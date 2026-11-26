using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using WindowsForm_DianPIan;
using WindowsFormsApp1;

namespace WinFrm_YWSB
{
    /// <summary>
    /// 主窗体。职责分四块：
    /// 1）图像来源：本地图片选择、相机连接与采集；
    /// 2）执行检测：把图像灌进 CogToolBlock，跑一次并取输出；
    /// 3）结果展示：检测图像、OK/NG/良品率/总数面板、检测记录表格；
    /// 4）数据持久化：每次检测写一份 CSV 明细，产量统计写 INI。
    ///
    /// 控件命名规则：前缀 + 拼音，例如
    /// btnXuanZeTuXiang（按钮）、cogXianShiYuanTu（Cognex 显示控件）、
    /// dgvJianCeJiLu（表格）、lstRiZhi（日志列表）、grpRiZhi（分组框）。
    /// </summary>
    public partial class MainForm : Form
    {
        #region 一、字段：图像与工具块

        /// <summary>当前待检测图像（24 位彩色），由“选择图像”或相机采集中赋值</summary>
        private CogImage24PlanarColor image;

        /// <summary>工具块引用，指向 DanLiToolBlock 里的同一个对象，不额外加载</summary>
        private CogToolBlock cogToolBlock;

        /// <summary>vpp 是否已加载完成；后台线程加载成功后置 true</summary>
        private bool IsVppReady = false;

        /// <summary>工具块单例，负责加载 / 保存 vpp</summary>
        private DanLiToolBlock danLiToolBlock;

        #endregion

        #region 二、字段：检测记录与产量统计

        /// <summary>
        /// 检测记录集合。直接绑定到 dgvJianCeJiLu，
        /// BindingList 会在 Add 时自动通知表格追加行，不需要手动 Rows.Add。
        /// </summary>
        private BindingList<CsvData> list;

        /// <summary>累计合格数（单次检测“合格”时加一），以内存为准</summary>
        private int OKCount = 0;

        /// <summary>累计不合格数（单次检测“不合格”时加一）</summary>
        private int NGCount = 0;

        #endregion

        #region 三、字段：配置文件与相机

        /// <summary>检测结果统计的 INI：OK / NG / Rate / Total</summary>
        private string iniFile = Path.Combine(Application.StartupPath, "INI", "Result.ini");

        /// <summary>相机参数的 INI（暂时只读，未接入界面）</summary>
        private string iniFileXJ = Path.Combine(Application.StartupPath, "INI", "XinagJi.ini");

        /// <summary>相机设备对象</summary>
        private ICogFrameGrabber frameGrabber;

        /// <summary>采集 FIFO，负责启动采集、接收完成回调</summary>
        private ICogAcqFifo acqFifo;

        /// <summary>相机采集到的图像（灰度/彩色由 FIFO 格式决定）</summary>
        private ICogImage cogImage;

        /// <summary>
        /// 是否处于连续采集状态。
        /// true 时 Complete 回调会继续请求下一张；false 时采完一张就停。
        /// </summary>
        private bool isLianXuCaiJi = false;

        /// <summary>
        /// FIFO 是否已切到自由运行（FreeRun）模式。
        /// FreeRun 下 StartAcquire 一次就会持续出图，不需要每次在 Complete 里续采；
        /// 硬件触发/手动触发模式下才需要在 Complete 里手动续采。
        /// </summary>
        private bool isFreeRunMode = false;

        /// <summary>上次刷新显示的时间（Environment.TickCount，毫秒）</summary>
        private int lastDisplayTick = 0;

        /// <summary>
        /// 界面刷新最小间隔（毫秒）。
        /// 相机可以每秒出几十张，但界面没必要每张都画：
        /// 采集照常进行，只是显示按这个间隔抽样，避免 UI 线程被刷爆。
        /// </summary>
        private const int DisplayIntervalMs = 100;

        #endregion

        #region 四、构造函数与初始化

        public MainForm()
        {
            InitializeComponent();

            danLiToolBlock = DanLiToolBlock.Instance;   // 只拿单例，vpp 交给后台线程加载
            EnsureIniFolder();                          // 保证 INI 目录存在，否则写 INI 会静默失败

            // 先绑一个空集合，让表格的列结构先画出来；
            // 真实记录由 LoadCsvInThread 读完后通过 BindCsvData 换上去。
            list = new BindingList<CsvData>();
            dgvJianCeJiLu.DataSource = list;
        }

        /// <summary>
        /// 确保 iniFile 所在目录存在。
        /// Windows 的 WritePrivateProfileString 只会写文件，不会自动建目录，
        /// 目录不存在时写 INI 返回 false 且不抛异常，现象是“界面有数字、重启就丢”。
        /// </summary>
        private void EnsureIniFolder()
        {
            string dir = Path.GetDirectoryName(iniFile);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        #endregion

        #region 五、窗体生命周期

        /// <summary>
        /// 窗体首次显示后启动三个后台任务：
        /// 读检测记录、读检测结果、加载 vpp。
        /// 放在 OnShown 而不是构造函数里，避免构造函数被阻塞、界面迟迟不显示。
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);          // 先让基类完成显示，再干活

            LoadCsvInThread();
            LoadIniInThread();
            LoadVppInThread();
        }

        /// <summary>
        /// 关闭窗体时停掉相机。
        /// 不停的话进程退出后设备可能仍被占用，下次“连接相机”会枚举失败或提示设备忙。
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (acqFifo != null)
            {
                try
                {
                    isLianXuCaiJi = false;
                    acqFifo.Flush();   // 丢弃未取的图像，停止后续采集
                }
                catch { }   // 关闭阶段不再提示，避免连锁异常
            }
        }

        #endregion

        #region 六、日志

        /// <summary>
        /// 往日志列表顶部插入一条带时间的记录。
        /// 内部自动判断线程：后台线程调用也会 Invoke 回 UI 线程，调用方不用管线程问题。
        /// </summary>
        private void AppendLog(string message)
        {
            if (this.lstRiZhi.InvokeRequired)
            {
                this.lstRiZhi.Invoke(new Action<string>(AppendLog), message);
            }
            else
            {
                this.lstRiZhi.Items.Insert(0, $"{DateTime.Now.ToString()}:{message}");
                this.lstRiZhi.SelectedIndex = 0;
                GengXinRiZhiKuanDu();   // 日志变长了，重算横向滚动范围，否则拉不出左右滚动条
            }
        }

        /// <summary>
        /// 按“最长的一条日志”重算横向滚动范围。
        /// ListBox 不会自己量文字宽度：只把 HorizontalScrollbar 设成 true 是没有横条的，
        /// 必须同时给 HorizontalExtent 一个大于可视宽度的像素值，Windows 才会画出滚动条。
        /// 每次插入日志、清空日志后都要调一次。
        /// </summary>
        private void GengXinRiZhiKuanDu()
        {
            if (lstRiZhi.Items.Count == 0)
            {
                lstRiZhi.HorizontalExtent = 0;   // 没有内容就不需要横条
                return;
            }

            int zuiKuan = 0;
            foreach (object item in lstRiZhi.Items)
            {
                string wenBen = item == null ? string.Empty : item.ToString();
                int kuan = TextRenderer.MeasureText(wenBen, lstRiZhi.Font).Width;
                if (kuan > zuiKuan)
                {
                    zuiKuan = kuan;
                }
            }

            lstRiZhi.HorizontalExtent = zuiKuan + 16;   // 多留 16px，避免最后一个字贴边被截掉
        }

        /// <summary>
        /// 日志列表的自绘回调。
        /// 设成 OwnerDrawFixed 只是为了“逼” ListBox 支持横向滚动条；
        /// ListBox 没有 e.DrawDefault（那是 ListView 才有的属性），所以这里按原生规则画三件事：
        /// 1) DrawBackground 画底色（选中项会自动用高亮色）
        /// 2) 用 TextRenderer 画文字，颜色取 e.ForeColor（选中项即高亮文字色）
        /// 3) DrawFocusRectangle 画虚线焦点框
        /// 起点跟着 e.Bounds 走，横向滚动时文字会一起平移。
        /// </summary>
        private void lstRiZhi_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            e.DrawBackground();   // 底色：普通行用白，选中行用系统高亮色

            string wenBen = lstRiZhi.Items[e.Index] == null ? string.Empty : lstRiZhi.Items[e.Index].ToString();
            Rectangle wenBenQu = new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height);

            TextRenderer.DrawText(e.Graphics,
                                  wenBen,
                                  lstRiZhi.Font,
                                  wenBenQu,
                                  e.ForeColor,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);

            e.DrawFocusRectangle();
        }

        #endregion

        #region 七、后台加载：工具块 vpp

        /// <summary>
        /// 后台线程加载 vpp。加载成功才把 IsVppReady 置 true，
        /// 检测按钮据此判断“能不能跑”。
        /// </summary>
        private void LoadVppInThread()
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    cogToolBlock = danLiToolBlock.GetToolBlock();   // 内部双检锁，重复调用不会重复加载
                    if (cogToolBlock == null)
                    {
                        this.Invoke(new Action(() => AppendLog("加载工具块失败")));
                        return;
                    }
                    this.Invoke(new Action(() =>
                    {
                        IsVppReady = true;
                        AppendLog("加载工具块成功");
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() => AppendLog($"加载工具块失败:{ex.Message}")));
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        #endregion

        #region 八、图像来源：本地图片

        /// <summary>
        /// “选择图像”：从磁盘选一张图，转成 CogImage24PlanarColor 显示在左侧。
        /// 只做显示，不自动检测，检测由“执行检测”按钮触发。
        /// </summary>
        private void btnXuanZeTuXiang_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图像文件|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|所有文件|*.*";
            openFileDialog.Title = "选择图像文件";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Bitmap bitmap = Bitmap.FromFile(filePath) as Bitmap;

                image = new CogImage24PlanarColor(bitmap);
                cogXianShiYuanTu.Image = image;
                cogXianShiYuanTu.Fit();
            }
        }

        #endregion

        #region 九、图像来源：相机

        #region 9.1 连接相机与采集初始化

        /// <summary>
        /// “连接相机”：枚举本机采集设备，取第一个并创建 8 位灰度 FIFO，
        /// 同时订阅采集完成事件 Fifo_Complete。
        /// </summary>
        private void btnLianJieXiangJi_Click(object sender, EventArgs e)
        {
            // 相机参数本来准备从 XinagJi.ini 读，目前只做占位，后续接界面的曝光、增益等
            string value = IniAPI.INIGetStringValue(iniFileXJ, "检测结果存储", "OK", "true");

            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            if (frameGrabbers == null || frameGrabbers.Count < 1)
            {
                AppendLog("未找到相机,请检测是否连接正常");
                return;
            }

            frameGrabber = frameGrabbers[0];
            AppendLog("成功抓取相机");

            // 参数1：视频格式 GigE Bayer 彩色格式
            // 参数2：像素格式 8bit 灰度
            // 参数3：相机端口 0
            // 参数4：autoPrepare = true，自动初始化硬件
            acqFifo = frameGrabber.CreateAcqFifo("Generic GigEVision (Bayer Color)",
                                                CogAcqFifoPixelFormatConstants.Format8Grey,
                                                0, true);
            // 连续采集的前提是自由运行（FreeRun）：相机自己按帧率持续曝光，
            // 每次 StartAcquire 立刻就能拿到一帧，不用等外触发。
            // 硬件外触发（光电开关）场景不要设 FreeRun，保持 Manual 即可。
            try
            {
                ICogAcqTrigger trigger = acqFifo.OwnedTriggerParams;
                if (trigger == null)
                {
                    isFreeRunMode = false;
                    AppendLog("该采集格式不支持触发参数，保持默认触发模式");
                }
                else
                {
                    trigger.TriggerModel = CogAcqTriggerModelConstants.FreeRun;
                    isFreeRunMode = true;
                    AppendLog("采集模式：自由运行（FreeRun）");
                }
            }
            catch (Exception ex)
            {
                // 采集卡或视频格式不支持改触发模式时，退化为“软件循环采集”
                isFreeRunMode = false;
                AppendLog($"设置自由运行失败，改用软件循环采集：{ex.Message}");
            }

            acqFifo.Complete += Fifo_Complete;   // 每采完一张触发一次
        }

        #endregion

        #region 9.2 采集完成回调

        /// <summary>
        /// FIFO 采集完成回调（在采集线程里触发，一次可能积压多张图）。
        /// 处理三件事：
        /// 1）把 FIFO 里已就绪的图像全部取出来，只保留最后一张；
        /// 2）显示按 DisplayIntervalMs 限频，采集照常、界面不必每帧都画；
        /// 3）连续采集且非 FreeRun 时，主动请求下一张（软件循环采集）。
        /// </summary>
        private void Fifo_Complete(object sender, EventArgs e)
        {
            try
            {
                // numPending：等待处理的采集任务数
                // numReady：已采集完成、待取出的图像数
                // busy：相机是否正在采集
                acqFifo.GetFifoState(out int numPending, out int numReady, out bool busy);

                if (numReady > 0)
                {
                    CogAcqInfo cogAcqInfo = new CogAcqInfo();
                    ICogImage newImage = null;

                    // 一次回调可能有多张就绪，全部取掉只留最后一张；
                    // 只取一张会让 FIFO 积压，画面越来越滞后
                    while (numReady > 0)
                    {
                        newImage = acqFifo.CompleteAcquireEx(cogAcqInfo);
                        numReady--;
                    }

                    cogImage = newImage;

                    // 限频刷新：界面每 DisplayIntervalMs 才更新一次，避免 UI 线程被刷爆
                    int now = Environment.TickCount;
                    if (now - lastDisplayTick >= DisplayIntervalMs)
                    {
                        lastDisplayTick = now;
                        ICogImage imageToShow = newImage;   // 用局部变量，防止显示到后面采的帧

                        // BeginInvoke：不阻塞采集线程，也不影响下一张采集
                        this.BeginInvoke(new Action(() =>
                        {
                            cogXianShiYuanTu.Image = imageToShow;
                            cogXianShiYuanTu.Fit();
                        }));
                    }
                }

                // 软件循环采集：每采完一张立刻请求下一张，形成连续采集。
                // VisionPro 的 ICogAcqFifo 没有 StopAcquire，停止靠“不再续采 + Flush”实现。
                if (isLianXuCaiJi)
                {
                    acqFifo.StartAcquire();
                }
            }
            catch (Exception ex)
            {
                AppendLog($"相机采集异常:{ex}");
            }
        }

        #endregion

        #region 9.3 采集控制：单次 / 连续 / 停止

        /// <summary>
        /// “相机采集”：单次采集一张。
        /// 连续采集进行中按它没有意义，直接提示并忽略。
        /// </summary>
        private void btnXiangJiCaiJi_Click(object sender, EventArgs e)
        {
            if (acqFifo == null)
            {
                AppendLog("相机没有连接");
                return;
            }
            if (isLianXuCaiJi)
            {
                AppendLog("正在连续采集，已忽略单次采集");
                return;
            }
            acqFifo.StartAcquire();   // 请求一张，取图在 Fifo_Complete 里
        }

        /// <summary>
        /// “连续采集”：同一个按钮兼作开始 / 停止。
        /// 第一次点击：置连续标志并请求第一张。
        ///   - FreeRun 模式下这一句之后相机会自己持续出图；
        ///   - 非 FreeRun 模式由 Fifo_Complete 每张续采，形成循环。
        /// 第二次点击：停止采集并复位标志。
        /// </summary>
        private void btnLianXuCaiJi_Click(object sender, EventArgs e)
        {
            if (acqFifo == null)
            {
                AppendLog("相机没有连接");
                return;
            }

            if (isLianXuCaiJi)
            {
                StopLianXuCaiJi();
                return;
            }

            isLianXuCaiJi = true;
            // 日志里区分两种连续采集的实现方式，排查“画面不动”时一眼能看出走的是哪条路径
            AppendLog(isFreeRunMode ? "开始连续采集（自由运行）" : "开始连续采集（软件循环）");
            acqFifo.StartAcquire();
        }

        /// <summary>
        /// 停止连续采集。
        /// 顺序不能反：先清标志，回调里就不会再续采；再 StopAcquire 才能真正停下。
        /// </summary>
        private void StopLianXuCaiJi()
        {
            if (!isLianXuCaiJi)
            {
                return;
            }

            isLianXuCaiJi = false;      // 先关标志，回调里就不会再请求下一张

            try
            {
                // ICogAcqFifo 没有 StopAcquire：不续采 + Flush 丢弃 FIFO 里还没取的图像
                acqFifo.Flush();
            }
            catch (Exception ex)
            {
                AppendLog($"停止采集异常:{ex.Message}");
            }

            AppendLog("已停止连续采集");
        }
        #endregion

        #endregion

        #region 十、执行检测

        /// <summary>
        /// “执行检测”：图像灌入工具块 → 跑一次 → 取检测图像 → 解析输出 →
        /// 写 CSV 明细 → 进内存集合（表格自动加行）→ 累计产量 → 刷新面板与 INI。
        /// 任何一步异常都被 catch 住并写日志，不会让界面弹错误框。
        /// </summary>
        private void btnZhiXingJianCe_Click(object sender, EventArgs e)
        {
            try
            {
                // 前置判断：vpp 没加载完时 ToolBlock 为 null，直接跑必崩空引用
                if (!IsVppReady)
                {
                    AppendLog("工具块尚未加载完成，请稍候再检测");
                    return;
                }
                // 前置判断：没有图像时工具块会跑失败
                if (image == null)
                {
                    AppendLog("请先选择图像或采集相机图像");
                    return;
                }

                cogToolBlock = danLiToolBlock.ToolBlock;      // 已加载完成，这里取到的是同一个对象
                cogToolBlock.Inputs[0].Value = image;
                cogToolBlock.Run();

                // 右侧显示本次运行的记录（SubRecords[0] 是图像记录）
                cogXianShiJianCeTu.Record = cogToolBlock.CreateLastRunRecord().SubRecords[0];
                cogXianShiJianCeTu.Fit();

                // 取工具块的三个输出项；TryParse 失败时保持 0
                int.TryParse(cogToolBlock.Outputs["OKNum"].Value.ToString(), out int heGeCount);
                int.TryParse(cogToolBlock.Outputs["NGNum"].Value.ToString(), out int queXianCount);
                int.TryParse(cogToolBlock.Outputs["QueShiNum"].Value.ToString(), out int queShiCount);

                string jieGuo = heGeCount == 15 ? "合格" : "不合格";

                // 1）CSV 明细：按次一行，跨月自动换文件
                CsvAPI.WriteCsv(heGeCount.ToString(), queXianCount.ToString(),
                                queShiCount.ToString(), jieGuo);

                // 2）内存集合：BindingList 会通知表格自动加一行
                CsvData csvData = new CsvData(DateTime.Now.ToString(),
                                              heGeCount.ToString(),
                                              queXianCount.ToString(),
                                              queShiCount.ToString(),
                                              jieGuo);
                list.Add(csvData);

                // 3）累计产量：按本次结果给 OK 或 NG 加一
                if (jieGuo == "合格")
                {
                    OKCount++;
                }
                else
                {
                    NGCount++;
                }

                // 4）界面与 INI 统一刷新，避免同一个除法在多处各写一遍
                RefreshResultPanel();
                SaveCheckResult();
                // 5）结果回传：串口没打开时 Write 会抛“端口已关闭”，
                //    那样后面的日志会被 catch 改成“检测失败”，看起来像检测本身出错，
                //    所以先判一次，把“通信没开”和“检测没跑通”区分开
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(heGeCount.ToString());
                }
                else
                {
                    AppendLog("串口未打开，本次结果未回传");
                }
                AppendLog("检测成功");
            }
            catch (Exception ex)
            {
                AppendLog("检测失败: " + ex.Message);
            }
        }

        #endregion

        #region 十一、后台加载：检测记录

        /// <summary>
        /// 后台线程读取本月 CSV 明细，读完回到 UI 线程绑定到表格。
        /// 读文件不放 UI 线程，是为了避免磁盘慢时界面卡住。
        /// </summary>
        private void LoadCsvInThread()
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    BindingList<CsvData> data = CsvAPI.ReadCsv();
                    if (data == null)                 // 文件不存在时 ReadCsv 返回 null
                    {
                        data = new BindingList<CsvData>();
                    }
                    BindCsvData(data);
                }
                catch (Exception ex)
                {
                    try
                    {
                        this.Invoke(new Action(() => AppendLog($"读取检测记录失败：{ex.Message}")));
                    }
                    catch { }   // 窗体已关闭时 Invoke 也会抛，这里吞掉即可
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 把读到的集合换成表格的数据源，必须在 UI 线程执行。
        /// 注意：更换 list 之后必须紧接着重绑 DataSource，
        /// 只换字段不重绑，表格还指着旧对象，界面看起来“没有反应”。
        /// </summary>
        private void BindCsvData(BindingList<CsvData> data)
        {
            if (this.IsDisposed) return;      // 窗体已关闭就不再碰控件

            if (this.InvokeRequired)          // 子线程调进来时，转给 UI 线程再执行
            {
                this.Invoke(new Action(() => BindCsvData(data)));
                return;
            }

            list = data;
            dgvJianCeJiLu.DataSource = list;

            if (list.Count == 0)
            {
                AppendLog("本月暂无检测记录");
            }
            else
            {
                AppendLog($"检测记录加载完成，共 {list.Count} 条");
            }
        }

        #endregion

        #region 十二、检测记录表格：刷新

        /// <summary>
        /// “加载数据”：重新读一次本月 CSV 并刷新表格。
        /// 适合在别处（比如手工改过 CSV）改完数据后手动刷新。
        /// </summary>
        private void btnJiaZaiShuJu_Click(object sender, EventArgs e)
        {
            AppendLog("开始刷新历史数据…");
            LoadCsvInThread();
        }

        #endregion

        #region 十三、后台加载：检测结果统计

        /// <summary>
        /// 后台线程读 INI 里的 OK / NG，回 UI 线程还原成产量统计。
        /// Rate、Total 都是派生值（Rate = OK / Total，Total = OK + NG），
        /// 读回来也不用来覆盖，避免 ini 被手改后界面数字自相矛盾。
        /// </summary>
        private void LoadIniInThread()
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    string okStr = IniAPI.INIGetStringValue(iniFile, "检测结果存储", "OK", "0");
                    string ngStr = IniAPI.INIGetStringValue(iniFile, "检测结果存储", "NG", "0");

                    this.Invoke(new Action(() => ApplyCheckResult(okStr, ngStr)));
                }
                catch (Exception ex)
                {
                    try
                    {
                        this.Invoke(new Action(() => AppendLog($"读取检测结果失败：{ex.Message}")));
                    }
                    catch { }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 把 INI 里读到的字符串还原成产量统计并刷新面板，必须在 UI 线程调用。
        /// 用 TryParse 而不是 Convert：ini 被手工改坏时只会变 0，不会 crash。
        /// </summary>
        private void ApplyCheckResult(string okStr, string ngStr)
        {
            if (this.IsDisposed) return;

            int ok = 0;
            int ng = 0;
            int.TryParse(okStr, out ok);
            int.TryParse(ngStr, out ng);

            OKCount = ok;      // 字段只在 UI 线程赋值，和检测按钮不冲突
            NGCount = ng;

            RefreshResultPanel();   // 总数、良品率都按 OK/NG 重算
            AppendLog($"产量统计加载完成：OK={ok}，NG={ng}");
        }

        #endregion

        #region 十四、检测结果面板

        #region 14.1 计算与显示

        /// <summary>
        /// 良品率 = OK / 总数，以 OKCount / NGCount 为唯一数据源。
        /// 总数为 0 时返回 0，避免 0/0 得到 NaN 显示成“NaN%”。
        /// </summary>
        private double GetRate()
        {
            int total = OKCount + NGCount;
            if (total <= 0)
            {
                return 0;
            }
            return (double)OKCount / total;
        }

        /// <summary>
        /// 按当前 OKCount / NGCount 刷新四个显示框（只动界面，不写文件）。
        /// 显示口径固定：良品率用 P2，即带百分号、保留两位小数。
        /// </summary>
        private void RefreshResultPanel()
        {
            txtOK.Text = OKCount.ToString();
            txtNG.Text = NGCount.ToString();
            txtZongShu.Text = (OKCount + NGCount).ToString();
            txtLiangPinLv.Text = GetRate().ToString("P2");
        }
        #endregion

        #region 14.2 写回 INI

        /// <summary>
        /// 把当前产量写回 INI。
        /// Rate 存 0~1 的纯小数、固定四位（如 0.9677），不带百分号；
        /// 带百分号的字符串只能显示，读回时会解析失败。
        /// </summary>
        private void SaveCheckResult()
        {
            IniAPI.INIWriteValue(iniFile, "检测结果存储", "OK", OKCount.ToString());
            IniAPI.INIWriteValue(iniFile, "检测结果存储", "NG", NGCount.ToString());
            IniAPI.INIWriteValue(iniFile, "检测结果存储", "Rate", GetRate().ToString("F4"));
            IniAPI.INIWriteValue(iniFile, "检测结果存储", "Total", (OKCount + NGCount).ToString());
        }
        #endregion

        #region 14.3 清零

        /// <summary>
        /// “清零”：产量统计归零。三件事必须一起做——字段归 0、界面归 0、INI 归 0，
        /// 少写文件的话重启程序数字会“复活”。
        /// 只清统计，不动检测记录表格和 CSV 明细。
        /// </summary>
        private void btnQingLing_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定清零产量统计吗？历史检测记录不会被删除。",
                                                  "确认清零",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Question);
            if (result != DialogResult.OK)
            {
                return;
            }

            OKCount = 0;
            NGCount = 0;
            RefreshResultPanel();
            SaveCheckResult();
            AppendLog("产量统计已清零");
        }
        #endregion

        #endregion

        #region 十五、菜单事件

        /// <summary>
        /// “编辑作业 → 药丸识别TB”：打开工具块编辑窗体。
        /// 必须用 GetToolBlock()（会触发加载），不能用只读属性 ToolBlock——
        /// 后者在 vpp 加载完成前是 null，传进子窗体会打开一个空白编辑器。
        /// </summary>
        private void tsmiCeLiangDianPian_Click(object sender, EventArgs e)
        {
            CogToolBlock toolBlock = danLiToolBlock.GetToolBlock();
            if (toolBlock == null)
            {
                AppendLog("工具块尚未加载完成，暂时无法打开编辑界面");
                return;
            }

            FrmToolBlock frmToolBlock = new FrmToolBlock(toolBlock);
            frmToolBlock.ShowDialog();
        }

        #endregion

        #region 十六、相机参数联动（菜单 → 参数子窗体 → 相机）

        /// <summary>
        /// “编辑作业 → 修改相机参数”：打开相机参数设置窗体，并把采集 FIFO 交给它
        /// 流程：判空 → new 子窗体（传入 acqFifo）→ 订阅参数变更事件 → 非模态显示
        /// 为什么先判空：子窗体必须拿到 acqFifo 才能写曝光、亮度、传输延迟，
        ///               相机没连时打开它只会得到一个改不动参数的窗口，不如直接拦下并提示。
        /// 为什么用 Show 而不是 ShowDialog：调参数需要边看画面边改，主界面要保持可操作。
        /// 注意：每点一次菜单都会 new 一个新子窗体，连点会叠出多个窗口；
        ///       规范做法是把它存成字段，已存在则 Activate 而不是重复创建。
        /// </summary>
        private void tsmiXiuGaiXiangJiCanShu_Click(object sender, EventArgs e)
        {
            if (acqFifo == null)
            {
                AppendLog("相机未初始化，无法打开相机参数设置界面");
                return;
            }
            // 子窗体需要FIFO才能直接改相机参数，相机未初始化时不能打开
            FrmCameraParams frmCameraParams = new FrmCameraParams(acqFifo);
            // 订阅子窗体参数变更事件，用户在子窗体确认后回调本窗体的处理方法
            frmCameraParams.ChangeCameraParams += FrmCamera_changeCameraParms;
            // 非模态显示：主窗体与子窗体可同时操作
            frmCameraParams.Show();
        }
        /// <summary>
        /// 子窗体参数确认后的回调：把 CameraParams 里的三项参数写到相机
        /// 执行时机：用户在 FrmCameraParams 点【保存设置】，子窗体触发 ChangeCameraParams 事件
        /// 说明：三项都通过 FIFO 的 Owned 系列属性下发，不需要另建相机会话
        /// </summary>
        private void FrmCamera_changeCameraParms(CameraParams cameraParams)
        {
            // 曝光时间：单位毫秒
            acqFifo.OwnedExposureParams.Exposure = cameraParams.ExposureTime;
            // 亮度（增益）：0~1归一化值
            acqFifo.OwnedBrightnessParams.Brightness = cameraParams.Brightness;
            // GigE传输延迟级别：整型档位，数值越大越抗丢包、帧率越低
            acqFifo.OwnedGigEVisionTransportParams.LatencyLevel = cameraParams.Level;
        }

        #endregion

        /// <summary>
        /// “通信 → 开启通信 / 关闭通信”开关。
        /// 判断依据改用 serialPort1.IsOpen（串口的真实状态），不再依赖菜单文字。
        ///
        /// 原代码的三处错：
        /// 1）判断和赋值都写在父菜单 tsmiTongXin 上（if 判 tsmiTongXin.Text，两个分支也给
        ///    tsmiTongXin.Text 赋值），而用户点击、看得见的是子菜单 开启通信ToolStripMenuItem；
        /// 2）子菜单的文字从头到尾没被改过，所以点完还是“开启通信”，看起来像没反应；
        /// 3）父菜单标签被覆盖成“开启通信 / 关闭通信”，菜单栏上原来的“通信”二字就没了，
        ///    截图里那一项显示成“关闭通信”正是这个原因。
        /// 更麻烦的是串口变成“隔一次点才真正打开”：第一次点走 else 关端口，
        /// 第二次点条件才成立去 Open，第三次点又关掉……所以通信时开时不开，
        /// 对端（端口 2）发过来的数据自然时有时无。
        /// </summary>
        private void 开启通信ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 被点击的菜单项。用 sender 取，读文字和改文字就是同一个控件，不会再认错对象
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi == null)
            {
                return;
            }

            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    // 订阅必须放在 Open 之后：Open 失败时不会残留一个指向死端口的订阅
                    serialPort1.DataReceived += Sp_DataReceived;
                    mi.Text = "关闭通信";
                    // 把实际生效的串口参数写进日志：波特率对不上，是“发得出去、收不回来”的头号原因
                    AppendLog($"串口 {serialPort1.PortName} 已打开：{serialPort1.BaudRate},"
                              + $"{serialPort1.DataBits},{serialPort1.Parity},{serialPort1.StopBits}");
                }
                catch (Exception ex)
                {
                    // 常见原因：端口号不存在、被串口调试助手等程序占用、权限不足
                    AppendLog($"打开 {serialPort1.PortName} 失败：{ex.Message}");
                }
            }
            else
            {
                // 先退订再 Close：Close 之后仍可能有一两个回调在路上
                serialPort1.DataReceived -= Sp_DataReceived;
                serialPort1.Close();
                mi.Text = "开启通信";
                AppendLog($"串口 {serialPort1.PortName} 已关闭");
            }
            // 关闭串口：这一步之后端口不可再读写，需要重新 Open 才能继续通信
        }

        /// <summary>
        /// 串口收到数据时触发。注意三件事：
        /// 1）它跑在串口自己的接收线程上，不是 UI 线程，不能直接改控件；
        ///    AppendLog 内部已经判断 InvokeRequired，会自己回到 UI 线程；
        /// 2）DataReceived 只保证“至少到了 1 个字节”，一帧数据可能被拆成多次回调，
        ///    正式项目要自己拼包（按换行符 / 固定长度 / 超时判断一帧结束）；
        /// 3）收到什么必须写出来，否则“收到了但没显示”和“根本没收到”现象完全一样。
        /// </summary>
        public void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // sender 就是触发事件的 SerialPort 实例，转成具体类型后才能读数据
            SerialPort sp = sender as SerialPort;
            if (sp == null || !sp.IsOpen)
            {
                return;   // 关闭瞬间仍可能有回调在路上，直接丢弃，避免访问已关闭的端口
            }

            // BytesToRead：接收缓冲区里已到达的字节数
            int size = sp.BytesToRead;
            if (size <= 0)
            {
                return;
            }

            byte[] buffer = new byte[size];
            // 把缓冲区里的字节全部读进 buffer（第三个参数是要读的字节数）
            sp.Read(buffer, 0, size);
            // 按 UTF-8 解码；若对端用 GBK 发送，中文会变乱码，需换成 Encoding.GetEncoding("GBK")
            string data = Encoding.UTF8.GetString(buffer);
            AppendLog($"[{sp.PortName}] 收到：{data}");
        }
    }
}

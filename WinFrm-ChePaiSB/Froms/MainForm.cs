using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;

namespace WinFrm_ChePaiSB
{
    /// <summary>
    /// 主窗体。职责分五块：
    /// 1）图像来源：本地图片读取（CogImageFileTool）、相机连接与采集（ICogAcqFifo）；
    /// 2）执行识别：把图像灌进 CogToolBlock，跑一次并取车牌号输出；
    /// 3）界面展示：原图 / 识别结果两块 CogRecordDisplay，车位信息四个数值框，历史记录表格；
    /// 4）数据持久化：每次识别写一份 CSV 明细，车位信息写 INI；
    /// 5）串口通信：开关串口、接收上位机指令、回传已停车辆数。
    ///
    /// 线程模型（排查界面卡死时先看这里）：
    ///   - 构造函数、按钮点击、菜单点击：全部在 UI 线程执行；
    ///   - LoadCsvInThread / LoadIniInThread / LoadVppInThread：新建后台线程读文件，
    ///     读完用 Invoke 回到 UI 线程再碰控件；
    ///   - Fifo_Complete：由采集卡的采集线程回调，不是 UI 线程；
    ///   - Sp_DataReceived：由串口的接收线程回调，不是 UI 线程。
    ///
    /// 控件命名规则：前缀 + 拼音，例如 btnXuanZeTuXiang（按钮）、cogXianShiYuanTu（Cognex 显示控件）、
    /// dgvJianCeJiLu（表格）、lstRiZhi（日志列表）。本窗体部分控件仍是设计器默认名
    /// （button1~4、textBox1~3、dataGridView1），改名要同步改 Designer，暂不动。
    /// </summary>
    public partial class MainForm : Form
    {
        #region 一、字段：车位统计与记录集合

        /// <summary>
        /// 历史记录集合。直接绑定到 dataGridView1，
        /// BindingList 会在 Add 时自动通知表格追加行，不需要手动 Rows.Add。
        /// 读文件成功后会被整体替换成新集合（见 BindCsvData）。
        /// </summary>
        private BindingList<CsvData> list;

        /// <summary>总车位数（容量），由 INI 读入，默认 100；不随停车变化</summary>
        int ZongCheWei = 100;

        /// <summary>已停车辆数，每识别成功一辆加一；剩余车位 = 总车位 - 本值</summary>
        int CheLiangNum = 0;

        #endregion

        #region 二、字段：配置文件与工具块

        /// <summary>车位信息的 INI：CPH / Time / ZCW / SYCW，固定放在 程序目录\INI\Result.ini</summary>
        private string iniFile = Path.Combine(Application.StartupPath, "INI", "Result.ini");

        /// <summary>相机参数的 INI（目前只读“硬触发”一项做占位，未接入界面）</summary>
        private string iniFileXJ = Path.Combine(Application.StartupPath, "INI", "XiangJi.ini");

        /// <summary>本地图片读取工具：Open 打开文件、Run 执行、OutputImage 取结果</summary>
        CogImageFileTool cogImageFileTool = new CogImageFileTool();

        /// <summary>工具块单例，负责加载 / 保存 vpp，避免多处各存一份互相覆盖</summary>
        private DanLiToolBlock danLiToolBlock;

        /// <summary>工具块引用，指向 DanLiToolBlock 里的同一个对象，不额外加载</summary>
        private CogToolBlock cogToolBlock;

        /// <summary>vpp 是否已加载完成；后台线程加载成功后置 true，识别按钮据此判断“能不能跑”</summary>
        private bool IsVppReady = false;

        #endregion

        #region 三、字段：相机与当前图像

        /// <summary>相机设备对象，由“连接相机”按钮枚举得到</summary>
        private ICogFrameGrabber frameGrabber;

        /// <summary>采集 FIFO，负责启动采集、接收完成回调</summary>
        private ICogAcqFifo acqFifo;

        /// <summary>
        /// 当前待识别的图像。
        /// 两处会赋值：本地图片读取（button1）、相机采集完成（Fifo_Complete）。
        /// 声明为 public 是为了将来给子窗体共享，目前只在窗体内使用。
        /// </summary>
        public ICogImage cogImage;

        #endregion

        #region 四、构造函数与窗体生命周期

        /// <summary>
        /// 构造函数：只做“不依赖文件”的初始化。
        /// 这里不读 CSV / INI / vpp——那些是磁盘操作，放这里会把窗口卡在启动阶段。
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            danLiToolBlock = DanLiToolBlock.Instance;   // 只拿单例，vpp 交给后台线程加载

            // 先绑一个空集合，让表格的列结构先画出来；
            // 真实记录由 LoadCsvInThread 读完后通过 BindCsvData 换上去
            list = new BindingList<CsvData>();
            dataGridView1.DataSource = list;
        }

        /// <summary>
        /// 窗体首次显示后启动三个后台任务：读停车记录、读车位信息、加载 vpp。
        /// 放在 OnShown 而不是构造函数里，避免构造函数被阻塞、界面迟迟不显示。
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);          // 先让基类完成显示，再干活

            LoadCsvInThread();
            LoadIniInThread();
            LoadVppInThread();
        }

        #endregion

        #region 五、后台加载：历史记录（CSV）

        /// <summary>
        /// 后台线程读取本月 CSV 明细，读完回到 UI 线程绑定到表格。
        /// 读文件不放 UI 线程，是为了避免磁盘慢或文件被 Excel 占用时界面卡住。
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
                        this.Invoke(new Action(() => AppendLog($"读取停车记录失败：{ex.Message}")));
                    }
                    catch { }   // 窗体已关闭时 Invoke 也会抛，这里吞掉即可
                }
            });
            thread.IsBackground = true;   // 后台线程：主窗体关闭时随之结束，不会拖住进程
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
            dataGridView1.DataSource = list;

            if (list.Count == 0)
            {
                AppendLog("本月暂无记录");
            }
            else
            {
                AppendLog($"停车记录加载完成，共 {list.Count} 条");
            }
        }

        #endregion

        #region 六、后台加载：车位信息（INI）

        /// <summary>
        /// 后台线程读 INI 里的车牌、时间、总车位、剩余车位，回 UI 线程还原显示。
        /// 段名必须与 SaveCheckResult 写入时一致（车位信息存储），否则永远读不到刚写进去的值。
        /// 注意：读的是“剩余车位”，已停车辆数由 总车位 - 剩余车位 反推，不需要单独存。
        /// </summary>
        private void LoadIniInThread()
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    string chePaiHao = IniAPI.INIGetStringValue(iniFile, "车位信息存储", "CPH", "无");
                    string shiJian = IniAPI.INIGetStringValue(iniFile, "车位信息存储", "Time", DateTime.Now.ToString("HH:mm:ss"));
                    string zongCheWei = IniAPI.INIGetStringValue(iniFile, "车位信息存储", "ZCW", "100");
                    string shengYuCheWei = IniAPI.INIGetStringValue(iniFile, "车位信息存储", "SYCW", "100");

                    this.Invoke(new Action(() => ApplyCheckResult(chePaiHao, shiJian, zongCheWei, shengYuCheWei)));
                }
                catch (Exception ex)
                {
                    try
                    {
                        this.Invoke(new Action(() => AppendLog($"读取车位信息失败：{ex.Message}")));
                    }
                    catch { }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 把 INI 里读到的字符串还原成车位统计并刷新面板，必须在 UI 线程调用。
        /// 用 TryParse 而不是 Convert：ini 被手工改坏时只会变 0，不会 crash。
        /// </summary>
        private void ApplyCheckResult(string chePaiHao, string shiJian, string zongCheWeiText, string shengYuCheWeiText)
        {
            if (this.IsDisposed) return;

            int zongCheWei;
            int shengYuCheWei;

            // TryParse 失败时 out 参数被赋 0，这里给总车位兜个底，避免出现 0 个车位
            if (!int.TryParse(zongCheWeiText, out zongCheWei) || zongCheWei <= 0)
            {
                zongCheWei = 100;
            }
            int.TryParse(shengYuCheWeiText, out shengYuCheWei);
            if (shengYuCheWei < 0 || shengYuCheWei > zongCheWei)
            {
                shengYuCheWei = zongCheWei;
            }

            ZongCheWei = zongCheWei;                       // 字段只在 UI 线程赋值，和识别按钮不冲突
            CheLiangNum = zongCheWei - shengYuCheWei;       // 已停车辆数由“总 - 剩余”反推

            RefreshResultPanel(chePaiHao, shiJian);
            AppendLog($"车位加载完成：总车位={ZongCheWei}，已停={CheLiangNum}");
        }

        #endregion

        #region 七、后台加载：工具块（VPP）

        /// <summary>
        /// 后台线程加载 vpp。加载成功才把 IsVppReady 置 true，
        /// 识别按钮据此判断“能不能跑”。
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

        #region 八、日志

        /// <summary>
        /// 往日志列表顶部插入一条带时间的记录。
        /// 内部自动判断线程：采集线程、串口线程调用时也会 Invoke 回 UI 线程，调用方不用管线程问题。
        /// 注意：ListBox 不会自己量文字宽度，长文本需要 HorizontalExtent 才能出横向滚动条（见 GengXinRiZhiKuanDu）。
        /// </summary>
        private void AppendLog(string message)
        {
            if (this.lstRiZhi.InvokeRequired)
            {
                this.lstRiZhi.Invoke(new Action<string>(AppendLog), message);
            }
            else
            {
                this.lstRiZhi.Items.Insert(0, $"{DateTime.Now}:{message}");
                this.lstRiZhi.SelectedIndex = 0;

                // 日志变长了就重算横向滚动范围，否则长文本被截断、也拉不出左右滚动条
                GengXinRiZhiKuanDu();
            }
        }

        /// <summary>
        /// 按“最长的一条日志”重算横向滚动范围。
        /// ListBox 只把 HorizontalScrollbar 设成 true 是没有横条的，
        /// 必须同时给 HorizontalExtent 一个大于可视宽度的像素值，Windows 才会画出滚动条。
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

        #endregion

        #region 九、车位信息面板与 INI 回写

        /// <summary>
        /// 按当前字段刷新四个显示框（只动界面，不写文件）。
        /// 控件与含义的对应关系（控件名是设计器默认名，改名前请同步确认）：
        ///   txtOK   → 车牌号
        ///   textBox2→ 进出时间
        ///   textBox1→ 总车位
        ///   textBox3→ 剩余车位
        /// </summary>
        private void RefreshResultPanel(string chePaiHao, string shiJian)
        {
            txtOK.Text = chePaiHao;
            textBox2.Text = shiJian;
            textBox1.Text = ZongCheWei.ToString();
            textBox3.Text = (ZongCheWei - CheLiangNum).ToString();
        }

        /// <summary>
        /// 把当前车位信息写回 INI。
        /// 段名“车位信息存储”必须与 LoadIniInThread 读取时一致，否则重启后读不到、界面回到默认值。
        /// 剩余车位算出来再写，不在调用方重复计算。
        /// </summary>
        private void SaveCheckResult(string chePaiHao, string shiJian)
        {
            IniAPI.INIWriteValue(iniFile, "车位信息存储", "CPH", chePaiHao);
            IniAPI.INIWriteValue(iniFile, "车位信息存储", "Time", shiJian);
            IniAPI.INIWriteValue(iniFile, "车位信息存储", "ZCW", ZongCheWei.ToString());
            IniAPI.INIWriteValue(iniFile, "车位信息存储", "SYCW", (ZongCheWei - CheLiangNum).ToString());
        }

        #endregion

        #region 十、图像来源：本地图片（更换图片）

        /// <summary>
        /// “更换图片”：用 CogImageFileTool 读一张本地图片，显示在左侧“原图采集”里。
        /// 只做显示，不自动识别，识别由“执行检测”按钮触发。
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            #region 使用 CogImageFileTool 读取本地图片

            // 创建文件打开对话框实例，供用户在电脑上选择图片
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 文件过滤规则：第一项为图像文件，第二项为所有文件
            openFileDialog.Filter = "图像文件|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|所有文件|*.*";
            // 对话框标题
            openFileDialog.Title = "选择图像文件";
            // RestoreDirectory=true：关闭对话框后，自动恢复到上次打开的文件夹路径
            openFileDialog.RestoreDirectory = true;

            // 弹出选择文件窗口；用户点【打开】返回 DialogResult.OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 用户选中文件的完整绝对路径
                string filePath = openFileDialog.FileName;

                try
                {
                    // 打开文件，打开模式：只读。
                    // 同一个 CogImageFileTool 反复 Open 新文件是允许的，不必每次都 new
                    cogImageFileTool.Operator.Open(filePath, CogImageFileModeConstants.Read);
                    // 运行图像读取工具，把图片加载进工具内部
                    cogImageFileTool.Run();
                }
                catch (Exception ex)
                {
                    // 常见原因：文件被占用、格式不被支持、路径含非法字符
                    AppendLog($"打开图片失败：{ex.Message}");
                    return;
                }

                // 将读取出来的输出图像保存到字段，供“执行检测”使用
                cogImage = cogImageFileTool.OutputImage;

                // 显示到左侧显示控件，并让图像自动缩放适配窗口
                cogRecordDisplay1.Image = cogImage;
                cogRecordDisplay1.Fit();
            }

            #endregion
        }

        #endregion

        #region 十一、图像来源：相机

        #region 11.1 连接相机与采集初始化

        /// <summary>
        /// “连接相机”：枚举本机采集设备，取第一个并创建 8 位灰度 FIFO，
        /// 同时订阅采集完成事件 Fifo_Complete。
        /// 失败原因通常是：相机未上电 / 网线不通 / 被其它软件占用。
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // 相机参数本来准备从 XiangJi.ini 读，目前只做占位，后续接界面的曝光、增益等
                string value = IniAPI.INIGetStringValue(iniFileXJ, "相机参数", "硬触发", "true");

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

                acqFifo.Complete += Fifo_Complete;   // 每采完一张触发一次
            }
            catch (Exception ex)
            {
                AppendLog($"初始化相机失败：{ex.Message}");
            }
        }

        #endregion

        #region 11.2 采集完成回调

        /// <summary>
        /// FIFO 采集完成回调。由采集卡的采集线程调用，不是 UI 线程。
        /// 处理两件事：取出就绪图像并显示；把图像存进字段供识别使用。
        /// 注意：这里直接给 CogRecordDisplay（ActiveX 控件）赋值属于跨线程操作 COM 控件，
        ///       规范做法是 BeginInvoke 回 UI 线程再赋值，当前实现存在偶发崩溃风险。
        /// </summary>
        private void Fifo_Complete(object sender, CogCompleteEventArgs e)
        {
            try
            {
                // 查询 FIFO 状态：
                // numPending：等待处理的采集任务数
                // numReady：已采集完成、待取出的图像数
                // busy：相机是否正在采集
                acqFifo.GetFifoState(out int numPending, out int numReady, out bool busy);

                // 有就绪图像才取，否则 CompleteAcquireEx 会一直等
                if (numReady > 0)
                {
                    CogAcqInfo cogAcqInfo = new CogAcqInfo();

                    // 从 FIFO 取出一张图像，同时带出采集附加信息
                    // 若本次采集异常终止，这里会抛 CogAcqAbnormalException，交给 catch 记日志
                    cogImage = acqFifo.CompleteAcquireEx(cogAcqInfo);

                    // 图像绑定显示控件（跨线程操作 ActiveX，建议改为 BeginInvoke）
                    this.cogRecordDisplay1.Image = cogImage;

                    // 图像自适应显示窗口大小
                    this.cogRecordDisplay1.Fit();
                }
            }
            catch (Exception ex)
            {
                // 采集异常不向外抛：Complete 事件里抛出去会直接打断程序
                AppendLog(ex.ToString());
            }
        }

        #endregion

        #region 11.3 拍摄照片（单次采集）

        /// <summary>
        /// “拍摄照片”：请求采集一张。
        /// StartAcquire 只是“下单”，取图仍然在 Fifo_Complete 里完成；
        /// 相机没连接时 acqFifo 为 null，必须先判空，否则空引用异常。
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            if (acqFifo == null)
            {
                AppendLog("相机没有连接");
                return;
            }

            // 启动 FIFO 采集任务（单次）
            acqFifo.StartAcquire();
        }

        #endregion

        #endregion

        #region 十二、执行识别

        /// <summary>
        /// “执行检测”：图像灌入工具块 → 跑一次 → 取识别图像 → 解析输出 →
        /// 写 CSV 明细 → 进内存集合（表格自动加行）→ 更新车位统计 → 刷新面板与 INI → 串口回传。
        /// 任何一步异常都被 catch 住并写日志，不会让界面弹错误框。
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 前置判断 1：vpp 没加载完时 ToolBlock 为 null，直接跑必崩空引用
                if (!IsVppReady)
                {
                    AppendLog("工具块尚未加载完成，请稍候再检测");
                    return;
                }

                // 前置判断 2：没有图像时工具块会跑失败
                if (cogImage == null)
                {
                    AppendLog("请先选择图像或采集相机图像");
                    return;
                }

                cogToolBlock = danLiToolBlock.ToolBlock;      // 已加载完成，这里取到的是同一个对象
                cogToolBlock.Inputs[0].Value = cogImage;      // 输入端子 0 约定为待检测图像
                cogToolBlock.Run();

                // 右侧显示本次运行的记录（SubRecords[0] 是图像记录）
                cogRecordDisplay2.Record = cogToolBlock.CreateLastRunRecord().SubRecords[0];
                cogRecordDisplay2.Fit();

                // 取工具块的车牌号输出项；识别失败时可能是空串
                string chePaiHao = cogToolBlock.Outputs["ChePaiHao"].Value.ToString();

                // 车位统计：驶入一辆，已停车辆数加一；总车位是容量，不能改
                CheLiangNum++;

                // 1）CSV 明细：按次一行，跨月自动换文件。
                //    注意：进站时间 / 出站时间 / 停车费三项目前是占位常量，
                //    真实业务需要按车牌号查上一条进站记录再算时长和费用
                CsvAPI.WriteCsv(chePaiHao, 10.ToString(), 20.ToString(), 15.ToString());

                // 2）内存集合：BindingList 会通知表格自动加一行
                CsvData csvData = new CsvData(DateTime.Now.ToString(), chePaiHao,
                                              10.ToString(), 20.ToString(), 15.ToString());
                list.Add(csvData);

                // 3）界面与 INI 一起刷新，时间只取一次，避免两处取到不同秒
                string shiJian = DateTime.Now.ToString("HH:mm:ss");
                RefreshResultPanel(chePaiHao, shiJian);
                SaveCheckResult(chePaiHao, shiJian);

                // 4）结果回传：串口没打开时 Write 会抛“端口已关闭”，
                //    那样后面的日志会被 catch 改成“检测失败”，看起来像识别本身出错，
                //    所以先判一次，把“通信没开”和“识别没跑通”区分开
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(CheLiangNum.ToString());
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

        #region 十三、串口通信

        /// <summary>
        /// “通信 → 开启通信 / 关闭通信”开关。
        /// 判断依据用 serialPort1.IsOpen（串口的真实状态），不依赖菜单文字。
        ///
        /// 原代码的三处错（已修正，改动原因留档）：
        /// 1）判断和赋值都写在父菜单 tsmiTongXin 上，而用户点击的是子菜单 开启通信ToolStripMenuItem；
        /// 2）子菜单文字从未被修改，点完还是“开启通信”，看起来像没反应；
        /// 3）父菜单标签被覆盖成“开启通信 / 关闭通信”，菜单栏上原来的“通信”二字就没了。
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
        }

        /// <summary>
        /// 串口收到数据时触发。注意三件事：
        /// 1）它跑在串口自己的接收线程上，不是 UI 线程，不能直接改控件；
        ///    AppendLog 内部已判断 InvokeRequired，会自己回到 UI 线程；
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

        #endregion

        #region 十四、菜单事件

        /// <summary>
        /// “编辑作业 → 车牌号识别”：打开工具块编辑窗体。
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

        /// <summary>
        /// “相机 → 修改相机参数”：打开相机参数设置窗体。
        /// 流程：判空 → new 子窗体（传入 acqFifo）→ 订阅参数变更事件 → 非模态显示。
        /// 为什么先判空：子窗体必须拿到 acqFifo 才能写曝光、亮度、传输延迟，
        ///               相机没连时打开它只会得到一个改不动参数的窗口。
        /// 为什么用 Show 而不是 ShowDialog：调参数需要边看画面边改，主界面要保持可操作。
        /// </summary>
        private void tsmiXiuGaiXiangJiCanShu_Click(object sender, EventArgs e)
        {
            if (acqFifo == null)
            {
                AppendLog("相机未初始化，无法打开相机参数设置界面");
                return;
            }

            FrmCameraParams frmCameraParams = new FrmCameraParams(acqFifo);
            // 订阅子窗体参数变更事件，用户在子窗体确认后回调本窗体的处理方法
            frmCameraParams.ChangeCameraParams += FrmCamera_changeCameraParms;
            // 非模态显示：主窗体与子窗体可同时操作
            frmCameraParams.Show();
        }

        /// <summary>
        /// 子窗体参数确认后的回调：把 CameraParams 里的三项参数写到相机。
        /// 执行时机：用户在 FrmCameraParams 点【保存设置】，子窗体触发 ChangeCameraParams 事件。
        /// 说明：三项都通过 FIFO 的 Owned 系列属性下发，不需要另建相机会话。
        /// </summary>
        private void FrmCamera_changeCameraParms(CameraParams cameraParams)
        {
            // 曝光时间：单位毫秒
            acqFifo.OwnedExposureParams.Exposure = cameraParams.ExposureTime;
            // 亮度（增益）：0~1 归一化值
            acqFifo.OwnedBrightnessParams.Brightness = cameraParams.Brightness;
            // GigE 传输延迟级别：整型档位，数值越大越抗丢包、帧率越低
            acqFifo.OwnedGigEVisionTransportParams.LatencyLevel = cameraParams.Level;
        }

        #endregion
    }
}

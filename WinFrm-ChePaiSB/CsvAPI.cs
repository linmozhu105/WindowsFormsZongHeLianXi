using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinFrm_ChePaiSB
{
    /// <summary>
    /// CSV 停车记录工具类
    /// 职责：把每一次识别结果追加写入“程序目录\Data\年月.csv”，一个自然月对应一个文件。
    /// 设计要点：
    ///   ① 只有当文件还一个字都没有时才写表头，避免每次追加都重复写一行表头；
    ///   ② 统一用 UTF-8 编码写入，Excel / WPS 双击即可正确显示中文；
    ///   ③ 本类只管“落盘”，不管界面提示；读文件出错时自己弹窗，写文件出错交给调用方处理。
    /// 常见故障：CSV 正被 Excel / WPS 打开时文件被独占锁定，写入会抛 IOException
    ///           （提示“正由另一进程使用，因此该进程无法访问此文件”），关掉表格软件即可。
    /// </summary>
    public class CsvAPI
    {
        #region 一、静态字段与静态构造

        /// <summary>
        /// 本月 CSV 文件的完整路径，形如 程序目录\Data\202611.csv
        /// 由静态构造函数在类型首次使用时算好，之后读写共用同一个路径，保证两边指向同一个文件。
        /// 注意：年月只在程序启动时取一次，程序跨月不重启仍会写在上个月的文件里；
        ///       若要严格按月分文件，应改成每次调用时按 DateTime.Now 重新拼路径。
        /// </summary>
        private static string csvPath;

        /// <summary>
        /// 静态构造函数：本类型第一次被使用时自动执行，且只执行一次
        /// 作用：确保 程序目录\Data 目录存在，并算好本月 CSV 文件路径
        /// 注意：Application.StartupPath 依赖 WinForms，所以本类只能在 WinForms 程序里使用
        /// </summary>
        static CsvAPI()
        {
            // 拼出 Data 目录的绝对路径：程序运行目录\Data
            string filePath = Path.Combine(Application.StartupPath, "Data");

            // 目录不存在才创建；CreateDirectory 对已存在目录本身是幂等的，这里判断只为语义清晰
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            // 按“年月”确定本月文件（如 202611.csv），读写都用这一个 csvPath
            DateTime now = DateTime.Now;
            csvPath = Path.Combine(filePath, $"{now:yyyyMM}.csv");
        }

        #endregion

        #region 二、写入记录

        /// <summary>
        /// 追加一行停车记录到“当前年月.csv”
        /// 执行流程：判断是否需要表头 → 追加模式打开文件 → 必要时先写表头 → 写数据行
        /// 注意：文件路径由静态构造函数算好，本方法不接收路径参数，调用方无法指定写到哪里。
        /// </summary>
        /// <param name="chePaiHao">车牌号，写入“车牌号”列</param>
        /// <param name="jinZhanShiJian">进站时间，写入“进站时间”列</param>
        /// <param name="chuZhanShiJian">出站时间，写入“出站时间”列</param>
        /// <param name="tingCheFei">停车费，写入“停车费”列</param>
        public static void WriteCsv(string chePaiHao, string jinZhanShiJian, string chuZhanShiJian, string tingCheFei)
        {
            // 取当前时间写“记录”列；文件名的年月已在静态构造函数里定好，这里不再参与命名
            DateTime dataTime = DateTime.Now;

            // append=true：追加方式打开，文件不存在会自动创建（Data 目录已由静态构造函数保证）
            // using：离开作用域自动 Dispose，保证文件句柄释放，不会把自己锁住
            using (StreamWriter sw = new StreamWriter(csvPath, true, Encoding.UTF8))
            {
                // 是否需要表头：文件不存在，或文件长度为 0（刚建出来的空文件）都算“还没有表头”
                // || 是短路运算：文件不存在时不会再去取 Length（对不存在的文件取 Length 会抛异常）
                if (!File.Exists(csvPath) || new FileInfo(csvPath).Length == 0)
                {
                    sw.WriteLine("记录,车牌号,进站时间,出站时间,停车费");
                }

                // 写数据行，五列顺序与表头一一对应
                // 时间列用 "yyyyMMddHHmmss"，定长、无分隔符，便于按文本排序
                sw.WriteLine($"{dataTime:yyyyMMddHHmmss},{chePaiHao},{jinZhanShiJian},{chuZhanShiJian},{tingCheFei}");
            }
        }

        #endregion

        #region 三、读取记录

        /// <summary>
        /// 读取本月 CSV 文件里的全部停车记录
        /// 返回：BindingList&lt;CsvData&gt;，每个元素是一行记录；文件不存在时返回 null（调用方按“无数据”处理）
        /// 流程：打开文件 → 跳过第一行表头 → 逐行按逗号拆分 → 转成 CsvData → 加入列表
        /// 注意：① 这是“全量读取”，文件行数多时耗时会变长，调用前应考虑放到后台线程；
        ///       ② 返回 BindingList 是为了直接绑给 DataGridView，元素增减会自动通知界面刷新；
        ///       ③ 只按逗号拆分，若某列文本本身含逗号会导致列数变多、后面取值错位。
        /// </summary>
        public static BindingList<CsvData> ReadCsv()
        {
            // 文件不存在（本月还没有任何记录）：返回 null，由调用方提示“暂无记录”
            if (!File.Exists(csvPath))
            {
                return null;
            }

            // 准备结果容器：BindingList 在元素增减时发通知，绑到表格后界面自动更新
            BindingList<CsvData> list = new BindingList<CsvData>();

            try
            {
                // using：读完自动释放文件句柄，避免把文件锁住影响后续写入
                using (StreamReader sr = new StreamReader(csvPath, Encoding.UTF8))
                {
                    // 第一行是表头，读掉不使用（变量名 oneline 只是占位，代表表头行）
                    string oneline = sr.ReadLine();

                    string tempStr = null;
                    // ReadLine 返回 null 表示到达文件末尾，循环结束
                    while ((tempStr = sr.ReadLine()) != null)
                    {
                        // 按逗号拆成“记录 / 车牌号 / 进站时间 / 出站时间 / 停车费”五段
                        // 风险：若某行字段不足 5 段，下面的 arr[4] 会抛 IndexOutOfRangeException，
                        //       异常被 catch 捕获后停止读取，前面已读到的数据仍会返回
                        string[] arr = tempStr.Split(',');

                        // 组装成一条记录，稍后统一加入列表
                        CsvData data = new CsvData(arr[0], arr[1], arr[2], arr[3], arr[4]);
                        list.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                // 读文件异常（被占用、编码不符、字段不足导致索引越界）统一弹窗提示
                // 注意：MessageBox 是模态的，会阻塞界面等用户点确定；正式项目建议改成写日志
                MessageBox.Show(ex.Message);
            }

            // 即使中途出错，也把已读到的部分返回，界面可以先显示已有数据
            return list;
        }

        #endregion
    }
}

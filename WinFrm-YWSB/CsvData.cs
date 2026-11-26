using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrm_YWSB
{
    /// <summary>
    /// 检测记录数据实体
    /// 作用：CSV 明细里的一行 ↔ 一个对象。既是 CsvAPI.ReadCsv 的解析产物，
    ///       也是检测记录表格（dgvJianCeJiLu）数据源 BindingList 的元素类型。
    /// 字段与 CSV 表头严格对应：时间 / 合格数量 / 缺陷数量 / 缺失数量 / 结果，顺序不可调换。
    /// 说明：五个字段都用 string 而不是 int，是为了和 CSV 文本直接互转——
    ///       读文件时不需要解析、写文件时不需要格式化，代价是数值比较前要自己转一次。
    ///       属性名会参与表格的列绑定：若设计器里没给列设 DataPropertyName，
    ///       一旦 AutoGenerateColumns 为 true，表格就会按这些属性名自动建列（表头显示英文）。
    /// </summary>
    public class CsvData
    {
        #region 数据属性
        /// <summary>
        /// 时间：检测发生的时刻，形如 "2026/11/25 21:06:02"
        /// 由调用方 DateTime.Now.ToString() 生成，与 CSV 里的时间列一致
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 合格数量：本次检测中判定为合格的目标个数
        /// 来自工具块输出端子 OKNum 的字符串形式
        /// </summary>
        public string HeGeNum { get; set; }

        /// <summary>
        /// 缺陷数量：本次检测中检出缺陷的目标个数
        /// 来自工具块输出端子 NGNum 的字符串形式
        /// </summary>
        public string QueXianNum { get; set; }

        /// <summary>
        /// 缺失数量：本次检测中"应有而未检出"的目标个数
        /// 来自工具块输出端子 QueShiNum，与缺陷数量是两个不同维度，不要混用
        /// </summary>
        public string QueShiNum { get; set; }

        /// <summary>
        /// 检测结果：整条记录的结论，取值为"合格"或"不合格"（中文，直接写进 CSV）
        /// 注意：判定规则硬编码在 MainForm.btnZhiXingJianCe_Click 里（合格数 == 15 才算合格），
        ///       改了工艺标准要同步改那里，本类只负责承载文本。
        /// </summary>
        public string JieGuo { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 无参构造函数
        /// 用途：BindingList 新增空对象、设计器反射、将来做反序列化时都需要它
        /// </summary>
        public CsvData() { }

        /// <summary>
        /// 五参构造函数：把"一行 CSV"的五个字段一次性装进对象
        /// 调用场景：ReadCsv 逐行解析时、以及每次检测完成后往表格里加一行时
        /// </summary>
        /// <param name="time">时间文本</param>
        /// <param name="heGeNum">合格数量（文本）</param>
        /// <param name="queXianNum">缺陷数量（文本）</param>
        /// <param name="queShiNum">缺失数量（文本）</param>
        /// <param name="jieGuo">检测结果：合格 / 不合格</param>
        public CsvData(string time, string heGeNum, string queXianNum, string queShiNum, string jieGuo)
        {
            Time = time;
            HeGeNum = heGeNum;
            QueXianNum = queXianNum;
            QueShiNum = queShiNum;
            JieGuo = jieGuo;
        }
        #endregion
    }
}

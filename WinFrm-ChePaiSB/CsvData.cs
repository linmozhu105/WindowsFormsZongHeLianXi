using System;

namespace WinFrm_ChePaiSB
{
    /// <summary>
    /// 停车记录数据实体
    /// 作用：CSV 明细里的一行 ↔ 一个对象。既是 CsvAPI.ReadCsv 的解析产物，
    ///       也是“历史记录”表格（dataGridView1）数据源 BindingList 的元素类型。
    /// 字段与 CSV 表头严格对应：记录 / 车牌号 / 进站时间 / 出站时间 / 停车费，顺序不可调换。
    /// 说明：五个字段全部用 string，是为了和 CSV 文本直接互转——
    ///       读文件时不需要解析、写文件时不需要格式化；代价是比较数值前要自己转换一次。
    /// 注意：属性名会参与表格的自动列绑定。若将来打开 AutoGenerateColumns，
    ///       表格会按这些属性名自动建列（表头显示英文），届时需要手动调整列标题。
    /// </summary>
    public class CsvData
    {
        #region 一、数据属性

        /// <summary>
        /// 时间：记录产生的时刻，形如 "2026/11/26 21:30:05"
        /// 由调用方 DateTime.Now.ToString() 生成，与 CSV 第一列一致
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 车牌号：识别出的车牌文本（如 豫A88888）
        /// 取自工具块输出端子 ChePaiHao；识别失败时可能是空串，调用方需自行兜底
        /// </summary>
        public string ChePaiHao { get; set; }

        /// <summary>
        /// 进站时间：车辆驶入的时刻
        /// 目前由主窗体写入占位值（尚未接入真实进站记录），字段本身只负责承载文本
        /// </summary>
        public string JinZhanTime { get; set; }

        /// <summary>
        /// 出站时间：车辆驶出的时刻
        /// 与进站时间配对使用，两者差值即停车时长，是计算停车费的依据
        /// </summary>
        public string ChuZhanTime { get; set; }

        /// <summary>
        /// 停车费：本次停车应缴金额（文本形式，直接写进 CSV，便于保留两位小数等格式）
        /// 注意：本类不做计费，费率与规则属于业务逻辑，应放在主窗体或独立的计费类里
        /// </summary>
        public string TingCheFei { get; set; }

        #endregion

        #region 二、构造函数

        /// <summary>
        /// 无参构造函数
        /// 用途：BindingList 需要能无参构造元素、设计器反射绑定、将来做反序列化时也依赖它
        /// </summary>
        public CsvData() { }

        /// <summary>
        /// 五参构造函数：把“一行 CSV”的五个字段一次性装进对象
        /// 调用场景：ReadCsv 逐行解析时、以及每次识别完成后往表格里追加一行时
        /// </summary>
        /// <param name="time">记录时间文本</param>
        /// <param name="chePaiHao">车牌号</param>
        /// <param name="jinZhanTime">进站时间</param>
        /// <param name="chuZhanTime">出站时间</param>
        /// <param name="tingCheFei">停车费</param>
        public CsvData(string time, string chePaiHao, string jinZhanTime, string chuZhanTime, string tingCheFei)
        {
            Time = time;
            ChePaiHao = chePaiHao;
            JinZhanTime = jinZhanTime;
            ChuZhanTime = chuZhanTime;
            TingCheFei = tingCheFei;
        }

        #endregion
    }
}

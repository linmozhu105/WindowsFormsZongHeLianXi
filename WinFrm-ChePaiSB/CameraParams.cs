using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrm_ChePaiSB
{
    /// <summary>
    /// 相机参数实体类
    /// 作用：在"相机参数设置"窗体与采集窗体之间传递一组相机运行参数，
    ///       避免逐个参数作为方法形参层层传递，后续新增参数时只改这个类。
    /// 说明：本类只承载数据，不含采集或配置逻辑，属于纯数据载体（POJO）。
    /// </summary>
    public class CameraParams
    {
        #region 数据属性
        /// <summary>
        /// 曝光时间
        /// 决定感光元件累计光量的时长：值越大图像越亮、运动物体越容易拖影。
        /// 单位：本项目统一用毫秒（VisionPro 的 OwnedExposureParams.Exposure 默认按毫秒处理），
        ///       换用其它 SDK 前要确认单位，必要时在这里做一次换算，别让上层各处各自换算。
        /// </summary>
        public Double ExposureTime { get; set; }

        /// <summary>
        /// 亮度（增益类参数）
        /// 对已采集的信号做整体放大：值越大图像越亮，但噪点也同步被放大，
        /// 与曝光时间不同，它不改变进光量，只改变信号放大的倍数（本项目取 0~1 的归一化值）。
        /// </summary>
        public Double Brightness { get; set; }

        /// <summary>
        /// 延迟级别（GigE 传输参数，整型档位）
        /// 作用是控制相机分包发送与主机接收的节拍：档位越大越不容易丢包，但帧率会被压低。
        /// 注意：0 也是合法档位（多数相机默认就是 0），界面下拉框里必须允许出现 0，否则回显会空白。
        /// </summary>
        public int Level { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 无参构造函数
        /// 用途：先 new 出对象，再逐项给属性赋值；
        ///       也用于对象反序列化（从 INI、JSON 还原参数时必须有无参构造）。
        /// </summary>
        public CameraParams() { }

        /// <summary>
        /// 三参构造函数
        /// 用途：参数齐全时一次性构造，避免"先 new 再赋值"的多行代码。
        /// </summary>
        /// <param name="exposureTime">曝光时间，单位毫秒（与 OwnedExposureParams.Exposure 一致）</param>
        /// <param name="brightness">亮度（增益），0~1 归一化值</param>
        /// <param name="level">GigE 传输延迟级别，0 起算的整型档位</param>
        public CameraParams(double exposureTime, double brightness, int level)
        {
            ExposureTime = exposureTime;
            Brightness = brightness;
            Level = level;
        }
        #endregion
    }
}

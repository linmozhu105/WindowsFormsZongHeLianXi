using System;
using System.IO;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;

namespace WinFrm_ChePaiSB
{
    /// <summary>
    /// 工具块单例：整个程序只加载、保存同一个 VPP 文件，避免多处各存一份互相覆盖。
    /// 加载（GetToolBlock）与保存（SaveVpp）都走这个类，路径也只在这里定义一次。
    /// </summary>
    public class DanLiToolBlock
    {
        #region 一、单例与内部状态

        /// <summary>唯一实例，类加载时创建</summary>
        private static readonly DanLiToolBlock _instance = new DanLiToolBlock();

        /// <summary>已加载的工具块；null 表示还没加载过</summary>
        private CogToolBlock toolBlock;

        /// <summary>双检锁用的锁对象</summary>
        private readonly object lockObj = new object();

        /// <summary>VPP 文件路径：程序目录下的 VPP\YaoWuShiBie-TB.vpp</summary>
        private static string VppPath
        {
            get { return Path.Combine(Application.StartupPath, "VPP", "ChePaiShiBie-TB.vpp"); }
        }

        /// <summary>私有构造函数，外部只能通过 Instance 取实例</summary>
        private DanLiToolBlock() { }

        /// <summary>对外暴露的唯一入口</summary>
        public static DanLiToolBlock Instance
        {
            get { return _instance; }
        }

        #endregion

        #region 二、加载工具块

        /// <summary>
        /// 取工具块。第一次调用才真正读文件，之后直接返回缓存对象。
        /// 用双检锁：多数情况不进锁、不排队，只有“还没加载”时才会有一个线程进去加载。
        /// 加载失败（文件不存在、版本不匹配）时返回 null，调用方必须判空。
        /// </summary>
        public CogToolBlock GetToolBlock()
        {
            if (toolBlock != null)
            {
                return toolBlock;
            }

            lock (lockObj)
            {
                if (toolBlock == null)
                {
                    toolBlock = CogSerializer.LoadObjectFromFile(VppPath) as CogToolBlock;
                }
            }

            return toolBlock;
        }

        /// <summary>
        /// 只读属性：返回当前已加载的对象，不会触发加载。
        /// 所以 vpp 还没加载时它是 null，要保证拿到对象请调用 GetToolBlock()。
        /// </summary>
        public CogToolBlock ToolBlock
        {
            get { return toolBlock; }
        }

        #endregion

        #region 三、保存工具块

        /// <summary>
        /// 把工具块写回 VPP 文件。
        /// 返回 true 表示写成功；false 表示路径不可写、文件被占用或对象非法。
        /// 具体异常不往上层抛，避免UI层写一堆 try，但也不吞掉原因——调用方可通过返回值提示用户。
        /// </summary>
        /// <param name="toolBlock">要保存的工具块，建议传编辑控件当前的 Subject</param>
        public static bool SaveVpp(CogToolBlock toolBlock)
        {
            if (toolBlock == null)
            {
                return false;      // 空对象交给序列化会抛异常，直接判掉
            }

            try
            {
                CogSerializer.SaveObjectToFile(toolBlock, VppPath);
                return true;
            }
            catch (Exception)
            {
                // 文件被占用、目录不可写、序列化失败都会走到这里，统一返回 false 由界面提示
                return false;
            }
        }

        #endregion
    }
}

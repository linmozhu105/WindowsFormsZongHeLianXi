using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsZongHeLianXi
{
    /// <summary>
    /// 程序入口类
    /// 本项目的练习窗体（Form1）为空壳，只用于验证工程能正常启动。
    /// 真正有业务逻辑的项目是同一解决方案下的 WinFrm-YWSB（药丸识别）。
    /// </summary>
    internal static class Program
    {
        #region 程序入口
        /// <summary>
        /// 应用程序的主入口点
        /// [STAThread]：把主线程初始化为单线程单元（STA），WinForms 控件的硬性要求
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 启用操作系统风格的视觉样式
            Application.EnableVisualStyles();
            // false：文本用 GDI 渲染，兼容老控件；true 走 GDI+，个别控件会错位
            Application.SetCompatibleTextRenderingDefault(false);
            // 启动消息循环并显示 Form1，阻塞到窗体关闭为止
            Application.Run(new Form1());
        }
        #endregion
    }
}

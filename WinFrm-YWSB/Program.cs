using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrm_YWSB
{
    /// <summary>
    /// 程序入口类
    /// 只在启动时用一次：设置全局渲染选项 → 启动消息循环 → 显示主窗体。
    /// 之后的流程全部在 MainForm 里，本类不再参与。
    /// </summary>
    public static class Program
    {
        #region 程序入口
        /// <summary>
        /// 应用程序的主入口点
        /// [STAThread]：把主线程初始化为单线程单元（STA），这是 WinForms + ActiveX 的硬性要求，
        ///               本程序的 Cognex 显示控件属于 COM 组件，去掉该特性会直接实例化失败。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 启用操作系统风格的视觉样式（按钮、分组框等按系统主题绘制）
            Application.EnableVisualStyles();
            // 文本渲染方式：false 表示用 GDI 渲染，兼容老控件；true 走 GDI+，文字更圆润但个别控件会错位
            Application.SetCompatibleTextRenderingDefault(false);
            // 启动主消息循环并显示主窗体，这一句会阻塞到主窗体关闭为止
            Application.Run(new MainForm());
        }
        #endregion
    }
}

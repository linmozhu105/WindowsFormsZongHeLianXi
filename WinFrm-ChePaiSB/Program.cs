using System;
using System.Windows.Forms;

namespace WinFrm_ChePaiSB
{
    /// <summary>
    /// 程序入口类
    /// 只在启动时用一次：设置全局渲染选项 → 启动消息循环 → 显示主窗体；
    /// 之后全部流程都在 MainForm 里，本类不再参与。
    /// 说明：声明为 internal static，语义上是"不给外部程序集调用"，
    ///       同时避免 IDE 的 Main 入口推断出现多个候选。
    /// </summary>
    internal static class Program
    {
        #region 程序入口

        /// <summary>
        /// 应用程序的主入口点
        /// [STAThread]：把主线程初始化为单线程单元（STA）。
        /// 这是 WinForms 的硬性要求，本项目还用到 Cognex 的 COM 显示控件，
        /// 去掉该特性会直接在实例化 ActiveX 控件时抛 COM 异常。
        /// 注意：方法名必须是 Main（大写 M），C# 区分大小写，编译器只认 Main。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 启用操作系统风格的视觉样式（按钮、分组框等按系统主题绘制）
            Application.EnableVisualStyles();

            // 文本渲染方式：false 表示用 GDI 渲染文字，兼容老控件；
            // true 走 GDI+，文字更圆润，但个别自绘控件会出现对齐偏差
            Application.SetCompatibleTextRenderingDefault(false);

            // 启动主消息循环并显示主窗体；这一句是阻塞的，窗口关闭后才返回
            // 注意：全程序只调用一次，写两次会导致"关掉主窗体后又弹出一个新的"
            Application.Run(new MainForm());
        }

        #endregion
    }
}

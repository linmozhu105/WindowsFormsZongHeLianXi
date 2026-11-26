using System;
using System.Windows.Forms;
using Cognex.VisionPro.ToolBlock;

namespace WinFrm_ChePaiSB
{
    /// <summary>
    /// 工具块编辑窗体。
    /// 主窗体把当前 CogToolBlock 传进来，这里用 cogZuoYeBianJi（CogToolBlockEditV2）
    /// 显示可编辑的作业树；用户改完点“保存”，把对象写回 VPP 文件。
    /// 注意：保存只改磁盘上的 vpp，内存里正在跑的还是旧对象，需要重启程序才生效。
    /// </summary>
    public partial class FrmToolBlock : Form
    {
        #region 一、字段

        /// <summary>要编辑的工具块，由主窗体通过构造函数传入，与主窗体共用同一个对象</summary>
        public CogToolBlock cogToolBlock;

        #endregion

        #region 二、构造函数

        /// <summary>
        /// 初始化界面并把工具块挂到编辑控件上。
        /// 传入 null 时只提示并返回，不去访问编辑控件的 Subject，
        /// 否则会抛 NullReferenceException（宁可打开一个空窗体也不能崩）。
        /// </summary>
        /// <param name="cogToolBlock">主窗体当前使用的工具块</param>
        public FrmToolBlock(CogToolBlock cogToolBlock)
        {
            InitializeComponent();

            this.cogToolBlock = cogToolBlock;

            if (this.cogToolBlock == null)
            {
                AppendLog("未传入工具块，编辑界面为空");
                return;
            }

            // 把工具块交给编辑控件；控件名是 cogZuoYeBianJi（设计器生成）
            cogZuoYeBianJi.Subject = this.cogToolBlock;
        }

        #endregion

        #region 三、日志

        /// <summary>
        /// 往日志列表顶部插入一条带时间的记录，后台线程调用会自动 Invoke 回 UI 线程。
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
            }
        }

        #endregion

        #region 四、保存工具块

        /// <summary>
        /// “保存”：取编辑控件当前的 Subject，写回 VPP 文件。
        /// 用局部变量而不是直接传字段，避免和实例字段同名混淆；
        /// Subject 为空时直接提示，不把 null 交给序列化方法。
        /// </summary>
        private void btnBaoCun_Click(object sender, EventArgs e)
        {
            CogToolBlock toolBlockToSave = cogZuoYeBianJi.Subject;

            if (toolBlockToSave == null)
            {
                AppendLog("没有可保存的工具块");
                return;
            }

            bool result = DanLiToolBlock.SaveVpp(toolBlockToSave);

            if (result)
            {
                AppendLog("保存成功，请重启程序生效");
            }
            else
            {
                AppendLog("保存失败，请检查路径或文件占用情况");
            }
        }

        #endregion
    }
}

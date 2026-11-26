using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;

namespace WinFrm_YWSB
{
    #region 委托声明
    /// <summary>
    /// 相机参数回传委托
    /// 用途：把本窗体中用户设置的三个参数打包成 CameraParams 对象，
    ///       通过 ChangeCameraParams 事件交回调用方（采集窗体），
    ///       这样两边只认一个数据对象，不必各自维护一套字段。
    /// </summary>
    /// <param name="cameraParams">打包后的相机参数对象</param>
    public delegate void ChangeDelegate(CameraParams cameraParams);
    #endregion

    #region 窗体定义
    /// <summary>
    /// 相机参数设置窗体
    /// 职责：① 打开时从 INI 读取曝光时间/亮度/延迟级别，下发给相机并回显到界面；
    ///       ② 用户改完点【保存设置】时，把三个值打包成 CameraParams 通过事件回传给采集窗体。
    /// 说明：本窗体只做"参数收集与回传"，不负责采集、不负责显示图像；
    ///       当前版本也没有写INI的动作，需要持久化时由调用方在事件里自行调用 IniAPI.INIWriteValue。
    /// </summary>
    public partial class FrmCameraParams : Form
    {
        #region 成员字段
        /// <summary>
        /// 采集FIFO对象：由外部采集窗体传入，本窗体只借用它来设置参数，
        /// 不创建、不销毁，生命周期归调用方管理。
        /// </summary>
        private ICogAcqFifo acqFifo;

        /// <summary>
        /// INI配置文件路径：程序运行目录\INI\camera.ini
        /// 与主窗体 MainForm 用的是同一个文件，所以两边的节名、键名必须严格一致，
        /// 任何一边改名都会导致另一边读到默认值。
        /// </summary>
        string iniFile = Path.Combine(Application.StartupPath, "INI", "camera.ini");

        /// <summary>
        /// 相机参数变更事件：供外部订阅，本窗体在确认参数后触发。
        /// 声明为事件而不是普通委托字段，是为了让外部只能 add/remove，不能直接调用。
        /// </summary>
        public event ChangeDelegate ChangeCameraParams;
        #endregion

        #region 构造函数
        /// <summary>
        /// 无参构造函数
        /// 仅供设计器使用。注意：这条路径不会给 acqFifo 赋值，也不会订阅 Load，
        /// 实际运行时不要用它创建窗体，否则参数下发会空引用。
        /// </summary>
        public FrmCameraParams()
        {
            // 初始化窗体组件（设计器生成的控件创建与布局代码）
            InitializeComponent();
        }

        /// <summary>
        /// 带参构造函数
        /// 由采集窗体传入 FIFO，本窗体才能直接操作相机的曝光、亮度、传输参数。
        /// </summary>
        /// <param name="acqFifo">调用方已创建好的采集FIFO</param>
        public FrmCameraParams(ICogAcqFifo acqFifo)
        {
            // 初始化窗体组件
            InitializeComponent();
            // 保存传入的FIFO引用，后续所有参数读写都走它
            this.acqFifo = acqFifo;
            // 订阅窗体加载事件：只有拿到FIFO的这条构造路径才需要初始化参数回显
            this.Load += FrmCameraParams_Load;
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 窗体加载事件：从INI读出上次保存的参数 → 下发给相机 → 回显到界面
        /// 顺序不能颠倒，先去下发再回显，界面显示的值才是相机真实生效的值。
        /// </summary>
        private void FrmCameraParams_Load(object sender, EventArgs e)
        {
            try
            {
                // 读曝光时间：INI里存的是字符串，默认值100（毫秒）
                string exposureTimeStr = IniAPI.INIGetStringValue(iniFile, "相机运行参数", "曝光时间", "100");
                // 字符串转数值，失败时 exposureTime 为 0（TryParse 不回抛异常）
                double.TryParse(exposureTimeStr, out double exposureTime);
                // 下发曝光时间到相机：单位为毫秒
                acqFifo.OwnedExposureParams.Exposure = exposureTime;

                // 读亮度：默认0.01，区间通常为0~1，是信号放大倍数而不是进光量
                string brightnessStr = IniAPI.INIGetStringValue(iniFile, "相机运行参数", "亮度", "0.01");
                double.TryParse(brightnessStr, out double brightness);
                // 下发亮度到相机
                acqFifo.OwnedBrightnessParams.Brightness = brightness;

                // 读延迟级别：默认0，GigE传输参数，值是整型
                string levelStr = IniAPI.INIGetStringValue(iniFile, "相机运行参数", "延迟级别", "0");
                int.TryParse(levelStr, out int level);
                // 下发延迟级别：控制相机发包与主机接收的节拍，数值越大越抗丢包但帧率越低
                acqFifo.OwnedGigEVisionTransportParams.LatencyLevel = level;

                // 回显：直接写INI里的原始字符串，不再把数值格式化回去，避免显示上被改写
                txtBaoGuang.Text = exposureTimeStr;
                txtLiangDu.Text = brightnessStr;
                // cmbYanChiJiBie 用 Text 回显的前提是下拉列表里已有该项，否则纯下拉样式下会显示空白
                cmbYanChiJiBie.Text = levelStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("参数设置失败：" + ex.Message, "错误");
            }
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 【保存设置】按钮点击事件
        /// 流程：取三个输入控件里的文本 → 各自转成目标类型 → 打包成 CameraParams → 触发事件交回主窗体
        /// 说明：本窗体自己不下发参数，也不写INI，只负责"收集 + 上报"，怎么用由调用方决定；
        ///       TryParse 失败时得到的是默认 0，不要让用户输入非法字符串后静默变成 0 还没提示。
        /// </summary>
        private void btnBaoCun_Click(object sender, EventArgs e)
        {
            // 三项输入各自转换为目标类型
            double.TryParse(txtBaoGuang.Text.Trim(), out double exposureTime);
            double.TryParse(txtLiangDu.Text.Trim(), out double brightness);
            int.TryParse(cmbYanChiJiBie.Text.Trim(), out int level);
            // 用三参构造函数一次性打包，避免先new再逐项赋值
            CameraParams cameraParams = new CameraParams(exposureTime, brightness, level);
            // ?.Invoke：没有任何订阅者时事件为null，用空条件运算符可避免空引用异常
            ChangeCameraParams?.Invoke(cameraParams);
        }
        #endregion
    }
    #endregion
}

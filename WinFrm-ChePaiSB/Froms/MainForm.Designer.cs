namespace WinFrm_ChePaiSB
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        ///
        /// 配色取自同解决方案的 WinFrm-YWSB，两套界面保持同一视觉规范：
        /// 页面底色 #F5F7FA、卡片纯白、主色 #2B579A、正文 #212B36、辅助文字 #6E7884。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnsCaiDan = new System.Windows.Forms.MenuStrip();
            this.tsmiBianJiZuoYe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCeLiangDianPian = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShuJu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXiuGaiBaoCunShuJu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXiangJi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXiuGaiXiangJiCanShu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiJiZhun = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSheZhiJiZhunDian = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBiaoDing = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSheZhiYinDaoBiaoDing = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTongXin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXiuGaiTongXinFangShi = new System.Windows.Forms.ToolStripMenuItem();
            this.开启通信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpYuanTu = new System.Windows.Forms.GroupBox();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.grpShiBieTu = new System.Windows.Forms.GroupBox();
            this.cogRecordDisplay2 = new Cognex.VisionPro.CogRecordDisplay();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.进站车牌 = new System.Windows.Forms.Label();
            this.txtOK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstRiZhi = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlpAnNiu = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.mnsCaiDan.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpYuanTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.grpShiBieTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tlpAnNiu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsCaiDan
            // 
            this.mnsCaiDan.BackColor = System.Drawing.Color.White;
            this.mnsCaiDan.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mnsCaiDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.mnsCaiDan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsCaiDan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBianJiZuoYe,
            this.tsmiShuJu,
            this.tsmiXiangJi,
            this.tsmiJiZhun,
            this.tsmiBiaoDing,
            this.tsmiTongXin});
            this.mnsCaiDan.Location = new System.Drawing.Point(0, 0);
            this.mnsCaiDan.Name = "mnsCaiDan";
            this.mnsCaiDan.Padding = new System.Windows.Forms.Padding(12, 6, 0, 6);
            this.mnsCaiDan.Size = new System.Drawing.Size(1262, 37);
            this.mnsCaiDan.TabIndex = 6;
            this.mnsCaiDan.Text = "mnsCaiDan";
            // 
            // tsmiBianJiZuoYe
            // 
            this.tsmiBianJiZuoYe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCeLiangDianPian});
            this.tsmiBianJiZuoYe.Name = "tsmiBianJiZuoYe";
            this.tsmiBianJiZuoYe.Size = new System.Drawing.Size(88, 25);
            this.tsmiBianJiZuoYe.Text = "编辑作业";
            // 
            // tsmiCeLiangDianPian
            // 
            this.tsmiCeLiangDianPian.Name = "tsmiCeLiangDianPian";
            this.tsmiCeLiangDianPian.Size = new System.Drawing.Size(174, 26);
            this.tsmiCeLiangDianPian.Text = "车牌号识别";
            this.tsmiCeLiangDianPian.Click += new System.EventHandler(this.tsmiCeLiangDianPian_Click);
            // 
            // tsmiShuJu
            // 
            this.tsmiShuJu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiXiuGaiBaoCunShuJu});
            this.tsmiShuJu.Name = "tsmiShuJu";
            this.tsmiShuJu.Size = new System.Drawing.Size(56, 25);
            this.tsmiShuJu.Text = "数据";
            // 
            // tsmiXiuGaiBaoCunShuJu
            // 
            this.tsmiXiuGaiBaoCunShuJu.Name = "tsmiXiuGaiBaoCunShuJu";
            this.tsmiXiuGaiBaoCunShuJu.Size = new System.Drawing.Size(224, 26);
            this.tsmiXiuGaiBaoCunShuJu.Text = "查看保存数据";
            // 
            // tsmiXiangJi
            // 
            this.tsmiXiangJi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiXiuGaiXiangJiCanShu});
            this.tsmiXiangJi.Name = "tsmiXiangJi";
            this.tsmiXiangJi.Size = new System.Drawing.Size(56, 25);
            this.tsmiXiangJi.Text = "相机";
            // 
            // tsmiXiuGaiXiangJiCanShu
            // 
            this.tsmiXiuGaiXiangJiCanShu.Name = "tsmiXiuGaiXiangJiCanShu";
            this.tsmiXiuGaiXiangJiCanShu.Size = new System.Drawing.Size(224, 26);
            this.tsmiXiuGaiXiangJiCanShu.Text = "修改相机参数";
            this.tsmiXiuGaiXiangJiCanShu.Click += new System.EventHandler(this.tsmiXiuGaiXiangJiCanShu_Click);
            // 
            // tsmiJiZhun
            // 
            this.tsmiJiZhun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSheZhiJiZhunDian});
            this.tsmiJiZhun.Name = "tsmiJiZhun";
            this.tsmiJiZhun.Size = new System.Drawing.Size(56, 25);
            this.tsmiJiZhun.Text = "基准";
            // 
            // tsmiSheZhiJiZhunDian
            // 
            this.tsmiSheZhiJiZhunDian.Name = "tsmiSheZhiJiZhunDian";
            this.tsmiSheZhiJiZhunDian.Size = new System.Drawing.Size(174, 26);
            this.tsmiSheZhiJiZhunDian.Text = "设置基准点";
            // 
            // tsmiBiaoDing
            // 
            this.tsmiBiaoDing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSheZhiYinDaoBiaoDing});
            this.tsmiBiaoDing.Name = "tsmiBiaoDing";
            this.tsmiBiaoDing.Size = new System.Drawing.Size(56, 25);
            this.tsmiBiaoDing.Text = "标定";
            // 
            // tsmiSheZhiYinDaoBiaoDing
            // 
            this.tsmiSheZhiYinDaoBiaoDing.Name = "tsmiSheZhiYinDaoBiaoDing";
            this.tsmiSheZhiYinDaoBiaoDing.Size = new System.Drawing.Size(190, 26);
            this.tsmiSheZhiYinDaoBiaoDing.Text = "设置引导标定";
            // 
            // tsmiTongXin
            // 
            this.tsmiTongXin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiXiuGaiTongXinFangShi,
            this.开启通信ToolStripMenuItem});
            this.tsmiTongXin.Name = "tsmiTongXin";
            this.tsmiTongXin.Size = new System.Drawing.Size(56, 25);
            this.tsmiTongXin.Text = "通信";
            // 
            // tsmiXiuGaiTongXinFangShi
            // 
            this.tsmiXiuGaiTongXinFangShi.Name = "tsmiXiuGaiTongXinFangShi";
            this.tsmiXiuGaiTongXinFangShi.Size = new System.Drawing.Size(190, 26);
            this.tsmiXiuGaiTongXinFangShi.Text = "修改通信方式";
            // 
            // 开启通信ToolStripMenuItem
            // 
            this.开启通信ToolStripMenuItem.Name = "开启通信ToolStripMenuItem";
            this.开启通信ToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.开启通信ToolStripMenuItem.Text = "开启通信";
            this.开启通信ToolStripMenuItem.Click += new System.EventHandler(this.开启通信ToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grpYuanTu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpShiBieTu, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1262, 716);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // grpYuanTu
            // 
            this.grpYuanTu.BackColor = System.Drawing.Color.White;
            this.grpYuanTu.Controls.Add(this.cogRecordDisplay1);
            this.grpYuanTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpYuanTu.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpYuanTu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.grpYuanTu.Location = new System.Drawing.Point(16, 16);
            this.grpYuanTu.Margin = new System.Windows.Forms.Padding(6);
            this.grpYuanTu.Name = "grpYuanTu";
            this.grpYuanTu.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.grpYuanTu.Size = new System.Drawing.Size(609, 508);
            this.grpYuanTu.TabIndex = 0;
            this.grpYuanTu.TabStop = false;
            this.grpYuanTu.Text = "原图采集";
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(10, 30);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(589, 468);
            this.cogRecordDisplay1.TabIndex = 0;
            // 
            // grpShiBieTu
            // 
            this.grpShiBieTu.BackColor = System.Drawing.Color.White;
            this.grpShiBieTu.Controls.Add(this.cogRecordDisplay2);
            this.grpShiBieTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpShiBieTu.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpShiBieTu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.grpShiBieTu.Location = new System.Drawing.Point(637, 16);
            this.grpShiBieTu.Margin = new System.Windows.Forms.Padding(6);
            this.grpShiBieTu.Name = "grpShiBieTu";
            this.grpShiBieTu.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.grpShiBieTu.Size = new System.Drawing.Size(609, 508);
            this.grpShiBieTu.TabIndex = 1;
            this.grpShiBieTu.TabStop = false;
            this.grpShiBieTu.Text = "识别结果";
            // 
            // cogRecordDisplay2
            // 
            this.cogRecordDisplay2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay2.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay2.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogRecordDisplay2.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay2.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay2.Location = new System.Drawing.Point(10, 30);
            this.cogRecordDisplay2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay2.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay2.Name = "cogRecordDisplay2";
            this.cogRecordDisplay2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay2.OcxState")));
            this.cogRecordDisplay2.Size = new System.Drawing.Size(589, 468);
            this.cogRecordDisplay2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 30);
            this.tabControl1.Location = new System.Drawing.Point(16, 536);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(609, 164);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(8);
            this.tabPage1.Size = new System.Drawing.Size(601, 126);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "车位信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.进站车牌, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtOK, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(585, 110);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.textBox3.Location = new System.Drawing.Point(382, 65);
            this.textBox3.Margin = new System.Windows.Forms.Padding(6, 0, 10, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(193, 34);
            this.textBox3.TabIndex = 7;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.textBox2.Location = new System.Drawing.Point(382, 10);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 0, 10, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(193, 34);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.label3.Location = new System.Drawing.Point(292, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 55);
            this.label3.TabIndex = 4;
            this.label3.Text = "进出时间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.textBox1.Location = new System.Drawing.Point(90, 65);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 0, 10, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(192, 34);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // 进站车牌
            // 
            this.进站车牌.Dock = System.Windows.Forms.DockStyle.Fill;
            this.进站车牌.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.进站车牌.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.进站车牌.Location = new System.Drawing.Point(0, 0);
            this.进站车牌.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.进站车牌.Name = "进站车牌";
            this.进站车牌.Size = new System.Drawing.Size(78, 55);
            this.进站车牌.TabIndex = 0;
            this.进站车牌.Text = "车牌信息";
            this.进站车牌.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOK
            // 
            this.txtOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOK.BackColor = System.Drawing.Color.White;
            this.txtOK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.txtOK.Location = new System.Drawing.Point(90, 10);
            this.txtOK.Margin = new System.Windows.Forms.Padding(6, 0, 10, 0);
            this.txtOK.Name = "txtOK";
            this.txtOK.ReadOnly = true;
            this.txtOK.Size = new System.Drawing.Size(192, 34);
            this.txtOK.TabIndex = 2;
            this.txtOK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.label2.Location = new System.Drawing.Point(0, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 55);
            this.label2.TabIndex = 1;
            this.label2.Text = "总车位";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.label4.Location = new System.Drawing.Point(292, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 55);
            this.label4.TabIndex = 5;
            this.label4.Text = "剩余车位";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(601, 126);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "历史记录";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(595, 120);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ChePaiHao";
            this.Column1.HeaderText = "车牌号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "JinZhanTime";
            this.Column2.HeaderText = "进站时间";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ChuZhanTime";
            this.Column3.HeaderText = "出站时间";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TingCheFei";
            this.Column4.HeaderText = "费用";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(637, 536);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(609, 164);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lstRiZhi);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.groupBox1.Size = new System.Drawing.Size(292, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行日志";
            // 
            // lstRiZhi
            // 
            this.lstRiZhi.BackColor = System.Drawing.Color.White;
            this.lstRiZhi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRiZhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRiZhi.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstRiZhi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.lstRiZhi.FormattingEnabled = true;
            this.lstRiZhi.HorizontalScrollbar = true;
            this.lstRiZhi.IntegralHeight = false;
            this.lstRiZhi.ItemHeight = 20;
            this.lstRiZhi.Location = new System.Drawing.Point(10, 30);
            this.lstRiZhi.Name = "lstRiZhi";
            this.lstRiZhi.Size = new System.Drawing.Size(272, 112);
            this.lstRiZhi.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.tlpAnNiu);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.groupBox2.Location = new System.Drawing.Point(310, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.groupBox2.Size = new System.Drawing.Size(293, 152);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能按钮";
            // 
            // tlpAnNiu
            // 
            this.tlpAnNiu.BackColor = System.Drawing.Color.White;
            this.tlpAnNiu.ColumnCount = 2;
            this.tlpAnNiu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnNiu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnNiu.Controls.Add(this.button3, 0, 0);
            this.tlpAnNiu.Controls.Add(this.button1, 1, 0);
            this.tlpAnNiu.Controls.Add(this.button4, 0, 1);
            this.tlpAnNiu.Controls.Add(this.button2, 1, 1);
            this.tlpAnNiu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAnNiu.Location = new System.Drawing.Point(10, 30);
            this.tlpAnNiu.Name = "tlpAnNiu";
            this.tlpAnNiu.RowCount = 2;
            this.tlpAnNiu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnNiu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnNiu.Size = new System.Drawing.Size(273, 112);
            this.tlpAnNiu.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(226)))), ((int)(((byte)(245)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.button3.Location = new System.Drawing.Point(6, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 44);
            this.button3.TabIndex = 0;
            this.button3.Text = "连接相机";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(226)))), ((int)(((byte)(245)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.button1.Location = new System.Drawing.Point(142, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "更换图片";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(226)))), ((int)(((byte)(245)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.button4.Location = new System.Drawing.Point(6, 62);
            this.button4.Margin = new System.Windows.Forms.Padding(6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 44);
            this.button4.TabIndex = 2;
            this.button4.Text = "拍摄照片";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(130)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(108)))), ((int)(((byte)(183)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(142, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "执行检测";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mnsCaiDan);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车牌识别";
            this.mnsCaiDan.ResumeLayout(false);
            this.mnsCaiDan.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpYuanTu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.grpShiBieTu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tlpAnNiu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsCaiDan;
        private System.Windows.Forms.ToolStripMenuItem tsmiBianJiZuoYe;
        private System.Windows.Forms.ToolStripMenuItem tsmiCeLiangDianPian;
        private System.Windows.Forms.ToolStripMenuItem tsmiShuJu;
        private System.Windows.Forms.ToolStripMenuItem tsmiXiuGaiBaoCunShuJu;
        private System.Windows.Forms.ToolStripMenuItem tsmiXiangJi;
        private System.Windows.Forms.ToolStripMenuItem tsmiXiuGaiXiangJiCanShu;
        private System.Windows.Forms.ToolStripMenuItem tsmiJiZhun;
        private System.Windows.Forms.ToolStripMenuItem tsmiSheZhiJiZhunDian;
        private System.Windows.Forms.ToolStripMenuItem tsmiBiaoDing;
        private System.Windows.Forms.ToolStripMenuItem tsmiSheZhiYinDaoBiaoDing;
        private System.Windows.Forms.ToolStripMenuItem tsmiTongXin;
        private System.Windows.Forms.ToolStripMenuItem tsmiXiuGaiTongXinFangShi;
        private System.Windows.Forms.ToolStripMenuItem 开启通信ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label 进站车牌;
        private System.Windows.Forms.TextBox txtOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox grpYuanTu;
        private System.Windows.Forms.GroupBox grpShiBieTu;
        private System.Windows.Forms.ListBox lstRiZhi;
        private System.Windows.Forms.TableLayoutPanel tlpAnNiu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

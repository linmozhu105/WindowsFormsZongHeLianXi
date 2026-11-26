namespace WinFrm_ChePaiSB
{
    partial class FrmToolBlock
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
        /// 布局分两层：上面是作业树（占满剩余高度），下面固定 96px 放日志与操作按钮。
        /// 配色与 MainForm 保持同一套规范：页面底 #F5F7FA、卡片纯白、主色 #2B579A。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpZhu = new System.Windows.Forms.TableLayoutPanel();
            this.grpZuoYeShu = new System.Windows.Forms.GroupBox();
            this.cogZuoYeBianJi = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            this.tlpDiBu = new System.Windows.Forms.TableLayoutPanel();
            this.grpRiZhi = new System.Windows.Forms.GroupBox();
            this.lstRiZhi = new System.Windows.Forms.ListBox();
            this.grpGongNeng = new System.Windows.Forms.GroupBox();
            this.btnBaoCun = new System.Windows.Forms.Button();
            this.tlpZhu.SuspendLayout();
            this.grpZuoYeShu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogZuoYeBianJi)).BeginInit();
            this.tlpDiBu.SuspendLayout();
            this.grpRiZhi.SuspendLayout();
            this.grpGongNeng.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpZhu
            // 
            this.tlpZhu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tlpZhu.ColumnCount = 1;
            this.tlpZhu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpZhu.Controls.Add(this.grpZuoYeShu, 0, 0);
            this.tlpZhu.Controls.Add(this.tlpDiBu, 0, 1);
            this.tlpZhu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpZhu.Location = new System.Drawing.Point(0, 0);
            this.tlpZhu.Name = "tlpZhu";
            this.tlpZhu.Padding = new System.Windows.Forms.Padding(10);
            this.tlpZhu.RowCount = 2;
            this.tlpZhu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpZhu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlpZhu.Size = new System.Drawing.Size(1262, 753);
            this.tlpZhu.TabIndex = 0;
            // 
            // grpZuoYeShu
            // 
            this.grpZuoYeShu.BackColor = System.Drawing.Color.White;
            this.grpZuoYeShu.Controls.Add(this.cogZuoYeBianJi);
            this.grpZuoYeShu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpZuoYeShu.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpZuoYeShu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.grpZuoYeShu.Location = new System.Drawing.Point(16, 16);
            this.grpZuoYeShu.Margin = new System.Windows.Forms.Padding(6);
            this.grpZuoYeShu.Name = "grpZuoYeShu";
            this.grpZuoYeShu.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.grpZuoYeShu.Size = new System.Drawing.Size(1230, 625);
            this.grpZuoYeShu.TabIndex = 0;
            this.grpZuoYeShu.TabStop = false;
            this.grpZuoYeShu.Text = "作业树";
            // 
            // cogZuoYeBianJi
            // 
            this.cogZuoYeBianJi.AllowDrop = true;
            this.cogZuoYeBianJi.ContextMenuCustomizer = null;
            this.cogZuoYeBianJi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogZuoYeBianJi.Location = new System.Drawing.Point(10, 26);
            this.cogZuoYeBianJi.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogZuoYeBianJi.Name = "cogZuoYeBianJi";
            this.cogZuoYeBianJi.ShowNodeToolTips = true;
            this.cogZuoYeBianJi.Size = new System.Drawing.Size(1210, 589);
            this.cogZuoYeBianJi.SuspendElectricRuns = false;
            this.cogZuoYeBianJi.TabIndex = 0;
            // 
            // tlpDiBu
            // 
            this.tlpDiBu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tlpDiBu.ColumnCount = 2;
            this.tlpDiBu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpDiBu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpDiBu.Controls.Add(this.grpRiZhi, 0, 0);
            this.tlpDiBu.Controls.Add(this.grpGongNeng, 1, 0);
            this.tlpDiBu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiBu.Location = new System.Drawing.Point(16, 653);
            this.tlpDiBu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tlpDiBu.Name = "tlpDiBu";
            this.tlpDiBu.RowCount = 1;
            this.tlpDiBu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDiBu.Size = new System.Drawing.Size(1230, 84);
            this.tlpDiBu.TabIndex = 1;
            // 
            // grpRiZhi
            // 
            this.grpRiZhi.BackColor = System.Drawing.Color.White;
            this.grpRiZhi.Controls.Add(this.lstRiZhi);
            this.grpRiZhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRiZhi.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpRiZhi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.grpRiZhi.Location = new System.Drawing.Point(6, 6);
            this.grpRiZhi.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpRiZhi.Name = "grpRiZhi";
            this.grpRiZhi.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.grpRiZhi.Size = new System.Drawing.Size(787, 72);
            this.grpRiZhi.TabIndex = 0;
            this.grpRiZhi.TabStop = false;
            this.grpRiZhi.Text = "运行日志";
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
            this.lstRiZhi.Location = new System.Drawing.Point(10, 26);
            this.lstRiZhi.Name = "lstRiZhi";
            this.lstRiZhi.Size = new System.Drawing.Size(767, 36);
            this.lstRiZhi.TabIndex = 0;
            // 
            // grpGongNeng
            // 
            this.grpGongNeng.BackColor = System.Drawing.Color.White;
            this.grpGongNeng.Controls.Add(this.btnBaoCun);
            this.grpGongNeng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGongNeng.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpGongNeng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.grpGongNeng.Location = new System.Drawing.Point(805, 6);
            this.grpGongNeng.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpGongNeng.Name = "grpGongNeng";
            this.grpGongNeng.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.grpGongNeng.Size = new System.Drawing.Size(419, 72);
            this.grpGongNeng.TabIndex = 1;
            this.grpGongNeng.TabStop = false;
            this.grpGongNeng.Text = "操作";
            // 
            // btnBaoCun
            // 
            this.btnBaoCun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.btnBaoCun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCun.FlatAppearance.BorderSize = 0;
            this.btnBaoCun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(130)))));
            this.btnBaoCun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(108)))), ((int)(((byte)(183)))));
            this.btnBaoCun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCun.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBaoCun.ForeColor = System.Drawing.Color.White;
            this.btnBaoCun.Location = new System.Drawing.Point(14, 24);
            this.btnBaoCun.Name = "btnBaoCun";
            this.btnBaoCun.Size = new System.Drawing.Size(110, 38);
            this.btnBaoCun.TabIndex = 0;
            this.btnBaoCun.Text = "保存 VPP";
            this.btnBaoCun.UseVisualStyleBackColor = false;
            this.btnBaoCun.Click += new System.EventHandler(this.btnBaoCun_Click);
            // 
            // FrmToolBlock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.tlpZhu);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FrmToolBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工具块编辑 — 车牌识别";
            this.tlpZhu.ResumeLayout(false);
            this.grpZuoYeShu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogZuoYeBianJi)).EndInit();
            this.tlpDiBu.ResumeLayout(false);
            this.grpRiZhi.ResumeLayout(false);
            this.grpGongNeng.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpZhu;
        private System.Windows.Forms.GroupBox grpZuoYeShu;
        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogZuoYeBianJi;
        private System.Windows.Forms.TableLayoutPanel tlpDiBu;
        private System.Windows.Forms.GroupBox grpRiZhi;
        private System.Windows.Forms.ListBox lstRiZhi;
        private System.Windows.Forms.GroupBox grpGongNeng;
        private System.Windows.Forms.Button btnBaoCun;
    }
}

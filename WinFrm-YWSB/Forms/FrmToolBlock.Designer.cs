namespace WinFrm_YWSB
{
    partial class FrmToolBlock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpZhu = new System.Windows.Forms.TableLayoutPanel();
            this.cogZuoYeBianJi = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            this.tlpDiBu = new System.Windows.Forms.TableLayoutPanel();
            this.grpRiZhi = new System.Windows.Forms.GroupBox();
            this.lstRiZhi = new System.Windows.Forms.ListBox();
            this.grpGongNeng = new System.Windows.Forms.GroupBox();
            this.btnBaoCun = new System.Windows.Forms.Button();
            this.tlpZhu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogZuoYeBianJi)).BeginInit();
            this.tlpDiBu.SuspendLayout();
            this.grpRiZhi.SuspendLayout();
            this.grpGongNeng.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpZhu
            // 
            this.tlpZhu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tlpZhu.ColumnCount = 1;
            this.tlpZhu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpZhu.Controls.Add(this.cogZuoYeBianJi, 0, 0);
            this.tlpZhu.Controls.Add(this.tlpDiBu, 0, 1);
            this.tlpZhu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpZhu.Location = new System.Drawing.Point(0, 0);
            this.tlpZhu.Name = "tlpZhu";
            this.tlpZhu.RowCount = 2;
            this.tlpZhu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpZhu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpZhu.Size = new System.Drawing.Size(1262, 753);
            this.tlpZhu.TabIndex = 0;
            // 
            // cogZuoYeBianJi
            // 
            this.cogZuoYeBianJi.AllowDrop = true;
            this.cogZuoYeBianJi.ContextMenuCustomizer = null;
            this.cogZuoYeBianJi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogZuoYeBianJi.Location = new System.Drawing.Point(3, 3);
            this.cogZuoYeBianJi.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogZuoYeBianJi.Name = "cogZuoYeBianJi";
            this.cogZuoYeBianJi.ShowNodeToolTips = true;
            this.cogZuoYeBianJi.Size = new System.Drawing.Size(1256, 667);
            this.cogZuoYeBianJi.SuspendElectricRuns = false;
            this.cogZuoYeBianJi.TabIndex = 0;
            // 
            // tlpDiBu
            // 
            this.tlpDiBu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tlpDiBu.ColumnCount = 2;
            this.tlpDiBu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiBu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiBu.Controls.Add(this.grpRiZhi, 0, 0);
            this.tlpDiBu.Controls.Add(this.grpGongNeng, 1, 0);
            this.tlpDiBu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiBu.Location = new System.Drawing.Point(3, 676);
            this.tlpDiBu.Name = "tlpDiBu";
            this.tlpDiBu.RowCount = 1;
            this.tlpDiBu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiBu.Size = new System.Drawing.Size(1256, 74);
            this.tlpDiBu.TabIndex = 1;
            // 
            // grpRiZhi
            // 
            this.grpRiZhi.Controls.Add(this.lstRiZhi);
            this.grpRiZhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRiZhi.Location = new System.Drawing.Point(3, 3);
            this.grpRiZhi.Name = "grpRiZhi";
            this.grpRiZhi.Size = new System.Drawing.Size(622, 68);
            this.grpRiZhi.TabIndex = 0;
            this.grpRiZhi.TabStop = false;
            this.grpRiZhi.Text = "日志";
            // 
            // lstRiZhi
            // 
            this.lstRiZhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRiZhi.FormattingEnabled = true;
            this.lstRiZhi.ItemHeight = 15;
            this.lstRiZhi.Location = new System.Drawing.Point(3, 21);
            this.lstRiZhi.Name = "lstRiZhi";
            this.lstRiZhi.Size = new System.Drawing.Size(616, 44);
            this.lstRiZhi.TabIndex = 0;
            // 
            // grpGongNeng
            // 
            this.grpGongNeng.Controls.Add(this.btnBaoCun);
            this.grpGongNeng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGongNeng.Location = new System.Drawing.Point(631, 3);
            this.grpGongNeng.Name = "grpGongNeng";
            this.grpGongNeng.Size = new System.Drawing.Size(622, 68);
            this.grpGongNeng.TabIndex = 1;
            this.grpGongNeng.TabStop = false;
            this.grpGongNeng.Text = "功能";
            // 
            // btnBaoCun
            // 
            this.btnBaoCun.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBaoCun.Location = new System.Drawing.Point(31, 24);
            this.btnBaoCun.Name = "btnBaoCun";
            this.btnBaoCun.Size = new System.Drawing.Size(94, 37);
            this.btnBaoCun.TabIndex = 0;
            this.btnBaoCun.Text = "保存";
            this.btnBaoCun.UseVisualStyleBackColor = true;
            this.btnBaoCun.Click += new System.EventHandler(this.btnBaoCun_Click);
            // 
            // FrmToolBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.tlpZhu);
            this.Name = "FrmToolBlock";
            this.Text = "工具块编辑 — 药丸识别";

            // ==================== 界面样式：与主界面同一套配色 ====================
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.tlpZhu.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.tlpZhu.Padding = new System.Windows.Forms.Padding(10);
            this.tlpDiBu.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            this.cogZuoYeBianJi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);

            this.grpRiZhi.BackColor = System.Drawing.Color.White;
            this.grpRiZhi.ForeColor = System.Drawing.Color.FromArgb(33, 43, 54);
            this.grpRiZhi.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpRiZhi.Padding = new System.Windows.Forms.Padding(12, 8, 12, 10);

            this.grpGongNeng.BackColor = System.Drawing.Color.White;
            this.grpGongNeng.ForeColor = System.Drawing.Color.FromArgb(33, 43, 54);
            this.grpGongNeng.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.lstRiZhi.BackColor = System.Drawing.Color.White;
            this.lstRiZhi.ForeColor = System.Drawing.Color.FromArgb(33, 43, 54);
            this.lstRiZhi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRiZhi.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstRiZhi.IntegralHeight = false;

            // 保存按钮：实心主色，和主界面的“执行检测”一致
            this.btnBaoCun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCun.FlatAppearance.BorderSize = 0;
            this.btnBaoCun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(58, 108, 183);
            this.btnBaoCun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(33, 72, 130);
            this.btnBaoCun.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.btnBaoCun.ForeColor = System.Drawing.Color.White;
            this.btnBaoCun.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBaoCun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCun.UseVisualStyleBackColor = false;

            // ==================== 界面样式结束 ====================

            this.tlpZhu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogZuoYeBianJi)).EndInit();
            this.tlpDiBu.ResumeLayout(false);
            this.grpRiZhi.ResumeLayout(false);
            this.grpGongNeng.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpZhu;
        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogZuoYeBianJi;
        private System.Windows.Forms.TableLayoutPanel tlpDiBu;
        private System.Windows.Forms.GroupBox grpRiZhi;
        private System.Windows.Forms.GroupBox grpGongNeng;
        private System.Windows.Forms.Button btnBaoCun;
        private System.Windows.Forms.ListBox lstRiZhi;
    }
}
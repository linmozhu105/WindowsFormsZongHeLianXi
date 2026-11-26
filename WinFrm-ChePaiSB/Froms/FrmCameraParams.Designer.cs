namespace WinFrm_ChePaiSB
{
    partial class FrmCameraParams
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
            this.lblBaoGuangShiJian = new System.Windows.Forms.Label();
            this.lblLiangDu = new System.Windows.Forms.Label();
            this.lblDuiBiDu = new System.Windows.Forms.Label();
            this.lblChaoShi = new System.Windows.Forms.Label();
            this.lblYanChiJiBie = new System.Windows.Forms.Label();
            this.txtBaoGuang = new System.Windows.Forms.TextBox();
            this.txtLiangDu = new System.Windows.Forms.TextBox();
            this.cmbDuiBiDu = new System.Windows.Forms.ComboBox();
            this.cmbChaoShi = new System.Windows.Forms.ComboBox();
            this.cmbYanChiJiBie = new System.Windows.Forms.ComboBox();
            this.btnBaoCun = new System.Windows.Forms.Button();
            this.btnQuXiao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBaoGuangShiJian
            // 标签统一宽 96、右对齐，标签右缘距输入框左缘 14px
            // 
            this.lblBaoGuangShiJian.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBaoGuangShiJian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblBaoGuangShiJian.Location = new System.Drawing.Point(90, 50);
            this.lblBaoGuangShiJian.Name = "lblBaoGuangShiJian";
            this.lblBaoGuangShiJian.Size = new System.Drawing.Size(96, 26);
            this.lblBaoGuangShiJian.TabIndex = 0;
            this.lblBaoGuangShiJian.Text = "曝光时间：";
            this.lblBaoGuangShiJian.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLiangDu
            // 
            this.lblLiangDu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLiangDu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblLiangDu.Location = new System.Drawing.Point(90, 98);
            this.lblLiangDu.Name = "lblLiangDu";
            this.lblLiangDu.Size = new System.Drawing.Size(96, 26);
            this.lblLiangDu.TabIndex = 1;
            this.lblLiangDu.Text = "相机亮度：";
            this.lblLiangDu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDuiBiDu
            // 
            this.lblDuiBiDu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDuiBiDu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblDuiBiDu.Location = new System.Drawing.Point(90, 146);
            this.lblDuiBiDu.Name = "lblDuiBiDu";
            this.lblDuiBiDu.Size = new System.Drawing.Size(96, 26);
            this.lblDuiBiDu.TabIndex = 2;
            this.lblDuiBiDu.Text = "对比度：";
            this.lblDuiBiDu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblChaoShi
            // 
            this.lblChaoShi.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChaoShi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblChaoShi.Location = new System.Drawing.Point(90, 194);
            this.lblChaoShi.Name = "lblChaoShi";
            this.lblChaoShi.Size = new System.Drawing.Size(96, 26);
            this.lblChaoShi.TabIndex = 3;
            this.lblChaoShi.Text = "超时：";
            this.lblChaoShi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYanChiJiBie
            // 
            this.lblYanChiJiBie.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblYanChiJiBie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblYanChiJiBie.Location = new System.Drawing.Point(90, 242);
            this.lblYanChiJiBie.Name = "lblYanChiJiBie";
            this.lblYanChiJiBie.Size = new System.Drawing.Size(96, 26);
            this.lblYanChiJiBie.TabIndex = 4;
            this.lblYanChiJiBie.Text = "延迟级别：";
            this.lblYanChiJiBie.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBaoGuang
            // 输入框统一 300 宽、25 高、细边框
            // 
            this.txtBaoGuang.BackColor = System.Drawing.Color.White;
            this.txtBaoGuang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaoGuang.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBaoGuang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtBaoGuang.Location = new System.Drawing.Point(200, 50);
            this.txtBaoGuang.Name = "txtBaoGuang";
            this.txtBaoGuang.Size = new System.Drawing.Size(300, 25);
            this.txtBaoGuang.TabIndex = 5;
            // 
            // txtLiangDu
            // 
            this.txtLiangDu.BackColor = System.Drawing.Color.White;
            this.txtLiangDu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLiangDu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLiangDu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtLiangDu.Location = new System.Drawing.Point(200, 98);
            this.txtLiangDu.Name = "txtLiangDu";
            this.txtLiangDu.Size = new System.Drawing.Size(300, 25);
            this.txtLiangDu.TabIndex = 6;
            // 
            // cmbDuiBiDu
            // 下拉框统一 DropDownList，只允许选不允许手输，避免写进非法字符串
            // 
            this.cmbDuiBiDu.BackColor = System.Drawing.Color.White;
            this.cmbDuiBiDu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDuiBiDu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.cmbDuiBiDu.FormattingEnabled = true;
            this.cmbDuiBiDu.Items.AddRange(new object[] {
            "true",
            "false"});
            this.cmbDuiBiDu.Location = new System.Drawing.Point(200, 146);
            this.cmbDuiBiDu.Name = "cmbDuiBiDu";
            this.cmbDuiBiDu.Size = new System.Drawing.Size(300, 25);
            this.cmbDuiBiDu.TabIndex = 7;
            // 
            // cmbChaoShi
            // 
            this.cmbChaoShi.BackColor = System.Drawing.Color.White;
            this.cmbChaoShi.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbChaoShi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.cmbChaoShi.FormattingEnabled = true;
            this.cmbChaoShi.Items.AddRange(new object[] {
            "true",
            "false"});
            this.cmbChaoShi.Location = new System.Drawing.Point(200, 194);
            this.cmbChaoShi.Name = "cmbChaoShi";
            this.cmbChaoShi.Size = new System.Drawing.Size(300, 25);
            this.cmbChaoShi.TabIndex = 8;
            // 
            // cmbYanChiJiBie
            // 延迟级别 1/2/3：数值越大越抗丢包，帧率相应降低
            // 
            this.cmbYanChiJiBie.BackColor = System.Drawing.Color.White;
            this.cmbYanChiJiBie.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbYanChiJiBie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.cmbYanChiJiBie.FormattingEnabled = true;
            this.cmbYanChiJiBie.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbYanChiJiBie.Location = new System.Drawing.Point(200, 242);
            this.cmbYanChiJiBie.Name = "cmbYanChiJiBie";
            this.cmbYanChiJiBie.Size = new System.Drawing.Size(300, 25);
            this.cmbYanChiJiBie.TabIndex = 9;
            // 
            // btnBaoCun
            // 主按钮：蓝底白字 140×38
            // 
            this.btnBaoCun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.btnBaoCun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCun.FlatAppearance.BorderSize = 0;
            this.btnBaoCun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(88)))), ((int)(((byte)(200)))));
            this.btnBaoCun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnBaoCun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCun.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBaoCun.ForeColor = System.Drawing.Color.White;
            this.btnBaoCun.Location = new System.Drawing.Point(200, 300);
            this.btnBaoCun.Name = "btnBaoCun";
            this.btnBaoCun.Size = new System.Drawing.Size(140, 38);
            this.btnBaoCun.TabIndex = 10;
            this.btnBaoCun.Text = "保存设置";
            this.btnBaoCun.UseVisualStyleBackColor = false;
            this.btnBaoCun.Click += new System.EventHandler(this.btnBaoCun_Click);
            // 
            // btnQuXiao
            // 次按钮：白底灰字灰边
            // 
            this.btnQuXiao.BackColor = System.Drawing.Color.White;
            this.btnQuXiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuXiao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(225)))), ((int)(((byte)(231)))));
            this.btnQuXiao.FlatAppearance.BorderSize = 1;
            this.btnQuXiao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.btnQuXiao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnQuXiao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuXiao.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuXiao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnQuXiao.Location = new System.Drawing.Point(360, 300);
            this.btnQuXiao.Name = "btnQuXiao";
            this.btnQuXiao.Size = new System.Drawing.Size(140, 38);
            this.btnQuXiao.TabIndex = 11;
            this.btnQuXiao.Text = "取消";
            this.btnQuXiao.UseVisualStyleBackColor = false;
            // 
            // FrmCameraParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 372);
            this.Controls.Add(this.cmbYanChiJiBie);
            this.Controls.Add(this.cmbChaoShi);
            this.Controls.Add(this.cmbDuiBiDu);
            this.Controls.Add(this.btnQuXiao);
            this.Controls.Add(this.btnBaoCun);
            this.Controls.Add(this.txtLiangDu);
            this.Controls.Add(this.txtBaoGuang);
            this.Controls.Add(this.lblYanChiJiBie);
            this.Controls.Add(this.lblChaoShi);
            this.Controls.Add(this.lblDuiBiDu);
            this.Controls.Add(this.lblLiangDu);
            this.Controls.Add(this.lblBaoGuangShiJian);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCameraParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改相机参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaoGuangShiJian;
        private System.Windows.Forms.Label lblLiangDu;
        private System.Windows.Forms.Label lblDuiBiDu;
        private System.Windows.Forms.Label lblChaoShi;
        private System.Windows.Forms.Label lblYanChiJiBie;
        private System.Windows.Forms.TextBox txtBaoGuang;
        private System.Windows.Forms.TextBox txtLiangDu;
        private System.Windows.Forms.ComboBox cmbDuiBiDu;
        private System.Windows.Forms.ComboBox cmbChaoShi;
        private System.Windows.Forms.ComboBox cmbYanChiJiBie;
        private System.Windows.Forms.Button btnBaoCun;
        private System.Windows.Forms.Button btnQuXiao;
    }
}

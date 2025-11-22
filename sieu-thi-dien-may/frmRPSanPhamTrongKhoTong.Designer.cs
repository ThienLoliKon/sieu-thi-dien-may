namespace stdm
{
    partial class frmRPSanPhamTrongKhoTong
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RTKhachHangForm = new ReaLTaiizor.Forms.NightForm();
            this.cRPSPTrongKhoTong = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.RPSanPhamTrongKhoTong1 = new stdm.RPSanPhamTrongKhoTong();
            this.RTKhachHangForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // RTKhachHangForm
            // 
            this.RTKhachHangForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.RTKhachHangForm.Controls.Add(this.cRPSPTrongKhoTong);
            this.RTKhachHangForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTKhachHangForm.DrawIcon = false;
            this.RTKhachHangForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RTKhachHangForm.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(61)))));
            this.RTKhachHangForm.Location = new System.Drawing.Point(0, 0);
            this.RTKhachHangForm.MinimumSize = new System.Drawing.Size(100, 42);
            this.RTKhachHangForm.Name = "RTKhachHangForm";
            this.RTKhachHangForm.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.RTKhachHangForm.Size = new System.Drawing.Size(1582, 853);
            this.RTKhachHangForm.TabIndex = 3;
            this.RTKhachHangForm.TextAlignment = ReaLTaiizor.Forms.NightForm.Alignment.Left;
            this.RTKhachHangForm.TitleBarTextColor = System.Drawing.Color.Gainsboro;
            this.RTKhachHangForm.Click += new System.EventHandler(this.RTKhachHangForm_Click);
            // 
            // cRPSPTrongKhoTong
            // 
            this.cRPSPTrongKhoTong.ActiveViewIndex = 0;
            this.cRPSPTrongKhoTong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRPSPTrongKhoTong.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRPSPTrongKhoTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRPSPTrongKhoTong.Location = new System.Drawing.Point(0, 31);
            this.cRPSPTrongKhoTong.Name = "cRPSPTrongKhoTong";
            this.cRPSPTrongKhoTong.ReportSource = this.RPSanPhamTrongKhoTong1;
            this.cRPSPTrongKhoTong.Size = new System.Drawing.Size(1582, 822);
            this.cRPSPTrongKhoTong.TabIndex = 0;
            this.cRPSPTrongKhoTong.Load += new System.EventHandler(this.cRPSPTrongKhoTong_Load);
            // 
            // frmRPSanPhamTrongKhoTong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.RTKhachHangForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1020);
            this.Name = "frmRPSanPhamTrongKhoTong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRPSanPhamTrongKhoTong";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.frmRPSanPhamTrongKhoTong_Load);
            this.RTKhachHangForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.NightForm RTKhachHangForm;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRPSPTrongKhoTong;
        private RPSanPhamTrongKhoTong RPSanPhamTrongKhoTong1;
        //private RPSanPhamTrongKhoTong RPSanPhamTrongKhoTong1;
    }
}
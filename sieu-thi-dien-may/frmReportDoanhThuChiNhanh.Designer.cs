namespace stdm
{
	partial class frmReportDoanhThuChiNhanh
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
			this.crptViewDoanhThuChiNhanh = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.btnTimKiem = new ReaLTaiizor.Controls.CyberButton();
			this.dtpNgayKetThuc = new ReaLTaiizor.Controls.PoisonDateTime();
			this.dtpNgayBatDau = new ReaLTaiizor.Controls.PoisonDateTime();
			this.SuspendLayout();
			// 
			// crptViewDoanhThuChiNhanh
			// 
			this.crptViewDoanhThuChiNhanh.ActiveViewIndex = -1;
			this.crptViewDoanhThuChiNhanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crptViewDoanhThuChiNhanh.Cursor = System.Windows.Forms.Cursors.Default;
			this.crptViewDoanhThuChiNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crptViewDoanhThuChiNhanh.Location = new System.Drawing.Point(0, 0);
			this.crptViewDoanhThuChiNhanh.Name = "crptViewDoanhThuChiNhanh";
			this.crptViewDoanhThuChiNhanh.Size = new System.Drawing.Size(1218, 550);
			this.crptViewDoanhThuChiNhanh.TabIndex = 0;
			this.crptViewDoanhThuChiNhanh.Load += new System.EventHandler(this.crptViewDoanhThuChiNhanh_Load);
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Alpha = 20;
			this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
			this.btnTimKiem.Background = true;
			this.btnTimKiem.Background_WidthPen = 4F;
			this.btnTimKiem.BackgroundPen = true;
			this.btnTimKiem.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnTimKiem.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnTimKiem.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
			this.btnTimKiem.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnTimKiem.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnTimKiem.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnTimKiem.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
			this.btnTimKiem.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
			this.btnTimKiem.Effect_1 = true;
			this.btnTimKiem.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnTimKiem.Effect_1_Transparency = 25;
			this.btnTimKiem.Effect_2 = true;
			this.btnTimKiem.Effect_2_ColorBackground = System.Drawing.Color.White;
			this.btnTimKiem.Effect_2_Transparency = 20;
			this.btnTimKiem.Font = new System.Drawing.Font("Arial", 11F);
			this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
			this.btnTimKiem.Lighting = false;
			this.btnTimKiem.LinearGradient_Background = false;
			this.btnTimKiem.LinearGradientPen = false;
			this.btnTimKiem.Location = new System.Drawing.Point(881, 12);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.PenWidth = 15;
			this.btnTimKiem.Rounding = true;
			this.btnTimKiem.RoundingInt = 70;
			this.btnTimKiem.Size = new System.Drawing.Size(103, 41);
			this.btnTimKiem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.btnTimKiem.TabIndex = 7;
			this.btnTimKiem.Tag = "Cyber";
			this.btnTimKiem.TextButton = "Tìm kiếm";
			this.btnTimKiem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.btnTimKiem.Timer_Effect_1 = 5;
			this.btnTimKiem.Timer_RGB = 300;
			this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
			// 
			// dtpNgayKetThuc
			// 
			this.dtpNgayKetThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpNgayKetThuc.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
			this.dtpNgayKetThuc.Location = new System.Drawing.Point(659, 23);
			this.dtpNgayKetThuc.MinimumSize = new System.Drawing.Size(0, 30);
			this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
			this.dtpNgayKetThuc.Size = new System.Drawing.Size(200, 30);
			this.dtpNgayKetThuc.TabIndex = 6;
			// 
			// dtpNgayBatDau
			// 
			this.dtpNgayBatDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpNgayBatDau.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
			this.dtpNgayBatDau.Location = new System.Drawing.Point(440, 23);
			this.dtpNgayBatDau.MinimumSize = new System.Drawing.Size(0, 30);
			this.dtpNgayBatDau.Name = "dtpNgayBatDau";
			this.dtpNgayBatDau.Size = new System.Drawing.Size(200, 30);
			this.dtpNgayBatDau.TabIndex = 5;
			// 
			// frmReportDoanhThuChiNhanh
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1218, 550);
			this.Controls.Add(this.btnTimKiem);
			this.Controls.Add(this.dtpNgayKetThuc);
			this.Controls.Add(this.dtpNgayBatDau);
			this.Controls.Add(this.crptViewDoanhThuChiNhanh);
			this.Name = "frmReportDoanhThuChiNhanh";
			this.Text = "frmReportDoanhThuChiNhanh";
			this.ResumeLayout(false);

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crptViewDoanhThuChiNhanh;
		private ReaLTaiizor.Controls.CyberButton btnTimKiem;
		private ReaLTaiizor.Controls.PoisonDateTime dtpNgayKetThuc;
		private ReaLTaiizor.Controls.PoisonDateTime dtpNgayBatDau;
	}
}
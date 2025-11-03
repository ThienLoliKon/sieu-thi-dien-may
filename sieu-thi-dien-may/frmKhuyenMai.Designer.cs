namespace he_thong_dien_may
{
	partial class frmKhuyenMai
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.foreverForm1 = new ReaLTaiizor.Forms.ForeverForm();
			this.cboLoaiHang = new ReaLTaiizor.Controls.HopeComboBox();
			this.dtpNgayKetThuc = new ReaLTaiizor.Controls.PoisonDateTime();
			this.dtpNgayBatDau = new ReaLTaiizor.Controls.PoisonDateTime();
			this.btnTimKiem = new ReaLTaiizor.Controls.CyberButton();
			this.dgvKhuyenMai = new ReaLTaiizor.Controls.PoisonDataGridView();
			this.btnThoat = new ReaLTaiizor.Controls.CyberButton();
			this.btnSua = new ReaLTaiizor.Controls.CyberButton();
			this.btnThem = new ReaLTaiizor.Controls.CyberButton();
			this.foreverLabel6 = new ReaLTaiizor.Controls.ForeverLabel();
			this.foreverLabel8 = new ReaLTaiizor.Controls.ForeverLabel();
			this.foreverLabel3 = new ReaLTaiizor.Controls.ForeverLabel();
			this.foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
			this.txtGiamGia = new ReaLTaiizor.Controls.ForeverTextBox();
			this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
			this.txtMaKhuyenMai = new ReaLTaiizor.Controls.ForeverTextBox();
			this.foreverForm1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
			this.SuspendLayout();
			// 
			// foreverForm1
			// 
			this.foreverForm1.BackColor = System.Drawing.Color.White;
			this.foreverForm1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
			this.foreverForm1.BorderColor = System.Drawing.Color.DodgerBlue;
			this.foreverForm1.Controls.Add(this.cboLoaiHang);
			this.foreverForm1.Controls.Add(this.dtpNgayKetThuc);
			this.foreverForm1.Controls.Add(this.dtpNgayBatDau);
			this.foreverForm1.Controls.Add(this.btnTimKiem);
			this.foreverForm1.Controls.Add(this.dgvKhuyenMai);
			this.foreverForm1.Controls.Add(this.btnThoat);
			this.foreverForm1.Controls.Add(this.btnSua);
			this.foreverForm1.Controls.Add(this.btnThem);
			this.foreverForm1.Controls.Add(this.foreverLabel6);
			this.foreverForm1.Controls.Add(this.foreverLabel8);
			this.foreverForm1.Controls.Add(this.foreverLabel3);
			this.foreverForm1.Controls.Add(this.foreverLabel2);
			this.foreverForm1.Controls.Add(this.txtGiamGia);
			this.foreverForm1.Controls.Add(this.foreverLabel1);
			this.foreverForm1.Controls.Add(this.txtMaKhuyenMai);
			this.foreverForm1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.foreverForm1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.foreverForm1.ForeverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
			this.foreverForm1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
			this.foreverForm1.HeaderMaximize = false;
			this.foreverForm1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 12F);
			this.foreverForm1.Image = null;
			this.foreverForm1.Location = new System.Drawing.Point(0, 0);
			this.foreverForm1.MinimumSize = new System.Drawing.Size(210, 50);
			this.foreverForm1.Name = "foreverForm1";
			this.foreverForm1.Padding = new System.Windows.Forms.Padding(1, 51, 1, 1);
			this.foreverForm1.Sizable = true;
			this.foreverForm1.Size = new System.Drawing.Size(1582, 753);
			this.foreverForm1.TabIndex = 0;
			this.foreverForm1.Text = "foreverForm1";
			this.foreverForm1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.foreverForm1.TextLight = System.Drawing.Color.SeaGreen;
			this.foreverForm1.Click += new System.EventHandler(this.foreverForm1_Click);
			// 
			// cboLoaiHang
			// 
			this.cboLoaiHang.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cboLoaiHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboLoaiHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboLoaiHang.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.cboLoaiHang.FormattingEnabled = true;
			this.cboLoaiHang.ItemHeight = 30;
			this.cboLoaiHang.Location = new System.Drawing.Point(947, 105);
			this.cboLoaiHang.Name = "cboLoaiHang";
			this.cboLoaiHang.Size = new System.Drawing.Size(271, 36);
			this.cboLoaiHang.TabIndex = 59;
			// 
			// dtpNgayKetThuc
			// 
			this.dtpNgayKetThuc.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
			this.dtpNgayKetThuc.Location = new System.Drawing.Point(1428, 149);
			this.dtpNgayKetThuc.MinimumSize = new System.Drawing.Size(0, 30);
			this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
			this.dtpNgayKetThuc.Size = new System.Drawing.Size(200, 30);
			this.dtpNgayKetThuc.TabIndex = 39;
			// 
			// dtpNgayBatDau
			// 
			this.dtpNgayBatDau.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
			this.dtpNgayBatDau.Location = new System.Drawing.Point(1428, 105);
			this.dtpNgayBatDau.MinimumSize = new System.Drawing.Size(0, 30);
			this.dtpNgayBatDau.Name = "dtpNgayBatDau";
			this.dtpNgayBatDau.Size = new System.Drawing.Size(200, 30);
			this.dtpNgayBatDau.TabIndex = 38;
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Alpha = 20;
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
			this.btnTimKiem.Location = new System.Drawing.Point(1393, 260);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.PenWidth = 15;
			this.btnTimKiem.Rounding = true;
			this.btnTimKiem.RoundingInt = 70;
			this.btnTimKiem.Size = new System.Drawing.Size(130, 50);
			this.btnTimKiem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.btnTimKiem.TabIndex = 37;
			this.btnTimKiem.Tag = "Cyber";
			this.btnTimKiem.TextButton = "Tìm Kiếm";
			this.btnTimKiem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.btnTimKiem.Timer_Effect_1 = 5;
			this.btnTimKiem.Timer_RGB = 300;
			// 
			// dgvKhuyenMai
			// 
			this.dgvKhuyenMai.AllowUserToResizeRows = false;
			this.dgvKhuyenMai.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.dgvKhuyenMai.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvKhuyenMai.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dgvKhuyenMai.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvKhuyenMai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvKhuyenMai.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvKhuyenMai.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvKhuyenMai.EnableHeadersVisualStyles = false;
			this.dgvKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dgvKhuyenMai.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.dgvKhuyenMai.Location = new System.Drawing.Point(1, 352);
			this.dgvKhuyenMai.Name = "dgvKhuyenMai";
			this.dgvKhuyenMai.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvKhuyenMai.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvKhuyenMai.RowHeadersWidth = 51;
			this.dgvKhuyenMai.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvKhuyenMai.RowTemplate.Height = 24;
			this.dgvKhuyenMai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvKhuyenMai.Size = new System.Drawing.Size(1580, 400);
			this.dgvKhuyenMai.TabIndex = 36;
			// 
			// btnThoat
			// 
			this.btnThoat.Alpha = 20;
			this.btnThoat.BackColor = System.Drawing.Color.Transparent;
			this.btnThoat.Background = true;
			this.btnThoat.Background_WidthPen = 4F;
			this.btnThoat.BackgroundPen = true;
			this.btnThoat.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnThoat.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnThoat.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
			this.btnThoat.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnThoat.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnThoat.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnThoat.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
			this.btnThoat.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
			this.btnThoat.Effect_1 = true;
			this.btnThoat.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnThoat.Effect_1_Transparency = 25;
			this.btnThoat.Effect_2 = true;
			this.btnThoat.Effect_2_ColorBackground = System.Drawing.Color.White;
			this.btnThoat.Effect_2_Transparency = 20;
			this.btnThoat.Font = new System.Drawing.Font("Arial", 11F);
			this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
			this.btnThoat.Lighting = false;
			this.btnThoat.LinearGradient_Background = false;
			this.btnThoat.LinearGradientPen = false;
			this.btnThoat.Location = new System.Drawing.Point(1102, 260);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.PenWidth = 15;
			this.btnThoat.Rounding = true;
			this.btnThoat.RoundingInt = 70;
			this.btnThoat.Size = new System.Drawing.Size(130, 50);
			this.btnThoat.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.btnThoat.TabIndex = 35;
			this.btnThoat.Tag = "Cyber";
			this.btnThoat.TextButton = "Thoát";
			this.btnThoat.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.btnThoat.Timer_Effect_1 = 5;
			this.btnThoat.Timer_RGB = 300;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnSua
			// 
			this.btnSua.Alpha = 20;
			this.btnSua.BackColor = System.Drawing.Color.Transparent;
			this.btnSua.Background = true;
			this.btnSua.Background_WidthPen = 4F;
			this.btnSua.BackgroundPen = true;
			this.btnSua.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnSua.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnSua.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
			this.btnSua.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnSua.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnSua.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnSua.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
			this.btnSua.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
			this.btnSua.Effect_1 = true;
			this.btnSua.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnSua.Effect_1_Transparency = 25;
			this.btnSua.Effect_2 = true;
			this.btnSua.Effect_2_ColorBackground = System.Drawing.Color.White;
			this.btnSua.Effect_2_Transparency = 20;
			this.btnSua.Font = new System.Drawing.Font("Arial", 11F);
			this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
			this.btnSua.Lighting = false;
			this.btnSua.LinearGradient_Background = false;
			this.btnSua.LinearGradientPen = false;
			this.btnSua.Location = new System.Drawing.Point(795, 260);
			this.btnSua.Name = "btnSua";
			this.btnSua.PenWidth = 15;
			this.btnSua.Rounding = true;
			this.btnSua.RoundingInt = 70;
			this.btnSua.Size = new System.Drawing.Size(130, 50);
			this.btnSua.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.btnSua.TabIndex = 34;
			this.btnSua.Tag = "Cyber";
			this.btnSua.TextButton = "Sửa";
			this.btnSua.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.btnSua.Timer_Effect_1 = 5;
			this.btnSua.Timer_RGB = 300;
			// 
			// btnThem
			// 
			this.btnThem.Alpha = 20;
			this.btnThem.BackColor = System.Drawing.Color.Transparent;
			this.btnThem.Background = true;
			this.btnThem.Background_WidthPen = 4F;
			this.btnThem.BackgroundPen = true;
			this.btnThem.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnThem.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnThem.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
			this.btnThem.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnThem.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnThem.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
			this.btnThem.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
			this.btnThem.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
			this.btnThem.Effect_1 = true;
			this.btnThem.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
			this.btnThem.Effect_1_Transparency = 25;
			this.btnThem.Effect_2 = true;
			this.btnThem.Effect_2_ColorBackground = System.Drawing.Color.White;
			this.btnThem.Effect_2_Transparency = 20;
			this.btnThem.Font = new System.Drawing.Font("Arial", 11F);
			this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
			this.btnThem.Lighting = false;
			this.btnThem.LinearGradient_Background = false;
			this.btnThem.LinearGradientPen = false;
			this.btnThem.Location = new System.Drawing.Point(489, 260);
			this.btnThem.Name = "btnThem";
			this.btnThem.PenWidth = 15;
			this.btnThem.Rounding = true;
			this.btnThem.RoundingInt = 70;
			this.btnThem.Size = new System.Drawing.Size(130, 50);
			this.btnThem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.btnThem.TabIndex = 33;
			this.btnThem.Tag = "Cyber";
			this.btnThem.TextButton = "Thêm";
			this.btnThem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.btnThem.Timer_Effect_1 = 5;
			this.btnThem.Timer_RGB = 300;
			// 
			// foreverLabel6
			// 
			this.foreverLabel6.AutoSize = true;
			this.foreverLabel6.BackColor = System.Drawing.Color.Transparent;
			this.foreverLabel6.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.foreverLabel6.ForeColor = System.Drawing.Color.LightGray;
			this.foreverLabel6.Location = new System.Drawing.Point(1306, 155);
			this.foreverLabel6.Name = "foreverLabel6";
			this.foreverLabel6.Size = new System.Drawing.Size(102, 19);
			this.foreverLabel6.TabIndex = 32;
			this.foreverLabel6.Text = "Ngày kết thúc :";
			// 
			// foreverLabel8
			// 
			this.foreverLabel8.AutoSize = true;
			this.foreverLabel8.BackColor = System.Drawing.Color.Transparent;
			this.foreverLabel8.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.foreverLabel8.ForeColor = System.Drawing.Color.LightGray;
			this.foreverLabel8.Location = new System.Drawing.Point(1306, 115);
			this.foreverLabel8.Name = "foreverLabel8";
			this.foreverLabel8.Size = new System.Drawing.Size(99, 19);
			this.foreverLabel8.TabIndex = 28;
			this.foreverLabel8.Text = "Ngày bắt đầu :";
			// 
			// foreverLabel3
			// 
			this.foreverLabel3.AutoSize = true;
			this.foreverLabel3.BackColor = System.Drawing.Color.Transparent;
			this.foreverLabel3.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.foreverLabel3.ForeColor = System.Drawing.Color.LightGray;
			this.foreverLabel3.Location = new System.Drawing.Point(865, 114);
			this.foreverLabel3.Name = "foreverLabel3";
			this.foreverLabel3.Size = new System.Drawing.Size(76, 19);
			this.foreverLabel3.TabIndex = 24;
			this.foreverLabel3.Text = "Loại hàng :";
			// 
			// foreverLabel2
			// 
			this.foreverLabel2.AutoSize = true;
			this.foreverLabel2.BackColor = System.Drawing.Color.Transparent;
			this.foreverLabel2.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.foreverLabel2.ForeColor = System.Drawing.Color.LightGray;
			this.foreverLabel2.Location = new System.Drawing.Point(401, 155);
			this.foreverLabel2.Name = "foreverLabel2";
			this.foreverLabel2.Size = new System.Drawing.Size(68, 19);
			this.foreverLabel2.TabIndex = 22;
			this.foreverLabel2.Text = "giảm giá :";
			// 
			// txtGiamGia
			// 
			this.txtGiamGia.BackColor = System.Drawing.Color.Transparent;
			this.txtGiamGia.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
			this.txtGiamGia.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
			this.txtGiamGia.FocusOnHover = false;
			this.txtGiamGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.txtGiamGia.Location = new System.Drawing.Point(559, 145);
			this.txtGiamGia.MaxLength = 32767;
			this.txtGiamGia.Multiline = false;
			this.txtGiamGia.Name = "txtGiamGia";
			this.txtGiamGia.ReadOnly = false;
			this.txtGiamGia.Size = new System.Drawing.Size(227, 34);
			this.txtGiamGia.TabIndex = 21;
			this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtGiamGia.UseSystemPasswordChar = false;
			// 
			// foreverLabel1
			// 
			this.foreverLabel1.AutoSize = true;
			this.foreverLabel1.BackColor = System.Drawing.Color.Transparent;
			this.foreverLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.foreverLabel1.ForeColor = System.Drawing.Color.LightGray;
			this.foreverLabel1.Location = new System.Drawing.Point(401, 117);
			this.foreverLabel1.Name = "foreverLabel1";
			this.foreverLabel1.Size = new System.Drawing.Size(111, 19);
			this.foreverLabel1.TabIndex = 20;
			this.foreverLabel1.Text = "Mã khuyến mãi :";
			// 
			// txtMaKhuyenMai
			// 
			this.txtMaKhuyenMai.BackColor = System.Drawing.Color.Transparent;
			this.txtMaKhuyenMai.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
			this.txtMaKhuyenMai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
			this.txtMaKhuyenMai.FocusOnHover = false;
			this.txtMaKhuyenMai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.txtMaKhuyenMai.Location = new System.Drawing.Point(559, 105);
			this.txtMaKhuyenMai.MaxLength = 32767;
			this.txtMaKhuyenMai.Multiline = false;
			this.txtMaKhuyenMai.Name = "txtMaKhuyenMai";
			this.txtMaKhuyenMai.ReadOnly = false;
			this.txtMaKhuyenMai.Size = new System.Drawing.Size(227, 34);
			this.txtMaKhuyenMai.TabIndex = 19;
			this.txtMaKhuyenMai.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtMaKhuyenMai.UseSystemPasswordChar = false;
			// 
			// frmKhuyenMai
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1582, 753);
			this.Controls.Add(this.foreverForm1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmKhuyenMai";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmKhuyenMai";
			this.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.Load += new System.EventHandler(this.frmKhuyenMai_Load);
			this.foreverForm1.ResumeLayout(false);
			this.foreverForm1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ReaLTaiizor.Forms.ForeverForm foreverForm1;
		private ReaLTaiizor.Controls.CyberButton btnTimKiem;
		private ReaLTaiizor.Controls.PoisonDataGridView dgvKhuyenMai;
		private ReaLTaiizor.Controls.CyberButton btnThoat;
		private ReaLTaiizor.Controls.CyberButton btnSua;
		private ReaLTaiizor.Controls.CyberButton btnThem;
		private ReaLTaiizor.Controls.ForeverLabel foreverLabel6;
		private ReaLTaiizor.Controls.ForeverLabel foreverLabel8;
		private ReaLTaiizor.Controls.ForeverLabel foreverLabel3;
		private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
		private ReaLTaiizor.Controls.ForeverTextBox txtGiamGia;
		private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
		private ReaLTaiizor.Controls.ForeverTextBox txtMaKhuyenMai;
		private ReaLTaiizor.Controls.PoisonDateTime dtpNgayKetThuc;
		private ReaLTaiizor.Controls.PoisonDateTime dtpNgayBatDau;
		private ReaLTaiizor.Controls.HopeComboBox cboLoaiHang;
	}
}
namespace he_thong_dien_may
{
    partial class frmTaiKhoan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.foreverForm1 = new ReaLTaiizor.Forms.ForeverForm();
            this.btnDong = new ReaLTaiizor.Controls.CyberButton();
            this.dgvTK = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.btnXoa = new ReaLTaiizor.Controls.CyberButton();
            this.btnLuu = new ReaLTaiizor.Controls.CyberButton();
            this.btnThem = new ReaLTaiizor.Controls.CyberButton();
            this.foreverLabel8 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            this.txtMK = new ReaLTaiizor.Controls.ForeverTextBox();
            this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            this.cbbMaNV = new ReaLTaiizor.Controls.SkyComboBox();
            this.cbbQuyen = new ReaLTaiizor.Controls.SkyComboBox();
            this.btnDoiMK = new ReaLTaiizor.Controls.CyberButton();
            this.foreverForm1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).BeginInit();
            this.SuspendLayout();
            // 
            // foreverForm1
            // 
            this.foreverForm1.BackColor = System.Drawing.Color.White;
            this.foreverForm1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.foreverForm1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.foreverForm1.Controls.Add(this.cbbQuyen);
            this.foreverForm1.Controls.Add(this.cbbMaNV);
            this.foreverForm1.Controls.Add(this.btnDong);
            this.foreverForm1.Controls.Add(this.dgvTK);
            this.foreverForm1.Controls.Add(this.btnXoa);
            this.foreverForm1.Controls.Add(this.btnLuu);
            this.foreverForm1.Controls.Add(this.btnDoiMK);
            this.foreverForm1.Controls.Add(this.btnThem);
            this.foreverForm1.Controls.Add(this.foreverLabel8);
            this.foreverForm1.Controls.Add(this.foreverLabel2);
            this.foreverForm1.Controls.Add(this.txtMK);
            this.foreverForm1.Controls.Add(this.foreverLabel1);
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
            this.foreverForm1.Size = new System.Drawing.Size(1600, 800);
            this.foreverForm1.TabIndex = 3;
            this.foreverForm1.Text = "Quản Lý Tài Khoản";
            this.foreverForm1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.foreverForm1.TextLight = System.Drawing.Color.SeaGreen;
            // 
            // btnDong
            // 
            this.btnDong.Alpha = 20;
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.Transparent;
            this.btnDong.Background = true;
            this.btnDong.Background_WidthPen = 4F;
            this.btnDong.BackgroundPen = true;
            this.btnDong.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnDong.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnDong.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnDong.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDong.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDong.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnDong.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnDong.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnDong.Effect_1 = true;
            this.btnDong.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDong.Effect_1_Transparency = 25;
            this.btnDong.Effect_2 = true;
            this.btnDong.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnDong.Effect_2_Transparency = 20;
            this.btnDong.Font = new System.Drawing.Font("Arial", 11F);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnDong.Lighting = false;
            this.btnDong.LinearGradient_Background = false;
            this.btnDong.LinearGradientPen = false;
            this.btnDong.Location = new System.Drawing.Point(1383, 725);
            this.btnDong.Name = "btnDong";
            this.btnDong.PenWidth = 15;
            this.btnDong.Rounding = true;
            this.btnDong.RoundingInt = 70;
            this.btnDong.Size = new System.Drawing.Size(130, 50);
            this.btnDong.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnDong.TabIndex = 18;
            this.btnDong.Tag = "Cyber";
            this.btnDong.TextButton = "Đóng";
            this.btnDong.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnDong.Timer_Effect_1 = 5;
            this.btnDong.Timer_RGB = 300;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvTK
            // 
            this.dgvTK.AllowUserToResizeRows = false;
            this.dgvTK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTK.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTK.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTK.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTK.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTK.EnableHeadersVisualStyles = false;
            this.dgvTK.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvTK.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTK.Location = new System.Drawing.Point(1, 54);
            this.dgvTK.Name = "dgvTK";
            this.dgvTK.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTK.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTK.RowHeadersWidth = 51;
            this.dgvTK.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTK.RowTemplate.Height = 24;
            this.dgvTK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTK.Size = new System.Drawing.Size(989, 745);
            this.dgvTK.TabIndex = 17;
            this.dgvTK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTK_CellClick);
            this.dgvTK.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTK_MouseDoubleClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Alpha = 20;
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Transparent;
            this.btnXoa.Background = true;
            this.btnXoa.Background_WidthPen = 4F;
            this.btnXoa.BackgroundPen = true;
            this.btnXoa.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnXoa.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnXoa.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnXoa.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnXoa.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnXoa.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnXoa.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnXoa.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnXoa.Effect_1 = true;
            this.btnXoa.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnXoa.Effect_1_Transparency = 25;
            this.btnXoa.Effect_2 = true;
            this.btnXoa.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnXoa.Effect_2_Transparency = 20;
            this.btnXoa.Font = new System.Drawing.Font("Arial", 11F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnXoa.Lighting = false;
            this.btnXoa.LinearGradient_Background = false;
            this.btnXoa.LinearGradientPen = false;
            this.btnXoa.Location = new System.Drawing.Point(1133, 725);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PenWidth = 15;
            this.btnXoa.Rounding = true;
            this.btnXoa.RoundingInt = 70;
            this.btnXoa.Size = new System.Drawing.Size(130, 50);
            this.btnXoa.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Tag = "Cyber";
            this.btnXoa.TextButton = "Xóa";
            this.btnXoa.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnXoa.Timer_Effect_1 = 5;
            this.btnXoa.Timer_RGB = 300;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Alpha = 20;
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.Transparent;
            this.btnLuu.Background = true;
            this.btnLuu.Background_WidthPen = 4F;
            this.btnLuu.BackgroundPen = true;
            this.btnLuu.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLuu.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLuu.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnLuu.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLuu.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLuu.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLuu.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnLuu.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnLuu.Effect_1 = true;
            this.btnLuu.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLuu.Effect_1_Transparency = 25;
            this.btnLuu.Effect_2 = true;
            this.btnLuu.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnLuu.Effect_2_Transparency = 20;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 11F);
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnLuu.Lighting = false;
            this.btnLuu.LinearGradient_Background = false;
            this.btnLuu.LinearGradientPen = false;
            this.btnLuu.Location = new System.Drawing.Point(1435, 617);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.PenWidth = 15;
            this.btnLuu.Rounding = true;
            this.btnLuu.RoundingInt = 70;
            this.btnLuu.Size = new System.Drawing.Size(130, 50);
            this.btnLuu.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Tag = "Cyber";
            this.btnLuu.TextButton = "Lưu";
            this.btnLuu.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnLuu.Timer_Effect_1 = 5;
            this.btnLuu.Timer_RGB = 300;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Alpha = 20;
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnThem.Location = new System.Drawing.Point(1049, 617);
            this.btnThem.Name = "btnThem";
            this.btnThem.PenWidth = 15;
            this.btnThem.Rounding = true;
            this.btnThem.RoundingInt = 70;
            this.btnThem.Size = new System.Drawing.Size(130, 50);
            this.btnThem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnThem.TabIndex = 14;
            this.btnThem.Tag = "Cyber";
            this.btnThem.TextButton = "Thêm";
            this.btnThem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnThem.Timer_Effect_1 = 5;
            this.btnThem.Timer_RGB = 300;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // foreverLabel8
            // 
            this.foreverLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel8.AutoSize = true;
            this.foreverLabel8.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel8.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel8.Location = new System.Drawing.Point(1020, 476);
            this.foreverLabel8.Name = "foreverLabel8";
            this.foreverLabel8.Size = new System.Drawing.Size(199, 25);
            this.foreverLabel8.TabIndex = 9;
            this.foreverLabel8.Text = "Quyền Truy Cập:  ";
            // 
            // foreverLabel2
            // 
            this.foreverLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel2.AutoSize = true;
            this.foreverLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel2.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel2.Location = new System.Drawing.Point(1020, 290);
            this.foreverLabel2.Name = "foreverLabel2";
            this.foreverLabel2.Size = new System.Drawing.Size(137, 25);
            this.foreverLabel2.TabIndex = 3;
            this.foreverLabel2.Text = "Mật Khẩu:  ";
            // 
            // txtMK
            // 
            this.txtMK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMK.BackColor = System.Drawing.Color.Transparent;
            this.txtMK.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.txtMK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.txtMK.FocusOnHover = false;
            this.txtMK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMK.Location = new System.Drawing.Point(1252, 281);
            this.txtMK.MaxLength = 32767;
            this.txtMK.Multiline = false;
            this.txtMK.Name = "txtMK";
            this.txtMK.ReadOnly = false;
            this.txtMK.Size = new System.Drawing.Size(336, 34);
            this.txtMK.TabIndex = 2;
            this.txtMK.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMK.UseSystemPasswordChar = false;
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foreverLabel1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.foreverLabel1.Location = new System.Drawing.Point(1020, 107);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(104, 25);
            this.foreverLabel1.TabIndex = 1;
            this.foreverLabel1.Text = "Mã NV:  ";
            // 
            // cbbMaNV
            // 
            this.cbbMaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMaNV.BackColor = System.Drawing.Color.Transparent;
            this.cbbMaNV.BGColorA = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cbbMaNV.BGColorB = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cbbMaNV.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.cbbMaNV.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cbbMaNV.BorderColorC = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.cbbMaNV.BorderColorD = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.cbbMaNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbMaNV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaNV.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold);
            this.cbbMaNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(137)))));
            this.cbbMaNV.FormattingEnabled = true;
            this.cbbMaNV.ItemHeight = 16;
            this.cbbMaNV.ItemHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(176)))), ((int)(((byte)(214)))));
            this.cbbMaNV.LineColorA = System.Drawing.Color.White;
            this.cbbMaNV.LineColorB = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.cbbMaNV.LineColorC = System.Drawing.Color.White;
            this.cbbMaNV.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbMaNV.ListBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbMaNV.ListDashType = System.Drawing.Drawing2D.DashStyle.Dot;
            this.cbbMaNV.ListForeColor = System.Drawing.Color.Black;
            this.cbbMaNV.ListSelectedBackColorA = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbMaNV.ListSelectedBackColorB = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbMaNV.Location = new System.Drawing.Point(1252, 113);
            this.cbbMaNV.Name = "cbbMaNV";
            this.cbbMaNV.Size = new System.Drawing.Size(336, 22);
            this.cbbMaNV.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cbbMaNV.StartIndex = 0;
            this.cbbMaNV.TabIndex = 55;
            this.cbbMaNV.TriangleColorA = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(176)))), ((int)(((byte)(214)))));
            this.cbbMaNV.TriangleColorB = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(137)))));
            // 
            // cbbQuyen
            // 
            this.cbbQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbQuyen.BackColor = System.Drawing.Color.Transparent;
            this.cbbQuyen.BGColorA = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cbbQuyen.BGColorB = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cbbQuyen.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.cbbQuyen.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cbbQuyen.BorderColorC = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.cbbQuyen.BorderColorD = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.cbbQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbQuyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbQuyen.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold);
            this.cbbQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(137)))));
            this.cbbQuyen.FormattingEnabled = true;
            this.cbbQuyen.ItemHeight = 16;
            this.cbbQuyen.ItemHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(176)))), ((int)(((byte)(214)))));
            this.cbbQuyen.LineColorA = System.Drawing.Color.White;
            this.cbbQuyen.LineColorB = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.cbbQuyen.LineColorC = System.Drawing.Color.White;
            this.cbbQuyen.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbQuyen.ListBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbbQuyen.ListDashType = System.Drawing.Drawing2D.DashStyle.Dot;
            this.cbbQuyen.ListForeColor = System.Drawing.Color.Black;
            this.cbbQuyen.ListSelectedBackColorA = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbQuyen.ListSelectedBackColorB = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbbQuyen.Location = new System.Drawing.Point(1252, 479);
            this.cbbQuyen.Name = "cbbQuyen";
            this.cbbQuyen.Size = new System.Drawing.Size(336, 22);
            this.cbbQuyen.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cbbQuyen.StartIndex = 0;
            this.cbbQuyen.TabIndex = 56;
            this.cbbQuyen.TriangleColorA = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(176)))), ((int)(((byte)(214)))));
            this.cbbQuyen.TriangleColorB = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(137)))));
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Alpha = 20;
            this.btnDoiMK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoiMK.BackColor = System.Drawing.Color.Transparent;
            this.btnDoiMK.Background = true;
            this.btnDoiMK.Background_WidthPen = 4F;
            this.btnDoiMK.BackgroundPen = true;
            this.btnDoiMK.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnDoiMK.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnDoiMK.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnDoiMK.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDoiMK.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDoiMK.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnDoiMK.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnDoiMK.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnDoiMK.Effect_1 = true;
            this.btnDoiMK.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDoiMK.Effect_1_Transparency = 25;
            this.btnDoiMK.Effect_2 = true;
            this.btnDoiMK.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnDoiMK.Effect_2_Transparency = 20;
            this.btnDoiMK.Font = new System.Drawing.Font("Arial", 11F);
            this.btnDoiMK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnDoiMK.Lighting = false;
            this.btnDoiMK.LinearGradient_Background = false;
            this.btnDoiMK.LinearGradientPen = false;
            this.btnDoiMK.Location = new System.Drawing.Point(1252, 617);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.PenWidth = 15;
            this.btnDoiMK.Rounding = true;
            this.btnDoiMK.RoundingInt = 70;
            this.btnDoiMK.Size = new System.Drawing.Size(130, 50);
            this.btnDoiMK.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnDoiMK.TabIndex = 14;
            this.btnDoiMK.Tag = "Cyber";
            this.btnDoiMK.TextButton = "Đổi Mật Khẩu  ";
            this.btnDoiMK.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnDoiMK.Timer_Effect_1 = 5;
            this.btnDoiMK.Timer_RGB = 300;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 800);
            this.Controls.Add(this.foreverForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTaiKhoan";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.foreverForm1.ResumeLayout(false);
            this.foreverForm1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm foreverForm1;
        private ReaLTaiizor.Controls.CyberButton btnDong;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvTK;
        private ReaLTaiizor.Controls.CyberButton btnXoa;
        private ReaLTaiizor.Controls.CyberButton btnLuu;
        private ReaLTaiizor.Controls.CyberButton btnThem;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel8;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
        private ReaLTaiizor.Controls.ForeverTextBox txtMK;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.SkyComboBox cbbQuyen;
        private ReaLTaiizor.Controls.SkyComboBox cbbMaNV;
        private ReaLTaiizor.Controls.CyberButton btnDoiMK;
    }
}
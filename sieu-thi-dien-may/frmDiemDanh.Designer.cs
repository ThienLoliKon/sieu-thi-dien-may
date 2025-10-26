namespace he_thong_dien_may
{
    partial class frmDiemDanh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTimKiem = new ReaLTaiizor.Controls.ForeverButton();
            this.btnXoa = new ReaLTaiizor.Controls.ForeverButton();
            this.txtLuu = new ReaLTaiizor.Controls.ForeverButton();
            this.btnThem = new ReaLTaiizor.Controls.ForeverButton();
            this.txtMaDiemDanh = new ReaLTaiizor.Controls.ForeverTextBox();
            this.foreverLabel6 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel5 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel4 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel3 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDong = new ReaLTaiizor.Controls.ForeverButton();
            this.dgvDiemDanh = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbTraCuu = new ReaLTaiizor.Controls.ForeverComboBox();
            this.foreverForm1 = new ReaLTaiizor.Forms.ForeverForm();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbMaNV = new ReaLTaiizor.Controls.ForeverComboBox();
            this.dtpThoiGianVao = new System.Windows.Forms.DateTimePicker();
            this.dtpThoiGianRa = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).BeginInit();
            this.panel1.SuspendLayout();
            this.foreverForm1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(1233, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Rounded = false;
            this.btnTimKiem.Size = new System.Drawing.Size(252, 57);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Lọc";
            this.btnTimKiem.TextColor = System.Drawing.Color.Black;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Transparent;
            this.btnXoa.BaseColor = System.Drawing.Color.Red;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(24, 273);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Rounded = false;
            this.btnXoa.Size = new System.Drawing.Size(100, 80);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextColor = System.Drawing.Color.Black;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtLuu
            // 
            this.txtLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLuu.BackColor = System.Drawing.Color.Transparent;
            this.txtLuu.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.txtLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtLuu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuu.Location = new System.Drawing.Point(687, 42);
            this.txtLuu.Name = "txtLuu";
            this.txtLuu.Rounded = false;
            this.txtLuu.Size = new System.Drawing.Size(100, 80);
            this.txtLuu.TabIndex = 0;
            this.txtLuu.Text = "Lưu";
            this.txtLuu.TextColor = System.Drawing.Color.Black;
            this.txtLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(24, 42);
            this.btnThem.Name = "btnThem";
            this.btnThem.Rounded = false;
            this.btnThem.Size = new System.Drawing.Size(100, 80);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextColor = System.Drawing.Color.Black;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtMaDiemDanh
            // 
            this.txtMaDiemDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaDiemDanh.BackColor = System.Drawing.Color.Transparent;
            this.txtMaDiemDanh.BaseColor = System.Drawing.Color.Silver;
            this.txtMaDiemDanh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.txtMaDiemDanh.FocusOnHover = false;
            this.txtMaDiemDanh.ForeColor = System.Drawing.Color.Black;
            this.txtMaDiemDanh.Location = new System.Drawing.Point(233, 66);
            this.txtMaDiemDanh.MaxLength = 32767;
            this.txtMaDiemDanh.Multiline = false;
            this.txtMaDiemDanh.Name = "txtMaDiemDanh";
            this.txtMaDiemDanh.ReadOnly = false;
            this.txtMaDiemDanh.Size = new System.Drawing.Size(445, 34);
            this.txtMaDiemDanh.TabIndex = 3;
            this.txtMaDiemDanh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMaDiemDanh.UseSystemPasswordChar = false;
            // 
            // foreverLabel6
            // 
            this.foreverLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel6.AutoSize = true;
            this.foreverLabel6.BackColor = System.Drawing.Color.White;
            this.foreverLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel6.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel6.Location = new System.Drawing.Point(49, 327);
            this.foreverLabel6.Name = "foreverLabel6";
            this.foreverLabel6.Size = new System.Drawing.Size(131, 23);
            this.foreverLabel6.TabIndex = 2;
            this.foreverLabel6.Text = "Thời Gian Ra:";
            // 
            // foreverLabel5
            // 
            this.foreverLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel5.AutoSize = true;
            this.foreverLabel5.BackColor = System.Drawing.Color.White;
            this.foreverLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel5.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel5.Location = new System.Drawing.Point(49, 233);
            this.foreverLabel5.Name = "foreverLabel5";
            this.foreverLabel5.Size = new System.Drawing.Size(141, 23);
            this.foreverLabel5.TabIndex = 2;
            this.foreverLabel5.Text = "Thời Gian Vào:";
            // 
            // foreverLabel4
            // 
            this.foreverLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel4.AutoSize = true;
            this.foreverLabel4.BackColor = System.Drawing.Color.White;
            this.foreverLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel4.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel4.Location = new System.Drawing.Point(49, 154);
            this.foreverLabel4.Name = "foreverLabel4";
            this.foreverLabel4.Size = new System.Drawing.Size(76, 23);
            this.foreverLabel4.TabIndex = 2;
            this.foreverLabel4.Text = "Mã NV:";
            // 
            // foreverLabel3
            // 
            this.foreverLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel3.AutoSize = true;
            this.foreverLabel3.BackColor = System.Drawing.Color.White;
            this.foreverLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel3.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel3.Location = new System.Drawing.Point(49, 83);
            this.foreverLabel3.Name = "foreverLabel3";
            this.foreverLabel3.Size = new System.Drawing.Size(143, 23);
            this.foreverLabel3.TabIndex = 2;
            this.foreverLabel3.Text = "Mã Điểm Danh:";
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.foreverLabel1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel1.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel1.Location = new System.Drawing.Point(38, 4);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(212, 53);
            this.foreverLabel1.TabIndex = 2;
            this.foreverLabel1.Text = "Tra Cứu:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.btnDong);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.txtLuu);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 466);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(832, 404);
            this.panel3.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.Transparent;
            this.btnDong.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(687, 273);
            this.btnDong.Name = "btnDong";
            this.btnDong.Rounded = false;
            this.btnDong.Size = new System.Drawing.Size(100, 80);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextColor = System.Drawing.Color.Black;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvDiemDanh
            // 
            this.dgvDiemDanh.AllowUserToResizeRows = false;
            this.dgvDiemDanh.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvDiemDanh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiemDanh.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDiemDanh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiemDanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiemDanh.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDiemDanh.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvDiemDanh.EnableHeadersVisualStyles = false;
            this.dgvDiemDanh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvDiemDanh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvDiemDanh.Location = new System.Drawing.Point(832, 0);
            this.dgvDiemDanh.Name = "dgvDiemDanh";
            this.dgvDiemDanh.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiemDanh.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDiemDanh.RowHeadersWidth = 51;
            this.dgvDiemDanh.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDiemDanh.RowTemplate.Height = 24;
            this.dgvDiemDanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiemDanh.Size = new System.Drawing.Size(766, 870);
            this.dgvDiemDanh.TabIndex = 0;
            this.dgvDiemDanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiemDanh_CellClick);
            this.dgvDiemDanh.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvNhanVien_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.cbbTraCuu);
            this.panel1.Controls.Add(this.foreverLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1598, 78);
            this.panel1.TabIndex = 0;
            // 
            // cbbTraCuu
            // 
            this.cbbTraCuu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTraCuu.BaseColor = System.Drawing.Color.Silver;
            this.cbbTraCuu.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.cbbTraCuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbTraCuu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTraCuu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTraCuu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbbTraCuu.ForeColor = System.Drawing.Color.White;
            this.cbbTraCuu.FormattingEnabled = true;
            this.cbbTraCuu.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cbbTraCuu.HoverFontColor = System.Drawing.Color.White;
            this.cbbTraCuu.ItemHeight = 18;
            this.cbbTraCuu.Location = new System.Drawing.Point(320, 21);
            this.cbbTraCuu.Name = "cbbTraCuu";
            this.cbbTraCuu.Size = new System.Drawing.Size(440, 24);
            this.cbbTraCuu.TabIndex = 5;
            // 
            // foreverForm1
            // 
            this.foreverForm1.BackColor = System.Drawing.Color.White;
            this.foreverForm1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.foreverForm1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.foreverForm1.Controls.Add(this.panel2);
            this.foreverForm1.Controls.Add(this.panel1);
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
            this.foreverForm1.Size = new System.Drawing.Size(1600, 1000);
            this.foreverForm1.TabIndex = 1;
            this.foreverForm1.Text = "Điểm Danh";
            this.foreverForm1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.foreverForm1.TextLight = System.Drawing.Color.SeaGreen;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dtpThoiGianRa);
            this.panel2.Controls.Add(this.dtpThoiGianVao);
            this.panel2.Controls.Add(this.cbbMaNV);
            this.panel2.Controls.Add(this.txtMaDiemDanh);
            this.panel2.Controls.Add(this.foreverLabel6);
            this.panel2.Controls.Add(this.foreverLabel5);
            this.panel2.Controls.Add(this.foreverLabel4);
            this.panel2.Controls.Add(this.foreverLabel3);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvDiemDanh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1598, 870);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cbbMaNV
            // 
            this.cbbMaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMaNV.BaseColor = System.Drawing.Color.Silver;
            this.cbbMaNV.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.cbbMaNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbMaNV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaNV.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbbMaNV.ForeColor = System.Drawing.Color.White;
            this.cbbMaNV.FormattingEnabled = true;
            this.cbbMaNV.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cbbMaNV.HoverFontColor = System.Drawing.Color.White;
            this.cbbMaNV.ItemHeight = 18;
            this.cbbMaNV.Location = new System.Drawing.Point(233, 153);
            this.cbbMaNV.Name = "cbbMaNV";
            this.cbbMaNV.Size = new System.Drawing.Size(445, 24);
            this.cbbMaNV.TabIndex = 7;
            // 
            // dtpThoiGianVao
            // 
            this.dtpThoiGianVao.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpThoiGianVao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianVao.Location = new System.Drawing.Point(233, 233);
            this.dtpThoiGianVao.Name = "dtpThoiGianVao";
            this.dtpThoiGianVao.Size = new System.Drawing.Size(445, 34);
            this.dtpThoiGianVao.TabIndex = 8;
            // 
            // dtpThoiGianRa
            // 
            this.dtpThoiGianRa.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpThoiGianRa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianRa.Location = new System.Drawing.Point(233, 316);
            this.dtpThoiGianRa.Name = "dtpThoiGianRa";
            this.dtpThoiGianRa.Size = new System.Drawing.Size(445, 34);
            this.dtpThoiGianRa.TabIndex = 8;
            // 
            // frmDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 1000);
            this.Controls.Add(this.foreverForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDiemDanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDiemDanh";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDiemDanh_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.foreverForm1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.ForeverButton btnTimKiem;
        private ReaLTaiizor.Controls.ForeverButton btnXoa;
        private ReaLTaiizor.Controls.ForeverButton txtLuu;
        private ReaLTaiizor.Controls.ForeverButton btnThem;
        private ReaLTaiizor.Controls.ForeverTextBox txtMaDiemDanh;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel6;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel5;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel4;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel3;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private System.Windows.Forms.Panel panel3;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvDiemDanh;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.ForeverComboBox cbbTraCuu;
        private ReaLTaiizor.Forms.ForeverForm foreverForm1;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.ForeverButton btnDong;
        private ReaLTaiizor.Controls.ForeverComboBox cbbMaNV;
        private System.Windows.Forms.DateTimePicker dtpThoiGianRa;
        private System.Windows.Forms.DateTimePicker dtpThoiGianVao;
    }
}
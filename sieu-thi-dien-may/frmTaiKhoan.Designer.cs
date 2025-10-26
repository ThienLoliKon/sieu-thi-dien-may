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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnXoa = new ReaLTaiizor.Controls.ForeverButton();
            this.txtLuu = new ReaLTaiizor.Controls.ForeverButton();
            this.btnThem = new ReaLTaiizor.Controls.ForeverButton();
            this.foreverLabel7 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel5 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel3 = new ReaLTaiizor.Controls.ForeverLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDong = new ReaLTaiizor.Controls.ForeverButton();
            this.btnDoiMatKhau = new ReaLTaiizor.Controls.ForeverButton();
            this.dgvTK = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.foreverForm1 = new ReaLTaiizor.Forms.ForeverForm();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbMaNV = new ReaLTaiizor.Controls.ForeverComboBox();
            this.cbbQuyen = new ReaLTaiizor.Controls.ForeverComboBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).BeginInit();
            this.foreverForm1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Transparent;
            this.btnXoa.BaseColor = System.Drawing.Color.Red;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(911, 42);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Rounded = false;
            this.btnXoa.Size = new System.Drawing.Size(110, 100);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextColor = System.Drawing.Color.Black;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtLuu
            // 
            this.txtLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLuu.BackColor = System.Drawing.Color.Transparent;
            this.txtLuu.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.txtLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtLuu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuu.Location = new System.Drawing.Point(481, 42);
            this.txtLuu.Name = "txtLuu";
            this.txtLuu.Rounded = false;
            this.txtLuu.Size = new System.Drawing.Size(110, 100);
            this.txtLuu.TabIndex = 0;
            this.txtLuu.Text = "Lưu";
            this.txtLuu.TextColor = System.Drawing.Color.Black;
            this.txtLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(26, 42);
            this.btnThem.Name = "btnThem";
            this.btnThem.Rounded = false;
            this.btnThem.Size = new System.Drawing.Size(110, 100);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextColor = System.Drawing.Color.Black;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // foreverLabel7
            // 
            this.foreverLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverLabel7.AutoSize = true;
            this.foreverLabel7.BackColor = System.Drawing.Color.White;
            this.foreverLabel7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel7.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel7.Location = new System.Drawing.Point(35, 351);
            this.foreverLabel7.Name = "foreverLabel7";
            this.foreverLabel7.Size = new System.Drawing.Size(157, 23);
            this.foreverLabel7.TabIndex = 2;
            this.foreverLabel7.Text = "Quyền Truy Cập:";
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
            this.foreverLabel5.Location = new System.Drawing.Point(35, 191);
            this.foreverLabel5.Name = "foreverLabel5";
            this.foreverLabel5.Size = new System.Drawing.Size(101, 23);
            this.foreverLabel5.TabIndex = 2;
            this.foreverLabel5.Text = "Mật Khẩu:";
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
            this.foreverLabel3.Location = new System.Drawing.Point(35, 40);
            this.foreverLabel3.Name = "foreverLabel3";
            this.foreverLabel3.Size = new System.Drawing.Size(76, 23);
            this.foreverLabel3.TabIndex = 2;
            this.foreverLabel3.Text = "Mã NV:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.btnDong);
            this.panel3.Controls.Add(this.btnDoiMatKhau);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.txtLuu);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 418);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1060, 330);
            this.panel3.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.Transparent;
            this.btnDong.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(214, 200);
            this.btnDong.Name = "btnDong";
            this.btnDong.Rounded = false;
            this.btnDong.Size = new System.Drawing.Size(110, 100);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextColor = System.Drawing.Color.Black;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.btnDoiMatKhau.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnDoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.Location = new System.Drawing.Point(720, 200);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Rounded = false;
            this.btnDoiMatKhau.Size = new System.Drawing.Size(110, 100);
            this.btnDoiMatKhau.TabIndex = 0;
            this.btnDoiMatKhau.Text = "Đổi Mật Khẩu";
            this.btnDoiMatKhau.TextColor = System.Drawing.Color.Black;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // dgvTK
            // 
            this.dgvTK.AllowUserToResizeRows = false;
            this.dgvTK.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvTK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTK.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTK.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTK.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTK.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvTK.EnableHeadersVisualStyles = false;
            this.dgvTK.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvTK.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTK.Location = new System.Drawing.Point(1060, 0);
            this.dgvTK.Name = "dgvTK";
            this.dgvTK.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTK.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTK.RowHeadersWidth = 51;
            this.dgvTK.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTK.RowTemplate.Height = 24;
            this.dgvTK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTK.Size = new System.Drawing.Size(738, 748);
            this.dgvTK.TabIndex = 0;
            this.dgvTK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTK_CellClick);
            this.dgvTK.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTK_MouseDoubleClick);
            // 
            // foreverForm1
            // 
            this.foreverForm1.BackColor = System.Drawing.Color.White;
            this.foreverForm1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.foreverForm1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.foreverForm1.Controls.Add(this.panel2);
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
            this.foreverForm1.Size = new System.Drawing.Size(1800, 800);
            this.foreverForm1.TabIndex = 1;
            this.foreverForm1.Text = "Quản Lý Tài Khoản";
            this.foreverForm1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.foreverForm1.TextLight = System.Drawing.Color.SeaGreen;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtMK);
            this.panel2.Controls.Add(this.cbbMaNV);
            this.panel2.Controls.Add(this.cbbQuyen);
            this.panel2.Controls.Add(this.foreverLabel7);
            this.panel2.Controls.Add(this.foreverLabel5);
            this.panel2.Controls.Add(this.foreverLabel3);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvTK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1798, 748);
            this.panel2.TabIndex = 1;
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
            this.cbbMaNV.Location = new System.Drawing.Point(295, 39);
            this.cbbMaNV.Name = "cbbMaNV";
            this.cbbMaNV.Size = new System.Drawing.Size(583, 24);
            this.cbbMaNV.TabIndex = 4;
            // 
            // cbbQuyen
            // 
            this.cbbQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbQuyen.BaseColor = System.Drawing.Color.Silver;
            this.cbbQuyen.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.cbbQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbQuyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbQuyen.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbbQuyen.ForeColor = System.Drawing.Color.White;
            this.cbbQuyen.FormattingEnabled = true;
            this.cbbQuyen.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cbbQuyen.HoverFontColor = System.Drawing.Color.White;
            this.cbbQuyen.ItemHeight = 18;
            this.cbbQuyen.Location = new System.Drawing.Point(295, 350);
            this.cbbQuyen.Name = "cbbQuyen";
            this.cbbQuyen.Size = new System.Drawing.Size(583, 24);
            this.cbbQuyen.TabIndex = 4;
            // 
            // txtMK
            // 
            this.txtMK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMK.BackColor = System.Drawing.Color.Silver;
            this.txtMK.Location = new System.Drawing.Point(295, 191);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(583, 34);
            this.txtMK.TabIndex = 5;
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 800);
            this.Controls.Add(this.foreverForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTaiKhoan";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).EndInit();
            this.foreverForm1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.ForeverButton btnXoa;
        private ReaLTaiizor.Controls.ForeverButton txtLuu;
        private ReaLTaiizor.Controls.ForeverButton btnThem;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel7;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel5;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel3;
        private System.Windows.Forms.Panel panel3;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvTK;
        private ReaLTaiizor.Forms.ForeverForm foreverForm1;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.ForeverComboBox cbbQuyen;
        private ReaLTaiizor.Controls.ForeverButton btnDoiMatKhau;
        private ReaLTaiizor.Controls.ForeverButton btnDong;
        private ReaLTaiizor.Controls.ForeverComboBox cbbMaNV;
        private System.Windows.Forms.TextBox txtMK;
    }
}
namespace he_thong_dien_may
{
    partial class frmCapBacNhanVien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDong = new ReaLTaiizor.Controls.ForeverButton();
            this.btnXoa = new ReaLTaiizor.Controls.ForeverButton();
            this.btnLuu = new ReaLTaiizor.Controls.ForeverButton();
            this.btnThem = new ReaLTaiizor.Controls.ForeverButton();
            this.foreverLabel3 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            this.foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            this.txtMoTa = new ReaLTaiizor.Controls.ForeverTextBox();
            this.txtCapBac = new ReaLTaiizor.Controls.ForeverTextBox();
            this.txtMaCB = new ReaLTaiizor.Controls.ForeverTextBox();
            this.dgvCapBac = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.foreverForm1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapBac)).BeginInit();
            this.SuspendLayout();
            // 
            // foreverForm1
            // 
            this.foreverForm1.BackColor = System.Drawing.Color.White;
            this.foreverForm1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.foreverForm1.BorderColor = System.Drawing.Color.DodgerBlue;
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
            this.foreverForm1.Size = new System.Drawing.Size(1094, 630);
            this.foreverForm1.TabIndex = 0;
            this.foreverForm1.Text = "Quản Lý Cấp Bậc";
            this.foreverForm1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.foreverForm1.TextLight = System.Drawing.Color.SeaGreen;
            this.foreverForm1.Click += new System.EventHandler(this.foreverForm1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvCapBac);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 578);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.foreverLabel3);
            this.panel2.Controls.Add(this.foreverLabel2);
            this.panel2.Controls.Add(this.foreverLabel1);
            this.panel2.Controls.Add(this.txtMoTa);
            this.panel2.Controls.Add(this.txtCapBac);
            this.panel2.Controls.Add(this.txtMaCB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 579);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.btnDong);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.btnLuu);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 383);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 196);
            this.panel3.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Transparent;
            this.btnDong.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(404, 101);
            this.btnDong.Name = "btnDong";
            this.btnDong.Rounded = false;
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextColor = System.Drawing.Color.Black;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.BaseColor = System.Drawing.Color.Red;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(404, 55);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Rounded = false;
            this.btnXoa.Size = new System.Drawing.Size(120, 40);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextColor = System.Drawing.Color.Black;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Transparent;
            this.btnLuu.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(231, 55);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Rounded = false;
            this.btnLuu.Size = new System.Drawing.Size(120, 40);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextColor = System.Drawing.Color.Black;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(59, 55);
            this.btnThem.Name = "btnThem";
            this.btnThem.Rounded = false;
            this.btnThem.Size = new System.Drawing.Size(120, 40);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextColor = System.Drawing.Color.Black;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // foreverLabel3
            // 
            this.foreverLabel3.AutoSize = true;
            this.foreverLabel3.BackColor = System.Drawing.Color.White;
            this.foreverLabel3.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.foreverLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel3.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel3.Location = new System.Drawing.Point(44, 234);
            this.foreverLabel3.Name = "foreverLabel3";
            this.foreverLabel3.Size = new System.Drawing.Size(67, 23);
            this.foreverLabel3.TabIndex = 1;
            this.foreverLabel3.Text = "Mô tả:";
            this.foreverLabel3.Click += new System.EventHandler(this.foreverLabel3_Click);
            // 
            // foreverLabel2
            // 
            this.foreverLabel2.AutoSize = true;
            this.foreverLabel2.BackColor = System.Drawing.Color.White;
            this.foreverLabel2.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.foreverLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel2.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel2.Location = new System.Drawing.Point(44, 159);
            this.foreverLabel2.Name = "foreverLabel2";
            this.foreverLabel2.Size = new System.Drawing.Size(125, 23);
            this.foreverLabel2.TabIndex = 1;
            this.foreverLabel2.Text = "Tên Cấp Bậc:";
            this.foreverLabel2.Click += new System.EventHandler(this.foreverLabel2_Click);
            // 
            // foreverLabel1
            // 
            this.foreverLabel1.AutoSize = true;
            this.foreverLabel1.BackColor = System.Drawing.Color.White;
            this.foreverLabel1.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.foreverLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreverLabel1.ForeColor = System.Drawing.Color.Black;
            this.foreverLabel1.Location = new System.Drawing.Point(44, 85);
            this.foreverLabel1.Name = "foreverLabel1";
            this.foreverLabel1.Size = new System.Drawing.Size(121, 23);
            this.foreverLabel1.TabIndex = 1;
            this.foreverLabel1.Text = "Mã Cấp Bậc:";
            this.foreverLabel1.Click += new System.EventHandler(this.foreverLabel1_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.BackColor = System.Drawing.Color.Transparent;
            this.txtMoTa.BaseColor = System.Drawing.Color.Silver;
            this.txtMoTa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.txtMoTa.FocusOnHover = false;
            this.txtMoTa.ForeColor = System.Drawing.Color.Black;
            this.txtMoTa.Location = new System.Drawing.Point(191, 223);
            this.txtMoTa.MaxLength = 32767;
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = false;
            this.txtMoTa.Size = new System.Drawing.Size(271, 34);
            this.txtMoTa.TabIndex = 0;
            this.txtMoTa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMoTa.UseSystemPasswordChar = false;
            this.txtMoTa.TextChanged += new System.EventHandler(this.txtMoTa_TextChanged);
            // 
            // txtCapBac
            // 
            this.txtCapBac.BackColor = System.Drawing.Color.Transparent;
            this.txtCapBac.BaseColor = System.Drawing.Color.Silver;
            this.txtCapBac.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.txtCapBac.FocusOnHover = false;
            this.txtCapBac.ForeColor = System.Drawing.Color.Black;
            this.txtCapBac.Location = new System.Drawing.Point(191, 148);
            this.txtCapBac.MaxLength = 32767;
            this.txtCapBac.Multiline = false;
            this.txtCapBac.Name = "txtCapBac";
            this.txtCapBac.ReadOnly = false;
            this.txtCapBac.Size = new System.Drawing.Size(271, 34);
            this.txtCapBac.TabIndex = 0;
            this.txtCapBac.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCapBac.UseSystemPasswordChar = false;
            this.txtCapBac.TextChanged += new System.EventHandler(this.txtCapBac_TextChanged);
            // 
            // txtMaCB
            // 
            this.txtMaCB.BackColor = System.Drawing.Color.Transparent;
            this.txtMaCB.BaseColor = System.Drawing.Color.Silver;
            this.txtMaCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.txtMaCB.FocusOnHover = false;
            this.txtMaCB.ForeColor = System.Drawing.Color.Black;
            this.txtMaCB.Location = new System.Drawing.Point(191, 74);
            this.txtMaCB.MaxLength = 32767;
            this.txtMaCB.Multiline = false;
            this.txtMaCB.Name = "txtMaCB";
            this.txtMaCB.ReadOnly = false;
            this.txtMaCB.Size = new System.Drawing.Size(271, 34);
            this.txtMaCB.TabIndex = 0;
            this.txtMaCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMaCB.UseSystemPasswordChar = false;
            this.txtMaCB.TextChanged += new System.EventHandler(this.txtMaCapBac_TextChanged);
            // 
            // dgvCapBac
            // 
            this.dgvCapBac.AllowUserToResizeRows = false;
            this.dgvCapBac.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvCapBac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCapBac.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCapBac.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCapBac.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCapBac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCapBac.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCapBac.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvCapBac.EnableHeadersVisualStyles = false;
            this.dgvCapBac.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvCapBac.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvCapBac.Location = new System.Drawing.Point(582, 0);
            this.dgvCapBac.Name = "dgvCapBac";
            this.dgvCapBac.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCapBac.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCapBac.RowHeadersWidth = 51;
            this.dgvCapBac.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCapBac.RowTemplate.Height = 24;
            this.dgvCapBac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCapBac.Size = new System.Drawing.Size(510, 578);
            this.dgvCapBac.TabIndex = 0;
            this.dgvCapBac.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCapBac_CellClick);
            this.dgvCapBac.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCapBac_MouseDoubleClick);
            // 
            // frmCapBacNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 630);
            this.Controls.Add(this.foreverForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCapBacNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCapBacNhanVien";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.foreverForm1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapBac)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm foreverForm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.ForeverTextBox txtMaCB;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvCapBac;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel3;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
        private ReaLTaiizor.Controls.ForeverTextBox txtMoTa;
        private ReaLTaiizor.Controls.ForeverTextBox txtCapBac;
        private System.Windows.Forms.Panel panel3;
        private ReaLTaiizor.Controls.ForeverButton btnDong;
        private ReaLTaiizor.Controls.ForeverButton btnXoa;
        private ReaLTaiizor.Controls.ForeverButton btnLuu;
        private ReaLTaiizor.Controls.ForeverButton btnThem;
    }
}
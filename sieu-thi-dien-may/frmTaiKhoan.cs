using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace he_thong_dien_may
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        public void LoadDL()
        {
            try
            {
                TaiKhoanBUS bus = new TaiKhoanBUS();
                DataTable dtNhanVien = bus.GetAllTaiKhoanAsTable();

                if (dtNhanVien != null)
                {
                    dgvTK.DataSource = dtNhanVien;
                }
                else
                {
                    dgvTK.DataSource = null;
                    MessageBox.Show("Không có dữ liệu Tài Khoản để hiển thị. Vui lòng kiểm tra database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu DataGridView: {ex.Message}", "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxData()
        {
            try
            {
                TaiKhoanBUS tkBus = new TaiKhoanBUS();
                NhanVienBUS nvbus = new NhanVienBUS();

                // 1. LOAD DANH SÁCH NHÂN VIÊN VÀO cbbMaNV
                DataTable dtNhanVien = nvbus.GetAllNhanVienAsTable();

                if (dtNhanVien != null)
                {
                    cbbMaNV.DataSource = dtNhanVien;
                    cbbMaNV.DisplayMember = "MaNV"; // HIỂN THỊ MÃ NV
                    cbbMaNV.ValueMember = "MaNV";    // Gán MÃ NV
                    cbbMaNV.SelectedIndex = -1;
                }
                cbbMaNV.Tag = dtNhanVien;

                // 2. LOAD QUYỀN VÀO cbbQuyen (Hardcode mẫu hoặc dùng bảng khác)
                DataTable dtQuyen = new DataTable();
                //dtQuyen.Columns.Add("TenQuyen");
                //dtQuyen.Rows.Add("Admin");
                //dtQuyen.Rows.Add("QuanLyCN");
                //dtQuyen.Rows.Add("TruongKho");
                //dtQuyen.Rows.Add("NhanVien");

                cbbQuyen.DataSource = dtQuyen;
                cbbQuyen.DisplayMember = "Quyen";
                cbbQuyen.ValueMember = "Quyen";
                cbbQuyen.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ComboBox: " + ex.Message, "Lỗi Load Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();

            // Cài đặt DataGridView Columns (GIỮ NGUYÊN)
            dgvTK.AutoGenerateColumns = false;
            dgvTK.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 100 });
            dgvTK.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mật Khẩu", DataPropertyName = "MatKhau", Width = 100 });
            dgvTK.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quyền Truy Cập", DataPropertyName = "Quyen", Width = 100 });

            // Load Dữ liệu DataGridView sau
            LoadDL();
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                // GÁN MÃ ĐỂ COMBOBOX TỰ ĐỘNG CHỌN ĐÚNG MỤC
                cbbMaNV.SelectedValue = dgvTK.Rows[line].Cells[0].Value; // MaCB
                txtMK.Text = dgvTK.Rows[line].Cells[1].Value.ToString();
                cbbQuyen.SelectedValue = dgvTK.Rows[line].Cells[2].Value; // MaChiNhanh
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết lên controls: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Lấy Mã từ SelectedValue
                    string manv = cbbMaNV.SelectedValue?.ToString();
                    string tennv = txtMK.Text;
                    string quyen = cbbQuyen.SelectedValue?.ToString();


                    TaiKhoanBUS bus = new TaiKhoanBUS();

                    // THỨ TỰ ĐÚNG CỦA BUS: (tenNV, macapbac, sdt, diachi, machinhanh, trangthai)
                    bool isAdd = bus.AddTaiKhoan(
                        manv, tennv, quyen
                    );

                    if (isAdd)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                    LoadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn sửa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // LẤY MÃ TỪ SELECTEDVALUE (KHẮC PHỤC LỖI FK/TRUNCATION)
                    string manv = cbbMaNV.SelectedValue?.ToString();
                    string tennv = txtMK.Text;
                    string quyen = cbbQuyen.SelectedValue?.ToString(); // Đảm bảo luôn là mã ngắn gọn (char(10))


                    TaiKhoanBUS bus = new TaiKhoanBUS();

                    bool isupdate = bus.AddTaiKhoan(
                        manv, tennv, quyen
                    );

                    if (isupdate)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                    LoadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sửa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // KHẮC PHỤC LỖI CÚ PHÁP MESSAGEBOX
            DialogResult result = MessageBox.Show($"Bạn có muốn chuyển trạng thái nhân viên có mã: {cbbMaNV.Text} thành 'Đã Nghỉ' không ?", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    TaiKhoanBUS bus = new TaiKhoanBUS();
                    bool isDeleted = bus.DeleteTaiKhoan(cbbMaNV.Text);

                    if (isDeleted)
                    {
                        MessageBox.Show("Chuyển trạng thái thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Chuyển trạng thái thất bại.");
                    }
                    LoadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chuyển trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn Thoát không ?", "thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvTK_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadComboBoxData();
            LoadDL();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {

        }
    }
}

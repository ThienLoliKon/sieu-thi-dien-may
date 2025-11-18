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
        private string _maNVCanLoc = null;
        TaiKhoanBUS tkBus = new TaiKhoanBUS();
        public frmTaiKhoan(string maNV) : this() 
        {
            _maNVCanLoc = maNV;
        }
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

                DataTable dtNhanVien = nvbus.GetAllNhanVienAsTable();

                if (dtNhanVien != null)
                {
                    cbbMaNV.DataSource = dtNhanVien;
                    cbbMaNV.DisplayMember = "MaNV"; 
                    cbbMaNV.ValueMember = "MaNV";   
                    cbbMaNV.SelectedIndex = -1;
                }

                DataTable dtQuyen = tkBus.GetAllTaiKhoanAsTable(); 

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
        private void FilterByMaNV(string maNV)
        {
            try
            {
                DataTable dtKetQua = tkBus.timTaiKhoan(maNV);
                if (dtKetQua != null && dtKetQua.Rows.Count > 0)
                {
                    dgvTK.DataSource = dtKetQua;
                }
                else
                {
                    dgvTK.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();

            dgvTK.AutoGenerateColumns = false;
            dgvTK.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 300 });
            dgvTK.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mật Khẩu", DataPropertyName = "MatKhau", Width = 300 });
            dgvTK.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quyền Truy Cập", DataPropertyName = "Quyen", Width = 430 });
            if (!string.IsNullOrEmpty(_maNVCanLoc))
            {
                cbbMaNV.SelectedValue = _maNVCanLoc;
                FilterByMaNV(_maNVCanLoc);
            }
            else
            {
                LoadDL();
            }
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                cbbMaNV.SelectedValue = dgvTK.Rows[line].Cells[0].Value; 
                txtMK.Text = dgvTK.Rows[line].Cells[1].Value.ToString();
                cbbQuyen.SelectedValue = dgvTK.Rows[line].Cells[2].Value; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết lên controls: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = cbbMaNV.SelectedValue?.ToString();
            string matKhau = txtMK.Text.Trim();
            string quyen = cbbQuyen.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(quyen))
            {
                MessageBox.Show("Vui lòng chọn Mã NV, nhập Mật khẩu và Quyền.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhau.Length > 7)
            {
                MessageBox.Show("Mật khẩu không được vượt quá 7 ký tự.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    TaiKhoanBUS bus = new TaiKhoanBUS();

                    bool isAdd = bus.AddTaiKhoan(maNV, matKhau, quyen);

                    if (isAdd)
                    {
                        MessageBox.Show("Thêm Tài khoản thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm Tài khoản không thành công. (Mã NV đã có tài khoản)");
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
            string maNV = cbbMaNV.SelectedValue?.ToString();
            string matKhau = txtMK.Text.Trim();
            string quyen = cbbQuyen.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(quyen))
            {
                MessageBox.Show("Vui lòng chọn Tài khoản và điền đầy đủ Mật khẩu/Quyền.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhau.Length > 7)
            {
                MessageBox.Show("Mật khẩu không được vượt quá 7 ký tự.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn sửa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    TaiKhoanBUS bus = new TaiKhoanBUS();

                    bool isupdate = bus.UpdateTaiKhoanstring(maNV, matKhau, quyen);

                    if (isupdate)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại (Mã NV không tồn tại TK).");
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
            if (cbbMaNV.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Tài khoản cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Tài khoản của Mã NV: {cbbMaNV.SelectedValue} không?", "Xác nhận Xóa", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string maNV = cbbMaNV.SelectedValue.ToString();
                    TaiKhoanBUS bus = new TaiKhoanBUS();
                    bool isDeleted = bus.DeleteTaiKhoan(maNV); 

                    MessageBox.Show(isDeleted ? "Xóa Tài khoản thành công!" : "Xóa thất bại.");
                    LoadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

using BUS;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions; 

namespace he_thong_dien_may
{
    public partial class frmLuong : Form
    {
        private string _maNVCanLoc = null;
        private LuongBUS luongBus = new LuongBUS();
        private NhanVienBUS nvBus = new NhanVienBUS();
        public frmLuong(string maNV) : this() 
        {
            _maNVCanLoc = maNV;
        }
        public frmLuong()
        {
            InitializeComponent();
            txtTongLuongNhan.ReadOnly = true;
        }


        private void ClearInputControls()
        {
            txtMaPhieuLuong.Text = "";
            cbbMaNV.SelectedIndex = -1;
            txtLuongCoBan.Text = "";
            txtThuong.Text = "";
            txtPhat.Text = "";
            txtTongLuongNhan.Text = "";
            dtpThangLuong.Value = DateTime.Now;

            txtMaPhieuLuong.ReadOnly = false;
        }
        private bool ContainsSpecialChars(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9\s\p{L}]");
        }

        private bool ValidateInput(out double luongCB, out double thuong, out double phat)
        {
            string maNV = cbbMaNV.SelectedValue?.ToString();
            string luongCBStr = txtLuongCoBan.Text.Trim();
            string thuongStr = txtThuong.Text.Trim();
            string phatStr = txtPhat.Text.Trim();

            luongCB = 0; thuong = 0; phat = 0;

            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(luongCBStr))
            {
                MessageBox.Show("Vui lòng chọn Mã NV và nhập Lương CB.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ContainsSpecialChars(luongCBStr))
            {
                MessageBox.Show("Lương cơ bản không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(thuongStr)) thuongStr = "0";
            if (string.IsNullOrEmpty(phatStr)) phatStr = "0";

            if (!double.TryParse(luongCBStr, out luongCB) || luongCB < 0 ||
                !double.TryParse(thuongStr, out thuong) || thuong < 0 ||
                !double.TryParse(phatStr, out phat) || phat < 0)
            {
                MessageBox.Show("Lương CB, Thưởng, Phạt phải là số dương hợp lệ.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public void LoadDL()
        {
            try
            {
                DataTable dtLuong = luongBus.GetAllLuongAsTable();

                if (dtLuong != null)
                {
                    dgvLuong.DataSource = dtLuong;
                    dgvLuong.ReadOnly = true;
                }
                else
                {
                    dgvLuong.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu Lương: {ex.Message}", "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                DataTable dtNhanVien = nvBus.GetAllNhanVienAsTable();
                if (dtNhanVien != null)
                {
                    cbbMaNV.DataSource = dtNhanVien;
                    cbbMaNV.DisplayMember = "MaNV";
                    cbbMaNV.ValueMember = "MaNV";
                    cbbMaNV.SelectedIndex = -1;
                }
                DataTable dttimkiem = nvBus.GetAllNhanVienAsTable();
                if (dttimkiem != null)
                {
                    cbbTraCuu.DataSource = dttimkiem;
                    cbbTraCuu.DisplayMember = "MaNV";
                    cbbTraCuu.ValueMember = "MaNV";
                    cbbTraCuu.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải Mã NV: {ex.Message}", "Lỗi Load Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FilterByMaNV(string maNV)
        {
            try
            {
                DataTable dtKetQua = luongBus.timLuong(maNV);
                if (dtKetQua != null && dtKetQua.Rows.Count > 0)
                {
                    dgvLuong.DataSource = dtKetQua;
                }
                else
                {
                    dgvLuong.DataSource = null;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Lỗi trong quá trình lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            dgvLuong.AutoGenerateColumns = false;

            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Phiếu", DataPropertyName = "MaPhieuLuong", Width = 220 });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 220 });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lương CB", DataPropertyName = "LuongCB", Width = 220 });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tháng", DataPropertyName = "ThangLuong", Width = 220 });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thưởng", DataPropertyName = "Thuong", Width = 220 });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phạt", DataPropertyName = "Phat", Width = 200 });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tổng Nhận", DataPropertyName = "TongNhan", Width = 200 });
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

        private void btnThem_Click(object sender, EventArgs e)
        {

            double luongCB, thuong, phat;
            if (!ValidateInput(out luongCB, out thuong, out phat)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm Phiếu lương này không?", "Xác nhận Thêm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maNV = cbbMaNV.SelectedValue.ToString();
                    string thangLuong = dtpThangLuong.Value.ToString();

                    bool success = luongBus.AddLuong(maNV, luongCB, thangLuong, thuong, phat);

                    if (success) { MessageBox.Show("Thêm thành công"); LoadDL(); ClearInputControls(); }
                    else { MessageBox.Show("Thêm thất bại."); }
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi nghiệp vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            double luongCB, thuong, phat;

            string maPhieuLuong = txtMaPhieuLuong.Text.Trim();
            if (txtMaPhieuLuong.ReadOnly == false || string.IsNullOrEmpty(maPhieuLuong))
            {
                MessageBox.Show("Nút Lưu chỉ dùng để cập nhật. Vui lòng chọn một bản ghi từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(out luongCB, out thuong, out phat)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật Phiếu lương này không?", "Xác nhận Sửa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maNV = cbbMaNV.SelectedValue.ToString();
                    string thangLuong = dtpThangLuong.Value.ToString();

                    bool success = luongBus.UpdateLuong(maPhieuLuong, maNV, luongCB, thangLuong, thuong, phat);

                    if (success) { MessageBox.Show("Cập nhật thành công"); LoadDL(); }
                    else { MessageBox.Show("Cập nhật thất bại (Mã không tồn tại)."); }
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi sửa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                txtMaPhieuLuong.Text = dgvLuong.Rows[line].Cells[0].Value.ToString();
                cbbMaNV.SelectedValue = dgvLuong.Rows[line].Cells[1].Value;
                txtLuongCoBan.Text = dgvLuong.Rows[line].Cells[2].Value.ToString();

                if (dgvLuong.Rows[line].Cells[3].Value != DBNull.Value)
                {
                    dtpThangLuong.Value = Convert.ToDateTime(dgvLuong.Rows[line].Cells[3].Value);
                }

                txtThuong.Text = dgvLuong.Rows[line].Cells[4].Value.ToString(); 
                txtPhat.Text = dgvLuong.Rows[line].Cells[5].Value.ToString();   
                txtTongLuongNhan.Text = dgvLuong.Rows[line].Cells[6].Value.ToString(); 

                txtMaPhieuLuong.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPhieu = txtMaPhieuLuong.Text.Trim();

            if (string.IsNullOrEmpty(maPhieu))
            {
                MessageBox.Show("Vui lòng chọn Phiếu lương cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có muốn xóa Phiếu lương có mã: {maPhieu} không?", "Xác nhận Xóa", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = luongBus.DeleteLuong(maPhieu);
                    MessageBox.Show(isDeleted ? "Xóa thành công!" : "Xóa thất bại.");
                    LoadDL();
                    ClearInputControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string maNVLoc = cbbTraCuu.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maNVLoc))
            {
                LoadDL(); 
                return;
            }
            try
            {
                DataTable dtKetQua = luongBus.timLuong(maNVLoc);

                if (dtKetQua != null && dtKetQua.Rows.Count > 0)
                {
                    dgvLuong.DataSource = dtKetQua;
                }
                else
                {
                    dgvLuong.DataSource = null;
                    MessageBox.Show($"Không tìm thấy phiếu lương nào của nhân viên có mã: {maNVLoc}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
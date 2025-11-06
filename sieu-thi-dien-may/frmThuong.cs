using BUS;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace he_thong_dien_may
{
    public partial class frmThuong : Form
    {
        // KHAI BÁO BUS
        private ThuongBUS tBus = new ThuongBUS();
        private NhanVienBUS nvBus = new NhanVienBUS();
        private LoaiThuongBUS ltBus = new LoaiThuongBUS();


        public frmThuong()
        {
            InitializeComponent();
            cbbLoaiThuong.SelectedValueChanged += cbbLoaiThuong_SelectedValueChanged;
            if (txtMucThuong != null) txtMucThuong.ReadOnly = true;
            this.Load += frmThuong_Load;
        }

        private void ClearInputControls()
        {
            txtMaThuong.Text = "";
            cbbMaNV.SelectedIndex = -1;
            cbbLoaiThuong.SelectedIndex = -1;
            if (txtMucThuong != null) txtMucThuong.Text = "0";
            dtpThoiGianThuong.Value = DateTime.Now;
            cbTrangThai.Checked = false; // Mặc định là chưa trao

            txtMaThuong.ReadOnly = false;
        }

        private bool ValidateInput(out DateTime thoiGian, out bool trangThai)
        {
            thoiGian = dtpThoiGianThuong.Value;
            trangThai = cbTrangThai.Checked;

            if (cbbMaNV.SelectedValue == null || cbbLoaiThuong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhân viên và Loại thưởng.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void cbbLoaiThuong_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbLoaiThuong.SelectedValue != null && cbbLoaiThuong.Tag is DataTable dtLoaiThuong && txtMucThuong != null)
            {
                string maLT = cbbLoaiThuong.SelectedValue.ToString();
                DataRow[] rows = dtLoaiThuong.Select($"MaLT = '{maLT}'");
                if (rows.Length > 0)
                {
                    // Giả định cột Mức thưởng là MucThuong
                    txtMucThuong.Text = rows[0]["MucThuong"].ToString();
                    return;
                }
            }
            if (txtMucThuong != null) txtMucThuong.Text = "0";
        }

        public void LoadDL()
        {
            try
            {
                DataTable dtThuong = tBus.GetAllThuongAsTable();
                if (dtThuong != null)
                {
                    dgvThuong.DataSource = dtThuong;
                    dgvThuong.ReadOnly = true;
                }
                else
                {
                    dgvThuong.DataSource = null;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadComboBoxData()
        {
            try
            {
                // 1. Load Nhân viên
                DataTable dtNV = nvBus.GetAllNhanVienAsTable();
                if (dtNV != null)
                {
                    cbbMaNV.DataSource = dtNV;
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
                // 2. Load Loại Thưởng
                DataTable dtLT = ltBus.GetAllLoaiThuongAsTable();
                if (dtLT != null)
                {
                    cbbLoaiThuong.DataSource = dtLT;
                    cbbLoaiThuong.DisplayMember = "LoaiYC"; // Hiển thị tên loại yêu cầu cho dễ hiểu
                    cbbLoaiThuong.ValueMember = "MaLT";
                    cbbLoaiThuong.Tag = dtLT; // Lưu để lấy Mức thưởng
                    cbbLoaiThuong.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void frmThuong_Load(object sender, EventArgs e)
        {
            dgvThuong.AutoGenerateColumns = false;

            dgvThuong.Columns.Clear();
            
            dgvThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Thưởng", DataPropertyName = "MaThuong", Width = 150 });
            dgvThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 150 });
            dgvThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại Thưởng", DataPropertyName = "MaLoaiThuong", Width = 150 });
            dgvThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thời Gian", DataPropertyName = "ThoiGianThuong", Width = 150 });
            dgvThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 150 });
            dgvThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mức Thưởng", DataPropertyName = "MucThuong", Width = 150 });
            LoadComboBoxData();
            LoadDL();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            DateTime thoiGian;
            bool trangThai;
            if (!ValidateInput(out thoiGian, out trangThai)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm phiếu thưởng này không?", "Xác nhận Thêm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maNV = cbbMaNV.SelectedValue?.ToString();
                    string maLoaiThuong = cbbLoaiThuong.SelectedValue?.ToString();

                    bool success = tBus.AddThuong(maNV, maLoaiThuong, thoiGian);

                    if (success) { MessageBox.Show("Thêm thành công"); LoadDL(); ClearInputControls(); }
                    else { MessageBox.Show("Thêm thất bại."); }
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi nghiệp vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime thoiGian;
            bool trangThai;

            string maThuong = txtMaThuong.Text.Trim();
            if (txtMaThuong.ReadOnly == false || string.IsNullOrEmpty(maThuong))
            {
                MessageBox.Show("Nút Lưu chỉ dùng để cập nhật. Vui lòng chọn một bản ghi từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(out thoiGian, out trangThai)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật phiếu thưởng này không?", "Xác nhận Sửa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maNV = cbbMaNV.SelectedValue?.ToString();
                    string maLoaiThuong = cbbLoaiThuong.SelectedValue?.ToString();

                    bool success = tBus.UpdateThuong(maThuong, maNV, maLoaiThuong, thoiGian, trangThai);

                    if (success) { MessageBox.Show("Cập nhật thành công"); LoadDL(); }
                    else { MessageBox.Show("Cập nhật thất bại (Mã không tồn tại)."); }
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi sửa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void dgvThuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                txtMaThuong.Text = dgvThuong.Rows[line].Cells[0].Value.ToString();
                cbbMaNV.SelectedValue = dgvThuong.Rows[line].Cells[1].Value;
                cbbLoaiThuong.SelectedValue = dgvThuong.Rows[line].Cells[2].Value;

                if (dgvThuong.Rows[line].Cells[3].Value != DBNull.Value)
                    dtpThoiGianThuong.Value = Convert.ToDateTime(dgvThuong.Rows[line].Cells[3].Value);

                if (dgvThuong.Rows[line].Cells[4].Value != DBNull.Value)
                    cbTrangThai.Checked = Convert.ToBoolean(dgvThuong.Rows[line].Cells[4].Value);

                if (dgvThuong.Rows[line].Cells[5].Value != DBNull.Value && txtMucThuong != null)
                    txtMucThuong.Text = dgvThuong.Rows[line].Cells[5].Value.ToString();

                txtMaThuong.ReadOnly = true;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maThuong = txtMaThuong.Text.Trim();
            if (string.IsNullOrEmpty(maThuong)) { MessageBox.Show("Chọn phiếu thưởng cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show($"Xóa phiếu thưởng {maThuong}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = tBus.DeleteThuong(maThuong);
                    MessageBox.Show(isDeleted ? "Xóa thành công!" : "Xóa thất bại.");
                    LoadDL();
                    ClearInputControls();
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                DataTable dtKetQua = tBus.TimThuongTheoMaNV(maNVLoc);
                if (dtKetQua != null && dtKetQua.Rows.Count > 0)
                {
                    dgvThuong.DataSource = dtKetQua;
                }
                else
                {
                    dgvThuong.DataSource = null;
                    MessageBox.Show($"Không tìm thấy phiếu thưởng nào của nhân viên {maNVLoc}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
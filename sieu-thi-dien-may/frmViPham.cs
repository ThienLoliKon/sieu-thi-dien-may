using BUS;
using System;
using System.Data;
using System.Linq; // Cần cho char.IsDigit
using System.Windows.Forms;
using System.Text.RegularExpressions; // Cần cho ký tự đặc biệt

namespace he_thong_dien_may
{
    // ĐÃ SỬA TÊN LỚP ĐỂ PHÙ HỢP VỚI FORM VIPHAM
    public partial class frmViPham : Form
    {

        public frmViPham()
        {
            InitializeComponent();
            // Liên kết sự kiện khi chọn Loại Vi Phạm để hiển thị Mức Phạt
            cbbLoaiViPham.SelectedValueChanged += cbbLoaiViPham_SelectedValueChanged;
            if (txtMucPhat != null)
            {
                txtMucPhat.ReadOnly = true;
            }
        }

        // Hàm kiểm tra ký tự đặc biệt (Giữ nguyên)
        private bool ContainsSpecialChars(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9\s\p{L}]");
        }

        private void ClearInputControls()
        {
            // SỬA: Dựa trên controls Vi Phạm
            txtMaViPham.Text = "";
            cbbMaNV.SelectedIndex = -1;
            cbbLoaiViPham.SelectedIndex = -1;

            if (txtMucPhat != null) txtMucPhat.Text = "";
            dtpThoiGianViPham.Value = DateTime.Now;
            cbTrangThai.Checked = false; // Trạng thái mặc định

            // Đặt ReadOnly = false để KÍCH HOẠT chế độ THÊM MỚI
            txtMaViPham.ReadOnly = false;
        }

        // Hàm xác thực dữ liệu đầu vào (SỬA DỮ LIỆU ĐẦU VÀO)
        private bool ValidateInput(out DateTime thoiGianVP, out bool trangThai)
        {
            // Lấy và làm sạch dữ liệu
            string maNV = cbbMaNV.SelectedValue?.ToString();
            string maLoaiVP = cbbLoaiViPham.SelectedValue?.ToString();

            thoiGianVP = dtpThoiGianViPham.Value;
            trangThai = cbTrangThai.Checked;

            // Quy tắc 1: Kiểm tra trống
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(maLoaiVP))
            {
                MessageBox.Show("Vui lòng chọn Mã NV và Loại Vi phạm.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Quy tắc 2: Kiểm tra ký tự đặc biệt (Không cần cho form này)

            // 3. Kiểm tra kiểu dữ liệu (Thời gian không được trong tương lai)
            if (thoiGianVP > DateTime.Now)
            {
                MessageBox.Show("Thời gian vi phạm không được xảy ra trong tương lai.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public void LoadDL()
        {
            try
            {
                // SỬA: Gọi ViPhamBUS
                ViPhamBUS vpBus = new ViPhamBUS();
                DataTable dtViPham = vpBus.GetAllViPhamAsTable();

                if (dtViPham != null)
                {
                    dgvViPham.DataSource = dtViPham;
                    dgvViPham.ReadOnly = true;
                }
                else
                {
                    dgvViPham.DataSource = null;
                    MessageBox.Show("Không có dữ liệu Vi phạm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // 1. Load Mã Nhân Viên
                NhanVienBUS nvBus = new NhanVienBUS();
                DataTable dtNhanVien = nvBus.GetAllNhanVienAsTable();
                if (dtNhanVien != null)
                {
                    cbbMaNV.DataSource = dtNhanVien;
                    cbbMaNV.DisplayMember = "MaNV";
                    cbbMaNV.ValueMember = "MaNV";
                    cbbMaNV.SelectedIndex = -1;
                }
                DataTable dtvipham = nvBus.GetAllNhanVienAsTable();
                if (dtvipham != null)
                {
                    cbbTraCuu.DataSource = dtNhanVien;
                    cbbTraCuu.DisplayMember = "MaNV";
                    cbbTraCuu.ValueMember = "MaNV";
                    cbbTraCuu.SelectedIndex = -1;
                }


                // 2. Load Loại Vi Phạm
                LoaiViPhamBUS lvpBus = new LoaiViPhamBUS();
                DataTable dtLoaiVP = lvpBus.GetAllLoaiViPhamAsTable();
                if (dtLoaiVP != null)
                {
                    cbbLoaiViPham.DataSource = dtLoaiVP;
                    cbbLoaiViPham.DisplayMember = "MoTa";
                    cbbLoaiViPham.ValueMember = "MaLVP";
                    cbbLoaiViPham.Tag = dtLoaiVP; // Lưu DT để tìm kiếm Mức phạt
                    cbbLoaiViPham.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ComboBox: {ex.Message}", "Lỗi Load Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbLoaiViPham_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbLoaiViPham.SelectedValue != null && cbbLoaiViPham.Tag is DataTable dtLoaiVP && txtMucPhat != null)
            {
                string maLVP = cbbLoaiViPham.SelectedValue.ToString();
                DataRow[] rows = dtLoaiVP.Select($"MaLVP = '{maLVP}'");
                if (rows.Length > 0)
                {
                    txtMucPhat.Text = rows[0]["MucPhat"].ToString();
                    return;
                }
            }
            if (txtMucPhat != null) txtMucPhat.Text = "0.0";
        }

        private void frmViPham_Load(object sender, EventArgs e) // SỬA TÊN SỰ KIỆN
        {
            LoadComboBoxData(); // Thêm hàm load ComboBox

            dgvViPham.AutoGenerateColumns = false;

            // SỬA CỘT
            dgvViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã VP", DataPropertyName = "MaVP", Width = 80 });
            dgvViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 80 });
            dgvViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại VP", DataPropertyName = "MaLoaiVP", Width = 100 });
            dgvViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thời Gian", DataPropertyName = "ThoiGianVP", Width = 150 });
            dgvViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 80 });
            dgvViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mức Phạt", DataPropertyName = "MucPhat", Width = 100 });

            LoadDL();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            ViPhamBUS vpBus = new ViPhamBUS();
            DateTime thoiGianVP;
            bool trangThai;

            if (!ValidateInput(out thoiGianVP, out trangThai)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới Vi phạm này không?", "Xác nhận Thêm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maNV = cbbMaNV.SelectedValue?.ToString();
                    string maLoaiVP = cbbLoaiViPham.SelectedValue?.ToString();

                    bool success = vpBus.AddViPham(maNV, maLoaiVP, thoiGianVP);

                    if (success)
                    {
                        MessageBox.Show("Thêm thành công");
                        LoadDL();
                        ClearInputControls();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi nghiệp vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime thoiGianVP;
            bool trangThai;

            string maVP = txtMaViPham.Text.Trim();
            if (txtMaViPham.ReadOnly == false || string.IsNullOrEmpty(maVP))
            {
                MessageBox.Show("Nút Lưu chỉ dùng để cập nhật. Vui lòng chọn một bản ghi từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện validation
            if (!ValidateInput(out thoiGianVP, out trangThai)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật Vi phạm này không?", "Xác nhận Sửa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maNV = cbbMaNV.SelectedValue?.ToString();
                    string maLoaiVP = cbbLoaiViPham.SelectedValue?.ToString();
                    ViPhamBUS vpBus = new ViPhamBUS();
                    bool success = vpBus.UpdateViPham(maVP, maNV, maLoaiVP, thoiGianVP, trangThai);

                    if (success)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        LoadDL();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại (Mã không tồn tại).");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sửa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvViPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                // Gán dữ liệu lên controls
                txtMaViPham.Text = dgvViPham.Rows[line].Cells[0].Value.ToString();
                cbbMaNV.SelectedValue = dgvViPham.Rows[line].Cells[1].Value;
                cbbLoaiViPham.SelectedValue = dgvViPham.Rows[line].Cells[2].Value;

                // Gán DateTimePicker
                if (dgvViPham.Rows[line].Cells[3].Value != DBNull.Value)
                {
                    dtpThoiGianViPham.Value = Convert.ToDateTime(dgvViPham.Rows[line].Cells[3].Value);
                }

                // KHẮC PHỤC LỖI ÉP KIỂU: Sử dụng Convert.ToBoolean()
                if (dgvViPham.Rows[line].Cells[4].Value != DBNull.Value)
                {
                    // Dùng Convert.ToBoolean() để chuyển đổi chuỗi "True" hoặc "False"
                    cbTrangThai.Checked = Convert.ToBoolean(dgvViPham.Rows[line].Cells[4].Value);
                }

                // Gán Mức phạt
                if (dgvViPham.Rows[line].Cells[5].Value != DBNull.Value && txtMucPhat != null)
                {
                    txtMucPhat.Text = dgvViPham.Rows[line].Cells[5].Value.ToString();
                }

                txtMaViPham.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết lên controls: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maVP = txtMaViPham.Text.Trim();

            if (string.IsNullOrEmpty(maVP))
            {
                MessageBox.Show("Vui lòng chọn Mã Vi phạm cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có muốn xóa Vi phạm có mã: {maVP} không? (Xóa cứng)", "Xác nhận Xóa", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ViPhamBUS vpBus = new ViPhamBUS();
                    bool isDeleted = vpBus.DeleteViPham(maVP);
                    MessageBox.Show(isDeleted ? "Xóa thành công!" : "Xóa thất bại (Có thể do ràng buộc khóa ngoại).");
                    LoadDL();
                    ClearInputControls();
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
        private void btnLoc_Click(object sender, EventArgs e)
        {
            // 1. Lấy Mã NV từ ComboBox (Giả định ComboBox dùng để lọc là cbbMaNV)
            string maNV = cbbTraCuu.SelectedValue?.ToString();

            // 2. Kiểm tra: Nếu không chọn Mã NV, tải lại toàn bộ danh sách
            if (string.IsNullOrEmpty(maNV))
            {
                LoadDL(); // Tải lại toàn bộ
                return;
            }

            try
            {
                ViPhamBUS vpBus = new ViPhamBUS();
                DataTable dtKetQua = vpBus.timViPham(maNV);

                // 4. Hiển thị kết quả
                if (dtKetQua != null && dtKetQua.Rows.Count > 0)
                {
                    dgvViPham.DataSource = dtKetQua;
                    MessageBox.Show($"Tìm thấy {dtKetQua.Rows.Count} kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvViPham.DataSource = null;
                    MessageBox.Show("Không tìm thấy vi phạm nào cho Mã NV này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using BUS;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace he_thong_dien_may
{
    public partial class frmLoaiThuong : Form
    {
        private LoaiThuongBUS ltBus = new LoaiThuongBUS();

        // GIẢ ĐỊNH CONTROLS: txtMaLT, txtLoaiYC, txtYeuCau, txtMucThuong, dgvLoaiThuong

        public frmLoaiThuong()
        {
            InitializeComponent();
        }

        // Hàm kiểm tra ký tự đặc biệt (Giữ nguyên)
        private bool ContainsSpecialChars(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9\s\p{L}]");
        }

        private void ClearInputControls()
        {
            txtMaLT.Text = "";
            txtLoaiYC.Text = "";
            txtYeuCau.Text = "";
            txtMucThuong.Text = "";

            // Đặt ReadOnly = false để KÍCH HOẠT chế độ THÊM MỚI
            txtMaLT.ReadOnly = false;
        }

        // Hàm xác thực dữ liệu đầu vào
        private bool ValidateInput(out int yeuCau, out double mucThuong)
        {
            // Lấy và làm sạch dữ liệu
            string loaiYC = txtLoaiYC.Text.Trim();
            string yeuCauStr = txtYeuCau.Text.Trim();
            string mucThuongStr = txtMucThuong.Text.Trim();

            yeuCau = 0;
            mucThuong = 0.0;

            // Quy tắc 1: Kiểm tra trống
            if (string.IsNullOrEmpty(loaiYC) || string.IsNullOrEmpty(yeuCauStr) || string.IsNullOrEmpty(mucThuongStr))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Loại yêu cầu, Yêu cầu và Mức thưởng.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Quy tắc 2: Kiểm tra ký tự đặc biệt (chỉ kiểm tra LoaiYC)
            if (ContainsSpecialChars(loaiYC))
            {
                MessageBox.Show("Loại yêu cầu không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3. Kiểm tra kiểu dữ liệu
            if (!int.TryParse(yeuCauStr, out yeuCau) || yeuCau < 0)
            {
                MessageBox.Show("Yêu cầu phải là số nguyên không âm.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(mucThuongStr, out mucThuong) || mucThuong < 0)
            {
                MessageBox.Show("Mức thưởng phải là số (>= 0).", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public void LoadDL()
        {
            try
            {
                DataTable dtLoaiThuong = ltBus.GetAllLoaiThuongAsTable();

                if (dtLoaiThuong != null)
                {
                    dgvLoaiThuong.DataSource = dtLoaiThuong;
                    dgvLoaiThuong.ReadOnly = true;
                }
                else
                {
                    dgvLoaiThuong.DataSource = null;
                    MessageBox.Show("Không có dữ liệu Loại Thưởng để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu DataGridView: {ex.Message}", "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLoaiThuong_Load(object sender, EventArgs e)
        {
            dgvLoaiThuong.AutoGenerateColumns = false;

            // Cột phải khớp với LoaiThuongBUS.GetAllLoaiThuongAsTable()
            dgvLoaiThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã LT", DataPropertyName = "MaLT", Width = 80 });
            dgvLoaiThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại Yêu Cầu", DataPropertyName = "LoaiYC", Width = 150 });
            dgvLoaiThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Yêu Cầu", DataPropertyName = "YeuCau", Width = 80 });
            dgvLoaiThuong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mức Thưởng", DataPropertyName = "MucThuong", Width = 150 });

            LoadDL();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            int yeuCau;
            double mucThuong;

            // Thực hiện validation
            if (!ValidateInput(out yeuCau, out mucThuong)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới Loại Thưởng này không?", "Xác nhận Thêm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string loaiYC = txtLoaiYC.Text.Trim();
                    bool success = ltBus.AddLoaiThuong(loaiYC, yeuCau, mucThuong);

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
            int yeuCau;
            double mucThuong;

            string maLT = txtMaLT.Text.Trim();
            if (txtMaLT.ReadOnly == false || string.IsNullOrEmpty(maLT))
            {
                MessageBox.Show("Nút Lưu chỉ dùng để cập nhật. Vui lòng chọn một bản ghi từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện validation
            if (!ValidateInput(out yeuCau, out mucThuong)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật Loại Thưởng này không?", "Xác nhận Sửa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string loaiYC = txtLoaiYC.Text.Trim();
                    bool success = ltBus.UpdateLoaiThuong(maLT, loaiYC, yeuCau, mucThuong);

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

        private void dgvLoaiThuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                // Gán dữ liệu lên controls
                txtMaLT.Text = dgvLoaiThuong.Rows[line].Cells[0].Value.ToString();
                txtLoaiYC.Text = dgvLoaiThuong.Rows[line].Cells[1].Value.ToString();
                txtYeuCau.Text = dgvLoaiThuong.Rows[line].Cells[2].Value.ToString();
                txtMucThuong.Text = dgvLoaiThuong.Rows[line].Cells[3].Value.ToString();

                txtMaLT.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết lên controls: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLT = txtMaLT.Text.Trim();

            if (string.IsNullOrEmpty(maLT))
            {
                MessageBox.Show("Vui lòng chọn Mã Loại Thưởng cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có muốn xóa Loại Thưởng có mã: {maLT} không? (Xóa cứng)", "Xác nhận Xóa", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = ltBus.DeleteLoaiThuong(maLT);
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
    }
}
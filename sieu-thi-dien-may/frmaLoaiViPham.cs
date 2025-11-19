using BUS;
using System;
using System.Data;
using System.Linq; 
using System.Windows.Forms;
using System.Text.RegularExpressions; 

namespace he_thong_dien_may
{
    public partial class frmaLoaiViPham : Form
    {
        private LoaiViPhamBUS lvpBus = new LoaiViPhamBUS();

        public frmaLoaiViPham()
        {
            InitializeComponent();
        }

        private bool ContainsSpecialChars(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9\s\p{L}]");
        }

        private void ClearInputControls()
        {
            txtMaLoaiViPham.Text = "";
            txtMoTaViPham.Text = "";
            txtMucDoViPham.Text = "";
            txtMucPhat.Text = "";

            txtMaLoaiViPham.ReadOnly = false;
        }

        private bool ValidateInput(out int mucDo, out double mucPhat)
        {
            string moTa = txtMoTaViPham.Text.Trim();
            string mucDoStr = txtMucDoViPham.Text.Trim();
            string mucPhatStr = txtMucPhat.Text.Trim();

            mucDo = 0;
            mucPhat = 0.0;

            if (string.IsNullOrEmpty(moTa) || string.IsNullOrEmpty(mucDoStr) || string.IsNullOrEmpty(mucPhatStr))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Mô tả, Mức độ và Mức phạt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ContainsSpecialChars(moTa))
            {
                MessageBox.Show("Mô tả không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ContainsSpecialChars(mucDoStr))
            {
                MessageBox.Show("Mức độ không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ContainsSpecialChars(mucPhatStr))
            {
                MessageBox.Show("Mức phạt không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(mucDoStr, out mucDo) || mucDo < 1 || mucDo > 4)
            {
                MessageBox.Show("Mức độ phải là số nguyên dương.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(mucPhatStr, out mucPhat) || mucPhat < 0)
            {
                MessageBox.Show("Mức phạt phải là số dương.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public void LoadDL()
        {
            try
            {
                DataTable dtLoaiVP = lvpBus.GetAllLoaiViPhamAsTable();

                if (dtLoaiVP != null)
                {
                    dgvLoaiViPham.DataSource = dtLoaiVP;
                    dgvLoaiViPham.ReadOnly = true; 
                }
                else
                {
                    dgvLoaiViPham.DataSource = null;
                    MessageBox.Show("Không có dữ liệu Loại Vi phạm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu DataGridView: {ex.Message}", "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmaLoaiViPham_Load(object sender, EventArgs e)
        {
            dgvLoaiViPham.AutoGenerateColumns = false;

            dgvLoaiViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã LVP", DataPropertyName = "MaLVP", Width = 300 });
            dgvLoaiViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mô Tả Vi Phạm", DataPropertyName = "MoTa", Width = 300 });
            dgvLoaiViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mức Độ", DataPropertyName = "MucDo", Width = 300 });
            dgvLoaiViPham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mức Phạt (VND)", DataPropertyName = "MucPhat", Width = 300 });

            LoadDL();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            int mucDo;
            double mucPhat;

            if (!ValidateInput(out mucDo, out mucPhat)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới Loại Vi phạm này không?", "Xác nhận Thêm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string moTa = txtMoTaViPham.Text.Trim();
                    bool success = lvpBus.AddLoaiViPham(moTa, mucDo, mucPhat);

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
            int mucDo;
            double mucPhat;

            string maLVP = txtMaLoaiViPham.Text.Trim();
            if (txtMaLoaiViPham.ReadOnly == false || string.IsNullOrEmpty(maLVP))
            {
                MessageBox.Show("Nút Lưu chỉ dùng để cập nhật. Vui lòng chọn một bản ghi từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(out mucDo, out mucPhat)) return;

            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật Loại Vi phạm này không?", "Xác nhận Sửa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string moTa = txtMoTaViPham.Text.Trim();
                    bool success = lvpBus.UpdateLoaiViPham(maLVP, moTa, mucDo, mucPhat);

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

        private void dgvLoaiViPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                txtMaLoaiViPham.Text = dgvLoaiViPham.Rows[line].Cells[0].Value.ToString();
                txtMoTaViPham.Text = dgvLoaiViPham.Rows[line].Cells[1].Value.ToString();
                txtMucDoViPham.Text = dgvLoaiViPham.Rows[line].Cells[2].Value.ToString();
                txtMucPhat.Text = dgvLoaiViPham.Rows[line].Cells[3].Value.ToString();

                txtMaLoaiViPham.ReadOnly = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết lên controls: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLVP = txtMaLoaiViPham.Text.Trim();

            if (string.IsNullOrEmpty(maLVP))
            {
                MessageBox.Show("Vui lòng chọn Mã LVP cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có muốn xóa Loại Vi phạm có mã: {maLVP} không? (Xóa cứng)", "Xác nhận Xóa", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = lvpBus.DeleteLoaiViPham(maLVP);

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
            this.Close();
        }
    }
}

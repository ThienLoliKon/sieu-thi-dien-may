using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace he_thong_dien_may
{
    public partial class frmCapBacNhanVien : Form
    {
        public frmCapBacNhanVien()
        {
            InitializeComponent();
        }
        public void LoadDL()
        {
            try
            {
                CapBacNhanVienBUS bus = new CapBacNhanVienBUS();
                DataTable dtdiemdanh = bus.GetAllCapBacNVAsTable();

                if (dtdiemdanh != null)
                {
                    dgvCapBac.DataSource = dtdiemdanh;
                }
                else
                {
                    dgvCapBac.DataSource = null;
                    MessageBox.Show("Không có dữ liệu Cấp Bậc Nhân viên để hiển thị. Vui lòng kiểm tra database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu DataGridView: {ex.Message}", "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvCapBac.AutoGenerateColumns = false;
            dgvCapBac.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã CB", DataPropertyName = "MaCB", Width = 200 });
            dgvCapBac.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên CB", DataPropertyName = "TenCB", Width = 300 });
            dgvCapBac.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mô Tả", DataPropertyName = "MotaCB", Width = 530 });

            LoadDL();
        }
        private bool ContainsSpecialChars(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9\s\p{L}]");
        }

        private void ClearInputControls()
        {
            txtMaCB.Text = "";
            txtCapBac.Text = "";
            txtMoTa.Text = "";

            txtMaCB.ReadOnly = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tencb = txtCapBac.Text.Trim();
            string mota = txtMoTa.Text.Trim();
            if (string.IsNullOrEmpty(tencb) || string.IsNullOrEmpty(mota))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Tên Cấp bậc và Mô tả.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ContainsSpecialChars(tencb) || ContainsSpecialChars(mota))
            {
                MessageBox.Show("Tên Cấp bậc và Mô tả không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CapBacNhanVienBUS bus = new CapBacNhanVienBUS();

                    bool isAdd = bus.AddCapBacNV(tencb, mota);

                    if (isAdd)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công (Mã cấp bậc đã tồn tại).");
                    }
                    LoadDL();
                    ClearInputControls(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi nghiệp vụ khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string macb = txtMaCB.Text.Trim();
            string tencb = txtCapBac.Text.Trim();
            string mota = txtMoTa.Text.Trim();

            if (txtMaCB.ReadOnly == false)
            {
                MessageBox.Show("Nút Lưu chỉ dùng để cập nhật. Vui lòng nhấn Thêm để thực hiện thao tác Thêm mới.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(macb) || string.IsNullOrEmpty(tencb) || string.IsNullOrEmpty(mota))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Mã, Tên Cấp bậc và Mô tả.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ContainsSpecialChars(tencb) || ContainsSpecialChars(mota))
            {
                MessageBox.Show("Tên Cấp bậc và Mô tả không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn sửa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CapBacNhanVienBUS bus = new CapBacNhanVienBUS();

                    bool isupdate = bus.UpdateCapBacNVstring(macb, tencb, mota);

                    if (isupdate)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại (Mã cấp bậc không tồn tại).");
                    }
                    LoadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sửa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCapBac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                txtMaCB.Text = dgvCapBac.Rows[line].Cells[0].Value.ToString();
                txtCapBac.Text = dgvCapBac.Rows[line].Cells[1].Value.ToString();

                txtMoTa.Text = dgvCapBac.Rows[line].Cells[2].Value.ToString();

                txtMaCB.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết lên controls: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCB.Text))
            {
                MessageBox.Show("Vui lòng chọn cấp bậc cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show($"Bạn có muốn xóa cấp bậc có mã: {txtMaCB.Text} không ?", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    CapBacNhanVienBUS bus = new CapBacNhanVienBUS();
                    bool isDeleted = bus.DeleteCapBacNV(txtMaCB.Text);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.");
                    }
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

        private void dgvCapBac_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadDL();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

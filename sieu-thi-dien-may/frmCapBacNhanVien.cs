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
    public partial class frmCapBacNhanVien : Form
    {
        public frmCapBacNhanVien()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void foreverForm1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMaCapBac_TextChanged(object sender, EventArgs e)
        {

        }

        private void foreverLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtCapBac_TextChanged(object sender, EventArgs e)
        {

        }

        private void foreverLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void foreverLabel3_Click(object sender, EventArgs e)
        {

        }

        private void foreverButton1_Click(object sender, EventArgs e)
        {

        }

        private void foreverButton2_Click(object sender, EventArgs e)
        {

        }

        private void foreverButton3_Click(object sender, EventArgs e)
        {

        }

        private void foreverButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
            dgvCapBac.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã CB", DataPropertyName = "MaCB", Width = 100 });
            dgvCapBac.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên CB", DataPropertyName = "TenCB", Width = 200 });
            dgvCapBac.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mô Tả", DataPropertyName = "MotaCB", Width = 100 });

            LoadDL();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Lấy Mã từ SelectedValue
                    string tencb = txtCapBac.Text;
                    string mota =txtMoTa.Text;

                    CapBacNhanVienBUS bus = new CapBacNhanVienBUS();

                    bool isAdd = bus.AddCapBacNV(
                        tencb, mota
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
            if (string.IsNullOrEmpty(txtMaCB.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn sửa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string macb = txtMaCB.Text;
                    string tencb = txtCapBac.Text;
                    string mota = txtMoTa.Text;

                    CapBacNhanVienBUS bus = new CapBacNhanVienBUS();

                    // GỌI PHƯƠNG THỨC CẬP NHẬT (GIẢ ĐỊNH ĐÃ SỬA BUS ĐỂ NHẬN MA NV VÀ CÁC THAM SỐ ĐÚNG)
                    // THỨ TỰ: (maNV, tenNV, macapbac, sdt, diachi, machinhanh, trangthai)
                    bool isupdate = bus.UpdateCapBacNVstring(
                        macb, tencb, mota
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
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // KHẮC PHỤC LỖI CÚ PHÁP MESSAGEBOX
            DialogResult result = MessageBox.Show($"Bạn có muốn xóa nhân viên có mã: {txtMaCB.Text} thành 'Đã Nghỉ' không ?", "Thông báo", MessageBoxButtons.YesNo);

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

        private void dgvCapBac_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadDL();
        }
    }
}

using BUS;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace he_thong_dien_may
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        public void LoadDL()
        {
            try
            {
                NhanVienBUS bus = new NhanVienBUS();
                DataTable dtNhanVien = bus.GetAllNhanVienAsTable();

                if (dtNhanVien != null)
                {
                    dgvNhanVien.DataSource = dtNhanVien;
                }
                else
                {
                    dgvNhanVien.DataSource = null;
                    MessageBox.Show("Không có dữ liệu Nhân viên để hiển thị. Vui lòng kiểm tra database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                CapBacNhanVienBUS cbBus = new CapBacNhanVienBUS();
                DataTable dtCapBac = cbBus.GetAllCapBacNVAsTable(); 
                cbbCapBac.DataSource = dtCapBac;
                cbbCapBac.DisplayMember = "TenCB"; 
                cbbCapBac.ValueMember = "MaCB";    
                cbbCapBac.SelectedIndex = -1;      

                ChiNhanhBUS cnBus = new ChiNhanhBUS();
                DataTable dtChiNhanh = cnBus.GetAllChiNhanhAsTable();
                cbbChiNhanh.DataSource = dtChiNhanh;
                cbbChiNhanh.DisplayMember = "TenCN"; 
                cbbChiNhanh.ValueMember = "MaCN";    
                cbbChiNhanh.SelectedIndex = -1;      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ComboBox: " + ex.Message + "\nVui lòng kiểm tra kết nối database.", "Lỗi Load Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();

            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 200 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên NV", DataPropertyName = "TenNV", Width = 235 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã CB", DataPropertyName = "MaCB", Width = 200 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SDT", DataPropertyName = "SDT", Width = 200 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa Chỉ", DataPropertyName = "DiaChi", Width = 250 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã CN", DataPropertyName = "MaChiNhanh", Width = 200 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 200 });

            LoadDL();
        }

        private bool ContainsSpecialChars(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9\s\p{L}]");
        }
        private void ClearInputControls()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTimKiem.Text = "";
            cbbCapBac.SelectedIndex = -1;
            cbbChiNhanh.SelectedIndex = -1;

            txtMaNV.ReadOnly = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenNV = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();

            string maCapBac = cbbCapBac.SelectedValue?.ToString();
            string maChiNhanh = cbbChiNhanh.SelectedValue?.ToString();
            string trangthai = "true"; 

            if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(maCapBac) ||
                string.IsNullOrEmpty(maChiNhanh) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Họ và Tên, SĐT, Địa chỉ, Cấp bậc và Chi nhánh.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ContainsSpecialChars(tenNV))
            {
                MessageBox.Show("Họ và Tên không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ContainsSpecialChars(diachi))
            {
                MessageBox.Show("Địa chỉ không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!sdt.All(char.IsDigit) || sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải là chuỗi số có 10 số.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    NhanVienBUS bus = new NhanVienBUS();

                    bool isAdd = bus.AddNhanVien(
                        tenNV, maCapBac, sdt, diachi, maChiNhanh, trangthai
                    );

                    if (isAdd)
                    {
                        MessageBox.Show("Thêm nhân viên thành công.");
                        ClearInputControls();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại. (Có thể do lỗi database hoặc trùng khóa).");
                    }
                    LoadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi nghiệp vụ khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();

            string maCapBac = cbbCapBac.SelectedValue?.ToString();
            string maChiNhanh = cbbChiNhanh.SelectedValue?.ToString();
            string trangthai = "true";

            if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(maCapBac) ||
                string.IsNullOrEmpty(maChiNhanh) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Họ và Tên, SĐT, Địa chỉ, Cấp bậc và Chi nhánh.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ContainsSpecialChars(tenNV))
            {
                MessageBox.Show("Họ và Tên không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ContainsSpecialChars(diachi))
            {
                MessageBox.Show("Địa chỉ không được chứa ký tự đặc biệt.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!sdt.All(char.IsDigit) || sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải là chuỗi số có 10 số.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    NhanVienBUS bus = new NhanVienBUS();

                    bool isdelete = bus.UpdateNhanVienstring(
                        maNV ,tenNV, maCapBac, sdt, diachi, maChiNhanh, trangthai
                    );

                    if (isdelete)
                    {
                        MessageBox.Show("Xóa nhân viên thành công.");
                        ClearInputControls();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại. (Có thể do lỗi database hoặc trùng khóa).");
                    }
                    LoadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi nghiệp vụ khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                txtMaNV.Text = dgvNhanVien.Rows[line].Cells[0].Value.ToString();
                txtHoTen.Text = dgvNhanVien.Rows[line].Cells[1].Value.ToString();
                
                cbbCapBac.SelectedValue = dgvNhanVien.Rows[line].Cells[2].Value; 
                cbbChiNhanh.SelectedValue = dgvNhanVien.Rows[line].Cells[5].Value; 

                txtSDT.Text = dgvNhanVien.Rows[line].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[line].Cells[4].Value.ToString();
                cbTrangThai.Text = dgvNhanVien.Rows[line].Cells[6].Value.ToString(); 
                
                txtMaNV.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết lên controls: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show($"Bạn có muốn cho nhân viên có mã: {txtMaNV.Text} Nghỉ việc không ?", "Thông báo", MessageBoxButtons.YesNo);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    NhanVienBUS bus = new NhanVienBUS();
                    bool isDeleted = bus.DeleteNhanVien(txtMaNV.Text); 

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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadDL(); 
                return;
            }

            try
            {
                NhanVienBUS bus = new NhanVienBUS();

                DataTable dtKetQua = bus.timNhanVien(keyword);

                if (dtKetQua != null && dtKetQua.Rows.Count > 0)
                {
                    dgvNhanVien.DataSource = dtKetQua;
                    MessageBox.Show($"Tìm thấy {dtKetQua.Rows.Count} kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvNhanVien.DataSource = null; 
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp với từ khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadComboBoxData();
            LoadDL();
        }
        private string GetSelectedMaNV()
        {
            if (dgvNhanVien.CurrentRow != null && dgvNhanVien.CurrentRow.Index >= 0)
            {
                return dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            }
            return null;
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            string maNV = GetSelectedMaNV();
            if (string.IsNullOrEmpty(maNV)) return;

            frmLuong f = new frmLuong(maNV);
            f.ShowDialog();
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            string maNV = GetSelectedMaNV();
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần tạo tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTaiKhoan f = new frmTaiKhoan(maNV); // Truyền mã NV sang
            f.ShowDialog();
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            string maNV = GetSelectedMaNV();
            if (string.IsNullOrEmpty(maNV)) return; // Hoặc báo lỗi tùy ý

            frmDiemDanh f = new frmDiemDanh(maNV);
            f.ShowDialog();
        }

        private void btnThuong_Click(object sender, EventArgs e)
        {
            string maNV = GetSelectedMaNV();
            if (string.IsNullOrEmpty(maNV)) return;

            frmThuong f = new frmThuong(maNV);
            f.ShowDialog();
        }

        private void btnViPham_Click(object sender, EventArgs e)
        {
            string maNV = GetSelectedMaNV();
            if (string.IsNullOrEmpty(maNV)) return;

            frmViPham f = new frmViPham(maNV);
            f.ShowDialog();
        }
    }
}
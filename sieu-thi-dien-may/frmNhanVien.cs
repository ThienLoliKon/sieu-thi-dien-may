using BUS;
using System;
using System.Data;
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
                // 1. Load Cấp Bậc (Sử dụng tên BUS/DLL bạn cung cấp)
                CapBacNhanVienBUS cbBus = new CapBacNhanVienBUS();
                DataTable dtCapBac = cbBus.GetAllCapBacNVAsTable(); 
                cbbCapBac.DataSource = dtCapBac;
                cbbCapBac.DisplayMember = "TenCB"; 
                cbbCapBac.ValueMember = "MaCB";    
                cbbCapBac.SelectedIndex = -1;      

                // 2. Load Chi Nhánh
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
            // KHẮC PHỤC: Load ComboBox trước để dữ liệu có sẵn cho các thao tác khác
            LoadComboBoxData();

            // Cài đặt DataGridView Columns (GIỮ NGUYÊN)
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 100 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên NV", DataPropertyName = "TenNV", Width = 200 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã CB", DataPropertyName = "MaCB", Width = 100 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SDT", DataPropertyName = "SDT", Width = 100 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa Chỉ", DataPropertyName = "DiaChi", Width = 100 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã CN", DataPropertyName = "MaChiNhanh", Width = 100 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 100 });

            // Load Dữ liệu DataGridView sau
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
                    string tenNV = txtHoTen.Text;
                    string maCapBac = cbbCapBac.SelectedValue?.ToString();
                    string maChiNhanh = cbbChiNhanh.SelectedValue?.ToString();
                    string sdt = txtSDT.Text;
                    string diachi = txtDiaChi.Text;
                    string trangthai = cbTrangThai.Text; // Lấy giá trị trạng thái

                    NhanVienBUS bus = new NhanVienBUS();

                    // THỨ TỰ ĐÚNG CỦA BUS: (tenNV, macapbac, sdt, diachi, machinhanh, trangthai)
                    bool isAdd = bus.AddNhanVien(
                        tenNV, maCapBac, sdt, diachi, maChiNhanh, trangthai
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
            if (string.IsNullOrEmpty(txtMaNV.Text))
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
                    string maNV = txtMaNV.Text;
                    string tenNV = txtHoTen.Text;
                    string maCapBac = cbbCapBac.SelectedValue?.ToString();
                    string sdt = txtSDT.Text;
                    string diachi = txtDiaChi.Text;
                    string maChiNhanh = cbbChiNhanh.SelectedValue?.ToString(); // Đảm bảo luôn là mã ngắn gọn (char(10))
                    string trangthai = cbTrangThai.Text;

                    NhanVienBUS bus = new NhanVienBUS();

                    // GỌI PHƯƠNG THỨC CẬP NHẬT (GIẢ ĐỊNH ĐÃ SỬA BUS ĐỂ NHẬN MA NV VÀ CÁC THAM SỐ ĐÚNG)
                    // THỨ TỰ: (maNV, tenNV, macapbac, sdt, diachi, machinhanh, trangthai)
                    bool isupdate = bus.UpdateNhanVienstring(
                        maNV, tenNV, maCapBac, sdt, diachi, maChiNhanh, trangthai
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                txtMaNV.Text = dgvNhanVien.Rows[line].Cells[0].Value.ToString();
                txtHoTen.Text = dgvNhanVien.Rows[line].Cells[1].Value.ToString();
                
                // GÁN MÃ ĐỂ COMBOBOX TỰ ĐỘNG CHỌN ĐÚNG MỤC
                cbbCapBac.SelectedValue = dgvNhanVien.Rows[line].Cells[2].Value; // MaCB
                cbbChiNhanh.SelectedValue = dgvNhanVien.Rows[line].Cells[5].Value; // MaChiNhanh

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
            // KHẮC PHỤC LỖI CÚ PHÁP MESSAGEBOX
            DialogResult result = MessageBox.Show($"Bạn có muốn chuyển trạng thái nhân viên có mã: {txtMaNV.Text} thành 'Đã Nghỉ' không ?", "Thông báo", MessageBoxButtons.YesNo);
            
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
            // 1. Lấy từ khóa tìm kiếm
            string keyword = txtTimKiem.Text.Trim();

            // 2. Kiểm tra từ khóa: Nếu trống, tải lại toàn bộ danh sách
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDL(); // LoadDL() gọi GetAllNhanVienAsTable()
                return;
            }

            try
            {
                NhanVienBUS bus = new NhanVienBUS();

                // 3. Gọi phương thức tìm kiếm từ BUS
                DataTable dtKetQua = bus.timNhanVien(keyword);

                // 4. Hiển thị kết quả
                if (dtKetQua != null && dtKetQua.Rows.Count > 0)
                {
                    dgvNhanVien.DataSource = dtKetQua;
                    MessageBox.Show($"Tìm thấy {dtKetQua.Rows.Count} kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvNhanVien.DataSource = null; // Xóa dữ liệu cũ trên Grid
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
        // ... (Các hàm khác giữ nguyên)
    }
}
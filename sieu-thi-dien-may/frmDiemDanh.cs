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
    public partial class frmDiemDanh : Form
    {
        public frmDiemDanh()
        {
            InitializeComponent();
        }

        private void foreverButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadDL()
        {
            try
            {
                DiemDanhBUS bus = new DiemDanhBUS();
                DataTable dtNhanVien = bus.GetAllDiemDanhAsTable();

                if (dtNhanVien != null)
                {
                    dgvDiemDanh.DataSource = dtNhanVien;
                }
                else
                {
                    dgvDiemDanh.DataSource = null;
                    MessageBox.Show("Không có dữ liệu Điểm danh để hiển thị. Vui lòng kiểm tra database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                NhanVienBUS cbBus = new NhanVienBUS();
                DataTable dtCapBac = cbBus.GetAllNhanVienAsTable();
                cbbMaNV.DataSource = dtCapBac;
                cbbMaNV.DisplayMember = "MaNV";
                cbbMaNV.ValueMember = "MaNV";
                cbbMaNV.SelectedIndex = -1;
                NhanVienBUS bus = new NhanVienBUS();
                DataTable dtdiemdanh = bus.GetAllNhanVienAsTable();
                cbbTraCuu.DataSource = dtdiemdanh;
                cbbTraCuu.DisplayMember = "MaNV";
                cbbTraCuu.ValueMember = "MaNV";
                cbbTraCuu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ComboBox: " + ex.Message + "\nVui lòng kiểm tra kết nối database.", "Lỗi Load Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime tgVaoValue = dtpThoiGianVao.Value;
            DateTime tgRaValue = dtpThoiGianRa.Value;

            if (tgRaValue < tgVaoValue)
            {
                MessageBox.Show("Thời gian RA không được sớm hơn thời gian VÀO.", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maNV = cbbMaNV.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn Mã Nhân viên.", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string tgVao = tgVaoValue.ToString();
                    string tgRa = tgRaValue.ToString();

                    DiemDanhBUS ddBus = new DiemDanhBUS();

                    bool isAdd = ddBus.AddDiemDanh(maNV, tgVao, tgRa);

                    if (isAdd)
                    {
                        MessageBox.Show("Thêm Điểm danh thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm Điểm danh không thành công.");
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
            DateTime tgVaoValue = dtpThoiGianVao.Value;
            DateTime tgRaValue = dtpThoiGianRa.Value;

            if (string.IsNullOrEmpty(txtMaDiemDanh.Text))
            {
                MessageBox.Show("Vui lòng chọn bản ghi điểm danh cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tgRaValue < tgVaoValue)
            {
                MessageBox.Show("Thời gian RA không được sớm hơn thời gian VÀO.", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn sửa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maDiemDanh = txtMaDiemDanh.Text;
                    string maNV = cbbMaNV.SelectedValue?.ToString();
                    string tgVao = tgVaoValue.ToString();
                    string tgRa = tgRaValue.ToString();

                    DiemDanhBUS ddBus = new DiemDanhBUS();

                    bool isupdate = ddBus.UpdateDiemDanhstring(maDiemDanh, maNV, tgVao, tgRa);

                    if (isupdate)
                    {
                        MessageBox.Show("Sửa Điểm danh thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa Điểm danh thất bại");
                    }
                    LoadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sửa dữ liệu Điểm danh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDiemDanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int line = e.RowIndex;

                txtMaDiemDanh.Text = dgvDiemDanh.Rows[line].Cells[0].Value.ToString();
                cbbMaNV.SelectedValue = dgvDiemDanh.Rows[line].Cells[1].Value;
                if (dgvDiemDanh.Rows[line].Cells[2].Value != DBNull.Value)
                {
                    dtpThoiGianVao.Value = Convert.ToDateTime(dgvDiemDanh.Rows[line].Cells[2].Value);
                }
                if (dgvDiemDanh.Rows[line].Cells[3].Value != DBNull.Value)
                {
                    dtpThoiGianRa.Value = Convert.ToDateTime(dgvDiemDanh.Rows[line].Cells[3].Value);
                }
                txtMaDiemDanh.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết lên controls: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDiemDanh.Text))
            {
                MessageBox.Show("Vui lòng chọn ngày điểm danh cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show($"Bạn có muốn xóa ngày điểm danh có mã: {txtMaDiemDanh.Text} không?", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DiemDanhBUS bus = new DiemDanhBUS();
                    bool isDeleted = bus.DeleteDiemDanh(txtMaDiemDanh.Text);

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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNVTimKiem = cbbTraCuu.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maNVTimKiem))
            {
                LoadDL();
                return;
            }

            try
            {
                DiemDanhBUS bus = new DiemDanhBUS();

                DataTable dtKetQua = bus.TimDiemDanhTheoTieuChi(maNVTimKiem);
                if (dtKetQua != null && dtKetQua.Rows.Count > 0)
                {
                    dgvDiemDanh.DataSource = dtKetQua;
                    MessageBox.Show($"Tìm thấy {dtKetQua.Rows.Count} kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvDiemDanh.DataSource = null;
                    MessageBox.Show("Không tìm thấy bản ghi điểm danh nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmDiemDanh_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();

            dgvDiemDanh.AutoGenerateColumns = false;
            dgvDiemDanh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Điểm Danh", DataPropertyName = "MaDiemDanh", Width = 200 });
            dgvDiemDanh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 200 });
            dgvDiemDanh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thời Gian Vào", DataPropertyName = "ThoiGianVao", Width = 200 });
            dgvDiemDanh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thời Gian Ra", DataPropertyName = "ThoiGianRa", Width = 200 });

            LoadDL();
        }

        private void foreverForm1_Click(object sender, EventArgs e)
        {

        }
    }
}

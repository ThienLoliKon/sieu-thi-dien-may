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
    public partial class PhieuXuatKho : Form
    {
        XuatKhoBUS xuatkhobus = new XuatKhoBUS();
        public string mkho;
        public string machinhanh;
        public PhieuXuatKho(string makho)
        {
            InitializeComponent();
            this.mkho = makho;
        }

        private void RTKhachHangForm_Click(object sender, EventArgs e)
        {

        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {

        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {

        }

        private void cyberButton4_Click_1(object sender, EventArgs e)
        {
            dgvPhieuXuatKho.DataSource = xuatkhobus.searchXuatKhoTheoKho(this.mkho);
            txtSoLuong.TextButton = "";
            txtChiNhanh.TextButton = "";
            txtMaPhieu.TextButton = "";
        }

        public bool validAllFields()
        {
            if (!CheckTestCase.checkLenghtChuoi(txtMaPhieu.TextButton, 10))
            {
                MessageBox.Show("Mã phiếu không được vượt quá 10 ký tự!");return false;
            }
            if(!CheckTestCase.checkKhoangTrang(txtSoLuong.TextButton, txtChiNhanh.TextButton))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");return false;
            }
            if (!CheckTestCase.checkChiChuaSo(txtSoLuong.TextButton))
            {
                MessageBox.Show("Số lượng phải nhập bằng số!");return false;
            }
            if (!CheckTestCase.checkLenghtChuoi(txtChiNhanh.TextButton, 10))
            {
                MessageBox.Show("Chi nhánh chỉ được nhập tối đa 10 kí tự!");return false;
            }
            return true;
        }
        private void cyberButton1_Click_1(object sender, EventArgs e)
        {
            if(validAllFields() == false)
            {
                return;
            }
            try
            {
                xuatkhobus.addXuatKho(createXuatKhoItem());
                SanPhamTrongKhoTongBUS ktbus = new SanPhamTrongKhoTongBUS();
                SanPhamTrongChiNhanhBUS spcnbus = new SanPhamTrongChiNhanhBUS();
                ktbus.updateSoLuongNhapKho(this.mkho, cbxSanPham.SelectedValue.ToString(), -int.Parse(txtSoLuong.TextButton));
                spcnbus.updateSoLuongXuatKho(this.machinhanh, cbxSanPham.SelectedValue.ToString(), int.Parse(txtSoLuong.TextButton));
                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu xuất kho: " + ex.Message);
            }
        }
        private XuatKhoBUS.XuatKho createXuatKhoItem()
        {
            XuatKhoBUS.XuatKho xk = new XuatKhoBUS.XuatKho();
            xk.makho = this.mkho;
            xk.masanpham = cbxSanPham.SelectedValue.ToString();
            xk.manhanviennhapkho = txtNhanVien.TextButton;
            xk.soluong = int.Parse(txtSoLuong.TextButton);
            xk.machinhanh = this.machinhanh;
            xk.maphieu = dgvPhieuXuatKho.SelectedRows[0].Cells[0].Value.ToString();
            return xk;
        }

        private void cyberButton5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.TextButton == "")
            {
                dgvPhieuXuatKho.DataSource = xuatkhobus.searchXuatKhoTheoKho(this.mkho);
            }
            else
            {
                dgvPhieuXuatKho.DataSource = xuatkhobus.searchXuatKho(txtMaPhieu.TextButton, this.mkho);
            }
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            if(validAllFields() == false)
            {
                return;
            }
            xuatkhobus.updateXuatKho(createXuatKhoItem());
            int chenhlechsoluong = int.Parse(txtSoLuong.TextButton) - int.Parse(dgvPhieuXuatKho.SelectedRows[0].Cells[4].Value.ToString());
            SanPhamTrongKhoTongBUS ktbus = new SanPhamTrongKhoTongBUS();
            SanPhamTrongChiNhanhBUS spcnbus = new SanPhamTrongChiNhanhBUS();
            ktbus.updateSoLuongNhapKho(this.mkho, cbxSanPham.SelectedValue.ToString(), chenhlechsoluong);
            spcnbus.updateSoLuongXuatKho(this.machinhanh, cbxSanPham.SelectedValue.ToString(), -chenhlechsoluong);
            MessageBox.Show("Thay đổi đã được lưu!");
        }

        private void PhieuXuatKho_Load(object sender, EventArgs e)
        {
            KhoTongBUS khotongbus = new KhoTongBUS();
            txtKho.TextButton = khotongbus.searchKhoTong(this.mkho).tenkho;
            txtNhanVien.TextButton = TaiKhoanBUS.currentUserMaNV;
            SanPhamBUS sanphambus = new SanPhamBUS();
            cbxSanPham.DataSource = sanphambus.GetAllSanPhamAsTable();
            cbxSanPham.DisplayMember = "ten_san_pham";
            cbxSanPham.ValueMember = "ma_san_pham";
            dgvPhieuXuatKho.DataSource = xuatkhobus.searchXuatKhoTheoKho(this.mkho);
        }

        private void txtChiNhanh_Enter(object sender, EventArgs e)
        {
            txtChiNhanh.TextButton = "";
        }

        private void txtChiNhanh_Leave(object sender, EventArgs e)
        {
            ChiNhanhBUS chinhanhbus = new ChiNhanhBUS();
            var chinhanh = chinhanhbus.searchChiNhanh(txtChiNhanh.TextButton);
            if (chinhanh.Count > 0)
            {
                this.machinhanh = chinhanh[0].machinhanh;
                txtChiNhanh.TextButton = chinhanh[0].tenchinhanh;
            }
            else
            {
                MessageBox.Show("Chi nhánh không tồn tại!");
                txtChiNhanh.TextButton = "";
            }
        }

        private void dgvPhieuXuatKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiNhanhBUS chinhanhbus = new ChiNhanhBUS();
            string macnselected = dgvPhieuXuatKho.SelectedRows[0].Cells[5].Value.ToString();
            var chinhanh = chinhanhbus.searchChiNhanh(macnselected);
            if (chinhanh.Count > 0)
            {
                this.machinhanh = chinhanh[0].machinhanh;
                txtChiNhanh.TextButton = chinhanh[0].tenchinhanh;
            }
            txtSoLuong.TextButton = dgvPhieuXuatKho.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}

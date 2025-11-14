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
            dgvPhieuXuatKho.DataSource =  xuatkhobus.searchXuatKhoTheoKho(this.mkho);
        }

        private void cyberButton1_Click_1(object sender, EventArgs e)
        {
            xuatkhobus.addXuatKho(createXuatKhoItem());
            SanPhamTrongKhoTongBUS ktbus = new SanPhamTrongKhoTongBUS();
            SanPhamTrongChiNhanhBUS spcnbus = new SanPhamTrongChiNhanhBUS();
            ktbus.updateSoLuongNhapKho(txtKho.TextButton, cbxSanPham.SelectedValue.ToString(), -int.Parse(txtSoLuong.Text));
            spcnbus.updateSoLuongXuatKho(txtChiNhanh.TextButton, cbxSanPham.SelectedValue.ToString(), int.Parse(txtSoLuong.Text));
        }
        private XuatKhoBUS.XuatKho createXuatKhoItem()
        {
            XuatKhoBUS.XuatKho xk = new XuatKhoBUS.XuatKho();
            xk.makho = txtKho.TextButton;
            xk.masanpham = cbxSanPham.SelectedValue.ToString();
            xk.manhanviennhapkho = txtNhanVien.ToString();
            xk.soluong = int.Parse(txtSoLuong.TextButton);
            xk.machinhanh = txtChiNhanh.TextButton;
            xk.maphieu = txtMaPhieu.TextButton;
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
                dgvPhieuXuatKho.DataSource = xuatkhobus.searchXuatKhoTheoKho(txtKho.TextButton);
            }else
            {
                dgvPhieuXuatKho.DataSource = xuatkhobus.searchXuatKho(txtMaPhieu.TextButton, txtKho.TextButton);
            }
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            xuatkhobus.updateXuatKho(createXuatKhoItem());
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
        }
    }
}

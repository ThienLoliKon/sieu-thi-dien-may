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
        public PhieuXuatKho()
        {
            InitializeComponent();
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
            dgvPhieuXuatKho.DataSource =  xuatkhobus.getAllXuatKho();
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
            xk.soluong = int.Parse(txtSoLuong.Text);
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
            dgvPhieuXuatKho.DataSource = xuatkhobus.searchXuatKho(txtMaPhieu.Text);
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            xuatkhobus.updateXuatKho(createXuatKhoItem());
        }
    }
}

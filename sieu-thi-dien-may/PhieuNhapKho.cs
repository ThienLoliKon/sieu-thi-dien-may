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
    public partial class PhieuNhapKho : Form
    {
        NhapKhoBUS nhapkhobus = new NhapKhoBUS();
        string makho;
        public PhieuNhapKho(string makho = "")
        {
            InitializeComponent();
            this.makho = makho;
        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {
            dgvPhieuNhapKho.DataSource = nhapkhobus.searchNhapKho(txtMaPhieu.TextButton);
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            var item = createPhieuNhapItem();
            nhapkhobus.addKhoTong(item);
            SanPhamTrongKhoTongBUS spktbus = new SanPhamTrongKhoTongBUS();
            spktbus.updateSoLuongNhapKho(item.makho, item.masanpham, item.soluong);
        }
        private NhapKhoBUS.NhapKho createPhieuNhapItem()
        {
            NhapKhoBUS.NhapKho nhapkho = new NhapKhoBUS.NhapKho();
            nhapkho.manhanviennhapkho = txtNhanVien.TextButton;
            //nhapkho.masanpham = txtSanPham.TextButton;
            nhapkho.masanpham = cbxSanPham.SelectedValue.ToString();
            nhapkho.makho = txtKho.TextButton;
            nhapkho.soluong = int.Parse(txtSoLuong.Text);
            nhapkho.dongia = decimal.Parse(txtDonGia.Text);
            return nhapkho;
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            var nhapkho = createPhieuNhapItem();
            if(nhapkho.soluong < int.Parse(dgvPhieuNhapKho.SelectedRows[0].Cells[3].Value.ToString()))
            {
                MessageBox.Show("Số lượng nhập không thể nhỏ hơn số lượng đã nhập trước đó.");
                return;
            }
            nhapkhobus.updateNhapKho(nhapkho);
        }

        private void txtNhanVien_Leave(object sender, EventArgs e)
        {
        }

        private void cyberButton6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TaiKhoanBUS.currentUserMaNV);
        }

        private void PhieuNhapKho_Load(object sender, EventArgs e)
        {
            //lblHeader.Text = "Phiếu Nhập Kho - " + makho;
            KhoTongBUS khotongbus = new KhoTongBUS();
            txtKho.TextButton = khotongbus.searchKhoTong(this.makho).tenkho;
            txtNhanVien.TextButton = TaiKhoanBUS.currentUserMaNV;
            SanPhamBUS sanphambus = new SanPhamBUS();
            cbxSanPham.DataSource = sanphambus.GetAllSanPhamAsTable();
            cbxSanPham.DisplayMember = "ten_san_pham";
            cbxSanPham.ValueMember = "ma_san_pham";
        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {
            dgvPhieuNhapKho.DataSource = nhapkhobus.getAllNhapKho();
        }
    }
}

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
        public string mkho;
        public PhieuNhapKho(string makho)
        {
            InitializeComponent();
            this.mkho = makho;
        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.TextButton.Length <= 0)
            {
                dgvPhieuNhapKho.DataSource = nhapkhobus.searchNhapKhoTheoKho(this.mkho);
            }
            else
            {
                dgvPhieuNhapKho.DataSource = nhapkhobus.searchNhapKho(txtMaPhieu.TextButton, this.mkho);
            }
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            var item = createPhieuNhapItem();
            nhapkhobus.addPhieuNhap(item);
            SanPhamTrongKhoTongBUS spktbus = new SanPhamTrongKhoTongBUS();
            spktbus.updateSoLuongNhapKho(item.makho, item.masanpham, item.soluong);
        }
        private NhapKhoBUS.NhapKho createPhieuNhapItem()
        {
            NhapKhoBUS.NhapKho nhapkho = new NhapKhoBUS.NhapKho();
            nhapkho.maphieu = txtMaPhieu.TextButton;
            nhapkho.manhanviennhapkho = txtNhanVien.TextButton;
            //nhapkho.masanpham = txtSanPham.TextButton;
            nhapkho.masanpham = cbxSanPham.SelectedValue.ToString();
            nhapkho.makho = this.mkho;
            nhapkho.soluong = int.Parse(txtSoLuong.TextButton);
            nhapkho.dongia = decimal.Parse(txtDonGia.TextButton);
            return nhapkho;
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            if(dgvPhieuNhapKho.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập kho cần sửa!");
                return;
            }
            var nhapkho = createPhieuNhapItem();
            nhapkho.maphieu = dgvPhieuNhapKho.SelectedRows[0].Cells[0].Value.ToString();
            int chenhlechsoluong = 0;
            //nhapkho.soluong = int.Parse(dgvPhieuNhapKho.SelectedRows[0].Cells[4].Value.ToString());
            if (nhapkho.soluong < int.Parse(dgvPhieuNhapKho.SelectedRows[0].Cells[4].Value.ToString()))
            {
                //MessageBox.Show("Số lượng nhập kho không được nhỏ hơn số lượng hiện có!");
                chenhlechsoluong = nhapkho.soluong - int.Parse(dgvPhieuNhapKho.SelectedRows[0].Cells[4].Value.ToString());
                //MessageBox.Show(nhapkho.soluong.ToString());return;
            }
            nhapkhobus.updateNhapKho(nhapkho);
            SanPhamTrongKhoTongBUS spktbus = new SanPhamTrongKhoTongBUS();
            spktbus.updateSoLuongNhapKho(nhapkho.makho, nhapkho.masanpham, chenhlechsoluong);
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
            //MessageBox.Show(this.mkho);
            KhoTongBUS khotongbus = new KhoTongBUS();
            txtKho.TextButton = khotongbus.searchKhoTong(this.mkho).tenkho;
            txtNhanVien.TextButton = TaiKhoanBUS.currentUserMaNV;
            SanPhamBUS sanphambus = new SanPhamBUS();
            cbxSanPham.DataSource = sanphambus.GetAllSanPhamAsTable();
            cbxSanPham.DisplayMember = "ten_san_pham";
            cbxSanPham.ValueMember = "ma_san_pham";
        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.TextButton == "")
            {
                dgvPhieuNhapKho.DataSource = nhapkhobus.searchNhapKhoTheoKho(this.mkho);
            }else
            {
                dgvPhieuNhapKho.DataSource = nhapkhobus.searchNhapKho(txtMaPhieu.TextButton, this.mkho);
            }
        }

        private void dgvPhieuNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhieu.TextButton = dgvPhieuNhapKho.SelectedRows[0].Cells[0].Value.ToString();
            txtSoLuong.TextButton = dgvPhieuNhapKho.SelectedRows[0].Cells[4].Value.ToString();
            txtDonGia.TextButton = dgvPhieuNhapKho.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}

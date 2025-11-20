using BUS;
using CrystalDecisions.CrystalReports.Engine;
using stdm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace he_thong_dien_may
{
	public partial class frmMainMenu : Form
	{
		public frmMainMenu()
		{
			InitializeComponent();
		}

		private void a_Load(object sender, EventArgs e)
		{
			// if(TaiKhoanBUS.currentUserMaNV)
			//	Form childForm = new frmSanPham();
			//	childForm.MdiParent = this;
			//	childForm.Show();
			//Form childForm = new frmSanPham();
			//	
			phanQuyenHienThi();
		}

		private void sanPhamToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form childForm = new frmSanPham();
			childForm.ShowDialog();
		}

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form fhoadon = new frmHoaDon();
            fhoadon.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form fsanpham = new frmSanPham();
            fsanpham.ShowDialog();
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form fkhuyenmai = new frmKhuyenMai();
            fkhuyenmai.ShowDialog();
        }

        private void chiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form chinhanh = new ChiNhanh();
            chinhanh.ShowDialog();
        }

        private void loạiViPhạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form loaivipham = new frmaLoaiViPham();
            loaivipham.ShowDialog();
        }

        private void bảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmBaoHanh();
            f.ShowDialog();
        }

        private void cấpBậcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmCapBacNhanVien();
            f.ShowDialog();
        }

        private void điểmDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmDiemDanh();
            f.ShowDialog();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmLoaiHang();
            f.ShowDialog();
        }

        private void loạiThươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmLoaiThuong();
            f.ShowDialog();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmLuong();
            f.ShowDialog();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmNhaCungCap();
            f.ShowDialog();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new frmNhanVien();
            f.ShowDialog();
        }

        private void nSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmNhaSanXuat();
            f.ShowDialog();
        }

        private void sảnPhẩmLoạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmSanPhamLoaiHang();
            f.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmTaiKhoan();
            f.ShowDialog();
        }

        private void viPhạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmViPham();
            f.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new KhachHang();
            f.ShowDialog();
        }

        private void thưởngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmThuong();
            f.ShowDialog();
        }

        private void khoTổngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new KhoTong();
            f.ShowDialog();
        }

        private void khuVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new KhuVuc();
            f.ShowDialog();
        }

        private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new PhieuXuatKho("");
            f.ShowDialog();
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new PhieuNhapKho("0");
            f.ShowDialog();
        }

        private void sảnPhẩmTrongKhoTổngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sảnPhẩmTrongChiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void xếpHạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new XepHang();
            f.ShowDialog();
        }

        private void khuyếnMãiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void doanhThuSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void doanhThuTheoThờiGianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

		private void crownMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
		{
            Form f = new Login();
            f.Show();
            this.Hide();
		}

		private void khuyếnMãiToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Form f = new frmKhuyenMai();
			f.ShowDialog();
		}

		private void tsmiSPThinhHanhTheoKhuVic_Click(object sender, EventArgs e)
		{
			frmReportSanPhamBanChay f = new frmReportSanPhamBanChay();
			f.ShowDialog();
		}

		private void tsmiDoanhThuCacChiNhanh_Click(object sender, EventArgs e)
		{
			frmReportDoanhThuChiNhanh f = new frmReportDoanhThuChiNhanh();
			f.ShowDialog();
		}


		private void phanQuyenHienThi()
		{
			// Mặc định: Ẩn hết các menu quan trọng trước cho an toàn
            tsQuanLyChiNhanh.Visible = false;
            tsQuanLyKhuVuc.Visible = false;
            tsBoPhanSanPham.Visible = false;
            tsGiamDoc.Visible = false;
            tsBaoCao.Visible = false;

			// Bật lại theo từng quyền
			switch (TaiKhoanBUS.currentUserQuyen)
			{
				case "CB10000001": // Nhân viên

					break;

				case "CB10000002": // Quản lý Chi nhánh
                    tsQuanLyChiNhanh.Visible = true;
					break;

				case "CB10000003": // Quản lý Khu vực
					tsQuanLyChiNhanh.Visible = true;
					tsQuanLyKhuVuc.Visible = true;
                    tsBaoCao.Visible = true;
					break;

				case "CB10000004": // Bộ phận Sản phẩm
                    tsBoPhanSanPham.Visible = true;
					break;

				case "CB10000005": // Giám đốc (Full quyền)
                    tsQuanLyChiNhanh.Visible = true;
                    tsQuanLyKhuVuc.Visible = true;
                    tsBoPhanSanPham.Visible = true;
                    tsGiamDoc.Visible = true;
                    tsBaoCao.Visible = true;
					break;
			}
		}



	}
}

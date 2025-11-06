using BUS;
using Microsoft.VisualBasic.Devices;
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
	public partial class frmChiTietHoaDon : Form
	{
		public frmChiTietHoaDon()
		{
			InitializeComponent();
		}
		ChiTietHoaDonBUS bus = new ChiTietHoaDonBUS();
		BindingSource bs = new BindingSource(); // <-- THÊM DÒNG NÀY
		public void loadData()
		{
			bs.DataSource = bus.GetAllChiTietHoaDonAsTable();
			dgvChiTietDonHang.DataSource = bs;
		}
		public void clearData()
		{
			txtSoLuong.Text = "";
			dtpNgayGioIn.Value = DateTime.Now;

		}
		public void loadSanPham()
		{
			SanPhamBUS busKH = new SanPhamBUS();
			cboSanPham.DataSource = busKH.GetAllSanPhamAsTable();
			cboSanPham.DisplayMember = "ten_san_pham";
			cboSanPham.ValueMember = "ma_san_pham";
			cboSanPham.SelectedIndex = 0;
		}
		public void loadHoaDon()
		{
			HoaDonBUS busKH = new HoaDonBUS();
			cboMaHoaDon.DataSource = busKH.GetAllHoaDonAsTable();
			cboMaHoaDon.DisplayMember = "ma_hoa_don";
			cboMaHoaDon.ValueMember = "ma_hoa_don";
			cboMaHoaDon.SelectedIndex = 0;
		}
		public void loadKhuyenMai()
		{
			KhuyenMaiBUS busKH = new KhuyenMaiBUS();
			cboSanPham.DataSource = busKH.GetAllKhuyenMaiAsTable();
			cboSanPham.DisplayMember = "ma_khuyen_mai";
			cboSanPham.ValueMember = "ma_khuyen_mai";
			cboSanPham.SelectedIndex = 0;
		}
		private void btnThoat_Click(object sender, EventArgs e)
		{
			DialogResult rs = MessageBox.Show("Are you sure to exit?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rs == DialogResult.No)
			{
				return;
			}
			this.Close();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			if (checkDuLieuNhap() == false)
			{
			}
			else
			{
				if (bus.AddChiTietHoaDon(cboMaHoaDon.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString(), cboKhuyenMai.SelectedValue.ToString(), txtSoLuong.Text, txtDonGia.Text, dtpNgayGioIn.Value) == false)
				{
					MessageBox.Show("Thêm chi tiết hóa đơn thành công!");
				}
				else
				{
					MessageBox.Show("Thêm chi tiết hóa đơn thất bại!");
				}
			}
			loadData();
		}

		private void frmChiTietHoaDon_Load(object sender, EventArgs e)
		{
			dgvChiTietDonHang.AutoGenerateColumns = false;
			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã hóa đơn",
				DataPropertyName = "ma_hoa_don",
				Width = 200
			});

			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã sản phẩm",
				DataPropertyName = "ma_san_pham",
				Width = 300
			});

			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã khuyến mãi",
				DataPropertyName = "ma_khuyen_mai",
				Width = 100
			});

			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Số lượng",
				DataPropertyName = "so_luong",
				Width = 100
			});
			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Đơn giá",
				DataPropertyName = "don_gia",
				Width = 200
			});
			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày giờ in",
				DataPropertyName = "ngay_gio_in",
				Width = 200
			});

			loadData();
			loadKhuyenMai();
			loadSanPham();
			loadHoaDon();
		}
		private bool checkDuLieuNhap()
		{
			errorProvider1.Clear();
			bool coLoi = false;
			// 1. Kiểm tra rỗng
			if (CheckTestCase.checkKhoangTrang(txtSoLuong.Text) == false)
			{
				errorProvider1.SetError(txtSoLuong, "Số lượng không được trống!");
				coLoi = true;
			}
			if (CheckTestCase.checkKhoangTrang(txtDonGia.Text) == false)
			{
				errorProvider1.SetError(txtDonGia, "Đơn giá không được trống!");
				coLoi = true;
			}

			// 3. Kiểm tra kiểu dữ liệu (chỉ check nếu không bị rỗng)
			if (coLoi == false) // Nếu đã qua được hết check rỗng
			{
				if (CheckTestCase.checkKieuInt(txtDonGia.Text) == false)
				{
					errorProvider1.SetError(txtDonGia, "Đơn giá phải là số nguyên!");
					coLoi = true;
				}
				if (CheckTestCase.checkKieuDecimal(txtSoLuong.Text) == false)
				{
					errorProvider1.SetError(txtSoLuong, "Số lượng phải là số nguyên!");
					coLoi = true;
				}

			}

			//if (cboKhuyenMai.SelectedIndex == -1 || cboKhuyenMai.SelectedValue == null)
			//{
			//	errorProvider1.SetError(cboKhuyenMai, "Vui lòng chọn khuyến mãi!");
			//	coLoi = true;
			//}
			if (cboSanPham.SelectedIndex == -1 || cboSanPham.SelectedValue == null)
			{
				errorProvider1.SetError(cboSanPham, "Vui lòng chọn sản phẩm!");
				coLoi = true;
			}
			if (cboMaHoaDon.SelectedIndex == -1 || cboMaHoaDon.SelectedValue == null)
			{
				errorProvider1.SetError(cboMaHoaDon, "Vui lòng chọn hóa đơn!");
				coLoi = true;
			}
			return !coLoi;
		}
		private void txtTimKiem_TextChanged(object sender, EventArgs e)
		{
			string keyword = txtTimKiem.Text;

			if (string.IsNullOrEmpty(keyword))
			{
				// Nếu ô tìm kiếm trống, xóa bộ lọc và hiển thị tất cả
				bs.Filter = null;
			}
			else
			{
				string safeKeyword = keyword.Replace("'", "''");
				bs.Filter = string.Format(
				" ma_hoa_don LIKE '%{0}%' OR " +
				" ma_san_pham LIKE '%{0}%' OR " +
				" ma_khuyen_mai LIKE '%{0}%' OR " +
				" CONVERT(so_luong, 'System.String') LIKE '%{0}%'", // <-- Sửa ở đây																			  
				safeKeyword);
			}
		}

		private void dgvChiTietDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvChiTietDonHang.CurrentCell.RowIndex;
				if (dgvChiTietDonHang.Rows[line].Cells[0].Value != DBNull.Value)
				{
					cboMaHoaDon.SelectedValue = dgvChiTietDonHang.Rows[line].Cells[0].Value.ToString();
					cboSanPham.SelectedValue = dgvChiTietDonHang.Rows[line].Cells[1].Value.ToString();
					cboKhuyenMai.SelectedValue = dgvChiTietDonHang.Rows[line].Cells[2].Value.ToString();
					txtSoLuong.Text = dgvChiTietDonHang.Rows[line].Cells[3].Value.ToString();
					decimal giaTienValue = decimal.Parse(dgvChiTietDonHang.Rows[line].Cells[4].Value.ToString());
					txtDonGia.Text = giaTienValue.ToString("F0");
					//lỗi xuất hiện e+0
					dtpNgayGioIn.Value = Convert.ToDateTime(dgvChiTietDonHang.Rows[line].Cells[5].Value);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Chỉ cho phép nhập số (IsDigit) hoặc các phím điều khiển (IsControl) như Backspace
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // "Nuốt" ký tự đó, không cho nó hiển thị
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			if (CheckTestCase.checkKhoangTrang(cboMaHoaDon.SelectedValue.ToString()) == false)
			{
				MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa");
				return;
			}
			else if (checkDuLieuNhap() == false)
			{
			}
			else
			{
				if (bus.UpdateChiTietHoaDon(cboMaHoaDon.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString(), cboKhuyenMai.SelectedValue.ToString(), txtSoLuong.Text, txtDonGia.Text, dtpNgayGioIn.Value) == false)
				{
					MessageBox.Show("sửa chi tiết hóa đơn thành công!");
				}
				else
				{
					MessageBox.Show("sửa chi tiết hóa đơn thất bại!");
				}
			}
			loadData();
		}

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			clearData();
		}


		private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // "Nuốt" ký tự đó, không cho nó hiển thị
			}
		}
	}
}

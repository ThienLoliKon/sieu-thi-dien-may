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
		private string maHoaDon = "";
		ChiTietHoaDonBUS bus = new ChiTietHoaDonBUS();
		BindingSource bs = new BindingSource(); // <-- THÊM DÒNG NÀY		
		private decimal giaGocSanPham = 0; // <-- THÊM DÒNG NÀY
		public frmChiTietHoaDon(string maHD)
		{
			InitializeComponent();
			maHoaDon = HamXuLy.XoaKhoangTrangThua(maHD);
		}
		
		public void loadData()
		{
			bs.DataSource = bus.GetAllChiTietHoaDonAsTable();
			dgvChiTietDonHang.DataSource = bs;
		}
		public void clearData()
		{
			txtSoLuong.Text = "";
			cboKhuyenMai.SelectedIndex = -1;
			cboSanPham.SelectedIndex = -1;
			cboMaHoaDon.SelectedIndex = -1;
			txtDonGia.Text = "0";
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
				string khuyenMaiValue = cboKhuyenMai.SelectedValue != null ? cboKhuyenMai.SelectedValue.ToString() : null;
				if (bus.AddChiTietHoaDon(cboMaHoaDon.SelectedValue.ToString(),TaiKhoanBUS.currentUserMaNV, cboSanPham.SelectedValue.ToString(), khuyenMaiValue, txtSoLuong.Text, txtDonGia.Text, dtpNgayGioIn.Value) == false)
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
		{// Đặt font cho tiêu đề (ví dụ: Tahoma, 12, In đậm)
			dgvChiTietDonHang.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12f, FontStyle.Bold);
			// Đặt font cho nội dung (ví dụ: Tahoma, 11, Thường)
			dgvChiTietDonHang.DefaultCellStyle.Font = new Font("Tahoma", 10f, FontStyle.Regular);
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
				Width = 200
			});

			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã khuyến mãi",
				DataPropertyName = "ma_khuyen_mai",
				Width = 200
			});

			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Số lượng",
				DataPropertyName = "so_luong",
				Width = 200
			});
			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Đơn giá",
				DataPropertyName = "don_gia",
				Width = 300
			});
			dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày giờ in",
				DataPropertyName = "ngay_gio_in",
				Width = 300
			});
			loadData();
			loadKhuyenMai();
			loadSanPham();
			loadHoaDon();
			txtTimKiem.Text = maHoaDon;
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

		private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboSanPham.SelectedValue == null)
			{
				return; // Dừng lại nếu chưa nạp xong
			}
			try
			{
				// lấy giá tiền lúc mua
				// 2. LẤY MÃ SẢN PHẨM (đã sửa)
				string maSP = cboSanPham.SelectedValue.ToString();

				// 3. Lấy giá tiền và LƯU VÀO BIẾN GIÁ GỐC
				SanPhamBUS busSP = new SanPhamBUS();
				// (Giả sử bạn đã có hàm layGiaTienSanPhamBangMa(maSP) trong BUS)
				this.giaGocSanPham = busSP.layGiaTienSanPhamBangMa(maSP);

				// 4. Hiển thị giá gốc ban đầu
				txtDonGia.Text = this.giaGocSanPham.ToString("F0");

				KhuyenMaiBUS busNhaSX = new KhuyenMaiBUS();
				DataTable dt = busNhaSX.GetAllKhuyenMaiByMaSPAsTable(cboSanPham.SelectedValue.ToString());
				cboKhuyenMai.DataSource = dt;
				cboKhuyenMai.DisplayMember = "giam_gia";
				cboKhuyenMai.ValueMember = "ma_khuyen_mai";
				if (dt == null || dt.Rows.Count == 0)
				{
					cboKhuyenMai.DataSource = null;
					cboKhuyenMai.Items.Clear();
					cboKhuyenMai.Text = "Không tìm thấy khuyến mãi";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message);
				this.giaGocSanPham = 0;
				txtDonGia.Text = "0";
			}
		}

		private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
		{
			// 1. Kiểm tra nếu ComboBox chưa sẵn sàng
			if (cboKhuyenMai.SelectedItem == null || cboKhuyenMai.DataSource == null || this.giaGocSanPham == 0)
			{
				// Nếu không chọn khuyến mãi, hoặc chưa có sản phẩm,
				// đảm bảo giá tiền được trả về giá gốc.
				txtDonGia.Text = this.giaGocSanPham.ToString("F0");
				return;
			}

			try
			{
				// 2. Lấy dòng dữ liệu (DataRowView) của khuyến mãi đang chọn
				DataRowView selectedRow = (DataRowView)cboKhuyenMai.SelectedItem;

				// 3. Lấy giá trị khuyến mãi (ví dụ: 0.05, 0.1, 0.2)
				// Chúng ta nên dùng Convert.ToDecimal để an toàn
				decimal phanTramGiam = Convert.ToDecimal(selectedRow["giam_gia"]);

				// 4. Tính giá đã giảm
				// Ví dụ: 1000 * (1 - 0.05) = 950
				decimal giaDaGiam = this.giaGocSanPham - (this.giaGocSanPham * phanTramGiam / 100);

				// 5. Cập nhật giá tiền mới vào TextBox
				// (Làm tròn đến 0 số lẻ)
				txtDonGia.Text = giaDaGiam.ToString("F0");
			}
			catch (Exception ex)
			{
				// Có lỗi xảy ra, trả về giá gốc cho an toàn
				txtDonGia.Text = this.giaGocSanPham.ToString("F0");
			}
		}
	}
}

using BUS;
using BUSs;
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
	public partial class frmBaoHanh : Form
	{
		public frmBaoHanh()
		{
			InitializeComponent();
		}
		BaoHanhBUS bus = new BaoHanhBUS();
		BindingSource bs = new BindingSource(); // <-- THÊM DÒNG NÀY
		private string maBHHT = "";
		private void btnThoat_Click(object sender, EventArgs e)
		{
			DialogResult rs = MessageBox.Show("Are you sure to exit?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rs == DialogResult.No)
			{
				return;
			}
			this.Close();
		}

		public void loadKhachHang()
		{
			KhachHangBUS busNhaSX = new KhachHangBUS();
			cboMaKhachHang.DataSource = busNhaSX.GetAllKhachHang();
			cboMaKhachHang.DisplayMember = "tenkhachhang";
			cboMaKhachHang.ValueMember = "makhachhang";
			cboMaKhachHang.SelectedIndex = 0;
		}

		public void loadKNhanVien()
		{
			NhanVienBUS busKH = new NhanVienBUS();
			cboMaNhanVien.DataSource = busKH.GetAllNhanVienAsTable();
			cboMaNhanVien.DisplayMember = "TenNV";
			cboMaNhanVien.ValueMember = "MaNV";
		}


		public void loadData()
		{
			bs.DataSource = bus.GetAllBaoHanhAsTable();
			dgvBaoHanh.DataSource = bs;
		}
		private bool checkDuLieuNhap()
		{
			// Xóa hết lỗi ❗ cũ trước khi kiểm tra
			errorProvider1.Clear();
			bool coLoi = false;

			// 1. Kiểm tra rỗng
			if (CheckTestCase.checkKhoangTrang(rtxtLyDo.Text) == false)
			{
				errorProvider1.SetError(rtxtLyDo, "Lý do không được trống!");
				coLoi = true;
			}

			// 2. Kiểm tra độ dài
			if (CheckTestCase.checkLenghtChuoi(rtxtLyDo.Text, 100) == false)
			{
				errorProvider1.SetError(rtxtLyDo, "Tên sản phẩm không được quá 100 kí tự!");
				coLoi = true;
			}

			//4. Kiểm tra ComboBox
			if (cboMaKhachHang.SelectedIndex == -1 || cboMaKhachHang.SelectedValue == null)
			{
				errorProvider1.SetError(cboMaKhachHang, "Vui lòng chọn khách hàng!");
				coLoi = true;
			}
			if (cboMaNhanVien.SelectedIndex == -1 || cboMaNhanVien.SelectedValue == null)
			{
				errorProvider1.SetError(cboMaNhanVien, "Vui lòng chọn nhân viên!");
				coLoi = true;
			}
			if (cboMaSanPham.SelectedIndex == -1 || cboMaSanPham.SelectedValue == null)
			{
				errorProvider1.SetError(cboMaSanPham, "Vui lòng chọn sản phẩm!");
				coLoi = true;
			}

			// 5. Kiểm tra ngày tháng
			if (CheckTestCase.ngayBatDauKetThuc(dtpNgayGui.Value, dtpNgayXong.Value) == false)
			{
				errorProvider1.SetError(dtpNgayXong, "Ngày xong phải sau ngày gửi!");
				coLoi = true;
			}



			return !coLoi;
		}
		private void btnSua_Click(object sender, EventArgs e)
		{
			if (CheckTestCase.checkKhoangTrang(txtMaBaoHanh.Text) == false)
			{
				MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa");
				return;
			}
			else if (checkDuLieuNhap() == false)
			{

			}
			else
			{
				bus.UpdateBaoHanh(txtMaBaoHanh.Text, cboMaSanPham.SelectedValue.ToString(), cboMaKhachHang.SelectedValue.ToString(), cboMaNhanVien.SelectedValue.ToString(), rtxtLyDo.Text, dtpNgayGui.Value, dtpNgayXong.Value, chkHoanThanh.Checked);
				loadData();
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			BaoHanhBUS bus = new BaoHanhBUS();
			bool hoanThanh = true;
			if (chkHoanThanh.Checked == true)
			{
				hoanThanh = true;
			}
			else
			{
				hoanThanh = false;
			}
			if (checkDuLieuNhap() == false)
			{
				return;
			}
			BaoHanhBUS baoHanhBus = new BaoHanhBUS();
			string maHD = cboNgayMua.SelectedValue.ToString();
			string maSP = cboMaSanPham.SelectedValue.ToString();

			bool conHan = baoHanhBus.KiemTraHanBaoHanh(maHD, maSP);

			if (!conHan)
			{
				MessageBox.Show("Sản phẩm này ĐÃ HẾT HẠN bảo hành.");
				return;
			}

			if (!bus.AddBaoHanh(cboMaSanPham.SelectedValue.ToString(), cboMaKhachHang.SelectedValue.ToString(), cboMaNhanVien.SelectedValue.ToString(), rtxtLyDo.Text, dtpNgayGui.Value, dtpNgayXong.Value, hoanThanh))
			{
				MessageBox.Show("Thêm bảo hành thành công!");
			}
			else
			{
				MessageBox.Show("Thêm bảo hành thất bại!");
			}
			loadData();


			//if (bus.AddBaoHanh(cboMaSanPham.SelectedValue.ToString(), cboMaKhachHang.SelectedValue.ToString(), TaiKhoanBUS.currentUserMaNV, rtxtLyDo.Text, dtpNgayGui.Value, dtpNgayXong.Value, hoanThanh);
			//{
			//	MessageBox.Show("Thêm bảo hành thành công!");
			//}
			//else
			//{
			//	MessageBox.Show("Thêm bảo hành thất bại!");
			//	loadData();
			//}
		}
		private void frmBaoHanh_Load(object sender, EventArgs e)
		{
			// Đặt font cho tiêu đề (ví dụ: Tahoma, 12, In đậm)
			dgvBaoHanh.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12f, FontStyle.Bold);
			// Đặt font cho nội dung (ví dụ: Tahoma, 11, Thường)
			dgvBaoHanh.DefaultCellStyle.Font = new Font("Tahoma", 10f, FontStyle.Regular);
			dgvBaoHanh.AutoGenerateColumns = false;

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã bảo hành",
				DataPropertyName = "ma_bao_hanh",
				Width = 100
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã sản phẩm",
				DataPropertyName = "ma_san_pham",
				Width = 100
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã khách hàng",
				DataPropertyName = "ma_khach_hang",
				Width = 100
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "nhân viên bảo hành",
				DataPropertyName = "nhan_vien_bao_hanh",
				Width = 100
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "lý do",
				DataPropertyName = "ly_do",
				Width = 250
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "ngày gửi",
				DataPropertyName = "ngay_gui",
				Width = 150
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày xong",
				DataPropertyName = "ngay_xong",
				Width = 150
			});
			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "hoàn thành",
				DataPropertyName = "hoan_thanh",
				Width = 100
			});
			loadData();
			loadKhachHang();
			loadKNhanVien();

			cboMaNhanVien.SelectedIndex = 0;
			//cboMaSanPham.SelectedIndex = 0; 
			//cboMaSanPham.SelectedIndex = 0;

		}

		private void dgvBaoHanh_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				clear();
				int line = dgvBaoHanh.CurrentCell.RowIndex;
				if (dgvBaoHanh.Rows[line].Cells[0].Value != DBNull.Value)
				{
					txtMaBaoHanh.Text = dgvBaoHanh.Rows[line].Cells[0].Value.ToString();
					cboMaSanPham.SelectedValue = dgvBaoHanh.Rows[line].Cells[1].Value.ToString();
					cboMaKhachHang.SelectedValue = dgvBaoHanh.Rows[line].Cells[2].Value.ToString();

					cboMaNhanVien.SelectedValue = dgvBaoHanh.Rows[line].Cells[3].Value.ToString();
					rtxtLyDo.Text = dgvBaoHanh.Rows[line].Cells[4].Value.ToString();
					dtpNgayGui.Value = Convert.ToDateTime(dgvBaoHanh.Rows[line].Cells[5].Value);
					if (Convert.ToBoolean(dgvBaoHanh.Rows[line].Cells[7].Value))
					{
						dtpNgayXong.Value = Convert.ToDateTime(dgvBaoHanh.Rows[line].Cells[6].Value);
					}
					chkHoanThanh.Checked = Convert.ToBoolean(dgvBaoHanh.Rows[line].Cells[7].Value);
				}
				maBHHT = txtMaBaoHanh.Text;

			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			clear();

		}
		private void clear()
		{
			txtMaBaoHanh.Text = "";
			txtTimKiem.Text = "";
			rtxtLyDo.Text = "";
			cboMaKhachHang.SelectedIndex = -1;
			cboMaSanPham.SelectedIndex = -1;
			cboNgayMua.SelectedIndex = -1;
			cboMaNhanVien.SelectedIndex = -1;
			dtpNgayGui.Value = DateTime.Now;
			dtpNgayXong.Value = DateTime.Now;
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
				" ma_san_pham LIKE '%{0}%' OR " +
				" ma_khach_hang LIKE '%{0}%' OR " +
				" nhan_vien_bao_hanh LIKE '%{0}%' OR " +
				" ly_do LIKE '%{0}%' OR " +
				" CONVERT(hoan_thanh, 'System.String') LIKE '%{0}%' ", // <-- Sửa ở đây
				safeKeyword);
			}
		}

		private void cboMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboMaKhachHang.SelectedValue == null)
			{
				return; // Dừng lại nếu chưa nạp xong
			}
			HoaDonBUS busNhaSX = new HoaDonBUS();
			DataTable dtHoaDon = busNhaSX.timHoaDon(cboMaKhachHang.SelectedValue.ToString());
			cboNgayMua.DataSource = dtHoaDon;
			cboNgayMua.DisplayMember = "ngay_lap";
			cboNgayMua.ValueMember = "ma_hoa_don";
			if (dtHoaDon == null || dtHoaDon.Rows.Count == 0)
			{
				cboNgayMua.DataSource = null;
				cboNgayMua.Items.Clear();
				cboNgayMua.Text = "Không tìm thấy ngày mua ";
			}
			//if (cboMaSanPham.SelectedValue != null && cboMaSanPham.DataSource != null)
			//{
			//	try
			//	{
			//		HoaDonBUS busNhaSX = new HoaDonBUS();
			//		DataTable dtHoaDon = busNhaSX.timHoaDon(cboMaKhachHang.SelectedValue.ToString());
			//		cboNgayMua.DataSource = dtHoaDon;
			//		cboNgayMua.DisplayMember = "ngay_lap";
			//		cboNgayMua.ValueMember = "ma_hoa_don";
			//		cboNgayMua.SelectedIndex = 0;


			//		// 3. Xử lý trường hợp khách hàng này không mua gì
			//		if (dtHoaDon == null || dtHoaDon.Rows.Count == 0)
			//		{
			//			cboNgayMua.DataSource = null;
			//			cboNgayMua.Items.Clear();
			//			cboNgayMua.Text = "Không tìm thấy ngày mua ";
			//		}
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Lỗi khi tải danh sách hóa ngày mua: " + ex.Message);
			//		cboNgayMua.DataSource = null;
			//		cboNgayMua.Items.Clear();
			//	}
			//}
		}

		private void cboNgayMua_SelectedIndexChanged(object sender, EventArgs e)
		{

			loadSanPhamKhiCellClick();
		}

		private void loadSanPhamKhiCellClick()
		{
			if (cboNgayMua.SelectedValue == null)
			{
				return; // Dừng lại nếu chưa nạp xong
			}
			SanPhamBUS busNhaSX = new SanPhamBUS();
			DataTable dt = busNhaSX.getSanPhamByMaHDAsTable(cboNgayMua.SelectedValue.ToString());
			cboMaSanPham.DataSource = dt;
			cboMaSanPham.DisplayMember = "ten_san_pham";
			cboMaSanPham.ValueMember = "ma_san_pham";
			if (dt == null || dt.Rows.Count == 0)
			{
				cboMaSanPham.DataSource = null;
				cboMaSanPham.Items.Clear();
				cboMaSanPham.Text = "Không tìm thấy sản phẩm ";
			}
		}

	}
}

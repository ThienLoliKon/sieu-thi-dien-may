using BUS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace he_thong_dien_may
{
	public partial class frmHoaDon : Form
	{
		public frmHoaDon()
		{
			InitializeComponent();
		}
		HoaDonBUS bus = new HoaDonBUS();
		BindingSource bs = new BindingSource();

		public void loadData()
		{
			bs.DataSource = bus.GetAllHoaDonAsTable();
			dgvHoaDon.DataSource = bs;
		}
		public void clearData()
		{
			txtMaHoaDon.Text = "";
			txtTimKiem.Text = "";
			dtpNgayLap.Value = DateTime.Now;

		}

		public void loadKhachHang()
		{
			//load nha san xuat
			KhachHangBUS khachHangBUS = new KhachHangBUS();
			cboKhachHang.DataSource = khachHangBUS.GetAllKhachHang();
			cboKhachHang.DisplayMember = "tenkhachhang";
			cboKhachHang.ValueMember = "makhachhang";
			cboKhachHang.SelectedIndex = 0;
		}
		public void loadNhanVienLap()
		{
			//load nha san xuat
			NhanVienBUS NhanVienBUS = new NhanVienBUS();
			cboNhanVienLap.DataSource = NhanVienBUS.GetAllNhanVienAsTable();
			cboNhanVienLap.DisplayMember = "TenNV";
			cboNhanVienLap.ValueMember = "MaNV";
			cboNhanVienLap.SelectedIndex = 0;
		}
		private void btnSuaChiTietHD_Click(object sender, EventArgs e)
		{
			Form f = new frmChiTietHoaDon(txtMaHoaDon.Text);
			f.ShowDialog();
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

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			clearData();
		}

		private void frmHoaDon_Load(object sender, EventArgs e)
		{
			// Đặt font cho tiêu đề (ví dụ: Tahoma, 12, In đậm)
			dgvHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12f, FontStyle.Bold);
			// Đặt font cho nội dung (ví dụ: Tahoma, 11, Thường)
			dgvHoaDon.DefaultCellStyle.Font = new Font("Tahoma", 10f, FontStyle.Regular);
			dgvHoaDon.AutoGenerateColumns = false;
			dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã hóa đơn",
				DataPropertyName = "ma_hoa_don",
				Width = 350
			});
			dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Nhân viên lập",
				DataPropertyName = "ma_nhan_vien_lap",
				Width = 350
			});
			dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã khách hàng",
				DataPropertyName = "ma_khach_hang",
				Width = 350
			});
			dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày lập",
				DataPropertyName = "ngay_lap",
				Width = 450
			});
			loadData();
			loadKhachHang();
			loadNhanVienLap();
		}
		private bool checkDuLieuNhap()
		{
			errorProvider1.Clear();
			bool coLoi = false;
			//4. Kiểm tra ComboBox
			if (cboKhachHang.SelectedIndex == -1 || cboKhachHang.SelectedValue == null)
			{
				errorProvider1.SetError(cboKhachHang, "Vui lòng chọn Khách hàng!");
				coLoi = true;
			}
			if (cboNhanVienLap.SelectedIndex == -1 || cboNhanVienLap.SelectedValue == null)
			{
				errorProvider1.SetError(cboNhanVienLap, "Vui lòng chọn nhân viên lập hóa đơn!");
				coLoi = true;
			}
			return !coLoi; // SỬA LẠI THÀNH DÒNG NÀY
						  
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			if (!checkDuLieuNhap())
			{
				return;
			}

			if (!bus.AddHoaDon(cboNhanVienLap.SelectedValue.ToString(), cboKhachHang.SelectedValue.ToString()))
			{
				MessageBox.Show("Thêm hóa đơn thành công");
			}
			else
			{
				MessageBox.Show("Thêm hóa đơn thất bại");
			}

			loadData();
		}

		private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvHoaDon.CurrentCell.RowIndex;

				if (dgvHoaDon.Rows[line].Cells[0].Value != DBNull.Value)
				{
					txtMaHoaDon.Text = dgvHoaDon.Rows[line].Cells[0].Value.ToString();
					cboNhanVienLap.SelectedValue = dgvHoaDon.Rows[line].Cells[1].Value.ToString();
					cboKhachHang.SelectedValue = dgvHoaDon.Rows[line].Cells[2].Value.ToString();
					dtpNgayLap.Value = Convert.ToDateTime(dgvHoaDon.Rows[line].Cells[3].Value);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			if (!checkDuLieuNhap())
			{
				return;
			}
			if (CheckTestCase.checkKhoangTrang(txtMaHoaDon.Text) == false)
			{
				MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa");
				return;
			}
			else if(!bus.UpdateHoaDon(txtMaHoaDon.Text, cboNhanVienLap.SelectedValue.ToString(), cboKhachHang.SelectedValue.ToString()))
			{
				MessageBox.Show("Sửa hóa đơn thành công");
			}
			else
			{
				MessageBox.Show("Sửa hóa đơn thất bại");
			}
			loadData();

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
				" ma_nhan_vien_lap LIKE '%{0}%' OR " +
				" ma_khach_hang LIKE '%{0}%'", // <-- Sửa ở đây																			  
				safeKeyword);
			}
		}
	}
}

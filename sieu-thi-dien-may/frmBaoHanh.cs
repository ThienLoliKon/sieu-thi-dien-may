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
			cboMaKhachHang.DisplayMember = "hotenkhachhang";
			cboMaKhachHang.ValueMember = "makhachhang";
			cboMaKhachHang.SelectedIndex = 0;
		}
		public void loadSanPham()
		{
			SanPhamBUS busNhaSX = new SanPhamBUS();
			cboMaSanPham.DataSource = busNhaSX.GetAllSanPhamAsTable();
			cboMaSanPham.DisplayMember = "ten_san_pham";
			cboMaSanPham.ValueMember = "ma_san_pham";
			cboMaSanPham.SelectedIndex = 0;
		}

		public void loadKNhanVien()
		{
			NhanVienBUS busKH = new NhanVienBUS();
			cboMaNhanVien.DataSource = busKH.GetAllNhanVienAsTable();
			cboMaNhanVien.DisplayMember = "TenNV";
			cboMaNhanVien.ValueMember = "MaNV";
			cboMaNhanVien.SelectedIndex = 0;
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

			bus.AddBaoHanh(cboMaSanPham.SelectedValue.ToString(),cboMaKhachHang.SelectedValue.ToString(), cboMaNhanVien.SelectedValue.ToString(), rtxtLyDo.Text, dtpNgayGui.Value, dtpNgayXong.Value, hoanThanh);
			loadData();
		}

		private void frmBaoHanh_Load(object sender, EventArgs e)
		{

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
			loadSanPham();
		}

		private void dgvBaoHanh_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvBaoHanh.CurrentCell.RowIndex;
				if (dgvBaoHanh.Rows[line].Cells[0].Value != DBNull.Value)
				{
					txtMaBaoHanh.Text = dgvBaoHanh.Rows[line].Cells[0].Value.ToString();
					cboMaSanPham.SelectedValue = dgvBaoHanh.Rows[line].Cells[1].Value.ToString();
					cboMaNhanVien.SelectedValue = dgvBaoHanh.Rows[line].Cells[2].Value.ToString();
					cboMaNhanVien.SelectedValue = dgvBaoHanh.Rows[line].Cells[3].Value.ToString();
					rtxtLyDo.Text = dgvBaoHanh.Rows[line].Cells[4].Value.ToString();
					dtpNgayGui.Value = Convert.ToDateTime(dgvBaoHanh.Rows[line].Cells[5].Value);
					if (Convert.ToBoolean(dgvBaoHanh.Rows[line].Cells[7].Value))
					{
						dtpNgayXong.Value = Convert.ToDateTime(dgvBaoHanh.Rows[line].Cells[6].Value);
					}
					chkHoanThanh.Checked = Convert.ToBoolean(dgvBaoHanh.Rows[line].Cells[7].Value);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtMaBaoHanh.Text = "";
			txtTimKiem.Text = "";
			rtxtLyDo.Text = "";
			txtTimKiem.Text = "";
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
	}
}

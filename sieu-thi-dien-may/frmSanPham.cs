using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace he_thong_dien_may
{
	public partial class frmSanPham : Form
	{

		public frmSanPham()
		{
			InitializeComponent();
		}
		SanPhamBUS bus = new SanPhamBUS();
		BindingSource bs = new BindingSource(); // <-- THÊM DÒNG NÀY

		public void loadData()
		{
			bs.DataSource = bus.GetAllSanPhamAsTable();
			dgvSanPham.DataSource = bs;
		}

		public void clearData()
		{
			txtMaSanPham.Text = "";
			txtTenSanPham.Text = "";
			cboMaNhaSX.SelectedIndex = 0;
			cboMaNhaCC.SelectedIndex = 0;
			txtKhoiLUong.Text = "";
			txtThoiGianBH.Text = "";
			txtGiaTien.Text = "0";
			dtpNgaySanXuat.Value = DateTime.Now;
		}

		public void loadNhaSX()
		{
			//load nha san xuat
			NhaSXBUS busNhaSX = new NhaSXBUS();
			cboMaNhaSX.DataSource = busNhaSX.GetAllNhaCungCapAsTable();
			cboMaNhaSX.DisplayMember = "ten_nha_san_xuat";
			cboMaNhaSX.ValueMember = "ma_nha_san_xuat";
			cboMaNhaSX.SelectedIndex = 0;
		}

		public void loadNhaCC()
		{
			//load nha cung cap
			NhaCCBUS busNhaCC = new NhaCCBUS();
			cboMaNhaCC.DataSource = busNhaCC.GetAllNhaCungCapAsTable();
			cboMaNhaCC.DisplayMember = "ten_nha_cung_cap";
			cboMaNhaCC.ValueMember = "ma_nha_cung_cap";
			cboMaNhaCC.SelectedIndex = 0;
		}


		private void frmSanPham_Load(object sender, EventArgs e)
		{
			dgvSanPham.AutoGenerateColumns = false;
			dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã sản phẩm",
				DataPropertyName = "ma_san_pham",
				Width = 100
			});

			dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Tên sản phẩm",
				DataPropertyName = "ten_san_pham",
				Width = 200
			});

			dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã nhà sản xuất",
				DataPropertyName = "ma_nha_san_xuat",
				Width = 100
			});

			dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã nhà cung cấp",
				DataPropertyName = "ma_nha_cung_cap",
				Width = 100
			});

			dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Khối lượng",
				DataPropertyName = "khoi_luong",
				Width = 100
			});
			dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Thời gian Bảo hành",
				DataPropertyName = "thoi_gian_bao_hanh",
				Width = 100
			});
			dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Gía tiền",
				DataPropertyName = "gia_tien",
				Width = 200,
				DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } // Hiển thị số nguyên, có dấu phẩy
			});

			dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày sản xuất",
				DataPropertyName = "ngay_san_xuat",
				Width = 200
			});
			loadData();
			loadNhaCC();
			loadNhaSX();
		}
		private bool checkDuLieuNhap()
		{
			// Xóa hết lỗi ❗ cũ trước khi kiểm tra
			errorProvider1.Clear();
			bool coLoi = false;

			// 1. Kiểm tra rỗng
			if (CheckTestCase.checkKhoangTrang(txtTenSanPham.Text) == false)
			{
				errorProvider1.SetError(txtTenSanPham, "Tên sản phẩm không được trống!");
				coLoi = true;
			}
			if (CheckTestCase.checkKhoangTrang(txtKhoiLUong.Text) == false)
			{
				errorProvider1.SetError(txtKhoiLUong, "Khối lượng không được trống!");
				coLoi = true;
			}
			if (CheckTestCase.checkKhoangTrang(txtThoiGianBH.Text) == false)
			{
				errorProvider1.SetError(txtThoiGianBH, "Bảo hành không được trống!");
				coLoi = true;
			}
			if (CheckTestCase.checkKhoangTrang(txtGiaTien.Text) == false)
			{
				errorProvider1.SetError(txtGiaTien, "Giá tiền không được trống!");
				coLoi = true;
			}

			// 2. Kiểm tra độ dài
			if (CheckTestCase.checkLenghtChuoi(txtTenSanPham.Text, 100) == false)
			{
				errorProvider1.SetError(txtTenSanPham, "Tên sản phẩm không được quá 100 kí tự!");
				coLoi = true;
			}

			// 3. Kiểm tra kiểu dữ liệu (chỉ check nếu không bị rỗng)
			if (coLoi == false) // Nếu đã qua được hết check rỗng
			{
				if (CheckTestCase.checkKieuInt(txtThoiGianBH.Text) == false)
				{
					errorProvider1.SetError(txtThoiGianBH, "Bảo hành phải là số nguyên!");
					coLoi = true;
				}
				if (CheckTestCase.checkKieuDouble(txtKhoiLUong.Text) == false)
				{
					errorProvider1.SetError(txtKhoiLUong, "Khối lượng phải là số (ví dụ: 0.5)!");
					coLoi = true;
				}
				if (CheckTestCase.checkKieuDecimal(txtGiaTien.Text) == false)
				{
					errorProvider1.SetError(txtGiaTien, "Giá tiền phải là số nguyên!");
					coLoi = true;
				}
			}
			//4. Kiểm tra ComboBox
			if (cboMaNhaSX.SelectedIndex == -1 || cboMaNhaSX.SelectedValue == null)
			{
				errorProvider1.SetError(cboMaNhaSX, "Vui lòng chọn nhà sản xuất!");
				coLoi = true;
			}
			if (cboMaNhaCC.SelectedIndex == -1 || cboMaNhaCC.SelectedValue == null)
			{
				errorProvider1.SetError(cboMaNhaCC, "Vui lòng chọn nhà cung cấp!");
				coLoi = true;
			}

			return !coLoi; // Trả về true (Không có lỗi) nếu coLoi = false
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			SanPhamBUS bus = new SanPhamBUS();
			if (checkDuLieuNhap() == false)
			{
			}
			else
			{
				if (bus.AddSanPham(txtTenSanPham.Text, cboMaNhaSX.SelectedValue.ToString(), cboMaNhaCC.SelectedValue.ToString(), txtKhoiLUong.Text, txtThoiGianBH.Text, txtGiaTien.Text, dtpNgaySanXuat.Value) == false)
				{
					MessageBox.Show("Thêm sản phẩm thành công!");
				}
				else
				{
					MessageBox.Show("Thêm sản phẩm thất bại!");
				}
			}
			loadData();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			if (CheckTestCase.checkKhoangTrang(txtMaSanPham.Text) == false)
			{
				MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa");
				return;
			}
			else if (checkDuLieuNhap() == false)
			{
			}
			else
			{
				if(bus.UpdateSanPham(txtMaSanPham.Text, txtTenSanPham.Text, cboMaNhaSX.SelectedValue.ToString(), cboMaNhaCC.SelectedValue.ToString(), txtKhoiLUong.Text, txtThoiGianBH.Text, txtGiaTien.Text, dtpNgaySanXuat.Value) == false)
					{
					MessageBox.Show("Sửa sản phẩm thành công!");
				}
				else
				{
					MessageBox.Show("Sửa sản phẩm thất bại!");
				}
			}
			loadData();
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


		private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvSanPham.CurrentCell.RowIndex;
				if (dgvSanPham.Rows[line].Cells[0].Value != DBNull.Value)
				{
					txtMaSanPham.Text = dgvSanPham.Rows[line].Cells[0].Value.ToString();
					txtTenSanPham.Text = dgvSanPham.Rows[line].Cells[1].Value.ToString();
					cboMaNhaSX.SelectedValue = dgvSanPham.Rows[line].Cells[2].Value.ToString();
					cboMaNhaCC.SelectedValue = dgvSanPham.Rows[line].Cells[3].Value.ToString();
					txtKhoiLUong.Text = dgvSanPham.Rows[line].Cells[4].Value.ToString();
					txtThoiGianBH.Text = dgvSanPham.Rows[line].Cells[5].Value.ToString();
					decimal giaTienValue = decimal.Parse(dgvSanPham.Rows[line].Cells[6].Value.ToString());
					txtGiaTien.Text = giaTienValue.ToString("F0");
					//lỗi xuất hiện e+0
					dtpNgaySanXuat.Value = Convert.ToDateTime(dgvSanPham.Rows[line].Cells[7].Value);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
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
				" ten_san_pham LIKE '%{0}%' OR " +
				" ma_nha_cung_cap LIKE '%{0}%' OR " +
				" ma_nha_san_xuat LIKE '%{0}%' OR " +
				" CONVERT(gia_tien, 'System.String') LIKE '%{0}%' OR " + // <-- Sửa ở đây
				" CONVERT(thoi_gian_bao_hanh, 'System.String') LIKE '%{0}%'", // <-- Sửa ở đây																			  
				safeKeyword);
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			clearData();
		}

		private void txtKhoiLUong_KeyPress(object sender, KeyPressEventArgs e)
		{
			// 1. Cho phép phím điều khiển (như Backspace)
			if (char.IsControl(e.KeyChar))
			{
				e.Handled = false;
				return;
			}

			// 2. Cho phép nhập số (0-9)
			if (char.IsDigit(e.KeyChar))
			{
				e.Handled = false;
				return;
			}

			// 3. Cho phép nhập MỘT dấu chấm (.)
			if (e.KeyChar == '.')
			{
				// Kiểm tra xem trong ô "txtKhoiLuong" đã có dấu '.' chưa
				// Dùng thẳng tên control, không dùng "sender"
				if (txtKhoiLUong.Text.Contains("."))
				{
					// Nếu ĐÃ CÓ, chặn không cho nhập thêm
					e.Handled = true;
				}
				else
				{
					// Nếu CHƯA CÓ, cho phép nhập
					e.Handled = false;
				}
				return;
			}

			// 4. Chặn tất cả các ký tự còn lại (như 'a', 'b', ',', '@')
			e.Handled = true;
		}

		private void txtThoiGianBH_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Chỉ cho phép nhập số (IsDigit) hoặc các phím điều khiển (IsControl) như Backspace
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // "Nuốt" ký tự đó, không cho nó hiển thị
			}
		}

		private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Chỉ cho phép nhập số (IsDigit) hoặc các phím điều khiển (IsControl) như Backspace
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // "Nuốt" ký tự đó, không cho nó hiển thị
			}
		}

	}
}

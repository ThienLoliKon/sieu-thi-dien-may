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

		public void loadData()
		{
			dgvSanPham.DataSource = bus.GetAllSanPhamAsTable();
		}

		public void clearData()
		{
			txtMaSanPham.Text = "";
			txtTenSanPham.Text = "";
			cboMaNhaSX.Text = "";
			cboMaNhaCC.Text = "";
			txtKhoiLUong.Text = "";
			a.Text = "";
			dtpNgaySanXuat.Value = DateTime.Now;
		}

		public void loadNhaSX()
		{
			//load nha san xuat
			NhaSXBUS busNhaSX = new NhaSXBUS();
			cboMaNhaSX.DataSource = busNhaSX.GetAllNhaCungCapAsTable();
			cboMaNhaSX.DisplayMember = "ten_nha_san_xuat";
			cboMaNhaSX.ValueMember = "ma_nha_san_xuat";
			cboMaNhaSX.SelectedIndex = -1;
		}

		public void loadNhaCC()
		{
			//load nha cung cap
			NhaCCBUS busNhaCC = new NhaCCBUS();
			cboMaNhaCC.DataSource = busNhaCC.GetAllNhaCungCapAsTable();
			cboMaNhaCC.DisplayMember = "ten_nha_cung_cap";
			cboMaNhaCC.ValueMember = "ma_nha_cung_cap";
			cboMaNhaCC.SelectedIndex = -1;
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
				HeaderText = "Gía tiền",
				DataPropertyName = "gia_tien",
				Width = 300,
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
		private void btnThem_Click(object sender, EventArgs e)
		{
			SanPhamBUS bus = new SanPhamBUS();
			if (txtGiaTien.Text.Length == 0 && txtTenSanPham.Text.Length == 0 && txtKhoiLUong.Text.Length == 0)
			{
				MessageBox.Show("Vui lòng nhập dữ liệu vào các ô trống");
			}
			bus.AddSanPham(txtTenSanPham.Text, cboMaNhaSX.SelectedValue.ToString(), cboMaNhaCC.SelectedValue.ToString(), txtKhoiLUong.Text, txtGiaTien.Text, dtpNgaySanXuat.Value);
			loadData();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			bus.UpdateSanPham(txtMaSanPham.Text, txtTenSanPham.Text, cboMaNhaSX.SelectedValue.ToString(), cboMaNhaCC.SelectedValue.ToString(), txtKhoiLUong.Text, txtGiaTien.Text, dtpNgaySanXuat.Value);
			loadData();
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvSanPham.CurrentCell.RowIndex;

				txtMaSanPham.Text = dgvSanPham.Rows[line].Cells[0].Value.ToString();
				txtTenSanPham.Text = dgvSanPham.Rows[line].Cells[1].Value.ToString();
				cboMaNhaSX.SelectedValue = dgvSanPham.Rows[line].Cells[2].Value.ToString();
				cboMaNhaCC.SelectedValue = dgvSanPham.Rows[line].Cells[3].Value.ToString();
				txtKhoiLUong.Text = dgvSanPham.Rows[line].Cells[4].Value.ToString();
				double giaTienValue = double.Parse( dgvSanPham.Rows[line].Cells[5].Value.ToString());
				//lỗi xuất hiện e+0
				txtGiaTien.Text = giaTienValue.ToString("F0");

				dtpNgaySanXuat.Value = Convert.ToDateTime(dgvSanPham.Rows[line].Cells[6].Value);
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{

		}
		public void checkGiaTien()
		{

			// Lưu lại vị trí con trỏ

			// Lọc chỉ giữ lại ký tự số
			string newText = new string(txtGiaTien.Text.Where(char.IsDigit).ToArray());

			if (txtGiaTien.Text != newText)
			{
				txtGiaTien.Text = newText;


			}
		}

		private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar))
			{
				MessageBox.Show("Chỉ được nhập số!");
				e.Handled = true; // Không cho nhập ký tự này
			}
			// Cho phép phím điều khiển như Backspace
			else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}
	}
}

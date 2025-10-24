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
		}

		public void loadNhaCC()
		{
			//load nha cung cap
			NhaCCBUS busNhaCC = new NhaCCBUS();
			cboMaNhaCC.DataSource = busNhaCC.GetAllNhaCungCapAsTable();
			cboMaNhaCC.DisplayMember = "ten_nha_cung_cap";
			cboMaNhaCC.ValueMember = "ma_nha_cung_cap";
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
			//MessageBox.Show($"{txtTenSanPham.Text}, {cboMaNhaSX.ValueMember}, {cboMaNhaCC.ValueMember}, {txtKhoiLUong.Text}, {txtGiaTien.Text}, {dtpNgaySanXuat.Value}");
			//Console.WriteLine(txtTenSanPham.Text, cboMaNhaSX.ValueMember, cboMaNhaCC.ValueMember, txtKhoiLUong.Text, txtGiaTien.Text, dtpNgaySanXuat.Value);
			SanPhamBUS bus = new SanPhamBUS();
			bus.AddSanPham(txtTenSanPham.Text,cboMaNhaSX.SelectedValue.ToString(),cboMaNhaCC.SelectedValue.ToString(),txtKhoiLUong.Text,txtGiaTien.Text,dtpNgaySanXuat.Value);
			loadData();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			bus.UpdateSanPham(txtMaSanPham.Text,txtTenSanPham.Text, cboMaNhaSX.SelectedValue.ToString(), cboMaNhaCC.SelectedValue.ToString(), txtKhoiLUong.Text, txtGiaTien.Text, dtpNgaySanXuat.Value);
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
				txtGiaTien.Text = dgvSanPham.Rows[line].Cells[5].Value.ToString();
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
	}
}

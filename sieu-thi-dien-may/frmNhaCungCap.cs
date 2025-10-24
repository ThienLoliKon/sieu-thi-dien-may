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
	public partial class frmNhaCungCap : Form
	{
		public frmNhaCungCap()
		{
			InitializeComponent();
		}

		NhaCCBUS bus = new NhaCCBUS();
		public void loadData()
		{
			dgvNhaCungCap.DataSource = bus.GetAllNhaCungCapAsTable();
		}
		private void frmNhaCungCap_Load(object sender, EventArgs e)
		{
			dgvNhaCungCap.AutoGenerateColumns = false;

			dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã nhà cung cấp",
				DataPropertyName = "ma_nha_cung_cap",
				Width = 300
			});

			dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Tên nhà cung cấp",
				DataPropertyName = "ten_nha_cung_cap",
				Width = 400
			});

			dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã nhà cung cấp",
				DataPropertyName = "dia_chi_nha_cung_cap",
				Width = 800
			});

			loadData();
		}
		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			bus.UpdateNhaCungCap(txtMaNCC.Text, txtTenNCC.Text, txtDiaChiNCC.Text);
			loadData();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			NhaCCBUS bus = new NhaCCBUS();
			bus.AddNhaCungCap(txtTenNCC.Text, txtDiaChiNCC.Text);
			loadData();

		}

		private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvNhaCungCap.CurrentCell.RowIndex;

				txtMaNCC.Text = dgvNhaCungCap.Rows[line].Cells[0].Value.ToString();
				txtTenNCC.Text = dgvNhaCungCap.Rows[line].Cells[1].Value.ToString();
				txtDiaChiNCC.Text = dgvNhaCungCap.Rows[line].Cells[2].Value.ToString();

			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		
	}
}

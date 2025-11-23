using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stdm
{
	public partial class frmConnectString : Form
	{
		public bool loadFormConnect;
		public frmConnectString(bool loadformConnect)
		{
			InitializeComponent();
			loadFormConnect = loadformConnect;
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			try
			{
				string server = txtServerName.Text.Trim();

				// Kiểm tra chọn chưa
				if (cboDatabaseName.SelectedIndex == -1)
				{
					MessageBox.Show("Chưa chọn Database!");
					return;
				}
				string dbName = cboDatabaseName.SelectedItem.ToString();

				// --- GỌI QUA BUS (ĐÚNG CHUẨN) ---
				ConnectBus bus = new ConnectBus();
				bus.updateConnectString(server, dbName);
				// --------------------------------

				MessageBox.Show("Lưu thành công! Ứng dụng sẽ khởi động lại.");
				//Application.Restart();
				//Environment.Exit(0);
				Login login = new Login();
				login.Show();
				this.Hide();
			}
			catch (Exception ex)
			{
				// Hứng lỗi từ BUS hoặc DLL ném lên
				MessageBox.Show(ex.Message);
			}

		}

		public void moFormLogIn()
		{
			if (string.IsNullOrEmpty(ConnectBus.getStringConnect()) == false)
			{
				// Đã có chuỗi kết nối rồi, load form Login luôn
				Login login = new Login();
				login.Show();
				this.Hide();
			}
		}

		private void frmConnectString_Load(object sender, EventArgs e)
		{
			if (loadFormConnect == true)
				return;
			moFormLogIn();
		}

		private void btnCheckConnect_Click(object sender, EventArgs e)
		{
			string server = txtServerName.Text.Trim();
			if (string.IsNullOrEmpty(server))
			{
				MessageBox.Show("Vui lòng nhập tên Server!", "Thông báo");
				return;
			}

			// Kết nối tạm vào 'master' để lấy danh sách
			string connString = $"Data Source={server};Initial Catalog=master;Integrated Security=True";

			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					// Lọc bớt mấy database hệ thống
					string sql = "SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";

					SqlCommand cmd = new SqlCommand(sql, conn);
					SqlDataReader dr = cmd.ExecuteReader();

					cboDatabaseName.Items.Clear();
					while (dr.Read())
					{
						cboDatabaseName.Items.Add(dr["name"].ToString());
					}
				}
				MessageBox.Show("Đã lấy danh sách Database!", "Thành công");
				if (cboDatabaseName.Items.Count > 0) cboDatabaseName.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không kết nối được Server: ", "Lỗi");
			}
		}



	}
}

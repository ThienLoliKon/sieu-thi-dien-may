using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Table = CrystalDecisions.CrystalReports.Engine.Table;

namespace stdm
{
	public partial class frmRPSanPhamTrongKhoTong : Form
	{
		public string makho;
		public ReportDocument rpt = new ReportDocument();
		public frmRPSanPhamTrongKhoTong(string mk)
		{
			InitializeComponent();
			this.makho = mk;
		}


		private void RPSanPhamTrongKhoTong1_InitReport(object sender, EventArgs e)
		{

		}

		private void frmRPSanPhamTrongKhoTong_Load(object sender, EventArgs e)
		{
			loadReport();
		}

		private void loadConnectionInfo()
		{
			try
			{
				// BƯỚC 1: Lấy chuỗi kết nối từ file Config (Gọi qua BUS hoặc DLL)
				// (Hàm này là hàm bạn đã viết ở bài trước để đọc file .txt/.ini)
				string fullConnectionString = BUS.ConnectBus.getStringConnect();

				// Kiểm tra nếu chưa có chuỗi kết nối
				if (string.IsNullOrEmpty(fullConnectionString))
				{
					MessageBox.Show("Chưa có cấu hình kết nối database!");
					return;
				}

				// BƯỚC 2: Dùng "Máy bóc tách" SqlConnectionStringBuilder
				// Nó sẽ tự động phân tích chuỗi "Data Source=...;Initial Catalog=..."
				SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(fullConnectionString);

				// BƯỚC 3: Gán thông tin đã bóc tách vào Crystal Report
				ConnectionInfo myConnectionInfo = new ConnectionInfo();

				// Lấy Server Name (Data Source)
				myConnectionInfo.ServerName = builder.DataSource;

				// Lấy Database Name (Initial Catalog)
				myConnectionInfo.DatabaseName = builder.InitialCatalog;

				// Xử lý đăng nhập (Windows hay SQL User)
				if (builder.IntegratedSecurity)
				{
					myConnectionInfo.IntegratedSecurity = true;
				}
				else
				{
					myConnectionInfo.IntegratedSecurity = false;
					myConnectionInfo.UserID = builder.UserID;
					myConnectionInfo.Password = builder.Password;
				}

				// BƯỚC 4: Áp dụng cho tất cả các bảng trong Report
				Tables tables = rpt.Database.Tables;
				foreach (Table table in tables)
				{
					TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
					tableLogOnInfo.ConnectionInfo = myConnectionInfo;
					table.ApplyLogOnInfo(tableLogOnInfo);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi cấu hình Report: " + ex.Message);
			}
		}



		private void loadReport()
		{
			string duongDanChay = Application.StartupPath;
			//string duongDanSolution = Directory.GetParent(duongDanChay).Parent.FullName;
			string tenFileReport = "RPSanPhamTrongKhoTong.rpt";
			string duongDanDayDu = Path.Combine(duongDanChay, tenFileReport);

			// (Kiểm tra cho chắc)
			if (!File.Exists(duongDanDayDu))
			{
				MessageBox.Show("Không tìm thấy file report ở: " + duongDanDayDu);
				return;
			}

			// Tải báo cáo
			rpt.Load(duongDanDayDu);
			loadConnectionInfo();


			//  Code của bạn
			rpt.SetParameterValue("MaKho", this.makho);
			cRPSPTrongKhoTong.ReportSource = rpt;
			cRPSPTrongKhoTong.Refresh();
		}





		private void RTKhachHangForm_Click(object sender, EventArgs e)
		{

		}

		private void cRPSPTrongKhoTong_Load(object sender, EventArgs e)
		{

		}
	}
}

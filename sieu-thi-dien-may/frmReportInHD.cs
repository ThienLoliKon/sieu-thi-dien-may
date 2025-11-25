using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
using System.Windows.Forms;

namespace stdm
{
	public partial class frmReportInHD : Form
	{
		ReportDocument rpt = new ReportDocument();

		private string maHoaDonCanIn; // Biến để lưu mã
		public frmReportInHD(string maHD)
		{
			InitializeComponent();
			this.maHoaDonCanIn = maHD; // Lưu mã được truyền vào
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

		private void testDebug()
		{
			// 1. Lấy thư mục đang chạy (là ...\bin\Debug)
			string duongDanChay = Application.StartupPath;

			// 2. Đi lùi 3 cấp thư mục để về thư mục Solution
			// Cấp 1: lùi từ Debug -> bin
			// Cấp 2: lùi từ bin -> [Tên_Project_GUI]
			// Cấp 3: lùi từ [Tên_Project_GUI] -> [Thư mục Solution]
			string duongDanSolution = Directory.GetParent(duongDanChay).FullName;

			// 3. Tên file report của bạn
			string tenFileReport = "rptInHoaDon.rpt";

			// 4. Ghép lại để có đường dẫn TUYỆT ĐỐI
			string duongDanDayDu = Path.Combine(Application.StartupPath, tenFileReport);

			// (Kiểm tra cho chắc)
			if (!File.Exists(duongDanDayDu))
			{
				MessageBox.Show("Không tìm thấy file report ở: " + duongDanDayDu);
				return;
			}

			// 5. Tải báo cáo
			rpt.Load(duongDanDayDu);
			loadConnectionInfo();

			// 6. Code của bạn
			rpt.SetParameterValue("MaHDParam", this.maHoaDonCanIn);
			crptViewInHD.ReportSource = rpt;
			crptViewInHD.Refresh();
			//MessageBox.Show(maHoaDonCanIn +"a");
		}

		private void frmReportInHD_Load(object sender, EventArgs e)
		{
			// TẤT CẢ CODE TẢI BÁO CÁO VIẾT Ở ĐÂY
			try
			{
				testDebug();

				//testExe();

			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message);
			}
		}


		private void testExe()
		{
			// Lấy đường dẫn thư mục chạy .exe
			string appPath = Application.StartupPath;

			// Tên file báo cáo của bạn
			string reportName = "HoaDonReport.rpt"; // <-- Thay bằng tên file .rpt thật của bạn

			// Ghép đường dẫn an toàn bằng Path.Combine
			string fullReportPath = Path.Combine(appPath, reportName);

			ReportDocument rpt = new ReportDocument();

			// Tải báo cáo bằng đường dẫn động
			rpt.Load(fullReportPath);

			// ... (Phần code SetParameterValue và gán ReportSource giữ nguyên) ...
			rpt.SetParameterValue("MaHoaDonParam", this.maHoaDonCanIn);
			crptViewInHD.ReportSource = rpt;
			crptViewInHD.Refresh();
		}
	}
}

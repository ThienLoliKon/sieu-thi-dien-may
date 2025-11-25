using BUS;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stdm
{
	public partial class frmReportDoanhThuChiNhanh : Form
	{
		public ReportDocument rpt = new ReportDocument();
		public frmReportDoanhThuChiNhanh()
		{
			InitializeComponent();
		}

		private void crptViewDoanhThuChiNhanh_Load(object sender, EventArgs e)
		{
			// Cài đặt mặc định: Từ ngày 1 tháng này đến hôm nay
			DateTime now = DateTime.Now;
			dtpNgayBatDau.Value = new DateTime(now.Year, now.Month, 1);
			dtpNgayKetThuc.Value = now;
			testDebug();
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
			string duongDanSolution = Directory.GetParent(duongDanChay).FullName;

			// 3. Tên file report của bạn
			string tenFileReport = "rptDoanhThuChiNhanh.rpt";

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
			rpt.SetParameterValue("BatDau", dtpNgayBatDau.Value);
			rpt.SetParameterValue("KetThuc", dtpNgayKetThuc.Value);

			crptViewDoanhThuChiNhanh.ReportSource = rpt;
			crptViewDoanhThuChiNhanh.Refresh();
			//MessageBox.Show(maHoaDonCanIn +"a");
		}
		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			try
			{
				if (CheckTestCase.checkValidDateInOut(dtpNgayBatDau.Value, dtpNgayKetThuc.Value) == false)
				{
					MessageBox.Show("Ngày kết thúc phải sau hoặc bằng ngày bắt đầu!");
					return;
				}

				testDebug();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
		}
	}
}

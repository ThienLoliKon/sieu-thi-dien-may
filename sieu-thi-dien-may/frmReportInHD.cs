using CrystalDecisions.CrystalReports.Engine;
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

namespace stdm
{
	public partial class frmReportInHD : Form
	{
		private string maHoaDonCanIn; // Biến để lưu mã
		public frmReportInHD(string maHD)
		{
			InitializeComponent();
			this.maHoaDonCanIn = maHD; // Lưu mã được truyền vào
		}

		private void testDebug()
		{
			// 1. Lấy thư mục đang chạy (là ...\bin\Debug)
			string duongDanChay = Application.StartupPath;

			// 2. Đi lùi 3 cấp thư mục để về thư mục Solution
			// Cấp 1: lùi từ Debug -> bin
			// Cấp 2: lùi từ bin -> [Tên_Project_GUI]
			// Cấp 3: lùi từ [Tên_Project_GUI] -> [Thư mục Solution]
			string duongDanSolution = Directory.GetParent(duongDanChay).Parent.Parent.FullName;

			// 3. Tên file report của bạn
			string tenFileReport = "rptInHoaDon.rpt";

			// 4. Ghép lại để có đường dẫn TUYỆT ĐỐI
			string duongDanDayDu = Path.Combine(duongDanSolution, tenFileReport);

			// (Kiểm tra cho chắc)
			if (!File.Exists(duongDanDayDu))
			{
				MessageBox.Show("Không tìm thấy file report ở: " + duongDanDayDu);
				return;
			}

			// 5. Tải báo cáo
			ReportDocument rpt = new ReportDocument();
			rpt.Load(duongDanDayDu);

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

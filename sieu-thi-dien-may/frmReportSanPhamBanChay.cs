using BUS;
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
	public partial class frmReportSanPhamBanChay : Form
	{
		public frmReportSanPhamBanChay()
		{
			InitializeComponent();
		}
		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			try
			{
				if(CheckTestCase.checkValidDateInOut(dtpNgayBatDau.Value, dtpNgayKetThuc.Value) == false)
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
			string tenFileReport = "rptTopSanPhamBanChay.rpt";

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
			rpt.SetParameterValue("BatDau",dtpNgayBatDau.Value); 
			rpt.SetParameterValue("KetThuc",dtpNgayKetThuc.Value);

			crptViewSanPhamBanChay.ReportSource = rpt;
			crptViewSanPhamBanChay.Refresh();
			//MessageBox.Show(maHoaDonCanIn +"a");
		}

		private void frmReportSanPhamBanChay_Load(object sender, EventArgs e)
		{
			// Cài đặt mặc định: Từ ngày 1 tháng này đến hôm nay
			DateTime now = DateTime.Now;
			dtpNgayBatDau.Value = new DateTime(now.Year, now.Month, 1);
			dtpNgayKetThuc.Value = now;
			testDebug();
		}
	}
}

using BUS;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace stdm
{
    public partial class frmInLoiViPham1NV : Form
    {
        private string _maNV;
        ReportDocument rpt = new ReportDocument();
        public frmInLoiViPham1NV(string maNV)
        {
            InitializeComponent();
            _maNV = maNV;
        }
        private void loadConnectionInfo()
        {
            ConnectionInfo myConnectionInfo = new ConnectionInfo();
            myConnectionInfo.ServerName = @".\SQLEXPRESS";
            myConnectionInfo.DatabaseName = "dien_may";
            myConnectionInfo.IntegratedSecurity = true;

            Tables tables = rpt.Database.Tables;
            foreach (Table table in tables)
            {
                TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                tableLogOnInfo.ConnectionInfo = myConnectionInfo;
                table.ApplyLogOnInfo(tableLogOnInfo);
            }
        }

        private void frmInLoiViPham1NV_Load(object sender, EventArgs e)
        {
            // 1. Lấy thư mục đang chạy (là ...\bin\Debug)
            string duongDanChay = Application.StartupPath;
            string duongDanSolution = Directory.GetParent(duongDanChay).Parent.FullName;

            // 3. Tên file report của bạn
            string tenFileReport = "rptViPhamNhanVien.rpt";

            // 4. Ghép lại để có đường dẫn TUYỆT ĐỐI
            string duongDanDayDu = Path.Combine(duongDanSolution, tenFileReport);

            // (Kiểm tra cho chắc)
            if (!File.Exists(duongDanDayDu))
            {
                MessageBox.Show("Không tìm thấy file report ở: " + duongDanDayDu);
                return;
            }

            // 5. Tải báo cáo
            rpt.Load(duongDanDayDu);
            loadConnectionInfo();
            rpt.SetParameterValue("MaNV", this._maNV);


            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}

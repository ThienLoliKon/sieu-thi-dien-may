using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stdm
{
    public partial class PhieuLuong : Form
    {
        public PhieuLuong()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void InPhieuLuong_Direct(string maNV)
        {
            try
            {
                ReportDocument rpt = new ReportDocument();
                string path = Application.StartupPath + @"\rptPhieuLuong.rpt";

                if (!System.IO.File.Exists(path))
                {
                    MessageBox.Show("Không tìm thấy file báo cáo: " + path);
                    return;
                }

                rpt.Load(path);

                Form frm = new Form();
                var viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer
                {
                    Dock = DockStyle.Fill,
                    ReportSource = rpt
                };
                frm.Controls.Add(viewer);
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in phiếu lương: " + ex.Message);
            }
        }


        private void btnIn_Click(object sender, EventArgs e)
        {
            string maNV = this.Controls["txtIn"].Text.Trim();
            

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.");
                return;
            }

            InPhieuLuong_Direct(maNV);
        }
    }
}

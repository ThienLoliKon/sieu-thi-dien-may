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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace stdm
{
    public partial class frmRPSanPhamTrongKhoTong : Form
    {
        public string makho;
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
            ReportDocument rpt = new ReportDocument();
            rpt.Load("rptSanPhamTrongKhoTong.rpt");
            rpt.SetParameterValue("MaKho", this.makho);
            cRPSPTrongKhoTong.ReportSource = rpt;
        }

        private void RTKhachHangForm_Click(object sender, EventArgs e)
        {

        }

        private void cRPSPTrongKhoTong_Load(object sender, EventArgs e)
        {

        }
    }
}

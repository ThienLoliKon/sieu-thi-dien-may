using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CapBacNhanVienBUS
    {
        private CapBacNhanVienDLL dal;

        public CapBacNhanVienBUS()
        {
            dal = new CapBacNhanVienDLL();
        }

        public List<cap_bac_nhan_vien> GetAllCapBacNV()
        {
            return dal.GetAllCapBacNhanVien();
        }

        public bool AddCapBacNV(string tencb, string motacb)
        {
            cap_bac_nhan_vien capbacnv = new cap_bac_nhan_vien();

            capbacnv.ma_cap_bac = dal.TaoMaCapBacNhanVien();
            capbacnv.ten_cap_bac = tencb;
            capbacnv.mo_ta_cap_bac = motacb;

            dal.AddCapBacNhanVien(capbacnv);

            if (dal.check(capbacnv.ma_cap_bac) == true) { return true; }
            return false; 
        }

        public bool DeleteCapBacNV(string id)
        {
            dal.DeleteCapBacNhanVien(id);
            if (dal.check(id) == false) { return true; }
            return false; 
        }

        public bool UpdateCapBacNVstring(string macb, string tencb, string motacb)
        {
            cap_bac_nhan_vien capbacnv = new cap_bac_nhan_vien();

            capbacnv.ma_cap_bac = macb;
            capbacnv.ten_cap_bac = tencb;
            capbacnv.mo_ta_cap_bac = motacb;

            dal.UpdateCapBacNhanVien(capbacnv);

            if (dal.check(capbacnv.ma_cap_bac) == true) { return true; }
            return false; 
        }

        public DataTable timCapBacNV(string keyword)
        {
            List<cap_bac_nhan_vien> capbacnvs = dal.SearchCapBacNhanVien(keyword);
            if (capbacnvs == null || capbacnvs.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaCB", typeof(string));
            dt.Columns.Add("TenCB", typeof(string));
            dt.Columns.Add("MoTaCB", typeof(string));
            foreach (var tk in capbacnvs)
            {
                dt.Rows.Add(tk.ma_cap_bac, tk.ten_cap_bac, tk.mo_ta_cap_bac);
            }
            return dt;
        }

        public DataTable GetAllCapBacNVAsTable()
        {
            List<cap_bac_nhan_vien> capbacnvs = dal.GetAllCapBacNhanVien();

            if (capbacnvs == null || capbacnvs.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaCB", typeof(string));
            dt.Columns.Add("TenCB", typeof(string));
            dt.Columns.Add("MoTaCB", typeof(string));
            foreach (var tk in capbacnvs)
            {
                dt.Rows.Add(tk.ma_cap_bac, tk.ten_cap_bac, tk.mo_ta_cap_bac);
            }
            return dt;
        }
    }
}
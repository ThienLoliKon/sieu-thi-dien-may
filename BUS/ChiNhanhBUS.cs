using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiNhanhBUS
    {
        private ChiNhanhDLL chinhanhdll = new ChiNhanhDLL();

        public ChiNhanhBUS()
        {
            
        }
        public class ChiNhanh
        {
            public string machinhanh { get; set; }
            public string tenchinhanh { get; set; }
            public string diachi { get; set; }
            public string khuvuc { get; set; }

            public ChiNhanh()
            {
                this.machinhanh = "";
                this.tenchinhanh = "";
                this.diachi = "";
                this.khuvuc = "";
            }
        }

        public List<chi_nhanh> GetAllChiNhanh()
        {
            return chinhanhdll.GetAllChiNhanh();
        }

        public bool AddChiNhanh(ChiNhanh cn)
        {
            chi_nhanh chinhanh = new chi_nhanh();

            chinhanh.ma_chi_nhanh = chinhanhdll.TaoMaChiNhanh();
            chinhanh.ten_chi_nhanh = cn.tenchinhanh;
            chinhanh.dia_chi = cn.diachi;
            chinhanh.khu_vuc = cn.khuvuc;

            chinhanhdll.AddChiNhanh(chinhanh);

            if (chinhanhdll.check(chinhanh.ma_chi_nhanh) == true) { return true; }
            return false;
        }
        public string createMaChiNhanh()
        {
            var chinhanhcuoicung = chinhanhdll.GetAllChiNhanh().LastOrDefault();
            if (chinhanhcuoicung != null)
            {
                string makhcuoicung = chinhanhcuoicung.ma_chi_nhanh;
                int so = int.Parse(makhcuoicung.Substring(2)) + 1;
                return "CN" + so.ToString();
            }
            else
            {
                return "CN10000001";
            }
        }

        public bool DeleteChiNhanh(string id)
        {
            chinhanhdll.DeleteChiNhanh(id);
            if (chinhanhdll.check(id) == false) { return true; }
            return false;
        }

        public bool UpdateChiNhanhstring(string maCN, string tenchinhanh, string diachi, string khuvuc)
        {
            chi_nhanh chinhanh = new chi_nhanh();

            chinhanh.ma_chi_nhanh = maCN; 
            chinhanh.ten_chi_nhanh = tenchinhanh;
            chinhanh.dia_chi = diachi;
            chinhanh.khu_vuc = khuvuc;

            try
            {
                chinhanhdll.UpdateChiNhanh(chinhanh);
                if (chinhanhdll.check(chinhanh.ma_chi_nhanh) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable timChiNhanh(string keyword)
        {
            List<chi_nhanh> chinhanhs = chinhanhdll.SearchChiNhanh(keyword);
            if (chinhanhs == null || chinhanhs.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaChiNhanh", typeof(string));
            dt.Columns.Add("TenChiNhanh", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("KhuVuc", typeof(string));
            foreach (var nv in chinhanhs)
            {
                dt.Rows.Add(nv.ma_chi_nhanh , nv.ten_chi_nhanh, nv.dia_chi, nv.khu_vuc);
            }
            return dt;
        }

        public DataTable GetAllChiNhanhAsTable()
        {
            List<chi_nhanh> chinhanhs = chinhanhdll.GetAllChiNhanh();

            if (chinhanhs == null || chinhanhs.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaCN", typeof(string));
            dt.Columns.Add("TenCN", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("KhuVuc", typeof(string));
            foreach (var nv in chinhanhs)
            {
                dt.Rows.Add(nv.ma_chi_nhanh , nv.ten_chi_nhanh, nv.dia_chi, nv.khu_vuc);
            }
            return dt;
        }
    }
}
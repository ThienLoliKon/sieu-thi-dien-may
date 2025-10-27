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
        private ChiNhanhDLL dal;

        public ChiNhanhBUS()
        {
            dal = new ChiNhanhDLL();
        }

        public List<chi_nhanh> GetAllChiNhanh()
        {
            return dal.GetAllChiNhanh();
        }

        public bool AddChiNhanh(string tenchinhanh, string diachi, string khuvuc)
        {
            chi_nhanh chinhanh = new chi_nhanh();

            chinhanh.ma_chi_nhanh = dal.TaoMaChiNhanh();
            chinhanh.ten_chi_nhanh = tenchinhanh;
            chinhanh.dia_chi = diachi;
            chinhanh.khu_vuc = khuvuc;

            dal.AddChiNhanh(chinhanh);

            if (dal.check(chinhanh.ma_chi_nhanh) == true) { return true; }
            return false;
        }

        public bool DeleteChiNhanh(string id)
        {
            dal.DeleteChiNhanh(id);
            if (dal.check(id) == false) { return true; }
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
                dal.UpdateChiNhanh(chinhanh);
                if (dal.check(chinhanh.ma_chi_nhanh) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable timChiNhanh(string keyword)
        {
            List<chi_nhanh> chinhanhs = dal.SearchChiNhanh(keyword);
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
                dt.Rows.Add(nv.ma_chi_nhanh, nv.ten_chi_nhanh, nv.dia_chi, nv.khu_vuc);
            }
            return dt;
        }

        public DataTable GetAllChiNhanhAsTable()
        {
            List<chi_nhanh> chinhanhs = dal.GetAllChiNhanh();

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
                dt.Rows.Add(nv.ma_chi_nhanh, nv.ten_chi_nhanh, nv.dia_chi, nv.khu_vuc);
            }
            return dt;
        }
    }
}
using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDLL dal;

        public TaiKhoanBUS()
        {
            dal = new TaiKhoanDLL();
        }

        public List<tai_khoan> GetAllTaiKhoan()
        {
            return dal.GetAllTaiKhoan();
        }

        public bool AddTaiKhoan(string maNV, string matKhau, string quyen)
        {
            tai_khoan taikhoan = new tai_khoan();

            taikhoan.ma_nhan_vien = maNV; 
            taikhoan.mat_khau = matKhau;
            taikhoan.quyen = quyen;

            dal.AddTaikhoan(taikhoan);

            if (dal.check(taikhoan.ma_nhan_vien) == true) { return true; }
            return false;
        }

        public bool DeleteTaiKhoan(string id)
        {
            dal.DeleteTaiKhoan(id);
            if (dal.check(id) == false) { return true; }
            return false;
        }

        public bool UpdateTaiKhoanstring(string maNV, string matKhau, string quyen)
        {
            tai_khoan taikhoan = new tai_khoan();

            taikhoan.ma_nhan_vien = maNV;
            taikhoan.mat_khau = matKhau;
            taikhoan.quyen = quyen;

            dal.UpdateTaiKhoan(taikhoan);

            if (dal.check(taikhoan.ma_nhan_vien) == true) { return true; }
            return false;
        }
        public DataTable timTaiKhoan(string keyword)
        {
            List<tai_khoan> taikhoans = dal.SearchTaiKhoan(keyword);
            if (taikhoans == null || taikhoans.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("MatKhau", typeof(string));
            dt.Columns.Add("Quyen", typeof(string));
            foreach (var tk in taikhoans)
            {
                dt.Rows.Add(tk.ma_nhan_vien, tk.mat_khau, tk.quyen);
            }
            return dt;
        }

        public DataTable GetAllTaiKhoanAsTable()
        {
            List<tai_khoan> taikhoans = dal.GetAllTaiKhoan(); 

            if (taikhoans == null || taikhoans.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("MatKhau", typeof(string));
            dt.Columns.Add("Quyen", typeof(string));
            foreach (var tk in taikhoans)
            {
                dt.Rows.Add(tk.ma_nhan_vien, tk.mat_khau, tk.quyen);
            }
            return dt;
        }
    }
}

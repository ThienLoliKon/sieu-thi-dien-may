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

        // ĐÃ SỬA: AddTaiKhoan phải nhận maNV từ GUI (ComboBox Nhân viên)
        public bool AddTaiKhoan(string maNV, string matKhau, string quyen)
        {
            tai_khoan taikhoan = new tai_khoan();

            taikhoan.ma_nhan_vien = maNV; // Nhận mã NV từ tham số
            taikhoan.mat_khau = matKhau;
            taikhoan.quyen = quyen;

            dal.AddTaikhoan(taikhoan);

            // SỬA LỖI LOGIC: Nếu tồn tại (check=true) sau khi thêm, nghĩa là thêm thành công.
            if (dal.check(taikhoan.ma_nhan_vien) == true) { return true; }
            return false;
        }

        public bool DeleteTaiKhoan(string id)
        {
            dal.DeleteTaiKhoan(id);
            // LOGIC NÀY ĐÚNG cho XÓA CỨNG: Nếu không tồn tại (check=false) sau khi gọi DAL, nghĩa là xóa thành công.
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

            // SỬA LỖI LOGIC: Nếu tồn tại (check=true) sau khi cập nhật, nghĩa là cập nhật thành công.
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
            List<tai_khoan> taikhoans = dal.GetAllTaiKhoan(); // Kiểm tra danh sách từ DAL

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

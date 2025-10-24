using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienBUS
    {
        private NhanVienDLL dal;

        public NhanVienBUS()
        {
            dal = new NhanVienDLL();
        }

        public List<nhan_vien> GetAllNhanVien()
        {
            return dal.GetAllNhanVien();
        }

        public bool AddNhanVien(string tenNV, string macapbac, string sdt, string diachi, string machinhanh, string trangthai)
        {
            nhan_vien nhanvien = new nhan_vien();

            nhanvien.ma_nhan_vien = dal.TaoMaNhanVien();
            nhanvien.ho_va_ten = tenNV;
            nhanvien.ma_cap_bac = macapbac;
            nhanvien.so_dien_thoai = sdt;
            nhanvien.dia_chi_thuong_tru = diachi;
            nhanvien.ma_chi_nhanh = machinhanh;
            nhanvien.trang_thai = trangthai == "1" || trangthai.ToLower() == "true";
            dal.AddNhanVien(nhanvien);

            // SỬA LỖI LOGIC: Nếu tồn tại (check=true) sau khi thêm, nghĩa là thêm thành công.
            if (dal.check(nhanvien.ma_nhan_vien) == true) { return true; }
            return false;
        }

        public bool DeleteNhanVien(string id)
        {
            try
            {
                // Gọi Soft Delete trong DAL
                dal.DeleteNhanVien(id);

                // SỬA LỖI LOGIC: Nếu bản ghi vẫn tồn tại (check=true), Soft Delete đã thành công.
                if (dal.check(id) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateNhanVienstring(string manv, string tenNV, string macapbac, string sdt, string diachi, string machinhanh, string trangthai)
        {
            nhan_vien nhanvien = new nhan_vien();

            nhanvien.ma_nhan_vien = manv;
            nhanvien.ho_va_ten = tenNV;
            nhanvien.ma_cap_bac = macapbac;
            nhanvien.so_dien_thoai = sdt;
            nhanvien.dia_chi_thuong_tru = diachi;
            nhanvien.ma_chi_nhanh = machinhanh;
            // Đã đơn giản hóa logic gán trang_thai
            nhanvien.trang_thai = trangthai == "1" || trangthai.ToLower() == "true";

            try
            {
                dal.UpdateNhanVien(nhanvien);
                return true; // Nếu DAL không ném Exception, cập nhật thành công.
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable timNhanVien(string keyword)
        {
            List<nhan_vien> nhanviens = dal.SearchNhanVien(keyword);
            if (nhanviens == null || nhanviens.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("TenNV", typeof(string));
            dt.Columns.Add("MaCB", typeof(string));
            dt.Columns.Add("SDT", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("MaChiNhanh", typeof(string)); // Cột này cần Mã
            dt.Columns.Add("TrangThai", typeof(string));

            foreach (var nv in nhanviens)
            {
                // SỬA LỖI: Sử dụng nv.ma_chi_nhanh thay vì nv.chi_nhanh
                dt.Rows.Add(nv.ma_nhan_vien, nv.ho_va_ten, nv.ma_cap_bac, nv.so_dien_thoai, nv.dia_chi_thuong_tru, nv.ma_chi_nhanh, nv.trang_thai);
            }
            return dt;
        }

        public DataTable GetAllNhanVienAsTable()
        {
            List<nhan_vien> nhanviens = dal.GetAllNhanVien();

            if (nhanviens == null || nhanviens.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("TenNV", typeof(string));
            dt.Columns.Add("MaCB", typeof(string));
            dt.Columns.Add("SDT", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("MaChiNhanh", typeof(string)); // Cột này cần Mã
            dt.Columns.Add("TrangThai", typeof(string));

            foreach (var nv in nhanviens)
            {
                // SỬA LỖI: Sử dụng nv.ma_chi_nhanh thay vì nv.chi_nhanh
                dt.Rows.Add(nv.ma_nhan_vien, nv.ho_va_ten, nv.ma_cap_bac, nv.so_dien_thoai, nv.dia_chi_thuong_tru, nv.ma_chi_nhanh, nv.trang_thai);
            }
            return dt;
        }
    }
}
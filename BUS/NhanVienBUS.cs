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

            if (dal.check(nhanvien.ma_nhan_vien) == true) { return true; }
            return false;
        }

        public bool DeleteNhanVien(string id)
        {
            try
            {
                dal.DeleteNhanVien(id);

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
            nhanvien.trang_thai = trangthai == "1" || trangthai.ToLower() == "true";

            try
            {
                dal.UpdateNhanVien(nhanvien);
                return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }
		public string timChiNhanhByMaNhanVien(string keyword)
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
			dt.Columns.Add("MaChiNhanh", typeof(string));
			dt.Columns.Add("TrangThai", typeof(string));

			foreach (var nv in nhanviens)
			{
				string chiNhanh = nv.ma_chi_nhanh;

				return chiNhanh;
			}
			return null;
		}

		public string timQuyenByMaNhanVien(string keyword)
		{
			List<nhan_vien> nhanviens = dal.SearchNhanVien(keyword);
			if (nhanviens == null || nhanviens.Count == 0)
			{
				return null;
			}

			foreach (var nv in nhanviens)
			{
				string chiNhanh = nv.ma_cap_bac;

				return chiNhanh;
			}
			return null;
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
            dt.Columns.Add("MaChiNhanh", typeof(string)); 
            dt.Columns.Add("TrangThai", typeof(string));

            foreach (var nv in nhanviens)
            {
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
            dt.Columns.Add("MaChiNhanh", typeof(string)); 
            dt.Columns.Add("TrangThai", typeof(string));

            foreach (var nv in nhanviens)
            {
                dt.Rows.Add(nv.ma_nhan_vien, nv.ho_va_ten, nv.ma_cap_bac, nv.so_dien_thoai, nv.dia_chi_thuong_tru, nv.ma_chi_nhanh, nv.trang_thai);
            }
            return dt;
        }
        public string getNameNV(string manv)
        {
            var nhanviens = dal.GetAllNhanVien();
            foreach (var nv in nhanviens)
            {
                if(nv.ma_nhan_vien.Trim() == manv.Trim())
                {
                    return nv.ho_va_ten;
                }
            }
            return null;
        }
    }
}
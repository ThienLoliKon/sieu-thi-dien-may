using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class NhanVienDLL
    {
        private DBSTDMDataContext db;

        public NhanVienDLL()
        {
            db = new DBSTDMDataContext();
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<nhan_vien> GetAllNhanVien()
        {
            using (DBSTDMDataContext freshDb = new DBSTDMDataContext())
            {
                return freshDb.nhan_viens.ToList();
            }
        }

        public void AddNhanVien(nhan_vien NV)
        {
            db.nhan_viens.InsertOnSubmit(NV);
            db.SubmitChanges();
        }

        public void DeleteNhanVien(string id)
        {
            var nhanvien = db.nhan_viens.SingleOrDefault(p => p.ma_nhan_vien == id);

            if (nhanvien == null)
            {
                throw new Exception($"Không tìm thấy nhân viên với ID: {id}");
            }

            nhanvien.trang_thai = false;

            db.SubmitChanges();
        }



        public void UpdateNhanVien(nhan_vien updateKhachHang)
        {
            var result = db.nhan_viens.SingleOrDefault(kh => kh.ma_nhan_vien == updateKhachHang.ma_nhan_vien);
            if (result != null)
            {
                result.ho_va_ten = updateKhachHang.ho_va_ten;
                result.ma_cap_bac = updateKhachHang.ma_cap_bac;
                result.so_dien_thoai = updateKhachHang.so_dien_thoai;
                result.dia_chi_thuong_tru = updateKhachHang.dia_chi_thuong_tru;
                result.ma_chi_nhanh = updateKhachHang.ma_chi_nhanh;
                result.trang_thai = updateKhachHang.trang_thai;
                db.SubmitChanges();
            }
        }

        public string TaoMaNhanVien()
        {
            var maNhanViens = db.nhan_viens.Select(p => p.ma_nhan_vien).ToList();

            int maxId = 0;

            if (maNhanViens.Any()) // Kiểm tra nếu có dữ liệu
            {
                maxId = maNhanViens
                            .Where(m => m.StartsWith("NV")) // Lọc các mã bắt đầu bằng "TG"
                            .Select(m => int.Parse(m.Substring(2))) // Lấy phần số sau "TG"
                            .Max(); // Lấy giá trị lớn nhất
            }

            // Tăng giá trị ID lớn nhất
            maxId++;

            // Tạo mã mới với tiền tố "TG" và đảm bảo đúng định dạng
            return "NV" + maxId.ToString("D3");
        }
        public List<nhan_vien> SearchNhanVien(string keyword)
        {
            return db.nhan_viens
                .Where(nhanvien => nhanvien.ma_nhan_vien.Contains(keyword) || nhanvien.ho_va_ten.Contains(keyword) || nhanvien.ma_cap_bac.Contains(keyword) || nhanvien.so_dien_thoai.Contains(keyword) || nhanvien.dia_chi_thuong_tru.Contains(keyword) || nhanvien.ma_chi_nhanh.Contains(keyword) )
                .ToList();
        }
		public nhan_vien GetNhanVienByMaNV(string maNV)
		{
			// Dùng Trim() để xóa dấu cách của kiểu CHAR
			return db.nhan_viens.SingleOrDefault(nv => nv.ma_nhan_vien.Trim() == maNV.Trim());
		}
		public bool check(string id)
        {
            return db.nhan_viens.Any(p => p.ma_nhan_vien == id);
        }
    }
}

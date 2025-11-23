using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class TaiKhoanDLL
    {
        private DBSTDMDataContext db;
		public TaiKhoanDLL()
        {
            db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

		public List<tai_khoan> GetAllTaiKhoan()
        {
            using (DBSTDMDataContext freshDb = new DBSTDMDataContext(ConnectDLL.ReadConnectionString()))
            {
                return freshDb.tai_khoans.ToList();
            }
        }

        public void AddTaikhoan(tai_khoan TK)
        {
            db.tai_khoans.InsertOnSubmit(TK);
            db.SubmitChanges();
        }

        public void DeleteTaiKhoan(string id)
        {
            var taikhoan = db.tai_khoans.SingleOrDefault(p => p.ma_nhan_vien == id);

            if (taikhoan == null)
            {
                throw new Exception($"Không tìm thấy tài khoản với ID: {id}");
            }
            db.tai_khoans.DeleteOnSubmit(taikhoan);
            db.SubmitChanges();
        }

        public void UpdateTaiKhoan(tai_khoan updateTaiKhoan)
        {
            var result = db.tai_khoans.SingleOrDefault(tk => tk.ma_nhan_vien == updateTaiKhoan.ma_nhan_vien);
            if (result != null)
            {
                result.mat_khau = updateTaiKhoan.mat_khau;
                result.quyen = updateTaiKhoan.quyen;
                db.SubmitChanges();
            }
        }

		// Trong file TaiKhoanDLL.cs
		public bool KiemTraDangNhap(string maNV, string matKhau)
		{
			using (DBSTDMDataContext db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString()))
			{
				// Vệ sinh dữ liệu đầu vào
				string maNhanVien = maNV.Trim();
				string matKhauNhanVien = matKhau.Trim();

				// Dùng Any() để kiểm tra sự tồn tại (Trả về True/False)
				// Lưu ý: Dùng Trim() trong LINQ để đảm bảo so sánh chính xác với kiểu char trong DB
				bool ketQua = db.tai_khoans.Any(tk => tk.ma_nhan_vien.Trim() == maNhanVien
												   && tk.mat_khau.Trim() == matKhauNhanVien);
				return ketQua;
			}
		}

		public List<tai_khoan> SearchTaiKhoan(string keyword)
        {
            return db.tai_khoans
                .Where(taikhoan => taikhoan.ma_nhan_vien.Contains(keyword) || taikhoan.mat_khau.Contains(keyword) || taikhoan.quyen.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            return db.tai_khoans.Any(p => p.ma_nhan_vien == id);
        }
    }
}
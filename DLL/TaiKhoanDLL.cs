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
            db = new DBSTDMDataContext();
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<tai_khoan> GetAllTaiKhoan()
        {
            return db.tai_khoans.ToList();
        }

        public void AddTaikhoan(tai_khoan TK)
        {
            // TK.ma_nhan_vien phải được cung cấp từ BUS/GUI
            db.tai_khoans.InsertOnSubmit(TK);
            db.SubmitChanges();
        }

        public void DeleteTaiKhoan(string id)
        {
            var taikhoan = db.tai_khoans.SingleOrDefault(p => p.ma_nhan_vien == id);

            if (taikhoan == null)
            {
                // SỬA LỖI: Báo cáo đúng đối tượng không tìm thấy
                throw new Exception($"Không tìm thấy tài khoản với ID: {id}");
            }
            db.tai_khoans.DeleteOnSubmit(taikhoan);
            db.SubmitChanges();
        }

        public void UpdateTaiKhoan(tai_khoan updateTaiKhoan)
        {
            // SỬA LỖI: Đổi tên biến lambda thành 'tk'
            var result = db.tai_khoans.SingleOrDefault(tk => tk.ma_nhan_vien == updateTaiKhoan.ma_nhan_vien);
            if (result != null)
            {
                result.mat_khau = updateTaiKhoan.mat_khau;
                result.quyen = updateTaiKhoan.quyen;
                db.SubmitChanges();
            }
        }

        // ĐÃ XÓA: Loại bỏ hàm TaoMaTaiKhoan() vì nó vi phạm ràng buộc FK (ma_nhan_vien)

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
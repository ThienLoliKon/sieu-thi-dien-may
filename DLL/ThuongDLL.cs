using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class ThuongDLL // Tên lớp chính xác
    {
        private DBSTDMDataContext db;

        // KHẮC PHỤC LỖI: Sửa tên constructor từ NhanVienDLL() thành ThuongDLL()
        public ThuongDLL()
        {
            db = new DBSTDMDataContext();
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }
        public double LayMucThuong(string maLT)
        {
            using (var db = new DBSTDMDataContext())
            {
                return db.loai_thuongs
                    .Where(lt => lt.ma_loai_thuong == maLT)
                    .Select(lt => lt.muc_thuong)
                    .FirstOrDefault() ?? 0;
            }
        }

        public List<thuong> GetAllThuong()
        {
            using (DBSTDMDataContext freshDb = new DBSTDMDataContext())
            {
                return freshDb.thuongs.ToList();
            }
        }

        public void AddThuong(thuong T)
        {
            db.thuongs.InsertOnSubmit(T);
            db.SubmitChanges();
        }

        public void DeleteThuong(string id)
        {
            // Tìm kiếm theo ma_thuong
            var thuong = db.thuongs.SingleOrDefault(p => p.ma_thuong == id);

            if (thuong == null)
            {
                // Sửa thông báo lỗi
                throw new Exception($"Không tìm thấy phiếu thưởng với Mã: {id}");
            }

            // Xóa cứng (Hard Delete)
            db.thuongs.DeleteOnSubmit(thuong);
            db.SubmitChanges();
        }

        public void UpdateThuong(thuong updateThuong) // Đổi tên tham số
        {
            // Tìm kiếm theo ma_thuong
            var result = db.thuongs.SingleOrDefault(t => t.ma_thuong == updateThuong.ma_thuong);

            if (result != null)
            {
                // Cập nhật các trường của bảng thuong
                result.ma_nhan_vien = updateThuong.ma_nhan_vien;
                result.ma_loai_thuong = updateThuong.ma_loai_thuong;
                result.trang_thai = updateThuong.trang_thai;
                result.thoi_gian_thuong = updateThuong.thoi_gian_thuong;
                db.SubmitChanges();
            }
        }

        public string TaoMaThuong()
        {
            // Logic tạo mã Txxx
            var maThuongs = db.thuongs.Select(p => p.ma_thuong).ToList();

            int maxId = 0;
            if (maThuongs.Any())
            {
                maxId = maThuongs
                            .Where(m => m.StartsWith("T") && m.Length > 1) // Lọc mã T
                            .Select(m => {
                                if (int.TryParse(m.Substring(1), out int id)) return id;
                                return 0;
                            })
                            .DefaultIfEmpty(0)
                            .Max();
            }

            maxId++;
            // Tạo mã mới với tiền tố "T" và đảm bảo đúng định dạng (ví dụ: T001)
            return "T" + maxId.ToString("D3");
        }

        public List<thuong> SearchThuong(string keyword)
        {
            // Tìm kiếm theo các cột chính của bảng thuong
            return db.thuongs
                .Where(t => t.ma_thuong.Contains(keyword) ||
                            t.ma_nhan_vien.Contains(keyword) ||
                            t.ma_loai_thuong.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            // Kiểm tra sự tồn tại trên bảng thuong
            return db.thuongs.Any(p => p.ma_thuong == id);
        }
    }
}
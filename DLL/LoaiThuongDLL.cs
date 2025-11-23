using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class LoaiThuongDLL
    {
        private DBSTDMDataContext db;

        public LoaiThuongDLL()
        {
            db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<loai_thuong> GetAllLoaiThuong()
        {
            using (DBSTDMDataContext freshDb = new DBSTDMDataContext(ConnectDLL.ReadConnectionString()))
            {
                return freshDb.loai_thuongs.ToList();
            }
        }

        public void AddLoaiThuong(loai_thuong LT)
        {
            db.loai_thuongs.InsertOnSubmit(LT);
            db.SubmitChanges();
        }

        public void DeleteLoaiThuong(string id)
        {
            // Tìm kiếm theo ma_loai_thuong
            var loaiThuong = db.loai_thuongs.SingleOrDefault(p => p.ma_loai_thuong == id);

            if (loaiThuong == null)
            {
                // Sửa thông báo lỗi
                throw new Exception($"Không tìm thấy loại thưởng với Mã: {id}");
            }

            // Xóa cứng (Hard Delete)
            db.loai_thuongs.DeleteOnSubmit(loaiThuong);
            db.SubmitChanges();
        }

        public void UpdateLoaiThuong(loai_thuong updateLoaiThuong) // Đổi tên tham số
        {
            // Tìm kiếm theo ma_loai_thuong
            var result = db.loai_thuongs.SingleOrDefault(lt => lt.ma_loai_thuong == updateLoaiThuong.ma_loai_thuong);

            if (result != null)
            {
                // Cập nhật các trường của bảng loai_thuong
                result.loai_yeu_cau = updateLoaiThuong.loai_yeu_cau;
                result.yeu_cau = updateLoaiThuong.yeu_cau;
                result.muc_thuong = updateLoaiThuong.muc_thuong;
                db.SubmitChanges();
            }
        }

        public string TaoMaLoaiThuong()
        {
            // Logic tạo mã LTxxx
            var maLoaiThuongs = db.loai_thuongs.Select(p => p.ma_loai_thuong).ToList();

            int maxId = 0;
            if (maLoaiThuongs.Any())
            {
                maxId = maLoaiThuongs
                            .Where(m => m.StartsWith("LT") && m.Length > 2)
                            .Select(m => {
                                if (int.TryParse(m.Substring(2), out int id)) return id;
                                return 0;
                            })
                            .DefaultIfEmpty(0)
                            .Max();
            }

            maxId++;
            // Tạo mã mới với tiền tố "LT" và đảm bảo đúng định dạng
            return "LT" + maxId.ToString("D3");
        }

        public List<loai_thuong> SearchLoaiThuong(string keyword)
        {
            // Tìm kiếm theo các cột chính của bảng loai_thuong
            return db.loai_thuongs
                .Where(lt => lt.ma_loai_thuong.Contains(keyword) ||
                             lt.loai_yeu_cau.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            // Kiểm tra sự tồn tại trên bảng loai_thuong
            return db.loai_thuongs.Any(p => p.ma_loai_thuong == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class LoaiViPhamDLL // Tên lớp chính xác
    {
        private DBSTDMDataContext db;

        public LoaiViPhamDLL()
        {
            db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<loai_vi_pham> GetAllLoaiViPham()
        {
            using (DBSTDMDataContext freshDb = new DBSTDMDataContext(ConnectDLL.ReadConnectionString()))
            {
                return freshDb.loai_vi_phams.ToList();
            }
        }

        public void AddLoaiViPham(loai_vi_pham LVP)
        {
            db.loai_vi_phams.InsertOnSubmit(LVP);
            db.SubmitChanges();
        }

        public void DeleteLoaiViPham(string id)
        {
            // Tìm kiếm theo ma_loai_vi_pham
            var loaiViPham = db.loai_vi_phams.SingleOrDefault(p => p.ma_loai_vi_pham == id);

            if (loaiViPham == null)
            {
                // Sửa thông báo lỗi
                throw new Exception($"Không tìm thấy loại vi phạm với Mã: {id}");
            }

            // Xóa cứng (Hard Delete)
            db.loai_vi_phams.DeleteOnSubmit(loaiViPham);
            db.SubmitChanges();
        }

        public void UpdateLoaiViPham(loai_vi_pham updateLoaiViPham) // Đổi tên tham số
        {
            var result = db.loai_vi_phams.SingleOrDefault(lvp => lvp.ma_loai_vi_pham == updateLoaiViPham.ma_loai_vi_pham);

            if (result != null)
            {
                // Cập nhật các trường của bảng loai_vi_pham
                result.mo_ta_vi_pham = updateLoaiViPham.mo_ta_vi_pham;
                result.muc_do_vi_pham = updateLoaiViPham.muc_do_vi_pham;
                result.muc_phat = updateLoaiViPham.muc_phat;
                db.SubmitChanges();
            }
        }

        public string TaoMaLoaiViPham()
        {
            // Logic tạo mã VPxxx (Giả định VP001)
            var maLoaiViPhams = db.loai_vi_phams.Select(p => p.ma_loai_vi_pham).ToList();

            int maxId = 0;
            if (maLoaiViPhams.Any())
            {
                maxId = maLoaiViPhams
                            .Where(m => m.StartsWith("VP") && m.Length > 2)
                            .Select(m => {
                                if (int.TryParse(m.Substring(2), out int id)) return id;
                                return 0;
                            })
                            .DefaultIfEmpty(0)
                            .Max();
            }

            maxId++;
            // Tạo mã mới với tiền tố "VP" và đảm bảo đúng định dạng
            return "VP" + maxId.ToString("D3");
        }

        public List<loai_vi_pham> SearchLoaiViPham(string keyword)
        {
            // Tìm kiếm theo các cột chính của bảng loai_vi_pham
            return db.loai_vi_phams
                .Where(lvp => lvp.ma_loai_vi_pham.Contains(keyword) ||
                             lvp.mo_ta_vi_pham.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            // Kiểm tra sự tồn tại trên bảng loai_vi_pham
            return db.loai_vi_phams.Any(p => p.ma_loai_vi_pham == id);
        }
    }
}
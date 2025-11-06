using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class LuongDLL
    {
        private DBSTDMDataContext db;

        public LuongDLL()
        {
            db = new DBSTDMDataContext();
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<luong> GetAllLuong()
        {
            using (DBSTDMDataContext freshDb = new DBSTDMDataContext())
            {
                return freshDb.luongs.ToList();
            }
        }

        public void AddLuong(luong luongMoi)
        {
            // Sử dụng 'using' để đảm bảo kết nối được đóng đúng cách
            using (DBSTDMDataContext dbContext = new DBSTDMDataContext())
            {
                dbContext.luongs.InsertOnSubmit(luongMoi);
                dbContext.SubmitChanges();
            }
        }

        public void UpdateLuong(luong updateLuong)
        {
            using (DBSTDMDataContext dbContext = new DBSTDMDataContext())
            {
                // Tìm phiếu lương cần cập nhật
                var result = dbContext.luongs.SingleOrDefault(l => l.ma_phieu_luong == updateLuong.ma_phieu_luong);
                if (result != null)
                {
                    // Cập nhật các trường
                    result.ma_nhan_vien = updateLuong.ma_nhan_vien;
                    result.luong_co_ban = updateLuong.luong_co_ban;
                    result.he_so = updateLuong.he_so; // Cột này vẫn tồn tại trong DB
                    result.thang_luong = updateLuong.thang_luong;
                    result.thuong = updateLuong.thuong;
                    result.phat = updateLuong.phat;
                    dbContext.SubmitChanges();
                }
            }
        }

        public void DeleteLuong(string maPhieuLuong)
        {
            using (DBSTDMDataContext dbContext = new DBSTDMDataContext())
            {
                var luong = dbContext.luongs.SingleOrDefault(l => l.ma_phieu_luong == maPhieuLuong);

                if (luong == null)
                {
                    throw new Exception($"Không tìm thấy phiếu lương với Mã: {maPhieuLuong}");
                }
                dbContext.luongs.DeleteOnSubmit(luong);
                dbContext.SubmitChanges();
            }
        }

        public string TaoMaPhieuLuong()
        {
            var maPhieuLuongs = db.luongs.Select(p => p.ma_phieu_luong).ToList();

            int maxId = 0;
            if (maPhieuLuongs.Any())
            {
                maxId = maPhieuLuongs
                    .Where(m => m.StartsWith("L") && m.Length > 1)
                    .Select(m => {
                        if (int.TryParse(m.Substring(1), out int id)) return id;
                        return 0;
                    })
                    .DefaultIfEmpty(0)
                    .Max();
            }

            maxId++;
            return "L" + maxId.ToString("D3");
        }

        public List<luong> SearchLuong(string keyword)
        {
            // Tìm kiếm theo Mã phiếu hoặc Mã NV
            return db.luongs
                .Where(l => l.ma_phieu_luong.Contains(keyword) ||
                            l.ma_nhan_vien.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            // Kiểm tra sự tồn tại của phiếu lương
            return db.luongs.Any(l => l.ma_phieu_luong == id);
        }

    }
}
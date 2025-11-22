using System;
using System.Collections.Generic;
using System.Linq;

namespace DLL
{
    public class ViPhamDLL
    {
        private DBSTDMDataContext db;

        public ViPhamDLL()
        {
            db = new DBSTDMDataContext();
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<vi_pham> GetAllViPham()
        {
            return db.vi_phams.ToList();
        }

        public void AddViPham(vi_pham VP)
        {
            db.vi_phams.InsertOnSubmit(VP);
            db.SubmitChanges();
        }

        public void UpdateViPham(vi_pham updateViPham)
        {
            var result = db.vi_phams.SingleOrDefault(vp => vp.ma_vi_pham == updateViPham.ma_vi_pham);
            if (result != null)
            {
                result.ma_nhan_vien = updateViPham.ma_nhan_vien;
                result.ma_loai_vi_pham = updateViPham.ma_loai_vi_pham;
                result.thoi_gian_vi_pham = updateViPham.thoi_gian_vi_pham;
                result.trang_thai = updateViPham.trang_thai;
                db.SubmitChanges();
            }
        }

        public void DeleteViPham(string id)
        {
            var viPham = db.vi_phams.SingleOrDefault(vp => vp.ma_vi_pham == id);
            if (viPham != null)
            {
                db.vi_phams.DeleteOnSubmit(viPham);
                db.SubmitChanges();
            }
        }

        public string TaoMaViPham()
        {
            // Logic tạo mã VPxxx
            var maViPhams = db.vi_phams.Select(p => p.ma_vi_pham).ToList();
            int maxId = 0;
            if (maViPhams.Any())
            {
                maxId = maViPhams
                    .Where(m => m.StartsWith("VP"))
                    .Select(m => { if (m.Length > 2 && int.TryParse(m.Substring(2), out int id)) return id; return 0; })
                    .DefaultIfEmpty(0)
                    .Max();
            }
            maxId++;
            return "VP" + maxId.ToString("D8"); // Dùng D4 vì mã vi phạm thường dài
        }

        public List<vi_pham> SearchViPham(string keyword)
        {
            return db.vi_phams
                .Where(vp => vp.ma_vi_pham.Contains(keyword) || vp.ma_nhan_vien.Contains(keyword) || vp.ma_loai_vi_pham.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            return db.vi_phams.Any(p => p.ma_vi_pham == id);
        }
    }
}
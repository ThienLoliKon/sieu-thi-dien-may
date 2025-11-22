using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class DiemDanhDLL
    {
        private DBSTDMDataContext db;

        public DiemDanhDLL()
        {
            db = new DBSTDMDataContext();
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<diem_danh> GetAllDiemDanh()
        {
            return db.diem_danhs.ToList();
        }

        public void AddDiemDanh(diem_danh DD)
        {
            db.diem_danhs.InsertOnSubmit(DD);
            db.SubmitChanges();
        }

        public void DeleteDiemDanh(string id)
        {
            var diemdanh = db.diem_danhs.SingleOrDefault(p => p.ma_diem_danh == id);

            if (diemdanh == null)
            {
                throw new Exception($"Không tìm thấy điểm danh với ID: {id}");
            }
            db.diem_danhs.DeleteOnSubmit(diemdanh);
            db.SubmitChanges();
        }

        public void UpdateDiemDanh(diem_danh updateDiemDanh)
        {
            var result = db.diem_danhs.SingleOrDefault(dd => dd.ma_diem_danh == updateDiemDanh.ma_diem_danh);
            if (result != null)
            {
                result.ma_nhan_vien = updateDiemDanh.ma_nhan_vien;
                result.thoi_gian_vao = updateDiemDanh.thoi_gian_vao;
                result.thoi_gian_ra = updateDiemDanh.thoi_gian_ra;
                db.SubmitChanges();
            }
        }

        public string TaoMaDiemDanh()
        {
            var maDiemDanhs = db.diem_danhs.Select(p => p.ma_diem_danh).ToList();

            int maxId = 0;

            if (maDiemDanhs.Any())
            {
                maxId = maDiemDanhs
                            .Where(m => m.StartsWith("DD") && m.Length > 2) // Lọc mã DD
                            .Select(m => {
                                // Thêm kiểm tra an toàn Parse
                                if (int.TryParse(m.Substring(2), out int id)) return id;
                                return 0;
                            })
                            .DefaultIfEmpty(0)
                            .Max();
            }

            // Tăng giá trị ID lớn nhất
            maxId++;

            // Tạo mã mới với tiền tố "DD" và đảm bảo đúng định dạng
            return "DD" + maxId.ToString("D8");
        }

        public List<diem_danh> SearchDiemDanh(string keyword)
        {
            return db.diem_danhs
                .Where(diemdanh => diemdanh.ma_diem_danh.Contains(keyword) || diemdanh.ma_nhan_vien.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            return db.diem_danhs.Any(p => p.ma_diem_danh == id);
        }
        public List<diem_danh> SearchDiemDanhByCriteria(string maNV)
        {
            var query = db.diem_danhs.AsQueryable();

            if (!string.IsNullOrEmpty(maNV))
            {
                query = query.Where(dd => dd.ma_nhan_vien == maNV);
            }
           return query.ToList();
        }
    }
}
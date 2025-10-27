using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class ChiNhanhDLL
    {
        private DBSTDMDataContext db;

        public ChiNhanhDLL()
        {
            db = new DBSTDMDataContext();
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<chi_nhanh> GetAllChiNhanh()
        {
            return db.chi_nhanhs.ToList();
        }

        public void AddChiNhanh(chi_nhanh CN)
        {
            db.chi_nhanhs.InsertOnSubmit(CN);
            db.SubmitChanges();
        }

        public void DeleteChiNhanh(string id)
        {
            var chinhanh = db.chi_nhanhs.SingleOrDefault(p => p.ma_chi_nhanh == id);

            if (chinhanh == null)
            {
                throw new Exception($"Không tìm thấy chi nhánh với ID: {id}");
            }

            db.chi_nhanhs.DeleteOnSubmit(chinhanh);
            db.SubmitChanges();
        }

        public void UpdateChiNhanh(chi_nhanh updateChiNhanh)
        {
            var result = db.chi_nhanhs.SingleOrDefault(cn => cn.ma_chi_nhanh == updateChiNhanh.ma_chi_nhanh);
            if (result != null)
            {
                result.ten_chi_nhanh = updateChiNhanh.ten_chi_nhanh;
                result.dia_chi = updateChiNhanh.dia_chi;
                result.khu_vuc = updateChiNhanh.khu_vuc;
                db.SubmitChanges();
            }
        }

        public string TaoMaChiNhanh()
        {
            var maChiNhanhs = db.chi_nhanhs.Select(p => p.ma_chi_nhanh).ToList();

            int maxId = 0;

            if (maChiNhanhs.Any())
            {
                maxId = maChiNhanhs
                            .Where(m => m.StartsWith("CN")) // Lọc các mã bắt đầu bằng "CN"
                            .Select(m => {
                                // Thêm kiểm tra an toàn Parse
                                if (m.Length > 2 && int.TryParse(m.Substring(2), out int id)) return id;
                                return 0;
                            })
                            .DefaultIfEmpty(0)
                            .Max();
            }

            maxId++;

            return "CN" + maxId.ToString("D3");
        }

        public List<chi_nhanh> SearchChiNhanh(string keyword)
        {
            return db.chi_nhanhs
                .Where(chinhanh => chinhanh.ma_chi_nhanh.Contains(keyword) || chinhanh.ten_chi_nhanh.Contains(keyword) || chinhanh.dia_chi.Contains(keyword) || chinhanh.khu_vuc.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            return db.chi_nhanhs.Any(p => p.ma_chi_nhanh == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class CapBacNhanVienDLL
    {
        private DBSTDMDataContext db;

        public CapBacNhanVienDLL()
        {
            db = new DBSTDMDataContext();
            if (!db.DatabaseExists())
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
            }
        }

        public List<cap_bac_nhan_vien> GetAllCapBacNhanVien()
        {
            return db.cap_bac_nhan_viens.ToList();
        }

        public void AddCapBacNhanVien(cap_bac_nhan_vien CBNV)
        {
            db.cap_bac_nhan_viens.InsertOnSubmit(CBNV);
            db.SubmitChanges();
        }

        public void DeleteCapBacNhanVien(string id)
        {
            var capbacnv = db.cap_bac_nhan_viens.SingleOrDefault(p => p.ma_cap_bac == id);

            if (capbacnv == null)
            {
                throw new Exception($"Không tìm thấy cấp bậc nhân viên với ID: {id}");
            }
            db.cap_bac_nhan_viens.DeleteOnSubmit(capbacnv);
            db.SubmitChanges();
        }

        public void UpdateCapBacNhanVien(cap_bac_nhan_vien updateCapBac)
        {
            var result = db.cap_bac_nhan_viens.SingleOrDefault(cb => cb.ma_cap_bac == updateCapBac.ma_cap_bac);
            if (result != null)
            {
                result.ten_cap_bac = updateCapBac.ten_cap_bac;
                result.mo_ta_cap_bac = updateCapBac.mo_ta_cap_bac;
                db.SubmitChanges();
            }
        }

        public string TaoMaCapBacNhanVien()
        {
            var maCapBanNVs = db.cap_bac_nhan_viens.Select(p => p.ma_cap_bac).ToList();

            int maxId = 0;

            if (maCapBanNVs.Any())
            {
                maxId = maCapBanNVs
                            .Where(m => m.StartsWith("CB") && m.Length > 2) // Lọc mã CB và kiểm tra độ dài
                            .Select(m => {
                                // Thêm kiểm tra an toàn Parse
                                if (int.TryParse(m.Substring(2), out int id))
                                    return id;
                                return 0;
                            })
                            .DefaultIfEmpty(0)
                            .Max();
            }

            // Tăng giá trị ID lớn nhất
            maxId++;

            // Tạo mã mới với tiền tố "CB" và đảm bảo đúng định dạng
            return "CB" + maxId.ToString("D3");
        }

        public List<cap_bac_nhan_vien> SearchCapBacNhanVien(string keyword)
        {
            return db.cap_bac_nhan_viens
                .Where(capbacNV => capbacNV.ma_cap_bac.Contains(keyword) || capbacNV.ten_cap_bac.Contains(keyword) || capbacNV.mo_ta_cap_bac.Contains(keyword))
                .ToList();
        }

        public bool check(string id)
        {
            return db.cap_bac_nhan_viens.Any(p => p.ma_cap_bac == id);
        }
    }
}
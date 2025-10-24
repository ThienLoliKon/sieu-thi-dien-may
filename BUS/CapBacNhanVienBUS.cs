using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CapBacNhanVienBUS
    {
        private CapBacNhanVienDLL dal;

        public CapBacNhanVienBUS()
        {
            dal = new CapBacNhanVienDLL();
        }

        public List<cap_bac_nhan_vien> GetAllCapBacNV()
        {
            return dal.GetAllCapBacNhanVien();
        }

        public bool AddCapBacNV(string tencb, string motacb)
        {
            cap_bac_nhan_vien capbacnv = new cap_bac_nhan_vien();

            capbacnv.ma_cap_bac = dal.TaoMaCapBacNhanVien();
            capbacnv.ten_cap_bac = tencb;
            capbacnv.mo_ta_cap_bac = motacb;

            dal.AddCapBacNhanVien(capbacnv);

            // SỬA LỖI LOGIC: Nếu tồn tại (check=true) sau khi thêm, nghĩa là thêm thành công.
            if (dal.check(capbacnv.ma_cap_bac) == true) { return true; }
            return false; // Thêm thất bại
        }

        public bool DeleteCapBacNV(string id)
        {
            dal.DeleteCapBacNhanVien(id);
            // LOGIC NÀY ĐÚNG cho XÓA CỨNG: Nếu không tồn tại (check=false) sau khi gọi DAL, nghĩa là xóa thành công.
            if (dal.check(id) == false) { return true; }
            return false; // Xóa thất bại (vẫn còn tồn tại)
        }

        public bool UpdateCapBacNVstring(string macb, string tencb, string motacb)
        {
            cap_bac_nhan_vien capbacnv = new cap_bac_nhan_vien();

            capbacnv.ma_cap_bac = macb;
            capbacnv.ten_cap_bac = tencb;
            capbacnv.mo_ta_cap_bac = motacb;

            dal.UpdateCapBacNhanVien(capbacnv);

            // SỬA LỖI LOGIC: Nếu tồn tại (check=true) sau khi cập nhật, nghĩa là đã tìm thấy và xử lý.
            if (dal.check(capbacnv.ma_cap_bac) == true) { return true; }
            return false; // Cập nhật thất bại (có thể ID không tồn tại ban đầu)
        }

        public DataTable timCapBacNV(string keyword)
        {
            // ... (Code tìm kiếm giữ nguyên)
            List<cap_bac_nhan_vien> capbacnvs = dal.SearchCapBacNhanVien(keyword);
            if (capbacnvs == null || capbacnvs.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaCB", typeof(string));
            dt.Columns.Add("TenCB", typeof(string));
            dt.Columns.Add("MoTaCB", typeof(string));
            foreach (var tk in capbacnvs)
            {
                dt.Rows.Add(tk.ma_cap_bac, tk.ten_cap_bac, tk.mo_ta_cap_bac);
            }
            return dt;
        }

        public DataTable GetAllCapBacNVAsTable()
        {
            List<cap_bac_nhan_vien> capbacnvs = dal.GetAllCapBacNhanVien();

            if (capbacnvs == null || capbacnvs.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaCB", typeof(string));
            dt.Columns.Add("TenCB", typeof(string));
            dt.Columns.Add("MoTaCB", typeof(string));
            foreach (var tk in capbacnvs)
            {
                dt.Rows.Add(tk.ma_cap_bac, tk.ten_cap_bac, tk.mo_ta_cap_bac);
            }
            return dt;
        }
    }
}
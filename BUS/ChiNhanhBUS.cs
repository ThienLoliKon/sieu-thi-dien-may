using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiNhanhBUS
    {
        private ChiNhanhDLL dal;

        public ChiNhanhBUS()
        {
            dal = new ChiNhanhDLL();
        }

        public List<chi_nhanh> GetAllChiNhanh()
        {
            return dal.GetAllChiNhanh();
        }

        public bool AddChiNhanh(string tenchinhanh, string diachi, string khuvuc)
        {
            chi_nhanh chinhanh = new chi_nhanh();

            chinhanh.ma_chi_nhanh = dal.TaoMaChiNhanh();
            chinhanh.ten_chi_nhanh = tenchinhanh;
            chinhanh.dia_chi = diachi;
            chinhanh.khu_vuc = khuvuc;

            dal.AddChiNhanh(chinhanh);

            // SỬA LỖI LOGIC: Nếu tồn tại (check=true), nghĩa là thêm thành công.
            if (dal.check(chinhanh.ma_chi_nhanh) == true) { return true; }
            return false;
        }

        public bool DeleteChiNhanh(string id)
        {
            dal.DeleteChiNhanh(id);
            // Logic này ĐÚNG cho XÓA CỨNG: Nếu không tồn tại (check=false), nghĩa là xóa thành công.
            if (dal.check(id) == false) { return true; }
            return false;
        }

        // ĐÃ THÊM THAM SỐ maCN VÀ SỬA LỖI LOGIC TRẢ VỀ
        public bool UpdateChiNhanhstring(string maCN, string tenchinhanh, string diachi, string khuvuc)
        {
            chi_nhanh chinhanh = new chi_nhanh();

            chinhanh.ma_chi_nhanh = maCN; // Cần thiết để DAL tìm kiếm
            chinhanh.ten_chi_nhanh = tenchinhanh;
            chinhanh.dia_chi = diachi;
            chinhanh.khu_vuc = khuvuc;

            try
            {
                dal.UpdateChiNhanh(chinhanh);
                // Giả định nếu DAL không ném Exception, và bản ghi tồn tại, thì thành công.
                if (dal.check(chinhanh.ma_chi_nhanh) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable timChiNhanh(string keyword)
        {
            List<chi_nhanh> chinhanhs = dal.SearchChiNhanh(keyword);
            if (chinhanhs == null || chinhanhs.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            // KHẮC PHỤC: Đồng nhất tên cột cho phép tìm kiếm trong DGV
            dt.Columns.Add("MaChiNhanh", typeof(string));
            dt.Columns.Add("TenChiNhanh", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("KhuVuc", typeof(string));
            foreach (var nv in chinhanhs)
            {
                dt.Rows.Add(nv.ma_chi_nhanh, nv.ten_chi_nhanh, nv.dia_chi, nv.khu_vuc);
            }
            return dt;
        }

        public DataTable GetAllChiNhanhAsTable()
        {
            List<chi_nhanh> chinhanhs = dal.GetAllChiNhanh();

            if (chinhanhs == null || chinhanhs.Count == 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            // KHẮC PHỤC: Đồng nhất tên cột cho ComboBox GUI
            dt.Columns.Add("MaCN", typeof(string));
            dt.Columns.Add("TenCN", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("KhuVuc", typeof(string));
            foreach (var nv in chinhanhs)
            {
                dt.Rows.Add(nv.ma_chi_nhanh, nv.ten_chi_nhanh, nv.dia_chi, nv.khu_vuc);
            }
            return dt;
        }
    }
}
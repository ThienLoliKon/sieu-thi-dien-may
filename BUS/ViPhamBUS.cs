using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ViPhamBUS
    {
        private ViPhamDLL dal;

        public ViPhamBUS()
        {
            dal = new ViPhamDLL();
        }

        public List<vi_pham> GetAllViPham()
        {
            return dal.GetAllViPham();
        }

        // GIẢ ĐỊNH: ViPhamDLL có thể truy cập bảng LoaiViPham để lấy Mức phạt.
        // Cần tạo hàm này nếu chưa có trong DLL.
        public double GetMucPhatByLoaiVP(string maLoaiVP)
        {
            // GIẢ ĐỊNH LOGIC: Gọi DLL để tìm kiếm MucPhat dựa trên maLoaiVP
            // Ví dụ: return new LoaiViPhamDLL().GetMucPhat(maLoaiVP);
            return 0.0; // Trả về 0.0 nếu logic phức tạp hoặc không có DLL tương ứng
        }

        public bool AddViPham(string maNV, string maLoaiVP, DateTime thoiGianVP)
        {
            vi_pham viPham = new vi_pham();

            viPham.ma_vi_pham = dal.TaoMaViPham();
            viPham.ma_nhan_vien = maNV;
            viPham.ma_loai_vi_pham = maLoaiVP;
            viPham.thoi_gian_vi_pham = thoiGianVP;
            viPham.trang_thai = false; // Mặc định là chưa hoàn thành (chưa xử lý)

            dal.AddViPham(viPham);

            // Logic kiểm tra: Nếu tồn tại sau khi thêm, nghĩa là thành công.
            if (dal.check(viPham.ma_vi_pham) == true) { return true; }
            return false;
        }

        public bool UpdateViPham(string maVP, string maNV, string maLoaiVP, DateTime thoiGianVP, bool trangThai)
        {
            vi_pham viPham = new vi_pham();

            viPham.ma_vi_pham = maVP;
            viPham.ma_nhan_vien = maNV;
            viPham.ma_loai_vi_pham = maLoaiVP;
            viPham.thoi_gian_vi_pham = thoiGianVP;
            viPham.trang_thai = trangThai;

            try
            {
                dal.UpdateViPham(viPham);
                // Kiểm tra sự tồn tại (thành công)
                if (dal.check(viPham.ma_vi_pham) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteViPham(string id)
        {
            try
            {
                dal.DeleteViPham(id);
                // Xóa cứng: Nếu không tồn tại sau khi gọi DAL, nghĩa là xóa thành công.
                if (dal.check(id) == false) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable GetAllViPhamAsTable()
        {
            List<vi_pham> viPhams = dal.GetAllViPham();

            if (viPhams == null || viPhams.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaVP", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("MaLoaiVP", typeof(string));
            dt.Columns.Add("ThoiGianVP", typeof(DateTime));
            dt.Columns.Add("TrangThai", typeof(string));
            // Cột Mức Phạt cần được thêm vào từ bảng LoaiViPham (yêu cầu logic phức tạp hơn)
            dt.Columns.Add("MucPhat", typeof(double));

            foreach (var vp in viPhams)
            {
                // Thao tác phức tạp hơn để lấy Mức phạt
                dt.Rows.Add(vp.ma_vi_pham, vp.ma_nhan_vien, vp.ma_loai_vi_pham, vp.thoi_gian_vi_pham, vp.trang_thai, GetMucPhatByLoaiVP(vp.ma_loai_vi_pham));
            }
            return dt;
        }
        // Trong ViPhamBUS.cs (BẮT BUỘC PHẢI CÓ)
        public DataTable timViPham(string keyword)
        {
            // Giả định dal.SearchViPham(keyword) tìm kiếm trong cột ma_nhan_vien
            List<vi_pham> viPhams = dal.SearchViPham(keyword);

            if (viPhams == null || viPhams.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaVP", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("MaLoaiVP", typeof(string));
            dt.Columns.Add("ThoiGianVP", typeof(DateTime));
            dt.Columns.Add("TrangThai", typeof(string));
            dt.Columns.Add("MucPhat", typeof(double));

            foreach (var vp in viPhams)
            {
                dt.Rows.Add(vp.ma_vi_pham, vp.ma_nhan_vien, vp.ma_loai_vi_pham, vp.thoi_gian_vi_pham, vp.trang_thai, GetMucPhatByLoaiVP(vp.ma_loai_vi_pham));
            }
            return dt;
        }
    }
}
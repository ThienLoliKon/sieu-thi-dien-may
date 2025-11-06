using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThuongBUS
    {
        private ThuongDLL dal;
        // Giả định có LoaiThuongDLL để truy cập MucThuong
        // private LoaiThuongDLL ltDal = new LoaiThuongDLL(); 

        public ThuongBUS()
        {
            dal = new ThuongDLL();
        }

        // Phương thức phụ trợ để lấy Mức Thưởng
        private double GetMucThuongByLoaiThuong(string maLoaiThuong)
        {
            // GIẢ ĐỊNH LOGIC: Gọi DLL để tìm kiếm MucThuong dựa trên maLoaiThuong
            // Nếu logic phức tạp, cần tạo lớp DLL riêng cho LoaiThuong
            return 0.0;
        }

        public bool AddThuong(string maNV, string maLoaiThuong, DateTime thoiGianThuong)
        {
            thuong thuongMoi = new thuong();

            // Logic tạo mã thưởng (Txxx)
            thuongMoi.ma_thuong = dal.TaoMaThuong();
            thuongMoi.ma_nhan_vien = maNV;
            thuongMoi.ma_loai_thuong = maLoaiThuong;
            thuongMoi.thoi_gian_thuong = thoiGianThuong;
            thuongMoi.trang_thai = true; // Mặc định là đã xử lý/đã cấp thưởng

            dal.AddThuong(thuongMoi);

            if (dal.check(thuongMoi.ma_thuong) == true) { return true; }
            return false;
        }

        public bool UpdateThuong(string maThuong, string maNV, string maLoaiThuong, DateTime thoiGianThuong, bool trangThai)
        {
            thuong updateThuong = new thuong();

            updateThuong.ma_thuong = maThuong;
            updateThuong.ma_nhan_vien = maNV;
            updateThuong.ma_loai_thuong = maLoaiThuong;
            updateThuong.thoi_gian_thuong = thoiGianThuong;
            updateThuong.trang_thai = trangThai;

            try
            {
                dal.UpdateThuong(updateThuong);
                if (dal.check(updateThuong.ma_thuong) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteThuong(string id)
        {
            try
            {
                dal.DeleteThuong(id);
                if (dal.check(id) == false) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable GetAllThuongAsTable()
        {
            List<thuong> thuongs = dal.GetAllThuong();

            if (thuongs == null || thuongs.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaThuong", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("MaLoaiThuong", typeof(string));
            dt.Columns.Add("ThoiGianThuong", typeof(DateTime));
            dt.Columns.Add("TrangThai", typeof(string));
            dt.Columns.Add("MucThuong", typeof(double));

            foreach (var t in thuongs)
            {
                // Lấy Mức thưởng (cần logic phức tạp hơn)
                double mucThuong = GetMucThuongByLoaiThuong(t.ma_loai_thuong);

                dt.Rows.Add(t.ma_thuong, t.ma_nhan_vien, t.ma_loai_thuong, t.thoi_gian_thuong, t.trang_thai, mucThuong);
            }
            return dt;
        }
        // Trong ThuongBUS.cs
        public DataTable TimThuongTheoMaNV(string maNV)
        {
            // Giả định DLL có phương thức SearchThuong(keyword) tìm theo MaNV
            List<thuong> thuongs = dal.SearchThuong(maNV);

            if (thuongs == null || thuongs.Count == 0) return null;

            DataTable dt = new DataTable();
            // ... (Định nghĩa cột giống GetAllThuongAsTable)
            dt.Columns.Add("MaThuong", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("LoaiThưởng", typeof(string));
            dt.Columns.Add("ThoiGianThuong", typeof(DateTime));
            dt.Columns.Add("TrangThai", typeof(string));
            dt.Columns.Add("MucThuong", typeof(double));

            foreach (var t in thuongs)
            {
                // ... (Logic lấy Mức thưởng giống GetAllThuongAsTable)
                double mucThuong = GetMucThuongByLoaiThuong(t.ma_loai_thuong);
                dt.Rows.Add(t.ma_thuong, t.ma_nhan_vien, t.ma_loai_thuong, t.thoi_gian_thuong, t.trang_thai, mucThuong);
            }
            return dt;
        }
    }
}
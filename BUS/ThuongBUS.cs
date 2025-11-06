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

        public ThuongBUS()
        {
            dal = new ThuongDLL();
        }


        private double GetMucThuongByLoaiThuong(string maLoaiThuong)
        {
            // Remove 'using' statement since DBSTDMDataContext does not implement IDisposable
            var db = new DBSTDMDataContext();
            return db.loai_thuongs
                .Where(lt => lt.ma_loai_thuong == maLoaiThuong)
                .Select(lt => lt.muc_thuong)
                .FirstOrDefault() ?? 0.0;
        }

        public bool AddThuong(string maNV, string maLoaiThuong, DateTime thoiGianThuong)
        {
            thuong thuongMoi = new thuong();

            thuongMoi.ma_thuong = dal.TaoMaThuong();
            thuongMoi.ma_nhan_vien = maNV;
            thuongMoi.ma_loai_thuong = maLoaiThuong;
            thuongMoi.thoi_gian_thuong = thoiGianThuong;
            thuongMoi.trang_thai = true; 

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
            if (thuongs == null || thuongs.Count == 0) return null;

            DataTable dt = new DataTable();
            dt.Columns.Add("MaThuong", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("MaLoaiThuong", typeof(string));
            dt.Columns.Add("ThoiGianThuong", typeof(DateTime));
            dt.Columns.Add("TrangThai", typeof(string));
            dt.Columns.Add("MucThuong", typeof(double));

            foreach (var t in thuongs)
            {
                double mucThuong = GetMucThuongByLoaiThuong(t.ma_loai_thuong);
                dt.Rows.Add(t.ma_thuong, t.ma_nhan_vien, t.ma_loai_thuong, t.thoi_gian_thuong, t.trang_thai, mucThuong);
            }
            return dt;
        }
        public DataTable TimThuongTheoMaNV(string maNV)
        {
            List<thuong> thuongs = dal.SearchThuong(maNV);
            if (thuongs == null || thuongs.Count == 0) return null;

            DataTable dt = new DataTable();
            dt.Columns.Add("MaThuong", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("MaLoaiThuong", typeof(string));
            dt.Columns.Add("ThoiGianThuong", typeof(DateTime));
            dt.Columns.Add("TrangThai", typeof(string));
            dt.Columns.Add("MucThuong", typeof(double));

            foreach (var t in thuongs)
            {
                double mucThuong = GetMucThuongByLoaiThuong(t.ma_loai_thuong);
                dt.Rows.Add(t.ma_thuong, t.ma_nhan_vien, t.ma_loai_thuong, t.thoi_gian_thuong, t.trang_thai, mucThuong);
            }
            return dt;
        }
    }
}
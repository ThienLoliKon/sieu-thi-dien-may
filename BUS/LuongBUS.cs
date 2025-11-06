using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BUS
{
    public class LuongBUS
    {
        private LuongDLL dal;

        // ĐÃ SỬA CÔNG THỨC: Bỏ HeSo (Lương CB + Thưởng - Phạt)
        private double TinhLuongThucNhan(double luongCB, double thuong, double phat)
        {
            return luongCB + thuong - phat;
        }

        public LuongBUS()
        {
            dal = new LuongDLL();
        }

        // ĐÃ SỬA: Bỏ heSo
        public bool AddLuong(string maNV, double luongCB, string thangLuong, double thuong, double phat)
        {
            luong luongMoi = new luong();
            try
            {
                luongMoi.ma_phieu_luong = dal.TaoMaPhieuLuong();
                luongMoi.ma_nhan_vien = maNV;
                luongMoi.luong_co_ban = luongCB;
                luongMoi.he_so = 1; // Gán mặc định là 1 (vì cột trong DB vẫn tồn tại)
                luongMoi.thang_luong = DateTime.Parse(thangLuong).Date;
                luongMoi.thuong = thuong;
                luongMoi.phat = phat;

                dal.AddLuong(luongMoi);

                if (dal.check(luongMoi.ma_phieu_luong) == true) { return true; }
                return false;
            }
            catch (Exception) { return false; }
        }

        // ĐÃ SỬA: Bỏ heSo
        public bool UpdateLuong(string maPhieuLuong, string maNV, double luongCB, string thangLuong, double thuong, double phat)
        {
            luong updateLuong = new luong();
            try
            {
                updateLuong.ma_phieu_luong = maPhieuLuong;
                updateLuong.ma_nhan_vien = maNV;
                updateLuong.luong_co_ban = luongCB;
                updateLuong.he_so = 1; // Gán mặc định là 1
                updateLuong.thang_luong = DateTime.Parse(thangLuong).Date;
                updateLuong.thuong = thuong;
                updateLuong.phat = phat;

                dal.UpdateLuong(updateLuong);

                if (dal.check(updateLuong.ma_phieu_luong) == true) { return true; }
                return false;
            }
            catch (Exception) { return false; }
        }

        public bool DeleteLuong(string maPhieuLuong)
        {
            try
            {
                dal.DeleteLuong(maPhieuLuong);
                if (dal.check(maPhieuLuong) == false) { return true; }
                return false;
            }
            catch (Exception) { return false; }
        }

        public DataTable timLuong(string keyword)
        {
            List<luong> luongs = dal.SearchLuong(keyword);
            if (luongs == null || luongs.Count == 0) return null;

            return ConvertListToDataTable(luongs);
        }

        public DataTable GetAllLuongAsTable()
        {
            List<luong> luongs = dal.GetAllLuong();
            if (luongs == null || luongs.Count == 0) return null;

            return ConvertListToDataTable(luongs);
        }

        // HÀM CHUYỂN ĐỔI (ĐỂ TRÁNH LẶP CODE)
        private DataTable ConvertListToDataTable(List<luong> luongs)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaPhieuLuong", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("LuongCB", typeof(double));
            // dt.Columns.Add("HeSo", typeof(double)); // ĐÃ XÓA
            dt.Columns.Add("ThangLuong", typeof(DateTime));
            dt.Columns.Add("Thuong", typeof(double));
            dt.Columns.Add("Phat", typeof(double));
            dt.Columns.Add("TongNhan", typeof(double)); // Cột mới

            foreach (var l in luongs)
            {
                // ĐÃ SỬA CÔNG THỨC: Bỏ HeSo
                double tongNhan = TinhLuongThucNhan(
                    (double)(l.luong_co_ban ?? 0),
                    (double)(l.thuong ?? 0),
                    (double)(l.phat ?? 0)
                );

                dt.Rows.Add(
                    l.ma_phieu_luong,
                    l.ma_nhan_vien,
                    l.luong_co_ban,
                    l.thang_luong,
                    l.thuong,
                    l.phat,
                    tongNhan
                );
            }
            return dt;
        }
    }
}
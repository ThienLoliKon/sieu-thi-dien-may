using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BUS
{
    public class LoaiThuongBUS
    {
        private LoaiThuongDLL dal;

        public LoaiThuongBUS()
        {
            dal = new LoaiThuongDLL();
        }

        public List<loai_thuong> GetAllLoaiThuong()
        {
            return dal.GetAllLoaiThuong();
        }

        public bool AddLoaiThuong(string loaiYeuCau, int yeuCau, double mucThuong)
        {
            loai_thuong ltMoi = new loai_thuong();

            try
            {
                ltMoi.ma_loai_thuong = dal.TaoMaLoaiThuong();
                ltMoi.loai_yeu_cau = loaiYeuCau;
                ltMoi.yeu_cau = yeuCau;
                ltMoi.muc_thuong = mucThuong;

                dal.AddLoaiThuong(ltMoi);

                // Logic kiểm tra: Nếu tồn tại sau khi thêm, thành công.
                if (dal.check(ltMoi.ma_loai_thuong) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateLoaiThuong(string maLT, string loaiYeuCau, int yeuCau, double mucThuong)
        {
            loai_thuong updateLT = new loai_thuong();

            try
            {
                updateLT.ma_loai_thuong = maLT;
                updateLT.loai_yeu_cau = loaiYeuCau;
                updateLT.yeu_cau = yeuCau;
                updateLT.muc_thuong = mucThuong;

                dal.UpdateLoaiThuong(updateLT);

                // Kiểm tra sự tồn tại (Cập nhật thành công)
                if (dal.check(updateLT.ma_loai_thuong) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLoaiThuong(string maLT)
        {
            try
            {
                dal.DeleteLoaiThuong(maLT);
                // Xóa cứng: Nếu không tồn tại sau khi gọi DAL, xóa thành công.
                if (dal.check(maLT) == false) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable GetAllLoaiThuongAsTable()
        {
            List<loai_thuong> loaiThuongs = dal.GetAllLoaiThuong();

            if (loaiThuongs == null || loaiThuongs.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaLT", typeof(string));
            dt.Columns.Add("LoaiYC", typeof(string));
            dt.Columns.Add("YeuCau", typeof(int));
            dt.Columns.Add("MucThuong", typeof(double));

            foreach (var lt in loaiThuongs)
            {
                dt.Rows.Add(lt.ma_loai_thuong, lt.loai_yeu_cau, lt.yeu_cau, lt.muc_thuong);
            }
            return dt;
        }
    }
}
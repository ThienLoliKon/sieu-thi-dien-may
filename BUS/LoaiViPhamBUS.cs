using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BUS
{
    public class LoaiViPhamBUS
    {
        private LoaiViPhamDLL dal;

        public LoaiViPhamBUS()
        {
            dal = new LoaiViPhamDLL();
        }

        public List<loai_vi_pham> GetAllLoaiViPham()
        {
            return dal.GetAllLoaiViPham();
        }

        public bool AddLoaiViPham(string moTaVP, int mucDoVP, double mucPhat)
        {
            loai_vi_pham lvpMoi = new loai_vi_pham();

            try
            {
                lvpMoi.ma_loai_vi_pham = dal.TaoMaLoaiViPham();
                lvpMoi.mo_ta_vi_pham = moTaVP;
                lvpMoi.muc_do_vi_pham = mucDoVP;
                lvpMoi.muc_phat = mucPhat;

                dal.AddLoaiViPham(lvpMoi);

                // Logic kiểm tra: Nếu tồn tại sau khi thêm, thành công.
                if (dal.check(lvpMoi.ma_loai_vi_pham) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateLoaiViPham(string maLVP, string moTaVP, int mucDoVP, double mucPhat)
        {
            loai_vi_pham updateLVP = new loai_vi_pham();

            try
            {
                updateLVP.ma_loai_vi_pham = maLVP;
                updateLVP.mo_ta_vi_pham = moTaVP;
                updateLVP.muc_do_vi_pham = mucDoVP;
                updateLVP.muc_phat = mucPhat;

                dal.UpdateLoaiViPham(updateLVP);

                // Kiểm tra sự tồn tại (Cập nhật thành công)
                if (dal.check(updateLVP.ma_loai_vi_pham) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLoaiViPham(string maLVP)
        {
            try
            {
                dal.DeleteLoaiViPham(maLVP);
                // Xóa cứng: Nếu không tồn tại sau khi gọi DAL, xóa thành công.
                if (dal.check(maLVP) == false) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable GetAllLoaiViPhamAsTable()
        {
            List<loai_vi_pham> loaiViPhams = dal.GetAllLoaiViPham();

            if (loaiViPhams == null || loaiViPhams.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaLVP", typeof(string));
            dt.Columns.Add("MoTa", typeof(string));
            dt.Columns.Add("MucDo", typeof(int));
            dt.Columns.Add("MucPhat", typeof(double));

            foreach (var lvp in loaiViPhams)
            {
                dt.Rows.Add(lvp.ma_loai_vi_pham, lvp.mo_ta_vi_pham, lvp.muc_do_vi_pham, lvp.muc_phat);
            }
            return dt;
        }
    }
}
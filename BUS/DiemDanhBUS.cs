using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DiemDanhBUS
    {
        private DiemDanhDLL dal;

        public DiemDanhBUS()
        {
            dal = new DiemDanhDLL();
        }

        public List<diem_danh> GetAllDiemDanh()
        {
            return dal.GetAllDiemDanh();
        }

        public bool AddDiemDanh(string maNV, string thoigianvao, string thoigianra)
        {
            diem_danh diemdanh = new diem_danh();

            try
            {
                diemdanh.ma_diem_danh = dal.TaoMaDiemDanh();
                diemdanh.ma_nhan_vien = maNV;
                diemdanh.thoi_gian_vao = DateTime.Parse(thoigianvao);
                diemdanh.thoi_gian_ra = DateTime.Parse(thoigianra);

                dal.AddDiemDanh(diemdanh);

                if (dal.check(diemdanh.ma_diem_danh) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDiemDanh(string id)
        {
            try
            {
                dal.DeleteDiemDanh(id);
                if (dal.check(id) == false) { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDiemDanhstring(string maDiemDanh, string maNV, string thoigianvao, string thoigianra)
        {
            diem_danh diemdanh = new diem_danh();

            try
            {
                diemdanh.ma_diem_danh = maDiemDanh;
                diemdanh.ma_nhan_vien = maNV;
                diemdanh.thoi_gian_vao = DateTime.Parse(thoigianvao);
                diemdanh.thoi_gian_ra = DateTime.Parse(thoigianra);

                dal.UpdateDiemDanh(diemdanh);

                if (dal.check(diemdanh.ma_diem_danh) == true) { return true; } 
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataTable timDiemDanh(string keyword)
        {
            List<diem_danh> diemdanhs = dal.SearchDiemDanh(keyword);
            if (diemdanhs == null || diemdanhs.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaDiemDanh", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("ThoiGianVao", typeof(DateTime));
            dt.Columns.Add("ThoiGianRa", typeof(DateTime));

            foreach (var dd in diemdanhs)
            {
                dt.Rows.Add(dd.ma_diem_danh, dd.ma_nhan_vien, dd.thoi_gian_vao, dd.thoi_gian_ra);
            }
            return dt;
        }

        public DataTable GetAllDiemDanhAsTable()
        {
            List<diem_danh> diemdanhs = dal.GetAllDiemDanh();

            if (diemdanhs == null || diemdanhs.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaDiemDanh", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("ThoiGianVao", typeof(DateTime));
            dt.Columns.Add("ThoiGianRa", typeof(DateTime));

            foreach (var dd in diemdanhs)
            {
                dt.Rows.Add(dd.ma_diem_danh, dd.ma_nhan_vien, dd.thoi_gian_vao, dd.thoi_gian_ra);
            }
            return dt;
        }

        public DataTable TimDiemDanhTheoTieuChi(string maNV)
        {
            List<diem_danh> diemdanhs = dal.SearchDiemDanhByCriteria(maNV);

            if (diemdanhs == null || diemdanhs.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaDiemDanh", typeof(string));
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("ThoiGianVao", typeof(DateTime));
            dt.Columns.Add("ThoiGianRa", typeof(DateTime));

            foreach (var dd in diemdanhs)
            {
                dt.Rows.Add(dd.ma_diem_danh, dd.ma_nhan_vien, dd.thoi_gian_vao, dd.thoi_gian_ra);
            }

            return dt;
        }
    }
}
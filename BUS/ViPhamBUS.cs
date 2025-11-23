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

        public double GetMucPhatByLoaiVP(string maLoaiVP)
        {
            return 0.0; 
        }

        public bool AddViPham(string maNV, string maLoaiVP, DateTime thoiGianVP)
        {
            vi_pham viPham = new vi_pham();

            viPham.ma_vi_pham = dal.TaoMaViPham();
            viPham.ma_nhan_vien = maNV;
            viPham.ma_loai_vi_pham = maLoaiVP;
            viPham.thoi_gian_vi_pham = thoiGianVP;
            viPham.trang_thai = false; 

            dal.AddViPham(viPham);

            if (dal.check(viPham.ma_vi_pham) == true) 
            {
                OnViPhamUpdated?.Invoke(this, EventArgs.Empty);
                return true; 
            }
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
                if (dal.check(viPham.ma_vi_pham) == true) { return true; }
                return false;
            }
            catch (Exception)
            {
                OnViPhamUpdated?.Invoke(this, EventArgs.Empty);
                return false;
            }
        }

        public bool DeleteViPham(string id)
        {
            try
            {
                dal.DeleteViPham(id);
                if (dal.check(id) == false) 
                {
                    OnViPhamUpdated?.Invoke(this, EventArgs.Empty);
                    return true; 
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private double GetMucPhatByLoaiPhat(string maLoaiThuong)
        {
            var db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
            return db.loai_vi_phams
                .Where(lt => lt.ma_loai_vi_pham == maLoaiThuong)
                .Select(lt => lt.muc_phat)
                .FirstOrDefault() ?? 0.0;
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
            dt.Columns.Add("MucPhat", typeof(double));

            foreach (var vp in viPhams)
            {
                double mucPhat = GetMucPhatByLoaiPhat(vp.ma_loai_vi_pham);

                dt.Rows.Add(vp.ma_vi_pham, vp.ma_nhan_vien, vp.ma_loai_vi_pham, vp.thoi_gian_vi_pham, vp.trang_thai, mucPhat);
            }
            return dt;
        }
        public DataTable timViPham(string keyword)
        {
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
                double mucPhat = GetMucPhatByLoaiPhat(vp.ma_loai_vi_pham);
                dt.Rows.Add(vp.ma_vi_pham, vp.ma_nhan_vien, vp.ma_loai_vi_pham, vp.thoi_gian_vi_pham, vp.trang_thai, mucPhat);
            }
            return dt;
        }
        public static event EventHandler OnViPhamUpdated;
        public double TinhTongPhat(string maNV, DateTime thang)
        {
            using (var db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString()))
            {
                int month = thang.Month;
                int year = thang.Year;

                var query = from vp in db.vi_phams
                            join lvp in db.loai_vi_phams on vp.ma_loai_vi_pham equals lvp.ma_loai_vi_pham
                            where vp.ma_nhan_vien == maNV
                                  && vp.thoi_gian_vi_pham.Value.Month == month
                                  && vp.thoi_gian_vi_pham.Value.Year == year
                            select lvp.muc_phat;

                return (double)(query.Sum() ?? 0.0);
            }
        }
    }
}
using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhuVucBUS
    {
        public class KhuVuc
        {
            public string makhu { get; set; }
            public string tenkhu { get; set; }
            public string nhanvienquanly { get; set; }

            public KhuVuc()
            {
                this.makhu = "";
                this.tenkhu = "";
                this.nhanvienquanly = "";
            }
        }
        private KhuVucDLL khuvucdll = new KhuVucDLL();
        public List<KhuVuc> getAllKhuVuc()
        {
            //khachhangdll = new KhachHangDLL();
            List<KhuVuc> list = new List<KhuVuc>();
            foreach (var item in khuvucdll.getAllKhuVuc())
            {
                KhuVuc kv = new KhuVuc();
                kv.makhu = item.ma_khu_vuc;
                kv.tenkhu = item.ten_khu_vuc;
                kv.nhanvienquanly = item.nhan_vien_quan_ly;
                //kh.xephang = item.xep_hang;
                //kh.diem = item.diem.HasValue ? item.diem.Value : 0;
                list.Add(kv);
            }
            return list;
        }
        //}
        //public DataTable getAllKVAsTable()
        //{
        //    return getAllKhuVuc(
        //}
        public int addKhuVuc(KhuVuc kv)
        {

            DLL.khu_vuc khuvuc = new DLL.khu_vuc()
            {
                ma_khu_vuc = createMaKhuVuc(),
                ten_khu_vuc = kv.tenkhu,
                nhan_vien_quan_ly = kv.nhanvienquanly
            };
            try
            {
                return khuvucdll.addKhuVuc(khuvuc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int updateKhuVuc(KhuVuc kv)
        {
            DLL.khu_vuc khuvuc = new DLL.khu_vuc()
            {
                ma_khu_vuc = kv.makhu,
                ten_khu_vuc = kv.tenkhu,
                nhan_vien_quan_ly = kv.nhanvienquanly,
            };
            return khuvucdll.updateKhuVuc(khuvuc);
        }
        //public bool checkTrungIDRank(string id)
        //{
        //    var listrank = xephangdll.getAllXepHang();
        //    foreach (var r in listrank)
        //    {
        //        if (r.ma_hang == id)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public int deleteKhuVuc(string id)
        {
            try
            {
                return khuvucdll.deleteKhuvuc(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string createMaKhuVuc()
        {
            var khuvuccuoicung = khuvucdll.getAllKhuVuc().LastOrDefault();
            if (khuvuccuoicung != null)
            {
                string makhcuoicung = khuvuccuoicung.ma_khu_vuc;
                int so = int.Parse(makhcuoicung.Substring(2)) + 1;
                return "KV" + so.ToString();
            }
            else
            {
                return "KV10000001";
            }
        }
        public List<KhuVuc> searchKhuVuc(KhuVuc khuvuc)
        {
            //khachhangdll = new KhachHangDLL();
            List<KhuVuc> list = new List<KhuVuc>();
            foreach (var item in khuvucdll.getAllKhuVuc())
            {
                if (item.ma_khu_vuc.Contains(khuvuc.makhu) || item.ten_khu_vuc.Contains(khuvuc.tenkhu) || item.nhan_vien_quan_ly.Contains(khuvuc.nhanvienquanly))
                {
                    KhuVuc kv = new KhuVuc();
                    kv.makhu = item.ma_khu_vuc;
                    kv.tenkhu = item.ten_khu_vuc;
                    kv.nhanvienquanly = item.nhan_vien_quan_ly;
                    //kh.xephang = item.xep_hang;
                    //kh.diem = item.diem.HasValue ? item.diem.Value : 0;
                    list.Add(kv);
                }
            }
            return list;
        }
    }
}

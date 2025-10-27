using DLL;
using System;
using System.Collections.Generic;
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
                kv.mahang = item.ma_hang;
                kv.tenhang = item.ten_hang;
                kv.yeucau = item.yeu_cau ?? 0;
                kv.uudai = item.uu_dai ?? 0;
                //kh.xephang = item.xep_hang;
                //kh.diem = item.diem.HasValue ? item.diem.Value : 0;
                list.Add(xh);
            }
            return list;
        }
        public int addRank(XepHang xh)
        {
            if (checkTrungIDRank(xh.mahang) == true)
            {
                throw new Exception("Duplicated rank id!!!");
            }
            DLL.xep_hang xephang = new DLL.xep_hang()
            {
                ma_hang = xh.mahang,
                ten_hang = xh.tenhang,
                yeu_cau = xh.yeucau,
                uu_dai = xh.uudai,
            };
            try
            {
                return xephangdll.AddXepHang(xephang);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int updateRank(XepHang xh)
        {
            DLL.xep_hang xephang = new DLL.xep_hang()
            {
                ma_hang = xh.mahang,
                ten_hang = xh.tenhang,
                yeu_cau = xh.yeucau,
                uu_dai = xh.uudai,
            };
            return xephangdll.UpdateRank(xephang);
        }
        public bool checkTrungIDRank(string id)
        {
            var listrank = xephangdll.getAllXepHang();
            foreach (var r in listrank)
            {
                if (r.ma_hang == id)
                {
                    return true;
                }
            }
            return false;
        }
        public int deleteRank(string id)
        {
            try
            {
                return xephangdll.deleteRank(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

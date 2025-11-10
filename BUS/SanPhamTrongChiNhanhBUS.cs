using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPhamTrongChiNhanhBUS
    {
        public class SanPhamTrongChiNhanh
        {
            public string machinhanh { get; set; }
            public string masanpham { get; set; }
            public string tensanpham { get; set; }
            public int soluong { get; set; }

            public SanPhamTrongChiNhanh()
            {
                this.machinhanh = "";
                this.masanpham = "";
                this.tensanpham = "";
                this.soluong = 0;
            }
        }
        private SanPhamTrongChiNhanhDLL sanphamtrongchinhanhdll = new SanPhamTrongChiNhanhDLL();
        public List<SanPhamTrongChiNhanh> getAllSanPhamTrongChiNhanh(string machinhanh = "")
        {
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPhamTrongChiNhanh> list = new List<SanPhamTrongChiNhanh>();
            foreach (var item in sanphamtrongchinhanhdll.getAllSanPhamTrongChiNhanh())
            {
                if (item.ma_chi_nhanh != machinhanh)
                {
                    continue;
                }
                SanPhamTrongChiNhanh sptkt = new SanPhamTrongChiNhanh();
                sptkt.machinhanh = item.ma_chi_nhanh;
                sptkt.masanpham = item.ma_san_pham;
                sptkt.soluong = item.so_luong ?? 0;
                sptkt.tensanpham = sanphambus.getTenSanPham(sptkt.masanpham);
                list.Add(sptkt);
            }
            return list;
        }
        public List<SanPhamTrongChiNhanh> searchSPTrongChiNhanh(string input)
        {
            List<SanPhamTrongChiNhanh> list = new List<SanPhamTrongChiNhanh>();
            foreach (var item in getAllSanPhamTrongChiNhanh())
            {
                if (item.masanpham.Contains(input) || item.tensanpham.Contains(input))
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public void updateSoLuongXuatKho(string makho, string masanpham, int soluong)
        {
            sanphamtrongchinhanhdll.updateSoLuongNhapKho(makho, masanpham, soluong);
        }
    }
}

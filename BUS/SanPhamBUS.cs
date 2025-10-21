using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using System.Threading.Tasks;

namespace BUS
{
	internal class SanPhamBUS
	{
		public class SanPham
		{
			public SanPham(string manv, string hotennv, string diachi, string email, string sdt, string chucvu, string ngaynhanviec)
			{
				this.manv = manv;
				this.hotennv = hotennv;
				this.diachi = diachi;
				this.email = email;
				this.sdt = sdt;
				this.chucvu = chucvu;
				this.ngaynhanviec = ngaynhanviec;
			}

			public string manv { get; set; }
			public string hotennv { get; set; }
			public string diachi { get; set; }
			public string email { get; set; }
			public string sdt { get; set; }
			public string chucvu { get; set; }
			public string ngaynhanviec { get; set; }
		}

		private SanPhamDLL nhanviendll;

		public List<NhanVien> getAllNhanVien()
		{
			nhanviendll = new NhanVienDLL();
			List<NhanVien> list = new List<NhanVien>();
			foreach (var item in nhanviendll.GetAllNhanVien())
			{
				NhanVien nv = new NhanVien(item.MaNhanVien, item.TenNhanVien, item.DiaChi, item.Email, item.SoDienThoai, item.ChucVu, item.NgayTao.Value.ToShortDateString());
				list.Add(nv);
			}
			return list;
		}

		public int addNhanVien(NhanVien nhanVien)
		{
			DAODLL.NhanVien nv = new DAODLL.NhanVien()
			{
				MaNhanVien = createMaNhanVien(),
				TenNhanVien = nhanVien.hotennv,
				DiaChi = nhanVien.diachi,
				Email = nhanVien.email,
				SoDienThoai = nhanVien.sdt,
				ChucVu = nhanVien.chucvu,
				NgayTao = DateTime.Now,
				NgayCapNhat = DateTime.Now
			};
			return nhanviendll.addNhanVien(nv);
		}
		public string createMaNhanVien()
		{
			return $"S{int.Parse(nhanviendll.GetAllNhanVien().Last().MaNhanVien.Substring(2)) + 1}";
		}
		public int deleteNhanVien(string id)
		{
			int rs = nhanviendll.deleteNhanVien(id);
			return rs;
		}
		public int updateNhanVien(NhanVien nhanVien)
		{
			DAODLL.NhanVien nv = new DAODLL.NhanVien()
			{
				MaNhanVien = nhanVien.manv,
				TenNhanVien = nhanVien.hotennv,
				DiaChi = nhanVien.diachi,
				Email = nhanVien.email,
				SoDienThoai = nhanVien.sdt,
				ChucVu = nhanVien.chucvu,
				NgayTao = DateTime.Parse(nhanVien.ngaynhanviec),
				NgayCapNhat = DateTime.Now
			};
			return nhanviendll.updateNhanVien(nv);
		}

		public List<NhanVien> searchByNameOrID(string name_id)
		{
			List<NhanVien> list = new List<NhanVien>();
			foreach (var item in nhanviendll.searchByNameOrID(name_id))
			{
				NhanVien nhanvien = new NhanVien(item.MaNhanVien, item.TenNhanVien, item.DiaChi, item.Email, item.SoDienThoai, item.ChucVu, item.NgayCapNhat.Value.ToShortTimeString());

				list.Add(nhanvien);
			}
			return list;
		}
		public class NhanVien
		{
			public NhanVien(string manv, string hotennv, string diachi, string email, string sdt, string chucvu, string ngaynhanviec)
			{
				this.manv = manv;
				this.hotennv = hotennv;
				this.diachi = diachi;
				this.email = email;
				this.sdt = sdt;
				this.chucvu = chucvu;
				this.ngaynhanviec = ngaynhanviec;
			}

			public string manv { get; set; }
			public string hotennv { get; set; }
			public string diachi { get; set; }
			public string email { get; set; }
			public string sdt { get; set; }
			public string chucvu { get; set; }
			public string ngaynhanviec { get; set; }
		}

		private NhanVienDLL nhanviendll;

		public List<NhanVien> getAllNhanVien()
		{
			nhanviendll = new NhanVienDLL();
			List<NhanVien> list = new List<NhanVien>();
			foreach (var item in nhanviendll.GetAllNhanVien())
			{
				NhanVien nv = new NhanVien(item.MaNhanVien, item.TenNhanVien, item.DiaChi, item.Email, item.SoDienThoai, item.ChucVu, item.NgayTao.Value.ToShortDateString());
				list.Add(nv);
			}
			return list;
		}

		public int addNhanVien(NhanVien nhanVien)
		{
			DAODLL.NhanVien nv = new DAODLL.NhanVien()
			{
				MaNhanVien = createMaNhanVien(),
				TenNhanVien = nhanVien.hotennv,
				DiaChi = nhanVien.diachi,
				Email = nhanVien.email,
				SoDienThoai = nhanVien.sdt,
				ChucVu = nhanVien.chucvu,
				NgayTao = DateTime.Now,
				NgayCapNhat = DateTime.Now
			};
			return nhanviendll.addNhanVien(nv);
		}
		public string createMaNhanVien()
		{
			return $"S{int.Parse(nhanviendll.GetAllNhanVien().Last().MaNhanVien.Substring(2)) + 1}";
		}
		public int deleteNhanVien(string id)
		{
			int rs = nhanviendll.deleteNhanVien(id);
			return rs;
		}
		public int updateNhanVien(NhanVien nhanVien)
		{
			DAODLL.NhanVien nv = new DAODLL.NhanVien()
			{
				MaNhanVien = nhanVien.manv,
				TenNhanVien = nhanVien.hotennv,
				DiaChi = nhanVien.diachi,
				Email = nhanVien.email,
				SoDienThoai = nhanVien.sdt,
				ChucVu = nhanVien.chucvu,
				NgayTao = DateTime.Parse(nhanVien.ngaynhanviec),
				NgayCapNhat = DateTime.Now
			};
			return nhanviendll.updateNhanVien(nv);
		}

		public List<NhanVien> searchByNameOrID(string name_id)
		{
			List<NhanVien> list = new List<NhanVien>();
			foreach (var item in nhanviendll.searchByNameOrID(name_id))
			{
				NhanVien nhanvien = new NhanVien(item.MaNhanVien, item.TenNhanVien, item.DiaChi, item.Email, item.SoDienThoai, item.ChucVu, item.NgayCapNhat.Value.ToShortTimeString());

				list.Add(nhanvien);
			}
			return list;
		}
	}
}

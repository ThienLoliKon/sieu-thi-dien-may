using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class HamXuLy
	{
		//hàm xóa khoảng trắng và return về
		public static string XoaKhoangTrangThua(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}

			// .Trim() sẽ xóa dấu cách ở cả đầu và cuối chuỗi
			// Nếu bạn CHỈ muốn xóa phía sau, dùng .TrimEnd()
			return input.Trim();
		}
	}
}

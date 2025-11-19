using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization; // Cần thêm thư viện này
namespace BUS
{
	public class CheckTestCase
	{
		public static bool checkKiTuDacBiet(params string[] str)
		{
			//char[] charlist = str.ToCharArray();
			foreach (string s in str)
			{
				char[] charlist = s.ToCharArray();
				foreach (int i in charlist)
				{
					//int i = (int)ii;
					if (!(i >= 48 && i <= 57) || (i >= 65 && i <= 90) || (i >= 97 && i <= 122))
					{
						return false;
					}
				}
			}
			return true;
		}
		//
		public static bool checkChuoiSo(params string[] str)
		{
			foreach (string s in str)
			{
				char[] charlist = s.ToCharArray();
				foreach (int i in charlist)
				{
					if (!(i >= 48 && i <= 57))
					{
						return false;
					}
				}
			}
			return true;
		}
		//check min max lenght of string
		public static bool checkLenghtChuoi(string str, int maxleng, int minleng = 0)
		{
			if (str.Length >= minleng && str.Length <= maxleng)
			{
				return true;
			}
			return false;
		}
		public static bool checkValidDateInOut(DateTime time1, DateTime time2)
		{
			if (time1 > time2)
			{
				return false;
			}
			return true;
		}
		//kiểm tra null // false : nếu có chuỗi rỗng || true nếu tất cả hợp lệ
		public static bool checkKhoangTrang(params string[] str)
		{
			foreach (string s in str)
			{
				if (s.Trim() == "")
				{
					return false;
				}
			}

			return true;
		}

		public static bool checkNumberRange(int max, int min, params double[] nums)
		{
			foreach (double d in nums)
			{
				if (d < min || d > max)
				{
					return false;
				}
			}
			return true;
		}

		//Kiểm tra chuỗi chỉ chứa số
		public static bool checkChiChuaSo(params string[] str)
		{
			foreach (string s in str)
			{
				// Dùng LINQ để kiểm tra TẤT CẢ các ký tự có phải là số (digit) hay không
				if (s.All(char.IsDigit) == false)
				{
					return false;
				}
			}

			return true;
		}

		/// Kiểm tra xem chuỗi có phải là một số NGUYÊN (int) hợp lệ hay không.
		public static bool checkKieuInt(string input, int maxValue = int.MaxValue)
		{
			// 1. int.TryParse mặc định sẽ thất bại nếu có chữ, dấu phẩy, hoặc dấu chấm.
			// Đây chính là điều bạn muốn.
			if (!int.TryParse(input, out int value))
			{
				// Sai kiểu (rỗng, có chữ, có dấu...)
				return false;
			}

			// 2. Kiểm tra max
			if (value > maxValue)
			{
				return false;
			}

			return true; // Hợp lệ
		}

		/// Kiểm tra xem chuỗi có phải là một số DOUBLE hợp lệ hay không.
		public static bool checkKieuDouble(string input, double maxValue = double.MaxValue)
		{
			NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
			CultureInfo culture = CultureInfo.InvariantCulture;

			if (!double.TryParse(input, style, culture, out double value))
			{
				return false;
			}

			if (value > maxValue)
			{
				return false;
			}

			return true;
		}

		/// Kiểm tra xem chuỗi có phải là một số DECIMAL hợp lệ hay không.
		/// (Dùng cho tiền tệ)
		public static bool checkKieuDecimal(string input, decimal maxValue = decimal.MaxValue)
		{
			// Quy tắc: Cho phép dấu phẩy hàng ngàn và 1 dấu chấm thập phân
			NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
			CultureInfo culture = CultureInfo.InvariantCulture; // Dùng '.' làm thập phân

			// 2. TryParse sẽ TỰ ĐỘNG THẤT BẠI nếu:
			//    - Rỗng, có chữ ("abc")
			//    - Có nhiều hơn 1 dấu chấm ("1.2.3")
			//    - Dấu phẩy sai chỗ ("1,,000")
			if (!decimal.TryParse(input, style, culture, out decimal value))
			{
				return false;
			}

			// 3. Kiểm tra max
			if (value > maxValue)
			{
				return false;
			}

			return true; // Hợp lệ
		}

		/// Kiểm tra xem chuỗi có phải là một số FLOAT hợp lệ hay không.
		public static bool checkKieuFloat(string input, float maxValue = float.MaxValue)
		{
			NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
			CultureInfo culture = CultureInfo.InvariantCulture;

			if (!float.TryParse(input, style, culture, out float value))
			{
				return false;
			}

			if (value > maxValue)
			{
				return false;
			}

			return true;
		}

		public static bool checkChiChuaSoVaDauCham(string str)
		{
			// Nếu chuỗi rỗng hoặc null, coi như không hợp lệ
			if (string.IsNullOrEmpty(str))
			{
				return false;
			}

			// Duyệt qua từng ký tự trong chuỗi
			foreach (char c in str)
			{
				// Nếu ký tự này KHÔNG PHẢI là số VÀ cũng KHÔNG PHẢI là dấu '.'
				if (!char.IsDigit(c) && c != '.')
				{
					return false; // Tìm thấy một ký tự không hợp lệ (như 'a', ',', '@')
				}
			}

			// Nếu qua được vòng lặp, nghĩa là tất cả ký tự đều hợp lệ
			return true;
		}

		public static bool ngayBatDauKetThuc(DateTime ngayBatDau, DateTime ngayKetThuc)
		{
			// Chúng ta dùng thuộc tính .Date để chỉ so sánh Năm/Tháng/Ngày.
			// Điều này đảm bảo việc chọn cùng một ngày (ví dụ: 16/11 - 16/11) là hợp lệ,
			// bất kể phần thời gian (giờ, phút) như thế nào.
			return ngayBatDau.Date <= ngayKetThuc.Date;
		}
	}
}
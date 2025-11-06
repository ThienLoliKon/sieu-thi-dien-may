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
        //kiểm tra null
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
			// 1. Kiểm tra kiểu
			// Xóa dấu phẩy (ví dụ: "1,000" -> "1000")
			string cleanInput = (input ?? "").Replace(",", "");

			if (!int.TryParse(cleanInput, out int value))
			{
				// Sai kiểu (không phải là số int)
				return false;
			}

			// 2. Kiểm tra max
			// Nếu vượt quá max, trả về false
			if (value > maxValue)
			{
				return false;
			}

			return true; // Hợp lệ
		}

		/// Kiểm tra xem chuỗi có phải là một số DOUBLE hợp lệ hay không.
		public static bool checkKieuDouble(string input, double maxValue = double.MaxValue)
		{
			// 1. Kiểm tra kiểu
			string cleanInput = (input ?? "").Replace(",", "");

			if (!double.TryParse(cleanInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
			{
				// Sai kiểu (không phải là số double)
				return false;
			}

			// 2. Kiểm tra max
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
			// 1. Kiểm tra kiểu
			string cleanInput = (input ?? "").Replace(",", "");

			if (!decimal.TryParse(cleanInput, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
			{
				// Sai kiểu (không phải là số decimal)
				return false;
			}

			// 2. Kiểm tra max
			if (value > maxValue)
			{
				return false;
			}

			return true;
		}

		/// Kiểm tra xem chuỗi có phải là một số FLOAT hợp lệ hay không.
		public static bool checkKieuFloat(string input, float maxValue = float.MaxValue)
		{
			// 1. Kiểm tra kiểu
			string cleanInput = (input ?? "").Replace(",", "");

			if (!float.TryParse(cleanInput, NumberStyles.Any, CultureInfo.InvariantCulture, out float value))
			{
				// Sai kiểu (không phải là số float)
				return false;
			}

			// 2. Kiểm tra max
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
	}
}

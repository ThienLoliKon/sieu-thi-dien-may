using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DLL
{
	public class ConnectDLL
	{
		// Tên file cấu hình
		private static string _fileName = "config.ini";

		// Hàm lấy chuỗi kết nối từ file
		public static string GetFilePath()
		{
			// Lấy đường dẫn thư mục chứa file .exe đang chạy (bin/Debug)
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string filePath = Path.Combine(basePath, _fileName);
			if (File.Exists(filePath))
			{
				// Đọc và cắt bỏ khoảng trắng thừa
				return File.ReadAllText(filePath).Trim();
			}

			return ""; // Trả về rỗng nếu chưa có file
		}

		// Hàm GHI File (Static để gọi cho lẹ, hoặc để public thường cũng được)
		public static void WriteConnectionString(string connString)
		{
			try
			{
				File.WriteAllText(_fileName, connString);
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi DLL: Không ghi được file cấu hình! " + GetFilePath() + ex.Message);
			}
		}

		// Hàm ĐỌC File
		public static string ReadConnectionString()
		{
			//string path = GetFilePath();
			if (File.Exists(_fileName))
			{
				return File.ReadAllText(_fileName).Trim();
			}
			return "";
		}

		public static void DeleteConnectionString()
		{
			try
			{
				if (File.Exists(_fileName))
				{
					File.Delete(_fileName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi DLL: Không xóa được file cấu hình! " + ex.Message);
			}

		}


	}
}

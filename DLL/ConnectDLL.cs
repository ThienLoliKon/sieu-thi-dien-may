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

		// --- HÀM LẤY ĐƯỜNG DẪN (ĐÃ SỬA) ---
		private static string GetFilePath()
		{
			string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string myFolder = Path.Combine(appDataPath, "SieuThiDienMay");

			// SỬA LỖI 1: Dùng Directory.Exists và thêm dấu chấm than (!) để kiểm tra "Nếu chưa có"
			if (!Directory.Exists(myFolder))
			{
				Directory.CreateDirectory(myFolder);
			}

			return Path.Combine(myFolder, _fileName);
		}

		// --- HÀM GHI FILE ---
		public static void WriteConnectionString(string connString)
		{
			try
			{
				// SỬA LỖI 2: Lấy đường dẫn đầy đủ từ AppData
				string path = GetFilePath();

				// Ghi đè nội dung
				File.WriteAllText(path, connString);
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi DLL: Không ghi được file cấu hình! " + ex.Message);
			}
		}

		// --- HÀM ĐỌC FILE ---
		public static string ReadConnectionString()
		{
			try
			{
				string path = GetFilePath(); // Lấy đường dẫn AppData
				if (File.Exists(path))
				{
					return File.ReadAllText(path).Trim();
				}
			}
			catch { }

			return "";
		}

		// --- HÀM XÓA FILE ---
		public static void DeleteConnectionString()
		{
			try
			{
				string path = GetFilePath(); // SỬA LỖI 3: Lấy đường dẫn AppData
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi DLL: Không xóa được file cấu hình! " + ex.Message);
			}
		}


	}
}

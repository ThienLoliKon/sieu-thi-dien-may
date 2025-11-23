using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class ConnectBus
	{

		// Hàm này cho GUI gọi
		public void updateConnectString(string server, string database)
		{
			// 1. Kiểm tra nghiệp vụ (Business Logic) tại BUS
			if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database))
			{
				throw new Exception("Tên Server và Database không được để trống!");
			}

			// 2. Ghép chuỗi (Xử lý logic)
			string connectionString = $"Data Source={server};Initial Catalog={database};Integrated Security=True;TrustServerCertificate=True";

			// 3. Gọi xuống DLL để lưu
			ConnectDLL.WriteConnectionString(connectionString);
		}

		// Hàm đọc (để dùng nếu cần hiển thị lại)
		public static string getStringConnect()
		{
			return ConnectDLL.ReadConnectionString();
		}

		public static void clearConnect() { }

	}
}

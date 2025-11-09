using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class SanPhamTrongKhoTongDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext();
        public SanPhamTrongKhoTongDLL()
        {
            if (!db.DatabaseExists())
            {
                //db.CreateDatabase();
            }
        }
        public List<san_pham_trong_kho_tong> getAllSanPhamTrongKhoTong()
        {
            return db.san_pham_trong_kho_tongs.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class KhuVucDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
        public KhuVucDLL()
        {
            if (!db.DatabaseExists())
            {
                //db.CreateDatabase();
            }
        }
        public List<khu_vuc> getAllKhuVuc()
        {
            return db.khu_vucs.ToList();
        }
        public int addKhuVuc(khu_vuc kv)
        {
            try
            {
                db.khu_vucs.InsertOnSubmit(kv);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                //throw new Exception(xh.xep_hang);
                throw new Exception("Loi khi them khu vuc: " + ex.Message);
            }
            return 1;
        }
        public int updateKhuVuc(khu_vuc kv)
        {
            try
            {
                var khuvuc = db.khu_vucs.SingleOrDefault(n => n.ma_khu_vuc == kv.ma_khu_vuc);
                if (khuvuc != null)
                {
                    khuvuc.ma_khu_vuc = kv.ma_khu_vuc;
                    khuvuc.ten_khu_vuc = kv.ten_khu_vuc;
                    khuvuc.nhan_vien_quan_ly = kv.nhan_vien_quan_ly;
                    db.SubmitChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        public int deleteKhuvuc(string makhu)
        {
            try
            {
                db.khu_vucs.DeleteOnSubmit(db.khu_vucs.SingleOrDefault(n => n.ma_khu_vuc == makhu));
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

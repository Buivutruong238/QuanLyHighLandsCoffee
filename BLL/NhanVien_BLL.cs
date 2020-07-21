using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVien_BLL
    {
        private QLyCafeDataContext db;
        public NhanVien_BLL()
        {
            db = new QLyCafeDataContext();
        }
        public IQueryable<NhanVien> getNhanViens()
        {
            return db.NhanViens.Select(t => t);
        }
        public NhanVien getNhanVien_By_TenDN(string tendn)
        {
            return db.NhanViens.FirstOrDefault(t => t.TenDangNhap == tendn);
        }
    }
}

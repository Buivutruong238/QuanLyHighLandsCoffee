using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Ban_BLL
    {
        private QLyCafeDataContext db;
        public Ban_BLL()
        {
            db = new QLyCafeDataContext();
        }
        public IQueryable<Ban> GetBans()
        {
            return db.Bans;
        }
        public Ban GetBan_by_maBan(int mb)
        {
            return db.Bans.FirstOrDefault(t => t.MaSoBan == mb);
        }
        public void CapNhatTrangThaiBan(int msban, bool trangthai)
        {
            Ban b = GetBan_by_maBan(msban);
            b.TrangThai = trangthai;
            db.SubmitChanges();
        }
    }
}

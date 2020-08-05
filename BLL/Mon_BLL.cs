using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Mon_BLL
    {
        private QLyCafeDataContext db;
        public Mon_BLL()
        {
            db = new QLyCafeDataContext();
        }
        public List<Mon> GetMons()
        {
            return db.Mons.ToList();
        }
        public List<Mon> GetMons_By_MaLoai(int ml)
        {
            return db.Mons.Where(t => t.MaLoaiMon == ml).ToList();
        }
        public Mon GetMon_by_maMon(int mm)
        {
            return db.Mons.FirstOrDefault(t => t.MaMon == mm);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiMon_BLL
    {
        private QLyCafeDataContext db;
        public LoaiMon_BLL()
        {
            db = new QLyCafeDataContext();
        }
        public IQueryable<LoaiMon> GetLoaiMons()
        {
            return db.LoaiMons;
        }
    }
}

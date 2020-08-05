using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguyenLieuCan_BLL
    {
        QLyCafeDataContext ql = new QLyCafeDataContext();
        public NguyenLieuCan_BLL()
        {

        }
        public IQueryable<NguyenLieuNhap> GetNguyenLieuNhaps()
        {
            return ql.NguyenLieuNhaps.Select(t => t);
        }
        public NguyenLieuNhap timMaNL(string ml)
        {
            return ql.NguyenLieuNhaps.Where(t => t.MaNguyenLieu == ml).FirstOrDefault();
        }
        private string phatSinhMaNCC(string prefix, int max, int id)
        {
            int sChuSo = id.ToString().Length;
            max -= prefix.Length;
            for (int i = 0; i < max - sChuSo; i++)
                prefix += "0";
            return prefix + id.ToString();
        }
        public string phatSinhMaTuDong()
        {
            return phatSinhMaNCC("NL", 8, timMaxIndex() + 1);
        }

        private int timMaxIndex()
        {
            int max = 0;
            int g;
            foreach (NguyenLieuNhap sp in ql.NguyenLieuNhaps)
            {
                g = int.Parse(sp.MaNguyenLieu.Substring(2));
                if (g > max)
                    max = g;
            }

            return max;
        }
        public bool them(List<NguyenLieuNhap> lstNL)
        {
            if (lstNL.Count == 0)
                return false;
            try
            {
                foreach (NguyenLieuNhap ct in lstNL)
                    ql.NguyenLieuNhaps.InsertOnSubmit(ct);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

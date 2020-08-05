using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaCungCap_BLL
    {
        QLyCafeDataContext ql = new QLyCafeDataContext();
        public NhaCungCap_BLL()
        {

        }
        public IQueryable<NhaCungCap> GetNhaCungCaps()
        {
            return ql.NhaCungCaps.Select(t => t);
        }
        public NhaCungCap timMaNCC(string ml)
        {
            return (NhaCungCap)ql.NhaCungCaps.Where(t => t.MaNhaCungCap == ml).FirstOrDefault();
            //return (PhieuNhap)ql.PhieuNhaps.Where(t => t.MaPhieuNhap == ml).FirstOrDefault();
        }
        public IQueryable getNhaCungCap_ByMaNCC(string ma)
        {
            return from nc in ql.NhaCungCaps where nc.MaNhaCungCap == ma select new {nc.MaNhaCungCap, nc.TenNhaCungCap, nc.DiaChi, nc.SoDienThoai };
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
            return phatSinhMaNCC("NCC", 8, timMaxIndex() + 1);
        }

        private int timMaxIndex()
        {
            int max = 0;
            int g;
            foreach (NhaCungCap sp in ql.NhaCungCaps)
            {
                g = int.Parse(sp.MaNhaCungCap.Substring(3));
                if (g > max)
                    max = g;
            }

            return max;
        }
        public bool them(List<NhaCungCap> lstNCC)
        {
            if (lstNCC.Count == 0)
                return false;
            try
            {
                foreach (NhaCungCap ct in lstNCC)
                    ql.NhaCungCaps.InsertOnSubmit(ct);
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

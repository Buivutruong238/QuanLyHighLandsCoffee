using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguyenLieu_BLL
    {
        QLyCafeDataContext ql = new QLyCafeDataContext();
        public NguyenLieu_BLL() { }
        public IQueryable<PhieuNhap> GetPhieuNhaps()
        {
            return ql.PhieuNhaps.Select(t => t);
        }
        public PhieuNhap getPN_byMaPN(string ml)
        {
            return (PhieuNhap)ql.PhieuNhaps.Where(t => t.MaPhieuNhap == ml).FirstOrDefault();
            //return (from pn in ql.PhieuNhaps where pn.MaPhieuNhap == ml select new { pn.MaPhieuNhap, pn.MaNhaCungCap, pn.NgayNhap, pn.ThanhTien, pn.NguoiLap});
        }
        public IQueryable GetChiTietPhieuNhaps()
        {
            return from ct in ql.ChiTietPhieuNhaps select new { ct.MaPhieuNhap, ct.MaNguyenLieu, ct.DonGia, ct.SoLuong, ct.ThanhTien};
        }
        public IQueryable<ChiTietPhieuNhap> GetChiTietPN()
        {
            return ql.ChiTietPhieuNhaps.Select(t => t);
        }
        public IQueryable<NhaCungCap> GetNhaCungCaps()
        {
            return ql.NhaCungCaps.Select(t => t);
        }
        public IQueryable GetChiTietPhieuNhaps_byMaPN(string ml)
        {
            return from ct in ql.ChiTietPhieuNhaps where ct.MaPhieuNhap == ml select new { ct.MaPhieuNhap, ct.MaNguyenLieu, ct.DonGia, ct.SoLuong, ct.ThanhTien };
        }
        public IQueryable<NguyenLieuNhap> GetNguyenLieuNhaps()
        {
            return ql.NguyenLieuNhaps.Select(t => t);
        }
        public decimal getDonGiaByMaNL(string maNL)
        {
            NguyenLieuNhap nl = ql.NguyenLieuNhaps.FirstOrDefault(t => t.MaNguyenLieu.Equals(maNL));
            if (nl != null)
            {
                return (decimal)nl.DonGia;
            }
            else
            {
                return -1;
            }

        }
        public int addPhieuNhap(string maPN, string maNCC, DateTime ngayNhap, double thanhTien, string nguoiLap)
        {
            PhieuNhap pn = ql.PhieuNhaps.Where(t => t.MaPhieuNhap == maPN && t.NguoiLap == nguoiLap).FirstOrDefault();
            if (pn == null)
            {
                PhieuNhap pn1 = new PhieuNhap();
                pn1.MaPhieuNhap = maPN;
                pn1.MaNhaCungCap = maNCC;
                pn1.NgayNhap = ngayNhap;
                pn1.ThanhTien = (decimal?)thanhTien;
                pn1.NguoiLap = nguoiLap;
                ql.PhieuNhaps.InsertOnSubmit(pn1);
                ql.SubmitChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int updatePhieuNhap(string maPN, string maNCC, DateTime ngayNhap, double thanhTien, string nguoiLap)
        {
            PhieuNhap pn = ql.PhieuNhaps.Where(t => t.MaPhieuNhap == maPN && t.NguoiLap == nguoiLap).FirstOrDefault();
            if (pn != null)
            {
                pn.MaNhaCungCap = maNCC;
                pn.NgayNhap = ngayNhap;
                pn.ThanhTien = (decimal?)thanhTien;
                pn.NguoiLap = nguoiLap;
                ql.SubmitChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int deletePhieuNhap(string maPN, string nguoiLap)
        {
            PhieuNhap pn = ql.PhieuNhaps.Where(t => t.MaPhieuNhap == maPN && t.NguoiLap == nguoiLap).FirstOrDefault();
            if (pn != null)
            {
                ql.PhieuNhaps.DeleteOnSubmit(pn);
                ql.SubmitChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int addChiTietPhieuNhap(string maPN, string maNL, double donGia, double soLuong, double thanhTien)
        {
            //PhieuNhap pn = ql.PhieuNhaps.Where(t => t.MaPhieuNhap == maPN && t.NguoiLap == nguoiLap).FirstOrDefault();
            ChiTietPhieuNhap ct = ql.ChiTietPhieuNhaps.Where(t => t.MaPhieuNhap == maPN && t.MaNguyenLieu == maNL).FirstOrDefault();
            if(ct == null)
            {
                ChiTietPhieuNhap ctpn1 = new ChiTietPhieuNhap();
                ctpn1.MaPhieuNhap = maPN;
                ctpn1.MaNguyenLieu = maNL;
                ctpn1.DonGia = (decimal?)donGia;
                ctpn1.SoLuong = soLuong;
                ctpn1.ThanhTien = (decimal?)thanhTien;
                ql.ChiTietPhieuNhaps.InsertOnSubmit(ctpn1);
                ql.SubmitChanges();
                return 1;
            }
            else
            {
                return 0;
            }
            
        }
        public int deleteChiTietPhieuNhap(string maPN, string maNL)
        {
            ChiTietPhieuNhap ctpn = ql.ChiTietPhieuNhaps.Where(t => t.MaPhieuNhap == maPN && t.MaNguyenLieu == maNL).FirstOrDefault();
            if (ctpn != null)
            {
                ql.ChiTietPhieuNhaps.DeleteOnSubmit(ctpn);
                ql.SubmitChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        private string phatSinhMaSP(string prefix, int max, int id)
        {
            int sChuSo = id.ToString().Length;
            max -= prefix.Length;
            for (int i = 0; i < max - sChuSo; i++)
                prefix += "0";
            return prefix + id.ToString();
        }
        public string phatSinhMaTuDong()
        {
            return phatSinhMaSP("PN", 8, timMaxIndex() + 1);
        }

        private int timMaxIndex()
        {
            int max = 0;
            int g;
            foreach (PhieuNhap sp in ql.PhieuNhaps)
            {
                g = int.Parse(sp.MaPhieuNhap.Substring(2));
                if (g > max)
                    max = g;
            }

            return max;
        }
        public string getTenNCC(string maNCC)
        {
            return ql.NhaCungCaps.Where(t => t.MaNhaCungCap == maNCC).FirstOrDefault().TenNhaCungCap;

        }
        public bool them(PhieuNhap pn, List<ChiTietPhieuNhap> ctPNs)
        {
            if (ctPNs.Count == 0)
                return false;
            try
            {
                ql.PhieuNhaps.InsertOnSubmit(pn);
                ql.SubmitChanges();
                foreach (ChiTietPhieuNhap ct in ctPNs)
                    ql.ChiTietPhieuNhaps.InsertOnSubmit(ct);
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

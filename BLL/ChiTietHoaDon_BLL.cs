
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietHoaDon_BLL
    {
        private QLyCafeDataContext db = new QLyCafeDataContext();
        public ChiTietHoaDon_BLL()
        {
            //db = new QLyCafeDataContext();
        }
        public List<DAL_ChiTietHD> GetChiTietHoaDons_Theo_maBan_TT0(int mb)
        {

            var result = (from hd in db.HoaDons
                          join cthd in db.ChiTietHoaDons on hd.MaHoaDon equals cthd.MaHoaDon
                          join m in db.Mons on cthd.MaMon equals m.MaMon
                          where (hd.MaSoBan == mb && hd.TrangThai == 0)
                          select new DAL_ChiTietHD
                          {
                              TenMon = m.TenMon.ToString(),
                              GiaBan = Convert.ToDouble(m.GiaBan),
                              SoLuong = int.Parse(cthd.SoLuong.ToString())
                          }).ToList();

            return result;
        }
        public bool is_TonTaiMonTrongHD(int maHD, int maMon)
        {
            _ChiTietHoaDon_DAL cthd = db.ChiTietHoaDons.FirstOrDefault(t => t.MaHoaDon == maHD && t.MaMon == maMon);
            if(cthd != null)
            {
                return true;
            }
            return false;
        }
        public void ThemChiTietHoaDon(int idHoaDon, int idMon, int soLuong)
        {
            db.ChiTietHoaDons.InsertOnSubmit(new _ChiTietHoaDon_DAL { MaHoaDon = idHoaDon, MaMon = idMon, SoLuong = soLuong });
            db.SubmitChanges();
        }
        public void UpdateSoLuongMon_TonTai(int idHoaDon, int idMon, int soLuong)
        {
            _ChiTietHoaDon_DAL cthd = db.ChiTietHoaDons.FirstOrDefault(t => t.MaHoaDon == idHoaDon && t.MaMon == idMon);
            if(cthd != null)
            {
                cthd.SoLuong += soLuong;
                db.SubmitChanges();
            }
        }


        //var result = from c in categories
        //             join p in products on c.CategoryID equals p.CategoryID
        //             select new
        //             {
        //                 ProductName = p.ProductName,
        //                 CategoryName = c.CategoryName
        //             };

        //select f.TenMon, cthd.SoLuong, f.GiaBan
        //from Mon as f, HoaDon as hd, ChiTietHoaDon as cthd
        //where hd.MaHoaDon = cthd.MaHoaDon

        //        and cthd.MaMon = f.MaMon
        //and hd.MaSoBan = 1--1.maban
        //and hd.TrangThai = 0
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDon_BLL
    {
        private QLyCafeDataContext db;
        public HoaDon_BLL()
        {
            db = new QLyCafeDataContext();
        }
        public void themMoiHD(int maban, string nguoiLap, int mamon, int soluong)
        {
            HoaDon hd = new HoaDon();
            hd.MaSoBan = maban;
            hd.TrangThai = 0;
            hd.NguoiLap = nguoiLap;
            hd.TimeCheckIn = DateTime.Now;
            db.HoaDons.InsertOnSubmit(hd);
            db.SubmitChanges();

            _ChiTietHoaDon_DAL cthd = new _ChiTietHoaDon_DAL();
            cthd.MaHoaDon = hd.MaHoaDon;
            cthd.MaMon = mamon;
            cthd.SoLuong = soluong;
            db.ChiTietHoaDons.InsertOnSubmit(cthd);
            db.SubmitChanges();
        }
        public int LayMaHoaDonTheoMaBan_ChuaThanhToan(int maBan)
        {
            HoaDon hd = db.HoaDons.FirstOrDefault(t => t.MaSoBan == maBan && t.TrangThai == 0);
            return hd.MaHoaDon;
        }
    }
}

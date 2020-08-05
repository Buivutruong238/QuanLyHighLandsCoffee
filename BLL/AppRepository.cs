using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AppRepository
    {
        NhanVien_BLL nhanvien_BLL;
        NguyenLieu_BLL nguyenlieu_BLL;
        Mon_BLL mon_BLL;
        Ban_BLL ban_BLL;
        LoaiMon_BLL loaiMon_BLL;
        ChiTietHoaDon_BLL chitiethoadon_BLL;
        HoaDon_BLL hoadon_BLL;

        public NhanVien_BLL NhanVienBLL
        {
            get
            {
                if(nhanvien_BLL == null)
                {
                    nhanvien_BLL = new NhanVien_BLL();
                }
                return nhanvien_BLL;
            }
        }
        public NguyenLieu_BLL NguyenLieuBLL
        {
            get
            {
                if (nguyenlieu_BLL == null)
                {
                    nguyenlieu_BLL = new NguyenLieu_BLL();
                }
                return nguyenlieu_BLL;
            }
        }
        public Mon_BLL Mon_BLL
        {
            get
            {
                if (mon_BLL == null)
                {
                    mon_BLL = new Mon_BLL();
                }
                return mon_BLL;
            }
        }
        public Ban_BLL Ban_BLL
        {
            get
            {
                if(ban_BLL == null)
                {
                    ban_BLL = new Ban_BLL();
                }
                return ban_BLL;
            }
        }
        public LoaiMon_BLL LoaiMon_BLL
        {
            get
            {
                if (loaiMon_BLL == null)
                {
                    loaiMon_BLL = new LoaiMon_BLL();
                }
                return loaiMon_BLL;
            }
        }
        public ChiTietHoaDon_BLL ChiTietHoaDon_BLL
        {
            get
            {
                if (chitiethoadon_BLL == null)
                {
                    chitiethoadon_BLL = new ChiTietHoaDon_BLL();
                }
                return chitiethoadon_BLL;
            }
        }
        public HoaDon_BLL HoaDon_BLL
        {
            get
            {
                if (hoadon_BLL == null)
                {
                    hoadon_BLL = new HoaDon_BLL();
                }
                return hoadon_BLL;
            }
        }
    }
}

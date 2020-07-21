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
    }
}

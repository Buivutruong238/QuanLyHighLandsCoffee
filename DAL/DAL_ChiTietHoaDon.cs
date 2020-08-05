using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChiTietHoaDon
    {
        private string _tenmon;

        public string TenMon
        {
            get { return _tenmon; }
            set { _tenmon = value; }
        }
        private double _giaban;

        public double GiaBan
        {
            get { return _giaban; }
            set { _giaban = value; }
        }
        private int _soluong;

        public int SoLuong
        {
            get { return _soluong; }
            set { _soluong = value; }
        }
    }
}

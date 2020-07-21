using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_BanHang : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        AppRepository app = new AppRepository();
        public Frm_BanHang()
        {
            InitializeComponent();
        }

        private void Frm_BanHang_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_DangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_DangNhap frm_dn = new Frm_DangNhap();
            frm_dn.ShowDialog();
           
        }
    }
}

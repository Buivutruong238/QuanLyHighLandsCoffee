using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;

namespace GUI
{
    public partial class Frm_DangNhap : DevExpress.XtraEditors.XtraForm
    {
        private AppRepository app = new AppRepository();
        public Frm_DangNhap()
        {
            InitializeComponent();
            setup();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            NhanVien nv = app.NhanVienBLL.getNhanVien_By_TenDN(txt_TenDN.Text.Trim());
            if (nv == null)
            {
                MessageBox.Show("Khong ton tai nhan vien nay");
            }
            else if (nv.MatKhau.Equals(txt_MatKhau.Text.Trim()))
            {
                OverlayFormShow.Instance.CloseProgressPanel();
                //this.Visible = false;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai mat khau!!");
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Thoát Chương Trình?",
                               "Thông báo",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
                    Application.Exit();
                else
                    e.Cancel = true; // to don't close form is user change his mind
            }
        }


        private void setup()
        {
            Frm_BanHang frm_main = new Frm_BanHang();
            frm_main.Show();
            OverlayFormShow.Instance.ShowFormOverlay(frm_main);
        }
    }
}
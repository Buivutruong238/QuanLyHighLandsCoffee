using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Ban_UserControl : UserControl
    {
        public Ban_UserControl()
        {
            InitializeComponent();
        }
        private int _maban;
        private string _tenban;
        private string _trangthai;
        private Image _hinhanh;

        public int MaBan
        {
            get { return _maban; }
            set { _maban = value; }
        }

        public string TenBan
        {
            get { return _tenban; }
            set { _tenban = value; lbl_TenBan.Text = value; }
        }


        public string TrangThai
        {
            get{return _trangthai; }
            set { _trangthai = value; lbl_TrangThai.Text = value; }
        }


        public Image HinhAnh
        {
            get { return _hinhanh; }
            set { _hinhanh = value; pictureBox_Ban.Image = value; }
        }

        private void pictureBox_Ban_MouseEnter(object sender, EventArgs e)
        {
            if (this.BackColor == Color.White)
            {
                this.BackColor = Color.Silver;
            }
        }

        private void pictureBox_Ban_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Silver)
            {
                this.BackColor = Color.White;
            }
        }


        private void pictureBox_Ban_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

    }
}

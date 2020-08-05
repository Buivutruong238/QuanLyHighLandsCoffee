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
    public partial class Mon_UserControl : UserControl
    {
        public Mon_UserControl()
        {
            InitializeComponent();
            
        }

        private int _mamon;
        private string _tenmon;
        private string _giaban;
        private Image _hinhanh;

        public int MaMon
        {
            get { return _mamon; }
            set { _mamon = value; }
        }

        public string TenMon
        {
            get { return _tenmon; }
            set { _tenmon = value; lbl_TenMon.Text = value; }
        }
        

        public string GiaBan
        {
            get { return _giaban; }
            set { _giaban = value;lbl_GiaBan.Text = value; }
        }
        

        public Image HinhAnh
        {
            get { return _hinhanh; }
            set { _hinhanh = value;pictureBox_MonUC.Image = value; }
        }

        private void pictureBox_MonUC_MouseEnter(object sender, EventArgs e)
        {
            if (this.BackColor == Color.White)
            {
                this.BackColor = Color.Silver;
            }
        }

        private void pictureBox_MonUC_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Silver)
            {
                this.BackColor = Color.White;
            }
        }

        private void pictureBox_MonUC_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        
    }
}

using BLL;
using DAL;
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
        public NhanVien login_account;
        private AppRepository app;
        private Ban ban_dangchon;
        private Ban_UserControl ban_userControl_dangchon;
        private Mon mon_dangchon;
        private Mon_UserControl mon_userControl_dangchon;

        public Frm_BanHang()
        {
            InitializeComponent();
        }

        private void Frm_BanHang_Load(object sender, EventArgs e)
        {
            app = new AppRepository();
            load_cbb_LoaiMon();
            loadBan();

        }

        private void btn_DangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.login_account = null;
            Frm_DangNhap frm_dn = new Frm_DangNhap();
            frm_dn.ShowDialog();

        }

        private void loadMon(List<Mon> list)
        {
            panel_Show_Mon.Controls.Clear();
            foreach (var item in list)
            {
                Mon_UserControl obj = new Mon_UserControl();
                obj.MaMon = item.MaMon;
                obj.TenMon = item.TenMon;
                obj.GiaBan = item.GiaBan.ToString() + " VNĐ";
                obj.HinhAnh = new Bitmap(Application.StartupPath + "\\Resources\\" + item.HinhAnh);
                obj.Click += Mon_Click;
                panel_Show_Mon.Controls.Add(obj);
            }
        }

        private void Mon_Click(object sender, EventArgs e)
        {
            //1. Xóa Textbox món và xóa BackColor món hiện tại.
            if (mon_dangchon != null || mon_userControl_dangchon != null)
            {
                txt_Mon_dangchon.Text = txt_Dongia.Text = string.Empty;
                mon_userControl_dangchon.BackColor = Color.White;
            }
            //2. Lấy món mới Click để so sánh với món HTai
            Mon_UserControl mon_userControl_clicked = (sender as Mon_UserControl);
            Mon mon_clicked = app.Mon_BLL.GetMon_by_maMon(mon_userControl_clicked.MaMon);
            //Nếu cùng 1 món thì bỏ chọn
            if (mon_clicked == mon_dangchon)
            {
                mon_dangchon = null;
                mon_userControl_dangchon = null;
            }
            else//Nếu khác món thì set món vừa Click thành món đang chọn
            {
                mon_dangchon = mon_clicked;
                mon_userControl_dangchon = mon_userControl_clicked;
            }
            //Hiển thị thông tin món vừa được Click
            if (mon_dangchon != null && mon_userControl_dangchon != null)
            {
                txt_Mon_dangchon.Text = mon_dangchon.TenMon;
                txt_Dongia.Text = mon_dangchon.GiaBan.ToString() + " VNĐ";
                mon_userControl_dangchon.BackColor = Color.Aqua;
            }
        }

        private void loadBan()
        {
            panel_Show_Ban.Controls.Clear();
            List<Ban> listBans = app.Ban_BLL.GetBans().ToList();
            foreach (var item in listBans)
            {
                Ban_UserControl obj = new Ban_UserControl();
                obj.MaBan = item.MaSoBan;
                obj.TenBan = item.TenBan;
                if (item.TrangThai == false)
                {
                    obj.TrangThai = "Trống";
                }
                else
                {
                    obj.TrangThai = "Có Người";
                    //
                    obj.BackColor = Color.DarkKhaki;
                }
                if (obj.TenBan == "Mang về")
                {
                    obj.HinhAnh = new Bitmap(Application.StartupPath + "\\Resources\\takeaway.png");
                }
                else
                {
                    obj.HinhAnh = new Bitmap(Application.StartupPath + "\\Resources\\ban.png");
                }
                obj.Click += Ban_Click;
                obj.BackColorChanged += Obj_BackColorChanged;
                panel_Show_Ban.Controls.Add(obj);
            }
        }

        private void Obj_BackColorChanged(object sender, EventArgs e)
        {
            Ban_UserControl ban_userControl_clicked = (sender as Ban_UserControl);
            Ban ban_clicked = app.Ban_BLL.GetBan_by_maBan(ban_userControl_clicked.MaBan);

            if(ban_clicked.TrangThai == true && ban_userControl_clicked.BackColor == Color.White)
            {
                ban_userControl_clicked.BackColor = Color.DarkKhaki;
            }
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            listView_CT_HoaDon.Items.Clear();
            //1. Xóa Textbox bàn và xóa BackColor bàn hiện tại.
            if (ban_dangchon != null || ban_userControl_dangchon != null)
            {
                txt_Ban_dangchon.Text = string.Empty;
                ban_userControl_dangchon.BackColor = Color.White;
            }
            //2. Lấy bàn mới Click để so sánh với bàn HTai
            Ban_UserControl ban_userControl_clicked = (sender as Ban_UserControl);
            Ban ban_clicked = app.Ban_BLL.GetBan_by_maBan(ban_userControl_clicked.MaBan);
            //Nếu cùng 1 bàn thì bỏ chọn
            if (ban_clicked == ban_dangchon)
            {
                ban_dangchon = null;
                ban_userControl_dangchon = null;
            }
            else//Nếu khác bàn thì set bàn vừa Click thành bàn đang chọn
            {
                ban_dangchon = ban_clicked;
                ban_userControl_dangchon = ban_userControl_clicked;
            }
            //Hiển thị thông tin bàn vừa được Click
            if (ban_dangchon != null && ban_userControl_dangchon != null)
            {
                txt_Ban_dangchon.Text = ban_dangchon.TenBan;
                ban_userControl_dangchon.BackColor = Color.Aqua;
              
                load_TTHoaDon_Theo_maBan(ban_dangchon.MaSoBan);//------------------------------------
            }
        }

        private void load_cbb_LoaiMon()
        {
            List<LoaiMon> list = app.LoaiMon_BLL.GetLoaiMons().ToList();
            list.Insert(0, new LoaiMon { MaLoaiMon = 0, TenLoaiMon = "Tất cả" });
            cbb_LoaiMon.DataSource = list;
            cbb_LoaiMon.DisplayMember = "TenLoaiMon";
            cbb_LoaiMon.ValueMember = "MaLoaiMon";
            cbb_LoaiMon.SelectedIndex = 0;
        }

        private void cbb_LoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_LoaiMon.SelectedIndex == 0)
            {
                List<Mon> list = app.Mon_BLL.GetMons();
                loadMon(list);
            }
            else
            {
                int id = int.Parse(cbb_LoaiMon.SelectedValue.ToString());
                List<Mon> list = app.Mon_BLL.GetMons_By_MaLoai(id);
                loadMon(list);
            }
        }
        //
        private void load_TTHoaDon_Theo_maBan(int maban)
        {
            listView_CT_HoaDon.Items.Clear();
            List<DAL_ChiTietHoaDon> list = app.ChiTietHoaDon_BLL.GetChiTietHoaDons_Theo_maBan_TT0(maban);
            if(list != null)
            {
                foreach (DAL_ChiTietHoaDon cthd in list)
                {
                    ListViewItem lstvItem = new ListViewItem(cthd.TenMon.ToString());
                    lstvItem.SubItems.Add(cthd.SoLuong.ToString());
                    lstvItem.SubItems.Add(cthd.GiaBan.ToString());

                    double thanhtien = double.Parse(cthd.GiaBan.ToString()) * int.Parse(cthd.SoLuong.ToString());
                    lstvItem.SubItems.Add(thanhtien.ToString());
                    listView_CT_HoaDon.Items.Add(lstvItem);
                }
            }else
                MessageBox.Show("nooka");

        }

        private void btn_Themmon_Click(object sender, EventArgs e)
        {
            if(ban_dangchon == null)
            {
                MessageBox.Show("Chưa chọn bàn!!");
                return;
            }
            if(mon_dangchon == null)
            {
                MessageBox.Show("Chưa chọn món!!");
                return;
            }
            if(ban_dangchon.TrangThai == false)//Bàn trống -> Tạo Hóa đơn mới -> add Chi tiết HD
            {
                int sl = int.Parse(num_SoLuong.Value.ToString());
                app.HoaDon_BLL.themMoiHD(ban_dangchon.MaSoBan, login_account.TenDangNhap, mon_dangchon.MaMon, sl);
                // update trang thai ban -> true
                app.Ban_BLL.CapNhatTrangThaiBan(ban_dangchon.MaSoBan, true);
            }
            else//Bàn đang có người -> Xét món đang chọn
            {
                int maHoaDon = app.HoaDon_BLL.LayMaHoaDonTheoMaBan_ChuaThanhToan(ban_dangchon.MaSoBan);
                int maMon = mon_dangchon.MaMon;
                int sluong = (int)num_SoLuong.Value;
                bool tontaimon = app.ChiTietHoaDon_BLL.is_TonTaiMonTrongHD(maHoaDon, maMon);
                //Nếu món chưa có -> thêm món vào CTHD
                if(tontaimon == false)
                {
                    app.ChiTietHoaDon_BLL.ThemChiTietHoaDon(maHoaDon, maMon, sluong);
                }
                else//Nếu món đã có -> update số lượng
                {
                    app.ChiTietHoaDon_BLL.UpdateSoLuongMon_TonTai(maHoaDon, maMon, sluong);
                }
                

            }
            //cập nhật Thông tin
            load_TTHoaDon_Theo_maBan(ban_dangchon.MaSoBan);// load Thông tin hóa đơn của bàn
        }

        private void setTrangThaiBan()
        {

        }
    }
}

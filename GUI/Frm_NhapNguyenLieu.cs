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
using DevExpress.XtraBars.Docking2010.Base;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Columns;
using BLL;

namespace GUI
{
    public partial class Frm_NhapNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        NguyenLieu_BLL nl = new NguyenLieu_BLL();
        PhieuNhap pnTemp;
        List<ChiTietPhieuNhap> lstPN = new List<ChiTietPhieuNhap>();
        public Frm_NhapNguyenLieu()
        {
            InitializeComponent();
            //this.dgvChiTietPN.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvChiTietPN_DataError);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn thật sự muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) this.Close();
        }
        public void load_CBONCC()
        {
            cboNCC.DataSource = nl.GetNhaCungCaps();
            cboNCC.ValueMember = "MaNhaCungCap";
            cboNCC.DisplayMember = "TenNhaCungCap";
        }
        public void load_CboMaPN()
        {
            cboMaPN.DataSource = nl.GetPhieuNhaps();
            cboMaPN.DisplayMember = "MaPhieuNhap";
            cboMaPN.ValueMember = "MaPhieuNhap";

        }
        public void load_cboMaNLieu()
        {
            cboNguyenLieu.DataSource = nl.GetNguyenLieuNhaps();
            cboNguyenLieu.ValueMember = "MaNguyenLieu";
            cboNguyenLieu.DisplayMember = "TenNguyenLieu";
        }
        public void load_gvChitiet()
        {
            dgvChiTietPN.DataSource = nl.GetChiTietPN();

        }

        private void Frm_NhapNguyenLieu_Load(object sender, EventArgs e)
        {
            load_CBONCC();
            load_CboMaPN();
            load_cboMaNLieu();
            load_gvChitiet();
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            msNgayNhap.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd-MM-yyyy");
            //dgvChiTietPN.Columns[5].Visible = false;
            //dgvChiTietPN.Columns[6].Visible = false;
            cboMaPN.Enabled = true;
            cboNguyenLieu.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Enabled = false;
            //dgvChiTietPN.Enabled = false;
            txtNhanVien.Text = "truong";
            btnThemChiTiet.Enabled = false;
            btnXoaCT.Enabled = false;
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnTaoPhieu.Enabled = false;
            cboMaPN.Enabled = false;
            cboNguyenLieu.Enabled = true;
            btnThemChiTiet.Enabled = true;
            btnXoaCT.Enabled = true;

            txtSoLuong.Enabled = true;


            msNgayNhap.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd-MM-yyyy");

            string ma = nl.phatSinhMaTuDong();
            txtMaPN.Text = ma;
            cboMaPN.Text = ma;
            cboMaPN.Enabled = false;
            txtThanhTien.Text = "0";

            pnTemp = new PhieuNhap();
            pnTemp.MaPhieuNhap = ma;
            pnTemp.MaNhaCungCap = cboNCC.SelectedValue.ToString();
            pnTemp.NgayNhap = DateTime.Now;
            pnTemp.ThanhTien = (decimal?)Convert.ToDouble(txtThanhTien.Text);
            pnTemp.NguoiLap = txtNhanVien.Text;
        }

        

        

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                btnLuu.Enabled = true;
                string maPN = cboMaPN.Text;
                string maNL = cboNguyenLieu.SelectedValue.ToString();
                double donGia = Convert.ToDouble(txtDonGia.Text);
                double soLuong = Convert.ToDouble(txtSoLuong.Text);
                double thanhTien = donGia * soLuong;
                if (ktra_TonTaiMaNL(maNL, lstPN))
                {
                    DialogResult r = MessageBox.Show("Nguyên liệu thêm đã có bạn muốn update lại không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (ktra_TonTaiMaNL(maNL, lstPN) && ktra_TonTaiMaPN(maPN, lstPN))
                        {
                            foreach (ChiTietPhieuNhap p in lstPN)
                            {
                                if (p.MaNguyenLieu.Equals(maNL) && p.MaPhieuNhap.Equals(maPN))
                                {
                                    p.DonGia = (decimal?)donGia;
                                    p.SoLuong = soLuong;
                                    p.ThanhTien = (decimal?)thanhTien;
                                }
                            }
                            var source = new BindingSource();
                            source.DataSource = lstPN;
                            dgvChiTietPN.DataSource = null;
                            dgvChiTietPN.DataSource = source;
                            double tien = 0;
                            for (int i = 0; i < lstPN.Count; i++)
                            {
                                tien += Convert.ToDouble(lstPN[i].ThanhTien);
                            }
                            txtThanhTien.Text = tien.ToString();
                        }
                    }

                }
                else
                {
                    lstPN.Add(new ChiTietPhieuNhap { MaPhieuNhap = maPN, MaNguyenLieu = maNL, DonGia = (decimal?)donGia, SoLuong = soLuong, ThanhTien = (decimal?)thanhTien });
                    var source = new BindingSource();
                    source.DataSource = lstPN;
                    dgvChiTietPN.DataSource = null;
                    dgvChiTietPN.DataSource = source;
                    double tien = 0;
                    for (int i = 0; i < lstPN.Count; i++)
                    {
                        tien += Convert.ToDouble(lstPN[i].ThanhTien);
                    }
                    txtThanhTien.Text = tien.ToString();
                }
                    
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải nhập số lượng nguyên liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            
        }
        private bool ktra_TonTaiMaNL(string manl, List<ChiTietPhieuNhap> list)
        {
            foreach (var item in list)
            {
                if(item.MaNguyenLieu == manl)
                {
                    return true;
                }
            }
            return false;
        }
        private bool ktra_TonTaiMaPN(string mapn, List<ChiTietPhieuNhap> list)
        {
            foreach(var item in list)
            {
                if(item.MaPhieuNhap == mapn)
                {
                    return true;
                }
            }
            return false;
        }

        private void cboNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNl = cboNguyenLieu.SelectedValue.ToString();
            txtDonGia.Text = nl.getDonGiaByMaNL(maNl).ToString();
        }

        private void cboMaPN_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            PhieuNhap dt1 = (PhieuNhap)nl.getPN_byMaPN(cboMaPN.SelectedValue.ToString());
            if(dt1 != null)
            {
                txtMaPN.Text = dt1.MaPhieuNhap.ToString();
                cboNCC.Text = nl.getTenNCC(dt1.MaNhaCungCap);
                msNgayNhap.Text = Convert.ToDateTime( dt1.NgayNhap).ToString("dd-MM-yyyy");
                txtThanhTien.Text = dt1.ThanhTien.ToString();
                txtNhanVien.Text = dt1.NguoiLap.ToString();
                string ml = cboMaPN.SelectedValue.ToString();
               
            }
            
        }

        private void dgvChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            cboMaPN.Enabled = true;
            try
            {
                
                DialogResult r = MessageBox.Show("Muốn lưu tất cả?", "Không thể sửa xóa nữa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    dgvChiTietPN.Enabled = true;
                    pnTemp.ThanhTien = decimal.Parse(txtThanhTien.Text);

                    bool kq = nl.them(pnTemp, lstPN);
                    if (kq == true)
                    {
                        btnTaoPhieu.Enabled = true;
                        btnLuu.Enabled = false;
                        load_CboMaPN();
                        load_gvChitiet();
                        pnTemp = null;
                        lstPN.Clear();
                        MessageBox.Show("Thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemChiTiet.Enabled = false;
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               
            }catch(Exception ex)
            {

            }
            
            
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            try
            {
                string maPN = cboMaPN.Text;
                string maNL = cboNguyenLieu.SelectedValue.ToString();
                double donGia = Convert.ToDouble(txtDonGia.Text);
                double soLuong = Convert.ToDouble(txtSoLuong.Text);

                if (ktra_TonTaiMaNL(maNL, lstPN) && ktra_TonTaiMaPN(maPN, lstPN))
                {
                    foreach (ChiTietPhieuNhap chiTiet in lstPN)
                    {
                        if (chiTiet.MaNguyenLieu.Equals(maNL) && chiTiet.MaPhieuNhap.Equals(maPN))
                        {
                            lstPN.Remove(chiTiet);
                            break;
                        }
                    }
                    var source = new BindingSource();
                    source.DataSource = lstPN;
                    dgvChiTietPN.DataSource = null;
                    dgvChiTietPN.DataSource = source;
                    double tien = 0;
                    for (int i = 0; i < lstPN.Count; i++)
                    {
                        tien += Convert.ToDouble(lstPN[i].ThanhTien);
                    }
                    txtThanhTien.Text = tien.ToString();
                }
                else
                {
                    MessageBox.Show("Phiếu nhập phải thêm chi tiết mới xóa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                
            }
            
        }

        private void dgvChiTietPN_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (gridView1.GetRowCellValue(e.RowHandle, MaNL).ToString() != string.Empty)
                {
                    cboNguyenLieu.Text = gridView1.GetRowCellValue(e.RowHandle, MaNL).ToString();
                    cboMaPN.Text = gridView1.GetRowCellValue(e.RowHandle, MaPN).ToString();
                    txtDonGia.Text = gridView1.GetRowCellValue(e.RowHandle, DonGiadg).ToString();
                    txtSoLuong.Text = gridView1.GetRowCellValue(e.RowHandle, SoLuongsl).ToString();
                }
            }catch(Exception ex)
            {

            }
                
           
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //int r = e.Y;
            //MessageBox.Show(r.ToString());
        }

        private void cboMaPN_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PhieuNhap dt1 = (PhieuNhap)nl.getPN_byMaPN(cboMaPN.SelectedValue.ToString());
            if (dt1 != null)
            {
                txtMaPN.Text = dt1.MaPhieuNhap.ToString();
                cboNCC.Text = nl.getTenNCC(dt1.MaNhaCungCap);
                msNgayNhap.Text = Convert.ToDateTime(dt1.NgayNhap).ToString("dd-MM-yyyy");
                txtThanhTien.Text = dt1.ThanhTien.ToString();
                txtNhanVien.Text = dt1.NguoiLap.ToString();
                string ml = cboMaPN.SelectedValue.ToString();
                if (ml != null)
                {
                    dgvChiTietPN.DataSource = nl.GetChiTietPhieuNhaps_byMaPN(ml.ToString());
                }
            }
        }
    }
}
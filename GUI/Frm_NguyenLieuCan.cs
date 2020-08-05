using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class Frm_NguyenLieuCan : Form
    {
        NguyenLieuCan_BLL nl = new NguyenLieuCan_BLL();
        NguyenLieuNhap pTemp;
        List<NguyenLieuNhap> lstNL = new List<NguyenLieuNhap>();
        public Frm_NguyenLieuCan()
        {
            InitializeComponent();
        }
        public void load_CboDonVi()
        {
            List<string> lst = new List<string>() { "Kilogram", "Hộp" };
            cboDVT.DataSource = lst;
        }
        public void load_cboMaNL()
        {
            cboMaNL.DataSource = nl.GetNguyenLieuNhaps();
            cboMaNL.ValueMember = "MaNguyenLieu";
            cboMaNL.DisplayMember = "MaNguyenLieu";
        }

        private void Frm_NguyenLieuCan_Load(object sender, EventArgs e)
        {
            load_CboDonVi();
            load_cboMaNL();
            load_dgvNL();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }
        
        public void load_dgvNL()
        {
            dgvNguyenLieu.DataSource = nl.GetNguyenLieuNhaps();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn thật sự muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) this.Close();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                btnTao.Enabled = false;
                btnThem.Enabled = true;
                cboMaNL.Enabled = false;
                string ma = nl.phatSinhMaTuDong();
                cboMaNL.Text = ma;
                pTemp = new NguyenLieuNhap();
                pTemp.MaNguyenLieu = cboMaNL.Text;
                pTemp.TenNguyenLieu = txtTen.Text;
                pTemp.DonViTinh = cboDVT.SelectedValue.ToString();
               
                pTemp.DonGia = Convert.ToDecimal(txtDonGia.Text.ToString());
                txtTen.Text = " ";
                txtDonGia.Text = " ";
                
                txtTen.Focus();
            }catch(Exception ex)
            {

            }
            

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public bool kiemTraTonTai_MaNL(string ml, List<NguyenLieuNhap> lst)
        {
            foreach(var item in lst)
            {
                if (item.MaNguyenLieu == ml)
                    return true;
            }
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            try
            {
                string ma = cboMaNL.Text;
                string ten = txtTen.Text;
                string dvt = cboDVT.SelectedValue.ToString();
               
                string donGia = txtDonGia.Text;
                if(kiemTraTonTai_MaNL(ma, lstNL) == false)
                {
                    lstNL.Add(new NguyenLieuNhap { MaNguyenLieu = ma, TenNguyenLieu = ten, DonViTinh = dvt, DonGia = Convert.ToDecimal(donGia) });
                    var source = new BindingSource();
                    source.DataSource = lstNL;
                    dgvNguyenLieu.DataSource = null;
                    dgvNguyenLieu.DataSource = source;
                }
                else
                {
                    DialogResult r = MessageBox.Show("Nguyên liệu thêm đã có bạn muốn update lại không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (kiemTraTonTai_MaNL(ma, lstNL))
                        {
                            foreach (NguyenLieuNhap n in lstNL)
                            {
                                if (n.MaNguyenLieu.Equals(ma))
                                {
                                    n.TenNguyenLieu = ten;
                                    n.DonViTinh = dvt;
                                    
                                    n.DonGia = Convert.ToDecimal(donGia);
                                }
                            }
                            var source = new BindingSource();
                            source.DataSource = lstNL;
                            dgvNguyenLieu.DataSource = null;
                            dgvNguyenLieu.DataSource = source;
                        }
                    }
                }
            }catch(Exception ex)
            {

            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (gridView1.GetRowCellValue(e.RowHandle, MaNL).ToString() != string.Empty)
                {
                    cboMaNL.Text = gridView1.GetRowCellValue(e.RowHandle, MaNL).ToString();
                    txtTen.Text = gridView1.GetRowCellValue(e.RowHandle, TenNL).ToString();//?
                    cboDVT.Text = gridView1.GetRowCellValue(e.RowHandle, DonVi).ToString();
                    
                    txtDonGia.Text = gridView1.GetRowCellValue(e.RowHandle, DonGia).ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnTao.Enabled = true;
           
            try
            {

                DialogResult r = MessageBox.Show("Muốn lưu tất cả?", "Không thể sửa xóa nữa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    dgvNguyenLieu.Enabled = true;

                    bool kq = nl.them(lstNL);
                    if (kq == true)
                    {
                        btnTao.Enabled = true;
                        btnLuu.Enabled = false;
                        load_cboMaNL();
                        load_dgvNL();
                        pTemp = null;
                        
                        MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThem.Enabled = false;
                        btnXoa.Enabled = false;
                        cboMaNL.Enabled = true;
                        lstNL.Clear();
                        
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = cboMaNL.Text;
                if (kiemTraTonTai_MaNL(ma, lstNL))
                {
                    DialogResult r = MessageBox.Show("Muốn Xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        foreach (NguyenLieuNhap n in lstNL)
                        {
                            if (n.MaNguyenLieu.Equals(ma))
                            {
                                lstNL.Remove(n);
                                break;
                            }
                        }
                        var source = new BindingSource();
                        source.DataSource = lstNL;
                        dgvNguyenLieu.DataSource = null;
                        dgvNguyenLieu.DataSource = source;
                    }
                }
                else
                {

                    MessageBox.Show("Nguyên liệu không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cboMaNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            NguyenLieuNhap ma = (NguyenLieuNhap)nl.timMaNL(cboMaNL.SelectedValue.ToString());
            if (ma != null)
            {
                txtTen.Text = ma.TenNguyenLieu.ToString();
                txtDonGia.Text = ma.DonGia.ToString();
                cboDVT.Text = ma.DonViTinh.ToString();
            }
        }
    }
}

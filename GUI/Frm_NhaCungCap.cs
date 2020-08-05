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
    public partial class Frm_NhaCungCap : Form
    {
        NhaCungCap_BLL ncc = new NhaCungCap_BLL();
        NhaCungCap pTemp;
        List<NhaCungCap> lstNCC = new List<NhaCungCap>();
        public Frm_NhaCungCap()
        {
            InitializeComponent();
        }
        public void load_CboMa()
        {
            cboNCC.DataSource = ncc.GetNhaCungCaps();
            cboNCC.ValueMember = "MaNhaCungCap";
            cboNCC.DisplayMember = "MaNhaCungCap";
        }
        public void load_gvNcc()
        {
            gvNCC.DataSource = ncc.GetNhaCungCaps();
        }

        private void Frm_NhaCungCap_Load(object sender, EventArgs e)
        {
            load_CboMa();
            load_gvNcc();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhaCungCap ma = (NhaCungCap)ncc.timMaNCC(cboNCC.SelectedValue.ToString());
            if( ma != null)
            {
                txtTen.Text = ma.TenNhaCungCap.ToString();
                txtDiaChi.Text = ma.DiaChi.ToString();
                txtSDT.Text = ma.SoDienThoai.ToString();
            }
            //string ml = cboNCC.SelectedValue.ToString();
            //if (ml != null)
            //    gvNCC.DataSource = ncc.getNhaCungCap_ByMaNCC(ml);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn thật sự muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) this.Close();
        }
        public bool kiemTra_MaNCC(string ma, List<NhaCungCap> lst)
        {
            foreach(var item in lst)
            {
                if (item.MaNhaCungCap == ma)
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
                string ma = cboNCC.Text;
                string ten = txtTen.Text;
                string diaChi = txtDiaChi.Text;
                string sdt = txtSDT.Text;
                if(sdt.Length > 10)
                {
                    MessageBox.Show("Số điện thoại chỉ được nhập tối đa 10 kí tự");
                }

                else if (kiemTra_MaNCC(cboNCC.Text, lstNCC) == false)
                {
                    lstNCC.Add(new NhaCungCap { MaNhaCungCap = ma, TenNhaCungCap = ten, DiaChi = diaChi, SoDienThoai = sdt });
                    var source = new BindingSource();
                    source.DataSource = lstNCC;
                    gvNCC.DataSource = null;
                    gvNCC.DataSource = source;
                }
                else
                {
                    DialogResult r = MessageBox.Show("Nhà cung cấp thêm đã có bạn muốn update lại không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if(kiemTra_MaNCC(ma, lstNCC))
                        {
                            foreach(NhaCungCap n in lstNCC)
                            {
                                if(n.MaNhaCungCap.Equals(ma))
                                {
                                    n.TenNhaCungCap = ten;
                                    n.DiaChi = diaChi;
                                    n.SoDienThoai = sdt;
                                }
                            }
                            var source = new BindingSource();
                            source.DataSource = lstNCC;
                            gvNCC.DataSource = null;
                            gvNCC.DataSource = source;
                        }
                    }
                }
            }catch(Exception ex)
            {

            }
            

            

        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            btnTao.Enabled = false;
            btnThem.Enabled = true;
            
            string ma = ncc.phatSinhMaTuDong();
            cboNCC.Text = ma;
            pTemp = new NhaCungCap();
            pTemp.MaNhaCungCap = ma;
            pTemp.TenNhaCungCap = txtTen.Text;
            pTemp.DiaChi = txtDiaChi.Text;
            pTemp.SoDienThoai = txtSDT.Text;
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnTao.Enabled = true;
            try
            {

                DialogResult r = MessageBox.Show("Muốn lưu tất cả?", "Không thể sửa xóa nữa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    gvNCC.Enabled = true;
                   
                    bool kq = ncc.them(lstNCC);
                    if (kq == true)
                    {
                        btnTao.Enabled = true;
                        btnLuu.Enabled = false;
                        load_CboMa();
                        load_gvNcc();
                        pTemp = null;
                        lstNCC.Clear();
                        MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                string ma = cboNCC.Text;
                string ten = txtTen.Text;
                string diaChi = txtDiaChi.Text;
                string sdt = txtSDT.Text;


                if (kiemTra_MaNCC(cboNCC.Text, lstNCC))
                {
                    DialogResult r = MessageBox.Show("Muốn Xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                      foreach (NhaCungCap n in lstNCC)
                        {
                          if (n.MaNhaCungCap.Equals(ma))
                            {
                              lstNCC.Remove(n);
                                break;
                            }
                        }
                            var source = new BindingSource();
                            source.DataSource = lstNCC;
                            gvNCC.DataSource = null;
                            gvNCC.DataSource = source;

                     }
                 }
                else
                {
                    
                        MessageBox.Show("Nhà cung cấp không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (gridView1.GetRowCellValue(e.RowHandle, MaNCC).ToString() != string.Empty)
                {
                    cboNCC.Text = gridView1.GetRowCellValue(e.RowHandle, MaNCC).ToString();
                    txtTen.Text = gridView1.GetRowCellValue(e.RowHandle, TenNCC).ToString();//?
                    txtDiaChi.Text = gridView1.GetRowCellValue(e.RowHandle, DiaChidc).ToString();
                    txtSDT.Text = gridView1.GetRowCellValue(e.RowHandle, SDT).ToString();
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            String tr = txtSDT.Text;
          
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || tr.Length > 9 || (e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }
    }
}

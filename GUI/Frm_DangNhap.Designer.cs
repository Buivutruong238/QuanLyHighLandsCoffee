namespace GUI
{
    partial class Frm_DangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DangNhap));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TenDN = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(150, 90);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "TÊN ĐĂNG NHẬP :";
            // 
            // txt_TenDN
            // 
            this.txt_TenDN.Location = new System.Drawing.Point(266, 83);
            this.txt_TenDN.Name = "txt_TenDN";
            this.txt_TenDN.Size = new System.Drawing.Size(163, 23);
            this.txt_TenDN.TabIndex = 1;
            this.txt_TenDN.Text = "truong";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(150, 150);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 17);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "MẬT KHẨU :";
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Location = new System.Drawing.Point(266, 143);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(163, 23);
            this.txt_MatKhau.TabIndex = 1;
            this.txt_MatKhau.Text = "123";
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Location = new System.Drawing.Point(195, 200);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(108, 39);
            this.btn_DangNhap.TabIndex = 2;
            this.btn_DangNhap.Text = "ĐĂNG NHẬP";
            this.btn_DangNhap.UseVisualStyleBackColor = true;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(321, 200);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(108, 39);
            this.btn_Thoat.TabIndex = 2;
            this.btn_Thoat.Text = "THOÁT";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // Frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 273);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_TenDN);
            this.Controls.Add(this.labelControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Frm_DangNhap.IconOptions.SvgImage")));
            this.Name = "Frm_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DangNhap_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_TenDN;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Button btn_Thoat;
    }
}
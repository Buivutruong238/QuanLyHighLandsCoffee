namespace GUI
{
    partial class Mon_UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_TenMon = new System.Windows.Forms.Label();
            this.lbl_GiaBan = new System.Windows.Forms.Label();
            this.pictureBox_MonUC = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MonUC)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TenMon
            // 
            this.lbl_TenMon.AutoEllipsis = true;
            this.lbl_TenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenMon.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_TenMon.Location = new System.Drawing.Point(0, 203);
            this.lbl_TenMon.Name = "lbl_TenMon";
            this.lbl_TenMon.Size = new System.Drawing.Size(175, 32);
            this.lbl_TenMon.TabIndex = 1;
            this.lbl_TenMon.Text = "label1";
            this.lbl_TenMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_TenMon.Click += new System.EventHandler(this.pictureBox_MonUC_Click);
            this.lbl_TenMon.MouseEnter += new System.EventHandler(this.pictureBox_MonUC_MouseEnter);
            this.lbl_TenMon.MouseLeave += new System.EventHandler(this.pictureBox_MonUC_MouseLeave);
            // 
            // lbl_GiaBan
            // 
            this.lbl_GiaBan.AutoEllipsis = true;
            this.lbl_GiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GiaBan.ForeColor = System.Drawing.Color.Red;
            this.lbl_GiaBan.Location = new System.Drawing.Point(0, 178);
            this.lbl_GiaBan.Name = "lbl_GiaBan";
            this.lbl_GiaBan.Size = new System.Drawing.Size(175, 23);
            this.lbl_GiaBan.TabIndex = 2;
            this.lbl_GiaBan.Text = "label2";
            this.lbl_GiaBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_GiaBan.Click += new System.EventHandler(this.pictureBox_MonUC_Click);
            this.lbl_GiaBan.MouseEnter += new System.EventHandler(this.pictureBox_MonUC_MouseEnter);
            this.lbl_GiaBan.MouseLeave += new System.EventHandler(this.pictureBox_MonUC_MouseLeave);
            // 
            // pictureBox_MonUC
            // 
            this.pictureBox_MonUC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox_MonUC.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_MonUC.Name = "pictureBox_MonUC";
            this.pictureBox_MonUC.Size = new System.Drawing.Size(175, 175);
            this.pictureBox_MonUC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_MonUC.TabIndex = 0;
            this.pictureBox_MonUC.TabStop = false;
            this.pictureBox_MonUC.Click += new System.EventHandler(this.pictureBox_MonUC_Click);
            this.pictureBox_MonUC.MouseEnter += new System.EventHandler(this.pictureBox_MonUC_MouseEnter);
            this.pictureBox_MonUC.MouseLeave += new System.EventHandler(this.pictureBox_MonUC_MouseLeave);
            // 
            // Mon_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_GiaBan);
            this.Controls.Add(this.lbl_TenMon);
            this.Controls.Add(this.pictureBox_MonUC);
            this.Name = "Mon_UserControl";
            this.Size = new System.Drawing.Size(175, 235);
            this.MouseEnter += new System.EventHandler(this.pictureBox_MonUC_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.pictureBox_MonUC_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MonUC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_MonUC;
        private System.Windows.Forms.Label lbl_TenMon;
        private System.Windows.Forms.Label lbl_GiaBan;
    }
}

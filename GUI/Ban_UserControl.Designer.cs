namespace GUI
{
    partial class Ban_UserControl
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
            this.lbl_TenBan = new System.Windows.Forms.Label();
            this.lbl_TrangThai = new System.Windows.Forms.Label();
            this.pictureBox_Ban = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Ban)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TenBan
            // 
            this.lbl_TenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenBan.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_TenBan.Location = new System.Drawing.Point(3, 103);
            this.lbl_TenBan.Name = "lbl_TenBan";
            this.lbl_TenBan.Size = new System.Drawing.Size(107, 20);
            this.lbl_TenBan.TabIndex = 1;
            this.lbl_TenBan.Text = "label1";
            this.lbl_TenBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_TenBan.Click += new System.EventHandler(this.pictureBox_Ban_Click);
            this.lbl_TenBan.MouseEnter += new System.EventHandler(this.pictureBox_Ban_MouseEnter);
            this.lbl_TenBan.MouseLeave += new System.EventHandler(this.pictureBox_Ban_MouseLeave);
            // 
            // lbl_TrangThai
            // 
            this.lbl_TrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TrangThai.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_TrangThai.Location = new System.Drawing.Point(3, 123);
            this.lbl_TrangThai.Name = "lbl_TrangThai";
            this.lbl_TrangThai.Size = new System.Drawing.Size(107, 27);
            this.lbl_TrangThai.TabIndex = 2;
            this.lbl_TrangThai.Text = "label2";
            this.lbl_TrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_TrangThai.Click += new System.EventHandler(this.pictureBox_Ban_Click);
            this.lbl_TrangThai.MouseEnter += new System.EventHandler(this.pictureBox_Ban_MouseEnter);
            this.lbl_TrangThai.MouseLeave += new System.EventHandler(this.pictureBox_Ban_MouseLeave);
            // 
            // pictureBox_Ban
            // 
            this.pictureBox_Ban.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox_Ban.Image = global::GUI.Properties.Resources.ban;
            this.pictureBox_Ban.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Ban.Name = "pictureBox_Ban";
            this.pictureBox_Ban.Size = new System.Drawing.Size(110, 100);
            this.pictureBox_Ban.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Ban.TabIndex = 0;
            this.pictureBox_Ban.TabStop = false;
            this.pictureBox_Ban.Click += new System.EventHandler(this.pictureBox_Ban_Click);
            this.pictureBox_Ban.MouseEnter += new System.EventHandler(this.pictureBox_Ban_MouseEnter);
            this.pictureBox_Ban.MouseLeave += new System.EventHandler(this.pictureBox_Ban_MouseLeave);
            // 
            // Ban_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_TrangThai);
            this.Controls.Add(this.lbl_TenBan);
            this.Controls.Add(this.pictureBox_Ban);
            this.Name = "Ban_UserControl";
            this.Size = new System.Drawing.Size(110, 150);
            this.MouseEnter += new System.EventHandler(this.pictureBox_Ban_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.pictureBox_Ban_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Ban)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Ban;
        private System.Windows.Forms.Label lbl_TenBan;
        private System.Windows.Forms.Label lbl_TrangThai;
    }
}

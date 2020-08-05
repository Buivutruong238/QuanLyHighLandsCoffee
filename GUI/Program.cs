﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_DangNhap());
            //Application.Run(new Frm_NhapNguyenLieu());
            //Application.Run(new Frm_NhaCungCap());
            //Application.Run(new Frm_NguyenLieuCan());
        }
    }
}

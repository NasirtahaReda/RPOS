using RedaPOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //stable version

                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //  DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                // Application.Run(new NormalUserForm(db));
                //Application.Run(new TestForm());
                Form frm = new Form();
                frm.WindowState = FormWindowState.Maximized;
                RequestItem uc = new RequestItem();
                //WindowsApplication1.Form1 uc = new WindowsApplication1.Form1();
                //frm.Controls.Add(uc);
                //frm.Controls[0].Dock = DockStyle.Fill;
                Application.Run(uc);
               // Application.Run(new AdminUserForm(db));
                //Application.Run(new Login());

              //Application.Run(new Inventory_Direct());

                ////using (Login l = new Login()) //if data ok, form will close it self!
                ////{
                ////    if (l.ShowDialog() == DialogResult.OK)
                ////    {
                ////       DevExpress.UserSkins.BonusSkins.Register();
                ////        Application.Run(new Dashboard());
                ////    }
                ////}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace,ex.Message);
            }
        }
    }
}

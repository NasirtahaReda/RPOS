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
using DevExpress.XtraReports.UI;
using WinForm.Reports;

namespace WinForm.Reports
{
    public partial class UserLoginOptions : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public UserLoginOptions()
        {
            InitializeComponent();
        }

        private void UserLoginOptions_Load(object sender, EventArgs e)
        {
            try
            {
                userBindingSource.DataSource = db.Users.Where(s => s.IsEnable == true).ToList();
                cmbDate.DateTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {

            ////    int ReorderPoint =  Convert.ToInt32(txtReorderPoint.EditValue);
            ////    //vwInventoryBindingSource.DataSource = null;
            ////    var list = from s in db.vw_Inventory where s.CurrentQuanity < ReorderPoint  select s ;
            ////    if (rgSortBy.SelectedIndex == 1)
            ////    {
            ////        if (rgSortDirection.SelectedIndex == 1)
            ////        {
            ////            list = from s in list orderby s.Name select s;
            ////        }
            ////        else if (rgSortDirection.SelectedIndex == 0)
            ////        {
            ////            list = from s in list orderby s.Name descending select s;
            ////        }
            ////    }
            ////    else if (rgSortBy.SelectedIndex == 0)
            ////    {
            ////        if (rgSortDirection.SelectedIndex == 1)
            ////        {
            ////            list = from s in list orderby s.CurrentQuanity select s;
            ////        }
            ////        else if (rgSortDirection.SelectedIndex == 0)
            ////        {
            ////            list = from s in list orderby s.CurrentQuanity descending select s;
            ////        }
                   
            ////    }
            ////    if (list.Count() <= 0)
            ////    {
            ////        MessageBox.Show("الفاتورة لا تحتوي علي أصناف", "طباعة فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////        return;
            ////    }
            ////    ReorderRPT rpt = new ReorderRPT();
            ////    rpt.DataSource = list.ToList();
            ////    try
            ////    {
            ////        string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
            ////        ReportPrintTool tool = new ReportPrintTool(rpt);
            ////        tool.ShowPreview(); //Print(InvoicePrinter);//
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////         ModuleClass.ShowMessage(this, ex, "خطأ", null);
            ////    }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxUsers.SelectedItem != null)
                {
                    ////int userId = Convert.ToInt32(listBoxUsers.GetItemValue(listBoxUsers.SelectedIndex));
                    ////var loginTime       = db.UserLogins.Where(s => s.UserID == userId && s.Type == false && s.Date.Day == cmbDate.DateTime.Day && s.Date.Month == cmbDate.DateTime.Month && s.Date.Year == cmbDate.DateTime.Year).Select(s => s.Date);
                    ////var LogoutTime = db.UserLogins.Where(s => s.UserID == userId && s.Type == true && s.Date.Day == cmbDate.DateTime.Day && s.Date.Month == cmbDate.DateTime.Month && s.Date.Year == cmbDate.DateTime.Year).Select(s => s.Date);
                    ////if (loginTime != null && loginTime.Count() > 0)
                    ////{
                    ////    var first = (from s in loginTime select s).Min();
                    ////    lblLginTime.Text = first.TimeOfDay.ToString();
                    ////}
                    ////else
                    ////{
                    ////    lblLginTime.Text = "0";
                    ////}

                    ////if (LogoutTime != null && LogoutTime.Count() > 0)
                    ////{
                    ////    var last = (from s in loginTime select s).Max();
                    ////    lblLogoutTime.Text = last.TimeOfDay.ToString();
                    ////}
                    ////else
                    ////{
                    ////    lblLogoutTime.Text = "0";
                    ////}
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}
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
using RedaPOS;
using System.Data.Entity;

namespace WinForm.Reports
{
    public partial class UserPaymentReportOptions : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public UserPaymentReportOptions(bool isAdmin, int UserID)
        {
            try
            {
                InitializeComponent();
                userBindingSource.DataSource = db.Users.Where(s => s.IsEnable == true).ToList();
                branchBindingSource.DataSource = db.Branches.ToList();
                if (isAdmin)
                {
                    cbEnableShifUser.Checked = false;
                    cbEnableShifUser.Checked = true;
                    cmbUsersRPT.EditValue = UserID;
                }
                else
                {
                    cbEnableShifUser.Checked = true;
                    cbEnableShifUser.Enabled = false;
                    cmbUsersRPT.EditValue = UserID;
                    cmbUsersRPT.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void StockReportOptions_Load(object sender, EventArgs e)
        {
            cmbFrom.DateTime =new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            cmbTo.DateTime = DateTime.Now;
         
           // cbEnableShifUser.Checked = false;
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                UserPaymentRPT rpt = new UserPaymentRPT();

               
                DateTime from = new DateTime(cmbFrom.DateTime.Year, cmbFrom.DateTime.Month, cmbFrom.DateTime.Day,0,0,0);
                DateTime to = new DateTime(cmbTo.DateTime.Year, cmbTo.DateTime.Month, cmbTo.DateTime.Day,23,59,59);

                var list = db.UserPayments.Where(s => s.Date >= from && s.Date <= to);
                //s => s.Date.Year >= from.Year && s.Date.Month >= from.Month && s.Date.Day >= from.Day && s.Date.Year <= to.Year && s.Date.Month <= to.Month && s.Date.Day <= to.Day);
                Decimal amountHour = 0;
                Decimal expence = 0;

                if (cbEnableShifUser.Checked)
                {
                    int userId = Convert.ToInt32(cmbUsersRPT.GetColumnValue("ID"));
                    list = list.Where(s => s.UserID == userId);
                     amountHour = list.Where(s => s.PaymentType == 1).Select(s => (Decimal?)s.Amount).Sum() ?? 0;
                     expence = list.Where(s => s.PaymentType == 2).Select(s => (Decimal?)s.Amount).Sum() ?? 0;
                }
                if (list.Any())
                {
                    //  rpt.DataSource = list;
                    rpt.DataSource = list.ToList();
                    //rpt.parameterBranchName.Value = UserData.Default.BranchID;
                    rpt.parameterFromDate.Value = cmbFrom.DateTime;
                    rpt.parameterToDate.Value = cmbTo.DateTime;//cmbExpenseUser.GetColumnValue("FullName").ToString();
                    rpt.parameterUserName.Value = cmbUsersRPT.Text;
                    rpt.parameterTotalAmount.Value = amountHour.ToString();
                    rpt.parameterTotalExpense.Value = expence.ToString();
                    rpt.parameterNetAmount.Value = (amountHour - (Math.Abs(expence))).ToString();
                    decimal demand = list.OrderByDescending(s => s.ID).AsEnumerable().First().Balance;
                    rpt.parameterCurrentDemand.Value = demand;
                    int NumOfShift = list.Where(s => s.PaymentType == 1).Select(s => DbFunctions.TruncateTime(s.Date)).Distinct().Count();
                    rpt.parameterNumOfShift.Value = NumOfShift;
                    try
                    {
                        ReportPrintTool tool = new ReportPrintTool(rpt);
                        tool.ShowPreview();
                    }
                    catch (Exception ex)
                    {
                         ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                    }
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات في هذا التاريخ");
                }



                ////int ReorderPoint =  Convert.ToInt32(txtReorderPoint.EditValue);
                //////vwInventoryBindingSource.DataSource = null;
                ////var list = from s in db.vw_Inventory where s.CurrentQuanity < ReorderPoint  select s ;
                ////if (rgSortBy.SelectedIndex == 1)
                ////{
                ////    if (rgSortDirection.SelectedIndex == 1)
                ////    {
                ////        list = from s in list orderby s.Name select s;
                ////    }
                ////    else if (rgSortDirection.SelectedIndex == 0)
                ////    {
                ////        list = from s in list orderby s.Name descending select s;
                ////    }
                ////}
                ////else if (rgSortBy.SelectedIndex == 0)
                ////{
                ////    if (rgSortDirection.SelectedIndex == 1)
                ////    {
                ////        list = from s in list orderby s.CurrentQuanity select s;
                ////    }
                ////    else if (rgSortDirection.SelectedIndex == 0)
                ////    {
                ////        list = from s in list orderby s.CurrentQuanity descending select s;
                ////    }
                   
                ////}
                ////if (list.Count() <= 0)
                ////{
                ////    MessageBox.Show("الفاتورة لا تحتوي علي أصناف", "طباعة فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ////    return;
                ////}
                ////ReorderRPT rpt = new ReorderRPT( ReorderPoint.ToString());
                ////rpt.DataSource = list.ToList();
                ////try
                ////{
                ////    string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                ////    ReportPrintTool tool = new ReportPrintTool(rpt);
                ////    tool.ShowPreview(); //Print(InvoicePrinter);//
                ////}
                ////catch (Exception ex)
                ////{
                ////     ModuleClass.ShowMessage(this, ex, "خطأ", null);
                ////}
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void cbEnableShifUser_CheckedChanged(object sender, EventArgs e)
        {
            cmbUsersRPT.Enabled = cbEnableShifUser.Checked;
        }

        private void cbEnableBranch_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void cbEnableExpenseUser_CheckedChanged(object sender, EventArgs e)
        {
     
        }

        private void cmbBranch_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbFrom_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
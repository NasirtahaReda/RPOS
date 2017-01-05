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

namespace WinForm.Reports
{
    public partial class ExpenseReportOptions : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities();
        public ExpenseReportOptions()
        {
            InitializeComponent();
            userBindingSource.DataSource = db.Users.ToList();
            branchBindingSource.DataSource = db.Branches.ToList();
        }

        private void StockReportOptions_Load(object sender, EventArgs e)
        {
            cmbFrom.DateTime =new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            cmbTo.DateTime = DateTime.Now;
            cbEnableBranch.Checked= false;
            cbEnableExpenseUser.Checked = false;
            cbEnableShifUser.Checked = false;
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                ExpenseRPT rpt = new ExpenseRPT();

               
                
                


                DateTime from = cmbFrom.DateTime;
                DateTime to = cmbTo.DateTime;

                var list = db.vw_Expense.Where(s => s.Date.Year >= from.Year && s.Date.Month >= from.Month && s.Date.Day >= from.Day && s.Date.Year <= to.Year && s.Date.Month <= to.Month && s.Date.Day <= to.Day);
                if (cbEnableBranch.Checked)
                {
                    int branchID = Convert.ToInt32(cmbBranch.GetColumnValue("ID"));
                    list = list.Where(s => s.BranchID == branchID);
                }
                if (cbEnableExpenseUser.Checked)
                {
                    int expnsesUserId = Convert.ToInt32(cmbExpenseUser.GetColumnValue("ID"));
                    list = list.Where(s => s.UserID == expnsesUserId);
                }
                if (cbEnableShifUser.Checked)
                {
                    int userId = Convert.ToInt32(cmbUsersRPT.GetColumnValue("ID"));
                    list = list.Where(s => s.InsertedUserId == userId);
                }
                if (list.Any())
                {
                    //  rpt.DataSource = list;
                    rpt.DataSource = list.ToList();
                    //rpt.parameterBranchName.Value = UserData.Default.BranchID;
                    rpt.parameterFromDate.Value = cmbFrom.DateTime;
                    rpt.parameterToDate.Value = cmbTo.DateTime;//cmbExpenseUser.GetColumnValue("FullName").ToString();
                    try
                    {
                        ReportPrintTool tool = new ReportPrintTool(rpt);
                        tool.ShowPreview();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("لا توجد منصرفات في هذا التاريخ");
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
                ////    MessageBox.Show(ex.Message);
                ////}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbEnableShifUser_CheckedChanged(object sender, EventArgs e)
        {
            cmbUsersRPT.Enabled = cbEnableShifUser.Checked;
        }

        private void cbEnableBranch_CheckedChanged(object sender, EventArgs e)
        {
            cmbBranch.Enabled = cbEnableBranch.Checked;
        }

        private void cbEnableExpenseUser_CheckedChanged(object sender, EventArgs e)
        {
            cmbExpenseUser.Enabled = cbEnableExpenseUser.Checked;
        }
    }
}
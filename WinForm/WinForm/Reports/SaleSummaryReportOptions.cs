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
using DevExpress.XtraEditors.Controls;

namespace WinForm.Reports
{
    public partial class SaleSummaryReportOptions : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public SaleSummaryReportOptions()
        {
            InitializeComponent();
        }

        private void SaleSummaryReportOptions_Load(object sender, EventArgs e)
        {
            try
            {
                cmbDate.DateTime = DateTime.Now;
                userBindingSource.DataSource = db.Users.Where(s => s.IsEnable == true).ToList();
                branchBindingSource.DataSource = db.Branches.ToList();
            }
            catch(Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {

                var ids = (from CheckedListBoxItem item in cmbUsers.Properties.Items 
                           where item.CheckState == CheckState.Checked
                           select (int)item.Value).ToArray();
               
                DateTime frm = new DateTime(cmbDate.DateTime.Year, cmbDate.DateTime.Month, cmbDate.DateTime.Day, 0, 0, 0);
                DateTime to = new DateTime(cmbDate.DateTime.Year, cmbDate.DateTime.Month, cmbDate.DateTime.Day, 23, 59, 59);
                int branchId = Convert.ToInt32(cmbBranch.EditValue);
                //vwInventoryBindingSource.DataSource = null;
                var list = from s in db.vw_SaleReport where s.BranchID== branchId && s.Flag == 1 && s.Date > frm && s.Date < to && ids.Contains(s.UserID) select s;
                if (list.Count() <= 0)
                {
                    MessageBox.Show("الفاتورة لا تحتوي علي أصناف", "طباعة فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //if (rgSortBy.SelectedIndex == 1)
                //{
                //    if (rgSortDirection.SelectedIndex == 1)
                //    {
                //     list = from s in list orderby s.Name select s;
                //    }
                //    else if (rgSortDirection.SelectedIndex == 0)
                //    {
                //        list = from s in list orderby s.Name descending select s;
                //    }
                //}
                //else if (rgSortBy.SelectedIndex == 0)
                //{
                //    if (rgSortDirection.SelectedIndex == 1)
                //    {
                //        list = from s in list orderby s.CurrentQuanity select s;
                //    }
                //    else if (rgSortDirection.SelectedIndex == 0)
                //    {
                //        list = from s in list orderby s.CurrentQuanity descending select s;
                //    }
                   
                //}
                SaleSummaryRPT rpt = new SaleSummaryRPT();
                string BranchName = cmbBranch.GetColumnValue("BranchName").ToString();
                rpt.parameterBranchName.Value = BranchName;
                rpt.DataSource = list.ToList();
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
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}
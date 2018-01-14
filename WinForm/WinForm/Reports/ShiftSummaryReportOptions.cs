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
using RedaPOS.Reports;

namespace WinForm.Reports
{
    public partial class ShiftSummaryReportOptions : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public ShiftSummaryReportOptions()
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


                FinancialDailyRPT rpt = new FinancialDailyRPT();


                DateTime from = cmbDate.DateTime;
                var summary = db.FinancialSummary(from);

                if (summary.Any())
                {
                    rpt.bindingSource1.DataSource = summary.ToList();
                    rpt.parameterFrom.Value = cmbDate.DateTime;
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
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}
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
    public partial class StockReportOptions : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public StockReportOptions()
        {
            InitializeComponent();
        }

        private void StockReportOptions_Load(object sender, EventArgs e)
        {

        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {

                int ReorderPoint =  Convert.ToInt32(txtReorderPoint.EditValue);
                //vwInventoryBindingSource.DataSource = null;
                var list = from s in db.vw_Inventory where s.CurrentQuanity < ReorderPoint  select s ;
                if (rgSortBy.SelectedIndex == 1)
                {
                    if (rgSortDirection.SelectedIndex == 1)
                    {
                        list = from s in list orderby s.Name select s;
                    }
                    else if (rgSortDirection.SelectedIndex == 0)
                    {
                        list = from s in list orderby s.Name descending select s;
                    }
                }
                else if (rgSortBy.SelectedIndex == 0)
                {
                    if (rgSortDirection.SelectedIndex == 1)
                    {
                        list = from s in list orderby s.CurrentQuanity select s;
                    }
                    else if (rgSortDirection.SelectedIndex == 0)
                    {
                        list = from s in list orderby s.CurrentQuanity descending select s;
                    }
                   
                }
                if (list.Count() <= 0)
                {
                    MessageBox.Show("الفاتورة لا تحتوي علي أصناف", "طباعة فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                ReorderRPT rpt = new ReorderRPT( ReorderPoint.ToString());
                rpt.DataSource = list.ToList();
                try
                {
                    string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                    ReportPrintTool tool = new ReportPrintTool(rpt);
                    tool.ShowPreview(); //Print(InvoicePrinter);//
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
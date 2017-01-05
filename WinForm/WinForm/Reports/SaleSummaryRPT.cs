using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Linq;
using System.Data;

namespace WinForm.Reports
{
    public partial class SaleSummaryRPT : DevExpress.XtraReports.UI.XtraReport
    {
        public SaleSummaryRPT()
        {
            InitializeComponent();
        }

        private void SaleSummaryRPT_AfterPrint(object sender, EventArgs e)
        {
           
        }

        private void txtDiscount_AfterPrint(object sender, EventArgs e)
        {
 //
        }

        private void txtDiscount_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            //var nui = e.Result;
            //txtNet.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtDiscount.Text)).ToString();
        }

        private void xrTableCell14_PreviewClick(object sender, PreviewMouseEventArgs e)
        {

        }

        private void xrTableCell14_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
         int invoiceID = Convert.ToInt32(e.Brick.Text);

         var currentRow = db.vw_SaleReport.Where(s => s.ID == invoiceID).SingleOrDefault(); //(DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
         SaleAllRpt rpt = new SaleAllRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), currentRow.ID.ToString(), currentRow.UserName.ToString());
            var list = from s in db.vw_Sale2 where s.SaleInvoiceID == invoiceID select s;
            rpt.DataSource = list.ToList();


            try
            {
              //  string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                ReportPrintTool tool = new ReportPrintTool(rpt);
                tool.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

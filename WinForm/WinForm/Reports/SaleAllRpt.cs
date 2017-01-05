using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RedaPOS;

namespace WinForm.Reports
{
    public partial class SaleAllRpt : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal discount;
        private decimal afterdiscount;

        public SaleAllRpt()
        {
            InitializeComponent();
        }

        public SaleAllRpt(decimal p1, decimal p2, string InvoiceNo, String UserName)
        {
            InitializeComponent();
            int branchID = Convert.ToInt32(UserData.Default.BranchID);
            // TODO: Complete member initialization
            this.discount = p1;
            this.afterdiscount = p2;
            lblAfterDiscount.Text = afterdiscount.ToString();
            lblDiscount.Text = discount.ToString();
            lblInvoiceNo.Text = InvoiceNo ;
            lblUser.Text = UserName;
           

        }

        private void xrTableRow4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

    }
}

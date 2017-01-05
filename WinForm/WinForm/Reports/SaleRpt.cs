using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RedaPOS;

namespace WinForm.Reports
{
    public partial class SaleRpt : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal discount;
        private decimal afterdiscount;
        decimal cashFromCustomer;
        decimal CashReturn;

        public SaleRpt()
        {
            InitializeComponent();
        }

        public SaleRpt(decimal Discount, decimal afterdiscount, decimal cashFromCustomer, decimal CashReturn, string InvoiceNo, String UserName)
        {
            InitializeComponent();
            int branchID = Convert.ToInt32(UserData.Default.BranchID);
            // TODO: Complete member initialization
            this.discount = Discount;
            this.afterdiscount = afterdiscount;
            this.cashFromCustomer = cashFromCustomer;
            this.CashReturn = CashReturn;
            lblAfterDiscount.Text = String.Format("{0:0.00}",afterdiscount.ToString());
            lblDiscount.Text = String.Format("{0:0.00}",discount.ToString());
            lblInvoiceNo.Text = branchID + " - "+InvoiceNo + " : رقم الفاتورة ";
            lblUser.Text = UserName;

            lblCashFromCustomer.Text =String.Format("{0:0.00}", cashFromCustomer.ToString());
            lblCashReturn.Text = String.Format("{0:0.00}", CashReturn.ToString());
            if (discount == 0)
            {
                lblDiscount.Visible = false;
                lblDiscountText.Visible = false;
            }

        }

        private void xrTableRow4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

    }
}

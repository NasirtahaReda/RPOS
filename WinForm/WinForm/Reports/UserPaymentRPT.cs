using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinForm.Reports
{
    public partial class UserPaymentRPT : DevExpress.XtraReports.UI.XtraReport
    {
        public UserPaymentRPT()
        {
            InitializeComponent();
        }

        private void xrTable2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}

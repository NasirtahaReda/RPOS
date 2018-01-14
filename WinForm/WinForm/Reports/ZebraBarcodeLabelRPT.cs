using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinForm.Reports
{
    public partial class ZebraBarcodeLabelRPT : DevExpress.XtraReports.UI.XtraReport
    {
        public ZebraBarcodeLabelRPT()
        {
            InitializeComponent();
        }
        public ZebraBarcodeLabelRPT(string barcode, string Name, string price, bool printPrice)
        {
            InitializeComponent();
            txtBarcode.Text = barcode;
            txtName.Text = Name;
            if (printPrice)
            {
                txtPrice.Text = price;
                
            }
            else
            {
                txtPrice.Text = "";
                lblCurrency.Text = "";
            }

        }

    }
}

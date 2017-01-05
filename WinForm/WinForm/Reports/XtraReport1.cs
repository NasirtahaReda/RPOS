using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinForm.Reports
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1(string barcode, string Name, string price)
        {
            InitializeComponent();
            txtBarcode.Text = barcode;
            txtName.Text = Name;
            txtPrice.Text = price;
        }

    }
}

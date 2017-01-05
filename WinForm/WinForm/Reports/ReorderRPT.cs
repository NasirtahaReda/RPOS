using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinForm.Reports
{
    public partial class ReorderRPT : DevExpress.XtraReports.UI.XtraReport
    {
        private string p;

       

        public ReorderRPT(string p)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.xrLabelTitle.Text = "  أصناف كمياتها أقل من" + p;
        }

    }
}

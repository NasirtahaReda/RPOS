using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RedaPOS;
using DevExpress.XtraPrinting.BarCode;
using System.Drawing.Printing;

namespace WinForm.Reports
{
    public partial class SaleFullRpt : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal discount;
        private decimal afterdiscount;

        public SaleFullRpt()
        {
            InitializeComponent();
        }
        public XRBarCode CreateQRCodeBarCode(string BarCodeText)
        {
            // Create a bar code control.
            XRBarCode barCode = new XRBarCode();

            // Set the bar code's type to QRCode.
            barCode.Symbology = new QRCodeGenerator();

            // Adjust the bar code's main properties.
            barCode.Text = BarCodeText;
            barCode.Width = 400;
            barCode.Height = 150;

            // If the AutoModule property is set to false, uncomment the next line.
            barCode.AutoModule = true;
            // barcode.Module = 3;

            // Adjust the properties specific to the bar code type.
            ((QRCodeGenerator)barCode.Symbology).CompactionMode = QRCodeCompactionMode.AlphaNumeric;
            ((QRCodeGenerator)barCode.Symbology).ErrorCorrectionLevel = QRCodeErrorCorrectionLevel.H;
            ((QRCodeGenerator)barCode.Symbology).Version = QRCodeVersion.AutoVersion;

            return barCode;
        }
        public SaleFullRpt(decimal p1, decimal p2, string InvoiceNo, String UserName)
        {
            InitializeComponent();
            int branchID = Convert.ToInt32(UserData.Default.BranchID);
            // TODO: Complete member initialization
            this.discount = p1;
            this.afterdiscount = p2;
            lblAfterDiscount.Text = (afterdiscount - discount).ToString();
            lblDiscount.Text = discount.ToString();
            lblInvoiceNo.Text = branchID + " - "+InvoiceNo + " : رقم الفاتورة ";
            lblUser.Text = UserName;
            if (discount == 0)
            {
                lblDiscount.Visible = false;
                lblDiscountText.Visible = false;
            }

        }
        private void XtraReport1_BeforePrint(object sender, PrintEventArgs e)
        {
            
        }
        private void xrTableRow4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void reportHeaderBand1_BeforePrint(object sender, PrintEventArgs e)
        {
            XRBarCode barCode = CreateQRCodeBarCode("012345678");
            barCode.LocationF = new PointF(10, 160);
            this.reportHeaderBand1.Controls.Add(barCode);
        }

    }
}

namespace WinForm.Reports
{
    partial class ZebraBarcodeLabelRPT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.TopMarginBand TopMargin;
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.txtBarcode = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPrice = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            TopMargin.HeightF = 0F;
            TopMargin.Name = "TopMargin";
            TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtBarcode,
            this.xrLabel2,
            this.xrLabel1,
            this.txtPrice,
            this.txtName});
            this.Detail.HeightF = 100F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtBarcode
            // 
            this.txtBarcode.LocationFloat = new DevExpress.Utils.PointFloat(2.375031F, 22.20834F);
            this.txtBarcode.Module = 1F;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.txtBarcode.ShowText = false;
            this.txtBarcode.SizeF = new System.Drawing.SizeF(146.625F, 40F);
            this.txtBarcode.StylePriority.UseTextAlignment = false;
            this.txtBarcode.Symbology = code128Generator1;
            this.txtBarcode.Text = "701-001";
            this.txtBarcode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.AutoWidth = true;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(15.50001F, 68F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(65F, 15F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "رضا بوكشوب";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.AutoWidth = true;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(81.5897F, 68F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(13.39334F, 15F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "ج";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            this.txtPrice.AutoWidth = true;
            this.txtPrice.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice.LocationFloat = new DevExpress.Utils.PointFloat(95.10169F, 68F);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPrice.SizeF = new System.Drawing.SizeF(45.77332F, 15F);
            this.txtPrice.StylePriority.UseFont = false;
            this.txtPrice.StylePriority.UseTextAlignment = false;
            this.txtPrice.Text = "123.59";
            this.txtPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.CanGrow = false;
            this.txtName.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 0F);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.SizeF = new System.Drawing.SizeF(117.5F, 20F);
            this.txtName.StylePriority.UseTextAlignment = false;
            this.txtName.Text = "متوسط A5 دفتر";
            this.txtName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 2F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ZebraBarcodeLabelRPT
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(1, 0, 0, 2);
            this.PageHeight = 100;
            this.PageWidth = 150;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "15.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel txtPrice;
        private DevExpress.XtraReports.UI.XRBarCode txtBarcode;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel txtName;
    }
}

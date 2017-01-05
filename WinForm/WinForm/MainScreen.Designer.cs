namespace WinForm
{
    partial class MainScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnItems = new DevExpress.XtraBars.BarButtonItem();
            this.btnCategories = new DevExpress.XtraBars.BarButtonItem();
            this.lblMessage = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowPurchaseInvoices = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnShowSaleInvoices = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnItems,
            this.btnCategories,
            this.lblMessage,
            this.barButtonItem1,
            this.btnShowPurchaseInvoices,
            this.btnShowSaleInvoices});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(758, 144);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnItems
            // 
            this.btnItems.Caption = "Items";
            this.btnItems.Id = 2;
            this.btnItems.Name = "btnItems";
            this.btnItems.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItems_ItemClick);
            // 
            // btnCategories
            // 
            this.btnCategories.Caption = "Categories";
            this.btnCategories.Id = 3;
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCategories_ItemClick);
            // 
            // lblMessage
            // 
            this.lblMessage.Caption = "Reda POS";
            this.lblMessage.Id = 4;
            this.lblMessage.LeftIndent = 10;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "New Purchase Invoice";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnShowPurchaseInvoices
            // 
            this.btnShowPurchaseInvoices.Caption = "Show Invoices";
            this.btnShowPurchaseInvoices.Id = 6;
            this.btnShowPurchaseInvoices.Name = "btnShowPurchaseInvoices";
            this.btnShowPurchaseInvoices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowPurchaseInvoices_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Sales";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnShowSaleInvoices);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Sales";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Purchases";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnShowPurchaseInvoices);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Purchase";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Settings";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnItems);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCategories);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Settings";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.ribbonStatusBar1.ForeColor = System.Drawing.Color.Green;
            this.ribbonStatusBar1.ItemLinks.Add(this.lblMessage);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 329);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(758, 31);
            this.ribbonStatusBar1.Click += new System.EventHandler(this.ribbonStatusBar1_Click);
            // 
            // groupControlMain
            // 
            this.groupControlMain.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControlMain.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControlMain.Controls.Add(this.xtraTabControl1);
            this.groupControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlMain.Location = new System.Drawing.Point(0, 144);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.ShowCaption = false;
            this.groupControlMain.Size = new System.Drawing.Size(758, 185);
            this.groupControlMain.TabIndex = 1;
            this.groupControlMain.Text = "Reda POS";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Size = new System.Drawing.Size(754, 181);
            this.xtraTabControl1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1350;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnShowSaleInvoices
            // 
            this.btnShowSaleInvoices.Caption = "Show Sale Invoices";
            this.btnShowSaleInvoices.Id = 7;
            this.btnShowSaleInvoices.Name = "btnShowSaleInvoices";
            this.btnShowSaleInvoices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowSaleInvoices_ItemClick);
            // 
            // MainScreen
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 360);
            this.Controls.Add(this.groupControlMain);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainScreen";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Reda POS V1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnItems;
        private DevExpress.XtraBars.BarButtonItem btnCategories;
        private System.Windows.Forms.BindingSource bindingSource1;
        public DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarStaticItem lblMessage;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnShowPurchaseInvoices;
        private DevExpress.XtraBars.BarButtonItem btnShowSaleInvoices;
    }
}


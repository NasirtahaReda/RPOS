namespace WinForm
{
    partial class AdminUserForm
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::RedaPOS.SplashScreen2), true, true);
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions5 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions6 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions7 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUserForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.bindingSourceSaleInvoice = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceItem = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceInventory = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceSaleInvoiceDetails = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bindingSourceTempItems = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceNoVisibleItems = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelHoulSearch = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.vwInventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldNumber1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldItemID1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldQuantity1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPurchasePrice1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDiscountPrice1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldReceiveQuantity1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCurrentQuanity1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldBarcodeText1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldID1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldReorderPoint1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSalePrice1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldBranchID1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldBranchName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.txtSearchAllBranch = new DevExpress.XtraEditors.TextEdit();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelReport = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnShiftReport = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUsersRPT = new DevExpress.XtraEditors.LookUpEdit();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnUserPaymentReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnExpenseRPT = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDate = new DevExpress.XtraEditors.DateEdit();
            this.btnShowUserLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaleSummaryReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockReport = new DevExpress.XtraEditors.SimpleButton();
            this.dockPanelReturn = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.cmbBranches = new DevExpress.XtraEditors.LookUpEdit();
            this.branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnShowSaleInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.cmbUsers = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSaleInvoiceSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSaleInvoiceDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.txtSaleInvoiceID = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.vwSaleReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewSaleInvoice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditSaleInvoice = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockPanelOperations = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnExpenses = new DevExpress.XtraEditors.SimpleButton();
            this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangePassword = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowCalculator = new DevExpress.XtraEditors.SimpleButton();
            this.itemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewPurchaseInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.btnItems = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemCategory2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewTransferInvoices = new DevExpress.XtraBars.BarButtonItem();
            this.btnExpenses2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewExpense = new DevExpress.XtraBars.BarButtonItem();
            this.btnPassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnShiftClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnDamege = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewDamege = new DevExpress.XtraBars.BarButtonItem();
            this.btnPayment = new DevExpress.XtraBars.BarButtonItem();
            this.btnSettings = new DevExpress.XtraBars.BarButtonItem();
            this.btnInventory = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboard = new DevExpress.XtraBars.BarButtonItem();
            this.btnPushover = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaleInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuickCode = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddMoney = new DevExpress.XtraBars.BarButtonItem();
            this.btnDollarRate = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnDialyFinancialReport = new DevExpress.XtraBars.BarButtonItem();
            this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSaleInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSaleInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTempItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNoVisibleItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.dockPanelHoulSearch.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwInventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchAllBranch.Properties)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dockPanelReport.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsersRPT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).BeginInit();
            this.dockPanelReturn.SuspendLayout();
            this.dockPanel4_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranches.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSaleInvoiceDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSaleInvoiceDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaleInvoiceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwSaleReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSaleInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditSaleInvoice)).BeginInit();
            this.dockPanelOperations.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // bindingSourceSaleInvoice
            // 
            this.bindingSourceSaleInvoice.DataSource = typeof(DataAccess.SaleInvoice);
            // 
            // bindingSourceItem
            // 
            this.bindingSourceItem.DataSource = typeof(DataAccess.vw_Inventory);
            // 
            // bindingSourceInventory
            // 
            this.bindingSourceInventory.DataSource = typeof(DataAccess.vw_Inventory);
            // 
            // bindingSourceSaleInvoiceDetails
            // 
            this.bindingSourceSaleInvoiceDetails.DataSource = typeof(DataAccess.SaleInvoiceDetail);
            // 
            // timer1
            // 
            this.timer1.Interval = 1350;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bindingSourceTempItems
            // 
            this.bindingSourceTempItems.DataSource = typeof(DataAccess.vw_TempItem);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DataAccess.TempItem);
            // 
            // bindingSourceNoVisibleItems
            // 
            this.bindingSourceNoVisibleItems.DataSource = typeof(DataAccess.vw_Inventory);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft});
            this.dockManager1.DockingOptions.ShowCloseButton = false;
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelOperations});
            this.dockManager1.ToolTipController = this.toolTipController1;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Controls.Add(this.dockPanelHoulSearch);
            this.hideContainerLeft.Controls.Add(this.panelContainer1);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 141);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(19, 544);
            // 
            // dockPanelHoulSearch
            // 
            this.dockPanelHoulSearch.Controls.Add(this.dockPanel3_Container);
            this.dockPanelHoulSearch.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelHoulSearch.ID = new System.Guid("35223e2d-3e70-4718-b33b-2f7a7f4a3a79");
            this.dockPanelHoulSearch.Location = new System.Drawing.Point(19, 120);
            this.dockPanelHoulSearch.Name = "dockPanelHoulSearch";
            this.dockPanelHoulSearch.OriginalSize = new System.Drawing.Size(837, 200);
            this.dockPanelHoulSearch.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelHoulSearch.SavedIndex = 0;
            this.dockPanelHoulSearch.Size = new System.Drawing.Size(837, 565);
            this.dockPanelHoulSearch.Text = "البحث";
            this.dockPanelHoulSearch.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.pivotGridControl1);
            this.dockPanel3_Container.Controls.Add(this.txtSearchAllBranch);
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(829, 538);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pivotGridControl1.Appearance.Cell.Options.UseFont = true;
            this.pivotGridControl1.Appearance.Cell.Options.UseTextOptions = true;
            this.pivotGridControl1.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.pivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
            this.pivotGridControl1.Appearance.FieldHeader.Options.UseTextOptions = true;
            this.pivotGridControl1.Appearance.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pivotGridControl1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pivotGridControl1.Appearance.FieldValue.Options.UseFont = true;
            this.pivotGridControl1.DataSource = this.vwInventoryBindingSource;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldNumber1,
            this.fieldItemID1,
            this.fieldQuantity1,
            this.fieldPurchasePrice1,
            this.fieldDiscountPrice1,
            this.fieldReceiveQuantity1,
            this.fieldCurrentQuanity1,
            this.fieldName1,
            this.fieldBarcodeText1,
            this.fieldID1,
            this.fieldReorderPoint1,
            this.fieldSalePrice1,
            this.fieldBranchID1,
            this.fieldBranchName1});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 20);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(829, 518);
            this.pivotGridControl1.TabIndex = 36;
            // 
            // fieldNumber1
            // 
            this.fieldNumber1.AreaIndex = 0;
            this.fieldNumber1.Caption = "Number";
            this.fieldNumber1.FieldName = "Number";
            this.fieldNumber1.Name = "fieldNumber1";
            this.fieldNumber1.Visible = false;
            // 
            // fieldItemID1
            // 
            this.fieldItemID1.AreaIndex = 0;
            this.fieldItemID1.Caption = "Item ID";
            this.fieldItemID1.FieldName = "ItemID";
            this.fieldItemID1.Name = "fieldItemID1";
            this.fieldItemID1.Visible = false;
            // 
            // fieldQuantity1
            // 
            this.fieldQuantity1.AreaIndex = 0;
            this.fieldQuantity1.Caption = "Quantity";
            this.fieldQuantity1.FieldName = "Quantity";
            this.fieldQuantity1.Name = "fieldQuantity1";
            this.fieldQuantity1.Visible = false;
            // 
            // fieldPurchasePrice1
            // 
            this.fieldPurchasePrice1.AreaIndex = 0;
            this.fieldPurchasePrice1.Caption = "Purchase Price";
            this.fieldPurchasePrice1.FieldName = "PurchasePrice";
            this.fieldPurchasePrice1.Name = "fieldPurchasePrice1";
            this.fieldPurchasePrice1.Visible = false;
            // 
            // fieldDiscountPrice1
            // 
            this.fieldDiscountPrice1.AreaIndex = 0;
            this.fieldDiscountPrice1.Caption = "Discount Price";
            this.fieldDiscountPrice1.FieldName = "DiscountPrice";
            this.fieldDiscountPrice1.Name = "fieldDiscountPrice1";
            this.fieldDiscountPrice1.Visible = false;
            // 
            // fieldReceiveQuantity1
            // 
            this.fieldReceiveQuantity1.AreaIndex = 0;
            this.fieldReceiveQuantity1.Caption = "Receive Quantity";
            this.fieldReceiveQuantity1.FieldName = "ReceiveQuantity";
            this.fieldReceiveQuantity1.Name = "fieldReceiveQuantity1";
            this.fieldReceiveQuantity1.Visible = false;
            // 
            // fieldCurrentQuanity1
            // 
            this.fieldCurrentQuanity1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCurrentQuanity1.AreaIndex = 0;
            this.fieldCurrentQuanity1.Caption = "الكمية المتوفره";
            this.fieldCurrentQuanity1.FieldName = "CurrentQuanity";
            this.fieldCurrentQuanity1.Name = "fieldCurrentQuanity1";
            this.fieldCurrentQuanity1.Options.ShowCustomTotals = false;
            this.fieldCurrentQuanity1.Options.ShowInPrefilter = false;
            this.fieldCurrentQuanity1.Options.ShowTotals = false;
            // 
            // fieldName1
            // 
            this.fieldName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldName1.AreaIndex = 0;
            this.fieldName1.Caption = "الصنف";
            this.fieldName1.FieldName = "Name";
            this.fieldName1.Name = "fieldName1";
            this.fieldName1.Width = 161;
            // 
            // fieldBarcodeText1
            // 
            this.fieldBarcodeText1.AreaIndex = 2;
            this.fieldBarcodeText1.Caption = "Barcode Text";
            this.fieldBarcodeText1.FieldName = "BarcodeText";
            this.fieldBarcodeText1.Name = "fieldBarcodeText1";
            this.fieldBarcodeText1.Visible = false;
            // 
            // fieldID1
            // 
            this.fieldID1.AreaIndex = 2;
            this.fieldID1.Caption = "ID";
            this.fieldID1.FieldName = "ID";
            this.fieldID1.Name = "fieldID1";
            this.fieldID1.Visible = false;
            // 
            // fieldReorderPoint1
            // 
            this.fieldReorderPoint1.AreaIndex = 2;
            this.fieldReorderPoint1.Caption = "Reorder Point";
            this.fieldReorderPoint1.FieldName = "ReorderPoint";
            this.fieldReorderPoint1.Name = "fieldReorderPoint1";
            this.fieldReorderPoint1.Visible = false;
            // 
            // fieldSalePrice1
            // 
            this.fieldSalePrice1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSalePrice1.AreaIndex = 1;
            this.fieldSalePrice1.Caption = "سعر البيع";
            this.fieldSalePrice1.FieldName = "SalePrice";
            this.fieldSalePrice1.Name = "fieldSalePrice1";
            // 
            // fieldBranchID1
            // 
            this.fieldBranchID1.AreaIndex = 2;
            this.fieldBranchID1.Caption = "Branch ID";
            this.fieldBranchID1.FieldName = "BranchID";
            this.fieldBranchID1.Name = "fieldBranchID1";
            this.fieldBranchID1.Visible = false;
            // 
            // fieldBranchName1
            // 
            this.fieldBranchName1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldBranchName1.AreaIndex = 0;
            this.fieldBranchName1.Caption = "Branch Name";
            this.fieldBranchName1.FieldName = "BranchName";
            this.fieldBranchName1.Name = "fieldBranchName1";
            this.fieldBranchName1.Options.ShowGrandTotal = false;
            this.fieldBranchName1.Options.ShowTotals = false;
            // 
            // txtSearchAllBranch
            // 
            this.txtSearchAllBranch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchAllBranch.EditValue = "";
            this.txtSearchAllBranch.Location = new System.Drawing.Point(0, 0);
            this.txtSearchAllBranch.Name = "txtSearchAllBranch";
            this.txtSearchAllBranch.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSearchAllBranch.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSearchAllBranch.Size = new System.Drawing.Size(829, 20);
            this.txtSearchAllBranch.TabIndex = 35;
            this.txtSearchAllBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchAllBranch_KeyDown);
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.dockPanelReport;
            this.panelContainer1.Controls.Add(this.dockPanelReturn);
            this.panelContainer1.Controls.Add(this.dockPanelReport);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.ID = new System.Guid("d76377ad-8b4c-4174-85de-6b0715eb122b");
            this.panelContainer1.Location = new System.Drawing.Point(19, 120);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(560, 200);
            this.panelContainer1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.SavedIndex = 0;
            this.panelContainer1.Size = new System.Drawing.Size(560, 565);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            this.panelContainer1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanelReport
            // 
            this.dockPanelReport.Controls.Add(this.dockPanel1_Container);
            this.dockPanelReport.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanelReport.ID = new System.Guid("a0889471-9f28-4e88-b801-264eae8394d5");
            this.dockPanelReport.Location = new System.Drawing.Point(4, 23);
            this.dockPanelReport.Name = "dockPanelReport";
            this.dockPanelReport.OriginalSize = new System.Drawing.Size(552, 511);
            this.dockPanelReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dockPanelReport.Size = new System.Drawing.Size(552, 538);
            this.dockPanelReport.Text = "التقارير";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnShiftReport);
            this.dockPanel1_Container.Controls.Add(this.label6);
            this.dockPanel1_Container.Controls.Add(this.cmbUsersRPT);
            this.dockPanel1_Container.Controls.Add(this.btnUserPaymentReport);
            this.dockPanel1_Container.Controls.Add(this.btnExpenseRPT);
            this.dockPanel1_Container.Controls.Add(this.label5);
            this.dockPanel1_Container.Controls.Add(this.cmbDate);
            this.dockPanel1_Container.Controls.Add(this.btnShowUserLogin);
            this.dockPanel1_Container.Controls.Add(this.btnSaleSummaryReport);
            this.dockPanel1_Container.Controls.Add(this.btnStockReport);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(552, 538);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnShiftReport
            // 
            this.btnShiftReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnShiftReport.Location = new System.Drawing.Point(152, 43);
            this.btnShiftReport.Name = "btnShiftReport";
            this.btnShiftReport.Size = new System.Drawing.Size(106, 94);
            this.btnShiftReport.TabIndex = 48;
            this.btnShiftReport.Text = "تقرير الورديه";
            this.btnShiftReport.ToolTip = "زمن الدخول والخروج";
            this.btnShiftReport.Click += new System.EventHandler(this.btnShiftReport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "المستخدم";
            // 
            // cmbUsersRPT
            // 
            this.cmbUsersRPT.Location = new System.Drawing.Point(158, 17);
            this.cmbUsersRPT.Name = "cmbUsersRPT";
            this.cmbUsersRPT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUsersRPT.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 34, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "User Name", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Password", "Password", 56, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsAdmin", "Is Admin", 51, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Full Name", 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchaseInvoices", "Purchase Invoices", 97, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserLogins", "User Logins", 65, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SaleInvoices", "Sale Invoices", 73, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Expenses", "Expenses", 56, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Expenses1", "Expenses1", 62, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Shifts", "Shifts", 37, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbUsersRPT.Properties.DataSource = this.userBindingSource;
            this.cmbUsersRPT.Properties.DisplayMember = "FullName";
            this.cmbUsersRPT.Properties.NullText = "";
            this.cmbUsersRPT.Properties.ValueMember = "ID";
            this.cmbUsersRPT.Size = new System.Drawing.Size(100, 20);
            this.cmbUsersRPT.TabIndex = 46;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(DataAccess.User);
            // 
            // btnUserPaymentReport
            // 
            this.btnUserPaymentReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnUserPaymentReport.Location = new System.Drawing.Point(152, 159);
            this.btnUserPaymentReport.Name = "btnUserPaymentReport";
            this.btnUserPaymentReport.Size = new System.Drawing.Size(106, 94);
            this.btnUserPaymentReport.TabIndex = 45;
            this.btnUserPaymentReport.Text = "تقرير الإيرادات\r\n والمنصرفات\r\n للموظف";
            this.btnUserPaymentReport.ToolTip = "تقرير الإيرادات\r\n والمنصرفات\r\n للموظف";
            this.btnUserPaymentReport.Click += new System.EventHandler(this.btnUserPaymentReport_Click);
            // 
            // btnExpenseRPT
            // 
            this.btnExpenseRPT.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExpenseRPT.Location = new System.Drawing.Point(10, 43);
            this.btnExpenseRPT.Name = "btnExpenseRPT";
            this.btnExpenseRPT.Size = new System.Drawing.Size(106, 94);
            this.btnExpenseRPT.TabIndex = 45;
            this.btnExpenseRPT.Text = "تقرير المصروفات";
            this.btnExpenseRPT.ToolTip = "زمن الدخول والخروج";
            this.btnExpenseRPT.Click += new System.EventHandler(this.btnExpenseRPT_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "التاريخ";
            // 
            // cmbDate
            // 
            this.cmbDate.EditValue = null;
            this.cmbDate.Location = new System.Drawing.Point(3, 17);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDate.Size = new System.Drawing.Size(100, 20);
            this.cmbDate.TabIndex = 43;
            // 
            // btnShowUserLogin
            // 
            this.btnShowUserLogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnShowUserLogin.Location = new System.Drawing.Point(10, 159);
            this.btnShowUserLogin.Name = "btnShowUserLogin";
            this.btnShowUserLogin.Size = new System.Drawing.Size(106, 94);
            this.btnShowUserLogin.TabIndex = 42;
            this.btnShowUserLogin.Text = "الحضور";
            this.btnShowUserLogin.ToolTip = "زمن الدخول والخروج";
            this.btnShowUserLogin.Click += new System.EventHandler(this.btnShowUserLogin_Click);
            // 
            // btnSaleSummaryReport
            // 
            this.btnSaleSummaryReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSaleSummaryReport.Location = new System.Drawing.Point(10, 275);
            this.btnSaleSummaryReport.Name = "btnSaleSummaryReport";
            this.btnSaleSummaryReport.Size = new System.Drawing.Size(106, 94);
            this.btnSaleSummaryReport.TabIndex = 41;
            this.btnSaleSummaryReport.Click += new System.EventHandler(this.btnSaleSummaryReport_Click);
            // 
            // btnStockReport
            // 
            this.btnStockReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStockReport.ImageOptions.Image")));
            this.btnStockReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnStockReport.Location = new System.Drawing.Point(10, 391);
            this.btnStockReport.Name = "btnStockReport";
            this.btnStockReport.Size = new System.Drawing.Size(106, 94);
            this.btnStockReport.TabIndex = 40;
            this.btnStockReport.Text = "تقرير المخزن";
            this.btnStockReport.Click += new System.EventHandler(this.btnStockReport_Click);
            // 
            // dockPanelReturn
            // 
            this.dockPanelReturn.Controls.Add(this.dockPanel4_Container);
            this.dockPanelReturn.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanelReturn.ID = new System.Guid("434ac2f4-edb6-4af1-80a6-803214553c7a");
            this.dockPanelReturn.Location = new System.Drawing.Point(4, 23);
            this.dockPanelReturn.Name = "dockPanelReturn";
            this.dockPanelReturn.OriginalSize = new System.Drawing.Size(552, 511);
            this.dockPanelReturn.Size = new System.Drawing.Size(552, 538);
            this.dockPanelReturn.Text = "فواتير البيع";
            this.dockPanelReturn.Click += new System.EventHandler(this.dockPanelReturn_Click);
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Controls.Add(this.cmbBranches);
            this.dockPanel4_Container.Controls.Add(this.btnShowSaleInvoice);
            this.dockPanel4_Container.Controls.Add(this.cmbUsers);
            this.dockPanel4_Container.Controls.Add(this.btnSaleInvoiceSearch);
            this.dockPanel4_Container.Controls.Add(this.cmbSaleInvoiceDateFrom);
            this.dockPanel4_Container.Controls.Add(this.txtSaleInvoiceID);
            this.dockPanel4_Container.Controls.Add(this.gridControl1);
            this.dockPanel4_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(552, 538);
            this.dockPanel4_Container.TabIndex = 0;
            // 
            // cmbBranches
            // 
            this.cmbBranches.Location = new System.Drawing.Point(443, 26);
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, editorButtonImageOptions1)});
            this.cmbBranches.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 34, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Address", 49, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Phone", "Phone", 40, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Email", "Email", 34, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BranchName", "Branch Name", 73, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Inventories", "Inventories", 65, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchaseInvoices", "Purchase Invoices", 97, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SaleInvoices", "Sale Invoices", 73, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserLogins", "User Logins", 65, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbBranches.Properties.DataSource = this.branchBindingSource;
            this.cmbBranches.Properties.DisplayMember = "BranchName";
            this.cmbBranches.Properties.NullText = "";
            this.cmbBranches.Properties.ValueMember = "ID";
            this.cmbBranches.Size = new System.Drawing.Size(102, 20);
            this.cmbBranches.TabIndex = 11;
            this.cmbBranches.TabStop = false;
            this.cmbBranches.ToolTipTitle = "الفرع";
            // 
            // branchBindingSource
            // 
            this.branchBindingSource.DataSource = typeof(DataAccess.Branch);
            // 
            // btnShowSaleInvoice
            // 
            this.btnShowSaleInvoice.Location = new System.Drawing.Point(99, 10);
            this.btnShowSaleInvoice.Name = "btnShowSaleInvoice";
            this.btnShowSaleInvoice.Size = new System.Drawing.Size(99, 36);
            this.btnShowSaleInvoice.TabIndex = 25;
            this.btnShowSaleInvoice.Text = "عرض فواتير البيع";
            this.btnShowSaleInvoice.Click += new System.EventHandler(this.btnShowSaleInvoice_Click_1);
            // 
            // cmbUsers
            // 
            this.cmbUsers.Location = new System.Drawing.Point(327, 26);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, editorButtonImageOptions2)});
            this.cmbUsers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 34, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "User Name", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Password", "Password", 56, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchaseInvoices", "Purchase Invoices", 97, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SaleInvoices", "Sale Invoices", 73, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Name30")});
            this.cmbUsers.Properties.DataSource = this.userBindingSource;
            this.cmbUsers.Properties.DisplayMember = "FullName";
            this.cmbUsers.Properties.NullText = "";
            this.cmbUsers.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cmbUsers.Properties.ValueMember = "ID";
            this.cmbUsers.Size = new System.Drawing.Size(102, 20);
            this.cmbUsers.TabIndex = 15;
            // 
            // btnSaleInvoiceSearch
            // 
            this.btnSaleInvoiceSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaleInvoiceSearch.ImageOptions.Image")));
            this.btnSaleInvoiceSearch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSaleInvoiceSearch.Location = new System.Drawing.Point(8, 55);
            this.btnSaleInvoiceSearch.Name = "btnSaleInvoiceSearch";
            this.btnSaleInvoiceSearch.Size = new System.Drawing.Size(67, 36);
            this.btnSaleInvoiceSearch.TabIndex = 9;
            this.btnSaleInvoiceSearch.ToolTip = "بحث عن طريق رقم الفاتوره";
            this.btnSaleInvoiceSearch.ToolTipController = this.toolTipController1;
            this.btnSaleInvoiceSearch.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSaleInvoiceSearch.Click += new System.EventHandler(this.btnSaleInvoiceSearch_Click);
            // 
            // cmbSaleInvoiceDateFrom
            // 
            this.cmbSaleInvoiceDateFrom.EditValue = null;
            this.cmbSaleInvoiceDateFrom.Location = new System.Drawing.Point(211, 26);
            this.cmbSaleInvoiceDateFrom.Name = "cmbSaleInvoiceDateFrom";
            this.cmbSaleInvoiceDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, editorButtonImageOptions3)});
            this.cmbSaleInvoiceDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSaleInvoiceDateFrom.Properties.Mask.EditMask = "";
            this.cmbSaleInvoiceDateFrom.Size = new System.Drawing.Size(102, 20);
            this.cmbSaleInvoiceDateFrom.TabIndex = 14;
            // 
            // txtSaleInvoiceID
            // 
            this.txtSaleInvoiceID.Location = new System.Drawing.Point(8, 17);
            this.txtSaleInvoiceID.Name = "txtSaleInvoiceID";
            this.txtSaleInvoiceID.Size = new System.Drawing.Size(75, 20);
            this.txtSaleInvoiceID.TabIndex = 10;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.vwSaleReportBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(2, 113);
            this.gridControl1.MainView = this.gridViewSaleInvoice;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditSaleInvoice});
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(547, 366);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ToolTipController = this.toolTipController1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSaleInvoice});
            // 
            // gridViewSaleInvoice
            // 
            this.gridViewSaleInvoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.colDate,
            this.colUserID,
            this.colUserName,
            this.colFlag,
            this.gridColumn6,
            this.colTotal,
            this.colDiscount});
            this.gridViewSaleInvoice.GridControl = this.gridControl1;
            this.gridViewSaleInvoice.GroupCount = 1;
            this.gridViewSaleInvoice.Name = "gridViewSaleInvoice";
            this.gridViewSaleInvoice.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFlag, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "رقم الفاتورة";
            this.gridColumn5.FieldName = "ID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 68;
            // 
            // colDate
            // 
            this.colDate.Caption = "التاريخ";
            this.colDate.DisplayFormat.FormatString = "g";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 4;
            this.colDate.Width = 138;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.Caption = "الموظف";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 3;
            this.colUserName.Width = 56;
            // 
            // colFlag
            // 
            this.colFlag.FieldName = "Flag";
            this.colFlag.Name = "colFlag";
            this.colFlag.Visible = true;
            this.colFlag.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.ColumnEdit = this.repositoryItemButtonEditSaleInvoice;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowSize = false;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 91;
            // 
            // repositoryItemButtonEditSaleInvoice
            // 
            this.repositoryItemButtonEditSaleInvoice.AutoHeight = false;
            this.repositoryItemButtonEditSaleInvoice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK, "عرض الفاتورة", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "عرض الفاتورة"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right, "فاتورة A4", -1, true, true, false, editorButtonImageOptions5),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo, "ارجاع الفاتورة", -1, true, true, false, editorButtonImageOptions6, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "ارجاع الفاتورة"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down, "طباعه", -1, true, true, false, editorButtonImageOptions7, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "طباعه")});
            this.repositoryItemButtonEditSaleInvoice.Name = "repositoryItemButtonEditSaleInvoice";
            this.repositoryItemButtonEditSaleInvoice.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEditSaleInvoice.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditSaleInvoice_ButtonClick);
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.Caption = "المجموع";
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 1;
            this.colTotal.Width = 51;
            // 
            // colDiscount
            // 
            this.colDiscount.AppearanceCell.Options.UseTextOptions = true;
            this.colDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiscount.Caption = "التخفيض";
            this.colDiscount.FieldName = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.OptionsColumn.AllowEdit = false;
            this.colDiscount.Visible = true;
            this.colDiscount.VisibleIndex = 2;
            this.colDiscount.Width = 58;
            // 
            // dockPanelOperations
            // 
            this.dockPanelOperations.Controls.Add(this.dockPanel2_Container);
            this.dockPanelOperations.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("عن النظام", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton)});
            this.dockPanelOperations.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelOperations.ID = new System.Guid("33362c01-f635-4955-a701-95710fd4e762");
            this.dockPanelOperations.Location = new System.Drawing.Point(19, 538);
            this.dockPanelOperations.Name = "dockPanelOperations";
            this.dockPanelOperations.Options.ShowCloseButton = false;
            this.dockPanelOperations.Options.ShowMaximizeButton = false;
            this.dockPanelOperations.OriginalSize = new System.Drawing.Size(200, 147);
            this.dockPanelOperations.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dockPanelOperations.Size = new System.Drawing.Size(1215, 147);
            this.dockPanelOperations.Text = "الأوامر";
            this.dockPanelOperations.Click += new System.EventHandler(this.dockPanelOperations_Click);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.btnExpenses);
            this.dockPanel2_Container.Controls.Add(this.btnTransfer);
            this.dockPanel2_Container.Controls.Add(this.btnChangePassword);
            this.dockPanel2_Container.Controls.Add(this.btnClose);
            this.dockPanel2_Container.Controls.Add(this.btnShowCalculator);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 26);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1207, 117);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // btnExpenses
            // 
            this.btnExpenses.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExpenses.Location = new System.Drawing.Point(752, 14);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(83, 94);
            this.btnExpenses.TabIndex = 47;
            this.btnExpenses.Text = "مصروفات";
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnTransfer.Location = new System.Drawing.Point(647, 14);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(83, 94);
            this.btnTransfer.TabIndex = 46;
            this.btnTransfer.Text = "تحويل";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.ImageOptions.Image")));
            this.btnChangePassword.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnChangePassword.Location = new System.Drawing.Point(962, 14);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(83, 94);
            this.btnChangePassword.TabIndex = 39;
            this.btnChangePassword.Text = "كلمة السر";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(1067, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 94);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "تغيير الوردية";
            this.btnClose.ToolTip = "خروج";
            this.btnClose.ToolTipController = this.toolTipController1;
            this.btnClose.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Warning;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowCalculator
            // 
            this.btnShowCalculator.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnShowCalculator.ImageOptions.Image")));
            this.btnShowCalculator.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnShowCalculator.Location = new System.Drawing.Point(857, 14);
            this.btnShowCalculator.Margin = new System.Windows.Forms.Padding(10);
            this.btnShowCalculator.Name = "btnShowCalculator";
            this.btnShowCalculator.Size = new System.Drawing.Size(83, 94);
            this.btnShowCalculator.TabIndex = 37;
            this.btnShowCalculator.Text = "آلة حاسبة";
            this.btnShowCalculator.ToolTip = "الحاسبة";
            this.btnShowCalculator.ToolTipController = this.toolTipController1;
            this.btnShowCalculator.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnShowCalculator.ToolTipTitle = "رضا";
            this.btnShowCalculator.Click += new System.EventHandler(this.btnShowCalculator_Click);
            // 
            // itemBindingSource1
            // 
            this.itemBindingSource1.DataSource = typeof(DataAccess.Item);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(19, 141);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1215, 397);
            this.xtraTabControl1.TabIndex = 7;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.xtraTabControl1_SelectedPageChanging);
            this.xtraTabControl1.CloseButtonClick += new System.EventHandler(this.xtraTabControl1_CloseButtonClick);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xtraTabPage1.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabPage1.Size = new System.Drawing.Size(1209, 363);
            this.xtraTabPage1.Tag = "=";
            this.xtraTabPage1.Text = "xtraTabPage1";
            this.xtraTabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.xtraTabPage1_Paint);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(1209, 363);
            this.xtraTabPage2.Tag = "+";
            this.xtraTabPage2.Text = "+";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.btnNewPurchaseInvoice,
            this.btnItems,
            this.btnItemCategory2,
            this.btnNewItem,
            this.barButtonItem12,
            this.btnViewTransferInvoices,
            this.btnExpenses2,
            this.btnNewExpense,
            this.btnPassword,
            this.btnShiftClose,
            this.btnDamege,
            this.btnNewDamege,
            this.btnPayment,
            this.btnSettings,
            this.btnInventory,
            this.btnDashboard,
            this.btnPushover,
            this.btnSaleInvoice,
            this.barButtonItem8,
            this.barButtonItem9,
            this.btnQuickCode,
            this.btnAddMoney,
            this.btnDollarRate,
            this.btnDialyFinancialReport});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.btnSaleInvoice);
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.barButtonItem8);
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.barButtonItem9);
            this.ribbonControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbonControl1.Size = new System.Drawing.Size(1234, 141);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "الأصناف";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Items;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "عرض فواتير المشتروات";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.category;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // btnNewPurchaseInvoice
            // 
            this.btnNewPurchaseInvoice.Caption = "فاتورة مشتروات جديدة";
            this.btnNewPurchaseInvoice.Id = 7;
            this.btnNewPurchaseInvoice.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Add64;
            this.btnNewPurchaseInvoice.Name = "btnNewPurchaseInvoice";
            this.btnNewPurchaseInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewPurchaseInvoice_ItemClick);
            // 
            // btnItems
            // 
            this.btnItems.Caption = "عرض الأصناف";
            this.btnItems.Id = 8;
            this.btnItems.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.category_item_select;
            this.btnItems.Name = "btnItems";
            this.btnItems.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItems_ItemClick);
            // 
            // btnItemCategory2
            // 
            this.btnItemCategory2.Caption = "أنواع الأصناف";
            this.btnItemCategory2.Id = 9;
            this.btnItemCategory2.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.category;
            this.btnItemCategory2.Name = "btnItemCategory2";
            this.btnItemCategory2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemCategory2_ItemClick);
            // 
            // btnNewItem
            // 
            this.btnNewItem.Caption = "صنف جديد";
            this.btnNewItem.Id = 10;
            this.btnNewItem.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.add_icon;
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewItem_ItemClick);
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "تحويل جديد";
            this.barButtonItem12.Id = 12;
            this.barButtonItem12.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.add_icon;
            this.barButtonItem12.Name = "barButtonItem12";
            // 
            // btnViewTransferInvoices
            // 
            this.btnViewTransferInvoices.Caption = "عرض فواتير التحويل";
            this.btnViewTransferInvoices.Id = 13;
            this.btnViewTransferInvoices.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Transfer;
            this.btnViewTransferInvoices.Name = "btnViewTransferInvoices";
            this.btnViewTransferInvoices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewTransferInvoices_ItemClick);
            // 
            // btnExpenses2
            // 
            this.btnExpenses2.Caption = "عرض المصروفات";
            this.btnExpenses2.Id = 14;
            this.btnExpenses2.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.money;
            this.btnExpenses2.Name = "btnExpenses2";
            // 
            // btnNewExpense
            // 
            this.btnNewExpense.Caption = "مصروف جديد";
            this.btnNewExpense.Id = 15;
            this.btnNewExpense.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.add_icon;
            this.btnNewExpense.Name = "btnNewExpense";
            this.btnNewExpense.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewExpense_ItemClick);
            // 
            // btnPassword
            // 
            this.btnPassword.Caption = "بيانات المستخدم";
            this.btnPassword.Id = 16;
            this.btnPassword.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.password_icon;
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPassword_ItemClick);
            // 
            // btnShiftClose
            // 
            this.btnShiftClose.Caption = "خروج";
            this.btnShiftClose.Id = 17;
            this.btnShiftClose.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Logout_icon;
            this.btnShiftClose.Name = "btnShiftClose";
            this.btnShiftClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShiftClose_ItemClick);
            // 
            // btnDamege
            // 
            this.btnDamege.Caption = "عرض فواتير التالف";
            this.btnDamege.Id = 19;
            this.btnDamege.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.trash_icon;
            this.btnDamege.Name = "btnDamege";
            this.btnDamege.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDamege_ItemClick);
            // 
            // btnNewDamege
            // 
            this.btnNewDamege.Caption = "فاتورة تالف جديدة";
            this.btnNewDamege.Id = 20;
            this.btnNewDamege.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.add_icon;
            this.btnNewDamege.Name = "btnNewDamege";
            this.btnNewDamege.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewDamege_ItemClick);
            // 
            // btnPayment
            // 
            this.btnPayment.Caption = "المنصرفات الرئيسية";
            this.btnPayment.Id = 1;
            this.btnPayment.ImageOptions.Image = global::RedaPOS.Properties.Resources.payment;
            this.btnPayment.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.payment;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPayment_ItemClick);
            // 
            // btnSettings
            // 
            this.btnSettings.Caption = "الضبط";
            this.btnSettings.Id = 2;
            this.btnSettings.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Settings_icon;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSettings_ItemClick);
            // 
            // btnInventory
            // 
            this.btnInventory.Caption = "الجرد";
            this.btnInventory.Id = 3;
            this.btnInventory.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.clock_icon;
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInventory_ItemClick);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Caption = "لوحة التقارير";
            this.btnDashboard.Id = 4;
            this.btnDashboard.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.dashboard_icon2;
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDashboard_ItemClick);
            // 
            // btnPushover
            // 
            this.btnPushover.Caption = "Push Over";
            this.btnPushover.Id = 5;
            this.btnPushover.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.PushOver;
            this.btnPushover.Name = "btnPushover";
            this.btnPushover.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPushover_ItemClick);
            // 
            // btnSaleInvoice
            // 
            this.btnSaleInvoice.Caption = "فاتورة";
            this.btnSaleInvoice.Id = 6;
            this.btnSaleInvoice.Name = "btnSaleInvoice";
            toolTipTitleItem1.Text = "Sale";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Sale Invoice";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnSaleInvoice.SuperTip = superToolTip1;
            this.btnSaleInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaleInvoice_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "barButtonItem8";
            this.barButtonItem8.Id = 7;
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick_1);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 8;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // btnQuickCode
            // 
            this.btnQuickCode.Caption = "الأرقام السريعة";
            this.btnQuickCode.Id = 9;
            this.btnQuickCode.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Fast_icon;
            this.btnQuickCode.Name = "btnQuickCode";
            this.btnQuickCode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuickCode_ItemClick);
            // 
            // btnAddMoney
            // 
            this.btnAddMoney.Caption = "إضافة ساعات للموظف";
            this.btnAddMoney.Id = 10;
            this.btnAddMoney.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Add_Money;
            this.btnAddMoney.Name = "btnAddMoney";
            this.btnAddMoney.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddMoney_ItemClick);
            // 
            // btnDollarRate
            // 
            this.btnDollarRate.Caption = "سعر الدولار";
            this.btnDollarRate.Id = 11;
            this.btnDollarRate.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Dollar;
            this.btnDollarRate.Name = "btnDollarRate";
            this.btnDollarRate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDollarRate_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup7,
            this.ribbonPageGroup10,
            this.ribbonPageGroup6,
            this.ribbonPageGroup2});
            this.ribbonPage1.Image = global::RedaPOS.Properties.Resources.Dashboard_icon;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPassword);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnShiftClose);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSettings);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPushover);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDashboard);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAddMoney);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDollarRate);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDialyFinancialReport);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "الرئيسية";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnItems);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnItemCategory2);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnNewItem);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnQuickCode);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "الأصناف";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnNewPurchaseInvoice);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "المشتروات";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnExpenses2);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnNewExpense);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnPayment);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "المصروفات";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.btnDamege);
            this.ribbonPageGroup10.ItemLinks.Add(this.btnNewDamege);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "التالف";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnViewTransferInvoices);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem12);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "التحويل";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnInventory);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "الجرد";
            // 
            // btnDialyFinancialReport
            // 
            this.btnDialyFinancialReport.ActAsDropDown = true;
            this.btnDialyFinancialReport.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnDialyFinancialReport.Caption = "التقرير المالي اليومي";
            this.btnDialyFinancialReport.DropDownControl = this.galleryDropDown1;
            this.btnDialyFinancialReport.Id = 12;
            this.btnDialyFinancialReport.ImageOptions.Image = global::RedaPOS.Properties.Resources.Cash;
            this.btnDialyFinancialReport.ImageOptions.LargeImage = global::RedaPOS.Properties.Resources.Cash;
            this.btnDialyFinancialReport.Name = "btnDialyFinancialReport";
            this.btnDialyFinancialReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDialyFinancialReport_ItemClick);
            // 
            // galleryDropDown1
            // 
            this.galleryDropDown1.Name = "galleryDropDown1";
            this.galleryDropDown1.Ribbon = this.ribbonControl1;
            // 
            // AdminUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 685);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.dockPanelOperations);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة بيع";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminUserForm_FormClosed);
            this.Load += new System.EventHandler(this.SaleInvoiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSaleInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSaleInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTempItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNoVisibleItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.dockPanelHoulSearch.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwInventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchAllBranch.Properties)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dockPanelReport.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsersRPT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).EndInit();
            this.dockPanelReturn.ResumeLayout(false);
            this.dockPanel4_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranches.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSaleInvoiceDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSaleInvoiceDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaleInvoiceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwSaleReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSaleInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditSaleInvoice)).EndInit();
            this.dockPanelOperations.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceSaleInvoice;
        private System.Windows.Forms.BindingSource bindingSourceSaleInvoiceDetails;
        private System.Windows.Forms.BindingSource bindingSourceItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource bindingSourceInventory;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSourceTempItems;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bindingSourceNoVisibleItems;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelOperations;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelReport;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.SimpleButton btnTransfer;
        private DevExpress.XtraEditors.SimpleButton btnShowUserLogin;
        private DevExpress.XtraEditors.SimpleButton btnSaleSummaryReport;
        private DevExpress.XtraEditors.SimpleButton btnStockReport;
        private DevExpress.XtraEditors.SimpleButton btnChangePassword;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnShowCalculator;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelHoulSearch;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNumber1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldItemID1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldQuantity1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPurchasePrice1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDiscountPrice1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldReceiveQuantity1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCurrentQuanity1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBarcodeText1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldID1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldReorderPoint1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSalePrice1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBranchID1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBranchName1;
        private DevExpress.XtraEditors.TextEdit txtSearchAllBranch;
        private System.Windows.Forms.BindingSource vwInventoryBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnExpenseRPT;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.DateEdit cmbDate;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelReturn;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel4_Container;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSaleInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colFlag;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditSaleInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscount;
        private System.Windows.Forms.BindingSource vwSaleReportBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnSaleInvoiceSearch;
        private DevExpress.XtraEditors.TextEdit txtSaleInvoiceID;
        private DevExpress.XtraEditors.DateEdit cmbSaleInvoiceDateFrom;
        private DevExpress.XtraEditors.SimpleButton btnShowSaleInvoice;
        private DevExpress.XtraEditors.LookUpEdit cmbUsers;
        private System.Windows.Forms.BindingSource userBindingSource;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraEditors.LookUpEdit cmbUsersRPT;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnShiftReport;
        private System.Windows.Forms.BindingSource itemBindingSource1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private DevExpress.XtraEditors.SimpleButton btnExpenses;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem btnNewPurchaseInvoice;
        private DevExpress.XtraBars.BarButtonItem btnItems;
        private DevExpress.XtraBars.BarButtonItem btnItemCategory2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnNewItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarButtonItem btnViewTransferInvoices;
        private DevExpress.XtraBars.BarButtonItem btnExpenses2;
        private DevExpress.XtraBars.BarButtonItem btnNewExpense;
        private DevExpress.XtraBars.BarButtonItem btnPassword;
        private DevExpress.XtraBars.BarButtonItem btnShiftClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnDamege;
        private DevExpress.XtraBars.BarButtonItem btnNewDamege;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.BarButtonItem btnPayment;
        private DevExpress.XtraBars.BarButtonItem btnSettings;
        private DevExpress.XtraBars.BarButtonItem btnInventory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnDashboard;
        private DevExpress.XtraEditors.LookUpEdit cmbBranches;
        private System.Windows.Forms.BindingSource branchBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnPushover;
        private DevExpress.XtraBars.BarButtonItem btnSaleInvoice;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem btnQuickCode;
        private DevExpress.XtraEditors.SimpleButton btnUserPaymentReport;
        private DevExpress.XtraBars.BarButtonItem btnAddMoney;
        private DevExpress.XtraBars.BarButtonItem btnDollarRate;
        private DevExpress.XtraBars.BarButtonItem btnDialyFinancialReport;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown galleryDropDown1;
    }
}
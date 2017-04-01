namespace WinForm
{
    partial class SaleInvoiceForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleInvoiceForm));
            this.bindingSourceSaleInvoice = new System.Windows.Forms.BindingSource(this.components);
            this.txtBar = new System.Windows.Forms.TextBox();
            this.bindingSourceItem = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.bindingSourceInventory = new System.Windows.Forms.BindingSource(this.components);
            this.gridControlInvoice = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceSaleInvoiceDetails = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewInvoice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQuanitity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumnAddQuanitity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditAddQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumnItemTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupControlBarcodeAndSearch = new DevExpress.XtraEditors.GroupControl();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.txtWhatsAppHistory = new DevExpress.XtraEditors.MemoEdit();
            this.gridControlSearch = new DevExpress.XtraGrid.GridControl();
            this.gridViewSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiveQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentQuanity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcodeText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditSearch = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlFastItems = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceTempItems = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewFastItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchasePrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalePrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcodeText1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentQuanity1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditAddTempItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnAddTempItem = new DevExpress.XtraEditors.SimpleButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupControlInvoice = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtWhatsAppMessage = new DevExpress.XtraEditors.MemoEdit();
            this.previewPanel = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoVisibleRemark = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoVisibleQuantity = new DevExpress.XtraEditors.TextEdit();
            this.txtNovisiblePrice = new DevExpress.XtraEditors.TextEdit();
            this.cmbNoVisible = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourceNoVisibleItems = new System.Windows.Forms.BindingSource(this.components);
            this.btnNoVisible = new DevExpress.XtraEditors.SimpleButton();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.txtInvoiceTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAfterDiscount = new DevExpress.XtraEditors.TextEdit();
            this.txtDiscount = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
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
            this.dockPanelHotItems = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelReport = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnShiftReport = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUsersRPT = new DevExpress.XtraEditors.LookUpEdit();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnExpenseRPT = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDate = new DevExpress.XtraEditors.DateEdit();
            this.btnShowUserLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaleSummaryReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockReport = new DevExpress.XtraEditors.SimpleButton();
            this.dockPanelReturn = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
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
            this.btnInventory = new DevExpress.XtraEditors.SimpleButton();
            this.btnExpire = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuickItems = new DevExpress.XtraEditors.SimpleButton();
            this.btnExpenses = new DevExpress.XtraEditors.SimpleButton();
            this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.btnItemCategory = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowPurchaseInvoices = new DevExpress.XtraEditors.SimpleButton();
            this.btnItems = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangePassword = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowCalculator = new DevExpress.XtraEditors.SimpleButton();
            this.itemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSaleInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSaleInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditAddQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBarcodeAndSearch)).BeginInit();
            this.groupControlBarcodeAndSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.flyoutPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWhatsAppHistory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFastItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTempItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFastItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditAddTempItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInvoice)).BeginInit();
            this.groupControlInvoice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWhatsAppMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPanel)).BeginInit();
            this.previewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoVisibleRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoVisibleQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNovisiblePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNoVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNoVisibleItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfterDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanelHoulSearch.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwInventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchAllBranch.Properties)).BeginInit();
            this.dockPanelHotItems.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            this.hideContainerLeft.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.dockPanelReport.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsersRPT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).BeginInit();
            this.dockPanelReturn.SuspendLayout();
            this.dockPanel4_Container.SuspendLayout();
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
            // txtBar
            // 
            this.txtBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBar.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.txtBar.Location = new System.Drawing.Point(231, 14);
            this.txtBar.Name = "txtBar";
            this.txtBar.Size = new System.Drawing.Size(294, 38);
            this.txtBar.TabIndex = 0;
            this.txtBar.TextChanged += new System.EventHandler(this.txtBar_TextChanged);
            this.txtBar.Enter += new System.EventHandler(this.txtBar_Enter);
            this.txtBar.Leave += new System.EventHandler(this.txtBar_Leave);
            // 
            // bindingSourceItem
            // 
            this.bindingSourceItem.DataSource = typeof(DataAccess.vw_Inventory);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.EditValue = "";
            this.txtSearch.Location = new System.Drawing.Point(231, 67);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSearch.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSearch.Size = new System.Drawing.Size(294, 38);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // bindingSourceInventory
            // 
            this.bindingSourceInventory.DataSource = typeof(DataAccess.vw_Inventory);
            // 
            // gridControlInvoice
            // 
            this.gridControlInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlInvoice.DataSource = this.bindingSourceSaleInvoiceDetails;
            this.gridControlInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlInvoice.Location = new System.Drawing.Point(2, 2);
            this.gridControlInvoice.MainView = this.gridViewInvoice;
            this.gridControlInvoice.Name = "gridControlInvoice";
            this.gridControlInvoice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEditAddQuantity,
            this.repositoryItemSpinEdit1});
            this.gridControlInvoice.Size = new System.Drawing.Size(544, 311);
            this.gridControlInvoice.TabIndex = 0;
            this.gridControlInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInvoice});
            this.gridControlInvoice.Enter += new System.EventHandler(this.gridControl1_Enter);
            this.gridControlInvoice.Leave += new System.EventHandler(this.gridControl1_Leave);
            // 
            // bindingSourceSaleInvoiceDetails
            // 
            this.bindingSourceSaleInvoiceDetails.DataSource = typeof(DataAccess.SaleInvoiceDetail);
            // 
            // gridViewInvoice
            // 
            this.gridViewInvoice.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.gridViewInvoice.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridViewInvoice.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewInvoice.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewInvoice.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewInvoice.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewInvoice.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 16F);
            this.gridViewInvoice.Appearance.Row.Options.UseFont = true;
            this.gridViewInvoice.Appearance.Row.Options.UseTextOptions = true;
            this.gridViewInvoice.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewInvoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colSaleInvoiceID,
            this.colInventoryID,
            this.colItemID,
            this.colQuanitity,
            this.colUnitPrice,
            this.colRemarks,
            this.colInventory,
            this.colSaleInvoice,
            this.gridColumn1,
            this.gridColumnAddQuanitity,
            this.gridColumnItemTotal});
            this.gridViewInvoice.GridControl = this.gridControlInvoice;
            this.gridViewInvoice.Name = "gridViewInvoice";
            this.gridViewInvoice.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridViewInvoice.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewInvoice.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewInvoice.OptionsView.RowAutoHeight = true;
            this.gridViewInvoice.OptionsView.ShowAutoFilterRow = true;
            this.gridViewInvoice.OptionsView.ShowFooter = true;
            this.gridViewInvoice.OptionsView.ShowGroupPanel = false;
            this.gridViewInvoice.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colID, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridViewInvoice.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridViewInvoice.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridViewInvoice.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridViewInvoice.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridViewInvoice.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridViewInvoice.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridViewInvoice.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridViewInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridViewInvoice.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            // 
            // colSaleInvoiceID
            // 
            this.colSaleInvoiceID.FieldName = "SaleInvoiceID";
            this.colSaleInvoiceID.Name = "colSaleInvoiceID";
            // 
            // colInventoryID
            // 
            this.colInventoryID.FieldName = "InventoryID";
            this.colInventoryID.Name = "colInventoryID";
            // 
            // colItemID
            // 
            this.colItemID.AppearanceCell.Options.UseTextOptions = true;
            this.colItemID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colItemID.Caption = "الصنف";
            this.colItemID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colItemID.FieldName = "ItemID";
            this.colItemID.Name = "colItemID";
            this.colItemID.OptionsColumn.AllowEdit = false;
            this.colItemID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colItemID.Visible = true;
            this.colItemID.VisibleIndex = 5;
            this.colItemID.Width = 142;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 34, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.bindingSourceItem;
            this.repositoryItemLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // colQuanitity
            // 
            this.colQuanitity.Caption = "الكميه";
            this.colQuanitity.FieldName = "Quanitity";
            this.colQuanitity.Name = "colQuanitity";
            this.colQuanitity.OptionsColumn.FixedWidth = true;
            this.colQuanitity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colQuanitity.Visible = true;
            this.colQuanitity.VisibleIndex = 3;
            this.colQuanitity.Width = 120;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "السعر";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsColumn.AllowEdit = false;
            this.colUnitPrice.OptionsColumn.FixedWidth = true;
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 4;
            this.colUnitPrice.Width = 84;
            // 
            // colRemarks
            // 
            this.colRemarks.FieldName = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.Width = 85;
            // 
            // colInventory
            // 
            this.colInventory.FieldName = "Inventory";
            this.colInventory.Name = "colInventory";
            // 
            // colSaleInvoice
            // 
            this.colSaleInvoice.FieldName = "SaleInvoice";
            this.colSaleInvoice.Name = "colSaleInvoice";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "x";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.MaxWidth = 40;
            this.gridColumn1.MinWidth = 40;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 40;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::RedaPOS.Properties.Resources.delete_1_icon, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // gridColumnAddQuanitity
            // 
            this.gridColumnAddQuanitity.Caption = "+      -";
            this.gridColumnAddQuanitity.ColumnEdit = this.repositoryItemButtonEditAddQuantity;
            this.gridColumnAddQuanitity.Name = "gridColumnAddQuanitity";
            this.gridColumnAddQuanitity.OptionsColumn.FixedWidth = true;
            this.gridColumnAddQuanitity.Visible = true;
            this.gridColumnAddQuanitity.VisibleIndex = 2;
            this.gridColumnAddQuanitity.Width = 70;
            // 
            // repositoryItemButtonEditAddQuantity
            // 
            this.repositoryItemButtonEditAddQuantity.AutoHeight = false;
            this.repositoryItemButtonEditAddQuantity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Up),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.repositoryItemButtonEditAddQuantity.Name = "repositoryItemButtonEditAddQuantity";
            this.repositoryItemButtonEditAddQuantity.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEditAddQuantity.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditAddQuantity_ButtonClick);
            // 
            // gridColumnItemTotal
            // 
            this.gridColumnItemTotal.Caption = "المجموع";
            this.gridColumnItemTotal.FieldName = "gridColumnItemTotal";
            this.gridColumnItemTotal.Name = "gridColumnItemTotal";
            this.gridColumnItemTotal.OptionsColumn.FixedWidth = true;
            this.gridColumnItemTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumnItemTotal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumnItemTotal.Visible = true;
            this.gridColumnItemTotal.VisibleIndex = 1;
            this.gridColumnItemTotal.Width = 70;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit1.MaxLength = 5;
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1350;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupControlBarcodeAndSearch
            // 
            this.groupControlBarcodeAndSearch.Controls.Add(this.flyoutPanel1);
            this.groupControlBarcodeAndSearch.Controls.Add(this.gridControlSearch);
            this.groupControlBarcodeAndSearch.Controls.Add(this.groupControl6);
            this.groupControlBarcodeAndSearch.Location = new System.Drawing.Point(569, 12);
            this.groupControlBarcodeAndSearch.Name = "groupControlBarcodeAndSearch";
            this.groupControlBarcodeAndSearch.ShowCaption = false;
            this.groupControlBarcodeAndSearch.Size = new System.Drawing.Size(615, 514);
            this.groupControlBarcodeAndSearch.TabIndex = 2;
            this.groupControlBarcodeAndSearch.Text = "groupControl2";
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.Controls.Add(this.label8);
            this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
            this.flyoutPanel1.Location = new System.Drawing.Point(47, 207);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.Options.CloseOnOuterClick = true;
            this.flyoutPanel1.OptionsButtonPanel.AllowGlyphSkinning = true;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Top;
            toolTipItem1.Text = "Exit";
            superToolTip1.Items.Add(toolTipItem1);
            this.flyoutPanel1.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.Utils.PeekFormButton("", global::RedaPOS.Properties.Resources.exit, -1, DevExpress.XtraEditors.ButtonPanel.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Exit", true, -1, true, superToolTip1, true, false, true, null, "Exit", -1, false)});
            this.flyoutPanel1.OptionsButtonPanel.ShowButtonPanel = true;
            this.flyoutPanel1.OwnerControl = this;
            this.flyoutPanel1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.flyoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flyoutPanel1.Size = new System.Drawing.Size(301, 277);
            this.flyoutPanel1.TabIndex = 44;
            this.flyoutPanel1.ButtonClick += new DevExpress.Utils.FlyoutPanelButtonClickEventHandler(this.flyoutPanel1_ButtonClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "رسائل رسائل الموبايل التي تم ارسالها";
            // 
            // flyoutPanelControl1
            // 
            this.flyoutPanelControl1.Controls.Add(this.txtWhatsAppHistory);
            this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
            this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 30);
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            this.flyoutPanelControl1.Size = new System.Drawing.Size(301, 247);
            this.flyoutPanelControl1.TabIndex = 0;
            // 
            // txtWhatsAppHistory
            // 
            this.txtWhatsAppHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWhatsAppHistory.EditValue = "";
            this.txtWhatsAppHistory.Location = new System.Drawing.Point(2, 2);
            this.txtWhatsAppHistory.Name = "txtWhatsAppHistory";
            this.txtWhatsAppHistory.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWhatsAppHistory.Properties.WordWrap = false;
            this.txtWhatsAppHistory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWhatsAppHistory.Size = new System.Drawing.Size(297, 243);
            this.txtWhatsAppHistory.TabIndex = 0;
            // 
            // gridControlSearch
            // 
            this.gridControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlSearch.DataSource = this.bindingSourceInventory;
            this.gridControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.RelationName = "Level1";
            this.gridControlSearch.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlSearch.Location = new System.Drawing.Point(2, 111);
            this.gridControlSearch.MainView = this.gridViewSearch;
            this.gridControlSearch.Name = "gridControlSearch";
            this.gridControlSearch.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditSearch});
            this.gridControlSearch.Size = new System.Drawing.Size(611, 401);
            this.gridControlSearch.TabIndex = 26;
            this.gridControlSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSearch});
            this.gridControlSearch.Click += new System.EventHandler(this.gridControl2_Click);
            // 
            // gridViewSearch
            // 
            this.gridViewSearch.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.gridViewSearch.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gridViewSearch.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewSearch.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewSearch.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewSearch.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewSearch.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.gridViewSearch.Appearance.Row.Options.UseFont = true;
            this.gridViewSearch.Appearance.Row.Options.UseTextOptions = true;
            this.gridViewSearch.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colItemID1,
            this.colQuantity,
            this.colPurchasePrice,
            this.colSalePrice,
            this.colDiscountPrice,
            this.colReceiveQuantity,
            this.colCurrentQuanity,
            this.colName,
            this.colBarcodeText,
            this.colID1,
            this.gridColumn2});
            this.gridViewSearch.GridControl = this.gridControlSearch;
            this.gridViewSearch.Name = "gridViewSearch";
            this.gridViewSearch.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewSearch.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewSearch.OptionsView.ShowGroupPanel = false;
            this.gridViewSearch.OptionsView.ShowIndicator = false;
            this.gridViewSearch.DoubleClick += new System.EventHandler(this.gridViewSearch_DoubleClick);
            // 
            // colNumber
            // 
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            // 
            // colItemID1
            // 
            this.colItemID1.FieldName = "ItemID";
            this.colItemID1.Name = "colItemID1";
            // 
            // colQuantity
            // 
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            // 
            // colPurchasePrice
            // 
            this.colPurchasePrice.FieldName = "PurchasePrice";
            this.colPurchasePrice.Name = "colPurchasePrice";
            // 
            // colSalePrice
            // 
            this.colSalePrice.Caption = "السعر";
            this.colSalePrice.FieldName = "SalePrice";
            this.colSalePrice.Name = "colSalePrice";
            this.colSalePrice.OptionsColumn.AllowEdit = false;
            this.colSalePrice.Visible = true;
            this.colSalePrice.VisibleIndex = 2;
            this.colSalePrice.Width = 96;
            // 
            // colDiscountPrice
            // 
            this.colDiscountPrice.Caption = "التخفيض";
            this.colDiscountPrice.FieldName = "DiscountPrice";
            this.colDiscountPrice.Name = "colDiscountPrice";
            this.colDiscountPrice.OptionsColumn.AllowEdit = false;
            this.colDiscountPrice.Width = 73;
            // 
            // colReceiveQuantity
            // 
            this.colReceiveQuantity.FieldName = "ReceiveQuantity";
            this.colReceiveQuantity.Name = "colReceiveQuantity";
            // 
            // colCurrentQuanity
            // 
            this.colCurrentQuanity.Caption = "الكميه المتاحه";
            this.colCurrentQuanity.FieldName = "CurrentQuanity";
            this.colCurrentQuanity.Name = "colCurrentQuanity";
            this.colCurrentQuanity.OptionsColumn.AllowEdit = false;
            this.colCurrentQuanity.Visible = true;
            this.colCurrentQuanity.VisibleIndex = 1;
            this.colCurrentQuanity.Width = 92;
            // 
            // colName
            // 
            this.colName.Caption = "الصنف";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 387;
            // 
            // colBarcodeText
            // 
            this.colBarcodeText.FieldName = "BarcodeText";
            this.colBarcodeText.Name = "colBarcodeText";
            // 
            // colID1
            // 
            this.colID1.FieldName = "ID";
            this.colID1.Name = "colID1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "+";
            this.gridColumn2.ColumnEdit = this.repositoryItemButtonEditSearch;
            this.gridColumn2.MaxWidth = 35;
            this.gridColumn2.MinWidth = 35;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 35;
            // 
            // repositoryItemButtonEditSearch
            // 
            this.repositoryItemButtonEditSearch.AutoHeight = false;
            this.repositoryItemButtonEditSearch.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::RedaPOS.Properties.Resources.add_icon, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "", null, null, true)});
            this.repositoryItemButtonEditSearch.Name = "repositoryItemButtonEditSearch";
            this.repositoryItemButtonEditSearch.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEditSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditSearch_ButtonClick);
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.pictureBox2);
            this.groupControl6.Controls.Add(this.pictureBox1);
            this.groupControl6.Controls.Add(this.txtBar);
            this.groupControl6.Controls.Add(this.txtSearch);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl6.Location = new System.Drawing.Point(2, 2);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.ShowCaption = false;
            this.groupControl6.Size = new System.Drawing.Size(611, 109);
            this.groupControl6.TabIndex = 27;
            this.groupControl6.Text = "groupControl6";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::RedaPOS.Properties.Resources.Magnifier_tool_64;
            this.pictureBox2.Location = new System.Drawing.Point(531, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::RedaPOS.Properties.Resources.Barcode_64;
            this.pictureBox1.Location = new System.Drawing.Point(531, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControlFastItems);
            this.groupControl1.Controls.Add(this.btnAddTempItem);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(654, 658);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "groupControl1";
            // 
            // gridControlFastItems
            // 
            this.gridControlFastItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlFastItems.DataSource = this.bindingSourceTempItems;
            this.gridControlFastItems.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControlFastItems.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlFastItems.Location = new System.Drawing.Point(2, 2);
            this.gridControlFastItems.MainView = this.gridViewFastItems;
            this.gridControlFastItems.Name = "gridControlFastItems";
            this.gridControlFastItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditAddTempItem});
            this.gridControlFastItems.Size = new System.Drawing.Size(650, 631);
            this.gridControlFastItems.TabIndex = 0;
            this.gridControlFastItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFastItems});
            // 
            // bindingSourceTempItems
            // 
            this.bindingSourceTempItems.DataSource = typeof(DataAccess.vw_TempItem);
            // 
            // gridViewFastItems
            // 
            this.gridViewFastItems.Appearance.GroupRow.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.gridViewFastItems.Appearance.GroupRow.ForeColor = System.Drawing.Color.DarkOrange;
            this.gridViewFastItems.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewFastItems.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewFastItems.Appearance.GroupRow.Options.UseTextOptions = true;
            this.gridViewFastItems.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewFastItems.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.gridViewFastItems.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridViewFastItems.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewFastItems.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewFastItems.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewFastItems.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewFastItems.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 16F);
            this.gridViewFastItems.Appearance.Row.Options.UseFont = true;
            this.gridViewFastItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemID2,
            this.colGroupName,
            this.colDiscountPrice1,
            this.colPurchasePrice1,
            this.colSalePrice1,
            this.colBarcodeText1,
            this.colCurrentQuanity1,
            this.colName1,
            this.gridColumn3,
            this.gridColumn4});
            this.gridViewFastItems.GridControl = this.gridControlFastItems;
            this.gridViewFastItems.GroupCount = 1;
            this.gridViewFastItems.Name = "gridViewFastItems";
            this.gridViewFastItems.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFastItems.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFastItems.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewFastItems.OptionsView.ShowAutoFilterRow = true;
            this.gridViewFastItems.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridViewFastItems.OptionsView.ShowIndicator = false;
            this.gridViewFastItems.OptionsView.ShowViewCaption = true;
            this.gridViewFastItems.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGroupName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewFastItems.ViewCaption = "الأصناف السريعه";
            this.gridViewFastItems.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView3_CustomDrawGroupRow);
            this.gridViewFastItems.GroupRowExpanding += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView3_GroupRowExpanding);
            this.gridViewFastItems.DoubleClick += new System.EventHandler(this.gridViewFastItems_DoubleClick);
            // 
            // colItemID2
            // 
            this.colItemID2.FieldName = "ItemID";
            this.colItemID2.Name = "colItemID2";
            this.colItemID2.Width = 47;
            // 
            // colGroupName
            // 
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.OptionsColumn.ShowCaption = false;
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 1;
            this.colGroupName.Width = 54;
            // 
            // colDiscountPrice1
            // 
            this.colDiscountPrice1.FieldName = "DiscountPrice";
            this.colDiscountPrice1.Name = "colDiscountPrice1";
            this.colDiscountPrice1.Width = 44;
            // 
            // colPurchasePrice1
            // 
            this.colPurchasePrice1.FieldName = "PurchasePrice";
            this.colPurchasePrice1.Name = "colPurchasePrice1";
            this.colPurchasePrice1.Width = 44;
            // 
            // colSalePrice1
            // 
            this.colSalePrice1.AppearanceCell.Options.UseTextOptions = true;
            this.colSalePrice1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSalePrice1.Caption = "السعر";
            this.colSalePrice1.FieldName = "SalePrice";
            this.colSalePrice1.Name = "colSalePrice1";
            this.colSalePrice1.OptionsColumn.AllowEdit = false;
            this.colSalePrice1.OptionsColumn.AllowSize = false;
            this.colSalePrice1.OptionsColumn.FixedWidth = true;
            this.colSalePrice1.Visible = true;
            this.colSalePrice1.VisibleIndex = 2;
            this.colSalePrice1.Width = 55;
            // 
            // colBarcodeText1
            // 
            this.colBarcodeText1.FieldName = "BarcodeText";
            this.colBarcodeText1.Name = "colBarcodeText1";
            this.colBarcodeText1.Width = 51;
            // 
            // colCurrentQuanity1
            // 
            this.colCurrentQuanity1.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrentQuanity1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentQuanity1.Caption = "الكميه المتاحه";
            this.colCurrentQuanity1.FieldName = "CurrentQuanity";
            this.colCurrentQuanity1.Name = "colCurrentQuanity1";
            this.colCurrentQuanity1.OptionsColumn.AllowEdit = false;
            this.colCurrentQuanity1.OptionsColumn.AllowSize = false;
            this.colCurrentQuanity1.OptionsColumn.FixedWidth = true;
            this.colCurrentQuanity1.Visible = true;
            this.colCurrentQuanity1.VisibleIndex = 1;
            // 
            // colName1
            // 
            this.colName1.AppearanceCell.Options.UseTextOptions = true;
            this.colName1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colName1.Caption = " الصنف";
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.OptionsColumn.AllowEdit = false;
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 3;
            this.colName1.Width = 398;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "ترتيب";
            this.gridColumn3.FieldName = "ItemOrderID";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "+";
            this.gridColumn4.ColumnEdit = this.repositoryItemButtonEditAddTempItem;
            this.gridColumn4.MinWidth = 35;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 35;
            // 
            // repositoryItemButtonEditAddTempItem
            // 
            this.repositoryItemButtonEditAddTempItem.AutoHeight = false;
            this.repositoryItemButtonEditAddTempItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::RedaPOS.Properties.Resources.add_icon, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
            this.repositoryItemButtonEditAddTempItem.Name = "repositoryItemButtonEditAddTempItem";
            this.repositoryItemButtonEditAddTempItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEditAddTempItem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditAddTempItem_ButtonClick);
            // 
            // btnAddTempItem
            // 
            this.btnAddTempItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddTempItem.Location = new System.Drawing.Point(2, 633);
            this.btnAddTempItem.Name = "btnAddTempItem";
            this.btnAddTempItem.Size = new System.Drawing.Size(650, 23);
            this.btnAddTempItem.TabIndex = 1;
            this.btnAddTempItem.Text = "+";
            this.btnAddTempItem.Click += new System.EventHandler(this.btnAddTempItem_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DataAccess.TempItem);
            // 
            // groupControlInvoice
            // 
            this.groupControlInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlInvoice.Controls.Add(this.gridControlInvoice);
            this.groupControlInvoice.Controls.Add(this.groupBox1);
            this.groupControlInvoice.Location = new System.Drawing.Point(12, 12);
            this.groupControlInvoice.Name = "groupControlInvoice";
            this.groupControlInvoice.ShowCaption = false;
            this.groupControlInvoice.Size = new System.Drawing.Size(548, 514);
            this.groupControlInvoice.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupControl2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNoVisibleRemark);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNoVisibleQuantity);
            this.groupBox1.Controls.Add(this.txtNovisiblePrice);
            this.groupBox1.Controls.Add(this.cmbNoVisible);
            this.groupBox1.Controls.Add(this.btnNoVisible);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.txtInvoiceTotal);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.txtAfterDiscount);
            this.groupBox1.Controls.Add(this.txtDiscount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(2, 313);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 199);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "0";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtWhatsAppMessage);
            this.groupControl2.Controls.Add(this.previewPanel);
            this.groupControl2.Controls.Add(this.label7);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(3, 141);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(538, 55);
            this.groupControl2.TabIndex = 42;
            this.groupControl2.Text = "groupControl2";
            // 
            // txtWhatsAppMessage
            // 
            this.txtWhatsAppMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWhatsAppMessage.EditValue = "";
            this.txtWhatsAppMessage.Location = new System.Drawing.Point(2, 15);
            this.txtWhatsAppMessage.Name = "txtWhatsAppMessage";
            this.txtWhatsAppMessage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtWhatsAppMessage.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtWhatsAppMessage.Properties.Appearance.Options.UseFont = true;
            this.txtWhatsAppMessage.Properties.Appearance.Options.UseForeColor = true;
            this.txtWhatsAppMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWhatsAppMessage.Size = new System.Drawing.Size(494, 38);
            this.txtWhatsAppMessage.TabIndex = 40;
            this.txtWhatsAppMessage.Enter += new System.EventHandler(this.txtWhatsAppMessage_Enter);
            this.txtWhatsAppMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWhatsAppMessage_KeyDown);
            // 
            // previewPanel
            // 
            this.previewPanel.Controls.Add(this.pictureBox3);
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.previewPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.previewPanel.Location = new System.Drawing.Point(496, 15);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(40, 38);
            this.previewPanel.TabIndex = 28;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::RedaPOS.Properties.Resources.Whatsapp1;
            this.pictureBox3.Location = new System.Drawing.Point(2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 34);
            this.pictureBox3.TabIndex = 43;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseEnter += new System.EventHandler(this.OnPreviewPanelMouseEnter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(2, 2);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(433, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "رسائل واتساب خاصة بالتبليغ عن أصناف مطلوبه،  أعطال بالأجهزة، أي شي آخر متعلق بالم" +
    "كتبه";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "اسم الصنف";
            // 
            // txtNoVisibleRemark
            // 
            this.txtNoVisibleRemark.Location = new System.Drawing.Point(46, 37);
            this.txtNoVisibleRemark.Name = "txtNoVisibleRemark";
            this.txtNoVisibleRemark.Size = new System.Drawing.Size(126, 20);
            this.txtNoVisibleRemark.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "السعر";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "الكميه";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "أصناف بدون باركود";
            // 
            // txtNoVisibleQuantity
            // 
            this.txtNoVisibleQuantity.Location = new System.Drawing.Point(198, 37);
            this.txtNoVisibleQuantity.Name = "txtNoVisibleQuantity";
            this.txtNoVisibleQuantity.Size = new System.Drawing.Size(48, 20);
            this.txtNoVisibleQuantity.TabIndex = 2;
            // 
            // txtNovisiblePrice
            // 
            this.txtNovisiblePrice.Location = new System.Drawing.Point(259, 37);
            this.txtNovisiblePrice.Name = "txtNovisiblePrice";
            this.txtNovisiblePrice.Size = new System.Drawing.Size(45, 20);
            this.txtNovisiblePrice.TabIndex = 1;
            // 
            // cmbNoVisible
            // 
            this.cmbNoVisible.Location = new System.Drawing.Point(317, 37);
            this.cmbNoVisible.Name = "cmbNoVisible";
            this.cmbNoVisible.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.cmbNoVisible.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "Number", 60, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemID", "Item ID", 46, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Quantity", "Quantity", 52, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchasePrice", "Purchase Price", 80, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DiscountPrice", "Discount Price", 77, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReceiveQuantity", "Receive Quantity", 93, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrentQuanity", "Current Quanity", 88, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BarcodeText", "Barcode Text", 74, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 21, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReorderPoint", "Reorder Point", 76, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SalePrice", "Sale Price", 56, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BranchID", "Branch ID", 57, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BranchName", "Branch Name", 73, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CategoryID", "Category ID", 69, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbology", "Symbology", 62, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Model", "Model", 38, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MadeInCountry", "Made In Country", 91, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsHotItem", "Is Hot Item", 64, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HasExpireDate", "Has Expire Date", 87, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OriginalBarcodeText", "Original Barcode Text", 113, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemCategory", "Item Category", 80, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchaseInvoiceDetails", "Purchase Invoice Details", 127, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SaleInvoiceDetails", "Sale Invoice Details", 103, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TempItems", "Temp Items", 66, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Inventories", "Inventories", 65, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbNoVisible.Properties.DataSource = this.bindingSourceNoVisibleItems;
            this.cmbNoVisible.Properties.DisplayMember = "Name";
            this.cmbNoVisible.Properties.NullText = "";
            this.cmbNoVisible.Properties.ValueMember = "ItemID";
            this.cmbNoVisible.Size = new System.Drawing.Size(85, 20);
            this.cmbNoVisible.TabIndex = 0;
            this.cmbNoVisible.EditValueChanged += new System.EventHandler(this.cmbNoVisible_EditValueChanged);
            // 
            // bindingSourceNoVisibleItems
            // 
            this.bindingSourceNoVisibleItems.DataSource = typeof(DataAccess.vw_Inventory);
            // 
            // btnNoVisible
            // 
            this.btnNoVisible.Location = new System.Drawing.Point(6, 21);
            this.btnNoVisible.Name = "btnNoVisible";
            this.btnNoVisible.Size = new System.Drawing.Size(33, 36);
            this.btnNoVisible.TabIndex = 4;
            this.btnNoVisible.Text = "+";
            this.btnNoVisible.Click += new System.EventHandler(this.btnNoVisible_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.Location = new System.Drawing.Point(6, 183);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 30;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Location = new System.Drawing.Point(132, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "صافي الفاتورة";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrint.Image = global::RedaPOS.Properties.Resources.Print1;
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(6, 68);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(64, 67);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "&Print";
            this.btnPrint.ToolTip = "طباعه الفاتورة\r\nCtrl + السهم الشمال\r\n\r\nتاكيد بدون طباعه\r\nCtrl + السهم اليمين\r\n";
            this.btnPrint.ToolTipController = this.toolTipController1;
            this.btnPrint.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnPrint.ToolTipTitle = "تاكيد البيع";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtInvoiceTotal
            // 
            this.txtInvoiceTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInvoiceTotal.EditValue = "0";
            this.txtInvoiceTotal.Location = new System.Drawing.Point(300, 87);
            this.txtInvoiceTotal.Name = "txtInvoiceTotal";
            this.txtInvoiceTotal.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.txtInvoiceTotal.Properties.Appearance.Options.UseFont = true;
            this.txtInvoiceTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInvoiceTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtInvoiceTotal.Properties.Mask.EditMask = "f2";
            this.txtInvoiceTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInvoiceTotal.Properties.ReadOnly = true;
            this.txtInvoiceTotal.Size = new System.Drawing.Size(79, 38);
            this.txtInvoiceTotal.TabIndex = 26;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(312, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "مجموع الفاتورة";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Location = new System.Drawing.Point(247, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "التخفيض";
            // 
            // txtAfterDiscount
            // 
            this.txtAfterDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAfterDiscount.EditValue = "0";
            this.txtAfterDiscount.Location = new System.Drawing.Point(116, 87);
            this.txtAfterDiscount.Name = "txtAfterDiscount";
            this.txtAfterDiscount.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.txtAfterDiscount.Properties.Appearance.Options.UseFont = true;
            this.txtAfterDiscount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAfterDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtAfterDiscount.Properties.ReadOnly = true;
            this.txtAfterDiscount.Size = new System.Drawing.Size(79, 38);
            this.txtAfterDiscount.TabIndex = 28;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDiscount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscount.Location = new System.Drawing.Point(208, 87);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.txtDiscount.Properties.Appearance.Options.UseFont = true;
            this.txtDiscount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDiscount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDiscount.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDiscount.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtDiscount.Size = new System.Drawing.Size(79, 38);
            this.txtDiscount.TabIndex = 27;
            this.txtDiscount.EditValueChanged += new System.EventHandler(this.txtDiscount_EditValueChanged);
            this.txtDiscount.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtDiscount_EditValueChanging);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControlInvoice);
            this.layoutControl1.Controls.Add(this.groupControlBarcodeAndSearch);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(19, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1196, 538);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.splitterItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1196, 538);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.groupControlBarcodeAndSearch;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(557, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(619, 518);
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControlInvoice;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(552, 518);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(552, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 518);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight,
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
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerRight.Controls.Add(this.dockPanelHoulSearch);
            this.hideContainerRight.Controls.Add(this.dockPanelHotItems);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1215, 0);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(19, 685);
            this.hideContainerRight.Click += new System.EventHandler(this.hideContainerRight_Click);
            // 
            // dockPanelHoulSearch
            // 
            this.dockPanelHoulSearch.Controls.Add(this.dockPanel3_Container);
            this.dockPanelHoulSearch.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelHoulSearch.ID = new System.Guid("35223e2d-3e70-4718-b33b-2f7a7f4a3a79");
            this.dockPanelHoulSearch.Location = new System.Drawing.Point(378, 0);
            this.dockPanelHoulSearch.Name = "dockPanelHoulSearch";
            this.dockPanelHoulSearch.OriginalSize = new System.Drawing.Size(837, 200);
            this.dockPanelHoulSearch.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelHoulSearch.SavedIndex = 2;
            this.dockPanelHoulSearch.Size = new System.Drawing.Size(837, 685);
            this.dockPanelHoulSearch.Text = "البحث";
            this.dockPanelHoulSearch.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.pivotGridControl1);
            this.dockPanel3_Container.Controls.Add(this.txtSearchAllBranch);
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(829, 658);
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
            this.pivotGridControl1.Size = new System.Drawing.Size(829, 638);
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
            this.txtSearchAllBranch.StyleController = this.layoutControl1;
            this.txtSearchAllBranch.TabIndex = 35;
            this.txtSearchAllBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchAllBranch_KeyDown);
            // 
            // dockPanelHotItems
            // 
            this.dockPanelHotItems.Controls.Add(this.controlContainer1);
            this.dockPanelHotItems.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelHotItems.ID = new System.Guid("8753ce48-df04-4b19-8e1c-eea56dd824ca");
            this.dockPanelHotItems.Location = new System.Drawing.Point(553, 0);
            this.dockPanelHotItems.Name = "dockPanelHotItems";
            this.dockPanelHotItems.OriginalSize = new System.Drawing.Size(662, 200);
            this.dockPanelHotItems.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelHotItems.SavedIndex = 1;
            this.dockPanelHotItems.Size = new System.Drawing.Size(662, 685);
            this.dockPanelHotItems.Text = "الأصناف السريعه";
            this.dockPanelHotItems.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.groupControl1);
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(654, 658);
            this.controlContainer1.TabIndex = 0;
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Controls.Add(this.panelContainer1);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(19, 685);
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.dockPanelReport;
            this.panelContainer1.Controls.Add(this.dockPanelReturn);
            this.panelContainer1.Controls.Add(this.dockPanelReport);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.ID = new System.Guid("d76377ad-8b4c-4174-85de-6b0715eb122b");
            this.panelContainer1.Location = new System.Drawing.Point(19, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(464, 200);
            this.panelContainer1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.SavedIndex = 0;
            this.panelContainer1.Size = new System.Drawing.Size(464, 685);
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
            this.dockPanelReport.OriginalSize = new System.Drawing.Size(458, 657);
            this.dockPanelReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dockPanelReport.Size = new System.Drawing.Size(456, 658);
            this.dockPanelReport.Text = "التقارير";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnShiftReport);
            this.dockPanel1_Container.Controls.Add(this.label6);
            this.dockPanel1_Container.Controls.Add(this.cmbUsersRPT);
            this.dockPanel1_Container.Controls.Add(this.btnExpenseRPT);
            this.dockPanel1_Container.Controls.Add(this.label5);
            this.dockPanel1_Container.Controls.Add(this.cmbDate);
            this.dockPanel1_Container.Controls.Add(this.btnShowUserLogin);
            this.dockPanel1_Container.Controls.Add(this.btnSaleSummaryReport);
            this.dockPanel1_Container.Controls.Add(this.btnStockReport);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(456, 658);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnShiftReport
            // 
            this.btnShiftReport.Image = global::RedaPOS.Properties.Resources.Logout_icon1;
            this.btnShiftReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnShiftReport.Location = new System.Drawing.Point(152, 43);
            this.btnShiftReport.Name = "btnShiftReport";
            this.btnShiftReport.Size = new System.Drawing.Size(106, 94);
            this.btnShiftReport.StyleController = this.layoutControl1;
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
            // btnExpenseRPT
            // 
            this.btnExpenseRPT.Image = global::RedaPOS.Properties.Resources.money;
            this.btnExpenseRPT.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExpenseRPT.Location = new System.Drawing.Point(10, 43);
            this.btnExpenseRPT.Name = "btnExpenseRPT";
            this.btnExpenseRPT.Size = new System.Drawing.Size(106, 94);
            this.btnExpenseRPT.StyleController = this.layoutControl1;
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
            this.btnShowUserLogin.Image = global::RedaPOS.Properties.Resources.Time;
            this.btnShowUserLogin.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnShowUserLogin.Location = new System.Drawing.Point(10, 159);
            this.btnShowUserLogin.Name = "btnShowUserLogin";
            this.btnShowUserLogin.Size = new System.Drawing.Size(106, 94);
            this.btnShowUserLogin.StyleController = this.layoutControl1;
            this.btnShowUserLogin.TabIndex = 42;
            this.btnShowUserLogin.Text = "الحضور";
            this.btnShowUserLogin.ToolTip = "زمن الدخول والخروج";
            this.btnShowUserLogin.Click += new System.EventHandler(this.btnShowUserLogin_Click);
            // 
            // btnSaleSummaryReport
            // 
            this.btnSaleSummaryReport.Image = global::RedaPOS.Properties.Resources.Cash;
            this.btnSaleSummaryReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSaleSummaryReport.Location = new System.Drawing.Point(10, 275);
            this.btnSaleSummaryReport.Name = "btnSaleSummaryReport";
            this.btnSaleSummaryReport.Size = new System.Drawing.Size(106, 94);
            this.btnSaleSummaryReport.StyleController = this.layoutControl1;
            this.btnSaleSummaryReport.TabIndex = 41;
            this.btnSaleSummaryReport.Click += new System.EventHandler(this.btnSaleSummaryReport_Click);
            // 
            // btnStockReport
            // 
            this.btnStockReport.Image = ((System.Drawing.Image)(resources.GetObject("btnStockReport.Image")));
            this.btnStockReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnStockReport.Location = new System.Drawing.Point(10, 391);
            this.btnStockReport.Name = "btnStockReport";
            this.btnStockReport.Size = new System.Drawing.Size(106, 94);
            this.btnStockReport.StyleController = this.layoutControl1;
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
            this.dockPanelReturn.OriginalSize = new System.Drawing.Size(458, 657);
            this.dockPanelReturn.Size = new System.Drawing.Size(456, 658);
            this.dockPanelReturn.Text = "فواتير البيع";
            this.dockPanelReturn.Click += new System.EventHandler(this.dockPanelReturn_Click);
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Controls.Add(this.btnShowSaleInvoice);
            this.dockPanel4_Container.Controls.Add(this.cmbUsers);
            this.dockPanel4_Container.Controls.Add(this.btnSaleInvoiceSearch);
            this.dockPanel4_Container.Controls.Add(this.cmbSaleInvoiceDateFrom);
            this.dockPanel4_Container.Controls.Add(this.txtSaleInvoiceID);
            this.dockPanel4_Container.Controls.Add(this.gridControl1);
            this.dockPanel4_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(456, 658);
            this.dockPanel4_Container.TabIndex = 0;
            // 
            // btnShowSaleInvoice
            // 
            this.btnShowSaleInvoice.Image = global::RedaPOS.Properties.Resources.get;
            this.btnShowSaleInvoice.Location = new System.Drawing.Point(99, 10);
            this.btnShowSaleInvoice.Name = "btnShowSaleInvoice";
            this.btnShowSaleInvoice.Size = new System.Drawing.Size(99, 36);
            this.btnShowSaleInvoice.StyleController = this.layoutControl1;
            this.btnShowSaleInvoice.TabIndex = 25;
            this.btnShowSaleInvoice.Text = "عرض فواتير البيع";
            this.btnShowSaleInvoice.Click += new System.EventHandler(this.btnShowSaleInvoice_Click_1);
            // 
            // cmbUsers
            // 
            this.cmbUsers.Location = new System.Drawing.Point(309, 26);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
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
            this.cmbUsers.Size = new System.Drawing.Size(74, 20);
            this.cmbUsers.StyleController = this.layoutControl1;
            this.cmbUsers.TabIndex = 15;
            // 
            // btnSaleInvoiceSearch
            // 
            this.btnSaleInvoiceSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSaleInvoiceSearch.Image")));
            this.btnSaleInvoiceSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSaleInvoiceSearch.Location = new System.Drawing.Point(8, 55);
            this.btnSaleInvoiceSearch.Name = "btnSaleInvoiceSearch";
            this.btnSaleInvoiceSearch.Size = new System.Drawing.Size(67, 36);
            this.btnSaleInvoiceSearch.StyleController = this.layoutControl1;
            this.btnSaleInvoiceSearch.TabIndex = 9;
            this.btnSaleInvoiceSearch.ToolTip = "بحث عن طريق رقم الفاتوره";
            this.btnSaleInvoiceSearch.ToolTipController = this.toolTipController1;
            this.btnSaleInvoiceSearch.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSaleInvoiceSearch.Click += new System.EventHandler(this.btnSaleInvoiceSearch_Click);
            // 
            // cmbSaleInvoiceDateFrom
            // 
            this.cmbSaleInvoiceDateFrom.EditValue = null;
            this.cmbSaleInvoiceDateFrom.Location = new System.Drawing.Point(204, 26);
            this.cmbSaleInvoiceDateFrom.Name = "cmbSaleInvoiceDateFrom";
            this.cmbSaleInvoiceDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.cmbSaleInvoiceDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSaleInvoiceDateFrom.Properties.Mask.EditMask = "";
            this.cmbSaleInvoiceDateFrom.Size = new System.Drawing.Size(99, 20);
            this.cmbSaleInvoiceDateFrom.StyleController = this.layoutControl1;
            this.cmbSaleInvoiceDateFrom.TabIndex = 14;
            // 
            // txtSaleInvoiceID
            // 
            this.txtSaleInvoiceID.Location = new System.Drawing.Point(8, 17);
            this.txtSaleInvoiceID.Name = "txtSaleInvoiceID";
            this.txtSaleInvoiceID.Size = new System.Drawing.Size(75, 20);
            this.txtSaleInvoiceID.StyleController = this.layoutControl1;
            this.txtSaleInvoiceID.TabIndex = 10;
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.vwSaleReportBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(2, 113);
            this.gridControl1.MainView = this.gridViewSaleInvoice;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditSaleInvoice});
            this.gridControl1.Size = new System.Drawing.Size(442, 366);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "عرض الفاتورة", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "ارجاع الفاتورة", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::RedaPOS.Properties.Resources.print, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
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
            this.dockPanelOperations.Size = new System.Drawing.Size(1196, 147);
            this.dockPanelOperations.Text = "الأوامر";
            this.dockPanelOperations.Click += new System.EventHandler(this.dockPanelOperations_Click);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.btnInventory);
            this.dockPanel2_Container.Controls.Add(this.btnExpire);
            this.dockPanel2_Container.Controls.Add(this.btnQuickItems);
            this.dockPanel2_Container.Controls.Add(this.btnExpenses);
            this.dockPanel2_Container.Controls.Add(this.btnTransfer);
            this.dockPanel2_Container.Controls.Add(this.btnItemCategory);
            this.dockPanel2_Container.Controls.Add(this.btnShowPurchaseInvoices);
            this.dockPanel2_Container.Controls.Add(this.btnItems);
            this.dockPanel2_Container.Controls.Add(this.btnChangePassword);
            this.dockPanel2_Container.Controls.Add(this.btnClose);
            this.dockPanel2_Container.Controls.Add(this.btnShowCalculator);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 25);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1188, 118);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // btnInventory
            // 
            this.btnInventory.Image = global::RedaPOS.Properties.Resources.inventory;
            this.btnInventory.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnInventory.Location = new System.Drawing.Point(17, 14);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(83, 94);
            this.btnInventory.StyleController = this.layoutControl1;
            this.btnInventory.TabIndex = 46;
            this.btnInventory.Text = "الجرد";
            this.btnInventory.ToolTip = "مجموعات الأصناف";
            this.btnInventory.ToolTipController = this.toolTipController1;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnExpire
            // 
            this.btnExpire.Image = global::RedaPOS.Properties.Resources.trash_icon;
            this.btnExpire.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExpire.Location = new System.Drawing.Point(542, 14);
            this.btnExpire.Name = "btnExpire";
            this.btnExpire.Size = new System.Drawing.Size(83, 94);
            this.btnExpire.StyleController = this.layoutControl1;
            this.btnExpire.TabIndex = 49;
            this.btnExpire.Text = "التالف";
            this.btnExpire.Click += new System.EventHandler(this.btnExpire_Click);
            // 
            // btnQuickItems
            // 
            this.btnQuickItems.Image = global::RedaPOS.Properties.Resources.Fast_icon;
            this.btnQuickItems.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnQuickItems.Location = new System.Drawing.Point(332, 14);
            this.btnQuickItems.Name = "btnQuickItems";
            this.btnQuickItems.Size = new System.Drawing.Size(83, 94);
            this.btnQuickItems.TabIndex = 48;
            this.btnQuickItems.Text = "مشتروات سريعه";
            this.btnQuickItems.Click += new System.EventHandler(this.btnQuickItems_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.Image = global::RedaPOS.Properties.Resources.money;
            this.btnExpenses.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExpenses.Location = new System.Drawing.Point(752, 14);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(83, 94);
            this.btnExpenses.StyleController = this.layoutControl1;
            this.btnExpenses.TabIndex = 47;
            this.btnExpenses.Text = "مصروفات";
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Image = global::RedaPOS.Properties.Resources.Transfer;
            this.btnTransfer.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnTransfer.Location = new System.Drawing.Point(647, 14);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(83, 94);
            this.btnTransfer.StyleController = this.layoutControl1;
            this.btnTransfer.TabIndex = 46;
            this.btnTransfer.Text = "تحويل";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnItemCategory
            // 
            this.btnItemCategory.Image = global::RedaPOS.Properties.Resources.category;
            this.btnItemCategory.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnItemCategory.Location = new System.Drawing.Point(122, 14);
            this.btnItemCategory.Name = "btnItemCategory";
            this.btnItemCategory.Size = new System.Drawing.Size(83, 94);
            this.btnItemCategory.StyleController = this.layoutControl1;
            this.btnItemCategory.TabIndex = 45;
            this.btnItemCategory.Text = "اقسام الأصناف";
            this.btnItemCategory.ToolTip = "مجموعات الأصناف";
            this.btnItemCategory.ToolTipController = this.toolTipController1;
            this.btnItemCategory.Click += new System.EventHandler(this.btnItemCategory_Click);
            // 
            // btnShowPurchaseInvoices
            // 
            this.btnShowPurchaseInvoices.Image = global::RedaPOS.Properties.Resources.Invoice;
            this.btnShowPurchaseInvoices.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnShowPurchaseInvoices.Location = new System.Drawing.Point(437, 14);
            this.btnShowPurchaseInvoices.Name = "btnShowPurchaseInvoices";
            this.btnShowPurchaseInvoices.Size = new System.Drawing.Size(83, 94);
            this.btnShowPurchaseInvoices.StyleController = this.layoutControl1;
            this.btnShowPurchaseInvoices.TabIndex = 44;
            this.btnShowPurchaseInvoices.Text = "المشتروات";
            this.btnShowPurchaseInvoices.ToolTip = "فواتير المشتروات";
            this.btnShowPurchaseInvoices.ToolTipController = this.toolTipController1;
            this.btnShowPurchaseInvoices.Click += new System.EventHandler(this.btnShowPurchaseInvoices_Click);
            // 
            // btnItems
            // 
            this.btnItems.Image = global::RedaPOS.Properties.Resources.Items;
            this.btnItems.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnItems.Location = new System.Drawing.Point(227, 14);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(83, 94);
            this.btnItems.StyleController = this.layoutControl1;
            this.btnItems.TabIndex = 43;
            this.btnItems.Text = "الأصناف";
            this.btnItems.ToolTip = " الأصناف";
            this.btnItems.ToolTipController = this.toolTipController1;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Image")));
            this.btnChangePassword.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnChangePassword.Location = new System.Drawing.Point(962, 14);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(83, 94);
            this.btnChangePassword.StyleController = this.layoutControl1;
            this.btnChangePassword.TabIndex = 39;
            this.btnChangePassword.Text = "كلمة السر";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(1067, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 94);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "تغيير الوردية";
            this.btnClose.ToolTip = "خروج";
            this.btnClose.ToolTipController = this.toolTipController1;
            this.btnClose.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Warning;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowCalculator
            // 
            this.btnShowCalculator.Image = ((System.Drawing.Image)(resources.GetObject("btnShowCalculator.Image")));
            this.btnShowCalculator.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnShowCalculator.Location = new System.Drawing.Point(857, 14);
            this.btnShowCalculator.Margin = new System.Windows.Forms.Padding(10);
            this.btnShowCalculator.Name = "btnShowCalculator";
            this.btnShowCalculator.Size = new System.Drawing.Size(83, 94);
            this.btnShowCalculator.StyleController = this.layoutControl1;
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
            // SaleInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 685);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.dockPanelOperations);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.hideContainerRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaleInvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة بيع";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SaleInvoiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSaleInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSaleInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditAddQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBarcodeAndSearch)).EndInit();
            this.groupControlBarcodeAndSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            this.flyoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.flyoutPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWhatsAppHistory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFastItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTempItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFastItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditAddTempItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInvoice)).EndInit();
            this.groupControlInvoice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWhatsAppMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPanel)).EndInit();
            this.previewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoVisibleRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoVisibleQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNovisiblePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNoVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNoVisibleItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfterDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanelHoulSearch.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwInventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchAllBranch.Properties)).EndInit();
            this.dockPanelHotItems.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            this.hideContainerLeft.ResumeLayout(false);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceSaleInvoice;
        private DevExpress.XtraGrid.GridControl gridControlInvoice;
        private System.Windows.Forms.BindingSource bindingSourceSaleInvoiceDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInvoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource bindingSourceItem;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryID;
        private DevExpress.XtraGrid.Columns.GridColumn colQuanitity;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colRemarks;
        private DevExpress.XtraGrid.Columns.GridColumn colInventory;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn colItemID;
        private System.Windows.Forms.BindingSource bindingSourceInventory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.GroupControl groupControlBarcodeAndSearch;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraGrid.GridControl gridControlSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSearch;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colItemID1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiveQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentQuanity;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeText;
        private DevExpress.XtraGrid.Columns.GridColumn colID1;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.TextBox txtBar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddQuanitity;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditAddQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSourceTempItems;
        private DevExpress.XtraGrid.GridControl gridControlFastItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFastItems;
        private DevExpress.XtraGrid.Columns.GridColumn colItemID2;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchasePrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colSalePrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeText1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditAddTempItem;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentQuanity1;
        private DevExpress.XtraEditors.SimpleButton btnAddTempItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.GroupControl groupControlInvoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.TextEdit txtInvoiceTotal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAfterDiscount;
        private DevExpress.XtraEditors.SpinEdit txtDiscount;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnNoVisible;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtNoVisibleQuantity;
        private DevExpress.XtraEditors.TextEdit txtNovisiblePrice;
        private DevExpress.XtraEditors.LookUpEdit cmbNoVisible;
        private System.Windows.Forms.BindingSource bindingSourceNoVisibleItems;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtNoVisibleRemark;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelOperations;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelReport;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.SimpleButton btnExpenses;
        private DevExpress.XtraEditors.SimpleButton btnTransfer;
        private DevExpress.XtraEditors.SimpleButton btnItemCategory;
        private DevExpress.XtraEditors.SimpleButton btnShowPurchaseInvoices;
        private DevExpress.XtraEditors.SimpleButton btnItems;
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
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private System.Windows.Forms.BindingSource vwInventoryBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnQuickItems;
        private DevExpress.XtraEditors.SimpleButton btnExpenseRPT;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.DateEdit cmbDate;
        private DevExpress.XtraEditors.SimpleButton btnExpire;
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
        private DevExpress.XtraBars.Docking.DockPanel dockPanelHotItems;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private System.Windows.Forms.BindingSource itemBindingSource1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private DevExpress.XtraEditors.SimpleButton btnInventory;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.MemoEdit txtWhatsAppMessage;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.PanelControl previewPanel;
        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private DevExpress.XtraEditors.MemoEdit txtWhatsAppHistory;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
    }
}
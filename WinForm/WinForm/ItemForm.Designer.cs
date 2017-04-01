namespace WinForm
{
    partial class ItemForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator2 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.bindingSourceItem = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourceCategory = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtModel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMade = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSalePrice = new DevExpress.XtraEditors.SpinEdit();
            this.cbHasExpireDate = new DevExpress.XtraEditors.CheckEdit();
            this.cbIsHotItem = new DevExpress.XtraEditors.CheckEdit();
            this.txtReorderPoint = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtOriginalBarcodeText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.barCodeControlOrginal = new DevExpress.XtraEditors.BarCodeControl();
            this.barCodeControlReda = new DevExpress.XtraEditors.BarCodeControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceItemBarcode = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcodeText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbActive = new DevExpress.XtraEditors.CheckEdit();
            this.cbHidden = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHasExpireDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsHotItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderPoint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginalBarcodeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItemBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHidden.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "Name", true));
            this.txtName.Location = new System.Drawing.Point(63, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(332, 20);
            this.txtName.TabIndex = 0;
            // 
            // bindingSourceItem
            // 
            this.bindingSourceItem.DataSource = typeof(DataAccess.Item);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "الاسم";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "CategoryID", true));
            this.cmbCategory.Location = new System.Drawing.Point(63, 108);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.cmbCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 34, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "Category", 55, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description", 63, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Items", "Items", 37, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbCategory.Properties.DataSource = this.bindingSourceCategory;
            this.cmbCategory.Properties.DisplayMember = "Category";
            this.cmbCategory.Properties.ValueMember = "ID";
            this.cmbCategory.Size = new System.Drawing.Size(120, 20);
            this.cmbCategory.TabIndex = 2;
            // 
            // bindingSourceCategory
            // 
            this.bindingSourceCategory.DataSource = typeof(DataAccess.ItemCategory);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(232, 107);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "الموديل";
            // 
            // txtModel
            // 
            this.txtModel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "Model", true));
            this.txtModel.Location = new System.Drawing.Point(275, 108);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(120, 20);
            this.txtModel.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(225, 152);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "بلد الصنع";
            // 
            // txtMade
            // 
            this.txtMade.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "MadeInCountry", true));
            this.txtMade.Location = new System.Drawing.Point(275, 149);
            this.txtMade.Name = "txtMade";
            this.txtMade.Size = new System.Drawing.Size(120, 20);
            this.txtMade.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 107);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "المجموعه";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 156);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "سعر البيع";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "SalePrice", true));
            this.txtSalePrice.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtSalePrice.Location = new System.Drawing.Point(63, 153);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtSalePrice.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtSalePrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtSalePrice.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtSalePrice.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtSalePrice.Size = new System.Drawing.Size(120, 20);
            this.txtSalePrice.TabIndex = 3;
            // 
            // cbHasExpireDate
            // 
            this.cbHasExpireDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "HasExpireDate", true));
            this.cbHasExpireDate.EditValue = null;
            this.cbHasExpireDate.Location = new System.Drawing.Point(170, 61);
            this.cbHasExpireDate.Name = "cbHasExpireDate";
            this.cbHasExpireDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.cbHasExpireDate.Properties.Caption = "له تاريخ صلاحية";
            this.cbHasExpireDate.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.cbHasExpireDate.Properties.NullText = "[EditValue is null]";
            this.cbHasExpireDate.Size = new System.Drawing.Size(113, 19);
            this.cbHasExpireDate.TabIndex = 1;
            this.cbHasExpireDate.CheckedChanged += new System.EventHandler(this.cbHasExpireDate_CheckedChanged);
            // 
            // cbIsHotItem
            // 
            this.cbIsHotItem.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "IsHotItem", true));
            this.cbIsHotItem.EditValue = null;
            this.cbIsHotItem.Location = new System.Drawing.Point(63, 61);
            this.cbIsHotItem.Name = "cbIsHotItem";
            this.cbIsHotItem.Properties.Appearance.Options.UseTextOptions = true;
            this.cbIsHotItem.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cbIsHotItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.cbIsHotItem.Properties.Caption = "صنف نشط";
            this.cbIsHotItem.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.cbIsHotItem.Properties.NullText = "[EditValue is null]";
            this.cbIsHotItem.Size = new System.Drawing.Size(80, 19);
            this.cbIsHotItem.TabIndex = 1;
            // 
            // txtReorderPoint
            // 
            this.txtReorderPoint.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "ReorderPoint", true));
            this.txtReorderPoint.EditValue = "5";
            this.txtReorderPoint.Location = new System.Drawing.Point(63, 196);
            this.txtReorderPoint.Name = "txtReorderPoint";
            this.txtReorderPoint.Size = new System.Drawing.Size(120, 20);
            this.txtReorderPoint.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 199);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 13);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "حد الطلب";
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Image = global::RedaPOS.Properties.Resources.save48;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(752, 68);
            this.btnSave.TabIndex = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOriginalBarcodeText
            // 
            this.txtOriginalBarcodeText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "OriginalBarcodeText", true));
            this.txtOriginalBarcodeText.Location = new System.Drawing.Point(275, 192);
            this.txtOriginalBarcodeText.Name = "txtOriginalBarcodeText";
            this.txtOriginalBarcodeText.Size = new System.Drawing.Size(120, 20);
            this.txtOriginalBarcodeText.TabIndex = 4;
            this.txtOriginalBarcodeText.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(204, 195);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(62, 13);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "باركود الشركه";
            this.labelControl7.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // barCodeControlOrginal
            // 
            this.barCodeControlOrginal.AutoModule = true;
            this.barCodeControlOrginal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceItem, "OriginalBarcodeText", true));
            this.barCodeControlOrginal.Location = new System.Drawing.Point(14, 284);
            this.barCodeControlOrginal.Name = "barCodeControlOrginal";
            this.barCodeControlOrginal.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControlOrginal.Size = new System.Drawing.Size(336, 75);
            this.barCodeControlOrginal.Symbology = code128Generator2;
            this.barCodeControlOrginal.TabIndex = 9;
            // 
            // barCodeControlReda
            // 
            this.barCodeControlReda.AutoModule = true;
            this.barCodeControlReda.Location = new System.Drawing.Point(416, 284);
            this.barCodeControlReda.Name = "barCodeControlReda";
            this.barCodeControlReda.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControlReda.Size = new System.Drawing.Size(336, 75);
            this.barCodeControlReda.Symbology = code128Generator1;
            this.barCodeControlReda.TabIndex = 9;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(123, 265);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(94, 13);
            this.labelControl9.TabIndex = 11;
            this.labelControl9.Text = "باركود الصنف الأصلي";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSourceItemBarcode;
            this.gridControl1.Location = new System.Drawing.Point(416, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(336, 266);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSourceItemBarcode
            // 
            this.bindingSourceItemBarcode.AllowNew = true;
            this.bindingSourceItemBarcode.DataSource = typeof(DataAccess.ItemBarcode);
            this.bindingSourceItemBarcode.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bindingSourceItemBarcode_AddingNew);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colItemID,
            this.colBarcodeText,
            this.colItem});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "بارد كود";
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView1_RowDeleting);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colItemID
            // 
            this.colItemID.FieldName = "ItemID";
            this.colItemID.Name = "colItemID";
            // 
            // colBarcodeText
            // 
            this.colBarcodeText.FieldName = "BarcodeText";
            this.colBarcodeText.Name = "colBarcodeText";
            this.colBarcodeText.Visible = true;
            this.colBarcodeText.VisibleIndex = 0;
            // 
            // colItem
            // 
            this.colItem.FieldName = "Item";
            this.colItem.Name = "colItem";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 361);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(756, 72);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "groupControl1";
            // 
            // cbActive
            // 
            this.cbActive.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "OutOfMarket", true));
            this.cbActive.EditValue = null;
            this.cbActive.Location = new System.Drawing.Point(300, 61);
            this.cbActive.Name = "cbActive";
            this.cbActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.cbActive.Properties.Caption = "صنف متوقف";
            this.cbActive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.cbActive.Properties.NullText = "[EditValue is null]";
            this.cbActive.Size = new System.Drawing.Size(92, 19);
            this.cbActive.TabIndex = 1;
            this.cbActive.CheckedChanged += new System.EventHandler(this.cbHasExpireDate_CheckedChanged);
            // 
            // cbHidden
            // 
            this.cbHidden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceItem, "Hidden", true));
            this.cbHidden.Location = new System.Drawing.Point(63, 237);
            this.cbHidden.Name = "cbHidden";
            this.cbHidden.Properties.Caption = "إخفاء";
            this.cbHidden.Size = new System.Drawing.Size(75, 19);
            this.cbHidden.TabIndex = 14;
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 433);
            this.Controls.Add(this.cbHidden);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.barCodeControlReda);
            this.Controls.Add(this.barCodeControlOrginal);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtOriginalBarcodeText);
            this.Controls.Add(this.txtReorderPoint);
            this.Controls.Add(this.txtMade);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.cbIsHotItem);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.cbHasExpireDate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صنف";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemForm_FormClosing);
            this.Load += new System.EventHandler(this.ItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHasExpireDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsHotItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderPoint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginalBarcodeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItemBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHidden.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.BindingSource bindingSourceItem;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbCategory;
        private System.Windows.Forms.BindingSource bindingSourceCategory;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtModel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMade;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit txtSalePrice;
        private DevExpress.XtraEditors.CheckEdit cbHasExpireDate;
        private DevExpress.XtraEditors.CheckEdit cbIsHotItem;
        private DevExpress.XtraEditors.TextEdit txtReorderPoint;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtOriginalBarcodeText;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.BarCodeControl barCodeControlReda;
        private DevExpress.XtraEditors.BarCodeControl barCodeControlOrginal;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSourceItemBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeText;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit cbActive;
        private DevExpress.XtraEditors.CheckEdit cbHidden;
    }
}
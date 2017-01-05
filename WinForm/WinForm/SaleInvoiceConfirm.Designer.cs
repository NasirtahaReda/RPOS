namespace WinForm
{
    partial class SaleInvoiceConfirm
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAfterDiscount = new DevExpress.XtraEditors.TextEdit();
            this.txtDiscount = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCashFromCustomer = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCashReturn = new DevExpress.XtraEditors.TextEdit();
            this.btn_ConfirmWithouPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ConfirmًWithPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfterDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashFromCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashReturn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(81, 222);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(95, 17);
            this.labelControl3.TabIndex = 33;
            this.labelControl3.Text = "صافي الفاتورة";
            // 
            // txtInvoiceTotal
            // 
            this.txtInvoiceTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInvoiceTotal.EditValue = "0";
            this.txtInvoiceTotal.Location = new System.Drawing.Point(181, 70);
            this.txtInvoiceTotal.Name = "txtInvoiceTotal";
            this.txtInvoiceTotal.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txtInvoiceTotal.Properties.Appearance.Options.UseFont = true;
            this.txtInvoiceTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInvoiceTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtInvoiceTotal.Properties.Mask.EditMask = "f2";
            this.txtInvoiceTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInvoiceTotal.Properties.ReadOnly = true;
            this.txtInvoiceTotal.Size = new System.Drawing.Size(109, 30);
            this.txtInvoiceTotal.TabIndex = 30;
            this.txtInvoiceTotal.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(77, 78);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(99, 17);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "مجموع الفاتورة";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(117, 174);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 17);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "التخفيض";
            // 
            // txtAfterDiscount
            // 
            this.txtAfterDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAfterDiscount.EditValue = "0";
            this.txtAfterDiscount.Location = new System.Drawing.Point(181, 214);
            this.txtAfterDiscount.Name = "txtAfterDiscount";
            this.txtAfterDiscount.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txtAfterDiscount.Properties.Appearance.Options.UseFont = true;
            this.txtAfterDiscount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAfterDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtAfterDiscount.Properties.ReadOnly = true;
            this.txtAfterDiscount.Size = new System.Drawing.Size(109, 30);
            this.txtAfterDiscount.TabIndex = 32;
            this.txtAfterDiscount.TabStop = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDiscount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscount.Location = new System.Drawing.Point(181, 166);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txtDiscount.Properties.Appearance.Options.UseFont = true;
            this.txtDiscount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDiscount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDiscount.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDiscount.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtDiscount.Size = new System.Drawing.Size(109, 30);
            this.txtDiscount.TabIndex = 1;
            this.txtDiscount.EditValueChanged += new System.EventHandler(this.txtDiscount_EditValueChanged);
            this.txtDiscount.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtDiscount_EditValueChanging);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(13, 126);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(163, 17);
            this.labelControl4.TabIndex = 38;
            this.labelControl4.Text = "المبلغ المستلم من الزبون";
            // 
            // txtCashFromCustomer
            // 
            this.txtCashFromCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCashFromCustomer.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCashFromCustomer.Location = new System.Drawing.Point(181, 118);
            this.txtCashFromCustomer.Name = "txtCashFromCustomer";
            this.txtCashFromCustomer.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txtCashFromCustomer.Properties.Appearance.Options.UseFont = true;
            this.txtCashFromCustomer.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCashFromCustomer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCashFromCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCashFromCustomer.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtCashFromCustomer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtCashFromCustomer.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtCashFromCustomer.Size = new System.Drawing.Size(109, 30);
            this.txtCashFromCustomer.TabIndex = 0;
            this.txtCashFromCustomer.EditValueChanged += new System.EventHandler(this.txtCashFromCustomer_EditValueChanged);
            this.txtCashFromCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashFromCustomer_KeyDown);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(50, 270);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(126, 17);
            this.labelControl5.TabIndex = 40;
            this.labelControl5.Text = "المبلغ الراجع للزبون";
            // 
            // txtCashReturn
            // 
            this.txtCashReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCashReturn.EditValue = "0";
            this.txtCashReturn.Location = new System.Drawing.Point(181, 262);
            this.txtCashReturn.Name = "txtCashReturn";
            this.txtCashReturn.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txtCashReturn.Properties.Appearance.Options.UseFont = true;
            this.txtCashReturn.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCashReturn.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCashReturn.Properties.ReadOnly = true;
            this.txtCashReturn.Size = new System.Drawing.Size(109, 30);
            this.txtCashReturn.TabIndex = 41;
            this.txtCashReturn.TabStop = false;
            // 
            // btn_ConfirmWithouPrint
            // 
            this.btn_ConfirmWithouPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ConfirmWithouPrint.Appearance.Options.UseFont = true;
            this.btn_ConfirmWithouPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ConfirmWithouPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ConfirmWithouPrint.Image = global::RedaPOS.Properties.Resources.face_smile;
            this.btn_ConfirmWithouPrint.Location = new System.Drawing.Point(2, 23);
            this.btn_ConfirmWithouPrint.Name = "btn_ConfirmWithouPrint";
            this.btn_ConfirmWithouPrint.Size = new System.Drawing.Size(173, 60);
            this.btn_ConfirmWithouPrint.TabIndex = 1;
            this.btn_ConfirmWithouPrint.Text = " بدون طباعة";
            this.btn_ConfirmWithouPrint.Click += new System.EventHandler(this.btn_ConfirmWithouPrint_Click);
            // 
            // btn_ConfirmًWithPrint
            // 
            this.btn_ConfirmًWithPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ConfirmًWithPrint.Appearance.Options.UseFont = true;
            this.btn_ConfirmًWithPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ConfirmًWithPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ConfirmًWithPrint.Image = global::RedaPOS.Properties.Resources.document_print;
            this.btn_ConfirmًWithPrint.Location = new System.Drawing.Point(180, 23);
            this.btn_ConfirmًWithPrint.Name = "btn_ConfirmًWithPrint";
            this.btn_ConfirmًWithPrint.Size = new System.Drawing.Size(174, 60);
            this.btn_ConfirmًWithPrint.TabIndex = 0;
            this.btn_ConfirmًWithPrint.Text = "طباعة";
            this.btn_ConfirmًWithPrint.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCancel.Image = global::RedaPOS.Properties.Resources.Go_back;
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(356, 41);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "رجوع للفاتورة";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupControl1.Controls.Add(this.btn_ConfirmًWithPrint);
            this.groupControl1.Controls.Add(this.btn_ConfirmWithouPrint);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 319);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(356, 85);
            this.groupControl1.TabIndex = 43;
            this.groupControl1.Text = "تأكيد البيع ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SaleInvoiceConfirm
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 404);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtCashReturn);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtCashFromCustomer);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtInvoiceTotal);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtAfterDiscount);
            this.Controls.Add(this.txtDiscount);
            this.Name = "SaleInvoiceConfirm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تأكيد البيع";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SaleInvoiceConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfterDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashFromCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashReturn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtInvoiceTotal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAfterDiscount;
        private DevExpress.XtraEditors.SpinEdit txtDiscount;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btn_ConfirmًWithPrint;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit txtCashFromCustomer;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCashReturn;
        private DevExpress.XtraEditors.SimpleButton btn_ConfirmWithouPrint;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
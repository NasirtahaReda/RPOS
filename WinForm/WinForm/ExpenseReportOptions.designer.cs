namespace WinForm.Reports
{
    partial class ExpenseReportOptions
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
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btnShowReport = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUsersRPT = new DevExpress.XtraEditors.LookUpEdit();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbFrom = new DevExpress.XtraEditors.DateEdit();
            this.cmbTo = new DevExpress.XtraEditors.DateEdit();
            this.cmbBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbExpenseUser = new DevExpress.XtraEditors.LookUpEdit();
            this.cbEnableShifUser = new DevExpress.XtraEditors.CheckEdit();
            this.cbEnableBranch = new DevExpress.XtraEditors.CheckEdit();
            this.cbEnableExpenseUser = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsersRPT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExpenseUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableShifUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableExpenseUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowReport
            // 
            this.btnShowReport.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnShowReport.Appearance.Options.UseFont = true;
            this.btnShowReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnShowReport.Image = global::RedaPOS.Properties.Resources.Reports_icon;
            this.btnShowReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnShowReport.Location = new System.Drawing.Point(0, 230);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(344, 75);
            this.btnShowReport.TabIndex = 0;
            this.btnShowReport.Text = "عرض التقرير";
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(91, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "الي تاريخ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(240, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "من تاريخ";
            // 
            // cmbUsersRPT
            // 
            this.cmbUsersRPT.Location = new System.Drawing.Point(58, 64);
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
            this.cmbUsersRPT.Size = new System.Drawing.Size(112, 20);
            this.cmbUsersRPT.TabIndex = 47;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(DataAccess.User);
            // 
            // cmbFrom
            // 
            this.cmbFrom.EditValue = null;
            this.cmbFrom.Location = new System.Drawing.Point(192, 172);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFrom.Properties.DisplayFormat.FormatString = "";
            this.cmbFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbFrom.Properties.EditFormat.FormatString = "";
            this.cmbFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbFrom.Properties.Mask.EditMask = "";
            this.cmbFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.cmbFrom.Size = new System.Drawing.Size(100, 20);
            this.cmbFrom.TabIndex = 4;
            // 
            // cmbTo
            // 
            this.cmbTo.EditValue = null;
            this.cmbTo.Location = new System.Drawing.Point(48, 172);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTo.Properties.DisplayFormat.FormatString = "";
            this.cmbTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbTo.Properties.EditFormat.FormatString = "";
            this.cmbTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbTo.Properties.Mask.EditMask = "";
            this.cmbTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.cmbTo.Size = new System.Drawing.Size(100, 20);
            this.cmbTo.TabIndex = 4;
            // 
            // cmbBranch
            // 
            this.cmbBranch.Location = new System.Drawing.Point(58, 21);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBranch.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 34, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BranchName", "Branch Name", 73, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Address", 49, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Phone", "Phone", 40, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Email", "Email", 34, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Inventories", "Inventories", 65, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchaseInvoices", "Purchase Invoices", 97, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SaleInvoices", "Sale Invoices", 73, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserLogins", "User Logins", 65, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbBranch.Properties.DataSource = this.branchBindingSource;
            this.cmbBranch.Properties.DisplayMember = "BranchName";
            this.cmbBranch.Properties.NullText = "";
            this.cmbBranch.Properties.ValueMember = "ID";
            this.cmbBranch.Size = new System.Drawing.Size(112, 20);
            this.cmbBranch.TabIndex = 49;
            // 
            // branchBindingSource
            // 
            this.branchBindingSource.DataSource = typeof(DataAccess.Branch);
            // 
            // cmbExpenseUser
            // 
            this.cmbExpenseUser.Location = new System.Drawing.Point(58, 107);
            this.cmbExpenseUser.Name = "cmbExpenseUser";
            this.cmbExpenseUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbExpenseUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
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
            this.cmbExpenseUser.Properties.DataSource = this.userBindingSource;
            this.cmbExpenseUser.Properties.DisplayMember = "FullName";
            this.cmbExpenseUser.Properties.NullText = "";
            this.cmbExpenseUser.Properties.ValueMember = "ID";
            this.cmbExpenseUser.Size = new System.Drawing.Size(112, 20);
            this.cmbExpenseUser.TabIndex = 51;
            // 
            // cbEnableShifUser
            // 
            this.cbEnableShifUser.EditValue = true;
            this.cbEnableShifUser.Location = new System.Drawing.Point(190, 65);
            this.cbEnableShifUser.Name = "cbEnableShifUser";
            this.cbEnableShifUser.Properties.Caption = "موظف الوردية";
            this.cbEnableShifUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbEnableShifUser.Size = new System.Drawing.Size(90, 19);
            this.cbEnableShifUser.TabIndex = 52;
            this.cbEnableShifUser.CheckedChanged += new System.EventHandler(this.cbEnableShifUser_CheckedChanged);
            // 
            // cbEnableBranch
            // 
            this.cbEnableBranch.EditValue = true;
            this.cbEnableBranch.Location = new System.Drawing.Point(190, 21);
            this.cbEnableBranch.Name = "cbEnableBranch";
            this.cbEnableBranch.Properties.Caption = "الفرع";
            this.cbEnableBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbEnableBranch.Size = new System.Drawing.Size(90, 19);
            this.cbEnableBranch.TabIndex = 53;
            this.cbEnableBranch.CheckedChanged += new System.EventHandler(this.cbEnableBranch_CheckedChanged);
            // 
            // cbEnableExpenseUser
            // 
            this.cbEnableExpenseUser.EditValue = true;
            this.cbEnableExpenseUser.Location = new System.Drawing.Point(176, 107);
            this.cbEnableExpenseUser.Name = "cbEnableExpenseUser";
            this.cbEnableExpenseUser.Properties.Caption = "الموظف المستفيد";
            this.cbEnableExpenseUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbEnableExpenseUser.Size = new System.Drawing.Size(104, 19);
            this.cbEnableExpenseUser.TabIndex = 54;
            this.cbEnableExpenseUser.CheckedChanged += new System.EventHandler(this.cbEnableExpenseUser_CheckedChanged);
            // 
            // ExpenseReportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 305);
            this.Controls.Add(this.cbEnableExpenseUser);
            this.Controls.Add(this.cbEnableBranch);
            this.Controls.Add(this.cbEnableShifUser);
            this.Controls.Add(this.cmbExpenseUser);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.cmbUsersRPT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.cmbTo);
            this.Name = "ExpenseReportOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خيارات تقرير المنصرفات";
            this.Load += new System.EventHandler(this.StockReportOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsersRPT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExpenseUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableShifUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableExpenseUser.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnShowReport;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit cmbUsersRPT;
        private DevExpress.XtraEditors.DateEdit cmbFrom;
        private DevExpress.XtraEditors.DateEdit cmbTo;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource branchBindingSource;
        private DevExpress.XtraEditors.LookUpEdit cmbBranch;
        private DevExpress.XtraEditors.LookUpEdit cmbExpenseUser;
        private DevExpress.XtraEditors.CheckEdit cbEnableShifUser;
        private DevExpress.XtraEditors.CheckEdit cbEnableBranch;
        private DevExpress.XtraEditors.CheckEdit cbEnableExpenseUser;
    }
}
namespace WinForm.Reports
{
    partial class UserPaymentReportOptions
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
            this.branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbEnableShifUser = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsersRPT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableShifUser.Properties)).BeginInit();
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
            this.btnShowReport.Size = new System.Drawing.Size(381, 75);
            this.btnShowReport.TabIndex = 0;
            this.btnShowReport.Text = "عرض التقرير";
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(104, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "الي تاريخ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(253, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "من تاريخ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbUsersRPT
            // 
            this.cmbUsersRPT.Location = new System.Drawing.Point(71, 65);
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
            this.cmbUsersRPT.Properties.DropDownRows = 15;
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
            this.cmbFrom.Location = new System.Drawing.Point(205, 173);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFrom.Properties.DisplayFormat.FormatString = "";
            this.cmbFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbFrom.Properties.EditFormat.FormatString = "";
            this.cmbFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbFrom.Size = new System.Drawing.Size(100, 20);
            this.cmbFrom.TabIndex = 4;
            this.cmbFrom.EditValueChanged += new System.EventHandler(this.cmbFrom_EditValueChanged);
            // 
            // cmbTo
            // 
            this.cmbTo.EditValue = null;
            this.cmbTo.Location = new System.Drawing.Point(61, 173);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTo.Properties.DisplayFormat.FormatString = "";
            this.cmbTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbTo.Properties.EditFormat.FormatString = "";
            this.cmbTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cmbTo.Size = new System.Drawing.Size(100, 20);
            this.cmbTo.TabIndex = 4;
            // 
            // branchBindingSource
            // 
            this.branchBindingSource.DataSource = typeof(DataAccess.Branch);
            // 
            // cbEnableShifUser
            // 
            this.cbEnableShifUser.EditValue = true;
            this.cbEnableShifUser.Location = new System.Drawing.Point(203, 66);
            this.cbEnableShifUser.Name = "cbEnableShifUser";
            this.cbEnableShifUser.Properties.Caption = "الموظف";
            this.cbEnableShifUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbEnableShifUser.Size = new System.Drawing.Size(90, 19);
            this.cbEnableShifUser.TabIndex = 52;
            this.cbEnableShifUser.CheckedChanged += new System.EventHandler(this.cbEnableShifUser_CheckedChanged);
            // 
            // UserPaymentReportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 305);
            this.Controls.Add(this.cbEnableShifUser);
            this.Controls.Add(this.cmbUsersRPT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.cmbTo);
            this.Name = "UserPaymentReportOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خيارات تقرير منصرفات / إيرادات لموظف ";
            this.Load += new System.EventHandler(this.StockReportOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsersRPT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableShifUser.Properties)).EndInit();
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
        private DevExpress.XtraEditors.CheckEdit cbEnableShifUser;
    }
}
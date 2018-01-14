namespace WinForm.Reports
{
    partial class ShiftSummaryReportOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDate = new DevExpress.XtraEditors.DateEdit();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnShowReport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "التاريخ";
            // 
            // cmbDate
            // 
            this.cmbDate.EditValue = new System.DateTime(2015, 6, 23, 18, 3, 41, 527);
            this.cmbDate.Location = new System.Drawing.Point(87, 87);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDate.Size = new System.Drawing.Size(139, 20);
            this.cmbDate.TabIndex = 1;
            // 
            // branchBindingSource
            // 
            this.branchBindingSource.DataSource = typeof(DataAccess.Branch);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnShowReport.Appearance.Options.UseFont = true;
            this.btnShowReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnShowReport.ImageOptions.Image = global::RedaPOS.Properties.Resources.Reports_icon;
            this.btnShowReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnShowReport.Location = new System.Drawing.Point(0, 230);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(333, 75);
            this.btnShowReport.TabIndex = 0;
            this.btnShowReport.Text = "عرض التقرير";
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // ShiftSummaryReportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 305);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.cmbDate);
            this.Name = "ShiftSummaryReportOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خيارات تقرير الملخص المالي اليومي";
            this.Load += new System.EventHandler(this.SaleSummaryReportOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnShowReport;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit cmbDate;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource branchBindingSource;
    }
}
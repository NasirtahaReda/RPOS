namespace WinForm.Reports
{
    partial class StockReportOptions
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
            this.txtReorderPoint = new DevExpress.XtraEditors.SpinEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.rgSortDirection = new DevExpress.XtraEditors.RadioGroup();
            this.rgSortBy = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btnShowReport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderPoint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSortDirection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSortBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReorderPoint
            // 
            this.txtReorderPoint.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtReorderPoint.Location = new System.Drawing.Point(20, 29);
            this.txtReorderPoint.Name = "txtReorderPoint";
            this.txtReorderPoint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtReorderPoint.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtReorderPoint.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtReorderPoint.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtReorderPoint.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtReorderPoint.Size = new System.Drawing.Size(111, 20);
            this.txtReorderPoint.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "الكميات أقل من ";
            // 
            // rgSortDirection
            // 
            this.rgSortDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgSortDirection.EditValue = "0";
            this.rgSortDirection.Location = new System.Drawing.Point(2, 47);
            this.rgSortDirection.Name = "rgSortDirection";
            this.rgSortDirection.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgSortDirection.Properties.Appearance.Options.UseBackColor = true;
            this.rgSortDirection.Properties.Appearance.Options.UseTextOptions = true;
            this.rgSortDirection.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rgSortDirection.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgSortDirection.Properties.Columns = 2;
            this.rgSortDirection.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rgSortDirection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "تنازلي"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", " تصاعدي")});
            this.rgSortDirection.Size = new System.Drawing.Size(274, 32);
            this.rgSortDirection.TabIndex = 5;
            // 
            // rgSortBy
            // 
            this.rgSortBy.Dock = System.Windows.Forms.DockStyle.Top;
            this.rgSortBy.EditValue = "0";
            this.rgSortBy.Location = new System.Drawing.Point(2, 21);
            this.rgSortBy.Name = "rgSortBy";
            this.rgSortBy.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgSortBy.Properties.Appearance.Options.UseBackColor = true;
            this.rgSortBy.Properties.Appearance.Options.UseTextOptions = true;
            this.rgSortBy.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rgSortBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgSortBy.Properties.Columns = 2;
            this.rgSortBy.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rgSortBy.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "بالكمية"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "بالإسم")});
            this.rgSortBy.Size = new System.Drawing.Size(274, 26);
            this.rgSortBy.TabIndex = 6;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControl1.Controls.Add(this.rgSortDirection);
            this.groupControl1.Controls.Add(this.rgSortBy);
            this.groupControl1.Location = new System.Drawing.Point(1, 72);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(278, 81);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "ترتيب";
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
            this.btnShowReport.Size = new System.Drawing.Size(276, 75);
            this.btnShowReport.TabIndex = 0;
            this.btnShowReport.Text = "عرض التقرير";
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // StockReportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 305);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.txtReorderPoint);
            this.Name = "StockReportOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خيارات تقرير المخزن";
            this.Load += new System.EventHandler(this.StockReportOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderPoint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSortDirection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSortBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnShowReport;
        private DevExpress.XtraEditors.SpinEdit txtReorderPoint;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.RadioGroup rgSortDirection;
        private DevExpress.XtraEditors.RadioGroup rgSortBy;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
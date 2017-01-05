namespace WinForm
{
    partial class TestForm
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
            this.txtTo = new DevExpress.XtraEditors.TextEdit();
            this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSendImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vwInventoryCompareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.btnShowFullReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestException = new DevExpress.XtraEditors.SimpleButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReorderItem = new System.Windows.Forms.Button();
            this.lblMarquee = new WinForm.MarqueeLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwInventoryCompareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTo
            // 
            this.txtTo.EditValue = "00249919400092";
            this.txtTo.Location = new System.Drawing.Point(68, 33);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(187, 20);
            this.txtTo.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.EditValue = "00249919400092";
            this.txtMessage.Location = new System.Drawing.Point(68, 70);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(187, 82);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(87, 187);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSendImage
            // 
            this.btnSendImage.Location = new System.Drawing.Point(180, 187);
            this.btnSendImage.Name = "btnSendImage";
            this.btnSendImage.Size = new System.Drawing.Size(75, 23);
            this.btnSendImage.TabIndex = 4;
            this.btnSendImage.Text = "Send Image";
            this.btnSendImage.UseVisualStyleBackColor = true;
            this.btnSendImage.Click += new System.EventHandler(this.btnSendImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DataAccess.vw_Inventory);
            // 
            // branchBindingSource
            // 
            this.branchBindingSource.DataSource = typeof(DataAccess.Branch);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xtraTabControl1.Location = new System.Drawing.Point(493, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(603, 457);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.xtraTabControl1_SelectedPageChanging);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(597, 429);
            this.xtraTabPage1.Tag = "=";
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(597, 429);
            this.xtraTabPage2.Tag = "+";
            this.xtraTabPage2.Text = "+";
            // 
            // btnShowFullReport
            // 
            this.btnShowFullReport.Location = new System.Drawing.Point(86, 292);
            this.btnShowFullReport.Name = "btnShowFullReport";
            this.btnShowFullReport.Size = new System.Drawing.Size(120, 40);
            this.btnShowFullReport.TabIndex = 7;
            this.btnShowFullReport.Text = "Show Report";
            this.btnShowFullReport.Click += new System.EventHandler(this.btnShowFullReport_Click);
            // 
            // btnTestException
            // 
            this.btnTestException.Location = new System.Drawing.Point(300, 215);
            this.btnTestException.Name = "btnTestException";
            this.btnTestException.Size = new System.Drawing.Size(120, 40);
            this.btnTestException.TabIndex = 7;
            this.btnTestException.Text = "Show Report";
            this.btnTestException.Click += new System.EventHandler(this.btnTestException_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(261, 36);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Send Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReorderItem
            // 
            this.btnReorderItem.Location = new System.Drawing.Point(300, 337);
            this.btnReorderItem.Name = "btnReorderItem";
            this.btnReorderItem.Size = new System.Drawing.Size(130, 31);
            this.btnReorderItem.TabIndex = 10;
            this.btnReorderItem.Text = "From Server to local";
            this.btnReorderItem.UseVisualStyleBackColor = true;
            this.btnReorderItem.Click += new System.EventHandler(this.btnReorderItem_Click);
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.Location = new System.Drawing.Point(220, 9);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.RTL = false;
            this.lblMarquee.Size = new System.Drawing.Size(92, 17);
            this.lblMarquee.TabIndex = 11;
            this.lblMarquee.Text = "السلام عليكم ورحمة الله";
            this.lblMarquee.UseCompatibleTextRendering = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 457);
            this.Controls.Add(this.lblMarquee);
            this.Controls.Add(this.btnReorderItem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnTestException);
            this.Controls.Add(this.btnShowFullReport);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnSendImage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtMessage);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwInventoryCompareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource branchBindingSource;
        private System.Windows.Forms.BindingSource vwInventoryCompareBindingSource;
        private DevExpress.XtraEditors.TextEdit txtTo;
        private DevExpress.XtraEditors.MemoEdit txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSendImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SimpleButton btnShowFullReport;
        private DevExpress.XtraEditors.SimpleButton btnTestException;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReorderItem;
        private MarqueeLabel lblMarquee;
    }
}
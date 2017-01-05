namespace WinForm.Reports
{
    partial class UserLoginOptions
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
            this.listBoxUsers = new DevExpress.XtraEditors.ListBoxControl();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLginTime = new System.Windows.Forms.Label();
            this.lblLogoutTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.DataSource = this.userBindingSource;
            this.listBoxUsers.DisplayMember = "UserName";
            this.listBoxUsers.Location = new System.Drawing.Point(249, 35);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(178, 180);
            this.listBoxUsers.TabIndex = 1;
            this.listBoxUsers.ValueMember = "ID";
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(DataAccess.User);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "التاريخ";
            // 
            // cmbDate
            // 
            this.cmbDate.EditValue = new System.DateTime(2015, 6, 23, 18, 3, 41, 527);
            this.cmbDate.Location = new System.Drawing.Point(249, 9);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDate.Size = new System.Drawing.Size(139, 20);
            this.cmbDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "الدخول";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "الخروج";
            // 
            // lblLginTime
            // 
            this.lblLginTime.AutoSize = true;
            this.lblLginTime.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblLginTime.Location = new System.Drawing.Point(38, 54);
            this.lblLginTime.Name = "lblLginTime";
            this.lblLginTime.Size = new System.Drawing.Size(70, 22);
            this.lblLginTime.TabIndex = 4;
            this.lblLginTime.Text = "الدخول";
            // 
            // lblLogoutTime
            // 
            this.lblLogoutTime.AutoSize = true;
            this.lblLogoutTime.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblLogoutTime.Location = new System.Drawing.Point(38, 120);
            this.lblLogoutTime.Name = "lblLogoutTime";
            this.lblLogoutTime.Size = new System.Drawing.Size(68, 22);
            this.lblLogoutTime.TabIndex = 4;
            this.lblLogoutTime.Text = "الخروج";
            // 
            // UserLoginOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 229);
            this.Controls.Add(this.lblLogoutTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLginTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDate);
            this.Controls.Add(this.listBoxUsers);
            this.Name = "UserLoginOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "زمن الدخول والخروج";
            this.Load += new System.EventHandler(this.UserLoginOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.ListBoxControl listBoxUsers;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit cmbDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLginTime;
        private System.Windows.Forms.Label lblLogoutTime;
    }
}
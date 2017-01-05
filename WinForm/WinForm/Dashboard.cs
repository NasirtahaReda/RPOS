using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using WinForm.Reports;
using DevExpress.XtraReports.UI;
using System.Diagnostics;
using System.Threading;
using System.Net.Mail;
using System.Net;
using DevExpress.LookAndFeel;
using MsgBox;
using RedaPOS;

namespace WinForm
{
  
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {
        bool normalLogout = false;
        int BranchID = 0;
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                BranchID = Convert.ToInt32(UserData.Default.BranchID);
                branchBindingSource.DataSource = db.Branches.ToList();
                var branch = db.Branches.Where(s => s.ID == BranchID).SingleOrDefault();
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute assembly = executingAssembly.GetCustomAttribute<AssemblyTitleAttribute>();
                AssemblyFileVersionAttribute assemblyVersion = executingAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
                

                this.Text = assembly.Title + " " + assemblyVersion.Version + " ( " + UserData.Default.UserName + " ) - "+branch.BranchName;

                var users = from s in db.Users where s.IsEnable == true select s;
                userBindingSource.DataSource = users.ToList();
                cmbUsers.EditValue = 1;

                cmbSaleInvoiceDateFrom.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
               // cmbSaleInvoiceDateTo.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59); 
                new SaleInvoiceForm(new DataAccess.SaleInvoice(), true, SaleInvoiceType.Sale).Show();
                

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                
            }
        }

        private void btnNewSaleInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                new SaleInvoiceForm(new DataAccess.SaleInvoice(), true, SaleInvoiceType.Sale).Show();
                FillSaleInvoiceGrid();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnSaleInvoiceSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //vwSaleReportBindingSource.DataSource = null;
                lblIncomeInvoice.Text ="0";
                lblNoOfSaleInvoices.Text = "0"; 

                int ID = Convert.ToInt32(txtSaleInvoiceID.EditValue);
                var list = from s in db.vw_SaleReport where s.ID == ID && s.BranchID == BranchID select s;
                vwSaleReportBindingSource.DataSource = list.ToList();
                gridViewSaleInvoice.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void cmbSaleInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
           
        }
        void FillSaleInvoiceGrid()
        {
            try
            {
                lblIncomeInvoice.Text = "";
                lblNoOfSaleInvoices.Text = ""; 
                int userID = Convert.ToInt32(cmbUsers.GetColumnValue("ID"));

                DateTime date = cmbSaleInvoiceDateFrom.DateTime;
                DateTime start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                DateTime end = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
               
             // var list = from s in db.vw_SaleReport where s.Date > start && s.Date < end && s.Flag != 0 select s;
                var list = from s in db.vw_SaleReport where s.Flag != 0 && s.UserID == userID && s.Date > start && s.Date < end && s.BranchID == BranchID select s;
                vwSaleReportBindingSource.DataSource = list.ToList();
                gridViewSaleInvoice.ExpandAllGroups();


             
                decimal? totalOfSale = (from s in list select s.Total).Sum();
                int noOfInvoices = (from s in list where s.Flag == 1 select s.Total).Count();
                lblIncomeInvoice.Text = totalOfSale != null ? totalOfSale.ToString() : "0";
                lblNoOfSaleInvoices.Text = noOfInvoices != null ? noOfInvoices.ToString() : "0";
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

            
        }

        private void repositoryItemButtonEditSaleInvoice_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.OK)
                {
                    var currentRow = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                    SaleRpt rpt = new SaleRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), 0, 0, currentRow.ID.ToString(), currentRow.UserName.ToString());
                    var list = from s in db.vw_Sale2 where s.SaleInvoiceID == currentRow.ID select s;
                    rpt.DataSource = list.ToList();


                    try
                    {
                        ////string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                        ReportPrintTool tool = new ReportPrintTool(rpt);
                        tool.ShowPreview();
                    }
                    catch (Exception ex)
                    {
                         ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                    }
                }
                else
                    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
                    {
                        var currentRow = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                        if (currentRow.Flag == 1)
                        {
                       //     if (MessageBox.Show("هل أنت متأكد من إرجاع الفاتور؟", "إرجاع الفاتور", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                var row = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                                SaleRpt rpt = new SaleRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), 0, 0, currentRow.ID.ToString(), currentRow.UserName.ToString());
                                var list = db.vw_Sale2.Where(s => s.SaleInvoiceID == row.ID).ToList<DataAccess.vw_Sale2>();
                                new ReturnForm(list,currentRow.ID).ShowDialog();
                                FillSaleInvoiceGrid();

                                ////DataAccess.SaleInvoice invoice = db.SaleInvoices.Where(s => s.ID == currentRow.ID).SingleOrDefault();
                                ////invoice.Flag = 2;
                                ////DataAccess.Inventory inv;
                                ////foreach (var item in invoice.SaleInvoiceDetails)
                                ////{
                                ////   // item.SaleInvoiceID = invoice.ID;
                                ////   /// invoice.SaleInvoiceDetails.Add(item);

                                ////    inv = db.Inventories.Where(s => s.ID == item.InventoryID).SingleOrDefault();
                                ////    inv.CurrentQuanity += item.Quanitity;
                                ////}
                                //if (db.SaveChanges() > 0)
                                //{
                                //    MessageBox.Show("تم ارجاع الفاتوره");
                                //}
                            }
                        }
                        else
                        {
                            MessageBox.Show("لا يمكن ارجاع الفاتوره");
                        }
                    }
                    else
                        if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                        {
                            var currentRow = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                            if (currentRow!= null)
                            {
                                var row = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                                SaleRpt rpt = new SaleRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), 0, 0, currentRow.ID.ToString(), currentRow.UserName.ToString());
                                var list = db.vw_Sale2.Where(s => s.SaleInvoiceID == row.ID).ToList<DataAccess.vw_Sale2>();
                              

                                rpt.DataSource = list.ToList();
                                ReportPrintTool tool = new ReportPrintTool(rpt);

                                string InvoicePrinter = db.Companies.Take(1).SingleOrDefault().InvoicePrinter; // System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                                if (InvoicePrinter == "")
                                {
                                    tool.Print();
                                }
                                else
                                {
                                    tool.Print(InvoicePrinter);
                                }                                
                            }
                          
                        }

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void gridViewSaleInvoice_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
            switch(info.EditValue.ToString())
            {
                case "0":
                    info.GroupText = "فواتير غير مؤكدة";
                    break;

                case "1":
                    info.GroupText = "فواتير  مؤكدة";
                    break;


                case "2":
                    info.GroupText = "فواتير راجعه ";
                    break;

            }
                // string.Format(view.GroupFormat, info.Column.Caption, info.EditValue, s);
   
        }

        private void txtReorderPoint_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbSaleSummary_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
               //// int userID = Convert.ToInt32(cmbUsers.GetColumnValue("ID"));
               //// DateTime date = cmbSaleSummary.DateTime;

               //// DateTime start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
               ////DateTime end = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

               //// var list = from s in db.vw_SaleReport where s.Flag == 1 &&  s.UserID == userID && s.Date> start && s.Date < end select s;
               //// decimal? totalOfSale = (from s in list select s.Total).Sum();
               //// int noOfInvoices = (from s in list where s.Flag==1 select s.Total).Count();
               //// lblIncomeInvoice.Text = totalOfSale != null ? totalOfSale.ToString() : "0";
               //// lblNoOfSaleInvoices.Text = noOfInvoices !=null? noOfInvoices.ToString() : "0";

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnShowReorderItems_Click(object sender, EventArgs e)
        {
            try
            {
                int ReorderPoint = Convert.ToInt32(txtReorderPoint.EditValue);
                //vwInventoryBindingSource.DataSource = null;
                var list = from s in db.vw_Inventory where s.CurrentQuanity < ReorderPoint && s.BranchID == BranchID select s;
                ReorderRPT rpt = new ReorderRPT( ReorderPoint.ToString());
                rpt.DataSource = list.ToList();
                try
                {
                    //string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                    ReportPrintTool tool = new ReportPrintTool(rpt);
                    tool.ShowPreview(); //Print(InvoicePrinter);//
                }
                catch (Exception ex)
                {
                     ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }

        private void btnMainForm_Click(object sender, EventArgs e)
        {
            new MainScreen().Show();
        }

        private void btnShowCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = null;
                if (p == null)
                {
                    p = new Process();
                    p.StartInfo.FileName = "Calc.exe";
                    p.Start();

                }
                else
                {
                    p.Close();
                    p.Dispose();

                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                new ChangePassword().Show();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("خروج من النظام؟", "نظام رضا بوكشوب", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int userID= Convert.ToInt32(UserData.Default.UserID);
                DataAccess.UserLogin login = db.UserLogins.Where(s => s.UserID == userID).LastOrDefault();
                login.LogOut = DateTime.Now;
                if (db.SaveChanges() > 0)
                {
                    this.Hide();
                    new Login().ShowDialog();
                }
                ////normalLogout = true;
                ////try
                ////{
                ////    Thread thread = new Thread(() => SendEmail(login, db.Users.Where(s => s.ID == login.UserID).SingleOrDefault()));
                ////    thread.Start();
                ////}
                ////catch (Exception ex)
                ////{
                ////    //Do nothing 
                ////}
                //////Shared.SendEmail(login,db.Users.Where(s=>s.ID ==  login.UserID).SingleOrDefault());
               
            }
        }
        public void SendEmail(DataAccess.UserLogin login, DataAccess.User ValidUser)
        {
            ////string smtpAddress = "smtp.gmail.com";
            ////// int portNumber = 587;
            ////bool enableSSL = true;
            ////string emailFrom = "redasudani@gmail.com";
            ////string password = "gqaz1tahaz";
            ////string emailTo = "NasirTaha@gmail.com";
            ////string subject = "Reda 1";
            ////string body = "";
            ////string pc = System.Environment.MachineName;
            ////if (login.Type)//Login Out
            ////{
            ////    body = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " :خروج" + "  Reda "+UserData.Default.BranchID +"  "+ pc;
            ////}
            ////else//Login In
            ////{
            ////    body = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " : دخول" + " Reda " + UserData.Default.BranchID + "  " + pc;
            ////}
            ////using (MailMessage mail = new MailMessage())
            ////{
            ////    mail.From = new MailAddress(emailFrom);
            ////    mail.To.Add(emailTo);
            ////    mail.To.Add("sheble233@gmail.com");
            ////    mail.Subject = body;
            ////    mail.Body = body;
            ////    mail.IsBodyHtml = true;

            ////    using (SmtpClient smtp = new SmtpClient(smtpAddress))//, portNumber))
            ////    {
            ////        try
            ////        {
            ////            #if !DEBUG
            ////                smtp.UseDefaultCredentials = false;
            ////                smtp.Credentials = new NetworkCredential(emailFrom, password);
            ////                smtp.EnableSsl = enableSSL;
            ////                smtp.Send(mail);
            ////            #endif
            ////        }
            ////        catch (Exception ex)
            ////        {
            ////            //Do nothing 
            ////        }
            ////    }
            ////}
        }
        private void btnStockReport_Click(object sender, EventArgs e)
        {
            string password = Prompt.ShowDialog("كلمة المرور:", "شاشة مخصصة");
            if (password.ToLower() == "1qaz")
            {
                new StockReportOptions().Show();
            }
        }

        private void btnSaleSummaryReport_Click(object sender, EventArgs e)
        {
            try
            {
                new Reports.SaleSummaryReportOptions().Show();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!normalLogout)
                {
                    //DataAccess.UserLogin login = db.UserLogins.Create();
                    //login.Date = DateTime.Now;
                    //login.UserID = Convert.ToInt32(UserData.Default.UserID);
                    //login.Type = true;//Login Out
                    //login.BranchID = BranchID;
                    //db.UserLogins.Add(login);
                    //if (db.SaveChanges() > 0)
                    //{

                    //}
                    //try
                    //{
                    //    Thread thread = new Thread(() => SendEmail(login, db.Users.Where(s => s.ID == login.UserID).SingleOrDefault()));
                    //    thread.Start();
                    //}
                    //catch (Exception ex)
                    //{
                    //    //Do nothing 
                    //}
                    //Shared.SendEmail(login, db.Users.Where(s => s.ID == login.UserID).SingleOrDefault());
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
               
            }
        }

        private void btnShowUserLogin_Click(object sender, EventArgs e)
        {
            new UserLoginOptions().Show();
        }

        private void btnShowSaleInvoice_Click(object sender, EventArgs e)
        {
            FillSaleInvoiceGrid();
        }

        private void txtSaleInvoiceID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbUsers_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnShowExpire_Click(object sender, EventArgs e)
        {
            try
            {
                int ReorderPoint = Convert.ToInt32(txtReorderPoint.EditValue);
                vwInventoryBindingSource.DataSource = null;

                var list = from s in db.vw_Inventory where s.CurrentQuanity < ReorderPoint  select s;
                vwInventoryBindingSource.DataSource = list.ToList();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            try
            {
                string password = Prompt.ShowDialog("كلمة المرور:", "شاشة مخصصة");       
                   if (password.ToLower() == "1qaz")
                    {
                        XtraForm frm = new XtraForm();
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Controls.Add(new ItemUC());
                        frm.Controls[0].Dock = DockStyle.Fill;
                        frm.Show();
                    }

               
            }
            catch(Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnShowPurchaseInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                string password = Prompt.ShowDialog("كلمة المرور:", "شاشة مخصصة");
                if (password.ToLower() == "1qaz")
                {
                    XtraForm frm = new XtraForm();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Controls.Add(new PurchaseInvoiceUC());
                    frm.Controls[0].Dock = DockStyle.Fill;
                    int branchId = Convert.ToInt32(UserData.Default.BranchID);
                    frm.Text = "فواتير المشتروات لفرع:" + db.Branches.Where(s => s.ID == branchId).Select(s => s.BranchName).SingleOrDefault();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnItemCategory_Click(object sender, EventArgs e)
        {
            try
            {
                XtraForm frm = new XtraForm();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.Controls.Add(new GategoryUC());
                frm.Controls[0].Dock = DockStyle.Fill;
                frm.Show();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                new Transfer().ShowDialog();
                
                FillSaleInvoiceGrid();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

      

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pivotGridControl1_FieldValueDisplayText(object sender, DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs e)
        {
            if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)
                e.DisplayText = "المجموع"; 
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter && txtSearch.Text.Length > 2)
                {
                    string query = txtSearch.Text;
                    int ReorderPoint = Convert.ToInt32(txtReorderPoint.EditValue);
                    var list = from s in db.vw_Inventory where s.Name.Contains(query) select s;
                    vwInventoryBindingSource.DataSource = list.ToList();
                }
                else
                {
                    vwInventoryBindingSource.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtSaleInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {

                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            try
            {

                ExpensesForm frm = new ExpensesForm();
                frm.Show();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.RightToLeft = RightToLeft.Yes;
            prompt.RightToLeftLayout = true;
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.RightToLeft = RightToLeft.Yes;

            textBox.PasswordChar = '#';
            Button confirmation = new Button() { Text = "دخول", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
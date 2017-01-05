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
using WhatsAppApi;
using RedaPOS;
using System.IO;
using DevExpress.XtraTab;
using DataAccess;
using WinForm.Reports;
using DevExpress.XtraReports.UI;
using System.Net;
using System.Collections.Specialized;
//using RedaPOS.Database;
using AutoMapper;
//using Utilities;

namespace WinForm
{
    public static class IgnoreVirtualExtensions
    {
        public static IMappingExpression<TSource, TDestination>
               IgnoreAllVirtual<TSource, TDestination>(
                   this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p =>
                                     p.GetGetMethod().IsVirtual))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }
    }
    public partial class TestForm : Form
    {

        DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
        List<DataAccess.Item> items ;//= db.Items.ToList();
        int pageIndex = 1;
        public TestForm()
        {
            InitializeComponent();
           // items = db.Items.ToList();
         
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            try
            {
               
                //UserData.Default.BranchID = "1";
                //UserData.Default.Save();
               
                //SaleInvoiceForm_Tab saleTab = new SaleInvoiceForm_Tab(db, items, new DataAccess.SaleInvoice(), true, SaleInvoiceType.Sale);
               
                //xtraTabPage1.Controls.Add(saleTab);
                //xtraTabPage1.Text = "فاتورة " + pageIndex++;
                //xtraTabPage1.Controls[0].Dock = DockStyle.Fill;
                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        bool SendPushMessage(string message)
        {
            bool result = false;
            try
            {
                var parameters = new NameValueCollection {
                    { "token", "anjmqq85namq52cjz8raa31crjftec" },
                    { "user", "ubgh4udoa6jipcspgkiyaf6s44fgmx" },
                    { "message", message }
            };

                using (var client = new WebClient())
                {
                    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
            return result;
        }
        private void btnShowExpire_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
          //  if (PushMessage.SendPush_Message(txtTo.Text, txtMessage.Text, "تجربة"))
          //{
          //    MessageBox.Show("sent");
          //}
          //else
          //{
          //    MessageBox.Show("not sent");
          //}
        }

        bool SendWhatsAppMessage(String receiver, String Message)
        {
            bool result = false;
            try
            {
                
                //Send ( button_click )

                DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
                DataAccess.Company company = db.Companies.Take(1).SingleOrDefault();

                string WhatsAppCode = company.WhatsAppCode;// UserData.Default.WhatsAppCode;
                string WhatsAppSender = company.WhatsAppSender;// UserData.Default.WhatsAppSender;

          

               string from = WhatsAppSender;
               string to = receiver;
               string msg = Message;

                WhatsApp wa = new WhatsApp(from, WhatsAppCode, "RedaPos", false, true);

                wa.OnConnectSuccess += () =>
                {
                    //   MessageBox.Show("Connected to whatsapp...");

                    wa.OnLoginSuccess += (phoneNumber, data) =>
                    {
                        wa.SendMessage(to, msg);
                        result = true;
                    };

                    wa.OnLoginFailed += (data) =>
                    {
                        MessageBox.Show("Login Failed : {0}", data);
                        result = false;
                    };

                    wa.Login();
                };

                wa.OnConnectFailed += (ex) =>
                {
                    MessageBox.Show("Connection Failed...");
                    result = false;
                };

                wa.Connect();

            }
            catch (Exception ex2)
            {
                
                result = false;
            }

            return result;
        }

        private void btnLogException_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
             
            }
        }

        // <previewPanel>
        void OnPreviewPanelMouseEnter(object sender, EventArgs e)
        {
            EnsureShowBeakForm();
        }
        void EnsureShowBeakForm()
        {
           
        }
        ////Point GetHotPoint()
        ////{
        ////    Point pt = new Point(this.previewPanel.Width / 2, 0);
        ////  //  if (this.cbeBeakLocation.EditValue.Equals(BeakPanelBeakLocation.Top))
        ////    {
        ////        pt.Y += this.previewPanel.Height;
        ////    }
        ////    return this.previewPanel.PointToScreen(pt);
        ////}

        private void flyoutPanel1_ButtonClick(object sender, DevExpress.Utils.FlyoutPanelButtonClickEventArgs e)
        {
            string tag = e.Button.Tag as string;
            if (string.Equals(tag, "Exit", StringComparison.OrdinalIgnoreCase))
            {
                ////this.flyoutPanel1.HideBeakForm();
            }
        }

        private void btnSendImage_Click(object sender, EventArgs e)
        {


           
             
            
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if(e.Page.Tag.ToString() == "+")
            {
                SaleInvoiceForm_Tab saleTab = new SaleInvoiceForm_Tab(db, items, new DataAccess.SaleInvoice(), true, SaleInvoiceType.Sale);
                
                e.Page.Controls.Add(saleTab);
                e.Page.Controls[0].Dock = DockStyle.Fill;
                
                e.Page.Tag = "-";
                e.Page.Text = "فاتورة " + pageIndex++;
                XtraTabPage newTab = new XtraTabPage();
                newTab.Tag = "+";
                newTab.Text = "+";
                xtraTabControl1.TabPages.Add(newTab);
            }
        }

        private void btnShowFullReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
                int invoiceID = 123;

                var currentRow = db.vw_SaleReport.Where(s => s.ID == invoiceID).SingleOrDefault(); //(DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                SaleAllRpt rpt = new SaleAllRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), currentRow.ID.ToString(), currentRow.UserName.ToString());
                var list = from s in db.vw_Sale2 where s.SaleInvoiceID == invoiceID select s;
                rpt.DataSource = list.ToList();


                try
                {
                    //  string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                    ReportPrintTool tool = new ReportPrintTool(rpt);
                    tool.ShowPreview();
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

        private void btnTestException_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("An unexpected error occurred. Please call Helpdesk.", new DivideByZeroException("Divid zero value"));
            }
            catch (Exception ex)
            {
                Dictionary<string, string> additionalData = new Dictionary<string, string>();
                additionalData.Add("AdvancedInformation.FileName", "ExceptionMessageBoxSample.dll");
              ModuleClass.ShowExceptionMessage(this,ex, "title", null);//, null);//additionalData);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //PushMessage.SendPushMessage(txtMessage.Text, txtTo.Text);
                //SendPushMessage(txtMessage.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void btnReorderItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = SychronizseTolocal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool SychronizseTolocal()
        {
            bool flag = true;
            RedaPOS.Database.localDBEntities local_db = new RedaPOS.Database.localDBEntities();
            var list = db.Branches.ToList();
            
            //config automapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DataAccess.Branch, RedaPOS.Database.Branch>().IgnoreAllVirtual());
            var mapper = config.CreateMapper();

            RedaPOS.Database.Branch branch = null;
            foreach (DataAccess.Branch item in list)
            {
                branch = mapper.Map<RedaPOS.Database.Branch>(item);
                local_db.Branches.Add(branch);
            }
            if(local_db.SaveChanges()> 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            return flag;
        }
    }
}
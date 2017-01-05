﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;

using DevExpress.XtraEditors;
using WinForm.Reports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Windows.Input;
using System.Globalization;
using DevExpress.XtraPivotGrid;
using System.Configuration;
using System.Diagnostics;
using System.Media;
using System.Data.Linq;
using System.Threading;
using System.Net.Mail;
using System.Net;
using RedaPOS;
using System.Reflection;
using WhatsAppApi;
using WhatsAppApi.Helper;
using WhatsAppApi.Account;
using WhatsAppApi.Response;
using System.IO; 

namespace WinForm
{
    public enum SaleInvoiceType
    {
        Sale =1,
        Transfer = 2,
        Expire = 3
    }
    public partial class SaleInvoiceForm : DevExpress.XtraEditors.XtraForm
    {
        bool refreshFastItem = false;
        int branchID = 0;

        private DataAccess.SaleInvoice invoice;
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        BindingList<DataAccess.SaleInvoiceDetail> details = null;
        //bool _Transfer = false;
        int _trnasferFrom;
        int _trnasferTo;
        SaleInvoiceType _saleInvoiceType;

        bool normalLogout = false;
        WhatsApp wa = null;
        Encoding tmpEncoding = Encoding.UTF8;
            string nickname = "WhatsApiNet";
            string sender = "249912313059"; // Mobile number with country code (but without + or 00)
            string password = "lyrHVvFrk2rw+vt8VpGmykPJizw=";//v2 password
            string target = "00249919400092";// Mobile number to send the message to
        ////public SaleInvoiceForm()
        ////{
        ////    InitializeComponent();
        ////    branchID = Convert.ToInt32(UserData.Default.BranchID);
           
        ////}

        public SaleInvoiceForm(DataAccess.SaleInvoice invoice, bool isNew, SaleInvoiceType saleInvoiceType, int trnasferFrom = 1, int trnasferTo = 2)
        {
            InitializeComponent();
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyTitleAttribute assembly = executingAssembly.GetCustomAttribute<AssemblyTitleAttribute>();
            AssemblyFileVersionAttribute assemblyVersion = executingAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            string title = assembly.Title + " " + assemblyVersion.Version + " ( " + UserData.Default.UserName + " ) ";// +branch.BranchName;

            _saleInvoiceType = saleInvoiceType;
          //  _Transfer = Transfer;
            _trnasferFrom = trnasferFrom;
            _trnasferTo = trnasferTo;
            branchID = Convert.ToInt32(UserData.Default.BranchID);

            bindingSourceNoVisibleItems.DataSource = db.vw_Inventory.Where(s => s.BarcodeText.StartsWith("0000") && s.BranchID == branchID).ToList();
            
            if(saleInvoiceType == SaleInvoiceType.Transfer)
            {
                var from = db.Branches.Where(s => s.ID == _trnasferFrom).SingleOrDefault();
                var to = db.Branches.Where(s => s.ID == _trnasferTo).SingleOrDefault();
                branchID = trnasferFrom;
                this.Text = "التحويل من " + from.BranchName + "  الي "+ to.BranchName;
              
            }
            else
                if (saleInvoiceType == SaleInvoiceType.Sale)
            {
                int branchId = Convert.ToInt32(UserData.Default.BranchID);
                this.Text = "فاتورة بيع - :" + db.Branches.Where(s => s.ID == branchId).Select(s => s.BranchName).SingleOrDefault()+ " - " + title;
               
            }
            if (saleInvoiceType == SaleInvoiceType.Expire)
            {
                int branchId = Convert.ToInt32(UserData.Default.BranchID);
                this.Text = "فاتورة تالف - :" + db.Branches.Where(s => s.ID == branchId).Select(s => s.BranchName).SingleOrDefault();

            }
           
            bindingSourceTempItems.DataSource = db.vw_TempItem.Where(s => s.BranchID == branchID).ToList() ;// db.vw_TempItem.Local.ToBindingList();
            
            

            if (isNew)
            {
               

                //details = invoice.SaleInvoiceDetails;


            }
            ////this.invoice = invoice;
           ///// this.bindingSourceSaleInvoice.DataSource = this.invoice;


            //db.SaleInvoiceDetails.Where(s => s.SaleInvoiceID == invoice.ID).Load();
            details = new BindingList<DataAccess.SaleInvoiceDetail>();
            ////details = db.SaleInvoiceDetails.Local.ToBindingList(); 

            this.bindingSourceSaleInvoiceDetails.DataSource = details;
            this.bindingSourceItem.DataSource = db.Items.ToList();

            //if invoice was closed
            ////if (this.invoice.Flag == 1)
            ////{
            var users = from s in db.Users /*where s.IsAdmin == false*/ select s;
            userBindingSource.DataSource = users.ToList();
            cmbUsers.EditValue =Convert.ToInt32(UserData.Default.UserID);
              

            ////}
            ////else if (this.invoice.Flag == 0)
            ////{
            ////    this.Text = this.invoice.ID.ToString();
            ////}

        }

        private void SaleInvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                cmbDate.DateTime = DateTime.Now;
                dockPanelReport.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                dockPanelOperations.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
#if DEBUG
                dockPanelReport.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                dockPanelOperations.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;          
#endif
               
                if(_saleInvoiceType != SaleInvoiceType.Sale)
                {
                    dockPanelReport.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                    dockPanelOperations.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                }

                //SetupWhatsApp();
            
              
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        #region WhatsApp
        private  void SetupWhatsApp()
        {
            

            wa = new WhatsApp(sender, password, nickname, true);
            System.Console.OutputEncoding = Encoding.Default;
            System.Console.InputEncoding = Encoding.Default;

            WhatsUserManager usrMan = new WhatsUserManager();
            var tmpUser = usrMan.CreateUser(target, "User");
            wa.SendMessage(tmpUser.GetFullJid(), "line");
            //event bindings
            wa.OnLoginSuccess += wa_OnLoginSuccess;
            wa.OnLoginFailed += wa_OnLoginFailed;
            wa.OnGetMessage += wa_OnGetMessage;
            ////wa.OnGetMessageReceivedClient += wa_OnGetMessageReceivedClient;
            ////wa.OnGetMessageReceivedServer += wa_OnGetMessageReceivedServer;
            wa.OnNotificationPicture += wa_OnNotificationPicture;
            wa.OnGetPresence += wa_OnGetPresence;
            wa.OnGetGroupParticipants += wa_OnGetGroupParticipants;
            wa.OnGetLastSeen += wa_OnGetLastSeen;
            wa.OnGetTyping += wa_OnGetTyping;
            wa.OnGetPaused += wa_OnGetPaused;
            wa.OnGetMessageImage += wa_OnGetMessageImage;
            wa.OnGetMessageAudio += wa_OnGetMessageAudio;
            wa.OnGetMessageVideo += wa_OnGetMessageVideo;
            wa.OnGetMessageLocation += wa_OnGetMessageLocation;
            wa.OnGetMessageVcard += wa_OnGetMessageVcard;
            wa.OnGetPhoto += wa_OnGetPhoto;
            wa.OnGetPhotoPreview += wa_OnGetPhotoPreview;
            wa.OnGetGroups += wa_OnGetGroups;
            wa.OnGetSyncResult += wa_OnGetSyncResult;
            wa.OnGetStatus += wa_OnGetStatus;
            wa.OnGetPrivacySettings += wa_OnGetPrivacySettings;
            DebugAdapter.Instance.OnPrintDebug += Instance_OnPrintDebug;

            wa.Connect();

            string datFile = getDatFileName(sender);
            byte[] nextChallenge = null;
            if (File.Exists(datFile))
            {
                try
                {
                    string foo = File.ReadAllText(datFile);
                    nextChallenge = Convert.FromBase64String(foo);
                }
                catch (Exception) { };
            }

            wa.Login(nextChallenge);

            ProcessChat(wa, target);
            Console.ReadKey();
        }

        static void Instance_OnPrintDebug(object value)
        {
            Console.WriteLine(value);
        }

        static void wa_OnGetPrivacySettings(Dictionary<ApiBase.VisibilityCategory, ApiBase.VisibilitySetting> settings)
        {
            throw new NotImplementedException();
        }

        static void wa_OnGetStatus(string from, string type, string name, string status)
        {
            Console.WriteLine(String.Format("Got status from {0}: {1}", from, status));
        }

        static string getDatFileName(string pn)
        {
            string filename = string.Format("{0}.next.dat", pn);
            return Path.Combine(Directory.GetCurrentDirectory(), filename);
        }

        static void wa_OnGetSyncResult(int index, string sid, Dictionary<string, string> existingUsers, string[] failedNumbers)
        {
            Console.WriteLine("Sync result for {0}:", sid);
            foreach (KeyValuePair<string, string> item in existingUsers)
            {
                Console.WriteLine("Existing: {0} (username {1})", item.Key, item.Value);
            }
            foreach (string item in failedNumbers)
            {
                Console.WriteLine("Non-Existing: {0}", item);
            }
        }

        static void wa_OnGetGroups(WaGroupInfo[] groups)
        {
            Console.WriteLine("Got groups:");
            foreach (WaGroupInfo info in groups)
            {
                Console.WriteLine("\t{0} {1}", info.subject, info.id);
            }
        }

        static void wa_OnGetPhotoPreview(string from, string id, byte[] data)
        {
            Console.WriteLine("Got preview photo for {0}", from);
            File.WriteAllBytes(string.Format("preview_{0}.jpg", from), data);
        }

        static void wa_OnGetPhoto(string from, string id, byte[] data)
        {
            Console.WriteLine("Got full photo for {0}", from);
            File.WriteAllBytes(string.Format("{0}.jpg", from), data);
        }

        static void wa_OnGetMessageVcard(ProtocolTreeNode vcardNode, string from, string id, string name, byte[] data)
        {
            Console.WriteLine("Got vcard \"{0}\" from {1}", name, from);
            File.WriteAllBytes(string.Format("{0}.vcf", name), data);
        }

        static void wa_OnGetMessageLocation(ProtocolTreeNode locationNode, string from, string id, double lon, double lat, string url, string name, byte[] preview, string username)
        {
            Console.WriteLine("Got location from {0} ({1}, {2})", from, lat, lon);
            if (!string.IsNullOrEmpty(name))
            {
                Console.WriteLine("\t{0}", name);
            }
            File.WriteAllBytes(string.Format("{0}{1}.jpg", lat, lon), preview);
        }

        static void wa_OnGetMessageVideo(ProtocolTreeNode mediaNode, string from, string id, string fileName, int fileSize, string url, byte[] preview, string username)
        {
            Console.WriteLine("Got video from {0}", from, fileName);
            OnGetMedia(fileName, url, preview);
        }

        static void OnGetMedia(string file, string url, byte[] data)
        {
            //save preview
            File.WriteAllBytes(string.Format("preview_{0}.jpg", file), data);
            //download
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(new Uri(url), file, null);
            }
        }

        static void wa_OnGetMessageAudio(ProtocolTreeNode mediaNode, string from, string id, string fileName, int fileSize, string url, byte[] preview, string username)
        {
            Console.WriteLine("Got audio from {0}", from, fileName);
            OnGetMedia(fileName, url, preview);
        }

        static void wa_OnGetMessageImage(ProtocolTreeNode mediaNode, string from, string id, string fileName, int size, string url, byte[] preview, string username)
        {
            Console.WriteLine("Got image from {0}", from, fileName);
            OnGetMedia(fileName, url, preview);
        }

        static void wa_OnGetPaused(string from)
        {
            Console.WriteLine("{0} stopped typing", from);
        }

        static void wa_OnGetTyping(string from)
        {
            Console.WriteLine("{0} is typing...", from);
        }

        static void wa_OnGetLastSeen(string from, DateTime lastSeen)
        {
            Console.WriteLine("{0} last seen on {1}", from, lastSeen.ToString());
        }

        static void wa_OnGetMessageReceivedServer(string from, string participant, string id)
        {
            Console.WriteLine("Message {0} to {1} received by server", id, from);
        }

        static void wa_OnGetMessageReceivedClient(string from, string participant, string id)
        {
            Console.WriteLine("Message {0} to {1} received by client", id, from);
        }

        static void wa_OnGetGroupParticipants(string gjid, string[] jids)
        {
            Console.WriteLine("Got participants from {0}:", gjid);
            foreach (string jid in jids)
            {
                Console.WriteLine("\t{0}", jid);
            }
        }

        static void wa_OnGetPresence(string from, string type)
        {
            Console.WriteLine("Presence from {0}: {1}", from, type);
        }

        static void wa_OnNotificationPicture(string type, string jid, string id)
        {
            //TODO
            //throw new NotImplementedException();
        }

        static void wa_OnGetMessage(ProtocolTreeNode node, string from, string id, string name, string message, bool receipt_sent)
        {
            Console.WriteLine("Message from {0} {1}: {2}", name, from, message);

        }

        private static void wa_OnLoginFailed(string data)
        {
            Console.WriteLine("Login failed. Reason: {0}", data);
        }

        private static void wa_OnLoginSuccess(string phoneNumber, byte[] data)
        {
            Console.WriteLine("Login success. Next password:");
            string sdata = Convert.ToBase64String(data);
            Console.WriteLine(sdata);
            try
            {
                File.WriteAllText(getDatFileName(phoneNumber), sdata);
            }
            catch (Exception) { }
        }


        private static void ProcessChat(WhatsApp wa, string dst)
        {
            var thRecv = new Thread(t =>
            {
                try
                {
                    while (wa != null)
                    {
                        wa.PollMessages();
                        Thread.Sleep(100);
                        continue;
                    }

                }
                catch (ThreadAbortException)
                {
                }
            }) { IsBackground = true };
            thRecv.Start();

            WhatsUserManager usrMan = new WhatsUserManager();
            var tmpUser = usrMan.CreateUser(dst, "User");

            while (true)
            {
                string line = Console.ReadLine();
                if (line == null && line.Length == 0)
                    continue;

                string command = line.Trim();
                switch (command)
                {
                    case "/query":
                        //var dst = dst//trim(strstr($line, ' ', FALSE));
                        Console.WriteLine("[] Interactive conversation with {0}:", tmpUser);
                        break;
                    case "/accountinfo":
                        Console.WriteLine("[] Account Info: {0}", wa.GetAccountInfo().ToString());
                        break;
                    case "/lastseen":
                        Console.WriteLine("[] Request last seen {0}", tmpUser);
                        wa.SendQueryLastOnline(tmpUser.GetFullJid());
                        break;
                    case "/exit":
                        wa = null;
                        thRecv.Abort();
                        return;
                    case "/start":
                        wa.SendComposing(tmpUser.GetFullJid());
                        break;
                    case "/pause":
                        wa.SendPaused(tmpUser.GetFullJid());
                        break;
                    default:
                        Console.WriteLine("[] Send message to {0}: {1}", tmpUser, line);
                        wa.SendMessage(tmpUser.GetFullJid(), line);
                        break;
                }
            }
        }
        #endregion
        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                ////  int ItemID = 0;
                ////  ItemID = Convert.ToInt32(cmbItem.GetColumnValue("ItemID"));// cmbItem.EditValue);

                ////  int quantity = 0;
                ////  quantity = Convert.ToInt32(txtQunatity.Text);

                ////   int AllAvailablequantity = 0;
                ////  AllAvailablequantity = Convert.ToInt32(cmbInventory.Text);


                ////  decimal salePrice = 0;
                ////  salePrice = Convert.ToDecimal(txtSalePrice.Text);

                ////  /*
                ////   Validation
                ////   * Check dupicated items
                ////   */
                ////  if(quantity <=0)
                ////  {
                ////      MessageBox.Show("Check the quantity", "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ////      txtQunatity.Focus();
                ////      txtQunatity.Select(txtQunatity.Text.Length, 0);
                ////      return;
                ////  }
                ////  if(quantity >  AllAvailablequantity)
                ////  {
                ////      MessageBox.Show(cmbInventory.Text + " "+cmbItem.Text+  "  not available\n You can sale only  "+cmbInventory.Text, "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ////      txtQunatity.Focus();
                ////      txtQunatity.Select(txtQunatity.Text.Length, 0);
                ////      return;
                ////  }
                ////  var found = (from s in details where s.ItemID == ItemID select s).Count();
                ////  if (found != 0)
                ////  {
                ////      MessageBox.Show(cmbItem.Text + "  already in the invoice", "Duplicate item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ////      cmbItem.Focus();
                ////      return;
                ////  }

                ////  DataAccess.SaleInvoiceDetail detail =  db.SaleInvoiceDetails.Create();

                ////  detail.SaleInvoiceID = invoice.ID;
                ////  detail.ItemID = ItemID;
                ////  detail.Quanitity =Convert.ToInt32( txtQunatity.Text);
                ////  detail.UnitPrice = Convert.ToInt32(cmbInventory.EditValue);
                ////  var inventory = cmbItem.GetColumnValue("ID");
                ////  detail.InventoryID =Convert.ToInt32(inventory);
                ////  cmbItem.EditValue = null;
                ////  cmbInventory.Text = "0";
                ////  txtQunatity.Text = "0";
                ////  txtSalePrice.Text = "0";
                ////  cmbItem.Focus();




                //// details.Add(detail);
                ////////  if (checkEditAutoSave.Checked)
                ////////  {
                ////////      if (db.SaveChanges() > 0)
                ////////      {
                ////////          ShowMessageInStatusBar("New item saved successfully", 9000);
                ////////      }
                ////////  }
                ////////  if(checkEditAutoPrint.Checked)
                ////////  {
                ////////      ////if(PrintDetails(detail))
                ////////      ////{
                ////////      ////    ShowMessageInStatusBar("New item printed successfully", 9000);
                ////////      ////}
                ////////  }
                ////bindingSourceSaleInvoiceDetails.ResetBindings(false);
                ////cmbItem.Focus();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private bool PrintDetails(DataAccess.SaleInvoiceDetail detail)
        {
            bool result = true;
            ////var item = db.Items.Where(s => s.ID == detail.ItemID).SingleOrDefault();

            ////  XtraReport1 rpt = new XtraReport1(item.BarcodeText, item.Name,detail.SalePrice.ToString());
            //// // rpt.DataSource = list;
            ////  ReportPrintTool tool = new ReportPrintTool(rpt);
            ////  tool.ShowPreview();


            return result;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintInvoice(true);
        }

        private void PrintInvoice(bool doPrint, bool confirm = true)
        {
            try
            {
                decimal invoiceTotal = 0;
                foreach (var item in details)
                {
                    invoiceTotal += (item.UnitPrice * item.Quanitity);
                }
                decimal discount = Convert.ToDecimal(txtDiscount.EditValue);
                if(discount>(invoiceTotal*10/100))
                {
                    MessageBox.Show("أكبر تخفيض يمكن منحه هو:" + (invoiceTotal * 10 / 100) +"  جنيه ", "قيمة التخفيض أكبر من 10% من مجموع الفاتورة");

                    return;
                }
                string msg = "";
                if(doPrint)
                {
                    msg = "تأكيد وطباعه الفاتورة";
                }
                else
                {
                    msg = "تأكيد بدون طباعه الفاتورة";
                }
                if (details.Count() <= 0)
                {
                    MessageBox.Show("الفاتورة لا تحتوي علي أصناف", "طباعة فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                bool confirmPrint = true;
                if(confirm)
                {
                    if (MessageBox.Show(msg, "تاكيد البيع", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        confirmPrint = true;
                    }
                    else
                    {
                        confirmPrint = false;
                    }
                }
               
                if (confirmPrint)// MessageBox.Show( msg,"تاكيد البيع", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    calculateInvoiceTotal();
                    // db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                    //Close invoice
                    ////invoice = db.SaleInvoices.Where(s => s.ID == this.invoice.ID).SingleOrDefault();
                    invoice = new DataAccess.SaleInvoice();
                    invoice.Date = DateTime.Now;
                    invoice.UserID = Convert.ToInt32(UserData.Default.UserID);
                    if (_saleInvoiceType == SaleInvoiceType.Sale)
                    {
                        invoice.Remarks = "Sale";
                    }
                    else
                        if (_saleInvoiceType == SaleInvoiceType.Transfer)
                        {
                            branchID = _trnasferFrom;
                            invoice.Remarks = "Transfer";
                        }
                        else
                            if (_saleInvoiceType == SaleInvoiceType.Expire)
                            {
                                invoice.Remarks = "Expire";
                            }

                    invoice.BranchID = branchID;
                    invoice.Flag = 0;
                   
                    db.SaleInvoices.Add(invoice);
                    DataAccess.Inventory inv;
                    foreach (var item in details)
                    {
                        item.SaleInvoiceID = invoice.ID;
                        invoice.SaleInvoiceDetails.Add(item);

                        ////inv= db.Inventories.Where(s => s.ID == item.InventoryID).SingleOrDefault();
                        ////inv.CurrentQuanity -= item.Quanitity;
                    }
                    invoice.Total = Convert.ToDecimal(txtInvoiceTotal.Text);
                    invoice.Discount = Convert.ToDecimal(txtDiscount.Text);
                    int savedRows = db.SaveChanges();
                    if(savedRows>0)
                    {
                        invoice.Flag = 1;
                        db.SaveChanges();

                        if (_saleInvoiceType == SaleInvoiceType.Transfer)
                        {
                            DataAccess.PurchaseInvoice TransferPurchaseInvoice = db.PurchaseInvoices.Create();
                            TransferPurchaseInvoice.BranchID = _trnasferTo;
                            TransferPurchaseInvoice.Date = DateTime.Now;
                            TransferPurchaseInvoice.Discount = 0;
                            TransferPurchaseInvoice.Flag = 0;
                            TransferPurchaseInvoice.Number = "Transfer " + invoice.ID;
                            TransferPurchaseInvoice.Total = 0;
                            TransferPurchaseInvoice.UserID = Convert.ToInt32(UserData.Default.UserID);
                            
                            DataAccess.PurchaseInvoiceDetail child;
                            foreach (var item in details)
                            {
                                child = db.PurchaseInvoiceDetails.Create();
                                child.DiscountPrice = 0;
                                child.ItemID = item.ItemID;
                                child.PurchasePrice = item.UnitPrice;
                                child.Quantity = item.Quanitity;
                                child.Remarks = "TrasferInvoice From Reda " + branchID + "  "+invoice.ID;
                                child.SalePrice = item.UnitPrice;


                                TransferPurchaseInvoice.PurchaseInvoiceDetails.Add(child);
                            }

                            db.PurchaseInvoices.Add(TransferPurchaseInvoice);
                            savedRows = db.SaveChanges();
                            if (savedRows > 0)
                            {
                                TransferPurchaseInvoice.Flag = 1;
                                savedRows = db.SaveChanges();
                                if (savedRows > 0)
                                {
                                    MessageBox.Show("اكتمل عملية تحويل البضاعه بنجاح");
                                    this.Close();
                                }
                            }

                        }
                        if(refreshFastItem)
                        {
                            bindingSourceTempItems.DataSource = db.vw_TempItem.Where(s => s.BranchID == branchID).ToList();
                            refreshFastItem = false;
                        }
                    }
                  
                    Reports.SaleRpt rpt = new SaleRpt(Convert.ToDecimal(txtDiscount.EditValue), Convert.ToDecimal(txtAfterDiscount.EditValue),0,0, this.invoice.ID.ToString(), UserData.Default.UserName);
                    var list = from s in db.vw_Sale2 where s.SaleInvoiceID == invoice.ID select s;
                    rpt.DataSource = list.ToList();

                    txtAfterDiscount.EditValue = 0;
                    txtInvoiceTotal.EditValue = 0;
                    txtDiscount.EditValue = 0;
                    try
                    {
                        if (doPrint)
                        {
                            ReportPrintTool tool = new ReportPrintTool(rpt);
                            string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                            if(InvoicePrinter == "")
                            {
                                tool.Print();
                            }
                            else
                            {
                                tool.Print(InvoicePrinter);
                            }
                        }
                        DataAccess.vw_Inventory localInv;
                        ////foreach (var item in details)
                        ////{
                        ////    localInv = db.vw_Inventory.Where(s => s.ID == item.InventoryID).SingleOrDefault();
                        ////    localInv.CurrentQuanity -= item.Quanitity;
                        ////}
                      // db.vw_Inventory.Load();
                       //db.vw_Inventory.Where(s => s.BranchID == branchID).Load();
                    }
                    catch (Exception ex)
                    {
                         ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                    }

                    ////db.Dispose();
                    ////db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                    //////refresh inventory
                    ////db.vw_TempItem.Load();
                    ////++++ = db.vw_TempItem.Local.ToBindingList();
                  

                    //Refresh Form
                    details = new BindingList<DataAccess.SaleInvoiceDetail>();
                    bindingSourceSaleInvoiceDetails.DataSource = details;

                    //bindingSourceTempItems.DataSource = db.vw_TempItem.Where(s => s.BranchID == branchID).ToList();

                   
                    bindingSourceInventory.DataSource = null;

                    ////invoice = db.SaleInvoices.Create();
                    ////invoice.Flag = 0;
                    ////invoice.Remarks = "None";
                    ////db.SaleInvoices.Add(invoice);
                    ////invoice.Date = DateTime.Now;
                    ////invoice.UserID = Convert.ToInt32(UserData.Default.UserID); //1;
                    ////invoice.BranchID = branchID;
                    ////int rows = db.SaveChanges();
                    ////this.Text = this.invoice.ID.ToString();
                    //details = null;
                    ////this.bindingSourceSaleInvoiceDetails.DataSource = null;
                    //////db.Set<DataAccess.SaleInvoiceDetail>().AsNoTracking();
                    ////this.bindingSourceSaleInvoice.DataSource = this.invoice;
                    ////db.SaleInvoiceDetails.Where(s => s.SaleInvoiceID == invoice.ID).Load();
                    ////details = db.SaleInvoiceDetails.Local.ToBindingList(); //new BindingList<DataAccess.SaleInvoiceDetail>();//
                    ////this.bindingSourceSaleInvoiceDetails.DataSource = details;
                    ////this.bindingSourceItem.DataSource = db.Items.ToList();


                }

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                PrintInvoice(true, false);
               
                return true;
            }
            else
                if (keyData == (Keys.F2))
                {
                    txtBar.Focus();
                  
                    return true;
                }
                else
                    if(keyData == Keys.F3)
                    {
                        txtSearch.Focus();
                        return true;
                    }
            if (keyData == (Keys.Up))
            {
                IncreaseQuantity();
                calculateInvoiceTotal();
                txtBar.Focus();
                return true;
            }
            else
                if (keyData == (Keys.Down))
                {
                    DecreaseQunatity();
                    calculateInvoiceTotal();
                    txtBar.Focus();
                    return true;
                }
                else
                    if (keyData == (Keys.Control | Keys.Left))
                    {
                        PrintInvoice(true);
                        return true;
                    }
                    else
                        if (keyData == (Keys.Control | Keys.Right))
                        {
                            PrintInvoice(false);
                            return true;
                        }
                        else
                            if (keyData == (Keys.Alt | Keys.C))
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
                                return true;
                            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            timer1.Stop();
        }
        public void ShowMessageInStatusBar(String Message, int time)
        {
            lblMessage.Text = Message;
            timer1.Interval = time;
            timer1.Start();
        }

        private void cmbItem_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    ////ItemForm frm = new ItemForm(cmbItem.Text);
                    ////if(frm.ShowDialog() ==System.Windows.Forms.DialogResult.OK)
                    ////{
                    ////    this.bindingSourceItem.DataSource = db.Items.ToList();
                    ////    int lastId = db.Items.Select(s => s.ID).Max();
                    ////    var lastInsertedRow = db.Items.Where(s => s.ID == lastId).SingleOrDefault();
                    ////    cmbItem.EditValue = lastInsertedRow.ID;
                    ////    txtQunatity.Focus();
                    ////    txtQunatity.Select(txtQunatity.Text.Length, 0);
                    ////}
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        //private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //         ModuleClass.ShowMessage(this, ex, "خطأ", null);
        //    }
        //}

        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //Print
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                //   if(MessageBox.Show("Are you sure ?","Delete current Item",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataAccess.SaleInvoiceDetail currentRow = (DataAccess.SaleInvoiceDetail)gridViewInvoice.GetFocusedRow();
                    details.Remove(currentRow);
                    int rows = db.SaveChanges();
                    calculateInvoiceTotal();

                    ////if (db.SaveChanges()>0)
                    {
                        ShowMessageInStatusBar("item remove successfully", 9000);
                    }
                }
            }
        }

        private void cmbItem_EditValueChanged(object sender, EventArgs e)
        {
            ////try
            ////{

            ////    int itemID = Convert.ToInt32(cmbItem.GetColumnValue("ItemID"));// cmbItem.EditValue);
            ////    var checkList = from s in db.vw_Inventory where s.ItemID == itemID select s;
            ////    if (checkList.Count() > 0)
            ////    {
            ////        var topSalePrice = (from s in checkList select s.SalePrice).Max();
            ////        txtSalePrice.Text = topSalePrice.ToString();
            ////        var AllCurrentQuanity = (from s in db.vw_Inventory where s.ItemID == itemID && s.CurrentQuanity > 0 select s.CurrentQuanity).Sum(); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);
            ////        //  bindingSourceInventory.DataSource = inventroyList.ToList();
            ////        cmbInventory.EditValue = AllCurrentQuanity.ToString();
            ////    }
            ////    else
            ////    {
            ////        cmbInventory.Text = "0";
            ////        txtQunatity.Text = "0";
            ////        txtSalePrice.Text = "0";
            ////        cmbItem.Focus();
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////     ModuleClass.ShowMessage(this, ex, "خطأ", null);
            ////}
        }

        private void txtSearch_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ////if(e.Button.Kind == ButtonPredefines.Clear)
            ////{
            ////    txtBarcode.Text = "";
            ////}
        }

        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //        string barcode = txtBarcode.Text;
            //        if (barcode.Length > 8)
            //        {
            //            ////var item = (from s in db.Items where s.BarcodeText == barcode select s).SingleOrDefault();
            //            ////if(item!= null)
            //            ////{
            //            ////    cmbItem.EditValue = item.ID;
            //            ////}
            //            ////var AllCurrentQuanity = (from s in db.vw_Inventory where s.BarcodeText == barcode && s.CurrentQuanity > 0 select s.CurrentQuanity).Sum();

            //            ////cmbInventory.EditValue = AllCurrentQuanity.ToString();
            //            ////txtQunatity.Text = "1";
            //            ////txtQunatity.Focus();
            //            ////txtQunatity.Select(txtQunatity.Text.Length, 0);
            //        }
            //    }
            //        catch(InvalidOperationException ex)
            //    {
            //        //Do nothing
            //        ////txtQunatity.Text = "";
            //        ////txtSalePrice.Text = "";
            //    }
            //    catch (Exception ex)
            //    {
            //         ModuleClass.ShowMessage(this, ex, "خطأ", null);
            //    }
        }

        private void gridLookUpEdit1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {


        }

        private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter && txtSearch.Text.Length > 2)
                {
                    string query = txtSearch.Text;
                    //  db = new DataAccess.RedaV1Entities(ModuleClass.Connect());

                    this.bindingSourceInventory.DataSource = (from s in db.vw_Inventory where s.CurrentQuanity > 0 && s.Name.Contains(query) && s.BranchID == branchID select s).ToList();// db.vw_Inventory.ToList();
                }
                else
                {
                    this.bindingSourceInventory.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                
            }
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridViewSearch_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;

            Point pt = view.GridControl.PointToClient(Control.MousePosition);

            DoRowDoubleClick(view, pt);
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {

            ////GridHitInfo info = view.CalcHitInfo(pt);

            ////if (info.InRow || info.InRowCell)
            ////{

            ////    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

            ////    //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            ////    //string barcodeText = txtBar.Text;

            ////    //txtBar.Text = "";
            ////   DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
            ////    ////DataAccess.Item item = (from s in db.Items where s.BarcodeText == barcodeText select s).SingleOrDefault();
            ////    ////if (item != null)
            ////    {
            ////        var item = gridViewSearch.GetFocusedDataRow();
            ////        //string cellValue;

            ////        var cellValue = gridViewSearch.GetRowCellValue(info.RowHandle, colItemID1);
            ////        var r = this.gridViewSearch.GetDataRow(info.RowHandle);
            ////        int itemID =Convert.ToInt32( item["ItemID"]);
            ////        var checkList = from s in db.vw_Inventory where s.ItemID == itemID select s;
            ////        if (checkList.Count() > 0)
            ////        {
            ////            //var AllCurrentQuanity = (from s in db.vw_Inventory where s.ItemID == itemID && s.CurrentQuanity > 0 select s.CurrentQuanity).Sum(); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);

            ////            var listFound = (from s in db.vw_Inventory where s.ItemID == itemID && s.CurrentQuanity > 0 select s).First();
            ////            //  if(listFound.Count() > 0)



            ////            DataAccess.SaleInvoiceDetail detail = db.SaleInvoiceDetails.Create();

            ////            detail.SaleInvoiceID = invoice.ID;
            ////            detail.ItemID = itemID;
            ////            detail.Quanitity = 1;// Convert.ToInt32(txtQunatity.Text);
            ////            detail.UnitPrice = listFound.SalePrice;
            ////            //var inventory = cmbItem.GetColumnValue("ID");
            ////            detail.InventoryID = listFound.ID;

            ////            txtBar.Focus();




            ////            details.Add(detail);
            ////            txtBar.Text = "";
            ////            // bindingSourceSaleInvoiceDetails.ResetBindings(false);


            ////        }
            ////    }

            ////}

        }

        private void txtBarcodetext_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //txtBarcodetext.Text = "";
            calculateInvoiceTotal();
        }

        private void calculateInvoiceTotal()
        {
            decimal invoiceTotal = 0;
            foreach (var item in details)
            {
                invoiceTotal += (item.UnitPrice * item.Quanitity);
            }
            decimal discount = Convert.ToDecimal(txtDiscount.EditValue);

            decimal afterDiscount = invoiceTotal - discount;

            txtAfterDiscount.EditValue = afterDiscount;
            txtInvoiceTotal.EditValue = invoiceTotal;
            ////int rowss = db.SaveChanges();
            ////db.SaleInvoiceDetails.Where(s => s.SaleInvoiceID == invoice.ID).Load();
            ////details = db.SaleInvoiceDetails.Local.ToBindingList(); //new BindingList<DataAccess.SaleInvoiceDetail>();//
            ////this.bindingSourceSaleInvoiceDetails.DataSource = details;

            gridViewInvoice.UpdateSummary();

            gridViewInvoice.BeginSort();

            try
            {

                gridViewInvoice.ClearSorting();

                gridViewInvoice.Columns["ID"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                //gridView1.Columns["colID"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            }

            finally
            {

                gridViewInvoice.EndSort();

            }
        }

        private void txtBarcodetext_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ////if (txtBarcodetext.Text != "")
                ////{
                ////    string barcodeText = txtBarcodetext.Text;

                ////    txtBarcodetext.Text = "";
                ////    db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                ////    DataAccess.Item item = (from s in db.Items where s.BarcodeText == barcodeText select s).SingleOrDefault();
                ////    if (item != null)
                ////    {
                ////        int itemID = item.ID;
                ////        var checkList = from s in db.vw_Inventory where s.ItemID == itemID select s;
                ////        if (checkList.Count() > 0)
                ////        {
                ////            //var AllCurrentQuanity = (from s in db.vw_Inventory where s.ItemID == itemID && s.CurrentQuanity > 0 select s.CurrentQuanity).Sum(); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);

                ////            var listFound = (from s in db.vw_Inventory where s.ItemID == itemID && s.CurrentQuanity > 0 select s).First();
                ////            //  if(listFound.Count() > 0)



                ////            DataAccess.SaleInvoiceDetail detail = db.SaleInvoiceDetails.Create();

                ////            detail.SaleInvoiceID = invoice.ID;
                ////            detail.ItemID = itemID;
                ////            detail.Quanitity = 1;// Convert.ToInt32(txtQunatity.Text);
                ////            detail.UnitPrice = listFound.SalePrice;
                ////            //var inventory = cmbItem.GetColumnValue("ID");
                ////            detail.InventoryID = listFound.ID;

                ////            txtBarcodetext.Focus();




                ////            details.Add(detail);

                ////            // bindingSourceSaleInvoiceDetails.ResetBindings(false);


                ////        }
                ////    }
                ////}
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }

        private void txtBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string barcodeText = txtBar.Text;
                if (txtBar.Text != "")
                {

                    if (txtBar.Text.Length >= 6)
                    {
                        var inventoryFound = (from s in db.vw_Inventory where (s.BarcodeText == barcodeText || s.OriginalBarcodeText== barcodeText) && s.CurrentQuanity > 0 && s.BranchID == branchID select s).ToList();
                        if (inventoryFound.Count() > 1)
                        {
                            this.bindingSourceInventory.DataSource = inventoryFound; // db.vw_Inventory.ToList();
                            return;
                        }
                        else
                            if (inventoryFound.Count() == 1)
                            {
                                this.bindingSourceInventory.DataSource = null;

                                //DataAccess.Item item = (from s in db.Items where s.BarcodeText == barcodeText select s).SingleOrDefault();
                                if (inventoryFound[0] != null)
                                {
                                    int itemID = inventoryFound[0].ItemID;
                                    //var checkList = from s in db.vw_Inventory where s.ItemID == itemID select s;
                                    //if (checkList.Count() > 0)
                                    {
                                        //increase existing item qnt
                                        //var listFound = (from s in db.vw_Inventory where s.ItemID == itemID && s.CurrentQuanity > 0 select s).First();
                                        foreach (var i in details)
                                        {
                                            if (i.InventoryID == inventoryFound[0].ID)
                                            {
                                                IncreaseQuantity();
                                                this.bindingSourceInventory.DataSource = null;
                                                txtBar.Text = "";
                                                return;
                                            }
                                        }

                                        Console.Beep();
                                        DataAccess.SaleInvoiceDetail newRow = details.AddNew();
                                        newRow.ItemID = itemID;
                                        newRow.Quanitity = 1;
                                        if (_saleInvoiceType == SaleInvoiceType.Transfer || _saleInvoiceType == SaleInvoiceType.Expire)
                                        {
                                            newRow.UnitPrice = Convert.ToDecimal(inventoryFound[0].PurchasePrice);
                                        }
                                        else
                                            if (_saleInvoiceType == SaleInvoiceType.Sale )
                                            {
                                                newRow.UnitPrice = Convert.ToDecimal(inventoryFound[0].SalePrice);
                                            }
                                        newRow.InventoryID = inventoryFound[0].ID;
                                        txtBar.Text = "";
                                        //calculateInvoiceTotal();
                                        txtBar.Focus();
                                        calculateInvoiceTotal();
                                        this.bindingSourceInventory.DataSource = null;
                                        gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1;
                                    }
                                }
                            }
                            else
                                 if (inventoryFound.Count() < 1)
                                 {
                                     this.bindingSourceInventory.DataSource = null;
                                    // txtBar.Text = "";
                                     //calculateInvoiceTotal();
                                     //txtBar.Focus();
                                     //Console.Beep(5000, 2000);
                                 }

                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }

        private void repositoryItemButtonEditSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.Glyph)
                {
                    if (gridViewSearch.GetFocusedRow() is DataAccess.vw_Inventory)
                    {
                        DataAccess.vw_Inventory currentRow = (DataAccess.vw_Inventory)gridViewSearch.GetFocusedRow();
                        foreach (var item in details)
                        {
                            if (item.InventoryID == currentRow.ID)
                            {
                                //Item alread added to invoice
                                MessageBox.Show("لا يمكنك إضافة الصنف أكثر من مرة في الفاتورة");
                                return;
                            }
                        }
                        int itemID = currentRow.ItemID;
                        Console.Beep();//5000, 1000);
                        DataAccess.SaleInvoiceDetail newRow = details.AddNew();
                        newRow.ItemID = itemID;
                        newRow.Quanitity = 1;
                        if (_saleInvoiceType == SaleInvoiceType.Transfer || _saleInvoiceType == SaleInvoiceType.Expire)
                        {
                            newRow.UnitPrice = Convert.ToDecimal(currentRow.PurchasePrice);
                        }
                        else
                        {
                            newRow.UnitPrice = Convert.ToDecimal(currentRow.SalePrice);
                        }
                      
                        newRow.InventoryID = currentRow.ID;

                        //details.Add(newRow);
                        ////db.SaleInvoiceDetails.Add(detail);
                       /////invoice.SaleInvoiceDetails.Add(detail);

                        /////int rows = db.SaveChanges();

                        txtBar.Text = "";
                        calculateInvoiceTotal();
                        txtBar.Focus();
                        calculateInvoiceTotal();
                        gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1; 
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

       
        private void repositoryItemButtonEditAddQuantity_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.Up)
                {
                    IncreaseQuantity();
                }
                else
                    if (e.Button.Kind == ButtonPredefines.Down)
                    {
                        DecreaseQunatity();
                    }

                calculateInvoiceTotal();
                txtBar.Focus();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void DecreaseQunatity()
        {
            if (gridViewInvoice.GetFocusedRow() is DataAccess.SaleInvoiceDetail)
            {
                DataAccess.SaleInvoiceDetail currentRow = (DataAccess.SaleInvoiceDetail)gridViewInvoice.GetFocusedRow();
                if (currentRow.Quanitity > 1)
                {
                    Console.Beep();//5000, 1000);
                    currentRow.Quanitity--;
                }
                else
                {
                    Console.Beep(5000, 100);
                }
                gridViewInvoice.RefreshRow(gridViewInvoice.FocusedRowHandle);
            }
        }

        private void IncreaseQuantity()
        {
            if (gridViewInvoice.GetFocusedRow() is DataAccess.SaleInvoiceDetail)
            {
                DataAccess.SaleInvoiceDetail currentRow = (DataAccess.SaleInvoiceDetail)gridViewInvoice.GetFocusedRow();
                
                var inventoryList = (from s in db.vw_Inventory where s.ID == currentRow.InventoryID && s.CurrentQuanity > 0 select s); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);
               
                var AllCurrentQuanity = inventoryList.Select(s=>s.CurrentQuanity).Sum();
                if (currentRow.Quanitity < AllCurrentQuanity)
                {
                    Console.Beep();//5000, 1000);
                    currentRow.Quanitity++;
                    if ((AllCurrentQuanity - currentRow.Quanitity) <= 2)
                    {
                        //ModuleClass.SendWhatsAppMessage("ALL",);
                        try
                        {
                            //string message = "Reda" + branchID + " الصنف " + inventoryList.First().Name + "قارب علي الإنتهاء" + (AllCurrentQuanity - currentRow.Quanitity);
                            //Thread thread = new Thread(() => PushMessage.SendPush_Message("", message, "قارب علي الإنتهاء"));
                            //thread.Start();
                        }
                        catch (Exception ex)
                        {
                            //Do nothing 
                        }
                    }
                   
                }
                else
                {
                  Console.Beep(5000, 100);
                //    SystemSounds.Beep.Play();
                } 
                gridViewInvoice.RefreshRow(gridViewInvoice.FocusedRowHandle);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.Name == "gridColumnItemTotal" && e.IsGetData)
                e.Value = getTotalValue(view, e.ListSourceRowIndex);
        }
        decimal getTotalValue(GridView view, int listSourceRowIndex)
        {
            decimal unitPrice = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "UnitPrice"));
            decimal quantity = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "Quanitity"));
            //decimal discount = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "Discount"));
            return unitPrice * quantity;
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            
            calculateInvoiceTotal();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //calculateInvoiceTotal();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                ////if(true)
                ////{
                ////    DataAccess.SaleInvoiceDetail currentRow = (DataAccess.SaleInvoiceDetail)e.Row;
                ////    var AllCurrentQuanity = (from s in db.vw_Inventory where s.ID == currentRow.InventoryID && s.CurrentQuanity > 0 select s.CurrentQuanity).Sum(); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);
                ////    if (currentRow.Quanitity > AllCurrentQuanity || currentRow.Quanitity <=0)
                ////    {
                ////        e.Valid = false;
                ////        e.ErrorText = "Data wrong";
                ////    }
                ////}

                ////gridView1.RefreshRow(gridView1.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "Quanitity")
                {
                    DataAccess.SaleInvoiceDetail currentRow = (DataAccess.SaleInvoiceDetail)view.GetFocusedRow();
                    var AllCurrentQuanity = (from s in db.vw_Inventory where s.ID == currentRow.InventoryID && s.CurrentQuanity > 0 select s.CurrentQuanity).Sum(); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);

                    //Get the currently edited value 
                    Int32 quan = Convert.ToInt32(e.Value);
                    //Specify validation criteria 
                    if (quan < 0)
                    {
                        e.Valid = false;
                        e.ErrorText = "الرجاء ادخال قيمه اكبر من صفر";
                    }
                    if (quan > AllCurrentQuanity)
                    {
                        e.Valid = false;
                        e.ErrorText = "   لا يمكن صرف أكثر من    " + AllCurrentQuanity; ;
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Quanitity")
                e.RepositoryItem = repositoryItemSpinEdit1;
        }

        private void txtBar_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("en"));
        }

        private void txtBar_Leave(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("ar"));
        }
        public static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                    return lang;
            }
            return null;
        }
        public void SetKeyboardLayout(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("ar"));


            txtSearch.BeginInvoke(new MethodInvoker(delegate
           {
               txtSearch.SelectionLength = txtSearch.Text.Length;
               txtSearch.SelectionStart = 0;
           }));

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            //SetKeyboardLayout(GetInputLanguageByName("En"));
        }

        

        private void pivotGridControl1_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            
        }

        private void pivotGridControl1_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {

        }

        private void pivotGridControl1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ////PivotGridControl pivotGridControl = (PivotGridControl)sender;
            ////PivotGridHitInfo hitInfo = pivotGridControl.CalcHitInfo(e.Location);

            ////if (hitInfo.HitTest == PivotGridHitTest.Value)
            ////{
            ////    var localDrillDownDataSource = hitInfo.ValueInfo.Data;
            ////   // localDrillDownDataSource.DataField
            ////   // localDrillDownDataSource.Cells;
            ////   // XtraMessageBox.Show(localDrillDownDataSource.RowCount.ToString());
            ////}
            ////if (hitInfo.HitTest == PivotGridHitTest.Cell)
            ////{
            ////    PivotDrillDownDataSource localDrillDownDataSource = hitInfo.CellInfo.CreateDrillDownDataSource();
            ////    XtraMessageBox.Show(localDrillDownDataSource.RowCount.ToString());
            ////}
        }

        private void pivotGridControl1_DoubleClick(object sender, EventArgs e)
        {
            PivotGridControl pivotGridControl = (PivotGridControl)sender;
            PivotGridHitInfo hitInfo = pivotGridControl.CalcHitInfo(pivotGridControl.PointToClient(Control.MousePosition));
            if (hitInfo.HitTest == PivotGridHitTest.Value)
            {
                //DoSomething
            }
        }

        private void gridView3_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
            info.GroupText = info.EditValue.ToString();// string.Format(view.GroupFormat, info.Column.Caption, info.EditValue, s);
        }

        private void repositoryItemButtonEditAddTempItem_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.Glyph)
                {
                    if (gridViewFastItems.GetFocusedRow() is DataAccess.vw_TempItem)
                    {
                        DataAccess.vw_TempItem currentRow = (DataAccess.vw_TempItem)gridViewFastItems.GetFocusedRow();
                        foreach (var item in details)
                        {
                            if (item.InventoryID == currentRow.ID)
                            {
                                //Item alread added to invoice
                                MessageBox.Show("لا يمكنك إضافة الصنف أكثر من مرة في الفاتورة");
                                return;
                            }
                        }
                        int itemID = currentRow.ItemID;
                        Console.Beep();//5000, 1000);
                        DataAccess.SaleInvoiceDetail newRow = details.AddNew();
                        refreshFastItem = true;
                       ///// newRow.SaleInvoiceID = invoice.ID;
                        newRow.ItemID = itemID;
                        newRow.Quanitity = 1;
                        if (_saleInvoiceType == SaleInvoiceType.Transfer || _saleInvoiceType == SaleInvoiceType.Expire)
                        {
                            newRow.UnitPrice = currentRow.PurchasePrice;
                        }
                        else
                        {
                            newRow.UnitPrice = currentRow.SalePrice;
                        }
                        
                        newRow.InventoryID = currentRow.ID;
                       // //details.Add(detail);
                       // //db.SaleInvoiceDetails.Add(newRow);
                       // //invoice.SaleInvoiceDetails.Add(newRow);

                       //// int rows = db.SaveChanges();

                        txtBar.Text = "";
                        calculateInvoiceTotal();
                        gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount-1; 
                        txtBar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            calculateInvoiceTotal();
        }

        private void btnAddTempItem_Click(object sender, EventArgs e)
        {
            try
            {
                new TempItem().ShowDialog();
                DataAccess.RedaV1Entities dbContext = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                //dbContext.vw_TempItem.Load();
                //bindingSourceTempItems.DataSource = dbContext.vw_TempItem.Local.ToBindingList();
                bindingSourceTempItems.DataSource = db.vw_TempItem.Where(s => s.BranchID == branchID).ToList();
                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            calculateInvoiceTotal();
        }

        private void gridControl1_Leave(object sender, EventArgs e)
        {
            calculateInvoiceTotal();
        }

        private void gridControl1_Enter(object sender, EventArgs e)
        {
            calculateInvoiceTotal();
        }

        private void txtDiscount_EditValueChanging(object sender, ChangingEventArgs e)
        {
            try
            {
                decimal invoiceTotal = 0;
                foreach (var item in details)
                {
                    invoiceTotal += (item.UnitPrice * item.Quanitity);
                }

                decimal discount = Convert.ToDecimal(e.NewValue);
                if (discount > (invoiceTotal * 10 / 100))
                {
                    errorProvider1.SetError(txtDiscount, "أكبر تخفيض يمكن منحه هو : " + (invoiceTotal * 10 / 100));
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test");
                
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNoVisible_Click(object sender, EventArgs e)
        {
            try
            
            {
                

                int itemId = Convert.ToInt32(cmbNoVisible.EditValue);
                Decimal salePrice = Convert.ToDecimal(txtNovisiblePrice.EditValue);
                int inventoryID = Convert.ToInt32(cmbNoVisible.GetColumnValue("ID"));
                string Remarks = txtNoVisibleRemark.EditValue.ToString();
                int Quanitity = Convert.ToInt32(txtNoVisibleQuantity.EditValue);

              
                if (cmbNoVisible.GetSelectedDataRow() is DataAccess.vw_Inventory)// cmbNoVisible.Text != null && cmbNoVisible.Text != "صنف بدون باركود")
                {
                    DataAccess.SaleInvoiceDetail newRow = details.AddNew();
                    newRow.ItemID = itemId;
                    newRow.UnitPrice = salePrice;
                    newRow.InventoryID = inventoryID;
                    newRow.Remarks = Remarks;
                    newRow.Quanitity = Quanitity;

                    string Name = Convert.ToString(cmbNoVisible.GetColumnValue("Name"));
                    if (Name == "صنف بدون باركود")
                    {
                        ////try
                        ////{
                        ////    Thread thread = new Thread(() => PushMessage.SendPush_Message("", "صنف بدون باركود: @" + UserData.Default.BranchName + "-" + UserData.Default.UserName + " (الصنف: " + Remarks + "الكمية " + Quanitity + "السعر " + salePrice + ")", "صنف بدون باركود"));
                        ////    thread.Start();
                        ////}
                        ////catch (Exception ex)
                        ////{
                        ////    //Do nothing 
                        ////}
                       // ModuleClass.SendWhatsAppMessage("ALL", "صنف بدون باركود: @" + UserData.Default.BranchName + "-" + UserData.Default.UserName + " (الصنف: " + Remarks + "الكمية " + Quanitity + "السعر " + salePrice + ")");
                    }



                }
             

                calculateInvoiceTotal();
                gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1;
                txtBar.Focus();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
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
            try
            {
                if (MessageBox.Show("خروج من النظام؟", "نظام رضا بوكشوب", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    //DataAccess.UserLogin login = db.UserLogins.Create();
                    //login.Date = DateTime.Now;
                    //login.UserID = Convert.ToInt32(UserData.Default.UserID);
                    //login.Type = true;//Login Out
                    //login.BranchID = branchID;
                    //db.UserLogins.Add(login);

                    //if (db.SaveChanges() > 0)
                    //{

                    //}
                    //normalLogout = true;
                    //try
                    //{
                    //    Thread thread = new Thread(() => SendEmail(login, db.Users.Where(s => s.ID == login.UserID).SingleOrDefault()));
                        
                    //    thread.Start();
                    //}
                    //catch (Exception ex)
                    //{
                    //    //Do nothing 
                    //}
                    //if (login.User.IsAdmin)
                    //{
                    //    this.Hide();
                    //    new Login().ShowDialog();
                    //}
                    //else
                    {
                       
                        if (new Shif(false).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }

        }
        public void SendEmail(DataAccess.UserLogin login, DataAccess.User ValidUser)
        {
////            string smtpAddress = "smtp.gmail.com";
////            // int portNumber = 587;
////            bool enableSSL = true;
////            string emailFrom = "redasudani@gmail.com";
////            string password = "gqaz1tahaz";
////            string emailTo = "NasirTaha@gmail.com";
////            string subject = "Reda 1";
////            string body = "";
////            string pc = System.Environment.MachineName;
////            string title = "";
////            if (login.Type)//Login Out
////            {
////                body = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " :خروج" + "  Reda " + UserData.Default.BranchID + "  " + pc;
////                title = "خروج";
////            }
////            else//Login In
////            {
////                body = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " : دخول" + " Reda " + UserData.Default.BranchID + "  " + pc;
////                title = "دخول";
////            }
////            using (MailMessage mail = new MailMessage())
////            {
////                mail.From = new MailAddress(emailFrom);
////                mail.To.Add(emailTo);

////                mail.To.Add("sheble233@gmail.com");
////                mail.Subject = body;
////                mail.Body = body;
////                mail.IsBodyHtml = true;
                
               
////                try
////                {
////                    Thread thread = new Thread(() => PushMessage.SendDirectMessage(body));
////                    thread.Start();
////                }
////                catch (Exception ex)
////                {
////                    //Do nothing 
////                }

////                using (SmtpClient smtp = new SmtpClient(smtpAddress))//, portNumber))
////                {
////                    try
////                    {
////#if !DEBUG
////                            smtp.UseDefaultCredentials = false;
////                            smtp.Credentials = new NetworkCredential(emailFrom, password);
////                            smtp.EnableSsl = enableSSL;
////                            smtp.Send(mail);

                        
////#endif
////                    }
////                    catch (Exception ex)
////                    {
////                        //Do nothing 
////                    }
////                }
////            }
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
                    ////DataAccess.UserLogin login = db.UserLogins.Create();
                    ////login.Date = DateTime.Now;
                    ////login.UserID = Convert.ToInt32(UserData.Default.UserID);
                    ////login.Type = true;//Login Out
                    ////login.BranchID = branchID;
                    ////db.UserLogins.Add(login);
                    ////if (db.SaveChanges() > 0)
                    ////{

                    ////}
                    ////try
                    ////{
                    ////    Thread thread = new Thread(() => SendEmail(login, db.Users.Where(s => s.ID == login.UserID).SingleOrDefault()));
                    ////    thread.Start();
                    ////}
                    ////catch (Exception ex)
                    ////{
                    ////    //Do nothing 
                    ////}
                    //////Shared.SendEmail(login, db.Users.Where(s => s.ID == login.UserID).SingleOrDefault());
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
            //FillSaleInvoiceGrid();
        }

        private void btnShowExpire_Click(object sender, EventArgs e)
        {
            try
            {
                ////int ReorderPoint = Convert.ToInt32(txtReorderPoint.EditValue);
                ////vwInventoryBindingSource.DataSource = null;

                ////var list = from s in db.vw_Inventory where s.CurrentQuanity < ReorderPoint select s;
                ////vwInventoryBindingSource.DataSource = list.ToList();
            }
            catch (Exception ex)
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
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                new Transfer().ShowDialog();

                //FillSaleInvoiceGrid();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtSearchAllBranch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            try
            {

                if (e.KeyCode == Keys.Enter && txtSearchAllBranch.Text.Length > 2)
                {
                    string query = txtSearchAllBranch.Text;
                   // int ReorderPoint = Convert.ToInt32(txtReorderPoint.EditValue);
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

        private void gridView3_GroupRowExpanding(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            gridViewFastItems.CollapseAllGroups();
            
        }

        private void gridViewFastItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               
              
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnQuickItems_Click(object sender, EventArgs e)
        {
            try
            {

                PurchaseInvoiceForm frm = new PurchaseInvoiceForm(new DataAccess.PurchaseInvoice(), true, true);
                frm.Show();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnExpenseRPT_Click(object sender, EventArgs e)
        {
            try
            {
                ExpenseReportOptions frm = new ExpenseReportOptions();
                frm.ShowDialog();

               //// ExpenseRPT rpt = new ExpenseRPT();
               ////// string BranchName = cmbBranch.GetColumnValue("BranchName").ToString();
               ////// rpt.parameterBranchName.Value = BranchName;
               //// int userId = Convert.ToInt32(UserData.Default.UserID);
               //// var list = db.vw_Expense.Where(s => s.BranchID == branchID && s.InsertedUserId == userId && s.Date.Year == cmbDate.DateTime.Year && s.Date.Month == cmbDate.DateTime.Month && s.Date.Day == cmbDate.DateTime.Day);
               //// if (list.Any())
               //// {
               ////     rpt.DataSource = list.ToList();
               ////     rpt.parameterBranchName.Value = UserData.Default.BranchID;
               ////     rpt.parameterFromDate.Value = DateTime.Now;
               ////     rpt.parameterToDate.Value = UserData.Default.UserName;

               
               ////     try
               ////     {
               ////         ReportPrintTool tool = new ReportPrintTool(rpt);
               ////         tool.ShowPreview();
               ////     }
               ////     catch (Exception ex)
               ////     {
               ////          ModuleClass.ShowMessage(this, ex, "خطأ", null);
               ////     }
               //// }
               //// else
               //// {
               ////     MessageBox.Show("لا توجد منصرفات في هذا التاريخ");
               //// }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnExpire_Click(object sender, EventArgs e)
        {
            try
            {
                new SaleInvoiceForm(new DataAccess.SaleInvoice(), true, SaleInvoiceType.Expire).Show();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void dockPanelReturn_Click(object sender, EventArgs e)
        {

        }

        private void btnSaleInvoiceSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(txtSaleInvoiceID.EditValue);
                var list = from s in db.vw_SaleReport where s.ID == ID && s.BranchID == branchID select s;
                vwSaleReportBindingSource.DataSource = list.ToList();
                gridViewSaleInvoice.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
        void FillSaleInvoiceGrid()
        {
            try
            {
               
                int userID = Convert.ToInt32(cmbUsers.GetColumnValue("ID"));

                DateTime date = cmbSaleInvoiceDateFrom.DateTime;
                DateTime start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                DateTime end = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

                // var list = from s in db.vw_SaleReport where s.Date > start && s.Date < end && s.Flag != 0 select s;
                var list = from s in db.vw_SaleReport where s.Flag != 0 && s.UserID == userID && s.Date > start && s.Date < end && s.BranchID == branchID select s;
                vwSaleReportBindingSource.DataSource = list.ToList();
                gridViewSaleInvoice.ExpandAllGroups();



                decimal? totalOfSale = (from s in list select s.Total).Sum();
                int noOfInvoices = (from s in list where s.Flag == 1 select s.Total).Count();
              
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }


        }
        private void repositoryItemButtonEditSaleInvoice_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
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
                                new ReturnForm(list, currentRow.ID).ShowDialog();
                                FillSaleInvoiceGrid();

                                
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
                            if (currentRow != null)
                            {
                                var row = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                                SaleRpt rpt = new SaleRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), 0, 0, currentRow.ID.ToString(), currentRow.UserName.ToString());
                                var list = db.vw_Sale2.Where(s => s.SaleInvoiceID == row.ID).ToList<DataAccess.vw_Sale2>();


                                rpt.DataSource = list.ToList();
                                ReportPrintTool tool = new ReportPrintTool(rpt);
                                string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
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

        private void btnShowSaleInvoice_Click_1(object sender, EventArgs e)
        {
            FillSaleInvoiceGrid();
        }

        private void btnShiftReport_Click(object sender, EventArgs e)
        {
            try
            {

                ShiftRPT rpt = new ShiftRPT();
                int userId = Convert.ToInt32(cmbUsersRPT.EditValue);
                var list = db.Shifts.Where(s => s.BranchID == branchID && s.UserId == userId && s.LoginTime.Year == cmbDate.DateTime.Year && s.LoginTime.Month == cmbDate.DateTime.Month && s.LoginTime.Day == cmbDate.DateTime.Day);//.SingleOrDefault();
                if (list != null)
                {
                    //rpt.DataSource = list.ToList();
                    //int branchId = list.First().BranchID;
                   // int UserId = list.First().UserId;
                    rpt.parameterBranchName.Value = db.Branches.Where(s => s.ID == branchID).SingleOrDefault().BranchName;
                    rpt.parameterUserName.Value = db.Users.Where(s => s.ID == userId).SingleOrDefault().UserName;
                         rpt.RequestParameters = false;
                         rpt.DataSource = list.ToList();
                    //rpt.parameterBranchName.Value = UserData.Default.BranchID;
                    //rpt.parameterDate.Value = cmbDate.DateTime;
                    //rpt.parameterInsertedUser.Value = UserData.Default.UserName;
                    try
                    {
                        ReportPrintTool tool = new ReportPrintTool(rpt);
                        tool.ShowPreview();
                    }
                    catch (Exception ex)
                    {
                         ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                    }
                }
                else
                {
                    MessageBox.Show("لا توجد ورديه في هذا التاريخ");
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtReturnSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                //if(query.Length>=2)
                //{
                //    var list = db.vw_Sale2.Where(s => s.Name.Contains(query));
 
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test");
            }
        }

        private void txtReturnSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                ////  itemBindingSource1.DataSource = null;
                //string query = txtReturnSearch.Text;
                //if (e.KeyCode == Keys.Enter && query.Length > 2)
                //{
                //    var list = db.Items.Local.Where(s => s.Name.Contains(query));
                //    itemBindingSource1.DataSource = list;
                //}
                //else
                //{
                //    itemBindingSource1.DataSource = null;
                //}

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            try
            {
#if !DEBUG

                 string password = Prompt.ShowDialog("كلمة المرور:", "شاشة مخصصة");
                if (password.ToLower() == "1qaz")
                {
                    XtraForm frm = new XtraForm();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Controls.Add(new StockingUC());
                    frm.Controls[0].Dock = DockStyle.Fill;
                    int branchId = Convert.ToInt32(UserData.Default.BranchID);
                    frm.Text = "فواتير جرد لفرع:" + db.Branches.Where(s => s.ID == branchId).Select(s => s.BranchName).SingleOrDefault();
                    frm.Show();
                }

#else
               XtraForm frm = new XtraForm();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Controls.Add(new StockingUC());
                    frm.Controls[0].Dock = DockStyle.Fill;
                    int branchId = Convert.ToInt32(UserData.Default.BranchID);
                    frm.Text = "فواتير جرد لفرع:" + db.Branches.Where(s => s.ID == branchId).Select(s => s.BranchName).SingleOrDefault();
                    frm.Show();
#endif

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        

        private void dockPanelOperations_Click(object sender, EventArgs e)
        {
            try
            {
                new About().ShowDialog();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtWhatsAppMessage_Enter(object sender, EventArgs e)
        {
          
        }

        private void txtWhatsAppMessage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(txtWhatsAppMessage.Text.Length<3)
                    {
                       // txtWhatsAppMessage.Text = "";
                        return;
                    }

                    try
                    {
                        Thread thread = new Thread(() => PushMessage.SendDirectMessage(txtWhatsAppMessage.Text));
                        thread.Start();
                    }
                    catch (Exception ex)
                    {
                        //Do nothing 
                    }
                   if( SendWhatsAppMessage("All","رسالة مباشرة"))
                   {
                       if (UserData.Default.WhatsAppHistory == null)
                       {
                           UserData.Default.WhatsAppHistory = new System.Collections.Specialized.StringCollection();
                       }
                       CultureInfo culture = new CultureInfo("ar");
                       string datepattern = culture.DateTimeFormat.LongDatePattern;
                       DateTimeFormatInfo datetimeFormatInfo = new DateTimeFormatInfo();
                       datetimeFormatInfo.LongDatePattern = "yyyy-M-dd:HH:mm";
                       culture.DateTimeFormat = datetimeFormatInfo;
                       Thread.CurrentThread.CurrentCulture = culture;


                       UserData.Default.WhatsAppHistory.Add(DateTime.Now.ToLongDateString() + ": (" + UserData.Default.UserName + "): " + txtWhatsAppMessage.Text.Replace(Environment.NewLine, ""));
                      // txtWhatsAppMessage.Text = "";
                   }
                   else
                   {
                       MessageBox.Show("لم يتم ارسال الرساله، حاول مرة اخري");
                   }

                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private bool SendWhatsAppMessage(string to, string title)
        {
            //return ModuleClass.SendWhatsAppMessage(to, txtWhatsAppMessage.Text);
            try
            {
                Thread thread = new Thread(() => PushMessage.SendDirectMessage(txtWhatsAppMessage.Text));
                thread.Start();
            }
            catch (Exception ex)
            {
                //Do nothing 
            }
            return true;
        }

        private void btnWhatsAppHistory_Click(object sender, EventArgs e)
        {

        }
        // <previewPanel>
        void OnPreviewPanelMouseEnter(object sender, EventArgs e)
        {
            if (UserData.Default.WhatsAppHistory != null)
            {
                txtWhatsAppHistory.Text = "";
                foreach (var item in UserData.Default.WhatsAppHistory)
                {
                    txtWhatsAppHistory.Text += item;
                    txtWhatsAppHistory.Text += Environment.NewLine;
                }
               
                EnsureShowBeakForm();
            }
        }
        void EnsureShowBeakForm()
        {
            if (flyoutPanel1.FlyoutPanelState.IsActive) return;
            flyoutPanel1.ShowBeakForm(GetHotPoint());
        }
        Point GetHotPoint()
        {
            Point pt = new Point(this.previewPanel.Width / 2, 0);
            //  if (this.cbeBeakLocation.EditValue.Equals(BeakPanelBeakLocation.Top))
            {
                pt.Y += this.previewPanel.Height;
            }
            return this.previewPanel.PointToScreen(pt);
        }

        private void flyoutPanel1_ButtonClick(object sender, DevExpress.Utils.FlyoutPanelButtonClickEventArgs e)
        {
            string tag = e.Button.Tag as string;
            if (string.Equals(tag, "Exit", StringComparison.OrdinalIgnoreCase))
            {
                this.flyoutPanel1.HideBeakForm();
            }
        }

        private void cmbNoVisible_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbNoVisible.GetSelectedDataRow() is  DataAccess.vw_Inventory )// cmbNoVisible.Text != null && cmbNoVisible.Text != "صنف بدون باركود")
                {
                    decimal salePrice = Convert.ToDecimal(cmbNoVisible.GetColumnValue("SalePrice"));
                    txtNovisiblePrice.EditValue = salePrice;
                    
                    string Name = Convert.ToString(cmbNoVisible.GetColumnValue("Name"));
                    if (Name == "صنف بدون باركود")
                    {
                        txtNoVisibleRemark.Text = "";
                        txtNoVisibleRemark.Focus();
                    }
                    else
                    {
                        txtNoVisibleRemark.Text = Name;// cmbNoVisible.Text;
                        txtNoVisibleQuantity.Focus();
                    }
                   

                    
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void hideContainerRight_Click(object sender, EventArgs e)
        {

        }
    }
}
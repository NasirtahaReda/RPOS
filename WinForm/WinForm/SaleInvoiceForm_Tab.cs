using System;
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
using DataAccess;
using MsgBox;
using DevExpress.XtraGrid.Columns; 

namespace WinForm
{
  
    public partial class SaleInvoiceForm_Tab : DevExpress.XtraEditors.XtraUserControl
    {
        bool refreshFastItem = false;
        int branchID = 0;
        string InvoicePrinter = "";
        private DataAccess.SaleInvoice invoice;
        DataAccess.RedaV1Entities db;// = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
        BindingList<DataAccess.SaleInvoiceDetail> details = null;
        //bool _Transfer = false;
        int _trnasferFrom;
        int _trnasferTo;
        SaleInvoiceType _saleInvoiceType;

        bool normalLogout = false;
        WhatsApp wa = null;
        Encoding tmpEncoding = Encoding.UTF8;
           
    
     
           static List<vw_Inventory> inv_List;
        public SaleInvoiceForm_Tab( DataAccess.RedaV1Entities db, List<Item> items, DataAccess.SaleInvoice invoice, bool isNew, SaleInvoiceType saleInvoiceType, int trnasferFrom = 1, int trnasferTo = 2)
        {
            int val = 0;
            try
            {
               
                //MessageBox.Show("OK5");
                InitializeComponent();
                val = 1;
                this.db = db;
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute assembly = executingAssembly.GetCustomAttribute<AssemblyTitleAttribute>();
                AssemblyFileVersionAttribute assemblyVersion = executingAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
                string title = assembly.Title + " " + assemblyVersion.Version + " ( " + UserData.Default.UserName + " ) ";// +branch.BranchName;
                val = 2;
                _saleInvoiceType = saleInvoiceType;
                //  _Transfer = Transfer;
                _trnasferFrom = trnasferFrom;
                _trnasferTo = trnasferTo;
                branchID = Convert.ToInt32(UserData.Default.BranchID);
                val = 3;
                inv_List = db.vw_Inventory.Where(s => s.BarcodeText.StartsWith("0000") && s.BranchID == branchID).ToList();
                bindingSourceNoVisibleItems.DataSource = inv_List;
                //MessageBox.Show("OK6");
                if (saleInvoiceType == SaleInvoiceType.Transfer)
                {
                    var from = db.Branches.Where(s => s.ID == _trnasferFrom).SingleOrDefault();
                    var to = db.Branches.Where(s => s.ID == _trnasferTo).SingleOrDefault();
                    branchID = trnasferFrom;
                    this.Text = "التحويل من " + from.BranchName + "  الي " + to.BranchName;

                }
                else
                    if (saleInvoiceType == SaleInvoiceType.Sale)
                    {
                        int branchId = Convert.ToInt32(UserData.Default.BranchID);
                        this.Text = "فاتورة بيع - :" + db.Branches.Where(s => s.ID == branchId).Select(s => s.BranchName).SingleOrDefault() + " - " + title;

                    }
                if (saleInvoiceType == SaleInvoiceType.Expire)
                {
                    int branchId = Convert.ToInt32(UserData.Default.BranchID);
                    this.Text = "فاتورة تالف - :" + db.Branches.Where(s => s.ID == branchId).Select(s => s.BranchName).SingleOrDefault();

                }
                val = 4;
                //MessageBox.Show("OK7");
                bindingSourceTempItems.DataSource = db.vw_TempItem.Where(s => s.BranchID == branchID).ToList();// db.vw_TempItem.Local.ToBindingList();




                details = new BindingList<DataAccess.SaleInvoiceDetail>();


                this.bindingSourceSaleInvoiceDetails.DataSource = details;

                this.bindingSourceItem.DataSource = items;
                val = 5;

                var users = from s in db.Users where s.IsEnable == true select s;
                userBindingSource.DataSource = users.ToList();
                db.ItemBarcodes.Load();
                InvoicePrinter = db.Companies.Take(1).SingleOrDefault().InvoicePrinter;
                //  BarcodePrinter = db.Companies.Take(1).SingleOrDefault().BarcodePrinter;
                //MessageBox.Show("OK8");
                SetMarqueeText();
                val = 6;
            }
            catch (Exception ex)
            {
                MessageBox.Show(val.ToString());
                if (ex != null && ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message, ex.Message);
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void SetMarqueeText()
        {
            try
            {
                //MessageBox.Show("OK9");
                //DateTime expireDate = DateTime.Now.AddDays(s.LifetimeDays) 
                var marqueeText = db.MarqueeMessages.Where(s => s.BranchID == branchID && s.Date > DateTime.Now).Select(s => s.Message).ToList();
                if (marqueeText == null || marqueeText.Count() == 0)
                {
                    lblMarqueeText.Text = "";
                    return;
                }
                //MessageBox.Show("OK10");
                StringBuilder text = new StringBuilder();
                foreach (var item in marqueeText)
                {
                    text.Append(item).Append("      -      ");
                }

                lblMarqueeText.Text = text.ToString();
                //MessageBox.Show("OK10");
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void SaleInvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                

                
              
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        
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
                if (details.Count() <= 0)
                {
                    MessageBox.Show("الفاتورة لا تحتوي علي أصناف", "طباعة فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                List<DataAccess.vw_Sale2> rptList = new List<DataAccess.vw_Sale2>();
                DataAccess.vw_Sale2 obj ;//= new DataAccess.vw_Sale2();
                for (int rowHandle = 0; rowHandle < gridViewInvoice.RowCount; rowHandle++)
                {
                    string ItemName = gridViewInvoice.GetRowCellDisplayText(rowHandle, colItemID);
                    string UnitPrice = gridViewInvoice.GetRowCellDisplayText(rowHandle, colUnitPrice);
                    string Quanitity = gridViewInvoice.GetRowCellDisplayText(rowHandle, colQuanitity);
                    string Remarks = gridViewInvoice.GetRowCellDisplayText(rowHandle, colRemarks);
                    obj = new DataAccess.vw_Sale2();
                    obj.Name = ItemName;
                    obj.UnitPrice = Convert.ToDecimal( UnitPrice);
                    obj.Quanitity = Convert.ToInt32( Quanitity);
                    obj.Remarks = Remarks;
                    
                    rptList.Add(obj);
                }
                if(_saleInvoiceType == SaleInvoiceType.Expire)
                {
                    if (MessageBox.Show("هل انت متأكد من إتمام عملية التالف؟", "فاتورة تالف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataAccess.SaleInvoice invoice = new DataAccess.SaleInvoice();
                        invoice.Date = DateTime.Now;
                        invoice.UserID = Convert.ToInt32(UserData.Default.UserID);
                        invoice.Remarks = "Expire";

                        invoice.BranchID = branchID;
                        invoice.Flag = 0;

                        db.SaleInvoices.Add(invoice);
                        //I use a trigger to update inventory
                        decimal invoiceTotal = 0;
                        string message = " تالف من الفرع " + UserData.Default.BranchName + " المستخدم " + UserData.Default.UserName + Environment.NewLine;
                        foreach (var item in details)
                        {
                            item.SaleInvoiceID = invoice.ID;
                            invoice.SaleInvoiceDetails.Add(item);
                            invoiceTotal += (item.UnitPrice * item.Quanitity);

                         
                        }
                        GridViewInfo viewInfo = gridViewInvoice.GetViewInfo() as GridViewInfo;
                        //foreach (GridRowInfo rowInfo in viewInfo.RowsInfo)
                        

                        for (int i = 0; i < gridViewInvoice.RowCount; i++)
                        {
                            var dataRow = gridViewInvoice.GetDataRow(i);
                            var row = gridViewInvoice.GetRow(i);//, "Quanitity");
                            int rowHandle = gridViewInvoice.GetVisibleRowHandle(i);
                            if (gridViewInvoice.IsDataRow(rowHandle))
                            {
                                var name = gridViewInvoice.GetRowCellDisplayText(rowHandle, colItemID);
                                var qnt = gridViewInvoice.GetRowCellDisplayText(rowHandle, colQuanitity);
                                message += qnt + " من " + name + Environment.NewLine;
                            }
                           
                        }
                        
                        invoice.Total = invoiceTotal;// Convert.ToDecimal(total.Text);
                        invoice.Discount = 0;// Convert.ToDecimal(txtDiscount.Text);
                        int savedRows = db.SaveChanges();
                        if (savedRows > 0)
                        {
                            invoice.Flag = 1;//To call trigger
                            savedRows = db.SaveChanges();
                            if (savedRows > 0)
                            {
                                PushMessage.SendDirectMessage(message);
                                toggleSwitchSaleOrExpire.Toggle();
                                IntilizeInvoice();
                                

                            }
                        }
                    }

                }
                else
                if (new SaleInvoiceConfirm(rptList, details, db, InvoicePrinter).ShowDialog() == DialogResult.OK)
                {
                    IntilizeInvoice();
                }
////                decimal invoiceTotal = 0;
////                foreach (var item in details)
////                {
////                    invoiceTotal += (item.UnitPrice * item.Quanitity);
////                }
////                decimal discount = Convert.ToDecimal(txtDiscount.EditValue);
////                if(discount>(invoiceTotal*10/100))
////                {
////                    MessageBox.Show("أكبر تخفيض يمكن منحه هو:" + (invoiceTotal * 10 / 100) +"  جنيه ", "قيمة التخفيض أكبر من 10% من مجموع الفاتورة");

////                    return;
////                }
////                string msg = "";
////                if(doPrint)
////                {
////                    msg = "تأكيد وطباعه الفاتورة";
////                }
////                else
////                {
////                    msg = "تأكيد بدون طباعه الفاتورة";
////                }
////                if (details.Count() <= 0)
////                {
////                    MessageBox.Show("الفاتورة لا تحتوي علي أصناف", "طباعة فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
////                    return;
////                }
////                bool confirmPrint = true;
////                if(confirm)
////                {
////                    if (MessageBox.Show(msg, "تاكيد البيع", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
////                    {
////                        confirmPrint = true;
////                    }
////                    else
////                    {
////                        confirmPrint = false;
////                    }
////                }
               
////                if (confirmPrint)// MessageBox.Show( msg,"تاكيد البيع", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
////                {
////                    calculateInvoiceTotal();
////                    //Close invoice
////                    invoice = new DataAccess.SaleInvoice();
////                    invoice.Date = DateTime.Now;
////                    invoice.UserID = Convert.ToInt32(UserData.Default.UserID);
////                    if (_saleInvoiceType == SaleInvoiceType.Sale)
////                    {
////                        invoice.Remarks = "Sale";
////                    }
////                    else
////                        if (_saleInvoiceType == SaleInvoiceType.Transfer)
////                        {
////                            branchID = _trnasferFrom;
////                            invoice.Remarks = "Transfer";
////                        }
////                        else
////                            if (_saleInvoiceType == SaleInvoiceType.Expire)
////                            {
////                                invoice.Remarks = "Expire";
////                            }

////                    invoice.BranchID = branchID;
////                    invoice.Flag = 0;
                   
////                    db.SaleInvoices.Add(invoice);
////                    //I use a trigger to update inventory
////                    foreach (var item in details)
////                    {
////                        item.SaleInvoiceID = invoice.ID;
////                        invoice.SaleInvoiceDetails.Add(item);
////                        v.CurrentQuanity -= item.Quanitity;
////                    }
////                    invoice.Total = Convert.ToDecimal(txtInvoiceTotal.Text);
////                    invoice.Discount = Convert.ToDecimal(txtDiscount.Text);
////                    int savedRows = db.SaveChanges();
////                    if(savedRows>0)
////                    {
////                        invoice.Flag = 1;//To call trigger
////                        db.SaveChanges();
////                        if (_saleInvoiceType == SaleInvoiceType.Transfer)
////                        {
////                            DataAccess.PurchaseInvoice TransferPurchaseInvoice = db.PurchaseInvoices.Create();
////                            TransferPurchaseInvoice.BranchID = _trnasferTo;
////                            TransferPurchaseInvoice.Date = DateTime.Now;
////                            TransferPurchaseInvoice.Discount = 0;
////                            TransferPurchaseInvoice.Flag = 0;
////                            TransferPurchaseInvoice.Number = "Transfer " + invoice.ID;
////                            TransferPurchaseInvoice.Total = 0;
////                            TransferPurchaseInvoice.UserID = Convert.ToInt32(UserData.Default.UserID);
                            
////                            DataAccess.PurchaseInvoiceDetail child;
////                            foreach (var item in details)
////                            {
////                                child = db.PurchaseInvoiceDetails.Create();
////                                child.DiscountPrice = 0;
////                                child.ItemID = item.ItemID;
////                                child.PurchasePrice = item.UnitPrice;
////                                child.Quantity = item.Quanitity;
////                                child.Remarks = "TrasferInvoice From Reda " + branchID + "  "+invoice.ID;
////                                child.SalePrice = item.UnitPrice;


////                                TransferPurchaseInvoice.PurchaseInvoiceDetails.Add(child);
////                            }

////                            db.PurchaseInvoices.Add(TransferPurchaseInvoice);
////                            savedRows = db.SaveChanges();
////                            if (savedRows > 0)
////                            {
////                                TransferPurchaseInvoice.Flag = 1;
////                                savedRows = db.SaveChanges();
////                                if (savedRows > 0)
////                                {
////                                    MessageBox.Show("اكتمل عملية تحويل البضاعه بنجاح");
////                                    ////this.Close();
////                                }
////                            }

////                        }
////                        if(refreshFastItem)
////                        {
////                            bindingSourceTempItems.DataSource = db.vw_TempItem.Where(s => s.BranchID == branchID).ToList();
////                            refreshFastItem = false;
////                        }
////                    }
                  
////                    Reports.SaleRpt rpt = new SaleRpt(Convert.ToDecimal(txtDiscount.EditValue), Convert.ToDecimal(txtAfterDiscount.EditValue), this.invoice.ID.ToString(), UserData.Default.UserName);
////                    var list = from s in db.vw_Sale2 where s.SaleInvoiceID == invoice.ID select s;
////                    rpt.DataSource = list.ToList();

////                    txtAfterDiscount.EditValue = 0;
////                    txtInvoiceTotal.EditValue = 0;
////                    txtDiscount.EditValue = 0;
////                    try
////                    {
////                        if (doPrint)
////                        {
////                            ReportPrintTool tool = new ReportPrintTool(rpt);
////                            string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
////                            if(InvoicePrinter == "")
////                            {
////                                tool.Print();
////                            }
////                            else
////                            {
////                                tool.Print(InvoicePrinter);
////                            }
////                        }
////                        DataAccess.vw_Inventory localInv;
////                       Where(s => s.BranchID == branchID).Load();
////                    }
////                    catch (Exception ex)
////                    {
////                         ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
////                    }

////                    //Refresh Form
////                    details = new BindingList<DataAccess.SaleInvoiceDetail>();
////                    bindingSourceSaleInvoiceDetails.DataSource = details;
////                    bindingSourceInventory.DataSource = null;
////                }

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void IntilizeInvoice()
        {
            //Refresh Form
            details = new BindingList<DataAccess.SaleInvoiceDetail>();
            bindingSourceSaleInvoiceDetails.DataSource = details;
            bindingSourceInventory.DataSource = null;

            if (refreshFastItem)
            {
                bindingSourceTempItems.DataSource = db.vw_TempItem.Where(s => s.BranchID == branchID).ToList();
                refreshFastItem = false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.Control | Keys.I))
                {

                    //string password = Prompt.ShowDialog("كلمة المرور:", "شاشة مخصصة");
                    //if (password.ToLower() == "1qaz")
                    {
                        new Inventory_Direct().Show();

                        return true;
                    }
                   
                }
                else
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
                        if (keyData == Keys.F3)
                        {
                            txtSearch.Focus();
                            return true;
                        }
                        else
                if (keyData == (Keys.Up))
                {
                    IncreaseFoucsRow();
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
                                }else
                                    if (keyData == (Keys.Oemplus))
                                    {
                                       // if(gri)
                                    }
                                    else
                                        if (keyData == (Keys.Control | Keys.Subtract))
                                    {
                                        gridViewInvoice.Appearance.Row.Font = new Font(gridViewInvoice.Appearance.Row.Font.FontFamily, gridViewInvoice.Appearance.Row.Font.Size - 1);
                                        gridViewFastItems.Appearance.Row.Font = new Font(gridViewInvoice.Appearance.Row.Font.FontFamily, gridViewInvoice.Appearance.Row.Font.Size - 1);
                                        gridViewSearch.Appearance.Row.Font = new Font(gridViewInvoice.Appearance.Row.Font.FontFamily, gridViewInvoice.Appearance.Row.Font.Size - 1);
                                    }
                                        else
                                            if (keyData == (Keys.Control | Keys.Add))
                                            {
                                                gridViewInvoice.Appearance.Row.Font = new Font(gridViewInvoice.Appearance.Row.Font.FontFamily, gridViewInvoice.Appearance.Row.Font.Size+ 1);
                                               gridViewFastItems.Appearance.Row.Font = new Font(gridViewInvoice.Appearance.Row.Font.FontFamily, gridViewInvoice.Appearance.Row.Font.Size + 1);
                                               gridViewSearch.Appearance.Row.Font = new Font(gridViewInvoice.Appearance.Row.Font.FontFamily, gridViewInvoice.Appearance.Row.Font.Size + 1);

                                            }

                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                return false;
            }
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
            try{
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                //   if(MessageBox.Show("Are you sure ?","Delete current Item",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataAccess.SaleInvoiceDetail currentRow = (DataAccess.SaleInvoiceDetail)gridViewInvoice.GetFocusedRow();
                    details.Remove(currentRow);
                    //int rows = db.SaveChanges();
                    calculateInvoiceTotal();

                    ////if (db.SaveChanges()>0)
                    {
                        ShowMessageInStatusBar("item remove successfully", 9000);
                    }
                }
            }
}
                catch (Exception ex)
                {
                    ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
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
                string query = txtSearch.Text;
                if (e.KeyCode == Keys.Enter && txtSearch.Text.Length > 2)
                {

                    //  db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());

                    bindingSourceInventory.DataSource = (from s in db.vw_Inventory where s.CurrentQuanity > 0 && s.Name.Contains(query) && s.BranchID == branchID select s).ToList();// db.vw_Inventory.ToList();
                }
                else
                    if (e.KeyCode == Keys.Enter && (txtSearch.Text.Length == 1 || txtSearch.Text.Length == 2))
                {
                    //this.bindingSourceInventory.DataSource = null;
                    int QuickCode;
                    if (Int32.TryParse(query, out QuickCode))
                    {
                        DataAccess.Item itm = db.Items.Where(s => s.QuickCode == QuickCode).SingleOrDefault();
                        if (itm != null)
                        {
                            vw_Inventory newItem = (from s in db.vw_Inventory where s.CurrentQuanity > 0 && s.QuickCode == QuickCode && s.BranchID == branchID select s).SingleOrDefault();// db.vw_Inventory.ToList();
                            if (newItem != null)
                            {
                                AddToInvoice(newItem);
                            }
                            else

                            {
                                //  MessageBox.Show(   " الصنف ("+ itm.Name+ ") غير متوفر بالمخزن ", query);
                                var item = itm;// ItemsFound.First().Item;
                                InputBox.SetLanguage(InputBox.Language.English);
                                //Save the DialogResult as res
                                DialogResult res = InputBox.ShowDialog(" الكمية : ", item.Name + " يمكن إضافة الصنف بدون باركود   ",   //Text message (mandatory), Title (optional)
                                    InputBox.Icon.Question,                                                                         //Set icon type Error/Exclamation/Question/Warning (default info)
                                    InputBox.Buttons.OkCancel,                                                                      //Set buttons set OK/OKcancel/YesNo/YesNoCancel (default ok)
                                    InputBox.Type.TextBox,                                                                         //Set type ComboBox/TextBox/Nothing (default nothing)
                                    new string[] { "Item1", "Item2", "Item3" },                                                        //Set string field as ComboBox items (default null)
                                    true,                                                                                           //Set visible in taskbar (default false)
                                    new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));                        //Set font (default by system)
                                                                                                                                    //Check InputBox result
                                if (((InputBox.ResultValue != "") && (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)))
                                {
                                    string Remarks = "";
                                    Int16 quantity = Convert.ToInt16(InputBox.ResultValue);
                                    DataAccess.SaleInvoiceDetail newRow = details.AddNew();
                                    newRow.ItemID = item.ID;
                                    newRow.UnitPrice = Convert.ToDecimal(item.SalePrice);
                                    newRow.InventoryID = 11539;// inventoryID;
                                    newRow.Remarks = "Zero QTY";
                                    newRow.Quanitity = quantity;
                                    newRow.CurrentQuanitity = -1;
                                    calculateInvoiceTotal();
                                    gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1;
                                    txtBar.Text = "";
                                    txtBar.Focus();

                                }

                                txtSearch.SelectAll();
                            }   
                        }
                        else
                        {
                            MessageBox.Show("لا يوجد صنف بهذا الرقم المدخل", query);
                            txtSearch.SelectAll();
                        }
                    }

                }
                else
                {
                   // this.bindingSourceInventory.DataSource = null;
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

            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                AddToInvoice((DataAccess.vw_Inventory)gridViewSearch.GetRow(info.RowHandle));
                //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }

        }

        private void txtBarcodetext_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //txtBarcodetext.Text = "";
            calculateInvoiceTotal();
            txtBar.Focus();
        }

        private void calculateInvoiceTotal()
        {
            ////decimal invoiceTotal = 0;
            ////foreach (var item in details)
            ////{
            ////    invoiceTotal += (item.UnitPrice * item.Quanitity);
            ////}
            ////decimal discount = Convert.ToDecimal(txtDiscount.EditValue);
            ////decimal afterDiscount = invoiceTotal - discount;
            ////txtAfterDiscount.EditValue = afterDiscount;
            ////txtInvoiceTotal.EditValue = invoiceTotal;
            gridViewInvoice.UpdateSummary();
            gridViewInvoice.BeginSort();
            try
            {
                gridViewInvoice.ClearSorting();
                gridViewInvoice.Columns["ID"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
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
                ////    db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
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
                ////string barcodeText = txtBar.Text;
                ////if (txtBar.Text != "")
                ////{

                ////    if (txtBar.Text.Length >= 6)
                ////    {
                ////        var inventoryFound = (from s in db.vw_Inventory where (s.BarcodeText == barcodeText || s.OriginalBarcodeText== barcodeText) && s.CurrentQuanity > 0 && s.BranchID == branchID select s).ToList();
                ////        if (inventoryFound.Count() > 1)
                ////        {
                ////            this.bindingSourceInventory.DataSource = inventoryFound; // db.vw_Inventory.ToList();
                ////            return;
                ////        }
                ////        else
                ////            if (inventoryFound.Count() == 1)
                ////            {
                ////                this.bindingSourceInventory.DataSource = null;

                ////                //DataAccess.Item item = (from s in db.Items where s.BarcodeText == barcodeText select s).SingleOrDefault();
                ////                if (inventoryFound[0] != null)
                ////                {
                ////                    int itemID = inventoryFound[0].ItemID;
                ////                    //var checkList = from s in db.vw_Inventory where s.ItemID == itemID select s;
                ////                    //if (checkList.Count() > 0)
                ////                    {
                ////                        //increase existing item qnt
                ////                        //var listFound = (from s in db.vw_Inventory where s.ItemID == itemID && s.CurrentQuanity > 0 select s).First();
                ////                        foreach (var i in details)
                ////                        {
                ////                            if (i.InventoryID == inventoryFound[0].ID)
                ////                            {
                ////                                IncreaseQuantity();
                ////                                this.bindingSourceInventory.DataSource = null;
                ////                                txtBar.Text = "";
                ////                                return;
                ////                            }
                ////                        }

                ////                        Console.Beep();
                ////                        DataAccess.SaleInvoiceDetail newRow = details.AddNew();
                ////                        newRow.ItemID = itemID;
                ////                        newRow.Quanitity = 1;
                ////                        if (_saleInvoiceType == SaleInvoiceType.Transfer || _saleInvoiceType == SaleInvoiceType.Expire)
                ////                        {
                ////                            newRow.UnitPrice = Convert.ToDecimal(inventoryFound[0].PurchasePrice);
                ////                        }
                ////                        else
                ////                            if (_saleInvoiceType == SaleInvoiceType.Sale )
                ////                            {
                ////                                newRow.UnitPrice = Convert.ToDecimal(inventoryFound[0].SalePrice);
                ////                            }
                ////                        newRow.InventoryID = inventoryFound[0].ID;
                ////                        txtBar.Text = "";
                ////                        //calculateInvoiceTotal();
                ////                        txtBar.Focus();
                ////                        calculateInvoiceTotal();
                ////                        this.bindingSourceInventory.DataSource = null;
                ////                        gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1;
                ////                    }
                ////                }
                ////            }
                ////            else
                ////                 if (inventoryFound.Count() < 1)
                ////                 {
                ////                     this.bindingSourceInventory.DataSource = null;
                ////                    // txtBar.Text = "";
                ////                     //calculateInvoiceTotal();
                ////                     //txtBar.Focus();
                ////                     //Console.Beep(5000, 2000);
                ////                 }

                ////    }
                ////}
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
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (gridViewSearch.GetFocusedRow() is DataAccess.vw_Inventory)
                    {
                        AddToInvoice((DataAccess.vw_Inventory)gridViewSearch.GetFocusedRow());
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        void AddToInvoice(DataAccess.vw_Inventory Row)
        {
            DataAccess.vw_Inventory currentRow = Row;// (DataAccess.vw_Inventory)gridViewSearch.GetFocusedRow();
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

            //- I repleace this code with SendItemWithoutBarcode in modul class

            //
            ////if ((currentRow.CurrentQuanity + 1) <= currentRow.ReorderPoint)
            ////{
            ////    //ModuleClass.SendWhatsAppMessage("ALL",);
            ////    try
            ////    {
            ////        string message = "Reda" + branchID +": " + currentRow.Name + "  <  "+ currentRow.ReorderPoint;
            ////        Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage("", message));
            ////        thread.Start();
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        //Do nothing 
            ////    }
            ////}
            //

            newRow.InventoryID = currentRow.ID;
            txtBar.Text = "";
            lblInventoryQuantity.Text = "";
            lblItemName.Text = "";
            calculateInvoiceTotal();
            txtBar.Focus();
            calculateInvoiceTotal();
            gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1;
        }
       
        private void repositoryItemButtonEditAddQuantity_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.Up)
                {
                    IncreaseFoucsRow();
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

        private void IncreaseQuantity(int ItemId, int RowHandle)
        {
            try
            {
                if (gridViewInvoice.GetFocusedRow() is DataAccess.SaleInvoiceDetail)
                {
                    foreach (var item in details)
                    {
                        if (item.ItemID == ItemId)
                        {
                            var AllCurrentQuanity = (from s in db.vw_Inventory where s.ID == item.InventoryID && s.CurrentQuanity > 0 select s.CurrentQuanity).Sum(); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);
                            if (item.Quanitity < AllCurrentQuanity)
                            {
                                Console.Beep();//5000, 1000);
                                item.Quanitity++;
                                gridControlInvoice.RefreshDataSource();
                                // gridViewInvoice.RefreshRow(RowHandle);
                                break;
                            }
                            else
                            {
                                Console.Beep(5000, 100);
                                //    SystemSounds.Beep.Play();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        void IncreaseFoucsRow()
        {
            if (gridViewInvoice.GetFocusedRow() is DataAccess.SaleInvoiceDetail)
            {

                ////DataAccess.SaleInvoiceDetail currentRow = (DataAccess.SaleInvoiceDetail)gridViewInvoice.GetFocusedRow();
                ////var AllCurrentQuanity = (from s in db.vw_Inventory where s.ID == currentRow.InventoryID && s.CurrentQuanity > 0 select s.CurrentQuanity).Sum(); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);
                ////if (currentRow.Quanitity < AllCurrentQuanity)
                ////{
                ////    Console.Beep();//5000, 1000);
                ////    currentRow.Quanitity++;

                ////}
                ////else
                ////{
                ////    Console.Beep(5000, 100);
                ////    //    SystemSounds.Beep.Play();
                ////}
                ////gridViewInvoice.RefreshRow(gridViewInvoice.FocusedRowHandle);
                //////
                DataAccess.SaleInvoiceDetail currentRow = (DataAccess.SaleInvoiceDetail)gridViewInvoice.GetFocusedRow();

                var inventoryList = (from s in db.vw_Inventory where s.ID == currentRow.InventoryID && s.CurrentQuanity > 0 select s); //from s in db.Inventories where s.PurchaseInvoiceDetailID in (from d in db.PurchaseInvoiceDetails where d.ItemID == itemID select d) select s); //db.Inventories.Select(s=> s.PurchaseInvoiceDetailID in purchaseList.);

                var AllCurrentQuanity = inventoryList.Select(s => s.CurrentQuanity).Sum();
                if (currentRow.Quanitity < AllCurrentQuanity)
                {
                    Console.Beep();//5000, 1000);
                    currentRow.Quanitity++;
                    //- I repleace this code with SendDailyInventoryStatus in modul class
                    ////int ReorderPoint = Convert.ToInt32( inventoryList.First().ReorderPoint);
                    //////We need to 
                    ////if ((AllCurrentQuanity - currentRow.Quanitity) <= ReorderPoint)
                    ////{
                      
                    ////    try
                    ////    {
                    ////        string message = "Reda" + branchID + ": " + inventoryList.First().Name + "  <  " + inventoryList.First().ReorderPoint;
                    ////        Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage("", message));
                    ////        thread.Start();
                    ////    }
                    ////    catch (Exception ex)
                    ////    {
                    ////        //Do nothing 
                    ////    }
                    ////}

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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            calculateInvoiceTotal();
        }

        private void btnAddTempItem_Click(object sender, EventArgs e)
        {
            try
            {
                new TempItem().ShowDialog();
                DataAccess.RedaV1Entities dbContext = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
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
                ////decimal invoiceTotal = 0;
                ////foreach (var item in details)
                ////{
                ////    invoiceTotal += (item.UnitPrice * item.Quanitity);
                ////}

                ////decimal discount = Convert.ToDecimal(e.NewValue);
                ////if (discount > (invoiceTotal * 10 / 100))
                ////{
                ////    errorProvider1.SetError(txtDiscount, "أكبر تخفيض يمكن منحه هو : " + (invoiceTotal * 10 / 100));
                ////    e.Cancel = true;
                ////}
                ////else
                ////{
                ////    errorProvider1.Clear();
                ////}
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

                    //- I repleace this code with SendItemWithoutBarcode in modul class

                    ////string Name = Convert.ToString(cmbNoVisible.GetColumnValue("Name"));
                    ////if (Name == "صنف بدون باركود")
                    ////{
                    ////    try
                    ////    {
                    ////        Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage("", "صنف بدون باركود: @" + UserData.Default.BranchName + "-" + UserData.Default.UserName + " (الصنف: " + Remarks + "الكمية " + Quanitity + "السعر " + salePrice + ")"));
                    ////        thread.Start();
                    ////    }
                    ////    catch (Exception ex)
                    ////    {
                    ////        //Do nothing 
                    ////    }
                    ////   //ModuleClass.SendWhatsAppMessage("ALL", "صنف بدون باركود: @" + UserData.Default.BranchName + "-" + UserData.Default.UserName + " (الصنف: " + Remarks + "الكمية " + Quanitity + "السعر " + salePrice + ")");
                    ////}



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

                    ////DataAccess.UserLogin login = db.UserLogins.Create();
                    ////login.Date = DateTime.Now;
                    ////login.UserID = Convert.ToInt32(UserData.Default.UserID);
                    ////login.Type = true;//Login Out
                    ////login.BranchID = branchID;
                    ////db.UserLogins.Add(login);

                    ////if (db.SaveChanges() > 0)
                    ////{

                    ////}
                    normalLogout = true;
                    try
                    {
                    ////    //Thread thread = new Thread(() => SendEmail(login, db.Users.Where(s => s.ID == login.UserID).SingleOrDefault()));
                        
                    ////    //thread.Start();

                    ////    string message = "";
                    ////    var ValidUser = db.Users.Where(s => s.ID == login.UserID).SingleOrDefault();
                    ////    if (login.Type)//Login Out
                    ////    {
                    ////        message = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " :خروج" + "- " + UserData.Default.BranchName + "-" + "  " + System.Environment.MachineName;
                    ////    }
                    ////    else//Login In
                    ////    {
                    ////        message = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + "   : دخول" + " " + UserData.Default.BranchName + " from pc:  " + System.Environment.MachineName;
                    ////    }
                    ////    //string EmailReceivers = UserData.Default.EmailReceivers;
                    //////    Thread emailThread = new Thread(() => ModuleClass.SendEmail("", "خروج", message));
                    //////    emailThread.Start();
                    }
                    catch (Exception ex)
                    {
                        //Do nothing 
                    }
                    ////if (login.User.IsAdmin)
                    ////{
                    ////    this.Hide();
                    ////    new Login().ShowDialog();
                    ////}
                    ////else
                    {
                       
                        if (new Shif(false).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            ////this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }

        }
//        public void SendEmail(DataAccess.UserLogin login, DataAccess.User ValidUser)
//        {
//            string smtpAddress = "smtp.gmail.com";
//            // int portNumber = 587;
//            bool enableSSL = true;
//            string emailFrom = "redasudani@gmail.com";
//            string password = "gqaz1tahaz";
//            string emailTo = "NasirTaha@gmail.com";
//            string subject = "Reda 1";
//            string body = "";
//            string pc = System.Environment.MachineName;
//            if (login.Type)//Login Out
//            {
//                body = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " :خروج" + "  Reda " + UserData.Default.BranchID + "  " + pc;

//            }
//            else//Login In
//            {
//                body = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " : دخول" + " Reda " + UserData.Default.BranchID + "  " + pc;
//            }
//            using (MailMessage mail = new MailMessage())
//            {
//                mail.From = new MailAddress(emailFrom);
//                mail.To.Add(emailTo);

//                mail.To.Add("sheble233@gmail.com");
//                mail.Subject = body;
//                mail.Body = body;
//                mail.IsBodyHtml = true;
                
               
//                try
//                {
//                    Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage(UserData.Default.WhatsAppReceivers, body));
//                    thread.Start();
//                }
//                catch (Exception ex)
//                {
//                    //Do nothing 
//                }

//                using (SmtpClient smtp = new SmtpClient(smtpAddress))//, portNumber))
//                {
//                    try
//                    {
//#if !DEBUG
//                            smtp.UseDefaultCredentials = false;
//                            smtp.Credentials = new NetworkCredential(emailFrom, password);
//                            smtp.EnableSsl = enableSSL;
//                            smtp.Send(mail);

                        
//#endif
//                    }
//                    catch (Exception ex)
//                    {
//                        //Do nothing 
//                    }
//                }
//            }
//        }
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
                    //login.BranchID = branchID;
                    //db.UserLogins.Add(login);
                    //if (db.SaveChanges() > 0)
                    //{

                    //}
                    try
                    {
                        //////Thread thread = new Thread(() => SendEmail(login, db.Users.Where(s => s.ID == login.UserID).SingleOrDefault()));
                        //////thread.Start();

                        ////string message = "";
                        ////var ValidUser = db.Users.Where(s => s.ID == login.UserID).SingleOrDefault();
                        ////if (login.Type)//Login Out
                        ////{
                        ////    message = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " :خروج" + "- " + UserData.Default.BranchName + "-" + "  " + System.Environment.MachineName;
                        ////}
                        ////else//Login In
                        ////{
                        ////    message = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + "   : دخول" + " " + UserData.Default.BranchName + " from pc:  " + System.Environment.MachineName;
                        ////}
                        ////var recerversEmails = db.Users.Where(s => s.IsAdmin == true).Select(s => s.Email).ToList();
                        ////string recervers = "";
                        ////foreach (var item in recerversEmails)
                        ////{
                        ////    recervers += (item + ",");
                        ////}
                        ////string EmailReceivers = recervers;// UserData.Default.EmailReceivers;

                        //////Thread emailThread = new Thread(() => ModuleClass.SendEmail("", "خروج", message));
                        //////emailThread.Start();
                    }
                    catch (Exception ex)
                    {
                        //Do nothing 
                    }
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

                //////if (e.KeyCode == Keys.Enter && txtSearchAllBranch.Text.Length > 2)
                //////{
                //////    string query = txtSearchAllBranch.Text;
                //////   // int ReorderPoint = Convert.ToInt32(txtReorderPoint.EditValue);
                //////    var list = from s in db.vw_Inventory where s.Name.Contains(query) select s;
                //////    vwInventoryBindingSource.DataSource = list.ToList();
                //////}
                //////else
                //////{
                //////    vwInventoryBindingSource.DataSource = null;
                //////}
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView3_GroupRowExpanding(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //////gridViewFastItems.CollapseAllGroups();

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
             //   new SaleInvoiceForm_Tab(items, new DataAccess.SaleInvoice(), true, SaleInvoiceType.Expire).Show();
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
                ////int ID = Convert.ToInt32(txtSaleInvoiceID.EditValue);
                ////var list = from s in db.vw_SaleReport where s.ID == ID && s.BranchID == branchID select s;
                ////vwSaleReportBindingSource.DataSource = list.ToList();
                ////gridViewSaleInvoice.ExpandAllGroups();
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
               
                ////int userID = Convert.ToInt32(cmbUsers.GetColumnValue("ID"));

                ////DateTime date = cmbSaleInvoiceDateFrom.DateTime;
                ////DateTime start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                ////DateTime end = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

                ////// var list = from s in db.vw_SaleReport where s.Date > start && s.Date < end && s.Flag != 0 select s;
                ////var list = from s in db.vw_SaleReport where s.Flag != 0 && s.UserID == userID && s.Date > start && s.Date < end && s.BranchID == branchID select s;
                ////vwSaleReportBindingSource.DataSource = list.ToList();
                ////gridViewSaleInvoice.ExpandAllGroups();



                ////decimal? totalOfSale = (from s in list select s.Total).Sum();
                ////int noOfInvoices = (from s in list where s.Flag == 1 select s.Total).Count();
              
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
                    ////var currentRow = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                    ////SaleRpt rpt = new SaleRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), currentRow.ID.ToString(), currentRow.UserName.ToString());
                    ////var list = from s in db.vw_Sale2 where s.SaleInvoiceID == currentRow.ID select s;
                    ////rpt.DataSource = list.ToList();


                    ////try
                    ////{
                    ////    string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                    ////    ReportPrintTool tool = new ReportPrintTool(rpt);
                    ////    tool.ShowPreview();
                    ////}
                    ////catch (Exception ex)
                    ////{
                    ////     ModuleClass.ShowMessage(this, ex, "خطأ", null);
                    ////}
                }
                else
                    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
                    {
                        ////var currentRow = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                        ////if (currentRow.Flag == 1)
                        ////{
                        ////    //     if (MessageBox.Show("هل أنت متأكد من إرجاع الفاتور؟", "إرجاع الفاتور", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        ////    {
                        ////        var row = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                        ////        SaleRpt rpt = new SaleRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), currentRow.ID.ToString(), currentRow.UserName.ToString());
                        ////        var list = db.vw_Sale2.Where(s => s.SaleInvoiceID == row.ID).ToList<DataAccess.vw_Sale2>();
                        ////        new ReturnForm(list, currentRow.ID).ShowDialog();
                        ////        FillSaleInvoiceGrid();

                                
                        ////    }
                        ////}
                        ////else
                        ////{
                        ////    MessageBox.Show("لا يمكن ارجاع الفاتوره");
                        ////}
                    }
                    else
                        if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                        {
                            //////var currentRow = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                            //////if (currentRow != null)
                            //////{
                            //////    var row = (DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                            //////    SaleRpt rpt = new SaleRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), currentRow.ID.ToString(), currentRow.UserName.ToString());
                            //////    var list = db.vw_Sale2.Where(s => s.SaleInvoiceID == row.ID).ToList<DataAccess.vw_Sale2>();


                            //////    rpt.DataSource = list.ToList();
                            //////    ReportPrintTool tool = new ReportPrintTool(rpt);
                            //////    string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                            //////    if (InvoicePrinter == "")
                            //////    {
                            //////        tool.Print();
                            //////    }
                            //////    else
                            //////    {
                            //////        tool.Print(InvoicePrinter);
                            //////    }
                            //////}

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
                    if (txtWhatsAppMessage.Text.Length < 3)
                    {
                        // txtWhatsAppMessage.Text = "";
                        return;
                    }

                    ////try
                    ////{
                    ////    Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage(UserData.Default.WhatsAppReceivers,UserData.Default.UserName + ": "+ txtWhatsAppMessage.Text));
                    ////    thread.Start();
                    ////}
                    ////catch (Exception ex)
                    ////{
                    ////    //Do nothing 
                    ////}
                    string message = "";
                    message += "Reda" + branchID + Environment.NewLine;
                    message += (UserData.Default.UserName + ":"+Environment.NewLine);
                    message += txtWhatsAppMessage.Text;


                    if (PushMessage.SendDirectMessage(message ))
                    {
                        txtWhatsAppMessage.Text = "";
                        //if (UserData.Default.WhatsAppHistory == null)
                        //{
                        //    UserData.Default.WhatsAppHistory = new System.Collections.Specialized.StringCollection();
                        //}
                        //CultureInfo culture = new CultureInfo("ar");
                        //string datepattern = culture.DateTimeFormat.LongDatePattern;
                        //DateTimeFormatInfo datetimeFormatInfo = new DateTimeFormatInfo();
                        //datetimeFormatInfo.LongDatePattern = "yyyy-M-dd:HH:mm";
                        //culture.DateTimeFormat = datetimeFormatInfo;
                        //Thread.CurrentThread.CurrentCulture = culture;


                        //UserData.Default.WhatsAppHistory.Add(DateTime.Now.ToLongDateString() + ": (" + UserData.Default.UserName + "): " + txtWhatsAppMessage.Text.Replace(Environment.NewLine, ""));
                        //// txtWhatsAppMessage.Text = "";
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

        private bool SendWhatsAppMessage(string to)
        {
            //return ModuleClass.SendWhatsAppMessage(to, txtWhatsAppMessage.Text);
            //try
            //{
            //    Thread thread = new Thread(() => PushMessage.SendPushMessage(txtWhatsAppMessage.Text, "Reda" + branchID + " رسالة مباشرة"));//  .SendWhatsAppMessage("", UserData.Default.UserName + ": " + txtWhatsAppMessage.Text));
            //    thread.Start();
            //    txtWhatsAppMessage.Text = "";
            //}
            //catch (Exception ex)
            //{
            //    //Do nothing 
            //}
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

        private void gridControlInvoice_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEditAddTempItem_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (gridViewFastItems.GetFocusedRow() is DataAccess.vw_TempItem)
                    {
                        AddToInvoice_FastItem((DataAccess.vw_TempItem)gridViewFastItems.GetFocusedRow());
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
        void AddToInvoice_FastItem(DataAccess.vw_TempItem Row)
        {
            DataAccess.vw_TempItem currentRow = Row;// (DataAccess.vw_TempItem)gridViewFastItems.GetFocusedRow();
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
            //

            //- I repleace this code with SendDailyInventoryStatus in modul class

            ////if ((currentRow.CurrentQuanity + 1) <= currentRow.ReorderPoint)
            ////{
            ////    //ModuleClass.SendWhatsAppMessage("ALL",);
            ////    try
            ////    {
            ////       // string message = "Reda" + branchID + " الصنف " + currentRow.Name + "  الكمية المتبقية من  " + currentRow.CurrentQuanity;
            ////        string message = "Reda" + branchID + ": " + currentRow.Name + "  <  " + currentRow.ReorderPoint;
            ////        Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage("", message));
            ////        thread.Start();
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        //Do nothing 
            ////    }
            ////}

            //
            newRow.InventoryID = currentRow.ID;
            // //details.Add(detail);
            // //db.SaleInvoiceDetails.Add(newRow);
            // //invoice.SaleInvoiceDetails.Add(newRow);

            //// int rows = db.SaveChanges();

            txtBar.Text = "";
            lblInventoryQuantity.Text = "";
            lblItemName.Text = "";
            calculateInvoiceTotal();
            gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1;
            txtBar.Focus();
        }
        private void gridViewFastItems_DoubleClick(object sender, EventArgs e)
        {

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            
            DoRowDoubleClick_FastItem(view, pt);
        }
        private void DoRowDoubleClick_FastItem(GridView view, Point pt)
        {

            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                AddToInvoice_FastItem((DataAccess.vw_TempItem)gridViewFastItems.GetRow(info.RowHandle));
                //AddToInvoice((DataAccess.vw_Inventory)gridViewSearch.GetRow(info.RowHandle));
                //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }

        }

        private void txtBar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string barcodeText = txtBar.Text;
                    if (txtBar.Text != "")
                    {

                        if (txtBar.Text.Length >= 6)
                        {
                            var ItemsFound = db.ItemBarcodes.Local.Where(s => s.BarcodeText == barcodeText);
                            var ItemIDs = ItemsFound.Select(s => s.ItemID);

                            if (ItemIDs != null && ItemIDs.Any())
                            {

                                //var inventoryFound = (from s in db.vw_Inventory where (s.BarcodeText == barcodeText || s.OriginalBarcodeText == barcodeText) && s.CurrentQuanity > 0 && s.BranchID == branchID select s).ToList();
                                int itemId = Convert.ToInt32(ItemIDs.First());
                                var inventoryFound = (from s in db.vw_Inventory where s.ItemID == itemId && s.CurrentQuanity > 0 && s.BranchID == branchID select s).ToList();
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
                                        lblInventoryQuantity.Text = inventoryFound[0].CurrentQuanity.ToString();
                                        lblItemName.Text = inventoryFound[0].Name;
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
                                                    IncreaseQuantity(i.ItemID, 0);
                                                    //



                                                    //
                                                    this.bindingSourceInventory.DataSource = null;
                                                    txtBar.Text = "";
                                                    // lblInventoryQuantity.Text = "";
                                                    //lblItemName.Text = "";
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
                                                if (_saleInvoiceType == SaleInvoiceType.Sale)
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


                                    //- I repleace this code with SendDailyInventoryStatus in modul class
                                    ////if ((inventoryFound[0].CurrentQuanity + 1) <= inventoryFound[0].ReorderPoint)
                                    ////{
                                    ////    //ModuleClass.SendWhatsAppMessage("ALL",);
                                    ////    try
                                    ////    {
                                    ////        //string message = "Reda" + branchID + " الصنف " + inventoryFound[0].Name + "  الكمية المتبقية من  " + inventoryFound[0].CurrentQuanity;
                                    ////        string message = "Reda" + branchID + ": " + inventoryFound[0].Name + "  <  " + inventoryFound[0].ReorderPoint;
                                    ////        Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage("", message));
                                    ////        thread.Start();
                                    ////    }
                                    ////    catch (Exception ex)
                                    ////    {
                                    ////        //Do nothing 
                                    ////    }
                                    ////}
                                }
                                else
                                        if (inventoryFound.Count() < 1)
                                {

                                    var item = ItemsFound.First().Item;
                                    InputBox.SetLanguage(InputBox.Language.English);
                                    //Save the DialogResult as res
                                    DialogResult res = InputBox.ShowDialog(" الكمية : ", item.Name + " يمكن إضافة الصنف بدون باركود   ",   //Text message (mandatory), Title (optional)
                                        InputBox.Icon.Question,                                                                         //Set icon type Error/Exclamation/Question/Warning (default info)
                                        InputBox.Buttons.OkCancel,                                                                      //Set buttons set OK/OKcancel/YesNo/YesNoCancel (default ok)
                                        InputBox.Type.TextBox,                                                                         //Set type ComboBox/TextBox/Nothing (default nothing)
                                        new string[] { "Item1", "Item2", "Item3" },                                                        //Set string field as ComboBox items (default null)
                                        true,                                                                                           //Set visible in taskbar (default false)
                                        new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));                        //Set font (default by system)
                                                                                                                                        //Check InputBox result
                                    if (((InputBox.ResultValue != "") && (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)))
                                    {
                                        string Remarks = "";
                                        Int16 quantity = Convert.ToInt16(InputBox.ResultValue);
                                        DataAccess.SaleInvoiceDetail newRow = details.AddNew();
                                        newRow.ItemID = item.ID;
                                        newRow.UnitPrice = Convert.ToDecimal(item.SalePrice);
                                        newRow.InventoryID = 11539;// inventoryID;
                                        newRow.Remarks = "Zero QTY";
                                        newRow.Quanitity = quantity;
                                        newRow.CurrentQuanitity = -1;


                                        //- I repleace this code with SendItemsWithoutBarcode in modul class

                                        ////try
                                        ////{
                                        ////    Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage("", "صنف بدون باركود: @" + UserData.Default.BranchName + "-" + UserData.Default.UserName + " (الصنف: " + Remarks + "الكمية " + quantity + "السعر " + item.SalePrice + ")"));
                                        ////    thread.Start();
                                        ////}
                                        ////catch (Exception ex)
                                        ////{
                                        ////    //Do nothing 
                                        ////}

                                        calculateInvoiceTotal();
                                        gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1;
                                        txtBar.Text = "";
                                        txtBar.Focus();


                                    }
                                    else
                                    {
                                        this.bindingSourceInventory.DataSource = null;
                                        // MessageBox.Show("هذا الصنف غير متوفر");
                                        txtBar.Text = "";
                                        lblInventoryQuantity.Text = "";
                                        lblItemName.Text = "";
                                    }
                                    //this.bindingSourceInventory.DataSource = null;
                                    //MessageBox.Show("هذا الصنف غير متوفر");
                                    //txtBar.Text = "";
                                    //lblInventoryQuantity.Text = "";
                                    //lblItemName.Text = "";

                                }

                            }
                            else
                            {
                                this.bindingSourceInventory.DataSource = null;
                                MessageBox.Show("هذا الصنف غير متوفر");
                                txtBar.Text = "";
                                lblInventoryQuantity.Text = "";
                                lblItemName.Text = "";
                            }
                        }
                        else
                             if ((txtBar.Text.Length == 1 || txtBar.Text.Length == 2))
                        {
                            //this.bindingSourceInventory.DataSource = null;
                            int QuickCode;
                            if (Int32.TryParse(txtBar.Text, out QuickCode))
                            {
                                DataAccess.Item itm = db.Items.Where(s => s.QuickCode == QuickCode).SingleOrDefault();
                                if (itm != null)
                                {
                                    vw_Inventory newItem = (from s in db.vw_Inventory where s.CurrentQuanity > 0 && s.QuickCode == QuickCode && s.BranchID == branchID select s).SingleOrDefault();// db.vw_Inventory.ToList();
                                    if (newItem != null)
                                    {
                                        AddToInvoice(newItem);
                                    }
                                    else

                                    {
                                        //  MessageBox.Show(   " الصنف ("+ itm.Name+ ") غير متوفر بالمخزن ", query);
                                        var item = itm;// ItemsFound.First().Item;
                                        InputBox.SetLanguage(InputBox.Language.English);
                                        //Save the DialogResult as res
                                        DialogResult res = InputBox.ShowDialog(" الكمية : ", item.Name + " يمكن إضافة الصنف بدون باركود   ",   //Text message (mandatory), Title (optional)
                                            InputBox.Icon.Question,                                                                         //Set icon type Error/Exclamation/Question/Warning (default info)
                                            InputBox.Buttons.OkCancel,                                                                      //Set buttons set OK/OKcancel/YesNo/YesNoCancel (default ok)
                                            InputBox.Type.TextBox,                                                                         //Set type ComboBox/TextBox/Nothing (default nothing)
                                            new string[] { "Item1", "Item2", "Item3" },                                                        //Set string field as ComboBox items (default null)
                                            true,                                                                                           //Set visible in taskbar (default false)
                                            new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));                        //Set font (default by system)
                                                                                                                                            //Check InputBox result
                                        if (((InputBox.ResultValue != "") && (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)))
                                        {
                                            string Remarks = "";
                                            Int16 quantity = Convert.ToInt16(InputBox.ResultValue);
                                            DataAccess.SaleInvoiceDetail newRow = details.AddNew();
                                            newRow.ItemID = item.ID;
                                            newRow.UnitPrice = Convert.ToDecimal(item.SalePrice);
                                            newRow.InventoryID = 11539;// inventoryID;
                                            newRow.Remarks = "Zero QTY";
                                            newRow.Quanitity = quantity;
                                            newRow.CurrentQuanitity = -1;
                                            calculateInvoiceTotal();
                                            gridViewInvoice.FocusedRowHandle = gridViewInvoice.RowCount - 1;
                                            txtBar.Text = "";
                                            txtBar.Focus();

                                        }

                                        txtSearch.SelectAll();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("لا يوجد صنف بهذا الرقم المدخل", txtBar.Text);
                                    txtBar.SelectAll();
                                }
                            }
                        }
                        }
                }

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridViewFastItems_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
            info.GroupText = info.EditValue.ToString();// string.Format(view.GroupFormat, info.Column.Caption, info.EditValue, s);
        }

        private void toggleSwitchSaleOrExpire_Toggled(object sender, EventArgs e)
        {
            try
            {
                if (toggleSwitchSaleOrExpire.IsOn)
                {
                    _saleInvoiceType = SaleInvoiceType.Sale;
                    details = new BindingList<DataAccess.SaleInvoiceDetail>();
                    this.bindingSourceSaleInvoiceDetails.DataSource = details;
                    MessageBox.Show("تم تغيير  حالة الفاتورة الي وضع البيع","فاتورة بيع");
                }
                else
                {
                    _saleInvoiceType = SaleInvoiceType.Expire;
                    int branchId = Convert.ToInt32(UserData.Default.BranchID);
                    //this.Text = "فاتورة تالف - :" + db.Branches.Where(s => s.ID == branchId).Select(s => s.BranchName).SingleOrDefault();
                    details = new BindingList<DataAccess.SaleInvoiceDetail>();
                    this.bindingSourceSaleInvoiceDetails.DataSource = details;
                    MessageBox.Show("تم تغيير حالة الفاتورة الي وضع التالف \n سيتم خصم البضاعة من الفرع بدون أن تتأثر بيانات الوردية","فاتورة تالف");
                }

            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}
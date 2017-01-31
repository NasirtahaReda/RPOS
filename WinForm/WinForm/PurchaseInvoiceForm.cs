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
using MsgBox;
using RedaPOS;
using DevExpress.XtraGrid.Views.Grid;

namespace WinForm
{
    public partial class PurchaseInvoiceForm : DevExpress.XtraEditors.XtraForm
    {
        public int NoOfCopies { get; set; }
        private DataAccess.PurchaseInvoice invoice;
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        BindingList<DataAccess.PurchaseInvoiceDetail> purchaseDetails = null;
        bool _quickInsert;
        string BarcodePrinter = "";
        ////public PurchaseInvoiceForm()
        ////{
        ////    InitializeComponent();
        ////}

        public PurchaseInvoiceForm(DataAccess.PurchaseInvoice invoice, bool isNew, bool quickInsert=false)
        {
            InitializeComponent();
            _quickInsert = quickInsert;
            if (isNew)
            {
                this.invoice = db.PurchaseInvoices.Create();
                this.invoice.UserID = Convert.ToInt32(UserData.Default.UserID);
                this.invoice.BranchID = Convert.ToInt32(UserData.Default.BranchID);
                this.invoice.Flag = 0;
                this.invoice.Date = DateTime.Now;
                this.invoice.Total = 0;
                this.invoice.Discount = 0;
                db.PurchaseInvoices.Add(this.invoice);
            }
            else
            {
                this.invoice = invoice;
            }

            this.bindingSource1.DataSource = this.invoice;


            db.PurchaseInvoiceDetails.Where(s=> s.PurchaseInvoiceID == invoice.ID).Load();
            purchaseDetails = db.PurchaseInvoiceDetails.Local.ToBindingList();

            this.bindingSource2.DataSource = purchaseDetails;
            if (quickInsert)
            {
                //Only quick items
                this.invoice.Number = "فاتورة سريعه"+DateTime.Now.Year+DateTime.Now.Month+DateTime.Now.Day+DateTime.Now.Hour+DateTime.Now.Minute+"-"+UserData.Default.BranchID;
                var list = db.Items.Where(s => s.CategoryID == 2014).ToList();
                this.itemBindingSource.DataSource = list;
                itemBindingSource1.DataSource = list;
                txtItemSearch.Enabled = false;
            }
            else
            {
                db.ItemBarcodes.Load();
                this.itemBindingSource.DataSource = db.Items.ToList();
            }
            this.txtUser.Text = this.invoice.User.UserName;
            //if invoice was closed
          if(this.invoice.Flag == 1)
          {
              
              btnSave.Enabled = false;
              btnAddItem.Enabled = false;
              cmbItem.Enabled = false;
              txtItemDiscount.Enabled = false;
              txtPurchasePrice.Enabled = false;
              txtSalePrice.Enabled = false;
              txtDiscount.Enabled = false;
              txtQunatity.Enabled = false;
              cmpDate.Enabled = false;
              txtTotal.Enabled = false;
              txtUser.Enabled = false;
             checkEditAutoPrint.Enabled = false;
             checkEditAutoSave.Enabled = false;
              txtNumber.Enabled = false;
              gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
              //gridView1.OptionsBehavior.Editable = false;
              colDiscountPrice.OptionsColumn.AllowEdit = false;
              colItemID.OptionsColumn.AllowEdit = false;
              colQuantity.OptionsColumn.AllowEdit = false;
              colSalePrice.OptionsColumn.AllowEdit = false;
              colPurchasePrice.OptionsColumn.AllowEdit = false;
              repositoryItemButtonEdit1.Buttons[3].Visible = false;              
              this.Text ="Invoice Number: " +this.invoice.Number  +  " Closed";

          }
          else if(this.invoice.Flag == 0)
          {
              this.Text = "Invoice Number: " + this.invoice.Number + " Open";
          }
          BarcodePrinter = db.Companies.Take(1).SingleOrDefault().BarcodePrinter;
        }

        private void PurchaseInvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
               // bindingSourceInventory.DataSource = db.vw_Inventory.ToList();
                lblMessage.Text = "";
                cmbItem.Focus();
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
                int ItemID = 0;
                ItemID  = Convert.ToInt32(cmbItem.EditValue);
                AddToInvoice(ItemID);
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void AddToInvoice(int ItemID)
        {
           // int ItemID = 0;
           // ItemID = Convert.ToInt32(cmbItem.EditValue);

            int quantity = 0;
            quantity = Convert.ToInt32(txtQunatity.Text);

            decimal purchasePrice = 0;
            purchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);

            decimal salePrice = 0;
            salePrice = Convert.ToDecimal(txtSalePrice.Text);

            decimal discountPrice = 0;
            discountPrice = Convert.ToDecimal(txtItemDiscount.Text);
            /*
             Validation
             * Check dupicated items
             */

            var found = (from s in purchaseDetails where s.ItemID == ItemID select s).Count();
            if (found != 0)
            {
                MessageBox.Show(cmbItem.Text + "  already in the invoice", "Duplicate item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataAccess.PurchaseInvoiceDetail detail = db.PurchaseInvoiceDetails.Create();

            detail.PurchaseInvoiceID = invoice.ID;
            detail.ItemID = ItemID;
            detail.Quantity = quantity;
            detail.PurchasePrice = purchasePrice;
            detail.SalePrice = salePrice;
            detail.DiscountPrice = discountPrice;

            purchaseDetails.Add(detail);
            if (checkEditAutoSave.Checked)
            {
                if (db.SaveChanges() > 0)
                {
                    ShowMessageInStatusBar("New item saved successfully", 9000);
                }
            }
            if (checkEditAutoPrint.Checked)
            {
                if (PrintDetails(detail, Convert.ToInt16(detail.Quantity)))
                {
                    ShowMessageInStatusBar("New item printed successfully", 9000);
                }
            }
            bindingSource2.ResetBindings(false);
            txtQunatity.EditValue = 0;
            txtPurchasePrice.EditValue = 0;
            txtDiscount.EditValue = 0;
            txtSalePrice.EditValue = 0;

            cmbItem.Focus();
        }

        private bool PrintDetails(DataAccess.PurchaseInvoiceDetail detail, Int16 noOfCopies)
        {
            bool result = true;
           var item = db.Items.Where(s => s.ID == detail.ItemID).SingleOrDefault();
          
           DataAccess.ItemBarcode ibc = db.ItemBarcodes.Where(s => s.SystemBarcode == true && s.ItemID == item.ID).SingleOrDefault();
           string BarcodeText = ibc.BarcodeText;// item.BarcodeText;

            ZebraBarcodeLabelRPT rpt = new ZebraBarcodeLabelRPT(BarcodeText, item.Name, item.SalePrice.ToString());// detail.SalePrice.ToString());
           // rpt.DataSource = list;
            ReportPrintTool tool = new ReportPrintTool(rpt);
            rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
            NoOfCopies = noOfCopies;// detail.Quantity;
            string BarcodePrinter = this.BarcodePrinter;//  System.Configuration.ConfigurationManager.AppSettings["BarcodePrinter"];
            if (BarcodePrinter == "")
            {
                tool.Print();
            }
            else
            {
                tool.Print(BarcodePrinter);
            }
            return result;
        }
        private bool PrintDetails(string BarcodeText, string Name, decimal? SalePrice, short copies)
        {
            bool result = true;
           // var item = db.Items.Where(s => s.ID == detail.ItemID).SingleOrDefault();

            ZebraBarcodeLabelRPT rpt = new ZebraBarcodeLabelRPT(BarcodeText, Name, SalePrice.ToString());// detail.SalePrice.ToString());
            // rpt.DataSource = list;
            ReportPrintTool tool = new ReportPrintTool(rpt);
            rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
            NoOfCopies = copies;// detail.Quantity;
            string BarcodePrinter = this.BarcodePrinter;// System.Configuration.ConfigurationManager.AppSettings["BarcodePrinter"];
            tool.Print(BarcodePrinter);

            return result;
        }

        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies =Convert.ToInt16(NoOfCopies);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.SaveChanges() > 0)
                {
                   ShowMessageInStatusBar("تم حفظ اليانات", 9000);
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
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
                if (e.Button.Kind == ButtonPredefines.Right)
                {
                    if (cmbItem.EditValue is int)
                    {
                        int itemID = Convert.ToInt32(cmbItem.EditValue);
                        new ItemForm(itemID,_quickInsert).ShowDialog();
                        db.Entry<DataAccess.Item>((DataAccess.Item)cmbItem.GetSelectedDataRow()).Reload();
                        //reset edit value
                        cmbItem.EditValue = null;
                       // cmbItem.EditValue = db.Items.Last().ID;
                        cmbItem.EditValue = itemID;
                    }
                    else
                    {
                        MessageBox.Show("الرجاء اختيار الصنف بصورة صحيحة من القائمة");
                    }
                }
                else
                if(e.Button.Kind == ButtonPredefines.Plus)
                {
                    ItemForm frm = new ItemForm(cmbItem.Text, _quickInsert);
                    if(frm.ShowDialog() ==System.Windows.Forms.DialogResult.OK)
                    {
                        if (_quickInsert)
                        {
                            //Only quick items
                            this.itemBindingSource.DataSource  = db.Items.Where(s => s.CategoryID == 2014).ToList();
                        }
                        else
                        {
                           this.itemBindingSource.DataSource = db.Items.ToList();
                        }
                        int lastId = db.Items.Select(s => s.ID).Max();
                        var lastInsertedRow = db.Items.Where(s => s.ID == lastId).SingleOrDefault();
                        cmbItem.EditValue = lastInsertedRow.ID;
                        txtQunatity.Focus();
                    }
                }
                else
                    if (e.Button.Kind == ButtonPredefines.Search)
                    {
                        int ItemId = Convert.ToInt32(cmbItem.EditValue);//Convert.ToInt32(cmbItem.GetColumnValue("ItemID"));
                        this.bindingSourceInventory.DataSource = null;

                        db.PurchaseInvoiceDetails.Where(s => s.ItemID == ItemId).Load();
                        purchaseDetails = db.PurchaseInvoiceDetails.Local.ToBindingList();

                        this.bindingSource2.DataSource = purchaseDetails;
                    }
                    else
                        if (e.Button.Kind == ButtonPredefines.SpinRight)
                        {
                            int ItemId = Convert.ToInt32(cmbItem.EditValue);
                            var PurchaseItem = (from s in db.vw_Inventory where s.ItemID == ItemId select s).First();
                            if (PurchaseItem != null)
                            {
                                txtPurchasePrice.EditValue = PurchaseItem.PurchasePrice;
                                txtSalePrice.EditValue = PurchaseItem.SalePrice;
                                txtDiscount.EditValue = PurchaseItem.DiscountPrice;
                            }
                        }
            
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ItemForm frm = new ItemForm(cmbItem.Text,_quickInsert);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (_quickInsert)
                        {
                            //Only quick items
                            this.itemBindingSource.DataSource = db.Items.Where(s => s.CategoryID == 2014).ToList();
                        }
                        else
                        {
                            this.itemBindingSource.DataSource = db.Items.ToList();
                        }
                            int lastId = db.Items.Select(s => s.ID).Max();
                        var lastInsertedRow = db.Items.Where(s => s.ID == lastId).SingleOrDefault();
                        cmbItem.EditValue = lastInsertedRow.ID;
                        txtQunatity.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //Print all quantities 
            if(e.Button.Kind == ButtonPredefines.OK)
            {
                if(MessageBox.Show("Are you sure ?","Print barcode stickets",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataAccess.PurchaseInvoiceDetail currentRow = (DataAccess.PurchaseInvoiceDetail)gridView1.GetFocusedRow();
                    DataAccess.BarCodeTemplateList list = new DataAccess.BarCodeTemplateList();
                    for (int i = 0; i < currentRow.Quantity; i++)
                    {
                        list.Add(new DataAccess.BarCodeTemplate {  Barcode =currentRow.Item.BarcodeText, Name = currentRow.Item.Name, Price = currentRow.SalePrice.ToString()});
                    }
                    if (PrintDetails(currentRow,Convert.ToInt16( currentRow.Quantity)))
                    {
                        ShowMessageInStatusBar("New item printed successfully " + currentRow.Quantity + " Times", 9000);
                    }   
                }
            }
            else
                if (e.Button.Kind == ButtonPredefines.Down)
                {
                   
                        DataAccess.PurchaseInvoiceDetail currentRow = (DataAccess.PurchaseInvoiceDetail)gridView1.GetFocusedRow();
                        DataAccess.BarCodeTemplateList list = new DataAccess.BarCodeTemplateList();
                        for (int i = 0; i < currentRow.Quantity; i++)
                        {
                            list.Add(new DataAccess.BarCodeTemplate { Barcode = currentRow.Item.BarcodeText, Name = currentRow.Item.Name, Price = currentRow.SalePrice.ToString() });
                        }
                        if (PrintDetails(currentRow, 1))
                        {
                            ShowMessageInStatusBar("New item printed successfully", 9000);
                        }
                }
                else
                    if(e.Button.Kind == ButtonPredefines.Delete)
                    {
                        if (MessageBox.Show("تأكيد مسح الصنف من الفاتورة", "مسح الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            DataAccess.PurchaseInvoiceDetail currentRow = (DataAccess.PurchaseInvoiceDetail)gridView1.GetFocusedRow();
                            db.PurchaseInvoiceDetails.Remove(currentRow);

                            if (db.SaveChanges() > 0)
                            {
                                ShowMessageInStatusBar("تم حفظ اليانات", 9000);
                            }
                        }
                    }
                    else
                        if (e.Button.Kind == ButtonPredefines.Glyph)
                        {
                            // if (MessageBox.Show("طباعة البار كود ؟", currentRow.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {

                                //Set buttons language Czech/English/German/Slovakian/Spanish (default English)
                                InputBox.SetLanguage(InputBox.Language.English);
                                //Save the DialogResult as res
                                DialogResult res = InputBox.ShowDialog("العدد:", "طباعة باركود",   //Text message (mandatory), Title (optional)
                                    InputBox.Icon.Question,                                                                         //Set icon type Error/Exclamation/Question/Warning (default info)
                                    InputBox.Buttons.OkCancel,                                                                      //Set buttons set OK/OKcancel/YesNo/YesNoCancel (default ok)
                                    InputBox.Type.TextBox,                                                                         //Set type ComboBox/TextBox/Nothing (default nothing)
                                    new string[] { "Item1", "Item2", "Item3" },                                                        //Set string field as ComboBox items (default null)
                                    true,                                                                                           //Set visible in taskbar (default false)
                                    new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));                        //Set font (default by system)
                                //Check InputBox result
                                if (((InputBox.ResultValue  != "" )&& (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)))
                                {
                                    Int16 copies = Convert.ToInt16(InputBox.ResultValue);
                                    DataAccess.PurchaseInvoiceDetail currentRow = (DataAccess.PurchaseInvoiceDetail)gridView1.GetFocusedRow();
                                    DataAccess.BarCodeTemplateList list = new DataAccess.BarCodeTemplateList();
                                    if (PrintDetails(currentRow, copies))
                                    {
                                        // ShowMessageInStatusBar("New item printed successfully " + currentRow.Quantity + " Times", 9000);
                                    }
                                }
                            }
                        }

        }

        

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (db.SaveChanges() > 0)
            {
                ShowMessageInStatusBar("تم حفظ اليانات", 9000);
                //var value = colSum.SummaryItem.SummaryValue;
                //txtTotal.EditValue = value;

                //var DiscountPrice = colDiscountPrice.SummaryItem.SummaryValue;
                //txtDiscount.EditValue = DiscountPrice;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void cmbItem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbItem.EditValue != null)
                {
                    int ItemId = Convert.ToInt32(cmbItem.EditValue);
                    decimal SalePrice = Convert.ToDecimal(cmbItem.GetColumnValue("SalePrice"));
                    var item = (from s in db.Items where s.ID == ItemId select s).First();
                    if (item != null)
                    {
                        txtPurchasePrice.EditValue = 0;
                        txtSalePrice.EditValue = item.SalePrice;
                        txtDiscount.EditValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                ////if (txtSearch.Text.Length >= 2)
                ////{
                ////    //string query = txtSearch.Text;
                ////    //db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                ////    //var Ids = db.Items.Where(s => s.Name.Contains(query)).ToList();
                ////    ////var list = db.PurchaseInvoiceDetails.Where(s=> Ids.Contains(s.ItemID.ToString()) );
                ////    //this.bindingSourceInventory.DataSource = list.ToList();//(from s in db.PurchaseInvoiceDetails where s.ID == Id select s).ToList();// db.vw_Inventory.ToList();
                ////}
                ////else
                ////{
                ////    this.bindingSourceInventory.DataSource = null;
                ////}
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtSalePrice_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtItemSearch_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void repositoryItemButtonEditOperation_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                ////if (e.Button.Kind == ButtonPredefines.Ellipsis && gridView2.GetFocusedRow() is DataAccess.Item)
                ////{
                ////    var currentRow = gridView2.GetFocusedRow() as DataAccess.Item;
                ////    cmbItem.EditValue = currentRow.ID;
                ////}
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
              //  itemBindingSource1.DataSource = null;

                if (e.KeyCode == Keys.Enter && txtItemSearch.Text.Length > 2)
                {
                    string query = txtItemSearch.EditValue.ToString();
                    var list = db.Items.Local.Where(s => s.Name.Contains(query));
                    itemBindingSource1.DataSource = list;
                }
                else
                {
                    itemBindingSource1.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnCommitInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                this.invoice.Flag = 1;
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("تم قفل الفاتورة");
                    ShowMessageInStatusBar("تم حفظ اليانات", 9000);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string barcodeText = txtBarcode.Text;
                    var barcodeFounds = db.ItemBarcodes.Local.Where(s => s.BarcodeText == barcodeText).Select(s => s.ItemID);
                    if (barcodeFounds != null && barcodeFounds.Any())
                    {
                        int itemId = Convert.ToInt32(barcodeFounds.First());
                        cmbItem.EditValue = itemId;
                        //AddToInvoice(itemId);
                    }
                    else
                    {
                        MessageBox.Show("هذا الصنف غير متوفر");
                        txtBarcode.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        // Returns the total amount for a specific row.
        decimal getTotalValue(GridView view, int listSourceRowIndex)
        {
            decimal Quantity = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "Quantity"));
            decimal PurchasePrice = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "PurchasePrice"));
            decimal DiscountPrice = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "DiscountPrice"));
            decimal amount = (DiscountPrice * Quantity);// -;PurchasePrice
            return amount;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
            GridView view = sender as GridView;
            decimal sum = getTotalValue(view, e.ListSourceRowIndex);
            if (e.Column.Name == "colSum" && e.IsGetData) e.Value =String.Format("{0:0.00#}", sum);//.ToString("##.##");
        }

        private void gridView1_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var value = colSum.SummaryItem.SummaryValue;
            txtTotal.EditValue = String.Format("{0:0.00#}", value);
            invoice.Total= Convert.ToDecimal(value);

            ////var DiscountPrice = colDiscountPrice.SummaryItem.SummaryValue;
            ////txtDiscount.EditValue = String.Format("{0:0.00#}", DiscountPrice);
            ////invoice.Discount =Convert.ToDecimal( DiscountPrice);

            db.SaveChanges();
        }

        private void txtPurchasePrice_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtItemDiscount.EditValue = txtPurchasePrice.EditValue;
            }
            catch (Exception ex)
            {
                
              ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RedaPOS;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Utils.Paint;

namespace WinForm
{
    public partial class Inventory_Direct : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
        int branchID = 0;
        int OldQTY = 0;
        int NewQTY = 0;
        string ItemName = "";
        public Inventory_Direct()
        {
            InitializeComponent();
        }

        private void Inventory_Direct_Load(object sender, EventArgs e)
        {
            try
            {
                var item_list = db.Items.ToList();
                itemBindingSource.DataSource = item_list;
                branchID = Convert.ToInt32(UserData.Default.BranchID);
                 cbAutoSave.Checked = true;
                //db.ItemBarcodes.Load();
               // DataAccess.SaleInvoice invoice = db.SaleInvoices.Where(s=> s.ID == SaleInvoiceId).SingleOrDefault();

                ////foreach (var item in item_list)
                ////{
                ////    var InventoryList = db.vw_Inventory.Where(s => s.ItemID == item.ID);

                ////    foreach (var invnt in InventoryList)
                ////    {
                ////        DataAccess.SaleInvoiceDetail saleDetails = db.SaleInvoiceDetails.Create();
                ////        saleDetails.SaleInvoiceID = SaleInvoiceId;
                ////        saleDetails.CurrentQuanitity = invnt.CurrentQuanity;
                ////        saleDetails.InventoryID = invnt.ID;
                ////        saleDetails.ItemID = item.ID;
                ////        saleDetails.PurchaseQuantity = invnt.ReceiveQuantity;
                ////        saleDetails.Quanitity = invnt.ReceiveQuantity;
                ////        saleDetails.Remarks = "Inv";
                ////        saleDetails.UnitPrice = invnt.SalePrice;

                ////        invoice.SaleInvoiceDetails.Add(saleDetails);

                ////    }
                ////}
                //saleInvoiceDetailBindingSource.DataSource = invoice.SaleInvoiceDetails;
            }
            catch(Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
               
                //if (cbAutoSave.Checked)
                //{
                //    if (db.SaveChanges() > 0)
                //    {
                //        string message = "";
                //        message += " تم تغير كمية الصنف: " + ItemName + " من   " + OldQTY + " الي " + NewQTY + Environment.NewLine;
                //        message += "الموظف" + UserData.Default.UserName + Environment.NewLine;
                //        message += "@ Reda" + UserData.Default.BranchID + Environment.NewLine;
                //        this.inventoryBindingSource.DataSource = null;
                //         txtSearch.Focus();
                //        PushMessage.SendDirectInventory(message);
                //    }
                //}
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(db.SaveChanges() > 0)
                {
                    string message = "";
                    message += "تم تغير كمية الصنف:" + ItemName + "من" + OldQTY + "الي" + NewQTY + Environment.NewLine;
                    message += "الموظف" + UserData.Default.UserName + Environment.NewLine;
                    message += "@ Reda" + UserData.Default.BranchID + Environment.NewLine;
                    gridControl1.DataSource = null;
                    this.inventoryBindingSource.DataSource = null;
                     txtSearch.Focus();
                    PushMessage.SendDirectInventory(message);
                }
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
                ////DataAccess.SaleInvoice invoice = db.SaleInvoices.Where(s => s.ID == SaleInvoiceId).SingleOrDefault();
                ////foreach (var item in invoice.SaleInvoiceDetails)
                ////{
                ////    var inv = db.Inventories.Where(s => s.ID == item.InventoryID).SingleOrDefault();
                ////    inv.ReceiveQuantity = Convert.ToInt32(item.PurchaseQuantity);
                ////    inv.CurrentQuanity = Convert.ToInt32(item.CurrentQuanitity);
                ////    item.Quanitity = Convert.ToInt32(item.PurchaseQuantity) - Convert.ToInt32(item.CurrentQuanitity);

                ////}

                ////int rowsSaved = db.SaveChanges();
                ////if (rowsSaved > 0)
                ////{

                ////}
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
                    var list = db.ItemBarcodes;
                    var barcodeFounds = db.ItemBarcodes.Where(s => s.BarcodeText == barcodeText);//.Select(s => s.ItemID);
                    if (barcodeFounds != null && barcodeFounds.Any())
                    {
                        int itemId = Convert.ToInt32(barcodeFounds.First().ItemID);
                      
                        var invList = db.Inventories.Where(s => s.ItemID == itemId && s.BranchID == branchID);
                        if (invList.Any())
                        {
                            inventoryBindingSource.DataSource = invList.ToList();
                            gridControl1.DataSource = inventoryBindingSource;

                            txtBarcode.Text = "";
                            txtSearch.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("هذا الصنف غير متوفر");
                            txtBarcode.Text = "";
                            txtSearch.Text = "";
                             txtSearch.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("هذا الصنف غير متوفر");
                        txtBarcode.Text = "";
                        txtSearch.Text = "";
                         txtSearch.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter && txtSearch.Text.Length > 2)
                {
                    string query = txtSearch.Text;
                    //  db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());

                    this.inventoryBindingSource.DataSource = (from inv in db.Inventories join itm in db.Items on inv.ItemID equals itm.ID where inv.CurrentQuanity >= 0 && itm.Name.Contains(query) && inv.BranchID == branchID select inv).ToList();// db.vw_Inventory.ToList();
                    gridControl1.DataSource = inventoryBindingSource;
                }
                else
                {
                    this.inventoryBindingSource.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }
        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;
            if (!view.OptionsView.ShowAutoFilterRow || !view.IsDataRow(e.RowHandle))
                return;

            string filterCellText = txtSearch.Text;// view.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, e.Column);
            if (String.IsNullOrEmpty(filterCellText))
                return;

            int filterTextIndex = e.DisplayText.IndexOf(filterCellText, StringComparison.CurrentCultureIgnoreCase);
            if (filterTextIndex == -1)
                return;

            XPaint.Graphics.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, filterCellText, e.Appearance, Color.Black, Color.Gold, false, filterTextIndex);
            e.Handled = true;
        }

        private void cbAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !cbAutoSave.Checked;
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != colCurrentQuanity) return;

                string cellValue = e.Value.ToString();// +" " + gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CurrentQuanity"]).ToString();

                var row = gridView1.GetFocusedRow() as DataAccess.Inventory;


                GridView view = (GridView)sender;
                var editor = view.ActiveEditor;
                OldQTY = Convert.ToInt32(view.ActiveEditor.OldEditValue);
                NewQTY = Convert.ToInt32(view.ActiveEditor.EditValue);
                ItemName = gridView1.GetRowCellDisplayText(view.FocusedRowHandle, colItemID).ToString();

                row.SystemQTY = OldQTY;
                row.ActualQTY = NewQTY;
                row.InventoryDate = DateTime.Now;





                if (cbAutoSave.Checked)
                {
                    if (db.SaveChanges() > 0)
                    {
                        string message = "";
                        message += " تم تغير كمية الصنف: " + ItemName + " من   " + OldQTY + " الي " + NewQTY + Environment.NewLine;
                        message += "الموظف" + UserData.Default.UserName + Environment.NewLine;
                        message += "@ Reda" + UserData.Default.BranchID + Environment.NewLine;
                        gridControl1.DataSource = null;
                        this.inventoryBindingSource.DataSource = null;
                        
                         txtSearch.Focus();
                         txtSearch.SelectAll();
                        this.Text = ItemName + "  " + NewQTY;
                        PushMessage.SendDirectInventory(message);
                    }
                }

            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                   GridView view = (GridView)sender;
                   var editor = view.ActiveEditor;
                   var row = view.GetFocusedRow();
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

             
            }
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
            txtSearch.Text = "";
             txtSearch.Focus();
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("en"));
        }
        public void SetKeyboardLayout(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("ar"));


            txtSearch.BeginInvoke(new MethodInvoker(delegate
            {
                txtSearch.SelectionLength = txtSearch.Text.Length;
                txtSearch.SelectionStart = 0;
            }));

        }

        private void repositoryItemLookUpEdit1_Click(object sender, EventArgs e)
        {
            
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.SpinRight)
                {
                    var row = gridView1.GetFocusedRow() as DataAccess.Inventory;
                    int itemID =  Convert.ToInt32(row.ItemID);
                    var item = db.Items.Where(s => s.ID == itemID).SingleOrDefault();
                    new ItemForm(item).ShowDialog();
                }
                else
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                   

                    //string cellValue = e.Value.ToString();// +" " + gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CurrentQuanity"]).ToString();

                    var row = gridView1.GetFocusedRow() as DataAccess.Inventory;


                    //GridView view = (GridView)sender;
                    //var editor = view.ActiveEditor;
                    //OldQTY = Convert.ToInt32(view.ActiveEditor.OldEditValue);
                    //NewQTY = Convert.ToInt32(view.ActiveEditor.EditValue);
                    //ItemName = gridView1.GetRowCellDisplayText(view.FocusedRowHandle, "ItemID").ToString();

                    row.SystemQTY = row.CurrentQuanity;
                    row.ActualQTY = row.CurrentQuanity;
                    row.InventoryDate = DateTime.Now;
                    if(db.SaveChanges()>0)
                    {
                        txtBarcode.Text = "";
                        txtSearch.Text = "";
                         txtSearch.Focus();
                        inventoryBindingSource.DataSource = null;
                        gridControl1.DataSource = null;
                        this.Text = ItemName + "  " + NewQTY;
                    }
                    else
                    {
                        MessageBox.Show("لم يتم حفظ البيانات، الرجاء المحاولة مرة أخري");
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}
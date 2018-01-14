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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using WinForm.Reports;
using DevExpress.XtraReports.UI;
using MsgBox;


namespace WinForm
{
    public partial class ItemUC : DevExpress.XtraEditors.XtraUserControl
    {
        public int NoOfCopies { get; set; }
        string ErrorMessage = "";
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        string BarcodePrinter = "";
        public ItemUC()
        {
            InitializeComponent();
            BarcodePrinter = db.Companies.Take(1).SingleOrDefault().BarcodePrinter;
        }

        private void ItemUC_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            try
            {
                db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                itemCategoryBindingSource.DataSource = db.ItemCategories.ToList();

               // db.Items.Local.Clear();
               // var list = new ObservableCollection(db.ItemCategories.ToList());
                //db.Configuration.LazyLoadingEnabled = false;
               // db.Items.Where(s => s.ID > 8);
                db.Items.Load();
                
              ///  db.Items.Local.AsLive().OrderBy(x => x.Id);
                var list = db.Items.Local.ToBindingList();
                bindingSource1.DataSource = list;
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
                //MainScreen parent = (MainScreen)this.Parent.Parent.Parent.Parent;
                if(db.SaveChanges() > 0)
                {
                    ShowMessageInStatusBar("تم حفظ اليانات",9000);
                }
                else
                {
                    ShowMessageInStatusBar("لا يوجد تغيير في البيانات يحتاج لحفظ", 9000);
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        public void ShowMessageInStatusBar(String Message, int time)
        {
            lblMessage.Caption = Message;
            timer1.Interval = time;
            timer1.Start();
        }
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ////if (gridView1.IsDataRow(gridView1.FocusedRowHandle))
                ////{
                ////    DataAccess.Item currentRow = (DataAccess.Item)gridView1.GetFocusedRow();

                ////    //Delete Current Object
                ////    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ////    {
                ////        if (MessageBox.Show("Are you sure ?", "Delete  " + currentRow.Name,MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                ////        {
                ////            db.Items.Remove(currentRow);
                ////            if(db.SaveChanges()>0)
                ////            {
                ////                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                ////                MainScreen parent = (MainScreen)this.Parent.Parent.Parent.Parent;
                ////                parent.ShowMessageInStatusBar("Item Deleted", 9000);
                ////            }
                ////        }
                ////    }
                ////    else
                ////        //Update
                ////        if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                ////        {
                     
                ////        }

                ////}
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {

                ////if (gridView1.FocusedColumn == colName)
                ////{
                ////    if (e.Value == null || ((string)e.Value) == string.Empty)
                ////    {
                ////        e.Valid = false;
                ////        e.ErrorText = "Name must have a value";
                ////    }
                ////    else
                ////        if (e.Value.ToString().Length > 50)
                ////        {
                ////            e.Valid = false;
                ////        }
                ////}
                ////else
                ////    if (gridView1.FocusedColumn == colCategoryID)
                ////    {
                ////        if (e.Value == null || ((string)e.Value) == string.Empty)
                ////        {
                ////            e.Valid = false;
                ////            e.ErrorText = "Category must have a value";
                ////        }
                ////    }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Input Error";
            e.ErrorText = "The value should be ....";

            ////// Destroying the editor and discarding the changes made within the edited cell
            ////gridView1.HideEditor();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ErrorMessage = string.Empty;
            ////Validate new row only
            //if (e.RowHandle != GridControl.NewItemRowHandle)
            //{
            //    return;
            //}
            DataAccess.Item currentRow = (DataAccess.Item)gridView1.GetFocusedRow();

            if (currentRow.Name == null || currentRow.Name == string.Empty)
            {
                e.Valid = false;
                e.ErrorText = "Error 0";
                ErrorMessage += "- Name must have a value \n";
                gridView1.SetColumnError(colName, "Name must have a value");
            }
            else
                if (currentRow.Name != null && currentRow.Name.Length > 50)
                {
                    e.Valid = false;
                    ErrorMessage += "- Name must have 50 characters maximum \n";
                    gridView1.SetColumnError(colName, "50 characters maximum");
                }

            if (currentRow.CategoryID == null || currentRow.CategoryID == 0)
            {
                e.Valid = false;
                ErrorMessage += "- You must select a category  \n";
                gridView1.SetColumnError(colCategoryID, "Category must have a value");
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            //Suppress displaying the error message box
            e.ErrorText = ErrorMessage + "\n\n";
            e.WindowCaption = "Error occur";
            
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        

        private void gridView1_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)// && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=  DialogResult.Yes)
                    return;

                DataAccess.Item currentRow = (DataAccess.Item)gridView1.GetFocusedRow();
                //GridView view = sender as GridView;
                db.Items.Remove(currentRow);
                if (db.SaveChanges() > 0)
                {
                    MainScreen parent = (MainScreen)this.Parent.Parent.Parent.Parent;
                    parent.ShowMessageInStatusBar("Item Deleted", 9000);
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string query = txtSearch.Text;
                if (e.KeyCode == Keys.Enter)
                {
                    db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                    if (!chHidden.Checked)
                    {
                        db.Items.Where(s => s.Name.Contains(query) && s.Hidden == false).Load();
                        var list = db.Items.Local.ToBindingList();
                        bindingSource1.DataSource = list;
                    }
                    else
                    {
                        db.Items.Where(s => s.Name.Contains(query)).Load();
                        var list = db.Items.Local.ToBindingList();
                        bindingSource1.DataSource = list;
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
        }

        private void txtSearch_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Clear)
            {
                txtSearch.Text = string.Empty;
                gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                db.Items.Local.Clear();
                bindingSource1.DataSource = db.Items.Local.ToBindingList();
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           if (e.RowHandle == GridControl.NewItemRowHandle)
           {
               //DataAccess.Item item = (DataAccess.Item)e.Row;
               //item.BarcodeText = item.ItemCategory.code +"-"+00001;
               //item.Symbology = "Code128";
           }
        }

        private void repositoryItemButtonEditPrintBarcode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
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
                        if (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)
                        {
                            Int16 copies = Convert.ToInt16(InputBox.ResultValue);
                            DataAccess.Item currentRow = (DataAccess.Item)gridView1.GetFocusedRow();
                            DataAccess.ItemBarcode ibc = db.ItemBarcodes.Where(s => s.SystemBarcode == true && s.ItemID == currentRow.ID).SingleOrDefault();
                            string BarcodeText = ibc.BarcodeText;// currentRow.BarcodeText;
                            DataAccess.BarCodeTemplateList list = new DataAccess.BarCodeTemplateList();
                            if (PrintDetails(BarcodeText, currentRow.Name, currentRow.SalePrice.ToString(), copies))
                            {
                                // ShowMessageInStatusBar("New item printed successfully " + currentRow.Quantity + " Times", 9000);
                            }
                        }
                    }
                }
                else
                    if (e.Button.Kind == ButtonPredefines.Ellipsis)
                {
                    DataAccess.Item currentRow = (DataAccess.Item)gridView1.GetFocusedRow();
                    new ItemForm(currentRow).ShowDialog();
                }
                else
                    if (e.Button.Kind == ButtonPredefines.Minus)
                {
                    DataAccess.Item currentRow = (DataAccess.Item)gridView1.GetFocusedRow();
                    currentRow.Hidden = true;
                    if (db.SaveChanges() > 0)
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }
        private bool PrintDetails(DataAccess.PurchaseInvoiceDetail detail, Int16 noOfCopies)
        {
            bool result = true;
            var item = db.Items.Where(s => s.ID == detail.ItemID).SingleOrDefault();

            ZebraBarcodeLabelRPT rpt = new ZebraBarcodeLabelRPT(item.BarcodeText, item.Name, item.SalePrice.ToString(), cbPrintPrice.Checked);// detail.SalePrice.ToString());
            // rpt.DataSource = list;
            ReportPrintTool tool = new ReportPrintTool(rpt);
            rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
            NoOfCopies = noOfCopies;// detail.Quantity;
            string BarcodePrinter = this.BarcodePrinter;// System.Configuration.ConfigurationManager.AppSettings["BarcodePrinter"];
            tool.Print(BarcodePrinter);


            return result;
        }
        private bool PrintDetails(String BarcodeText, String Name,String SalePrice, Int16 copies)
        {
            bool result = true;


            ZebraBarcodeLabelRPT rpt = new ZebraBarcodeLabelRPT(BarcodeText, Name, SalePrice.ToString(), cbPrintPrice.Checked);// detail.SalePrice.ToString());
            ReportPrintTool tool = new ReportPrintTool(rpt);
            rpt.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
            NoOfCopies = copies;// detail.Quantity;
            string BarcodePrinter = this.BarcodePrinter;// System.Configuration.ConfigurationManager.AppSettings["BarcodePrinter"];
            tool.Print(BarcodePrinter);


            return result;
        }
        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = Convert.ToInt16(NoOfCopies);
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if(e.Column == colNoOfCopies)
            {
                if(e.IsSetData)
                {
                  //  gridView1.SetFocusedRowCellValue(colNoOfCopies, e.Value);
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                new ItemForm("").ShowDialog();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column == colHidden)
            {
                try
                {
                    var row = gridView1.GetRow(e.RowHandle);
                    DataAccess.Item currentRow = (DataAccess.Item)row;
                    currentRow.Hidden = false;
                    if (db.SaveChanges() > 0)
                    {

                    }
                }
                catch (Exception ex)
                {
                    ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                }

            }
        }

        private void btnShowHidden_Click(object sender, EventArgs e)
        {
            try
            {
                db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                    db.Items.Where(s => s.Hidden == true).Load();
                    var list = db.Items.Local.ToBindingList();
                    bindingSource1.DataSource = list;
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}

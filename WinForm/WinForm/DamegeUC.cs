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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WinForm.Reports;
using DevExpress.XtraReports.UI;

namespace WinForm
{
    public partial class DamegeUC : DevExpress.XtraEditors.XtraUserControl
    {
        string ErrorMessage = "";
        DataAccess.RedaV1Entities db;// = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public DamegeUC(DataAccess.RedaV1Entities db)
        {
            this.db = db;
            InitializeComponent();

        }

        private void PurchaseInvoiceUC_Load(object sender, EventArgs e)
        {
            try
            {
                branchBindingSource.DataSource = db.Branches.ToList();
                cmbBranch.EditValue = 0;
                cmbFrom.DateTime = DateTime.Now;
                cmbTo.DateTime = DateTime.Now;
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

                bindingSourceUsers.DataSource = db.Users.Where(s=> s.IsEnable == true).ToList();
                // db.Items.Local.Clear();
                // var list = new ObservableCollection(db.ItemCategories.ToList());
                //db.Configuration.LazyLoadingEnabled = false;
                // db.Items.Where(s => s.ID > 8);
                db.SaleInvoices.Load();

                ///  db.Items.Local.AsLive().OrderBy(x => x.Id);
                var list = db.SaleInvoices.Local.ToBindingList();
                bindingSourceSaleInvoice.DataSource = list;
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
                MainScreen parent = (MainScreen)this.Parent.Parent.Parent.Parent;
                if (db.SaveChanges() > 0)
                {
                    parent.ShowMessageInStatusBar("تم حفظ اليانات", 9000);
                }
                else
                {
                    parent.ShowMessageInStatusBar("لا يوجد تغيير في البيانات يحتاج لحفظ", 9000);
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
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
            ////ErrorMessage = string.Empty;
            ////////Validate new row only
            //////if (e.RowHandle != GridControl.NewItemRowHandle)
            //////{
            //////    return;
            //////}
            ////DataAccess.Item currentRow = (DataAccess.Item)gridView1.GetFocusedRow();

            ////if (currentRow.Name == null || currentRow.Name == string.Empty)
            ////{
            ////    e.Valid = false;
            ////    e.ErrorText = "Error 0";
            ////    ErrorMessage += "- Name must have a value \n";
            ////    gridView1.SetColumnError(colName, "Name must have a value");
            ////}
            ////else
            ////    if (currentRow.Name != null && currentRow.Name.Length > 50)
            ////    {
            ////        e.Valid = false;
            ////        ErrorMessage += "- Name must have 50 characters maximum \n";
            ////        gridView1.SetColumnError(colName, "50 characters maximum");
            ////    }

            ////if (currentRow.CategoryID == null || currentRow.CategoryID == 0)
            ////{
            ////    e.Valid = false;
            ////    ErrorMessage += "- You must select a category  \n";
            ////    gridView1.SetColumnError(colCategoryID, "Category must have a value");
            ////}
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
            // (e.Panel.Parent as Form).Enabled = false;
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)// && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show("Delete invoice?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                DataAccess.SaleInvoice currentRow = (DataAccess.SaleInvoice)gridView1.GetFocusedRow();
                
                if (currentRow.Flag == 1)
                    {
                        MessageBox.Show("You can not delete closed invoice", "Delete Invoice", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                db.SaleInvoices.Remove(currentRow);
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
               
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {
            DataAccess.SaleInvoice obj = (DataAccess.SaleInvoice)e.NewObject;
            //obj.Flag = 0;//New Invoice
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["Date"], DateTime.Now);
        }

        private void txtSearch_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            
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

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
           
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void gridView1_ShowingPopupEditForm(object sender, ShowingPopupEditFormEventArgs e)
        {

        }

        private void gridView1_EditFormShowing(object sender, EditFormShowingEventArgs e)
        {
            if (gridView1.IsDataRow(e.RowHandle))
            {
                DataAccess.SaleInvoice currentRow = (DataAccess.SaleInvoice)gridView1.GetFocusedRow();
                if (currentRow.Flag == 1) //Clased Invoice
                {
                    e.Allow = false;
                    MessageBox.Show("You can not update closed invoice","Closed Invoice",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.SaleInvoice newInvoice = db.SaleInvoices.Create();

                new SaleInvoiceForm(newInvoice, true, SaleInvoiceType.Sale).ShowDialog();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnDisplayDamegeInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                int branchId = Convert.ToInt32(cmbBranch.EditValue);
                DateTime from = cmbFrom.DateTime;
                DateTime to = cmbTo.DateTime;
                if (true)
                {
                    //db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
                     var list = db.vw_SaleInvoiceSummary.Where(s => s.Date >= from && s.Date <= to && s.BranchID == branchId && s.Remarks == "Expire");
                    //var list = db.SaleInvoices.Local.ToBindingList();
                     if (list.Any())
                     {
                         bindingSourceSaleInvoice.DataSource = list.ToList();
                     }
                     else
                     {
                         MessageBox.Show("لا توجد فواتير تالف");
                     }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void repositoryItemLookUpEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if(e.Button.Kind == ButtonPredefines.Ellipsis)
                {
                    var row = (DataAccess.vw_SaleInvoiceSummary)gridView1.GetFocusedRow();
                    int invoiceID = row.ID;

                    var currentRow = db.vw_SaleReport.Where(s => s.ID == invoiceID).SingleOrDefault(); //(DataAccess.vw_SaleReport)gridViewSaleInvoice.GetFocusedRow();
                    SaleFullRpt rpt = new SaleFullRpt(Convert.ToDecimal(currentRow.Discount), Convert.ToDecimal(currentRow.Total), currentRow.ID.ToString(), currentRow.UserName.ToString());
                    var list = from s in db.vw_Sale2 where s.SaleInvoiceID == invoiceID select s;
                    rpt.DataSource = list.ToList();
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
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}

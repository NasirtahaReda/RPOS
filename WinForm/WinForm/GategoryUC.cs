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

namespace WinForm
{
    public partial class GategoryUC : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public GategoryUC()
        {
            InitializeComponent();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            try
            {
               // var list = new ObservableCollection(db.ItemCategories.ToList());

                db.ItemCategories.Load();
                var list = db.ItemCategories.Local.ToBindingList();
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
                if(db.SaveChanges() > 0)
                {
                    MainScreen parent = (MainScreen)this.Parent.Parent.Parent.Parent;
                    parent.ShowMessageInStatusBar("تم حفظ اليانات",9000);
                  //  MessageBox.Show("Saved");
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
                if (gridView1.IsDataRow(gridView1.FocusedRowHandle))
                {
                    DataAccess.ItemCategory currentRow = (DataAccess.ItemCategory)gridView1.GetFocusedRow();

                    //Delete Current Object
                    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                    {
                        if (MessageBox.Show("Are you sure ?", "Delete  " + currentRow.Category,MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            db.ItemCategories.Remove(currentRow);
                            if(db.SaveChanges()>0)
                            {
                                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                                MainScreen parent = (MainScreen)this.Parent.Parent.Parent.Parent;
                                parent.ShowMessageInStatusBar("Item Deleted", 9000);
                            }
                        }
                    }
                    else
                        //Update
                        if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                        {
                     
                        }

                }
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

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ////Validate new row only
            //if (e.RowHandle != GridControl.NewItemRowHandle)
            //{
            //    return;
            //}
            DataAccess.ItemCategory currentRow = (DataAccess.ItemCategory)gridView1.GetFocusedRow();
            
            if (currentRow.Category == null || currentRow.Category == string.Empty)
            {
                e.Valid = false;
                gridView1.SetColumnError(colCategory, "Category must have a value");
            }
            else
            if (currentRow.Category != null && currentRow.Category.Length > 50)
            {
                e.Valid = false;
                gridView1.SetColumnError(colCategory, "50 characters maximum");
            }

            if (currentRow.code == null || currentRow.code == string.Empty)
            {
                e.Valid = false;
                gridView1.SetColumnError(colcode, "Code must have a value");
            }
            else
            if (currentRow.Category != null && currentRow.code.Length !=2)
            {
                e.Valid = false;
                gridView1.SetColumnError(colcode, "The value must be 2 characters");
            }

            if (currentRow.Description != null && currentRow.Description.Length > 50)
            {
                e.Valid = false;
                gridView1.SetColumnError(colDescription, "50 characters maximum");
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            //Suppress displaying the error message box
            e.ExceptionMode = ExceptionMode.NoAction;
        }
    }
}

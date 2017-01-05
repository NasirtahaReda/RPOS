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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Entity;
using RedaPOS;

namespace WinForm
{
    public partial class ItemForm : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        bool _quickInsert;
        DataAccess.Item item;
        bool isNew = false;
        bool valid = true;
        private string p;
        private decimal? oldPrice;
        public ItemForm()
        {
            InitializeComponent();
            
        }

        public ItemForm(string p, bool quickInsert = false)
        {
            InitializeComponent();
            _quickInsert = quickInsert;
            if (_quickInsert)
            {
                bindingSourceCategory.DataSource = db.ItemCategories.Where(s => s.ID == 2014).ToList();
            }
            else
            {
                bindingSourceCategory.DataSource = db.ItemCategories.ToList();
            }

            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            item = db.Items.Create();
            item.SalePrice = 0;
            item.ReorderPoint = 5;
            item.CategoryID = db.ItemCategories.First().ID;
            db.Items.Add(item);
            bindingSourceItem.DataSource = item;
            bindingSourceItemBarcode.DataSource = this.item.ItemBarcodes;
            item.Name = p;
            txtName.Focus();
            isNew = true;

        }
        public ItemForm(int ItemID, bool quickInsert = false)
        {
            InitializeComponent();
            _quickInsert = quickInsert;
            if (_quickInsert)
            {
                bindingSourceCategory.DataSource = db.ItemCategories.Where(s => s.ID == 2014).ToList();
            }
            else
            {
                bindingSourceCategory.DataSource = db.ItemCategories.ToList();
            }
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

            item = db.Items.Where(s => s.ID == ItemID).SingleOrDefault();
            //use to send notificationn when change price
            oldPrice = item.SalePrice;
            bindingSourceItem.DataSource = item;
            bindingSourceItemBarcode.DataSource = this.item.ItemBarcodes;
           // item.Name = p;
            txtName.Focus();

        }
        public ItemForm(DataAccess.Item item)
        {
            InitializeComponent();
            bindingSourceCategory.DataSource = db.ItemCategories.ToList();
            this.item = db.Items.Where(s => s.ID == item.ID).SingleOrDefault(); ;
            //use to send notificationn when change price
            oldPrice = item.SalePrice;

            bindingSourceItem.DataSource = this.item;
            bindingSourceItemBarcode.DataSource = /*this.item.ItemBarcodes;*/ db.ItemBarcodes.Where(s => s.ItemID == item.ID).ToList();
            // item.Name = p;
            txtName.Focus();

            var itm = db.Items.Where(s => s.Name.Contains("osman")).SingleOrDefault();
            itm.SalePrice = 20;
            if(db.SaveChanges()>0)
            {

            }

        }

        private void ItemForm_Load(object sender, EventArgs e)
        {

        }

        bool CustomValidateForm()
        {
            bool result = true;
            errorProvider1.Clear();
            if (txtName.EditValue == null || txtName.EditValue.ToString() == "")
            {
                errorProvider1.SetError(txtName, "الرجاء تحديد الإسم");
                result= false;
            }
            if (cmbCategory.EditValue == null)
            {
                errorProvider1.SetError(cmbCategory, "الرجاء تحديد المجموعه");
                result= false;
            }
            if (Convert.ToDouble(txtSalePrice.EditValue) <= 0)
            {
                errorProvider1.SetError(txtSalePrice, "الرجاء  تحديد  سعر البيع");
                result = false;
            }
            if (Convert.ToInt32(txtReorderPoint.EditValue) <= 0)
            {
                errorProvider1.SetError(txtReorderPoint, "الرجاء  تحديد   حد الطلب");
                result = false;
            }
            valid = result;
            return result;


        }

        void SaveItem(bool closeWindow)
        {
            try
            {
                if (CustomValidateForm())
                {
                    if (isNew)
                    {
                        var catId = Convert.ToInt32(cmbCategory.GetColumnValue("ID"));
                        var code = cmbCategory.GetColumnValue("code").ToString();
                        int count = db.Items.Where(s => s.CategoryID == catId).Count();
                        string BarcodeText = "7" + code + "-" + (count + 1).ToString("000");
                        item.BarcodeText = BarcodeText;
                        item.Symbology = "Code128";
                        isNew = false;

                        DataAccess.ItemBarcode ibc = new DataAccess.ItemBarcode();
                        ibc.ItemID = item.ID;
                        ibc.BarcodeText = BarcodeText;
                        ibc.SystemBarcode = true;
                        db.ItemBarcodes.Add(ibc);
                    }
                    //this.item.SalePrice = 20;
                    //var res = db.ChangeTracker.Entries();
                    //if (res.Any())
                    //{
                    //}
                    if (db.SaveChanges() > 0)
                    {
                        //use to send notificationn when change price
                        if(oldPrice != null && oldPrice != item.SalePrice)
                        {
                            //Send notification message
                            string message = "تم تغيير سعر الصنف " +item.Name +" من " +oldPrice +  " الي "+item.SalePrice;
                            PushMessage.SendPriceChangeMessage(message);
                            DataAccess.MarqueeMessage marqueeMessage;
                            int LifetimeDays = 3;
                            foreach (var branch in db.Branches.ToList())
                            {
                                marqueeMessage = new DataAccess.MarqueeMessage
                                {
                                    BranchID = branch.ID,
                                    
                                    LifetimeDays = LifetimeDays,
                                    Message = message,
                                    Date = DateTime.Now.AddDays(LifetimeDays),
                                    UserID = Convert.ToInt32(UserData.Default.UserID)
                                };
                                db.MarqueeMessages.Add(marqueeMessage);
                                
                            }
                            if (db.SaveChanges() > 0)
                            {

                            }
                        }
                        valid = true;
                        if (closeWindow)
                        {
                            this.Close();
                        }
                    }
                }

            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(ex.Message,"رقم الباركود قد يكون تم إدخاله لصنف آخر");
                bindingSourceItemBarcode.DataSource = /*this.item.ItemBarcodes;*/ db.ItemBarcodes.Where(s => s.ItemID == item.ID).ToList();
            }
            catch( Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveItem(true);  
                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void cbHasExpireDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
            {
                if(!valid)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var row = gridView1.GetFocusedRow();
                if (row != null && row is DataAccess.ItemBarcode)
                {
                    DataAccess.ItemBarcode itemBarcode = row as DataAccess.ItemBarcode;
                    barCodeControlReda.Text = itemBarcode.BarcodeText;
                }
                //  e.FocusedRowHandle
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void bindingSourceItemBarcode_AddingNew(object sender, AddingNewEventArgs e)
       {
           try
          {
               DataAccess.ItemBarcode ibc = db.ItemBarcodes.Create();//  new DataAccess.ItemBarcode();
               ibc.ItemID = this.item.ID;
               ibc.SystemBarcode = false;
               e.NewObject = ibc;

               //item.ItemBarcodes.Add(ibc);
               db.ItemBarcodes.Add(ibc);
               //bindingSourceItemBarcode.DataSource = this.item.ItemBarcodes;
              // bindingSourceItemBarcode.DataSource = this.item.ItemBarcodes;// db.ItemBarcodes.Where(s => s.ItemID == item.ID).ToList();
               //item.ItemBarcodes.Add(ibc);
           }
            catch(Exception ex)
           {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
           }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (gridView1.IsNewItemRow(e.RowHandle))
            {
                gridView1.FocusedRowHandle = e.RowHandle;// GridControl.NewItemRowHandle;
                SaveItem(false);  
                //if(db.SaveChanges()>0)
                //{
                //    MessageBox.Show("تم إضافة بار كود");
                //}

            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveItem(false);
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                bindingSourceItemBarcode.DataSource = this.item.ItemBarcodes;

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                if (!view.IsNewItemRow(view.FocusedRowHandle))
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                
            }
        }

        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)// && e.Modifiers == Keys.Control)
                {
                    if (MessageBox.Show("حذف ?", "تأكيد الحذف", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    DataAccess.ItemBarcode currentRow = (DataAccess.ItemBarcode)gridView1.GetFocusedRow();

                    if (currentRow.SystemBarcode)
                    {
                        MessageBox.Show("لا يمكن حذف باركود الصنف الأساسي", "لا يمكن اتمام العملية ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    db.ItemBarcodes.Remove(currentRow);
                    if (db.SaveChanges() > 0)
                    {
                        bindingSourceItemBarcode.DataSource = this.item.ItemBarcodes;
                        ////MainScreen parent = (MainScreen)this.Parent.Parent.Parent.Parent;

                        ////parent.ShowMessageInStatusBar("Item Deleted", 9000);
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
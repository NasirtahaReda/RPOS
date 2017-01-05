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

namespace WinForm
{
    public partial class CalculateInventory : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        int SaleInvoiceId = 2;
        public CalculateInventory()
        {
            InitializeComponent();
        }

        private void CalculateInventory_Load(object sender, EventArgs e)
        {
            try
            {
                var item_list = db.Items.ToList();
                itemBindingSource.DataSource = item_list;
                DataAccess.SaleInvoice invoice = db.SaleInvoices.Where(s=> s.ID == SaleInvoiceId).SingleOrDefault();

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
                saleInvoiceDetailBindingSource.DataSource = invoice.SaleInvoiceDetails;
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
                if (db.SaveChanges() > 0)
                {

                }
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
    }
}
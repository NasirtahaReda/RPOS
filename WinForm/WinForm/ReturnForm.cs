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
using MsgBox;

namespace WinForm
{
    public partial class ReturnForm : DevExpress.XtraEditors.XtraForm
    {
       IEnumerable<DataAccess.vw_Sale2> _invoice;
       // SaleDetails = db.SaleInvoiceDetails.Where(s => s.ID == currentRow.ID).SingleOrDefault();
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public int _invoiceId { get; set; }
        public ReturnForm(IEnumerable<DataAccess.vw_Sale2> invoice, int invoiceID)
        {
            InitializeComponent();
            this._invoice = invoice;
            this._invoiceId = invoiceID;
            saleInvoiceDetailBindingSource.DataSource = _invoice;

            this.Text += "  : " + this._invoiceId;
        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            try
            {
                itemBindingSource.DataSource = db.Items.ToList();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void repositoryItemButtonEditDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataAccess.vw_Sale2 currentRow = (DataAccess.vw_Sale2)gridView1.GetFocusedRow();
                DataAccess.Inventory inv = null;
                inv = db.Inventories.Where(s => s.ID == currentRow.InventoryID).SingleOrDefault();
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                {
                    
                    inv.CurrentQuanity += currentRow.Quanitity;
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    var SaleDetails = db.SaleInvoiceDetails.Remove(db.SaleInvoiceDetails.Where(s => s.ID == currentRow.ID).SingleOrDefault());
                }
                else
                    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Minus)
                    {
                        InputBox.SetLanguage(InputBox.Language.English);
                        //Save the DialogResult as res
                        DialogResult res = InputBox.ShowDialog("العدد:", "ارجاع البضاعه",
                            InputBox.Icon.Question,
                            InputBox.Buttons.OkCancel,
                            InputBox.Type.TextBox,
                            new string[] { "Item1", "Item2", "Item3" },
                            true,
                            new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));
                        //Check InputBox result
                        if (((InputBox.ResultValue != "") && (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)))
                        {

                            Int16 quantityToReturn = 0;
                            if (!Int16.TryParse(InputBox.ResultValue, out quantityToReturn))
                            {
                                MessageBox.Show("الرجاء إدخال ارقام فقط");
                                return;
                            }
                            int currentQuantity = currentRow.Quanitity;
                            if (quantityToReturn < 0)
                            {
                                MessageBox.Show("كمية خاطئة");
                                return;
                            }
                            if (quantityToReturn > currentQuantity)
                            {
                                MessageBox.Show("الكمية أكبر من الموجودة بالفاتورة");
                                return;
                            }

                            inv.CurrentQuanity += quantityToReturn;
                            var SaleDetails = db.SaleInvoiceDetails.Where(s => s.ID == currentRow.ID).SingleOrDefault();
                            SaleDetails.Quanitity -= quantityToReturn;
                           
                            
                        }
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
                this.Close();
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

                if (MessageBox.Show("هل أنت متأكد من إرجاع الفاتور؟", "إرجاع الفاتور", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    var saleInvoice = db.SaleInvoices.Where(s => s.ID == this._invoiceId).SingleOrDefault();
                    decimal tot = 0;
                    foreach (var item in saleInvoice.SaleInvoiceDetails)
                    {
                        tot += (item.UnitPrice * item.Quanitity);
                    }
                    saleInvoice.Total = tot;
                    saleInvoice.Flag = 2;

                    if (db.SaveChanges() > 0)
                    {

                        this.Close();
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
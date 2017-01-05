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
using RedaPOS;

namespace WinForm
{
    public partial class StockingForm : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.Stocking invoice;
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());

        public StockingForm(int invoiceID, bool isNew)
        {
            
            InitializeComponent();
            if (isNew)
            {
                this.invoice = db.Stockings.Create();
                this.invoice.UserID = Convert.ToInt32(UserData.Default.UserID);
                this.invoice.BranchID = Convert.ToInt32(UserData.Default.BranchID);
                this.invoice.Flag = 0;
                this.invoice.Date = DateTime.Now;
                this.invoice.Number = "";
                this.invoice.ItemCategoryId=0 ;
                db.Stockings.Add(this.invoice);
            }
            else
            {
                this.invoice = db.Stockings.Where(s => s.ID == invoiceID).SingleOrDefault(); 
                if(this.invoice.Flag == 1)
                {
                    colActualQNT.OptionsColumn.AllowEdit = false;
                    colRemarks.OptionsColumn.AllowEdit = false;
                    btnCommitInvoice.Enabled = false;
                }
            }
            this.itemBindingSource.DataSource = db.Items.ToList();
            this.bindingSource1.DataSource = this.invoice;
           this.bindingSource2.DataSource = db.StockingDetails.Where(s => s.StockingID == this.invoice.ID).ToList();// this.invoice.StockingDetails;
            //rpt.DataSource = db.vw_StockingDetails.Where(s => s.StockingID == currentRow.ID).OrderBy(s => s.Name).ToList();

            this.itemCategoryBindingSource.DataSource = db.ItemCategories.ToList();
        }

        private void StockingForm_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
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
                    DataAccess.StockingDetail row = e.Row as DataAccess.StockingDetail;
                    row.Status = 1;
                    ShowMessageInStatusBar("تم حفظ اليانات", 9000);
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                
            }
        }
        public void ShowMessageInStatusBar(String Message, int time)
        {
            lblMessage.Text = Message;
            timer1.Interval = time;
            timer1.Start();
        }

        private void btnCommitInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                this.invoice.Flag = 1;
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("تم قفل الفاتورة");
                   // ShowMessageInStatusBar("تم حفظ اليانات", 9000);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle > 0)
            {
                GridView view = sender as GridView;
                string status = view.GetRowCellDisplayText(e.RowHandle, colStatus);
                if(status == "1")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using WinForm.Reports;
using RedaPOS;

namespace WinForm
{
    public partial class StockingUC : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        int BranchID = 0;
        public StockingUC()
        {
            try
            {
                InitializeComponent();
                BranchID = Convert.ToInt32(UserData.Default.BranchID);
                bindingSource1.DataSource = db.vw_Stocking.Where(s => s.BranchID == BranchID).ToList();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void txtSearch_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
             try
            {
                ////int unClosedInvoices = db.Stockings.Where(s => s.Flag == 0 && s.BranchID == BranchID).Count();
                ////if (unClosedInvoices >= 1)
                ////{
                ////    MessageBox.Show("توجد فاتورة غير مرحله", "لا يمكن إنشاء فاتورة جديده");
                ////    return;
                ////}
                ////else
                {
                    new StockingEditForm(new DataAccess.Stocking(), true).ShowDialog();
                    bindingSource1.DataSource = db.vw_Stocking.Where(s => s.BranchID == BranchID).ToList(); 
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                //Add or update items
                if (e.ClickedItem == invoiceDetailsToolStripMenuItem)
                {

                    DataAccess.vw_Stocking vw_invoice = (DataAccess.vw_Stocking)gridView1.GetFocusedRow();

                    DataAccess.Stocking invoice = db.Stockings.Where(s => s.ID == vw_invoice.ID).SingleOrDefault();
                    //rpt.DataSource = db.vw_StockingDetails.Where(s => s.StockingID == currentRow.ID).OrderBy(s => s.Name).ToList();
                    //if (invoice.Flag == 1) //Clased Invoice
                    //{
                    //    MessageBox.Show("You can not update closed invoice", "Update Invoice", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return;
                    //}

                    new StockingForm(vw_invoice.ID, false).Show();
                }

                //Close invoice
                if (e.ClickedItem == closeToolStripMenuItem)
                {


                    DataAccess.vw_Stocking currentRow = (DataAccess.vw_Stocking)gridView1.GetFocusedRow();
                    DataAccess.Stocking invoice = db.Stockings.Where(s => s.ID == currentRow.ID).SingleOrDefault();

                    if (currentRow.Flag == 1)
                    {
                        MessageBox.Show("Invoice already closed", "Closed Invoice", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (invoice.StockingDetails.Count == 0)
                    {
                        MessageBox.Show("You can not close invoice has no items", "Closed Invoice", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;

                    }

                    if (MessageBox.Show("Close invoice ?", "Close invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        invoice.Flag = 1;
                        if (db.SaveChanges() > 0)
                        {

                            ShowMessageInStatusBar("Invoice closed", 9000);
                        }
                    }
                }
                if (e.ClickedItem == printToolStripMenuItem)
                {
                     DataAccess.vw_Stocking currentRow = (DataAccess.vw_Stocking)gridView1.GetFocusedRow();
                    StockingRPT rpt = new StockingRPT();
                    rpt.parameterCategory.Value = currentRow.Category;
                    rpt.parameterBranch.Value = currentRow.BranchName;
                    rpt.DataSource = db.vw_StockingDetails.Where(s => s.StockingID == currentRow.ID).OrderBy(s=> s.Name).ToList();
                    ReportPrintTool tool = new ReportPrintTool(rpt);
                    tool.ShowRibbonPreview();
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

        private void contextMenuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {

        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = db.vw_Stocking.Where(s => s.BranchID == BranchID).ToList();
        }
    }
}

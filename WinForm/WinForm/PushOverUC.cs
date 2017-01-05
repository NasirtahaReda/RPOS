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
using WinForm;

namespace RedaPOS
{
    public partial class PushOverUC : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccess.RedaV1Entities db = null;//
        public PushOverUC()
        {
            try
            {
                InitializeComponent();
                db = ModuleClass.GetConnection();
                branchBindingSource.DataSource = db.Branches.ToList();
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnItemsWithoutBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                int BranchID = Convert.ToInt32( cmbBranches.EditValue);


                if (PushMessage.SendItemWithoutBarcode(BranchID, cmbFrom.DateTime, cmbTo.DateTime))
                {
                    MessageBox.Show("تم إرسال التقرير الي نظام الموبايل");
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnDailyInventoryStatu_Click(object sender, EventArgs e)
        {
            try
            {
                int BranchID = Convert.ToInt32(cmbBranches.EditValue);
                if (PushMessage.SendDailyInventoryStatus(BranchID, cmbFrom.DateTime, cmbTo.DateTime))
                {
                    MessageBox.Show("تم إرسال التقرير الي نظام الموبايل");
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnItemMovement_Click(object sender, EventArgs e)
        {
            try
            {
                int BranchID = Convert.ToInt32(cmbBranches.EditValue);
                int ItemID = Convert.ToInt32(txtItemID.EditValue);
                DateTime from = new DateTime(cmbFrom.DateTime.Year, cmbFrom.DateTime.Month, cmbFrom.DateTime.Day, 0, 0, 0);
                DateTime to = new DateTime(cmbTo.DateTime.Year, cmbTo.DateTime.Month, cmbTo.DateTime.Day, 23, 59, 59);

                var list = db.ItemMovement(ItemID).Where(s => s.InvoiceDate > from && s.InvoiceDate < to && s.BranchID == BranchID).ToList();
                itemMovementResultBindingSource.DataSource = list;
                //if (ModuleClass.SendDailyInventoryStatus(BranchID, cmbFrom.DateTime, cmbTo.DateTime))
                //{
                //    MessageBox.Show("تم إرسال التقرير الي نظام الموبايل");
                //}
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnNetSummary_Click(object sender, EventArgs e)
        {
            try
            {
                int BranchID = Convert.ToInt32(cmbBranches.EditValue);
                int ItemID = Convert.ToInt32(txtItemID.EditValue);
                DateTime from = new DateTime(cmbFrom.DateTime.Year, cmbFrom.DateTime.Month, cmbFrom.DateTime.Day, 0, 0, 0);
                DateTime to = new DateTime(cmbTo.DateTime.Year, cmbTo.DateTime.Month, cmbTo.DateTime.Day, 23, 59, 59);

                var list = db.vw_NetSummary.Where(s => s.Date > from && s.Date< to && s.BranchID == BranchID).ToList();
                vwNetSummaryBindingSource.DataSource = list;
                //if (ModuleClass.SendDailyInventoryStatus(BranchID, cmbFrom.DateTime, cmbTo.DateTime))
                //{
                //    MessageBox.Show("تم إرسال التقرير الي نظام الموبايل");
                //}
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}

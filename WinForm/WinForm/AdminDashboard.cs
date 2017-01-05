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
using WinForm;

namespace RedaPOS
{
    public partial class AdminDashboard : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public AdminDashboard()
        {
            InitializeComponent();
          cmbPaymentDate.EditValue = DateTime.Now;
        }

        private void cmbPaymentDate_EditValueChanged(object sender, EventArgs e)
        {
             FillData();
        }
        void FillData()
        {
            try
            {
                DateTime from = new DateTime(cmbPaymentDate.DateTime.Year, cmbPaymentDate.DateTime.Month,1,0,0,0);
                DateTime to = new DateTime(cmbPaymentDate.DateTime.Year, cmbPaymentDate.DateTime.Month,DateTime.DaysInMonth(cmbPaymentDate.DateTime.Year, cmbPaymentDate.DateTime.Month),23,59,59);

                bindingSourceIn.DataSource = db.vw_Payment.Where(s => s.Date >= from && s.Date <= to && s.Amount > 0).ToList();
                bindingSourceOut.DataSource = db.vw_Payment.Where(s => s.Date >= from && s.Date <= to && s.Amount < 0).ToList();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.IsForGroupRow)
            {
               // e.Value = "";
            }
        }
    }
}
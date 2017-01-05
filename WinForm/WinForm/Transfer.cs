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
    public partial class Transfer : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());

        public Transfer()
        {
            InitializeComponent();
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            try
            {
                branchBindingSource.DataSource = db.Branches.ToList();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                int from = Convert.ToInt32(cmbFrom.GetColumnValue("ID"));
                int to = Convert.ToInt32(cmbTo.GetColumnValue("ID"));
                this.Hide();
                new SaleInvoiceForm(new DataAccess.SaleInvoice(), true, SaleInvoiceType.Transfer,from, to).Show(); 
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}
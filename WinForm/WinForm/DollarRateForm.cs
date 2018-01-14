using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm;

namespace RedaPOS
{
    public partial class DollarRateForm : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = null;
        public DollarRateForm()
        {
            InitializeComponent();
            db = ModuleClass.GetConnection();
            fillGrid();
        }
        void fillGrid()
        {
            try
            {
                var list = db.DollarRates.ToList();
                dollarRateBindingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle);
            if(row != null && row is DataAccess.DollarRate)
            {
                DataAccess.DollarRate rateRow = row as DataAccess.DollarRate;
                rateRow.Date = DateTime.Now;
                db.DollarRates.Add(rateRow);
            }

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("تم حفظ اليانات");
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}

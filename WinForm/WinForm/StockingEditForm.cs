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
using RedaPOS;

namespace WinForm
{
    public partial class StockingEditForm : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.Stocking invoice;
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        int BranchID = 0;

        public StockingEditForm(DataAccess.Stocking invoice, bool isNew)
        {
            BranchID = Convert.ToInt32(UserData.Default.BranchID);
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
                NumberTextEdit.Focus();
            }
            else
            {
                this.invoice = invoice;
            }
            this.bindingSource1.DataSource = this.invoice;

            this.itemCategoryBindingSource.DataSource = db.ItemCategories.ToList();
        }

        private void StockingEditForm_Load(object sender, EventArgs e)
        {
            try
            {

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
                if(db.SaveChanges()>0)
                {
                    //var list = db.vw_Stocking.Where(s => s.ItemCategoryId == invoice.ItemCategoryId && s.BranchID == BranchID );
                    //foreach (var item in list)
                    //{
                    //    var child = db.StockingDetails.Create();
                    //    child.
                    //    invoice.StockingDetails.Add(child);
                    //}
                    MessageBox.Show("تم الجفظ");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("لم يتم الجفظ");
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}
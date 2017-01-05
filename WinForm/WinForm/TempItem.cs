using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;


using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;

namespace WinForm
{
    public partial class TempItem : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        BindingList<DataAccess.TempItem> tempItems = new BindingList<DataAccess.TempItem>();
        public TempItem()
        {
            InitializeComponent();

            db.TempItems.Where(s=>s.ID>0).Load();
            tempItems = db.TempItems.Local.ToBindingList();
            bindingSourceTempItem.DataSource = tempItems;

            db.Items.Load();
            bindingSourceItem.DataSource = db.Items.Local.ToList();


            db.TempItemGroups.Load();
            bindingSourceTempItemGroup.DataSource = db.TempItemGroups.Local.ToList();

            gridView1.ExpandAllGroups();
        }

        private void TempItem_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                if (db.SaveChanges() > 0)
                {
                    gridView1.ExpandAllGroups();
                }
            }
            catch(Exception ex)
            {
               ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }

        private void repositoryItemButtonEditDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                 if(e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                    {
                        if (MessageBox.Show("تأكيد مسح الصنف ", "مسح الصنف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            DataAccess.TempItem currentRow = (DataAccess.TempItem)gridView1.GetFocusedRow();
                            db.TempItems.Remove(currentRow);

                            if (db.SaveChanges() > 0)
                            {
                               
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}

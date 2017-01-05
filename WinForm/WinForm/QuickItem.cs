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
    public partial class QuickItem : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        
        public QuickItem()
        {
            InitializeComponent();
            LoadQuickItems();
          
        }

        private void LoadQuickItems()
        {
            try
            {
                bindingSourceItem.DataSource = db.Items.Where(s => s.QuickCode < 100).ToList();
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }

        private void TempItem_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                //if (db.SaveChanges() > 0)
                //{
                //    gridView1.ExpandAllGroups();
                //}
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
                 //if(e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                 //   {
                 //       if (MessageBox.Show("تأكيد مسح الصنف ", "مسح الصنف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                 //       {
                 //           DataAccess.TempItem currentRow = (DataAccess.TempItem)gridView1.GetFocusedRow();
                 //           db.TempItems.Remove(currentRow);

                 //           if (db.SaveChanges() > 0)
                 //           {
                               
                 //           }
                 //       }
                 //   }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(new QuickItemAdd().ShowDialog() == DialogResult.OK)
                {

                    LoadQuickItems();
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
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("تم حفظ البيانات");
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}

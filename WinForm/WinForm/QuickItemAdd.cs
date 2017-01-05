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
    public partial class QuickItemAdd : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        
        public QuickItemAdd()
        {
            InitializeComponent();
            txtSearch.Focus();
          
        }

        private void TempItem_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string query = txtSearch.Text;
                if (e.KeyCode == Keys.Enter && txtSearch.Text.Length > 2)
                {
                    bindingSourceItem.DataSource = (from s in db.Items where s.Name.Contains(query) select s).ToList();// db.vw_Inventory.ToList();
                }
               
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(db.SaveChanges()> 0)
                {
                    MessageBox.Show("تم حفظ البيانات");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}

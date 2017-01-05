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
    public partial class Settings : DevExpress.XtraEditors.XtraForm
    {
        private DataAccess.RedaV1Entities db;

        public Settings()
        {
            InitializeComponent();

        }

        public Settings(DataAccess.RedaV1Entities db)
        {
            InitializeComponent();
            this.db = db;
            userBindingSource.DataSource = this.db.Users.Where(s => s.IsEnable == true).ToList();//.Where(s => s.IsAdmin == true)
            companyBindingSource.DataSource = this.db.Companies.Take(1).SingleOrDefault();
            messageTypeBindingSource.DataSource = this.db.MessageTypes.ToList();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (db.SaveChanges() > 0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void TextEdit_EditValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int userId = 0;
                userId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colID));
                userMessageBindingSource.DataSource = this.db.UserMessages.Where(s => s.UserID == userId).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
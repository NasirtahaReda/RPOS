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
    public partial class ChangePassword : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        DataAccess.User User;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                int userID = Convert.ToInt32(UserData.Default.UserID);
                User = db.Users.Where(s => s.ID == userID).SingleOrDefault();
                userBindingSource.DataSource = User;
                txtOldPassword.EditValue = "";
                //txtUserName.EditValue = User.UserName;
                //txtEmail.EditValue = User.Email;
                //txtMobileNo.EditValue = User.MobileNo;
                //txtOldPassword.Focus();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                int userID = Convert.ToInt32(UserData.Default.UserID);
                //var User = db.Users.Where(s => s.ID == userID).SingleOrDefault();
                if(txtOldPassword.EditValue.ToString() != User.Password)
                {
                    errorProvider1.SetError(txtOldPassword,"كلمة السر القديمة غير صحيحة");
                    return;
                }
                if (txtNewPassword.EditValue ==null|| txtConfirmPassword.EditValue == null)
                {
                    errorProvider1.SetError(txtConfirmPassword, "كلمة السر غير صحيحه");
                    return;
                }
                if (txtNewPassword.EditValue.ToString() != txtConfirmPassword.EditValue.ToString())
                {
                    errorProvider1.SetError(txtConfirmPassword, "كلمة السر غير مطابقة");
                    return;
                }
                //User.Password = "";
                User.Password = txtNewPassword.EditValue.ToString();
                //User.Email = txtEmail.EditValue.ToString();
                //User.MobileNo = txtMobileNo.EditValue.ToString();
                //User.
                if(!db.ChangeTracker.HasChanges())
                {
                    MessageBox.Show("لم تقم بتغيير أي شي ");
                    return;
                }
                if(db.SaveChanges()>0)
                {
                    MessageBox.Show("تم حفظ التغييرات");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ التغييرات");
                }
               
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }
    }
}
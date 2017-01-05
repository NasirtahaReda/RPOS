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
using RedaPOS.Properties;
using System.IO;
using System.Net.Mail;

using System.Net;
using System.Threading;
using DevExpress.LookAndFeel;
using System.Runtime.InteropServices;
using RedaPOS;
using System.Reflection;
using System.Data.SqlClient;


namespace WinForm
{
   
    
    public partial class AddUserToShift : DevExpress.XtraEditors.XtraForm
    {
        
        SqlConnectionStringBuilder sqlBulider = new SqlConnectionStringBuilder();
        DataAccess.RedaV1Entities db = null;// new DataAccess.RedaV1Entities(ModuleClass.Connect());
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public AddUserToShift()
        {
            try
            {
                InitializeComponent();
               //string connString = ModuleClass.Connect();
               //DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
                db = ModuleClass.GetConnection();
                DevExpress.UserSkins.BonusSkins.Register();
                
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute assembly = executingAssembly.GetCustomAttribute<AssemblyTitleAttribute>();
                AssemblyFileVersionAttribute assemblyVersion = executingAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
             


                LoadData();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }
        private void AddUserToShift_Load(object sender, EventArgs e)
        {
            
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoLogin()
        {
                               
            try
            {
                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }


        }
        void WriteSesssion(DataAccess.User ValidUser, bool sendEmai, string emailTitle)
        {
        }




        private void txtUserName_EditValueChanged(object sender, EventArgs e)
        {

        }

       

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddUser.Focus();
            }
        }

        private void cmbBranches_EditValueChanged(object sender, EventArgs e)
        {
            try
            {


                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }
        DateTime GetServerTime()
        {
            var objectContext = (db as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext;


            var dQuery = objectContext.CreateQuery<DateTime>("CurrentDateTime() ");
            DateTime dbDate = dQuery.AsEnumerable().First();



            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear =(short) dbDate.Year; // must be short
            st.wMonth = (short)dbDate.Month;
            st.wDay = (short)dbDate.Day;
            st.wHour = (short)dbDate.Hour;
            st.wMinute = (short)dbDate.Minute;
            st.wSecond = (short)dbDate.Second;

            SetSystemTime(ref st); // invoke this method.


            return dbDate;
        }
        private void LoadData()
        {
            try
            {
                userBindingSource1.DataSource = db.Users.Where(s => s.IsEnable != false).ToList();
                txtPassword.EditValue = "";
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxErrorProvider1.HasErrors)
                {
                    int userId = Convert.ToInt32(cmbUserName.EditValue);
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    string password = txtPassword.EditValue.ToString().ToLower();
                    var ValidUser = db.Users.Where(s => s.ID == userId && s.Password.ToLower() == password).SingleOrDefault();
                    var _shift = db.Shifts.Where(s => s.ID == ModuleClass.shiftID).SingleOrDefault();
                    if (ValidUser != null)
                    {
                       if(_shift.ShiftUsers.Where(s=> s.UserID == userId).Any())
                        {
                            MessageBox.Show(" للوردية " +cmbUserName.Text +  " لا يمكن إضافة المسخدم  " , "المستخدم موجود بالوردية");
                            return;
                        }
                        
                        DataAccess.ShiftUser shiftUser = db.ShiftUsers.Create();
                        shiftUser.ShiftID = _shift.ID;
                        shiftUser.UserID = userId;
                        shiftUser.LogInTime = DateTime.Now;
                        shiftUser.LogoutTime = DateTime.Now;
                        shiftUser.Duration = 0;
                        shiftUser.Flag = 0;
                        _shift.ShiftUsers.Add(shiftUser);
                        if (db.SaveChanges() > 0)
                        {
                            var message = ""+UserData.Default.BranchName+" فرع "+" للوردية   " + cmbUserName.Text + " تمت إضافة المستخدم ";
                            PushMessage.SendSignOnMessage(message);
                            MessageBox.Show(message);
                            
                            Thread.Sleep(1500);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("الرجاء التأكد من اسم المستخدم وكلمة المرور");
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                db = ModuleClass.GetConnection();
            }
        }
    }
}
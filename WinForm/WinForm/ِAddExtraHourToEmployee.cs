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
   
    
    public partial class AddExtraHourToEmployee : DevExpress.XtraEditors.XtraForm
    {
        
        SqlConnectionStringBuilder sqlBulider = new SqlConnectionStringBuilder();
        DataAccess.RedaV1Entities db = null;// new DataAccess.RedaV1Entities(ModuleClass.Connect());
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public AddExtraHourToEmployee()
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
                txtHourNumbers.EditValue = "";
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnNumberOfhoursToUser_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                if (cmbUserName.EditValue == null)
                {
                    dxErrorProvider1.SetError(cmbUserName, "يجد تحديد الموظف   ");
                }
                if (txtHourNumbers.EditValue == "")
                {
                    dxErrorProvider1.SetError(txtHourNumbers, "يجد تحديد عدد الساعات للموظف");
                }
                if (txtDescription.Text == string.Empty || txtDescription.Text == "" || txtDescription.Text == null || txtDescription.Text.Length < 7)
                {
                    dxErrorProvider1.SetError(txtDescription,"يجد تحديد الغرض بصورة واضحة");
                }
                if (!dxErrorProvider1.HasErrors)
                {
                    int userId = Convert.ToInt32(cmbUserName.EditValue);
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;
                    var message = " تمت إضافة زمن للمستخدم " + cmbUserName.Text + " لمدة " + txtHourNumbers.Text + " ساعات ";
                    message += " الغرض ";
                    message += txtDescription.Text;

                    string NumberOfhours = txtHourNumbers.EditValue.ToString().ToLower();
                    decimal balance = db.UserPayments.Where(s => s.UserID == userId).Select(s => (decimal?) s.Amount).Sum() ?? 0;

                    //(SELECT SUM(Amount) FROM[dbo].[UserPayment] Where UserID = @UserID)
                    decimal hourRate = Convert.ToDecimal(cmbUserName.GetColumnValue("HourRate"));

                    var _userPayment = new DataAccess.UserPayment();
                    _userPayment.Amount = Convert.ToDecimal(NumberOfhours) * hourRate;
                    _userPayment.Balance = balance + _userPayment.Amount;
                    _userPayment.Date = DateTime.Now;
                    _userPayment.Desciption = message;
                    _userPayment.InvoiceID = 0;
                    _userPayment.PaymentType = 1;
                    _userPayment.UserID = userId;
                    db.UserPayments.Add(_userPayment);
                    
                    /*
                    var _shift = db.Shifts.Where(s => s.BranchID == 1).OrderBy(s => s.ID).First();// .LastOrDefault();//.SingleOrDefault();
                    DataAccess.ShiftUser newShift = new DataAccess.ShiftUser();
                    newShift.Duration = Convert.ToDecimal(NumberOfhours) * 60;
                    newShift.ShiftID = _shift.ID;
                    newShift.LogInTime = DateTime.Now.AddHours(-1 * Convert.ToDouble(NumberOfhours));
                    newShift.LogoutTime = DateTime.Now;
                    newShift.UserID = userId;
                    newShift.Flag = 1;
                    db.ShiftUsers.Add(newShift);
                    */
                    if (db.SaveChanges() > 0)
                    {

                        if (cmbUserName.GetColumnValue("PushoverID") != null)
                        {
                            string pushid = cmbUserName.GetColumnValue("PushoverID").ToString();
                            List<string> userIDs = new List<string>();
                            userIDs.Add(pushid);

                            var userPayment = db.UserPayments.Where(s => s.UserID == userId).OrderByDescending(s => s.ID).Take(1).SingleOrDefault();
                            var amount = userPayment.Amount;
                            balance = userPayment.Balance;

                            message += Environment.NewLine + " " + "القيمة  " + amount + Environment.NewLine + " " + " المطالبة الحالية: " + balance + Environment.NewLine;


                            PushMessage.SendUserPaymentStatusMessage(message, userIDs);

                            MessageBox.Show(message);

                            Thread.Sleep(1500);
                        }
                        this.Close();
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
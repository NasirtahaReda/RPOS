using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RedaPOS;
using System.Reflection;
using System.Data.SqlClient;


namespace WinForm
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }
    public partial class AddLogin : DevExpress.XtraEditors.XtraForm
    {
        
        SqlConnectionStringBuilder sqlBulider = new SqlConnectionStringBuilder();
        DataAccess.RedaV1Entities db = null;// new DataAccess.RedaV1Entities(ModuleClass.Connect());
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public AddLogin()
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
                this.Text = assembly.Title + " " + assemblyVersion.Version;// +" ( " + UserData.Default.UserName + " ) ";// +branch.BranchName;


                //LoadData();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }
        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                               
            try
            {
                if (!dxErrorProvider1.HasErrors)
                {
                    
                    int userId =Convert.ToInt32(txtUserName.EditValue);
                    int branchID = Convert.ToInt32(UserData.Default.BranchID);
                    int logedUserID = Convert.ToInt32(UserData.Default.UserID);
                    if(userId == logedUserID)
                    {
                        MessageBox.Show("لا يمكن إضافة المستخدم للوردية");
                        return;
                    }
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    string password = txtPassword.EditValue.ToString().ToLower();
                    var ValidUser = db.Users.Where(s => s.IsEnable == true && s.ID == userId && s.Password.ToLower() == password).SingleOrDefault();
                    if (ValidUser != null)
                    
                    {
                       
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
            }


        }
        void WriteSesssion(DataAccess.User ValidUser, bool sendEmai, string emailTitle)
        {
            UserData.Default.UserName = ValidUser.UserName;
            UserData.Default.UserID = ValidUser.ID.ToString();
           // UserData.Default.Password = ValidUser.Password;
            string BranchID = UserData.Default.BranchID;
            UserData.Default.BranchID = BranchID;
            UserData.Default.Save();
            DataAccess.UserLogin login = db.UserLogins.Create();
            login.LogIn = DateTime.Now;
            login.LogOut = login.LogIn;
            login.UserID = ValidUser.ID;
            login.Type = false;//AddLogin
            login.BranchID = Convert.ToInt32(BranchID);
            db.UserLogins.Add(login);
            if (db.SaveChanges() > 0) // Add session info
            {
                ////if (sendEmai)
                ////{
                ////    try
                ////    {
                ////        ////Thread thread = new Thread(() => SendEmail(login, ValidUser));
                ////        ////thread.Start();
                ////        string title = emailTitle;
                ////        string message="";
                ////        if (login.Type)//AddLogin Out
                ////        {
                ////            message = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " :خروج" + "- " + UserData.Default.BranchName + "-" + "  " + System.Environment.MachineName;
                ////            //title = "خروج";
                ////        }
                ////        else//AddLogin In
                ////        {
                ////            message = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + "   : دخول" + " " + UserData.Default.BranchName + " from pc:  " + System.Environment.MachineName;
                ////           // title = "دخول";
                ////        }
                       
                ////       // string EmailReceivers = recervers;// UserData.Default.EmailReceivers;
                ////        Thread whatsApplThread = new Thread(() => PushMessage.SendSignOnMessage(message, UserData.Default.BranchName, login.Date, ValidUser.UserName));
                ////        whatsApplThread.Start();

                ////        ////Thread emailThread = new Thread(() => ModuleClass.SendEmail("", emailTitle, message));
                ////        ////emailThread.Start();
                ////    }
                ////    catch (Exception ex)
                ////    {
                ////        //Do nothing 
                ////    }
                ////}
            }
        }




        private void txtUserName_EditValueChanged(object sender, EventArgs e)
        {

        }

       

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }

        private void cmbBranches_EditValueChanged(object sender, EventArgs e)
        {
           
                
        }

        
    }
}
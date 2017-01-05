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


    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        
        SqlConnectionStringBuilder sqlBulider = new SqlConnectionStringBuilder();
        DataAccess.RedaV1Entities db = null;// new DataAccess.RedaV1Entities(ModuleClass.Connect());
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public Login()
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


                LoadData();
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
                    int branchID = Convert.ToInt32(cmbBranches.EditValue);
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    string password = txtPassword.EditValue.ToString().ToLower();
                    var ValidUser = db.Users.Where(s => s.ID == userId && s.Password.ToLower() == password).SingleOrDefault();
                    if (ValidUser != null)
                    
                    {
                        if (chLogAsAdmin.Checked)
                        {
                            if (ValidUser.IsAdmin)//If admin user show Main windows without shif settings
                            {
                                this.Hide();
                                WriteSesssion(ValidUser, true, "إدارة دخول");
                                new AdminUserForm(db).ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("المستخدم ليس له خاصية الدخول كمسؤول للنظام");
                            }
                        }
                        else //Other users
                        {
                            //Check if there is a shift still open by other users
                           
                            var existingShift = db.Shifts.Where(s => s.Flag == 0 && s.BranchID == branchID).SingleOrDefault();
                            if (existingShift != null)
                            {
                                if (existingShift.UserId != userId)
                                {
                                    MessageBox.Show("   لم يتم إغلاقها  " + existingShift.User.UserName + " توجد وردية للمستخدم", "لا يمكنك الدخول الي النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                                else
                                {
                                    ModuleClass.shiftID = existingShift.ID;
                           WriteSesssion(ValidUser, true, "دخول متكرر");
                                    this.Hide();
                                    
                                    new NormalUserForm(db).Show();
                                }
                            }
                            else
                            {
                                WriteSesssion(ValidUser, true, "دخول");
                                this.Hide();
                                new Shif(true).ShowDialog();
                            }
                          


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
            }


        }
        void WriteSesssion(DataAccess.User ValidUser, bool sendEmai, string emailTitle)
        {
            UserData.Default.UserName = ValidUser.UserName;
            UserData.Default.UserID = ValidUser.ID.ToString();
           // UserData.Default.Password = ValidUser.Password;
            string BranchID = cmbBranches.GetColumnValue("ID").ToString();
            UserData.Default.BranchID = BranchID;
            UserData.Default.Save();
            DataAccess.UserLogin login = db.UserLogins.Create();
            login.LogIn = DateTime.Now;
            login.LogOut = login.LogIn;
            login.UserID = ValidUser.ID;
            login.Type = false;//Login
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
                ////        if (login.Type)//Login Out
                ////        {
                ////            message = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " :خروج" + "- " + UserData.Default.BranchName + "-" + "  " + System.Environment.MachineName;
                ////            //title = "خروج";
                ////        }
                ////        else//Login In
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
//        public void SendEmail(DataAccess.UserLogin login, DataAccess.User ValidUser)
//        {
//            string smtpAddress = "smtp.gmail.com";
//            // int portNumber = 587;
//            bool enableSSL = true;
//            string emailFrom = "redasudani@gmail.com";
//            string password = "gqaz1tahaz";
//            string emailTo = "NasirTaha@gmail.com";
//            string subject = "Reda "+UserData.Default.BranchID;
//            string body = "";
//            string pc = System.Environment.MachineName;
//            if (login.Type)//Login Out
//            {
//                body = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + " :خروج" + "- " + UserData.Default.BranchName + "-" + "  " + pc;
//            }
//            else//Login In
//            {
//                body = login.Date.Day.ToString("00") + "/" + login.Date.Month.ToString("00") + "-" + login.Date.Hour.ToString("00") + ":" + login.Date.Minute.ToString("00") + " :" + ValidUser.UserName + "   : دخول" + " " + UserData.Default.BranchName + " from pc:  " + pc;
//            }

           
//            try
//            {
//#if !DEBUG
//                Thread thread = new Thread(() => ModuleClass.SendWhatsAppMessage("ALL", body));
//                thread.Start();
//#endif
//            }
//            catch (Exception ex)
//            {
//                //Do nothing 
//            }
//            using (MailMessage mail = new MailMessage())
//            {
//                mail.From = new MailAddress(emailFrom);
//                mail.To.Add(emailTo);
//                mail.To.Add("sheble233@gmail.com");
//                mail.Subject = body;
//                mail.Body = body;
//                mail.IsBodyHtml = true;

//                using (SmtpClient smtp = new SmtpClient(smtpAddress))//, portNumber))
//                {
//                    try
//                    {
//#if !DEBUG
//                            smtp.UseDefaultCredentials = false;
//                            smtp.Credentials = new NetworkCredential(emailFrom, password);
//                            smtp.EnableSsl = enableSSL;
//                            smtp.Send(mail);
//#endif


//                    }
//                    catch (Exception ex)
//                    {
//                        //Do nothing 
//                    }
//                }
//            }
//        }



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
            try
            {


                if (cmbBranches.GetSelectedDataRow() != null)
                {
                    int BranchID = Convert.ToInt32(cmbBranches.GetColumnValue("ID").ToString());
                    if (BranchID != 0)
                    {
                        string branchName = cmbBranches.GetColumnValue("BranchName").ToString();
                        string address = cmbBranches.GetColumnValue("Address").ToString();
                        UserData.Default.BranchName = branchName;
                        this.Text = branchName + " : " + address;


                        if (BranchID == 1)
                        {
                            defaultLookAndFeel1.LookAndFeel.SkinName = "Xmas 2008 Blue";// "Office 2007 Green";
                        }
                        else
                            if (BranchID == 2)
                            {
                                defaultLookAndFeel1.LookAndFeel.SkinName = "Springtime";// "Valentine";
                            }
                            else
                                if (BranchID == 3)
                                {
                                    defaultLookAndFeel1.LookAndFeel.SkinName = "Summer 2008";// "Office 2010 Blue";
                                }
                    }
                }
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
                //DateTime serverTime = GetServerTime();
               
              
                 
                      //  db = ModuleClass.GetConnection();// new DataAccess.RedaV1Entities(ModuleClass.Connect());
                        branchBindingSource.DataSource = db.Branches.ToList();
                        userBindingSource1.DataSource = db.Users.Where(s=> s.IsEnable != false).ToList();
                        if (UserData.Default.UserID != null)// && UserData.Default.UserID is int)
                        {
                            int userId = 0;
                            Int32.TryParse(UserData.Default.UserID, out userId);

                            txtUserName.EditValue = userId;

                        }

                        int BranchID = 0;
                        Int32.TryParse(UserData.Default.BranchID, out BranchID);

                        cmbBranches.EditValue = BranchID;
                        cmbBranches.EditValue = -1;
                        cmbBranches.EditValue = BranchID;
                        
                    
                    
              
                //int BranchID =Convert.ToInt32(UserData.Default.BranchID);// Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["BranchID"]);
#if DEBUG

                txtUserName.EditValue = 1;
                txtPassword.EditValue = "a";
                chLogAsAdmin.Checked = true;
#endif
                txtPassword.Focus();
            }
            catch(Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}
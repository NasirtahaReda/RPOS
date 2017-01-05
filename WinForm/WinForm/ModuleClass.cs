using Microsoft.SqlServer.MessageBox;
using RedaPOS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace WinForm
{
    public static class ModuleClass
    {
        public static int shiftID=0;
        public static DataAccess.RedaV1Entities connection = null;
       


        public static DataAccess.RedaV1Entities GetConnection()
        {
            
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    if (connection !=null && connection.Database.Exists())
                    {
                        //int count = connection.Branches.Count();
                        
                        //connection.Branches.Where(s=> s.ID>0).loa
                        if (connection.vw_PushoverMessage.Local == null || connection.vw_PushoverMessage.Local.Count() == 0)
                            connection.vw_PushoverMessage.Load();

                        if (connection.MessageTypes.Local == null || connection.MessageTypes.Local.Count() == 0)
                            connection.MessageTypes.Load();
                        break;
                    }
                    else
                    {
                        connection = new DataAccess.RedaV1Entities(ModuleClass.Connect());

                        connection.Database.Connection.Open();
                    }
                    
                  
                }
                catch (Exception ex)
                {
                    //Do noting
                    //wait 10 times to check connection
                }
            }
            return connection;
            
        }

        public  static string Connect(string serverName = ".")
        {
            string providerName = "System.Data.SqlClient";
            string databaseName = "DB_98398_reda3";

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            ////////////To connect locally

            ////To connect to the server
            sqlBuilder.UserID = "DB_98398_reda3_user";
            sqlBuilder.DataSource = "s11.winhost.com";


#if DEBUG
            ////sqlBuilder.UserID = "sa";
            ////sqlBuilder.DataSource = ".";
#endif

            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.Password = "Qaz!user";
            string providerString = sqlBuilder.ToString();
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = providerName;
            entityBuilder.ProviderConnectionString = providerString;
            entityBuilder.Metadata = @"res://*/Model1.csdl|
                        res://*/Model1.ssdl|
                        res://*/Model1.msl";
            Console.WriteLine(entityBuilder.ToString());
            return entityBuilder.ConnectionString;
        }

        public static void ShowExceptionMessage(Control owner, Exception ex, string Caption, Dictionary<string, string> additionalData = null)
        {
          ex.Source = owner.Text;
            if (additionalData != null)
            {
                foreach (var item in additionalData)
                {
                    ex.Data.Add(item.Key, item.Value);
                }
            }
            ExceptionMessageBox box = new ExceptionMessageBox(ex);
            box.Buttons = ExceptionMessageBoxButtons.OK;
            box.Caption = Caption;
            box.Options = ExceptionMessageBoxOptions.None;
            box.Beep = true;
            //box.SetButtonText("OK OK", "Ok OK21");
            //    box.Options = ExceptionMessageBoxOptions.RightAlign;
            //box.ShowCheckBox = true;
            box.ShowToolBar = true;
            box.Symbol = ExceptionMessageBoxSymbol.Stop;
            box.Show(owner);
        }


        public static void SendEmail(String receiver,string Subject, String Message)
        {
            DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
            DataAccess.Company company = db.Companies.Take(1).SingleOrDefault();

            string smtpAddress = company.smtpAddress;// "smtp.gmail.com";
            // int portNumber = 587;
            bool enableSSL = true;
            string emailFrom = company.emailFrom;// "redasudani@gmail.com";
            string password = company.password;// "gqaz1tahaz";
           // string emailTo = "NasirTaha@gmail.com";
            string subject = Subject;
            string body = "";
            string pc = System.Environment.MachineName;
            body = Message;

            var recerversEmails = db.Users.Where(s => s.IsAdmin == true).Select(s => s.Email).ToList();
            string recervers = "";
            foreach (var item in recerversEmails)
            {
                recervers += (item + ",");
            }
            //string[] recivers = receiver.Split(',');// UserData.Default.WhatsAppReceivers.Split(',');
            //var recerversEmails = db.Users.Where(s => s.IsAdmin == true).Select(s => s.Email).ToList();
           // string emails = "";
            //foreach (var item in recerversEmails)
            //{
            //    emails += (item + ",");
            //}


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                foreach (var emailTo in recerversEmails)//recivers)
                {
                    mail.To.Add(emailTo);
                }

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(smtpAddress))//, portNumber))
                {
                    try
                    {
#if !DEBUG
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
#endif


                    }
                    catch (Exception ex)
                    {
                        //Do nothing 
                    }
                }
            }
        }



    }

}


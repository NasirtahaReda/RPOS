using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WinForm
{
   public static class Shared
    {
       //public static void SendEmail(DataAccess.UserLogin login, DataAccess.User ValidUser)
       //{
       //    string smtpAddress = "smtp.gmail.com";
       //    // int portNumber = 587;
       //    bool enableSSL = true;
       //    string emailFrom = "redasudani@gmail.com";
       //    string password = "gqaz1tahaz";
       //    string emailTo = "NasirTaha@gmail.com";
       //    string subject = "Reda 1";
       //    string body = "";
       //    if (login.Type)//Login Out
       //    {
       //        body = login.Date + "  :  " + ValidUser.UserName + "   :   خروج" + "   Reda 1  ";
       //    }
       //    else//Login In
       //    {
       //        body = login.Date + "  :  " + ValidUser.UserName + "   :   دخول" + "   Reda 1  ";
       //    }
       //    using (MailMessage mail = new MailMessage())
       //    {
       //        mail.From = new MailAddress(emailFrom);
       //        mail.To.Add(emailTo);
       //        mail.To.Add("abdoshibli252@gmail.com");
       //        mail.Subject = body;
       //        mail.Body = body;
       //        mail.IsBodyHtml = true;

       //        using (SmtpClient smtp = new SmtpClient(smtpAddress))//, portNumber))
       //        {
       //            try
       //            {
       //                smtp.UseDefaultCredentials = false;
       //                smtp.Credentials = new NetworkCredential(emailFrom, password);
       //                smtp.EnableSsl = enableSSL;
       //                smtp.Send(mail);
       //            }
       //            catch (Exception ex)
       //            {
       //                //Do nothing 
       //            }
       //        }
       //    }
       //}
    }
}

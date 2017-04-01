using Microsoft.SqlServer.MessageBox;
using RedaPOS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public enum PushOverMessageType
    {
        DirectMessage = 0,
        SignOn = 1,
        ItemWithoutBarcode = 2,
        ShiftStart = 3,
        ShiftClose = 4,
        DirectInventory = 5,
        DailyInventoryStatus = 6,
        DialyExpense = 7,
        Payment = 8,
        DevicesStatus=9,
        TransferItem = 10,
        UserPaymentStatus = 11,
        SignOut = 12,
        PriceChange = 13
    }
    public static class PushMessage
    {
        #region New Messages
        static List<string>  GetReceiver(int CodeID)
        {
            List<string> receivers;
            var db = ModuleClass.GetConnection();

            receivers = db.vw_PushoverMessage.Local.Where(s => s.CodeID == CodeID && s.EnableMessage == true && s.PushoverID != null).Select(s => s.PushoverID).ToList();
            return receivers;
        }
       static string  GetTitle(int CodeID)
        {
            try
            {
                var db = ModuleClass.GetConnection();

                string title = db.MessageTypes.Local.Where(s => s.CodeID == CodeID).Select(s => s.Message).SingleOrDefault().ToString();
                return title;
            }
           catch(Exception ex)
            {
                return "";
            }
        }
        public static bool SendSignOnMessage(String Message)//,string Branch, DateTime date, string user)
        {
            try 
            { 
            bool result = true;

            var db = ModuleClass.GetConnection();
            int codeId = (int)PushOverMessageType.SignOn;

            var receivers = GetReceiver(codeId);
            var title = GetTitle(codeId);
            var message = db.MessageTypes.Local.Where(s => s.CodeID == codeId).Select(s => s.Template).SingleOrDefault().ToString();
            
           // message = String.Format(message, Branch, date.ToString(), user);

            result = SendPushMessage(Message, receivers, title);
            
            return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SendSignOutMessage(String Message)
        {
            try 
            { 
            bool result = true;

            var db = ModuleClass.GetConnection();
            int codeId = (int)PushOverMessageType.SignOut;

            var receivers = GetReceiver(codeId);
            var title = GetTitle(codeId);
            //var message = db.MessageTypes.Local.Where(s => s.CodeID == codeId).Select(s => s.Template).SingleOrDefault().ToString();
            
           // message = String.Format(message, Branch, date.ToString(), user);

            result = SendPushMessage(Message, receivers, title);
            
            return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SendPriceChangeMessage(String Message)
        {
            try
            {
                bool result = true;

                var db = ModuleClass.GetConnection();
                int codeId = (int)PushOverMessageType.PriceChange;

                var receivers = GetReceiver(codeId);
                var title = GetTitle(codeId);
              
                result = SendPushMessage(Message, receivers, title);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SendShiftCloseMessage(DataAccess.User insertedUser, String Message)
        {
            try
            {
                bool result = true;


                int codeId = (int)PushOverMessageType.ShiftClose;
                var receivers = GetReceiver(codeId);

                if (!receivers.Contains(insertedUser.PushoverID))
                    receivers.Add(insertedUser.PushoverID);

                var title = GetTitle(codeId);
                result = SendPushMessage(Message, receivers, title);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SendUserPaymentStatusMessage(string message, List<string> userIDs)
        {
            try
            {
                
                bool result = true;
              //  var db = ModuleClass.GetConnection();
                
             
                
                int codeId = (int)PushOverMessageType.UserPaymentStatus;
                var receivers = GetReceiver(codeId);
                var title = GetTitle(codeId);
                foreach (var PushoverID in userIDs)
                {
                    if (!receivers.Contains(PushoverID))
                        receivers.Add(PushoverID);
                }
                result = SendPushMessage(message, receivers, title);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SendDevicesStatusMessage(String Message)
        {
            try { 
            bool result = true;


            int codeId = (int)PushOverMessageType.DevicesStatus;
            var receivers = GetReceiver(codeId);
            var title = GetTitle(codeId);
          result =  SendPushMessage(Message, receivers, title);

            return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        public static bool SendItemWithoutBarcode(int branchID, DateTime dateFrom, DateTime toFrom)
        {
            try
            {
                DateTime from = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
                DateTime to = new DateTime(toFrom.Year, toFrom.Month, toFrom.Day, 23, 59, 59);
                var db = ModuleClass.GetConnection();
                var list = db.vw_ReorderItem.Where(s => s.Date > from && s.Date < to && s.BranchID == branchID && s.Remarks != null && s.CategoryID != 2013).ToList();
                if (list.Count() == 0)
                {
                    return true;
                }
                string message = "   ملخص  الأصناف بدون باركود رضا" + branchID + " " + Environment.NewLine;
                foreach (var item in list)
                {
                    message += item.Name + " " + item.Remarks + " " + item.UserName + Environment.NewLine;
                }


                int codeId = (int)PushOverMessageType.ItemWithoutBarcode;
                var receivers = GetReceiver(codeId);
                var title = GetTitle(codeId);
                return SendPushMessage(message, receivers, title);
            }
            catch(Exception ex)
            {
                return false;
            }

            //return PushMessage.SendPushMessage(message, title);
        }
        public static bool SendDailyInventoryStatus(int branchID, DateTime dateFrom, DateTime toFrom)
        {
            try { 
            DateTime from = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
            DateTime to = new DateTime(toFrom.Year, toFrom.Month, toFrom.Day, 23, 59, 59);
            var db =ModuleClass.GetConnection();
            var list = db.vw_ReorderItem.Where(s => s.Date > from && s.Date < to && s.BranchID == branchID && s.CurrentQuanity <= s.ReorderPoint && s.CategoryID != 2013).ToList();
            if(list.Count() == 0)
            {
                return true;
            }
            string message = " ----  ملخص كميات الأصناف رضا"+ branchID +" -----" + Environment.NewLine;
            foreach (var item in list)
            {
                message += item.Name + " " + item.CurrentQuanity + Environment.NewLine;
            }


            int codeId = (int)PushOverMessageType.DailyInventoryStatus;
            var receivers = GetReceiver(codeId);
            var title = GetTitle(codeId);
            return SendPushMessage(message, receivers, title);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SendDirectInventory(string message)
        {
            try
            {

                int codeId = (int)PushOverMessageType.DirectInventory;
                var receivers = GetReceiver(codeId);
                var title = GetTitle(codeId);
                return SendPushMessage(message, receivers, title);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SendDirectMessage(string message, string title="")
        {
            try
            {
                int codeId = (int)PushOverMessageType.DirectMessage;
                var receivers = GetReceiver(codeId);
                if (title != "")
                {
                    title = GetTitle(codeId);
                }

                return SendPushMessage(message, receivers, title);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SendTransferItems(string message)
        {
            try
            {

                int codeId = (int)PushOverMessageType.TransferItem;
                var receivers = GetReceiver(codeId);
                var title = GetTitle(codeId);
                return SendPushMessage(message, receivers, title);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        internal static object SendDialyExpense(DataAccess.User insertedUser, DataAccess.User ExpenseToUser, string message)
        {
            try { 
            int codeId = (int)PushOverMessageType.DialyExpense;
            var receivers = GetReceiver(codeId);
            if (!receivers.Contains(insertedUser.PushoverID))
                receivers.Add(insertedUser.PushoverID);

            if (!receivers.Contains(ExpenseToUser.PushoverID))
                receivers.Add(ExpenseToUser.PushoverID);

            var title = GetTitle(codeId);
            return SendPushMessage(message, receivers, title);
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        internal static object SendPayment(string message)
        {
            try { 
            int codeId = (int)PushOverMessageType.Payment;
            var receivers = GetReceiver(codeId);
            var title = GetTitle(codeId);
            
            return SendPushMessage(message, receivers, title);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public static bool SendPushMessage(string message,  string title = "RedaPOS")
        //{
        //    bool result = false;
           
        //    try
        //    {
        //        var parameters = new NameValueCollection {
        //            { "token", "anjmqq85namq52cjz8raa31crjftec" },
        //            { "user", "ubgh4udoa6jipcspgkiyaf6s44fgmx" },
        //            { "message", message },
        //           { "title", title  }
                   
        //    };

        //        using (var client = new WebClient())
        //        {
        //            client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
        //            result = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}
        public static bool SendPushMessage(string message,  List<string> receivers, string title="RedaPOS")
        {
            if (message == "" || message == null || receivers.Count ==0)
            {
                return false;
            }
            bool result = false;
            string device ="";
            foreach (var item in receivers)
            {
                device += item + ",";
            }
            device = device.ToString().Substring(0, device.ToString().Length - 1);
            try
            {
                var parameters = new NameValueCollection {
                    { "token", "anjmqq85namq52cjz8raa31crjftec" },
                    { "user", "ubgh4udoa6jipcspgkiyaf6s44fgmx" },
                    { "message", message },
                   { "title", title  },

                   {"device", device}
            };

                using (var client = new WebClient())
                {
                    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        ////public static bool SendPush_Message(String additionalReceiver, String Message, string title)
        ////{
        ////    return SendPushMessage(Message, null, title);
        ////    ////bool result = false;
        ////    ////try
        ////    ////{
        ////    ////    DataAccess.RedaV1Entities db= new DataAccess.RedaV1Entities(ModuleClass.Connect());
        ////    ////    DataAccess.Company company = db.Companies.Take(1).SingleOrDefault();

        ////    ////    string WhatsAppCode = company.WhatsAppCode;// UserData.Default.WhatsAppCode;
        ////    ////    string WhatsAppSender = company.WhatsAppSender;// UserData.Default.WhatsAppSender;

        ////    ////    string from = WhatsAppSender;
        ////    ////    string msg = Message;
             
        ////    ////    var usersMobileNos = db.Users.Where(s => s.IsAdmin == true).Select(s => s.MobileNo).ToList();
        ////    ////    string allRecervers = "";
        ////    ////    foreach (var item in usersMobileNos)
        ////    ////    {
        ////    ////        allRecervers += (item + ",");    
        ////    ////    }
        ////    ////    if (additionalReceiver != "")
        ////    ////    {
        ////    ////        allRecervers += ",";
        ////    ////    }
        ////    ////    string[] recivers = allRecervers.Split(',');
        ////    ////    foreach (var to in recivers)
        ////    ////    {
        ////    ////        WhatsApp wa = new WhatsApp(from, WhatsAppCode, "RedaPos", false, true);
        ////    ////        wa.OnConnectSuccess += () =>
        ////    ////        {
        ////    ////            wa.OnLoginSuccess += (phoneNumber, data) =>
        ////    ////            {
        ////    ////                wa.SendMessage(to, msg);
        ////    ////                result = true;
        ////    ////            };
        ////    ////            wa.OnLoginFailed += (data) =>
        ////    ////            {
        ////    ////                result = false;
        ////    ////            };

        ////    ////            wa.Login();
        ////    ////        };

        ////    ////        wa.OnConnectFailed += (ex) =>
        ////    ////        {
        ////    ////            result = false;
        ////    ////        };
        ////    ////        wa.Connect();
        ////    ////    }
        ////    ////}
        ////    ////catch (Exception ex2)
        ////    ////{

        ////    ////    result = false;
        ////    ////}

        ////    ////return result;
        ////}







       
    }

}


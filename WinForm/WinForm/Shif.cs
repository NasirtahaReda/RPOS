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
using WinForm.Reports;
using DevExpress.XtraReports.UI;
using MsgBox;
using RedaPOS;
using System.Threading;
using System.Data.Entity;

namespace WinForm
{
    public partial class Shif : DevExpress.XtraEditors.XtraForm
    {
        bool _shiftStart = false;
        DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
        DataAccess.Shift _shift;
        int branchID = Convert.ToInt32(RedaPOS.UserData.Default.BranchID);
        int userID = Convert.ToInt32(UserData.Default.UserID);
        public Shif(bool shiftStart)
        {
            InitializeComponent();
            _shiftStart = shiftStart;

        }

        private void Shif_Load(object sender, EventArgs e)
        {
            if (_shiftStart)//Shif start
            {
                this.Text = DateTime.Now.ToShortDateString() + "   " + UserData.Default.UserName + ":بداية الوردية للمستخدم";
                btnShiftClose.Enabled = false;

                layoutControlGroupShiftStrat.Enabled = true;
                layoutControlGroupShiftClose.Enabled = false;
                txtUserCash.Enabled = false;
                _shift = db.Shifts.Create();
                _shift.Flag = 0;//Shift Start
                _shift.BranchID = Convert.ToInt32(UserData.Default.BranchID);
                _shift.LoginTime = DateTime.Now;
                _shift.LogoutTime = DateTime.Now;
                _shift.UserId = Convert.ToInt32(UserData.Default.UserID);
                _shift.NoOfElectricityInvoice = 0;
                _shift.ColorPrinter = false;
                _shift.LaserPrinter = false;
                _shift.Fax = false;
                _shift.PackingMachine= false;
                _shift.Photocopier = false;
                _shift.Scanner = false;

                //get from db

                _shift.SaleTotal = 0;
                _shift.ExpensesTotal = 0;
                _shift.DiscountTotal = 0;

                shiftBindingSource.DataSource = _shift;
                db.Shifts.Add(_shift);

                CalculateNetAmounts();
            }
            else
            {

                this.Text = DateTime.Now.ToShortDateString() + "   " + UserData.Default.UserName + ":نهاية الوردية للمستخدم";
                btnShiftStart.Enabled = false;
                //layoutControlGroupShiftStrat.Enabled = false;
                txtCashAmountStart.Enabled = false;
                txtCoinsAmountStart.Enabled = false;
                //txtZainVoucherMachineBalanceStart.Enabled = false;
                txtElectricityAmountStart.Enabled = false;
                btnAddElectricityBalance.Enabled = true;
                layoutControlGroupShiftClose.Enabled = true;

                string currentDay = DateTime.Now.ToShortDateString();
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                var existingShifts = db.Shifts.Where(s => /*s.LoginTime.Year == year && s.LoginTime.Month == month && s.LoginTime.Day == day* &&*/ s.BranchID == branchID && s.UserId == userID && s.Flag == 0).SingleOrDefault();
                //var existingShifts = db.Shifts.Where(s => s.LoginTime.Year == DateTime.Now.Year && s.LoginTime.Month == DateTime.Now.Month && s.LoginTime.Day == DateTime.Now.Day && s.BranchID == branchID && s.UserId == userID).SingleOrDefault();
                if (existingShifts != null)
                {
                    _shift = existingShifts;

                    _shift.LogoutTime = DateTime.Now;
                    DateTime frm = new DateTime(_shift.LoginTime.Year, _shift.LoginTime.Month, _shift.LoginTime.Day, _shift.LoginTime.Hour, _shift.LoginTime.Minute, _shift.LoginTime.Second);
                    DateTime to = new DateTime(_shift.LogoutTime.Year, _shift.LogoutTime.Month, _shift.LogoutTime.Day, _shift.LogoutTime.Hour, _shift.LogoutTime.Minute, _shift.LogoutTime.Second);


                    //Sales
                    var saleList = from s in db.vw_SaleReport where s.Flag != 0 && s.UserID == userID && s.Date > frm && s.Date < to && s.BranchID == branchID && s.Remarks == "Sale" select s;
                    if (saleList.Any())
                    {


                        decimal? totalOfSale = (from s in saleList select s.Total).Sum();
                        decimal? discountOfSale = (from s in saleList select s.Discount).Sum();
                        _shift.SaleTotal = Convert.ToDecimal(totalOfSale);
                        _shift.DiscountTotal = Convert.ToDecimal(discountOfSale);
                    }
                    getExpenses();


                    shiftBindingSource.DataSource = _shift;
                    CalculateNetAmounts();
                }
            }
        }

        private void getExpenses()
        {
            //Expenses
            DateTime frm = new DateTime(_shift.LoginTime.Year, _shift.LoginTime.Month, _shift.LoginTime.Day, _shift.LoginTime.Hour, _shift.LoginTime.Minute, _shift.LoginTime.Second);
            DateTime to = new DateTime(_shift.LogoutTime.Year, _shift.LogoutTime.Month, _shift.LogoutTime.Day, _shift.LogoutTime.Hour, _shift.LogoutTime.Minute, _shift.LogoutTime.Second);

            var expenseList = db.Expenses.Where(s => s.BranchID == branchID && s.ShiftID == ModuleClass.shiftID);// s.InsertedUserId == userID && s.Date.Year == DateTime.Now.Year && s.Date.Month == DateTime.Now.Month && s.Date.Day == DateTime.Now.Day);
            //var expenseList = db.vw_Expense.Where(s=> s.BranchID == branchID && s.InsertedUserId == userID && s.Date.Year == DateTime.Now.Year && s.Date.Month == DateTime.Now.Month && s.Date.Day == DateTime.Now.Day);
            if (expenseList.Any())
            {
                decimal? totalOfExpense = (from s in expenseList select s.Amount).Sum();
                _shift.ExpensesTotal = Convert.ToDecimal(totalOfExpense);
            }
        }

        private void CalculateNetAmounts()
        {
            try
            {
                //Coins
                //   shiftBindingSource.ResetBindings(true);
                decimal CoinsAmountStart = Convert.ToDecimal(txtCoinsAmountStart.EditValue);
                decimal CoinsAmountClose = Convert.ToDecimal(txtCoinsAmountClose.EditValue);
                decimal CoinsAmountNet = CoinsAmountStart - CoinsAmountClose;
                txtCoinsAmountNet.EditValue = CoinsAmountNet.ToString("0.00");

                //Cash
                //   shiftBindingSource.ResetBindings(true);
                decimal CashAmountStart = Convert.ToDecimal(txtCashAmountStart.EditValue);
                decimal CashAmountClose = Convert.ToDecimal(txtCashAmountClose.EditValue);
                decimal CashAmountNet = CashAmountStart - CashAmountClose;
                txtCashAmountNet.EditValue = CashAmountNet.ToString("0.00"); ;

                //Zain
                //////decimal ZainVoucherMachineBalanceStart = Convert.ToDecimal(txtZainVoucherMachineBalanceStart.EditValue);
                //////decimal ZainVoucherMachineBalanceClose = Convert.ToDecimal(txtZainVoucherMachineBalanceClose.EditValue);
                //////decimal ZainVoucherMachineBalanceNet = ZainVoucherMachineBalanceStart - ZainVoucherMachineBalanceClose;
                //////txtZainVoucherMachineBalanceNet.EditValue = ZainVoucherMachineBalanceNet.ToString("0.00"); ;

                //Electricity
                decimal ElectricityAmountStart = Convert.ToDecimal(txtElectricityAmountStart.EditValue);
                decimal ElectricityAmountClose = Convert.ToDecimal(txtElectricityAmountClose.EditValue);
                decimal ElectricityAmountNet = ElectricityAmountStart - ElectricityAmountClose;
                txtElectricityAmountNet.EditValue = ElectricityAmountNet.ToString("0.00"); ;

                //NoOfElectricityInvoice
                int NoOfElectricityInvoice = Convert.ToInt32(txtNoOfElectricityInvoice.EditValue);
                /// decimal ElectricityAmountClose = Convert.ToDecimal(txtElectricityAmountClose.EditValue);
                int NoOfElectricityInvoicetNet = NoOfElectricityInvoice * 3;
                txtNoOfElectricityInvoiceNet.EditValue = NoOfElectricityInvoicetNet.ToString("0.00");

                decimal UserCash = Convert.ToDecimal(txtUserCash.EditValue);

                _shift.SystemCash = _shift.SaleTotal - _shift.DiscountTotal - _shift.ExpensesTotal
                    + CoinsAmountNet  + CashAmountNet+  ElectricityAmountNet
                    + NoOfElectricityInvoicetNet;

                txtDifrrent.EditValue = _shift.SystemCash - UserCash;// _shift.UserCash;
                //shiftBindingSource.DataSource = _shift;

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnShiftStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValid() && MessageBox.Show("هل أنت متأكد من صحة بيانات الوردية و حالة جميع الأجهزة؟","الرجاء التأكد من البيانات قبل بدء الوردية",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    if (db.SaveChanges() > 0)
                    {
                        DataAccess.ShiftUser shiftUser = db.ShiftUsers.Create();
                        shiftUser.ShiftID = _shift.ID;
                        shiftUser.UserID = _shift.UserId;
                        shiftUser.LogInTime = DateTime.Now;
                        shiftUser.LogoutTime = DateTime.Now;
                        shiftUser.Duration = 0;
                        shiftUser.Flag = 0;
                        _shift.ShiftUsers.Add(shiftUser);
                        if (db.SaveChanges() > 0)
                        {
                            ModuleClass.shiftID = _shift.ID;
                            if (!SendDevicesStatus())
                            {
                                MessageBox.Show("لم يستطع النظام ارسال حالة الأجهزة عن طريق رسائل الموبايل \nالرجاء تبليغ الإدارة بواسطة التلفون");
                            }
                            this.Hide();
                            //new SaleInvoiceForm(new DataAccess.SaleInvoice(), true, SaleInvoiceType.Sale).Show();
                            new NormalUserForm(db).Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private bool isValid()
        {
            bool result = true;
            errorProvider1.Clear();


            if (cbAgree.CheckState == CheckState.Unchecked)
            {
                errorProvider1.SetError(cbAgree, "بدء الوردية يستلزم الموافقة علي شروط النظام");
                result = false;
            }

            ////if(cbColorPrinter.CheckState == CheckState.Indeterminate)
            ////{
            ////    errorProvider1.SetError(cbColorPrinter, "الرجاء تأكيد حالة الطابعة الملونة");
            ////    result = false;
            ////}

            ////if (cbFax.CheckState == CheckState.Indeterminate)
            ////{
            ////    errorProvider1.SetError(cbFax, "الرجاء تأكيد حالة الفاكس");
            ////    result = false;
            ////}

            ////if (cbLaserPrinter.CheckState == CheckState.Indeterminate)
            ////{
            ////    errorProvider1.SetError(cbLaserPrinter, "الرجاء تأكيد حالة الطابعة العاديه");
            ////    result = false;
            ////}

            ////if (cbPackingMachine.CheckState == CheckState.Indeterminate)
            ////{
            ////    errorProvider1.SetError(cbPackingMachine, "الرجاء تأكيد حالة مكنة التغليف ");
            ////    result = false;
            ////}

            ////if (cbPhotocopier.CheckState == CheckState.Indeterminate)
            ////{
            ////    errorProvider1.SetError(cbPhotocopier, "الرجاء تأكيد حالة مكنة التصوير ");
            ////    result = false;
            ////}

            ////if (cbScanner.CheckState == CheckState.Indeterminate)
            ////{
            ////    errorProvider1.SetError(cbScanner, "الرجاء تأكيد حالة الاسكنر  ");
            ////    result = false;
            ////}
            return result;
        }

        private void EditValueChanged_All(object sender, EventArgs e)
        {
            CalculateNetAmounts();
        }

        private void btnShiftClose_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(UserData.Default.UserID);//Convert.ToInt32(cmbUsersRPT.EditValue);
                DateTime currentDate = DateTime.Now;
                if (isValid() && MessageBox.Show("هل أنت متأكد من صحة بيانات الوردية و حالة جميع الأجهزة؟", "الرجاء التأكد من البيانات قبل قفل الوردية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
              
                {
                    

                    //Close shift for all users in shift
                    var shiftUsers = db.ShiftUsers.Where(s => s.ShiftID == _shift.ID);
                    foreach (DataAccess.ShiftUser shiftUser in shiftUsers)
                    {
                        shiftUser.LogoutTime = DateTime.Now;
                        TimeSpan dur = shiftUser.LogoutTime.Subtract(shiftUser.LogInTime);
                        shiftUser.Duration =Convert.ToDecimal( Math.Round(dur.TotalMinutes,2));
                       // shiftUser.Duration =Math.Round(Decimal.Parse(dur.TotalMinutes.ToString()), 2);


                        shiftUser.Flag = 1;
                    }


                    _shift.LogoutTime = DateTime.Now;
                    _shift.Flag = 1;
                    if (db.SaveChanges() > 0)
                    {
                      
                            if (!SendDevicesStatus())
                        {
                            MessageBox.Show("لم يستطع النظام ارسال حالة الأجهزة عن طريق رسائل الموبايل \nالرجاء تبليغ الإدارة بواسطة التلفون");
                        }

                        //Send To Whatsapp
                        try
                        {
                            // +"," + ExpenseToUser.MobileNo + "," + insertedUser.MobileNo;

                            string message = "-------------------" + Environment.NewLine;
                            message += " وردية الفرع   " + _shift.Branch.BranchName + Environment.NewLine;
                            message += " الموظف  " + _shift.User.FullName + Environment.NewLine;
                            message += " زمن الدخول " + _shift.LoginTime + Environment.NewLine;
                            message += "  زمن الخروج " + _shift.LogoutTime + Environment.NewLine;

                            message += "   الفكة بداية الوردية" + txtCoinsAmountStart.EditValue + Environment.NewLine;
                            message += " الفكة نهاية الوردية" + txtCoinsAmountClose.EditValue + Environment.NewLine;

                            message += "  الكاش بداية الوردية" + txtCashAmountStart.EditValue + Environment.NewLine;
                            message += " الكاش نهاية الوردية " + txtCashAmountClose.EditValue + Environment.NewLine;

                            message += "  رصيد الكهرباء الأولي " + _shift.ElectricityAmountStart + Environment.NewLine;
                            message += "  رصيد الكهرباء المتبقي " + _shift.ElectricityAmountClose + Environment.NewLine;
                            message += "  عدد فواتير الكهرباء " + txtNoOfElectricityInvoice.EditValue + Environment.NewLine;
                            message += " مجموع مبيعات الكهرباء " + txtElectricityAmountNet.EditValue + Environment.NewLine;

                            message += " مجموع فواتير البيع " + txtSaleTotal.EditValue + Environment.NewLine;
                            message += " مجموع  التخفيض " + txtDiscountTotal.EditValue + Environment.NewLine;
                            message += " مجموع المنصرفات " + txtExpensesTotal.EditValue + Environment.NewLine;

                            
                            message += "  صافي المبلغ - النظام " + txtSystemCash.EditValue + Environment.NewLine;
                            message += " المبلغ المتوفر - الموظف " + txtUserCash.EditValue + Environment.NewLine;
                            message += " الفرق " + txtDifrrent.EditValue + Environment.NewLine;
                            message += "-----المنصرفات-----  " + Environment.NewLine;
                            var shift_Expendses = db.vw_Expense.Where(s => s.InsertedUserId == userId && s.Date.Year == currentDate.Year && s.Date.Month == currentDate.Month && s.Date.Day == currentDate.Day);
                            foreach (var expense in shift_Expendses)
                            {
                                message += expense.Description + "   " + expense.Amount + "   " + expense.UserName;
                                message += Environment.NewLine;
                            }
                            message += "-------------------";




                            var insertedUser = db.Users.Where(s => s.ID == userId).SingleOrDefault();
                            PushMessage.SendShiftCloseMessage(insertedUser, message);
                            Thread.Sleep(1500);

                            var list2 = db.vw_ShiftUser.Where(s => s.ShiftID == _shift.ID && s.Flag == 0).ToList();
                            string UserStatusMessage = "   الوضع المالي للموظفين بالوردية" + Environment.NewLine;
                            List<string> userIDs = new List<string>();
                            foreach (var su in list2)
                            {
                                userIDs.Add(su.PushoverID);
                                var userPayment = db.UserPayments.Where(s => s.UserID == su.UserID).OrderByDescending(s => s.ID).Take(1).SingleOrDefault();
                                var amount = userPayment.Amount;
                                var balance = userPayment.Balance;

                                UserStatusMessage += su.FullName + Environment.NewLine + " " + "  أجرة الوردية: " + amount + Environment.NewLine + " " + " المطالبة الحالية: " + balance + Environment.NewLine;
                            }

                            PushMessage.SendUserPaymentStatusMessage(UserStatusMessage, userIDs);
                            Thread.Sleep(1500);
                            PushMessage.SendDailyInventoryStatus(branchID, _shift.LoginTime, _shift.LogoutTime);
                            Thread.Sleep(1500);
                            PushMessage.SendItemWithoutBarcode(branchID, _shift.LoginTime, _shift.LogoutTime);
                           
                            
                        }
                        catch (Exception ex)
                        {
                            //Do nothing 
                        }
                        ExportUSerPaymentReport();
                        ExportShiftReport();

                        MessageBox.Show("تم حفظ تقرير الوردية والتقرير المالي للموظف بسطح المكتب", "تم قفل الورديه بنجاح، ");

                        

                        ////ShiftRPT rpt = new ShiftRPT();
                        ////int userId = Convert.ToInt32(UserData.Default.UserID);
                        ////var list = db.Shifts.Where(s => s.ID == _shift.ID);//.SingleOrDefault();
                        ////if (list != null)
                        ////{
                        ////    rpt.RequestParameters = false;
                        ////    rpt.parameterBranchName.Value = db.Branches.Where(s => s.ID == branchID).SingleOrDefault().BranchName;
                        ////    rpt.parameterUserName.Value = db.Users.Where(s => s.ID == userId).SingleOrDefault().UserName;
                        ////    rpt.DataSource = list.ToList();
                        ////    //rpt.parameterBranchName.Value = UserData.Default.BranchID;
                        ////    //rpt.parameterDate.Value = cmbDate.DateTime;
                        ////    //rpt.parameterInsertedUser.Value = UserData.Default.UserName;
                        ////    try
                        ////    {
                        ////        ReportPrintTool tool = new ReportPrintTool(rpt);
                        ////        tool.ShowPreview();
                        ////    }
                        ////    catch (Exception ex)
                        ////    {
                        ////         ModuleClass.ShowMessage(this, ex, "خطأ", null);
                        ////    }
                        ////}
                        ////else
                        ////{
                        ////    MessageBox.Show("لا توجد ورديه في هذا التاريخ");
                        ////}
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }
        bool ExportShiftReport()
        {
            int userId = Convert.ToInt32(UserData.Default.UserID);
            DateTime currentDate = DateTime.Now;
            ShiftRPT rpt = new ShiftRPT();

            var list = db.Shifts.Where(s => s.ID == _shift.ID);// db.Shifts.Where(s => s.BranchID == branchID && s.UserId == userId && s.LoginTime.Year == cmbDate.DateTime.Year && s.LoginTime.Month == cmbDate.DateTime.Month && s.LoginTime.Day == cmbDate.DateTime.Day);//.SingleOrDefault();

            if (list.Any())
            {
                rpt.parameterBranchName.Value = db.Branches.Where(s => s.ID == branchID).SingleOrDefault().BranchName;
                rpt.parameterUserName.Value = db.Users.Where(s => s.ID == userId).SingleOrDefault().UserName;
                rpt.RequestParameters = false;

                var expendses = db.vw_Expense.Where(s => s.InsertedUserId == userId && s.Date.Year == currentDate.Year && s.Date.Month == currentDate.Month && s.Date.Day == currentDate.Day);
                rpt.bindingSource1.DataSource = list.ToList();
                rpt.DataSource = expendses.ToList();
                try
                {
                    ReportPrintTool tool = new ReportPrintTool(rpt);
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    rpt.ExportToPdf(path+"\\" + UserData.Default.UserName+ "_Shift_" + DateTime.Now.ToLongDateString() + ".pdf");

                    
                    //rpt.ExportToPdf( fileName );
                    //System.Diagnostics.Process.Start(fileName);
                    Thread.Sleep(2000);

                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        bool ExportUSerPaymentReport()
        {
            try
            {
                int userId = Convert.ToInt32(UserData.Default.UserID);
                UserPaymentRPT rpt = new UserPaymentRPT();
                //var _shift = db.Shifts.Where(s=> s.ID == _shift.ID)

                DateTime from = new DateTime(_shift.LoginTime.Year, _shift.LoginTime.Month, _shift.LoginTime.Day, _shift.LoginTime.Hour, _shift.LoginTime.Minute, _shift.LoginTime.Second);
                DateTime to = new DateTime(_shift.LogoutTime.Year, _shift.LogoutTime.Month, _shift.LogoutTime.Day, _shift.LogoutTime.Hour, _shift.LogoutTime.Minute, _shift.LogoutTime.Second);

                //int userId = Convert.ToInt32(userID);
                var list = db.UserPayments.Where(s => s.Date >= from && s.Date <= to && s.UserID == userID);
                //s => s.Date.Year >= from.Year && s.Date.Month >= from.Month && s.Date.Day >= from.Day && s.Date.Year <= to.Year && s.Date.Month <= to.Month && s.Date.Day <= to.Day);
                Decimal amountHour = list.Where(s => s.Amount > 0).Select(s => (Decimal?)s.Amount).Sum() ?? 0;
                Decimal expence = list.Where(s => s.Amount < 0).Select(s => (Decimal?)s.Amount).Sum() ??0;

                if (list.Any())
                {
                    //  rpt.DataSource = list;
                    rpt.DataSource = list.ToList();
                    //rpt.parameterBranchName.Value = UserData.Default.BranchID;
                    rpt.parameterFromDate.Value = from;
                    rpt.parameterToDate.Value = to;//cmbExpenseUser.GetColumnValue("FullName").ToString();
                    rpt.parameterUserName.Value = UserData.Default.UserName;
                    rpt.parameterTotalAmount.Value = amountHour.ToString();
                    rpt.parameterTotalExpense.Value = expence.ToString();
                    rpt.parameterNetAmount.Value = (amountHour - (Math.Abs(expence))).ToString();
                    decimal demand = list.OrderByDescending(s => s.ID).AsEnumerable().First().Balance;
                    rpt.parameterCurrentDemand.Value = demand;
                    int NumOfShift = list.Where(s => s.PaymentType == 1).Select(s => DbFunctions.TruncateTime(s.Date)).Distinct().Count();
                    rpt.parameterNumOfShift.Value = NumOfShift;
                    try
                    {
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        rpt.ExportToPdf(path + "\\"+UserData.Default.UserName + "_Payment_" + DateTime.Now.ToLongDateString() + ".pdf");
                    }
                    catch (Exception ex)
                    {
                        //ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnExpenseReport_Click(object sender, EventArgs e)
        {
            try
            {

                ExpenseRPT rpt = new ExpenseRPT();
                // string BranchName = cmbBranch.GetColumnValue("BranchName").ToString();
                // rpt.parameterBranchName.Value = BranchName;
                int userId = Convert.ToInt32(UserData.Default.UserID);
                var list = db.vw_Expense.Where(s => s.BranchID == branchID && s.InsertedUserId == userId && s.ShiftID == ModuleClass.shiftID);//  s.Date.Year == DateTime.Now.Year && s.Date.Month == DateTime.Now.Month && s.Date.Day == DateTime.Now.Day);
                if (list.Any())
                {
                    //  rpt.DataSource = list;
                    rpt.DataSource = list.ToList();
                    rpt.parameterBranchName.Value = UserData.Default.BranchID;
                    rpt.parameterFromDate.Value = DateTime.Now;
                    rpt.parameterToDate.Value = UserData.Default.UserName;
                    try
                    {
                        ReportPrintTool tool = new ReportPrintTool(rpt);
                        tool.ShowPreview();
                    }
                    catch (Exception ex)
                    {
                         ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                    }
                }
                else
                {
                    MessageBox.Show("لا توجد منصرفات في هذا التاريخ");
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnNewExpense_Click(object sender, EventArgs e)
        {
            try
            {

                ExpensesForm frm = new ExpensesForm();
                frm.ShowDialog();
                getExpenses();
                shiftBindingSource.ResetBindings(true);
                CalculateNetAmounts();
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnAddElectricityBalance_Click(object sender, EventArgs e)
        {
            try
            {
                InputBox.SetLanguage(InputBox.Language.English);
                //Save the DialogResult as res
                DialogResult res = InputBox.ShowDialog("القيمة:", " رصيد كهرباء جديد",
                    InputBox.Icon.Question,
                    InputBox.Buttons.OkCancel,
                    InputBox.Type.TextBox,
                    new string[] { "Item1", "Item2", "Item3" },
                    true,
                    new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));
                //Check InputBox result
                if (((InputBox.ResultValue != "") && (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)))
                {
                    Decimal amount = Convert.ToDecimal(InputBox.ResultValue);

                    _shift.ElectricityAmountStart += amount;
                    txtElectricityAmountStart.EditValue = _shift.ElectricityAmountStart;
                    shiftBindingSource.ResetBindings(true);
                    CalculateNetAmounts();

                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime frm = new DateTime(_shift.LoginTime.Year, _shift.LoginTime.Month, _shift.LoginTime.Day, _shift.LoginTime.Hour, _shift.LoginTime.Minute, _shift.LoginTime.Second);
                DateTime to = new DateTime(_shift.LogoutTime.Year, _shift.LogoutTime.Month, _shift.LogoutTime.Day, _shift.LogoutTime.Hour, _shift.LogoutTime.Minute, _shift.LogoutTime.Second);

                var saleList = from s in db.vw_SaleReport where s.Flag != 0 && s.UserID == userID && s.Date > frm && s.Date < to && s.BranchID == branchID && s.Remarks != "Expire" select s;
                if (saleList.Any())
                {

                    SaleSummaryRPT rpt = new SaleSummaryRPT();
                    //rpt.RequestParameters
                    string BranchName = db.Branches.Where(s => s.ID == branchID).SingleOrDefault().BranchName;
                    rpt.parameterBranchName.Value = BranchName;
                    rpt.DataSource = saleList.ToList();
                    try
                    {
                        rpt.RequestParameters = false;
                        ReportPrintTool tool = new ReportPrintTool(rpt);
                        tool.ShowPreview();
                    }
                    catch (Exception ex)
                    {
                         ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                    }
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات بالتقرير");
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void btnAddZainBalance_Click(object sender, EventArgs e)
        {
            try
            {
                InputBox.SetLanguage(InputBox.Language.English);
                //Save the DialogResult as res
                DialogResult res = InputBox.ShowDialog("القيمة:", " رصيد زين جديد",
                    InputBox.Icon.Question,
                    InputBox.Buttons.OkCancel,
                    InputBox.Type.TextBox,
                    new string[] { "Item1", "Item2", "Item3" },
                    true,
                    new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));
                //Check InputBox result
                if (((InputBox.ResultValue != "") && (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)))
                {
                    Decimal amount = Convert.ToDecimal(InputBox.ResultValue);

                    _shift.ZainVoucherMachineBalanceStart += amount;
                    //txtZainVoucherMachineBalanceStart.EditValue = _shift.ZainVoucherMachineBalanceStart;
                    shiftBindingSource.ResetBindings(true);
                    CalculateNetAmounts();

                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void DeviceStatus(object sender, EventArgs e)
        {
            try
            {
                ToggleSwitch ts = sender as ToggleSwitch;
                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        bool SendDevicesStatus()
        {
            string message = "";
            bool status = true;
            if (!tsColorPrinter.IsOn)
            {
                message += tsColorPrinter.Properties.OffText + "\n";
                status = false;
            }
            if (!tsFax.IsOn)
            {
                message += tsFax.Properties.OffText + "\n";
                status = false;
            }
            if (!tsLaserPrinter.IsOn)
            {
                message += tsLaserPrinter.Properties.OffText + "\n";
                status = false;
            }
            if (!tsPackingMachine.IsOn)
            {
                message += tsPackingMachine.Properties.OffText + "\n";
                status = false;
            }
            if (!tsPhotocopier.IsOn)
            {
                message += tsPhotocopier.Properties.OffText + "\n";
                status = false;
            }
            if (!tsScanner.IsOn)
            {
                message += tsScanner.Properties.OffText + "\n";
                status = false;
            }
            if (!status)
            {
                try
                {
                    PushMessage.SendDevicesStatusMessage(UserData.Default.UserName + Environment.NewLine + " @ Reda" + UserData.Default.BranchID + Environment.NewLine + message);
                    ////Thread thread = new Thread(() => PushMessage.SendDevicesStatusMessage(UserData.Default.UserName + Environment.NewLine + " @ Reda" + UserData.Default.BranchID + Environment.NewLine + message));
                    ////thread.Start();
                }
                catch (Exception ex)
                {
                    //Do nothing 
                }
                return true;
            }
            else
            {
                message = "جميع الأجهزة تعمل بصورة جيدة";
                try
                {

                    Thread thread = new Thread(() => PushMessage.SendDevicesStatusMessage(UserData.Default.UserName + " @ Reda" + UserData.Default.BranchID + Environment.NewLine + message));
                    thread.Start();
                }
                catch (Exception ex)
                {
                    //Do nothing 
                }
                return true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CalculateNetAmounts();
        }
    }
}
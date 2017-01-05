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
using System.Threading;

namespace WinForm
{
    public partial class ExpensesForm : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        DataAccess.Expense _expense;
        int branchID = 0;
        public ExpensesForm()
        {
            InitializeComponent();
            _expense = db.Expenses.Create();
            _expense.Date = DateTime.Now;
            _expense.InsertedUserId = Convert.ToInt32(UserData.Default.UserID);
            _expense.BranchID = Convert.ToInt32(UserData.Default.BranchID);
            _expense.ShiftID = ModuleClass.shiftID;
            bindingSourceExpense.DataSource = _expense;
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            try
            {
                userBindingSource.DataSource = db.Users.Where(s=> s.IsEnable == true).ToList();
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
                if (isValid())
                {
                    int userID = _expense.UserID;
                    string toUser = cmbExpensesTo.Text;
                    DateTime from = new DateTime(_expense.Date.Year, _expense.Date.Month, _expense.Date.Day, 0, 0, 0);
                    DateTime to = new DateTime(_expense.Date.Year, _expense.Date.Month, _expense.Date.Day, 23, 59, 59);

                    int MaxExpensePerDay =Convert.ToInt32( db.Users.Where(s => s.ID == userID).SingleOrDefault().MaxExpensePerDay);
                   

                    var todayExpensePerDay = db.vw_Expense.Where(s => s.UserID == userID && (s.Date >= from && s.Date <= to)).DefaultIfEmpty().Sum(s => (decimal?)s.Amount ?? 0);
                    if ((todayExpensePerDay + _expense.Amount) > MaxExpensePerDay)
                    {

                        MessageBox.Show("أقصي مبلغ يمكن صرفه ل  " + toUser + "  خلال اليوم هو  " + MaxExpensePerDay + Environment.NewLine + "  المنصرف اليومي حتي الآن " + todayExpensePerDay, "لا يمكن صرف المبلغ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }


                    int MaxExpensePerMonth = Convert.ToInt32(db.Users.Where(s => s.ID == userID).SingleOrDefault().MaxExpensePerMonth);
                    from = new DateTime(_expense.Date.Year, _expense.Date.Month, 1, 0, 0, 0);
                    to = new DateTime(_expense.Date.Year, _expense.Date.Month, DateTime.DaysInMonth(_expense.Date.Year, _expense.Date.Month), 23, 59, 59);
                    var todayExpensePerMonth = db.vw_Expense.Where(s => s.UserID == userID && (s.Date >= from && s.Date <= to)).DefaultIfEmpty().Sum(s => (decimal?)s.Amount ?? 0);
                    if ((todayExpensePerMonth + _expense.Amount) > MaxExpensePerMonth)
                    {

                        MessageBox.Show("أقصي مبلغ يمكن صرفه ل  " + toUser + "  خلال الشهر هو  " + MaxExpensePerMonth + Environment.NewLine + "  المنصرف الشهري حتي الآن " + todayExpensePerMonth, "لا يمكن صرف المبلغ",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        return;
                    }
                    if (_expense.ShiftID == 0)
                    {
                        ////MessageBox.Show("لا يمكن حفظ البيانات، الرجاء مراجعة مسؤول النظام");
                        ////return;

                        
                        _expense.ShiftID = 30;
                    }
                    db.Expenses.Add(_expense);
                    if (db.SaveChanges() > 0)
                    {
                        //Send To Whatsapp
                        try
                        {
                           
                            var ExpenseToUser = cmbExpensesTo.GetSelectedDataRow() as DataAccess.User;
                            int userId = Convert.ToInt32(UserData.Default.UserID);
                            var insertedUser = db.Users.Where(s=> s.ID == userId).SingleOrDefault();
                            var usersMobileNos = db.Users.Where(s => s.IsEnable == true && s.IsAdmin == true).Select(s => s.MobileNo).ToList();
                            string recervers = "";
                            //foreach (var item in usersMobileNos)
                            //{
                            //    recervers += (item + ",");
                            //}


                            string message = "تم صرف مبلغ "+_expense.Amount+" لصالح "+ExpenseToUser.FullName+ " عبارة عن  " + _expense.Description+" تم الإدخال بواسطة "+insertedUser.FullName;
                            var userPayment = db.UserPayments.Where(s => s.UserID == _expense.UserID).OrderByDescending(s => s.ID).Take(1).SingleOrDefault();

                            var amount = userPayment.Amount;
                            var balance = userPayment.Balance;

                            message+= Environment.NewLine + " " + "  آخر منصرف: " + amount + Environment.NewLine + " " + " المطالبة الحالية: " + balance + Environment.NewLine;
                            
                            Thread thread = new Thread(() => PushMessage.SendDialyExpense(insertedUser, ExpenseToUser, message));
                            thread.Start();

                            //send by Email

                            //string EmailReceivers = emails;// UserData.Default.EmailReceivers;
                            //Thread emailThread = new Thread(() => ModuleClass.SendEmail("", "منصرف", message));
                            //emailThread.Start();
                            MessageBox.Show(message, "تم حفظ المنصرف");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            //Do nothing 
                        }
                        //
                        MessageBox.Show("تم الحفظ");

                        _expense = db.Expenses.Create();
                        _expense.Date = DateTime.Now;
                        _expense.InsertedUserId = Convert.ToInt32(UserData.Default.UserID);
                        _expense.BranchID = Convert.ToInt32(UserData.Default.BranchID);
                        bindingSourceExpense.DataSource = _expense;
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
            if(Convert.ToInt32(cmbExpensesTo.EditValue) ==0)
            {
                errorProvider1.SetError(cmbExpensesTo, "الرجاء تحديد المستفيد");
                result = false;
            }

            if (Convert.ToInt32(AmountTextEdit.EditValue) <=0)
            {
                errorProvider1.SetError(AmountTextEdit, "الرجاء تحديد القيمة");
                result = false;
            }

            if (Convert.ToString(DescriptionTextEdit.EditValue).Length <= 7 )
            {
                errorProvider1.SetError(DescriptionTextEdit, "الرجاء كتابة ملاحظات واضحه");
                result = false;
            }

            return result;
        }
    }
}
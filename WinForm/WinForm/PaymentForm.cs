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
using WinForm;
using System.Threading;

namespace RedaPOS
{
    public partial class PaymentForm : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        DataAccess.Payment payment;
        public PaymentForm()
        {
            InitializeComponent();
            paymentTypeBindingSource.DataSource = db.PaymentTypes.Where(s=> s.DirectPayment == false).ToList();
            payment = db.Payments.Create();
            payment.Date = DateTime.Now;
            db.Payments.Add(payment);
            this.bindingSource1.DataSource = payment;
        }
        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomValidate())
                {
                    payment.Amount = payment.Amount * -1;
                    if (db.SaveChanges() > 0)
                    {
                        try
                        {
                            string message = "";
                            message += "  تم صرف قيمة " + AmountTextEdit.EditValue + Environment.NewLine;
                            message += "  عبارة عن " + txtDescription.Text + Environment.NewLine;
                            message += "  نوع المنصرف " + PaymentTypeIdTextEdit.Text + Environment.NewLine;
                            message += "   المستخدم " + UserData.Default.UserName + Environment.NewLine;

                            var usersMobileNos = db.Users.Where(s => s.IsAdmin == true).Select(s => s.MobileNo).ToList();
                            Thread thread = new Thread(() => PushMessage.SendPayment(message));// UserData.Default.WhatsAppReceivers, message));
                            thread.Start();

                            //send by Email
                            string EmailReceivers = db.Users.Where(s => s.IsAdmin == true).Select(s => s.Email).ToList().ToString();// UserData.Default.EmailReceivers;
                            //Thread emailThread = new Thread(() => ModuleClass.SendEmail("", "منصرف رئيسي ", message));
                            //emailThread.Start();
                        }
                        catch (Exception ex)
                        {
                            //Do nothing 
                        }
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }

        private bool CustomValidate()
        {
            bool isValid = true;
            errorProvider1.Clear();
            if (payment.Description == null || payment.Description == "")
            {
                errorProvider1.SetError(txtDescription, "يجب تحديد ,صف وافي للمنصرف");
                isValid = false;
            }
            if (payment.Amount == null || payment.Amount ==0)
            {
                errorProvider1.SetError(AmountTextEdit, "يجب تحديد  القيمة");
                isValid = false;
            }
            if (payment.PaymentTypeId == null || payment.PaymentTypeId== 0)
            {
                errorProvider1.SetError(PaymentTypeIdTextEdit, "يجب تحديد  نوع المنصرف");
                isValid = false;
            }
            return isValid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
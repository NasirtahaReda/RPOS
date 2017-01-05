using System;
using System.Collections.ObjectModel;
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
using WinForm.Reports;
using System.Data.Linq;
using DevExpress.XtraReports.UI;
namespace WinForm
{
    public partial class SaleInvoiceConfirm : DevExpress.XtraEditors.XtraForm
    {
        private BindingList<DataAccess.SaleInvoiceDetail> details;
        decimal invoiceTotal = 0;
        int branchID = 0;
        DataAccess.RedaV1Entities db;
        string InvoicePrinter = "";
        decimal dicountAllowed = 10;
        private List<DataAccess.vw_Sale2> rptList;
        public SaleInvoiceConfirm(List<DataAccess.vw_Sale2> rptList, BindingList<DataAccess.SaleInvoiceDetail> details, DataAccess.RedaV1Entities db, string InvoicePrinter)
        {
            InitializeComponent();
            this.details = details;
            this.db = db;
            this.rptList = rptList;
            foreach (var item in details)
            {
                invoiceTotal += (item.UnitPrice * item.Quanitity);
            }
            txtInvoiceTotal.EditValue = invoiceTotal;
            branchID = Convert.ToInt32(UserData.Default.BranchID);
            this.InvoicePrinter = InvoicePrinter;

            dicountAllowed = db.Companies.Take(1).SingleOrDefault().DiscountValue;
        }

        private void SaleInvoiceConfirm_Load(object sender, EventArgs e)
        {
            txtCashFromCustomer.Focus();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(Custom_Validate())
                {
                    DoInvoice(true);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
        private void btn_ConfirmWithouPrint_Click(object sender, EventArgs e)
        {
            if (Custom_Validate())
            {
                DoInvoice(false);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
        private void DoInvoice(bool print)
        {
            
            DataAccess.SaleInvoice invoice = new DataAccess.SaleInvoice();
            invoice.Date = DateTime.Now;
            invoice.UserID = Convert.ToInt32(UserData.Default.UserID);
            invoice.Remarks = "Sale";

            invoice.BranchID = branchID;
            invoice.Flag = 0;

            db.SaleInvoices.Add(invoice);
            //I use a trigger to update inventory
           
            foreach (var item in details)
            {
                item.SaleInvoiceID = invoice.ID;
                invoice.SaleInvoiceDetails.Add(item);

            }
            invoice.Total = Convert.ToDecimal(txtInvoiceTotal.Text);
            invoice.Discount = Convert.ToDecimal(txtDiscount.Text);
            int savedRows = db.SaveChanges();
            if (savedRows > 0)
            {
                invoice.Flag = 1;//To call trigger
                savedRows = db.SaveChanges();
                if(print)
                {
                    DoPrint(invoice.ID);
                }
            }
        }

        void DoInvoiceSave()
        {


        }
        void DoPrint(int invoiceID)
        {
            
            decimal cashFromCustomer = Convert.ToDecimal(txtCashFromCustomer.EditValue);
            decimal CashReturn = Convert.ToDecimal(txtCashReturn.EditValue);
            Reports.SaleRpt rpt = new SaleRpt(Convert.ToDecimal(txtDiscount.EditValue), Convert.ToDecimal(txtAfterDiscount.EditValue),cashFromCustomer, CashReturn, invoiceID.ToString(), UserData.Default.UserName);
            ////var list = from s in db.vw_Sale2 where s.SaleInvoiceID == invoiceID select s;
            ////rpt.DataSource = list.ToList();
            rpt.DataSource = rptList.ToList();
            ////txtAfterDiscount.EditValue = 0;
            ////txtInvoiceTotal.EditValue = 0;
            ////txtDiscount.EditValue = 0;
            try
            {
                ReportPrintTool tool = new ReportPrintTool(rpt);
              //  string InvoicePrinter = System.Configuration.ConfigurationManager.AppSettings["InvoicePrinter"];
                if (InvoicePrinter == "")
                {
                    tool.Print();
                }
                else
                {
                    tool.Print(InvoicePrinter);
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
       
        private bool Custom_Validate()
        {

            bool result = true;
            errorProvider1.Clear();
            decimal discount = Convert.ToDecimal(txtDiscount.EditValue);
               decimal cashFromCustomer = Convert.ToDecimal(txtCashFromCustomer.EditValue);
               decimal CashReturn = Convert.ToDecimal(txtCashReturn.EditValue);
               
               if (discount > (invoiceTotal * dicountAllowed / 100))
            {
                errorProvider1.SetError(txtDiscount, "أكبر تخفيض يمكن منحه هو:" + (invoiceTotal * dicountAllowed / 100) + "  جنيه ");//, "قيمة التخفيض أكبر من 10% من مجموع الفاتورة");
                result = false;
            }

            if (cashFromCustomer < (invoiceTotal -discount))
            {
               errorProvider1.SetError(txtCashFromCustomer,"القيمة المستلمة من الزبون اقل من قيمة الفاتورة");
                result = false;
            }
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCashFromCustomer_EditValueChanged(object sender, EventArgs e)
        {
            CalculateCash();
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateCash();
        }

        private void CalculateCash()
        {
            try
            {
                decimal discount = Convert.ToDecimal(txtDiscount.EditValue);
                decimal cashFromCustomer = Convert.ToDecimal(txtCashFromCustomer.EditValue);

                txtCashReturn.EditValue = cashFromCustomer - invoiceTotal + discount;

                txtAfterDiscount.EditValue = invoiceTotal - discount;
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtDiscount_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                decimal invoiceTotal = 0;
                foreach (var item in details)
                {
                    invoiceTotal += (item.UnitPrice * item.Quanitity);
                }
                decimal output = 0;
                Decimal.TryParse(e.NewValue.ToString(),out output);
                decimal discount = output;
                if (discount > (invoiceTotal * 10 / 100))
                {
                    errorProvider1.SetError(txtDiscount, "أكبر تخفيض يمكن منحه هو : " + (invoiceTotal * 10 / 100));
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void txtCashFromCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiscount.Focus();
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ConfirmWithouPrint.Focus();
            }
        }


       
    }
}
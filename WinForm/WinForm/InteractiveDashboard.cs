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
using System.Data.SqlClient;
using RedaPOS.Reports;
using DevExpress.XtraReports.UI;

namespace RedaPOS
{
   
    public partial class InteractiveDashboard : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccess.RedaV1Entities db = ModuleClass.GetConnection();// new DataAccess.RedaV1Entities(ModuleClass.Connect());

        public DataSet GetDataSet(string ConnectionString, string SQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
        public InteractiveDashboard()
        {
            try
            {
                InitializeComponent();

               // DataSet ds = GetDataSet(db.Database.Connection.ConnectionString, "select * From vw_SalesByMonth");

                branchBindingSource.DataSource = db.Branches.ToList();

                var list1 = db.vw_TopSale.Where(s => s.BranchID == 1 && s.Quanitity < 6000).OrderByDescending(s => s.Quanitity).Take(15);
                var list2 = db.vw_TopSale.Where(s => s.BranchID == 2 && s.Quanitity < 6000).OrderByDescending(s => s.Quanitity).Take(15);
                bindingSource1.DataSource = list1.ToList();
                bindingSource2.DataSource = list2.ToList();

               
                var listByMonth1 = db.vw_SalesByMonth.SqlQuery("select * From vw_SalesByMonth");//.Where(s => s.ID == 1);//.OrderByDescending(s => s.MONTH);
               // var listByMonth2 = db.vw_SalesByMonth.OrderByDescending(s => s.MONTH);
             //   bindingSourceSaleByMonth1.DataSource = ds.Tables[0];// listByMonth1.ToList();
               // bindingSourceSaleByMonth2.DataSource = listByMonth2.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbBranches_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int branchID = Convert.ToInt32(cmbBranches.EditValue);
                var list = db.vw_TopSale.Where(s=> s.BranchID == branchID).OrderByDescending(s => s.Quanitity).Take(25);
                bindingSource1.DataSource = list.ToList();
            }
            catch (Exception ex)
            {
                
                //throw;
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            try
            {
                int branchID = Convert.ToInt32(cmbBranchSummary.EditValue);
                
              

                ProfitlossRPT rpt = new ProfitlossRPT();


                DateTime from = new DateTime(cmbFrom.DateTime.Year, cmbFrom.DateTime.Month, cmbFrom.DateTime.Day, 0, 0, 0);
                DateTime to = new DateTime(cmbTo.DateTime.Year, cmbTo.DateTime.Month, cmbTo.DateTime.Day, 23, 59, 59);
                var summary = db.Summary(branchID, from, to);
                
                if (summary.Any())
                {
                    //  rpt.DataSource = list;
                    rpt.bindingSource1.DataSource= summary.ToList();
                    //rpt.parameterBranchName.Value = UserData.Default.BranchID;
                    rpt.parameterFrom.Value = cmbFrom.DateTime;
                    rpt.parameterTo.Value = cmbTo.DateTime;//cmbExpenseUser.GetColumnValue("FullName").ToString();
                    rpt.parameterBranchName.Value = cmbBranchSummary.Text;
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
                    MessageBox.Show("لا توجد بيانات في هذا التاريخ");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

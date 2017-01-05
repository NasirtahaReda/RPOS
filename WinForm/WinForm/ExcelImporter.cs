using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel;
using System.Data.OleDb;
using System.Data.SqlTypes;

namespace WinForm
{
    public partial class ExcelImporter : Form
    {
        DataAccess.RedaV1Entities db = new DataAccess.RedaV1Entities(ModuleClass.Connect());
        public ExcelImporter()
        {
            InitializeComponent();
        }

        private void ExcelImporter_Load(object sender, EventArgs e)
        {

        }
        public DataSet ImportExcelXLS(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                             FileName + ";Extended Properties=\"Excel 8.0;HDR=" +
                             HDR + ";IMEX=1\"";

            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                  OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = "";
                    try
                    {
                         sheet = schemaRow[2].ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;

                    }

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                    cmd.CommandType = CommandType.Text;

                    DataTable outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                }
            }
            return output;
        }
        public DataSet ImportExcel(string filePath, bool is2007)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            if (is2007)
            { 
                IExcelDataReader excelReader2007 = ExcelReaderFactory.CreateOpenXmlReader(stream);
                excelReader2007.IsFirstRowAsColumnNames = true;
                DataSet result2007 = excelReader2007.AsDataSet();


               
                excelReader2007.Close();
                return result2007;
            }
            else
            {

                IExcelDataReader excelReader2003 = ExcelReaderFactory.CreateBinaryReader(stream);
               
                excelReader2003.IsFirstRowAsColumnNames = true;
                DataSet result2003 = excelReader2003.AsDataSet();
                excelReader2003.Close();

                return result2003;
            }
            
            //...
           
         
            //...

            //...
            //4. DataSet - Create column names from first row
          
            

            //5. Data Reader methods
            ////while (excelReader2003.Read())
            ////{
            ////    //excelReader.GetInt32(0);
            ////}

            //6. Free resources (IExcelDataReader is IDisposable)
          

           
        }

        private void btnImportAircraft_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Inventory inventory;
                DataSet mainDS = ImportExcelXLS("C:\\Excel Files\\Reda1.xls", true);

                DataTable dtSale = mainDS.Tables[1];
                ////var resultsSale = from myRow in dtSale.AsEnumerable()
                ////              //where myRow.Field<int>("RowNo") == 1
                ////              select myRow;

                DataTable dtDetails = mainDS.Tables[3];

                

                

                DataAccess.SaleInvoice saleInvoice = null;
                int Salecounter = 0;
                int Detailscounter = 0;
                foreach (DataRow item in mainDS.Tables[1].Rows)
                {
                    


                    string i = item["ID"].ToString().Trim();
                    int ID = 0;
                    Int32.TryParse(i, out ID);

                    Salecounter++;
                    string d = item["Date"].ToString().Trim();
                    DateTime Date;
                    DateTime.TryParse(d, out Date);

                    string u = item["UserID"].ToString().Trim();
                    int UserID =0;
                    Int32.TryParse(u, out UserID);

                    string f = item["Flag"].ToString().Trim();
                    int Flag = 0;
                    Int32.TryParse(f, out Flag);


                    string Remarks = item["Remarks"].ToString().Trim();

                    string r = item["Total"].ToString().Trim();
                    decimal Total = 0;
                     Decimal.TryParse(r, out Total);



                     string dis = item["Discount"].ToString().Trim();
                    decimal Discount = 0;
                    Decimal.TryParse(dis, out Discount);

                    int BranchID = 1;

                   
                    

                    
                    if (Flag == 1)
                    {
                      
                        saleInvoice = db.SaleInvoices.Create();
                        saleInvoice.BranchID = BranchID;
                        saleInvoice.Date = Date;
                        saleInvoice.Discount = Discount;
                        saleInvoice.Flag = 9;
                        saleInvoice.Remarks = "Reda1" + ID;
                        saleInvoice.Total = Total;
                        saleInvoice.UserID = UserID;
                        db.SaleInvoices.Add(saleInvoice);

                        var resultsDetails = from myRow in dtDetails.AsEnumerable()
                                             where myRow.Field<string>("SaleInvoiceID") == i
                                             select myRow;

                        DataAccess.SaleInvoiceDetail child;// = db.SaleInvoiceDetails.Create();
                        foreach (var details in resultsDetails)
                        {
                            child = db.SaleInvoiceDetails.Create();
                            Detailscounter++;

                            string it = details["ItemID"].ToString().Trim();
                            int ItemID = 0;
                            Int32.TryParse(it, out ItemID);

                            string inv = details["InventoryID"].ToString().Trim();
                            int InventoryID = 0;
                            Int32.TryParse(inv, out InventoryID);

                            string q = details["Quanitity"].ToString().Trim();
                            int Quanitity = 0;
                            Int32.TryParse(q, out Quanitity);

                            string un = details["UnitPrice"].ToString().Trim();
                            decimal UnitPrice = 0;
                            Decimal.TryParse(un, out UnitPrice);

                            child.CurrentQuanitity = 0;
                            child.InventoryID = InventoryID;
                            child.ItemID = ItemID;
                            child.PurchaseQuantity = 0;
                            child.Quanitity = Quanitity;
                            child.Remarks = i;
                            child.UnitPrice = UnitPrice;
                            saleInvoice.SaleInvoiceDetails.Add(child);

                            inventory = db.Inventories.Where(s => s.ID == child.InventoryID).SingleOrDefault();
                            inventory.CurrentQuanity -= child.Quanitity;

                           
                        }
                        int savedRow =db.SaveChanges();
                        if ( savedRow> 0)
                        {

                        }
                       
                    }
                }
                MessageBox.Show(Salecounter.ToString() + "  row inserted", " Details: " + Detailscounter);

            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private DataSet getExcelFile()
        {
            DataSet ds = null;
            openFileDialog1.Filter = "2007 xlsx files (*.xlsx)|*.xlsx|2003 xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = "C:\\Excel Files";
            openFileDialog1.Title = "Select an Excel file";
            openFileDialog1.FileName = string.Empty;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                if (file != null && file != String.Empty)
                {
                    if (openFileDialog1.FilterIndex == 1)
                    {
                        ds = ImportExcelXLS(file, true);// ImportExcel(file, true);
                    }
                    else
                        if (openFileDialog1.FilterIndex == 2)
                        {
                            ds = ImportExcelXLS(file, true);// ImportExcel(file, false);
                        }
                }
                else
                {
                    MessageBox.Show("Incorrect file");
                }
            }

            return ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Inventory inv;
                var list = db.SaleInvoices.Where(s => s.Remarks.Contains("Reda"));
                foreach (var item in list.ToList())
                {
                    item.Flag = 1;
                  //  if (item.ID > 36650)
                    {
                        foreach (var child in item.SaleInvoiceDetails.ToList())
                        {
                            inv = db.Inventories.Where(s => s.ID == child.InventoryID).SingleOrDefault();
                            inv.CurrentQuanity -= child.Quanitity;

                            if (db.SaveChanges() > 0)
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

   
      

        

       

      
    }
}

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
using DevExpress.XtraGrid.Views.Grid;
using DataAccess;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;
using WinForm;
using System.Threading;

namespace RedaPOS
{
    public partial class TransferForm : DevExpress.XtraEditors.XtraForm
    {
        DataAccess.PurchaseInvoice purchaseInvoice;
        DataAccess.RedaV1Entities db;
        DataAccess.DamegeDS.DamegeDTDataTable DT = null;
        bool hasError = false;
        public TransferForm(DataAccess.PurchaseInvoice purchaseInvoice, DataAccess.RedaV1Entities db)
        {

            InitializeComponent();
            this.db = db;
            this.purchaseInvoice = purchaseInvoice;
            this.bindingSource1.DataSource = this.purchaseInvoice;
            var list = db.vw_PurchaseDetails.Where(s => s.PurchaseInvoiceID == purchaseInvoice.ID && s.BranchID == purchaseInvoice.BranchID).ToList();
             DT = new DataAccess.DamegeDS.DamegeDTDataTable();
            foreach (var item in list)
            {
                var newRow = DT.NewDamegeDTRow();
                newRow.BranchID = item.BranchID.ToString();
                newRow.CurrentQuanity = item.CurrentQuanity.ToString();
                newRow.ID = item.ID.ToString();
                newRow.ItemID = item.ItemID.ToString();
                newRow.Name = item.Name.ToString();
                newRow.PurchaseInvoiceDetailID = item.PurchaseInvoiceDetailID.ToString();
                newRow.PurchaseInvoiceID = item.PurchaseInvoiceID.ToString();
                newRow.PurchasePrice = item.PurchasePrice.ToString();
                newRow.Quantity = item.Quantity.ToString();
                newRow.ReceiveQuantity = item.ReceiveQuantity.ToString();
                newRow.Reda1 = (Math.Round(Convert.ToDecimal(item.Quantity)/3)).ToString();
                newRow.Reda2 = (Math.Round(Convert.ToDecimal(item.Quantity) / 3)).ToString();
                //newRow.Reda3 = (Convert.ToDecimal(item.Quantity) - Math.Round(Convert.ToDecimal(item.Quantity) / 3)).ToString();
                newRow.Reda3 = Math.Floor(Convert.ToDecimal(item.Quantity) / 3).ToString();


                DT.AddDamegeDTRow(newRow);

            }
            this.vwPurchaseDetailsBindingSource.DataSource = DT;
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {
            try
            {
                //string cellValue = gridView1.GetRowCellValue(2, "ID").ToString();
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn, "New Value");
                
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                
            }
        }
        
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if(hasError)
                {
                    MessageBox.Show("لا يمكن تحويل الأصناف الا بعد معالجة الأخطاء الموجدة");
                    return;
                }
                //Validate gird
               
                //for (int i = 0; i < gridView1.RowCount; i++)
                //{
                //    int rowHandle = gridView1.GetVisibleRowHandle(i);
                   
                //    if (gridView1.IsDataRow(rowHandle))
                //    {
                //        gridView1.FocusedRowHandle = rowHandle;
                //        hasError = gridView1.HasColumnErrors;
                //    }
                //}



                if (MessageBox.Show("هل أنت متأكد من إجراء العملية؟", "سيتم تحويل الكميات بالفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    StringBuilder pushMSG1 = new StringBuilder();
                    StringBuilder pushMSG2 = new StringBuilder();
                    StringBuilder pushMSG3 = new StringBuilder();
                    SaleInvoice invoice1, invoice2, invoice3;
                    invoice1 = new SaleInvoice();
                    invoice1.BranchID = 0;//المخزن
                    invoice1.Date = DateTime.Now;
                    invoice1.Discount = 0;
                    invoice1.Flag = 0;
                    invoice1.Remarks = "Transfer";
                    invoice1.Total = 0;
                    invoice1.UserID = Convert.ToInt32(UserData.Default.UserID);
                    db.SaleInvoices.Add(invoice1);

                    invoice2 = new SaleInvoice();
                    invoice2.BranchID = 0;//المخزن
                    invoice2.Date = DateTime.Now;
                    invoice2.Discount = 0;
                    invoice2.Flag = 0;
                    invoice2.Remarks = "Transfer";
                    invoice2.Total = 0;
                    invoice2.UserID = Convert.ToInt32(UserData.Default.UserID);
                    db.SaleInvoices.Add(invoice2);

                    invoice3 = new SaleInvoice();
                    invoice3.BranchID = 0;//المخزن
                    invoice3.Date = DateTime.Now;
                    invoice3.Discount = 0;
                    invoice3.Flag = 0;
                    invoice3.Remarks = "Transfer";
                    invoice3.Total = 0;
                    invoice3.UserID = Convert.ToInt32(UserData.Default.UserID);
                    db.SaleInvoices.Add(invoice3);


                    SaleInvoiceDetail detail1;
                    SaleInvoiceDetail detail2;
                    SaleInvoiceDetail detail3;
                    //   PurchaseInvoice purchaseInvoice1 = new PurchaseInvoice();
                    DataAccess.PurchaseInvoice purchaseInvoice1 = db.PurchaseInvoices.Create();
                    purchaseInvoice1.BranchID = 1;
                    purchaseInvoice1.Date = DateTime.Now;
                    purchaseInvoice1.Discount = 0;
                    purchaseInvoice1.Flag = 0;
                    purchaseInvoice1.Number = "Transfer Reda1" + purchaseInvoice.ID;
                    purchaseInvoice1.Total = 0;
                    purchaseInvoice1.UserID = Convert.ToInt32(UserData.Default.UserID);
                    db.PurchaseInvoices.Add(purchaseInvoice1);


                    //PurchaseInvoice purchaseInvoice2 = new PurchaseInvoice();
                    DataAccess.PurchaseInvoice purchaseInvoice2 = db.PurchaseInvoices.Create();
                    purchaseInvoice2.BranchID = 2;
                    purchaseInvoice2.Date = DateTime.Now;
                    purchaseInvoice2.Discount = 0;
                    purchaseInvoice2.Flag = 0;
                    purchaseInvoice2.Number = "Transfer Reda2" + purchaseInvoice.ID;
                    purchaseInvoice2.Total = 0;
                    purchaseInvoice2.UserID = Convert.ToInt32(UserData.Default.UserID);
                    db.PurchaseInvoices.Add(purchaseInvoice2);

                    DataAccess.PurchaseInvoice purchaseInvoice3 = db.PurchaseInvoices.Create();
                    purchaseInvoice3.BranchID = 3;
                    purchaseInvoice3.Date = DateTime.Now;
                    purchaseInvoice3.Discount = 0;
                    purchaseInvoice3.Flag = 0;
                    purchaseInvoice3.Number = "Transfer Reda2" + purchaseInvoice.ID;
                    purchaseInvoice3.Total = 0;
                    purchaseInvoice3.UserID = Convert.ToInt32(UserData.Default.UserID);
                    db.PurchaseInvoices.Add(purchaseInvoice3);


                    PurchaseInvoiceDetail purchaseInvoiceDetail1;
                    PurchaseInvoiceDetail purchaseInvoiceDetail2;
                    PurchaseInvoiceDetail purchaseInvoiceDetail3;
                    foreach (var row in DT.Rows)
                    {
                        detail1 = new SaleInvoiceDetail();
                        detail2 = new SaleInvoiceDetail();
                        detail3 = new SaleInvoiceDetail();

                        DataAccess.DamegeDS.DamegeDTRow currentRow = (DataAccess.DamegeDS.DamegeDTRow)row;
                        detail1.InventoryID = Convert.ToInt32(currentRow.ID);
                        detail1.ItemID = Convert.ToInt32(currentRow.ItemID);
                        detail1.PurchaseQuantity = Convert.ToInt32(currentRow.Quantity);
                        detail1.Quanitity = Convert.ToInt32(currentRow.Reda1);
                        detail1.Remarks = "Transfer from purchase invoice id: " + purchaseInvoice.ID;
                        detail1.SaleInvoiceID = invoice1.ID;
                        detail1.UnitPrice = Convert.ToDecimal(currentRow.PurchasePrice);

                        pushMSG1.Append(currentRow.Name + "  " + currentRow.Reda1).Append(Environment.NewLine);

                        invoice1.SaleInvoiceDetails.Add(detail1);

                        detail2.InventoryID = Convert.ToInt32(currentRow.ID);
                        detail2.ItemID = Convert.ToInt32(currentRow.ItemID);
                        detail2.PurchaseQuantity = Convert.ToInt32(currentRow.Quantity);
                        detail2.Quanitity = Convert.ToInt32(currentRow.Reda2);
                        detail2.Remarks = "Transfer from purchase invoice id: " + purchaseInvoice.ID;
                        detail2.SaleInvoiceID = invoice1.ID;
                        detail2.UnitPrice = Convert.ToDecimal(currentRow.PurchasePrice);
                        pushMSG2.Append(currentRow.Name + "  " + currentRow.Reda2).Append(Environment.NewLine);
                        invoice2.SaleInvoiceDetails.Add(detail2);

                        detail3.InventoryID = Convert.ToInt32(currentRow.ID);
                        detail3.ItemID = Convert.ToInt32(currentRow.ItemID);
                        detail3.PurchaseQuantity = Convert.ToInt32(currentRow.Quantity);
                        detail3.Quanitity = Convert.ToInt32(currentRow.Reda3);
                        detail3.Remarks = "Transfer from purchase invoice id: " + purchaseInvoice.ID;
                        detail3.SaleInvoiceID = invoice1.ID;
                        detail3.UnitPrice = Convert.ToDecimal(currentRow.PurchasePrice);
                        pushMSG3.Append(currentRow.Name + "  " + currentRow.Reda2).Append(Environment.NewLine);
                        invoice3.SaleInvoiceDetails.Add(detail3);

                        //Purchase details 1
                        purchaseInvoiceDetail1 = db.PurchaseInvoiceDetails.Create(); //new PurchaseInvoiceDetail();
                        purchaseInvoiceDetail1.DiscountPrice = 0;
                        purchaseInvoiceDetail1.ItemID = Convert.ToInt32(currentRow.ItemID);
                        //purchaseInvoiceDetail1.PurchaseInvoiceID = purchaseInvoice1.ID;
                        purchaseInvoiceDetail1.PurchasePrice = Convert.ToDecimal(currentRow.PurchasePrice);
                        purchaseInvoiceDetail1.Quantity = Convert.ToInt32(currentRow.Reda1);
                        purchaseInvoiceDetail1.Remarks = "Transfer from purchase invoice id: " + purchaseInvoice.ID;
                        purchaseInvoiceDetail1.SalePrice = 0;
                        purchaseInvoice1.PurchaseInvoiceDetails.Add(purchaseInvoiceDetail1);

                        //Purchase details 2
                        purchaseInvoiceDetail2 = db.PurchaseInvoiceDetails.Create(); //new PurchaseInvoiceDetail();
                        purchaseInvoiceDetail2.DiscountPrice = 0;
                        purchaseInvoiceDetail2.ItemID = Convert.ToInt32(currentRow.ItemID);
                        //purchaseInvoiceDetail2.PurchaseInvoiceID = purchaseInvoice1.ID;
                        purchaseInvoiceDetail2.PurchasePrice = Convert.ToDecimal(currentRow.PurchasePrice);
                        purchaseInvoiceDetail2.Quantity = Convert.ToInt32(currentRow.Reda2);
                        purchaseInvoiceDetail2.Remarks = "Transfer from purchase invoice id: " + purchaseInvoice.ID;
                        purchaseInvoiceDetail2.SalePrice = 0;
                        purchaseInvoice2.PurchaseInvoiceDetails.Add(purchaseInvoiceDetail2);

                        //Purchase details 3
                        purchaseInvoiceDetail3 = db.PurchaseInvoiceDetails.Create(); //new PurchaseInvoiceDetail();
                        purchaseInvoiceDetail3.DiscountPrice = 0;
                        purchaseInvoiceDetail3.ItemID = Convert.ToInt32(currentRow.ItemID);
                        //purchaseInvoiceDetail2.PurchaseInvoiceID = purchaseInvoice1.ID;
                        purchaseInvoiceDetail3.PurchasePrice = Convert.ToDecimal(currentRow.PurchasePrice);
                        purchaseInvoiceDetail3.Quantity = Convert.ToInt32(currentRow.Reda3);
                        purchaseInvoiceDetail3.Remarks = "Transfer from purchase invoice id: " + purchaseInvoice.ID;
                        purchaseInvoiceDetail3.SalePrice = 0;
                        purchaseInvoice3.PurchaseInvoiceDetails.Add(purchaseInvoiceDetail3);

                    }

                    if (db.SaveChanges() > 0)
                    {
                        invoice1.Flag = 1;
                        invoice2.Flag = 1;
                        invoice3.Flag = 1;
                        purchaseInvoice1.Flag = 1;
                        purchaseInvoice2.Flag = 1;
                        purchaseInvoice3.Flag = 1;
                        if (db.SaveChanges() > 0)
                        {
                            PushMessage.SendTransferItems("رضا1" + Environment.NewLine + pushMSG1.ToString());
                            Thread.Sleep(3000);
                            PushMessage.SendTransferItems("رضا2" + Environment.NewLine + pushMSG2.ToString());
                            Thread.Sleep(3000);
                            PushMessage.SendTransferItems("رضا3" + Environment.NewLine + pushMSG3.ToString());
                            MessageBox.Show("تم التحويل بنجاح");
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("لم يتم التحويل");
                    }
                }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
            ////GridView view = sender as GridView;
            ////    if (e.Column.Name == "gridColumn1" && e.IsGetData && e.Value == null)
            ////    {
            ////        decimal Quantity = Convert.ToDecimal(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Quantity"));
            ////        e.Value = Math.Round(Quantity / 2);//getTotalValue(view, e.ListSourceRowIndex);
            ////        rowcount++;
            ////    }
            ////    if (e.Column.Name == "gridColumn2" && e.IsGetData)
            ////    {
            ////        decimal Quantity = Convert.ToDecimal(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Quantity"));
            ////        e.Value = (Quantity - (Math.Round(Quantity / 2)));//getTotalValue(view, e.ListSourceRowIndex);
            ////    }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
              //for (int i = 0; i < gridView1.DataRowCount; i++)
            //    {
            //        //var row = gridView1.GetDataRow(i);
            //        string CurrentQuanity = gridView1.GetRowCellValue(i, "CurrentQuanity").ToString();
            //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColumn1, CurrentQuanity);
            //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColumn2, "0");

            //        //..
            //    }
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                
            }

        }
        public string GetError(object value, int rowHandle, GridColumn column)
        {
            int result =0;
            int  CurrentQuanity =Convert.ToInt32( gridView1.GetRowCellValue(rowHandle, "CurrentQuanity").ToString());
            int Reda1 =Convert.ToInt32( gridView1.GetRowCellValue(rowHandle, "Reda1").ToString());
            int Reda2 = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "Reda2").ToString());
            int Reda3 = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "Reda3").ToString());

            if ((Reda1 + Reda2 + Reda3) > CurrentQuanity)
            {
                hasError = true;
                string errorMSG = " مجموع التحويل أكبر  من كمية المخزن" + CurrentQuanity;
               // gridView1.SetColumnError(column, errorMSG);
                return errorMSG;
            }
            else
            {
                hasError = false;
            }
            return string.Empty;
        }

        void SetError(BaseEditViewInfo cellInfo, string errorIconText)
        {
            if (errorIconText == string.Empty) return;
            cellInfo.ErrorIconText = errorIconText;
            cellInfo.ShowErrorIcon = true;
            cellInfo.FillBackground = true;
            cellInfo.ErrorIcon = DXErrorProvider.GetErrorIconInternal(ErrorType.Critical);
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colReda1 || e.Column == colReda2)
            {
                BaseEditViewInfo info = ((GridCellInfo)e.Cell).ViewInfo;
                
                string error = GetError(e.CellValue, e.RowHandle, e.Column);
                SetError(info, error);
                info.CalcViewInfo(e.Graphics);
            }
        }

        private void cbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void checkedListBoxControl1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnRefreshBranches_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void btnRefreshBranches_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in checkedListBoxControl1.CheckedItems)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
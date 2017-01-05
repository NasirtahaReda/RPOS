using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class MainScreen : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DevExpress.XtraTab.XtraTabPage currPage;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            
        }

              private void AddControl(Control ctrl, string caption)
        {
           
            DevExpress.XtraTab.XtraTabPage newTab = new DevExpress.XtraTab.XtraTabPage();
            newTab.Controls.Add(ctrl);
            newTab.Text = newTab.Name = caption;

            newTab.Controls[ctrl.Name].Dock = DockStyle.Fill;

            if (ContainsKey(newTab.Name))
            {
                xtraTabControl1.SelectedTabPage = currPage;
            }
            else
            {
                xtraTabControl1.TabPages.Add(newTab);
                xtraTabControl1.SelectedTabPage = newTab;
            }
        }

        public bool ContainsKey(string tabPageName)
        {
            bool res = false;
            foreach (DevExpress.XtraTab.XtraTabPage currTab in xtraTabControl1.TabPages)
            {
                if (currTab.Text.Equals(tabPageName))
                {
                    res = true;
                    currPage = currTab;
                    //tabIndex = currTab.
                    break;
                }
            }
            return res;
        }

        private void btnCategories_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AddControl(new GategoryUC(), "Categories");
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }
        public void ShowMessageInStatusBar(String Message, int time)
        {
            lblMessage.Caption = Message;
            timer1.Interval = time;
            timer1.Start();
        }

        private void btnItems_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AddControl(new ItemUC(), "Items");
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMessage.Caption = "";
            timer1.Stop();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

            this.Text = versionInfo.FileDescription + "  " + versionInfo.FileVersion;
        }

        private void ribbonStatusBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnShowPurchaseInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AddControl(new PurchaseInvoiceUC(), "Purchase Invoices");
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnShowSaleInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AddControl(new SaleUC(), "Sale Invoices");
            }
            catch (Exception ex)
            {
                 ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }
    }
}

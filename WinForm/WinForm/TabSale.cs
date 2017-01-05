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

namespace RedaPOS
{
    public partial class TabSale :DevExpress.XtraEditors.XtraUserControl
    {
        BindingList<DataAccess.SaleInvoiceDetail> details = null;
        public TabSale()
        {
            InitializeComponent();
        }
    }
}
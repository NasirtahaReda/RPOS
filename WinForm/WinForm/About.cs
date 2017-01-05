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
using System.Reflection;
using RedaPOS;

namespace WinForm
{
    public partial class About : DevExpress.XtraEditors.XtraForm
    {
        public About()
        {
            InitializeComponent();
            //var branch = db.Branches.Where(s => s.ID == BranchID).SingleOrDefault();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyTitleAttribute assembly = executingAssembly.GetCustomAttribute<AssemblyTitleAttribute>();
            AssemblyFileVersionAttribute assemblyVersion = executingAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            this.Text = assembly.Title + " " + assemblyVersion.Version + " ( " + UserData.Default.UserName + " ) ";// +branch.BranchName;

            //this.memoEdit1.EditValue = this.memoEdit1.ToolTip;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
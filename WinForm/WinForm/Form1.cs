using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraScheduler;

namespace WinForm
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Value", typeof(string));
            myLookUpEdit1.Properties.DataSource = dt;
            myLookUpEdit1.Properties.ValueMember = "ID";
            myLookUpEdit1.Properties.DisplayMember = "Value";


        }

        Random random = new Random();

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }


        private void myLookUpEdit1_Properties_GetAutoCompleteList(object sender, WinForm.AutoCompleteListEventArgs e)
        {
            DataTable dt = (e.AutoCompleteList as DataView).Table;
            dt.Clear();
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add(new object[] { i, String.Format("{0}{1}", e.AutoSearchText, RandomString(5, true)) });
                //e.AutoCompleteList.Add(String.Format("{0}{1}", e.AutoSearchText, RandomString(5, true)));
            }
            //e.AutoCompleteList = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
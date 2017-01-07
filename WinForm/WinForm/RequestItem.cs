using System;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using RedaPOS;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.Entity;

namespace WinForm
{


    public partial class RequestItem : DevExpress.XtraEditors.XtraForm
    {
        int itemID = 0;
        int branchID = 0;
        int userID = 0;
        int quantity = 0;

        SqlConnectionStringBuilder sqlBulider = new SqlConnectionStringBuilder();
        DataAccess.RedaV1Entities db = null;// new DataAccess.RedaV1Entities(ModuleClass.Connect());
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public RequestItem()
        {
            try
            {
                InitializeComponent();
                //string connString = ModuleClass.Connect();
                //DataAccess.RedaV1Entities db = ModuleClass.GetConnection();//= new DataAccess.RedaV1Entities(ModuleClass.Connect());
                db = ModuleClass.GetConnection();
                DevExpress.UserSkins.BonusSkins.Register();

                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute assembly = executingAssembly.GetCustomAttribute<AssemblyTitleAttribute>();
                AssemblyFileVersionAttribute assemblyVersion = executingAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
                /*
                                DataTable dt = new DataTable();
                                dt.Columns.Add("ID", typeof(int));
                                dt.Columns.Add("Name", typeof(string));

                                cmbSearch.Properties.DataSource = dt;
                                cmbSearch.Properties.ValueMember = "ID";
                                cmbSearch.Properties.DisplayMember = "Name";
                                */

                cmbSearch.Properties.ValueMember = "ID";
                cmbSearch.Properties.DisplayMember = "Value";

                //cmbSearch.Properties.PopupFilterMode = PopupFilterMode.Contains
                //  myLookUpEdit1.Properties.PopulateColumns();
                // myLookUpEdit1.Properties.Columns[0].Visible = false;
                //this.myLookUpEdit1.Properties.PopulateColumns();
                db.Items.Load();

                //LoadData();
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }

        }
        private void AddUserToShift_Load(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoLogin()
        {

            try
            {

            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }


        }
        void WriteSesssion(DataAccess.User ValidUser, bool sendEmai, string emailTitle)
        {
        }




        private void txtUserName_EditValueChanged(object sender, EventArgs e)
        {

        }



        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRequest.Focus();
            }
        }

        private void cmbBranches_EditValueChanged(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }
        DateTime GetServerTime()
        {
            var objectContext = (db as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext;


            var dQuery = objectContext.CreateQuery<DateTime>("CurrentDateTime() ");
            DateTime dbDate = dQuery.AsEnumerable().First();



            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = (short)dbDate.Year; // must be short
            st.wMonth = (short)dbDate.Month;
            st.wDay = (short)dbDate.Day;
            st.wHour = (short)dbDate.Hour;
            st.wMinute = (short)dbDate.Minute;
            st.wSecond = (short)dbDate.Second;

            SetSystemTime(ref st); // invoke this method.


            return dbDate;
        }
        private void LoadData()
        {
            try
            {
                userBindingSource1.DataSource = db.Users.Where(s => s.IsEnable != false).ToList();
                //txtPassword.EditValue = "";
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxErrorProvider1.HasErrors)
                {
                    DataAccess.Request request = db.Requests.Create();
                    itemID = 0;

                    userID = Convert.ToInt32(UserData.Default.UserID);
                    string UserName = Convert.ToString(UserData.Default.UserName);
                    branchID = Convert.ToInt32(UserData.Default.BranchID);
                    quantity = Convert.ToInt32(txtQuantity.EditValue);
                    string desciption = txtDescription.Text;

                    if (true)
                    {
                        request.UserID = userID;
                        request.BranchID = branchID;
                        request.RequestDate = DateTime.Now;
                        request.Quantity = quantity;
                        request.Description = desciption;
                        db.Requests.Add(request);

                        if (db.SaveChanges() > 0)
                        {
                            var message = "" + UserData.Default.BranchName + " فرع " + UserName + " من المستخدم   " + lblItem.Text + " تمت طلب الصنف ";
                            PushMessage.SendDirectMessage(message);
                            MessageBox.Show("تم حفظ الطلب و إرساله للإدارة", "شكرا لاهتمامك");
                            Thread.Sleep(1500);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("الرجاء التأكد من اسم المستخدم وكلمة المرور");
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);
                db = ModuleClass.GetConnection();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ////string query = txtSearch.Text;
                ////if (e.KeyCode == Keys.Enter && txtSearch.Text.Length > 2)
                ////{
                ////    bindingSourceInventory.DataSource = (from s in db.Items.Local where s.Name.Contains(query) select s).ToList();// db.vw_Inventory.ToList();
                ////}
                ////else
                ////{
                ////    // this.bindingSourceInventory.DataSource = null;
                ////}
            }
            catch (Exception ex)
            {
                ModuleClass.ShowExceptionMessage(this, ex, "خطأ", null);

            }
        }

        private void cmbSearch_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {

                //string query = cmbSearch.Text;
                //var list = (from s in db.Items.Local where s.Name.Contains(query) select s).ToList();
                //itemBindingSource.DataSource = list;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void myLookUpEdit1_Properties_GetAutoCompleteList(object sender, AutoCompleteListEventArgs e)
        {
            try
            {
                string query = e.AutoSearchText;

                //itemBindingSource.DataSource = list;

                //  itemBindingSource.DataSource = db.Items.Local.ToList();

                //DataTable dt = (e.AutoCompleteList as DataView).Table;
                //dt.Clear();
                if (query.Length > 2)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("Value", typeof(string));

                    var list = (from s in db.Items.Local where s.Name.Contains(query) select s).ToList();

                    int i = 0;
                    foreach (var item in list)
                    {
                        dt.Rows.Add(new object[] { item.ID, item.Name });
                        //e.AutoCompleteList.Add(String.Format("{0}{1}", e.AutoSearchText, RandomString(5, true)));
                    }
                    e.AutoCompleteList = dt;
                    /*
                    cmbSearch.Properties.PopulateColumns();
                    cmbSearch.Properties.Columns["ID"].Visible = false;
                    cmbSearch.Properties.Columns["Name"].Caption = "الصنف";
                    */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            //e.AutoCompleteList = dt;
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

        private void cmbSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var val = cmbSearch.EditValue.ToString();
                lblItem.Text = cmbSearch.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string barcodeText = txtBar.Text;
                    if (txtBar.Text != "")
                    {

                        if (txtBar.Text.Length >= 6)
                        {
                            var ItemsFound = db.ItemBarcodes.Local.Where(s => s.BarcodeText == barcodeText);
                            var ItemIDs = ItemsFound.Select(s => s.ItemID);

                            if (ItemIDs != null && ItemIDs.Any())
                            {
                            }
                            else
                            {
                                this.bindingSourceInventory.DataSource = null;
                                MessageBox.Show("هذا الصنف غير متوفر");
                                txtBar.Text = "";
                                //lblInventoryQuantity.Text = "";
                                //lblItemName.Text = "";
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
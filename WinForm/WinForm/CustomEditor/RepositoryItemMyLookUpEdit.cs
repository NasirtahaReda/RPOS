using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using System.Collections.Generic;

namespace WinForm
{
    public class AutoCompleteListEventArgs : EventArgs
    {
        public AutoCompleteListEventArgs(string autoSearchText, object list)
        {
            _AutoCompleteList = list;
            _AutoSearchText = autoSearchText;
        }
        private object _AutoCompleteList;

        private string _AutoSearchText;
        public string AutoSearchText
        {
            get { return _AutoSearchText; }
        }


        public object AutoCompleteList
        {
            get { return _AutoCompleteList; }
            set { _AutoCompleteList = value; }
        }
    }
    public delegate void GetAutoCompleteListEventHandler(object sender, AutoCompleteListEventArgs e);

    [System.ComponentModel.DesignerCategory("")]
    [UserRepositoryItem("Register")]
    public class RepositoryItemMyLookUpEdit : RepositoryItemLookUpEdit
    {

        static readonly object getAutoCompleteList = new object();

        public event GetAutoCompleteListEventHandler GetAutoCompleteList
        {
            add
            {
                Events.AddHandler(getAutoCompleteList, value);
                OnPropertiesChanged();
            }
            remove
            {
                this.Events.RemoveHandler(getAutoCompleteList, value);
                OnPropertiesChanged();
            }
        }

        #region OnGetAutoCompleteList
        /// <summary>
        /// Triggers the GetAutoCompleteList event.
        /// </summary>
        public virtual void RaiseGetAutoCompleteList(AutoCompleteListEventArgs ea)
        {
            GetAutoCompleteListEventHandler handler = (GetAutoCompleteListEventHandler)Events[getAutoCompleteList];
            if (handler != null) handler(GetEventSender(), ea);
        }
        #endregion

        static RepositoryItemMyLookUpEdit()
        {
            Register();
        }
        public RepositoryItemMyLookUpEdit()
        {
            DataSource = new List<string>();
            ImmediatePopup = true;
            TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

        }

        internal const string EditorName = "MyLookUpEdit";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(MyLookUpEdit),
                typeof(RepositoryItemMyLookUpEdit), typeof(DevExpress.XtraEditors.ViewInfo.LookUpEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));
        }
        public override string EditorTypeName
        {
            get { return EditorName; }
        }
        public void UpdateDataSource(string autoSearchText)
        {
            //List<string> items = DataAdapter.DataSource as List<string>;
            //RaiseGetAutoCompleteList(new AutoCompleteListEventArgs(autoSearchText, items));
            object dataSource = new object();
            AutoCompleteListEventArgs args = new AutoCompleteListEventArgs(autoSearchText, dataSource);
            RaiseGetAutoCompleteList(args);
            DataAdapter.SetDataSource(args.AutoCompleteList);

        }
    }
}

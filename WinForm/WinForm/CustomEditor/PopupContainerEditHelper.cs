using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;

namespace WinForm
{
    public class PopupContainerEditHelper
    {
        public PopupContainerEditHelper(RepositoryItemPopupContainerEdit popupContainerEdit)
        {
            RepositoryItem = popupContainerEdit;

            PopuControl = CreatePopuControl();
            CheckedListBox = CreateCheckedListBoxControl();
            
            CheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            //CheckedListBox.CheckOnClick = true;
            PopuControl.Controls.Add(CheckedListBox);
            RepositoryItem.TextEditStyle = TextEditStyles.Standard;
            RepositoryItem.PopupControl = PopuControl;

            SubscribeEditor();
        }

        #region Methods
        private void SubscribeEditor()
        {
            RepositoryItem.QueryResultValue += new QueryResultValueEventHandler(RepositoryItem_QueryResultValue);
            RepositoryItem.QueryDisplayText += new QueryDisplayTextEventHandler(RepositoryItem_QueryDisplayText);
        }
        void RepositoryItem_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            e.DisplayText = string.Join(";", GetCheckedText());
        }

        private IEnumerable<string> GetCheckedText()
        {
            foreach (int number in CheckedListBox.SelectedIndices)
                yield return CheckedListBox.GetItemText(number);
        }

        private IEnumerable<object> GetCheckedValues()
        {
            foreach (int number in CheckedListBox.SelectedIndices)
                yield return CheckedListBox.GetItemValue(number);
        }

        void RepositoryItem_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = GetCheckedValues().ToArray();
        }

        protected virtual PopupContainerControl CreatePopuControl()
        {
            return new PopupContainerControl();
        }

        protected virtual ListBoxControl CreateCheckedListBoxControl()
        {
            return new ListBoxControl();
        }
        #endregion

        #region Properties
        public string ValueMember
        {
            get
            {
                return CheckedListBox.ValueMember;
            }
            set
            {
                CheckedListBox.ValueMember = value;
            }
        }
        public string DisplayMember
        {
            get { return CheckedListBox.DisplayMember; }
            set
            {
                CheckedListBox.DisplayMember = value;
            }
        }
        

        public object DataSource
        {
            get { return CheckedListBox.DataSource; }
            set { CheckedListBox.DataSource = value; }
        }
        
        public ListBoxItemCollection Items
        {
            get
            {
                return CheckedListBox.Items;
            }
        }

        public ListBoxControl CheckedListBox { get; private set; }
        public PopupContainerControl PopuControl { get; private set; }
        public RepositoryItemPopupContainerEdit RepositoryItem { get; private set; }
        #endregion
    }
}

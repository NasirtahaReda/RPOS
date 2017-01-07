using System.ComponentModel;
using DevExpress.XtraEditors;

namespace WinForm
{
    [System.ComponentModel.DesignerCategory("")]
    public class MyLookUpEdit : LookUpEdit
    {
        static MyLookUpEdit()
        {
            RepositoryItemMyLookUpEdit.Register();
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemMyLookUpEdit.EditorName; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyLookUpEdit Properties
        {
            get { return base.Properties as RepositoryItemMyLookUpEdit; }
        }


        protected override void ProcessFindItem(DevExpress.XtraEditors.Controls.KeyPressHelper helper, char pressedKey)
        {
            AssignDataSource(AutoSearchText);
            base.ProcessFindItem(helper, pressedKey);
        }

        private void AssignDataSource(string autoSearchText)
        {
            Properties.UpdateDataSource(autoSearchText);

        }

    }

}

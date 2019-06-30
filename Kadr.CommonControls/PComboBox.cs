using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace Kadr.CommonControls
{
    public class PComboBox : LookUpEdit
    {
        public PComboBox()
        {
            EnterMoveNextControl = true;
            Properties.ShowHeader = false;
            Properties.DropDownItemHeight = 20;
            Properties.NullText = "";
            Properties.ValidateOnEnterKey = true;
            Properties.DisplayMember = "SPNAME";
            Properties.ValueMember = "SPID";

            //this.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SPID", "Коди", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SPNAME", "Номи", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});

            Properties.AllowNullInput = DefaultBoolean.True;
            KeyDown += POnKeyDown;
        }

        private void POnKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == 8) || (e.KeyValue == 46))
            {
                EditValue = null;
            }
        }
    }

    public class PComboBoxNotNull : LookUpEdit
    {
        public PComboBoxNotNull()
        {
            EnterMoveNextControl = true;
            Properties.ShowHeader = false;
            Properties.DropDownItemHeight = 20;
            Properties.NullText = "";
            Properties.ValidateOnEnterKey = true;
            Properties.DisplayMember = "SPNAME";
            Properties.ValueMember = "SPID";

            //this.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SPID", "Коди", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SPNAME", "Номи", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});

            Properties.AllowNullInput = DefaultBoolean.False;
        }
    }
}
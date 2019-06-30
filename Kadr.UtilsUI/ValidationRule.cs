using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using Apteka.Utils;

namespace Kadr.UtilsUI
{
    public class ValidationRuleDecimal : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (!(control is TextEdit))
            {
                return false;
            }
            TextEdit edit = (TextEdit)control;

            var v = Convert.ToDecimal(edit.EditValue);

            return string.IsNullOrEmpty(edit.Text) || ((v >= Value1) && (v <= Value2));
        }
        
        public decimal Value1 { get; set; }

        public decimal Value2 { get; set; }
    }

    public class ValidationRuleInt : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (!(control is TextEdit))
            {
                return false;
            }
            TextEdit edit = (TextEdit)control;

            var v = Convert.ToInt64(edit.EditValue);

            return string.IsNullOrEmpty(edit.Text) || ((v >= Value1) && (v <= Value2));
        }

        public Int64 Value1 { get; set; }

        public Int64 Value2 { get; set; }
    }

    public class ValidationRuleDateTime : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (!(control is TextEdit))
            {
                return false;
            }
            TextEdit edit = (TextEdit)control;

            var v = edit.EditValue.ToDateTime();

            return string.IsNullOrEmpty(edit.Text) || ((v >= Value1) && (v <= Value2));
        }

        public DateTime Value1 { get; set; }

        public DateTime Value2 { get; set; }
    }
}

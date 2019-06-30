using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace Kadr.CommonControls
{
    public class PLabelRight : LabelControl
    {
        public PLabelRight()
        {
            Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            AutoSizeMode = LabelAutoSizeMode.Vertical;
        }
    }
}
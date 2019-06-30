using DevExpress.XtraEditors;

namespace Kadr.CommonControls
{
    public class PLabelLine : LabelControl
    {
        public PLabelLine()
        {
            LineVisible = true;
            LineLocation = LineLocation.Center;
            LineOrientation = LabelLineOrientation.Horizontal;
        }
    }
}
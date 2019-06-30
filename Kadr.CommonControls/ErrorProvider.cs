using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Kadr.CommonControls
{
    public class dxErrorProvider : DXErrorProvider
    {
        internal void SetControlsError(IList<Control> lstControl, string errorText, ErrorType errorType)
        {
            foreach (var objControl in lstControl)
            {
                SetError(objControl, errorText, errorType);
            }
        }

        internal void SetControlsError(IList<Control> lstControl, ErrorType errorType)
        {
            SetControlsError(lstControl, String.Empty, errorType);
        }

        internal void RemoveControlsError(IList<Control> lstControl)
        {
            foreach (var objControl in lstControl)
            {
                RemoveErrorInfo(objControl);
            }
        }
    }
}
using System;
using System.Runtime.InteropServices;

namespace Apteka.Utils
{
    public class CHDDKey
    {
        [DllImport("HddKey.dll", EntryPoint = "GetAcKey", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetAcKey();

        public static string GetHDDSerialNo()
        {
            IntPtr key = GetAcKey();
            string sresult = Marshal.PtrToStringAnsi(key);
            return sresult;
        }
    }
}
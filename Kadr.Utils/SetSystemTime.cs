using System;
using System.Runtime.InteropServices;

namespace Apteka.Utils
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }


    public static class CSystemTime
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public static void Set(DateTime d)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = (short)d.Year; // must be short
            st.wMonth = (short)d.Month;
            st.wDay = (short)d.Day;
            st.wHour = (short)d.Hour;
            st.wMinute = (short)d.Minute;
            st.wSecond = (short)d.Second;

            SetSystemTime(ref st); // invoke this method.
        }
    }
}

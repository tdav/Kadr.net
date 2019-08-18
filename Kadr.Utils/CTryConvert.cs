using System;

namespace Apteka.Utils
{
    public static class TryConvert
    {
        public static bool ToBool(object v, out bool value)
        {
            try
            {
                value = Convert.ToBoolean(v);
                return true;
            }
            catch (Exception)
            {
                value = false;
                return false;
            }
        }

        public static bool ToInt(object v, out int value)
        {
            try
            {
                value = Convert.ToInt32(v);
                return true;
            }
            catch (Exception)
            {
                value = -1;
                return false;
            }
        }

        public static bool ToInt64(object v, out Int64 value)
        {
            try
            {
                value = Convert.ToInt64(v);
                return true;
            }
            catch (Exception)
            {
                value = -1;
                return false;
            }
        }

        public static bool ToDecimal(object v, out decimal value)
        {
            try
            {
                value = Convert.ToDecimal(v);
                return true;
            }
            catch (Exception)
            {
                value = -1;
                return false;
            }
        }

        public static bool ToDateTime(object v, out DateTime value)
        {
            try
            {
                value = Convert.ToDateTime(v, System.Threading.Thread.CurrentThread.CurrentCulture);
                return true;
            }
            catch (Exception)
            {
                value = DateTime.MinValue;
                return false;
            }
        }

        public static bool ToDate(object v, out DateTime value)
        {
            try
            {
                value = Convert.ToDateTime(v, System.Threading.Thread.CurrentThread.CurrentCulture).Date;
                return true;
            }
            catch (Exception)
            {
                value = DateTime.MinValue;
                return false;
            }
        }

        public static bool ToGuid(object v, out Guid value)
        {
            try
            {
                var s = v.ToString();               

                if (!string.IsNullOrWhiteSpace( s) && Guid.Parse(s)==Guid.Empty)
                {
                    value = Guid.NewGuid();
                    return false;
                }

                value = Guid.Parse(v.ToString());
                return true;
            }
            catch (Exception)
            {
                value = Guid.NewGuid();
                return false;
            }
        }

    }
}

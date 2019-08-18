using System;
using Microsoft.Win32;

namespace Apteka.Utils
{
    public class CRegistry
    {
        private static bool IsStartupItem(string keyname)
        {
            var rkApp = Registry.LocalMachine.OpenSubKey(Environment.Is64BitOperatingSystem ? "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run" : "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            return rkApp == null || rkApp.GetValue(keyname) != null;
        }

        public static void SetAutoRun(string app, string path)
        {
            var rkApp = Registry.LocalMachine.OpenSubKey(Environment.Is64BitOperatingSystem ? "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run" : "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (!IsStartupItem(app))
            {
                rkApp?.SetValue(app, path);
            }
        }


        public static bool ValueExistCU(string path, string name)
        {
            var rk = Registry.CurrentUser.CreateSubKey(path);
            try
            {
                return rk?.GetValue(name) != null;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                rk?.Close();
            }
        }

        public static string GetValueHKCU(string path, string name, string defaultValue)
        {
            string res = "";
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(path);
            try
            {
                if (rk.GetValue(name) == null)
                {
                    SetValueHKCU(path, name, defaultValue);
                    res = defaultValue;
                }
                else
                    res = rk.GetValue(name).ToString();
            }
            catch (Exception err)
            {
                CEventLog.Write(string.Format("CRegistry.GetValueHKCU({0},{1},{2}) -> {3}", path, name, defaultValue, err.GetAllMessages()));
            }
            finally
            {
                rk.Close();
            }
            return res;
        }

        public static void SetValueHKCU(string path, string name, string value)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(path);
            try
            {
                rk.SetValue(name, value);
            }
            catch (Exception err)
            {
                CEventLog.Write(string.Format("CRegistry.SetValue({0},{1},{2}) -> {3}", path, name, value, err.Message));
            }
            finally
            {
                rk.Close();
            }
        }

        public static string GetValueHKLM(string path, string name)
        {
            string res = "";
            RegistryKey rk = Registry.LocalMachine.CreateSubKey(path, RegistryKeyPermissionCheck.ReadSubTree);
            try
            {
                string value = rk.GetValue(name).ToString();
                res = value;
            }
            catch (Exception err)
            {
                CEventLog.Write(string.Format("CRegistry.GetValueHKLM({0},{1}) -> {2}", path, name, err.GetAllMessages()));
            }
            finally
            {
                rk.Close();
            }
            return res;
        }
        public static string GetValueHKLM(string path, string name, string defaultValue)
        {
            string res = defaultValue;
            RegistryKey rk = Registry.LocalMachine.CreateSubKey(path, RegistryKeyPermissionCheck.ReadSubTree);
            try
            {
                string value = rk.GetValue(name).ToString();
                if (value.IsNotEmpty())
                    res = value;
            }
            catch (Exception err)
            {
                CEventLog.Write(string.Format("CRegistry.GetValueHKLM({0},{1},{2}) -> {3}", path, name, defaultValue, err.GetAllMessages()));
            }
            finally
            {
                rk.Close();
            }
            return res;
        }

        public static void SetValueHKLM(string path, string name, object defaultValue)
        {
            RegistryKey rk = Registry.LocalMachine.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
            try
            {
                rk.SetValue(name, defaultValue);
            }
            catch (Exception err)
            {
                CEventLog.Write(string.Format("CRegistry.GetValueHKLM({0},{1},{2}) -> {3}", path, name, defaultValue, err.GetAllMessages()));
            }
            finally
            {
                rk.Close();
            }
        }


        public static string GetValue(string name, string defval)
        {
            string res = "";
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\BIOPasport");
            try
            {
                string value = rk.GetValue(name).ToString();
                res = value;
            }
            catch (Exception e)
            {
                CLog.Write("CRegistry->GetValue  " + e.Message);
                rk.SetValue(name, defval);
                res = defval;
            }
            rk.Close();
            return res;
        }

        public static string GetValue(string name)
        {
            string res = "";
            try
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\BIOPasport");
                string value = rk.GetValue(name).ToString();
                rk.Close();
                res = value;
            }
            catch (Exception e)
            {
                CLog.Write("CRegistry->GetValue  " + e.Message);
            }
            return res;
        }

        public static void SetValue(string name, string value)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\BIOPasport");
                rk.SetValue(name, value);
                rk.Close();
            }
            catch (Exception e)
            {
                CLog.Write("CRegistry->SetValue  " + e.Message);
            }
        }
    }
}
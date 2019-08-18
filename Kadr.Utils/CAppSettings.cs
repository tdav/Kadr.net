using System.Configuration;

namespace Apteka.Utils
{
    public class CAppSettings
    {
        public static void Set(string name, string val)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                bool found = false;
                var ks = settings.AllKeys;
                foreach (var item in ks)
                {
                    if (item.ToLower() == name.ToLower())
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    settings.Add(name, val);
                else
                    settings[name].Value = val;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CAppSettings.Set"
                };
                CLogJson.Write(li);
            }
        }

        public static string Get(string name)
        {
            try
            {
                return ConfigurationManager.AppSettings[name].ToStr();
            }
            catch (ConfigurationErrorsException ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CAppSettings.Get"
                };
                CLogJson.Write(li);

                return "";
            }
        }


        public static string GetConnectionString(string key)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        //Save connection string to App.config file
        public static void SaveConnectionString(string key, string value, string providername= "System.Data.SqlClient")
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = providername;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}

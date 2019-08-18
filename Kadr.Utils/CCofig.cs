using System;
using System.Configuration;
using System.Windows.Forms;

namespace Apteka.Utils
{
    public class CCofig
    {
        //  private static string MainSection = "BIOPasport";

        private static AppSettingsSection section = new AppSettingsSection();
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        public static string GetValue(string MainSection, string sn)
        {
            string res = "";
            try
            {
                if (config.Sections[MainSection] == null)
                {
                    section.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToApplication;
                    config.Sections.Add(MainSection, section);
                }
                else section = (AppSettingsSection)config.Sections[MainSection];

                res = section.Settings[sn].Value;
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CCofig.GetValue"
                };
                CLogJson.Write(li);
            }
            return res;
        }

        public static void SetValue(string MainSection, string sn, string val)
        {
            try
            {
                if (config.Sections[MainSection] == null)
                {
                    section.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToApplication;
                    config.Sections.Add(MainSection, section);
                }
                else section = (AppSettingsSection)config.Sections[MainSection];

                section.Settings.Remove(sn);
                section.Settings.Add(sn, val);
                config.Save();
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CCofig.SetValue"
                };
                CLogJson.Write(li);
            }
        }
    }
}
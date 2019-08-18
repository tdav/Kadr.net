using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Apteka.Utils
{
    public class CInet
    {
        public static string GetRemoteString(string from, string token = "")
        {
            using (var wc = new WebClient())
            {
                try
                {
                    if (token != "")
                        wc.Headers.Add("Authorization", $"bearer {token}");

                    return wc.DownloadString(from);
                }
                catch (Exception ee)
                {
                    var li = new LogItem
                    {
                        App = "Apteka.Utils",
                        Message = ee.Message,
                        Stacktrace = ee.GetStackTrace(5),
                        Url = $"{from}  {token}",
                        Method = "CInet.GetRemoteString"
                    };
                    CLogJson.Write(li);
                    return "";
                }
            }
        }

        public static bool DownloadFile(string from, string to)
        {
            using (var wc = new WebClient())
            {
                try
                {
                    if (File.Exists(to)) File.Delete(to);
                    wc.DownloadFile(from, to);
                    return true;
                }
                catch (Exception ee)
                {
                    var li = new LogItem
                    {
                        App = "Apteka.Utils",
                        Message = ee.Message,
                        Stacktrace = ee.GetStackTrace(5),
                        Url = $"{from} => {to}",
                        Method = "CInet.DownloadFile"
                    };
                    CLogJson.Write(li);
                    return false;
                }
            }
        }

        public static async Task<bool> DownloadFileAsync(string from, string to)
        {
            using (var wc = new WebClient())
            {
                try
                {
                    if (File.Exists(to)) File.Delete(to);
                    await wc.DownloadFileTaskAsync(from, to);
                    return true;
                }
                catch (Exception ee)
                {
                    var li = new LogItem
                    {
                        App = "Apteka.Utils",
                        Message = ee.Message,
                        Stacktrace = ee.GetStackTrace(5),
                        Url = $"{from} => {to}",
                        Method = "CInet.DownloadFileAsync"
                    };
                    CLogJson.Write(li);
                    return false;
                }
            }
        }
    }
}

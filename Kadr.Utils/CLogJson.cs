using System;
using System.IO;
using System.Security;
using System.Web;

namespace Apteka.Utils
{
    [SecuritySafeCritical]
    public class CLogJson
    {
        private static object obj = new object();
        
        private static string FileName
        {
            get
            {
                var directoryPath = "";
                if (Environment.UserInteractive)
                    directoryPath = AppDomain.CurrentDomain.BaseDirectory;
                else
                {
                    try
                    {
                        directoryPath = HttpRuntime.AppDomainAppPath;
                    }
                    catch (Exception)
                    {
                        directoryPath = System.AppDomain.CurrentDomain.BaseDirectory;
                    }
                }
                return directoryPath + "\\LogJson.txt";
            }
        }

        public static void Write(Exception e, string app = "", string param = "", string method = "")
        {
            var li = new LogItem
            {
                App = app,
                Stacktrace = e.GetStackTrace(5),
                Message = e.GetAllMessages(),
                Params = param,
                Method = method,
                Mestype = "e"
            };
            Write(li);
        }

        public static void Write(LogItem li)
        {
            lock (obj)
            {
                var sr = !File.Exists(FileName) ? File.CreateText(FileName) : File.AppendText(FileName);
                sr.Write(li.ToString() + ',');
                sr.Close();
            }
        }
    }

    public class LogItem
    {
        public DateTime CreateDate { get; set; }
        public string App { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
        public string Mestype { get; set; }
        public string Method { get; set; }
        public string Params { get; set; }
        public string Username { get; set; }
        public string Url { get; set; }
        public string Serveraddress { get; set; }
        public string Remoteaddress { get; set; }
        public string Useragent { get; set; }
        public string DivisionName { get; set; }

        public LogItem()
        {
            Serveraddress = $"IP - {CNet.LocalIpAddressAll()} MAC - {CNet.GetMAC()}";
            DivisionName = Environment.GetEnvironmentVariable("DivisionName");
            Username = Environment.GetEnvironmentVariable("AppUser");
            CreateDate = DateTime.Now;
            Mestype = "e";
        }

        public LogItem(Exception e)
        {
            CreateDate = DateTime.Now;
            Stacktrace = e.StackTrace;
            Message = e.GetAllMessages();
            Mestype = "e";
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
using System;
using System.IO;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;

namespace Apteka.Utils
{
    [SecuritySafeCritical]
    public class CLog : IDisposable
    {
        private static int MaxLine = 1;
        private static StringBuilder sb = new StringBuilder();
        private static object obj = new object();


        //private static void oTimer_TimerCallback(object state)
        //{
        //    timer.Change(Timeout.Infinite, Timeout.Infinite);
        //    WriteFileLog();
        //    timer.Change(new TimeSpan(0, 1, 0), new TimeSpan(0, 0, _timeOut));
        //}


        //private static void Start()
        //{
        //    IsRun = true;
        //    TimerCallback tmrCallBack = new TimerCallback(oTimer_TimerCallback);
        //    timer = new Timer(tmrCallBack);
        //    timer.Change(new TimeSpan(0, 1, 0), new TimeSpan(0, 0, _timeOut));
        //}

        private static string FileName
        {
            get
            {
                var directoryPath = Environment.UserInteractive ?
                    AppDomain.CurrentDomain.BaseDirectory :
                    HttpRuntime.AppDomainAppPath;

                return directoryPath + "\\Log.txt";
            }
        }

        private static void WriteFileLog()
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(obj, ref lockWasTaken);
                {
                    var sr = !File.Exists(FileName) ? File.CreateText(FileName) : File.AppendText(FileName);
                    sr.Write(sb.ToString());
                    sr.Close();

                    sb.Clear();
                }
            }
            finally
            {
                if (lockWasTaken) Monitor.Exit(obj);
            }
        }

        public static void Write(string source, Exception ee)
        {
            sb.AppendLine(ee != null
                ? $"{DateTime.Now:yyyy.MM.dd HH:mm:ss} {source} {ee.GetAllMessages()}{Environment.NewLine}"
                : $"{DateTime.Now:yyyy.MM.dd HH:mm:ss} {source}{Environment.NewLine}");
            if (sb.Length > MaxLine)
                WriteFileLog();

            //if (!IsRun)
            //    Start();
        }

        public static void Write(string source)
        {
            sb.AppendLine($"{DateTime.Now:yyyy.MM.dd HH:mm:ss} {source}");
            if (sb.Length > MaxLine)
                WriteFileLog();

            //if (!IsRun)
            //    Start();
        }

        public static void Write(string source, string t)
        {
            sb.AppendLine($"{DateTime.Now:yyyy.MM.dd HH:mm:ss} {source} {t}");
            if (sb.Length > MaxLine)
                WriteFileLog();

            //if (!IsRun)
            //    Start();
        } 
        public void Dispose()
        {
            WriteFileLog();
        }

    }

  
}
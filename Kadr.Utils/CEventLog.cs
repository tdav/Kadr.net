using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Apteka.Utils
{
    public class CEventLog
    {
        public static void Write(string msg)
        {
            EventLog elog;
            try
            {
                string eventSource = Path.GetFileName(Application.ExecutablePath);

                string logName = "Asbt";
                if (!EventLog.SourceExists(eventSource))
                {
                    EventLog.CreateEventSource(eventSource, logName);
                }

                elog = new EventLog
                {
                    Log = logName,
                    Source = eventSource,
                    EnableRaisingEvents = true
                };
                if (elog.Entries.Count > 500)
                {
                    elog.Clear();
                }

                elog.WriteEntry(msg, EventLogEntryType.Error);
                System.Threading.Thread.Sleep(100);
                elog.Close();
                elog = null;
            }
            catch (System.Exception) { }
        }
    }
}
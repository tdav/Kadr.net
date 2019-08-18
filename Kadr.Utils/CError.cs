using System;
using System.Text;

namespace Apteka.Utils
{
    public static class CError
    {
        public static string GetStackTrace(this Exception e, int depth)
        {
            var s = e.StackTrace;
            string[] lines = s.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder();
            for (int i = 0; i < depth; i++)
            {
                if (lines.Length > i)
                    sb.AppendLine(lines[i]);
            }

            return sb.ToString();
        }
        
        public static string GetAllMessages(this System.Exception ex)
        {
            return ex.InnerException == null
             ? ex.Message
             : ex.Message + Environment.NewLine + ex.InnerException.GetAllMessages();
        }

        public static string[] GetLastExeption(this Exception ex)
        {
            while (ex != null)
            {
                if (ex.InnerException == null)
                {
                    var e = ex.Message.Split('|');
                    if (e.Length < 3)
                        return null;
                    else
                        return e;
                }
                ex = ex.InnerException;
            }
            return null;
        }
    }
}
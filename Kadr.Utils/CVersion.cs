using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Apteka.Utils
{
    public class CVersion
    {
        private static IEnumerable<string> GetFilesToProcess(string path, IEnumerable<string> extensions)
        {
            FileInfo fi = new FileInfo(path);
            return Directory.GetFiles(fi.DirectoryName, "*.*")
                .Where(f => extensions.Contains(Path.GetExtension(f).ToLower()));
        }


        public static string GetAverageAppVersion(string path)
        {
            string Result = string.Empty;

            int n1 = 0;
            int n2 = 0;
            int n3 = 0;
            int n4 = 0;

            IEnumerable<string> flx = GetFilesToProcess(path, new[] { ".dll", ".exe" });
            int i = flx.Count();

            int vshost = 0;
            foreach (var item in flx)
            {
                if (item.ToLower().Contains("vshost"))
                {
                    vshost++;
                    continue;
                }

                FileVersionInfo fi = FileVersionInfo.GetVersionInfo(item);
                if (fi.FileVersion != null)
                {
                    string[] fileVersion = fi.FileVersion.Split("."[0]);
                    try
                    {
                        n1 += Convert.ToInt32(fileVersion[0]);
                        n2 += Convert.ToInt32(fileVersion[1]);
                        n3 += Convert.ToInt32(fileVersion[2]);
                        n4 += Convert.ToInt32(fileVersion[3]);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            i = i - vshost;

            return (n1 / i).ToStr() + "." + (n2 / i).ToStr() + "." + (n3 / i).ToStr() + "." + (n4 / i).ToStr();
        }

    }
}

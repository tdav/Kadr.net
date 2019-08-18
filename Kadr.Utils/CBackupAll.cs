using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Apteka.Utils
{
    public static class CBackupAll
    {
        private static string CurDir = AppDomain.CurrentDomain.BaseDirectory;

        public static IEnumerable<FileSystemInfo> AllFilesAndFolders(this DirectoryInfo dir)
        {
            foreach (var f in dir.GetFiles())
                yield return f;
            foreach (var d in dir.GetDirectories())
            {
                yield return d;
                foreach (var o in AllFilesAndFolders(d))
                    yield return o;
            }
        }

        public static void DeleteOldBackup()
        {
            try
            {
                string ArDir = CurDir[0] + @":\AptekaN3_Backup\";

                if (!Directory.Exists(ArDir))
                    return;
                var ls = new List<string>();
                var di = new DirectoryInfo(ArDir);
                foreach (var it in di.GetFiles("*.bak"))
                {
                    ls.Add(it.Name);
                }

                ls.Sort();
                if (ls.Count>7)
                {
                    for (int i = 0; i < ls.Count-7; i++)
                    {
                        Console.WriteLine(ls[i]);
                        File.Delete(ArDir + ls[i]);
                    }
                }

            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "CBackupAll",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CBackupAll.Run"
                };
                CLogJson.Write(li);
            }
        }

        public static string GetPath()
        {
            try
            {
                string FileName = DateTime.Now.ToString("ddMMyyyyhhmmssff");
                string ArDir = CurDir[0] + @":\AptekaN3_Backup\";

                if (!Directory.Exists(ArDir))
                    Directory.CreateDirectory(ArDir);

                return ArDir + FileName;
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "CBackupAll",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CBackupAll.Run"
                };
                CLogJson.Write(li);

                return "";
            }
        }

        public static string Run(List<string> ExclusionFile)
        {
            try
            {
                string FileName = DateTime.Now.ToString("ddMMyyyyhhmmssff") ;
                string ArDir = CurDir[0] + @":\AptekaN3_Backup\";

                if (!Directory.Exists(ArDir))
                    Directory.CreateDirectory(ArDir);

                var from = new DirectoryInfo(CurDir);
                using (FileStream zipToOpen = new FileStream(ArDir + FileName + ".zip", FileMode.Create))
                {
                    using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        foreach (var file in from.AllFilesAndFolders().Where(o => o is FileInfo).Cast<FileInfo>())
                        {

                            Console.WriteLine(file.Name + " " + ExclusionFile.IndexOf(file.Name));

                            if (ExclusionFile.IndexOf(file.Name.ToLower()) > -1)
                                continue;

                            var relPath = file.Name;
                            var readmeEntry = archive.CreateEntry(file.FullName);

                            Application.DoEvents();
                        }
                    }
                }

                return ArDir + FileName;
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "CBackupAll",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CBackupAll.Run"
                };
                CLogJson.Write(li);

                return "";
            }
        }
    }
}
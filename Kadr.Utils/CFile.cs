using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Apteka.Utils
{
    public class CFile
    {
        public static void CreatePath(String inPath)
        {
            try
            {
                string[] splPath = (inPath.TrimEnd('\\') + "\\").Split('\\');
                String dirs = splPath[0] + "\\" + splPath[1];
                for (int i = 2; i < splPath.Length; i++)
                {
                    if (!System.IO.Directory.Exists(dirs))
                        System.IO.Directory.CreateDirectory(dirs);
                    dirs += "\\" + splPath[i];
                }
            }
            catch (Exception err)
            {
                CEventLog.Write(string.Format("CFile.CreatePath({0}) -> {1}", inPath, err.GetAllMessages()));
            }
        }

        public static string GetFileVersion(string f, string ext)
        {
            if (!File.Exists(f)) return "";
            string rs = "";
            if (ext.ToLower() == ".dll" || ext.ToLower() == ".exe")
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(f);
                rs = myFileVersionInfo.FileVersion;
            }
            return rs;
        }

        public static string Ext(string s)
        {
            FileInfo fi = new FileInfo(s);
            return fi.Extension;
        }

        public static void SaveFile(string Content, string FileName)
        {
            FileStream Writer = null;
            try
            {
                if (File.Exists(FileName)) File.Delete(FileName);

                byte[] ContentBytes = Encoding.UTF8.GetBytes(Content);
                int Index = FileName.LastIndexOf('/');
                if (Index <= 0)
                {
                    Index = FileName.LastIndexOf('\\');
                }
                if (Index <= 0)
                {
                    throw new Exception("Directory must be specified for the file");
                }
                string Directory = FileName.Remove(Index) + "/";
                if (!System.IO.Directory.Exists(Directory))
                {
                    System.IO.Directory.CreateDirectory(Directory);
                }
                bool Opened = false;
                while (!Opened)
                {
                    try
                    {
                        Writer = File.Open(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                        Opened = true;
                    }
                    catch (System.IO.IOException e)
                    {
                        throw e;
                    }
                }
                Writer.Write(ContentBytes, 0, ContentBytes.Length);
                Writer.Close();
            }
            catch (Exception a)
            {
                throw a;
            }
            finally
            {
                if (Writer != null)
                {
                    Writer.Close();
                    Writer.Dispose();
                }
            }
        }

        public static string GetFileContents(string FileName)
        {
            try
            {
                return GetFileContents(FileName, 5000);
            }
            catch (Exception a)
            {
                throw a;
            }
        }

        public static string GetFileContents(string FileName, int TimeOut)
        {
            StreamReader Reader = null;
            int StartTime = System.Environment.TickCount;
            try
            {
                if (!File.Exists(FileName))
                    return "";
                bool Opened = false;
                while (!Opened)
                {
                    try
                    {
                        if (System.Environment.TickCount - StartTime >= TimeOut)
                            throw new System.IO.IOException("File opening timed out");
                        Reader = File.OpenText(FileName);
                        Opened = true;
                    }
                    catch (System.IO.IOException e)
                    {
                        throw e;
                    }
                }
                string Contents = Reader.ReadToEnd();
                Reader.Close();
                return Contents;
            }
            catch
            {
                return "";
            }
            finally
            {
                if (Reader != null)
                {
                    Reader.Close();
                    Reader.Dispose();
                }
            }
        }

        public static string GetFileName(string szPath)
        {
            Regex r = new Regex(@"\w+[.]\w+$+");
            return r.Match(szPath).Value;
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern Microsoft.Win32.SafeHandles.SafeFileHandle CreateFile(string lpFileName, System.UInt32 dwDesiredAccess, System.UInt32 dwShareMode, IntPtr pSecurityAttributes, System.UInt32 dwCreationDisposition, System.UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

        private static readonly uint GENERIC_WRITE = 0x40000000;
        private static readonly uint OPEN_EXISTING = 3;

        public static bool IsFileInUse(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            SafeHandle handleValue = null;

            try
            {
                handleValue = CreateFile(filePath, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                bool inUse = handleValue.IsInvalid;

                return inUse;
            }
            finally
            {
                if (handleValue != null)
                {
                    handleValue.Close();

                    handleValue.Dispose();

                    handleValue = null;
                }
            }
        }
    }
}
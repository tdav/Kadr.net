using System;
using System.Collections;
using System.IO;

namespace Apteka.Utils
{
    public class DbFileName
    {   
        public char Type { get; set; }
        public int Division { get; set; }
        public DateTime Date { get; set; }
        public string Crc32 { get; set; }
        public long Size { get; set; }

        public string ToFileName()
        {                   
            var d = DateTime.Now.ToString("yyyyMMddHHmmss");
            return Type +"x"+ Division.ToString() + "x" + d + "x" + Crc32 + "x" + Size.ToString() + ".dbc";
        }

        public string ParserFileName(string filename)
        {
            var s = filename.Split('x');

            char[] charstotrim = { '.', 'd', 'b', 'c' };
            var str = s[4].Trim(charstotrim);

            var inf = ("Тип: " + s[0] + ", Дивизион: " + s[1] + ", Дата: " + s[2] + ", Crc32: " + s[3] + ", Размер: " + str);

            return inf;
        }

        public static FileInfo[] GetImExFiles(string workingDirectory, string mask)
        {
            var diWorking = new DirectoryInfo(workingDirectory);
            var exts = mask.Split('|');
            var files = new ArrayList();
            foreach (var ext in exts)
            {
                files.AddRange(diWorking.GetFiles(ext));
            }

            return (FileInfo[])files.ToArray(typeof(FileInfo));
        }
    }
}

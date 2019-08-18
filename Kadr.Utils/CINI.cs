using System;
using System.Collections.Concurrent;
using System.Text;
using System.Text.RegularExpressions;

namespace Apteka.Utils
{
    public class CINI
    {
        public CINI()
        {
            LoadFile();
        }

        public CINI(string FileName)
        {
            this.FileName = FileName;
            LoadFile();
        }

        public void WriteToINI(string Section, string Key, string Value)
        {
            if (_FileContents.Keys.Contains(Section))
            {
                if (_FileContents[Section].Keys.Contains(Key))
                {
                    _FileContents[Section][Key] = Value;
                }
                else
                {
                    _FileContents[Section].TryAdd(Key, Value);
                }
            }
            else
            {
                ConcurrentDictionary<string, string> TempDictionary = new ConcurrentDictionary<string, string>();
                TempDictionary.TryAdd(Key, Value);
                _FileContents.TryAdd(Section, TempDictionary);
            }
            WriteFile();
        }

        public string ReadFromINI(string Section, string Key, string DefaultValue)
        {
            if (_FileContents.Keys.Contains(Section))
            {
                if (_FileContents[Section].Keys.Contains(Key))
                {
                    return _FileContents[Section][Key];
                }
            }
            return DefaultValue;
        }

        public string ToXML()
        {
            if (string.IsNullOrEmpty(this.FileName))
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<INI>\r\n</INI>";
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            Builder.Append("<INI>\r\n");
            foreach (string Header in _FileContents.Keys)
            {
                Builder.Append("<section name=\"" + Header + "\">\r\n");
                foreach (string Key in _FileContents[Header].Keys)
                {
                    Builder.Append("<key name=\"" + Key + "\">" + _FileContents[Header][Key] + "</key>\r\n");
                }
                Builder.Append("</section>\r\n");
            }
            Builder.Append("</INI>");
            return Builder.ToString();
        }

        private void WriteFile()
        {
            if (string.IsNullOrEmpty(this.FileName))
                return;
            StringBuilder Builder = new StringBuilder();
            foreach (string Header in _FileContents.Keys)
            {
                Builder.Append("[" + Header + "]\r\n");
                foreach (string Key in _FileContents[Header].Keys)
                {
                    Builder.Append(Key + "=" + _FileContents[Header][Key] + "\r\n");
                }
            }
            CFile.SaveFile(Builder.ToString(), FileName);
        }

        private void LoadFile()
        {
            _FileContents = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
            if (string.IsNullOrEmpty(this.FileName))
                return;

            string Contents = CFile.GetFileContents(FileName);
            Regex Section = new Regex("[" + Regex.Escape(" ") + "\t]*" + Regex.Escape("[") + ".*" + Regex.Escape("]\r\n"));
            string[] Sections = Section.Split(Contents);
            MatchCollection SectionHeaders = Section.Matches(Contents);
            int Counter = 1;
            foreach (Match SectionHeader in SectionHeaders)
            {
                string[] Splitter = { "\r\n" };
                string[] Splitter2 = { "=" };
                string[] Items = Sections[Counter].Split(Splitter, StringSplitOptions.RemoveEmptyEntries);
                var SectionValues = new ConcurrentDictionary<string, string>();
                foreach (string Item in Items)
                {
                    if (!String.IsNullOrWhiteSpace(Item))
                        SectionValues.TryAdd(
                            Item.Split(Splitter2, StringSplitOptions.None)[0].Trim(),
                            Item.Split(Splitter2, StringSplitOptions.None)[1].Trim());
                }
                _FileContents.TryAdd(SectionHeader.Value.Replace("[", "").Replace("]\r\n", "").Trim(), SectionValues);
                ++Counter;
            }
        }

        public ConcurrentDictionary<string, ConcurrentDictionary<string, string>> Load()
        {
            _FileContents = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
            if (string.IsNullOrEmpty(this.FileName))
                return null;

            string Contents = CFile.GetFileContents(FileName);
            Regex Section = new Regex("[" + Regex.Escape(" ") + "\t]*" + Regex.Escape("[") + ".*" + Regex.Escape("]\r\n"));
            string[] Sections = Section.Split(Contents);
            MatchCollection SectionHeaders = Section.Matches(Contents);
            int Counter = 1;
            foreach (Match SectionHeader in SectionHeaders)
            {
                string[] Splitter = { "\r\n" };
                string[] Splitter2 = { "=" };
                string[] Items = Sections[Counter].Split(Splitter, StringSplitOptions.RemoveEmptyEntries);
                var SectionValues = new ConcurrentDictionary<string, string>();
                foreach (string Item in Items)
                {
                    if (!String.IsNullOrWhiteSpace(Item))
                        SectionValues.TryAdd(
                        Item.Split(Splitter2, 2, StringSplitOptions.None)[0].Trim(),
                        Item.Split(Splitter2, 2, StringSplitOptions.None)[1].Trim());
                }
                _FileContents.TryAdd(SectionHeader.Value.Replace("[", "").Replace("]\r\n", "").Trim(), SectionValues);
                ++Counter;
            }
            return _FileContents;
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; LoadFile(); }
        }

        private ConcurrentDictionary<string, ConcurrentDictionary<string, string>> FileContents
        {
            get { return _FileContents; }
            set { _FileContents = value; }
        }

        private string _FileName = string.Empty;
        private ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _FileContents = null;
    }
}
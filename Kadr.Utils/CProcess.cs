using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Serialization.Formatters.Binary;

namespace Apteka.Utils
{
    [Serializable]
    public class RemoteProcess
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string executablePath;
        public string ExecutablePath
        {
            get { return executablePath; }
            set { executablePath = value; }
        }

        private string commandLine;
        public string CommandLine
        {
            get { return commandLine; }
            set { commandLine = value; }
        }


        private string memory;
        public string Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }

    [Serializable]
    public class RemoteProcessList : List<RemoteProcess>
    {
        public byte[] Run()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process");
            ManagementObjectCollection processList = searcher.Get();

            RemoteProcessList rpl = new RemoteProcessList();
            foreach (ManagementObject obj in processList)
            {
                string fd = "";
                string ef = "";
                string mem = "";
                try
                {
                    if (obj["ExecutablePath"] != null)
                    {
                        ef = obj["ExecutablePath"].ToString();
                        fd = FileVersionInfo.GetVersionInfo(ef).FileDescription;
                    }
                    else
                    {
                        fd = obj["Name"].ToString();
                    };

                    if (obj["ProcessId"] != null)
                        mem = GetMemProcess(Convert.ToInt32(obj["ProcessId"]));
                }
                catch (Exception)
                {
                }

                rpl.Add(new RemoteProcess()
                {
                    Name = (obj["Name"] != null ? obj["Name"].ToString() : ""),
                    ExecutablePath = ef,
                    CommandLine = (obj["CommandLine"] != null ? obj["CommandLine"].ToString() : ""),
                    Memory = mem,
                    Description = fd
                });


            }

            return rpl.Serialize();
        }
   
        private string GetMemProcess(int pid)
        {
            return Process.GetProcesses().ToList()
            .Where(p => p.Id == pid)
              .Select(g => ConvertBytesToKilobytes(g.PrivateMemorySize64)).FirstOrDefault().ToString();
        }

        private string ConvertBytesToKilobytes(long bytes)
        {
            return Math.Round((bytes / 1024f)).ToString();
        }

        public byte[] Serialize()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, this);
            ms.Position = 0;
            byte[] data = ms.GetBuffer();
            ms.Close();
            return data;
        }

        public static RemoteProcessList Deserialize(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            BinaryFormatter formatter = new BinaryFormatter();
            // formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
            // formatter.TypeFormat = FormatterTypeStyle.TypesWhenNeeded;
            RemoteProcessList list;
            list = (RemoteProcessList)formatter.Deserialize(ms);
            return list;
        }
    };
}

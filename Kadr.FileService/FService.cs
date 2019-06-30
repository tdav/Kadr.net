using Asbt.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Asbt.DataModels;

namespace Asbt.FileService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true,
                   InstanceContextMode = InstanceContextMode.PerSession,
                   ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class FileTransferService : IFileTransferService
    {
        private OperationContext context;
        private MessageProperties messageProperties;
        private RemoteEndpointMessageProperty endpointProperty;

        private string rootPath = @"c:\RFS_Root\";

        public FileTransferService()
        {
            context = OperationContext.Current;
            messageProperties = context.IncomingMessageProperties;
            endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
        }

        private string GetIPPort()
        {
            return endpointProperty.Address + ":" + endpointProperty.Port;
        }

        public RemoteFileInfo Get(DownloadRequest request)
        {
            string filePath = request.FileName;
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File not found", request.FileName);
            }

            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            RemoteFileInfo result = new RemoteFileInfo();
            result.FileName = request.FileName;
            result.Length = fileInfo.Length;
            result.FileByteStream = stream;
            return result;
        }

        public RemoteFileCrc32 Put(RemoteFileInfo request)
        {
            string filePath = rootPath+"\\"+ request.ToDir +"\\"+ request.FileName;
            if (File.Exists(filePath)) File.Delete(filePath);

            int chunkSize = 2048;
            byte[] buffer = new byte[chunkSize];

            using (FileStream writeStream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
            {
                do
                {
                    int bytesRead = request.FileByteStream.Read(buffer, 0, chunkSize);
                    if (bytesRead == 0) break;

                    writeStream.Write(buffer, 0, bytesRead);
                } while (true);

                writeStream.Close();
            }
            RemoteFileCrc32 c32 = new RemoteFileCrc32() { Crc32 = CCRC32.GetCRC32File(filePath) };
            return c32;
        }

        public void Del(DownloadRequest request)
        {
            string filePath = request.FileName;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            //if (lvLocal.SelectedItems.Count > 0)
            //    path = lvLocal.SelectedItems[0].Tag.ToString();

            //if (path != "root")
            //{
            //    if (File.Exists(path))
            //        File.Delete(path);
            //    else
            //        Directory.Delete(path);
            //}
        }

        public void ReName(string OldFileName, string NewFileName)
        {
            if (File.Exists(OldFileName))
            {
                string s = Path.GetDirectoryName(OldFileName);
                File.Move(OldFileName, s+"\\"+NewFileName);
            }
            else if (Directory.Exists(OldFileName))
            {
                Directory.Move(OldFileName, NewFileName);
            }
        }

        public StorageFileInfo[] List(string basePath)
        {
            List<StorageFileInfo> sfo = new List<StorageFileInfo>();
            List<TbDivClass> ls = new List<TbDivClass>();

            if (basePath == "")
            {
                return sfo.ToArray();
            }
            
            if (basePath == "root")
            {
                ls =  tbDivList.GetObl();
            }

            if (basePath.Length==2)
            {
                ls =  tbDivList.GetUcherejdeniya(basePath);    
            }


                                
            if (!Directory.Exists(rootPath + basePath)) Directory.CreateDirectory(rootPath + basePath);
            DirectoryInfo dirInfo = new DirectoryInfo(rootPath + basePath);

            var lv = (ls.Count>0? ls[0].Level:0);

            foreach (var i in ls)
            {
                sfo.Add(new StorageFileInfo()
                {
                    CRC32 = "", 
                    FileName = i.SpName, 
                    IsDirectory = true, 
                    Size = i.SpId, 
                    Level = lv,
                    Version = ""
                });
            }

            foreach (var i in dirInfo.GetFiles())
            {
                sfo.Add(new StorageFileInfo()
                {
                    CRC32 = "", 
                    FileName = i.FullName, 
                    IsDirectory = false, Size = i.Length,
                    Level = lv,
                    Version = ""
                });
            }

            return sfo.ToArray();
        }

        public string CRC32(string FileName)
        {
            return CCRC32.GetCRC32File(FileName);
        }

        public StorageFileInfo[] UpdateFilesList(string basePath)
        {
            if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

            if (string.IsNullOrEmpty(basePath)) return null;

            DirectoryInfo dirInfo = new DirectoryInfo(basePath);
            FileInfo[] files = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

            return (from f in files
                    select new StorageFileInfo()
                    {
                        Size = f.Length,
                        FileName = f.Name,
                        Version = CFile.GetFileVersion(f.FullName, f.Extension),
                        CRC32 = CCRC32.GetCRC32File(f.FullName)
                    }).ToArray();
        }

        public List<TbDivClass> GetDriveInfo()
        {
            return  tbDivList.GetObl();
        }

    }
}

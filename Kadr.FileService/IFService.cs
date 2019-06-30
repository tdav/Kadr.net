using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using Asbt.DataModels;

namespace Asbt.FileService
{
    [ServiceContract]
    public interface IFileTransferService
    {
        [OperationContract]
        RemoteFileInfo Get(DownloadRequest request);

        [OperationContract]
        RemoteFileCrc32 Put(RemoteFileInfo request);

        [OperationContract]
        void Del(DownloadRequest request);

        [OperationContract]
        void ReName(string OldFileName, string NewFileName);
        
        [OperationContract]
        StorageFileInfo[] List(string basePath);

        [OperationContract]
        string CRC32(string FileName);

        [OperationContract]
        StorageFileInfo[] UpdateFilesList(string basePath);

        [OperationContract]
        List<TbDivClass> GetDriveInfo();
    }

    [DataContract]
    public class StorageFileInfo
    {
        [DataMember]
        public bool IsDirectory { get; set; }

        [DataMember]
        public long Size { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string CRC32 { get; set; }

        [DataMember]
        public int Level { get; set; }
    }

    [MessageContract]
    public class RemoteFileCrc32
    {
        [MessageBodyMember]
        public string Crc32;
    }

    [MessageContract]
    public class DownloadRequest
    {
        [MessageBodyMember]
        public string FileName;
    }

    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public string ToDir;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageBodyMember(Order = 1)]
        public Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }

}

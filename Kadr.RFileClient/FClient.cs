using Apteka.Utils;
using Lcc.RFileClient;
using Lcc.RFileClient.srvFileClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileClient
{
    public class FClient
    {
        public class ProgressChangedEventArgs : EventArgs
        {
            public int PValue;
            public string SValue;
            public int msgType;
            public ProgressChangedEventArgs(int P, string S, int T)
            {
                this.PValue = P;
                this.SValue = S;
                this.msgType = T;
            }
        }

        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        private BackgroundWorker bws;
        private BackgroundWorker bwd;
        private Timer ti;

        private int Progress = 0;
        private string StatusText;
        private long opr = 0;
        private long bpr = 0;

        public FClient()
        {
            ti = new Timer();
            ti.Tick += new EventHandler(ti_Tick);
            ti.Interval = 1000;
        }


        void uploadStreamWithProgress_ProgressChanged(object sender, StreamWithProgress.ProgressChangedEventArgs e)
        {
            bpr = e.BytesRead;
            if (e.Length != 0)
                Progress = (int)(e.BytesRead * 100 / e.Length);
            StatusText = "SendFile";
        }

        private string RemoteFileServerIp()
        {
            string s;
            var cl = Environment.GetCommandLineArgs();
            if (cl.Length > 1 && cl[1] == "debug")
                s = "net.tcp://localhost:45000/FileService";
            else
                s = "net.tcp://172.250.1.206:45000/FileService";
            return s;
        }

        private FileTransferServiceClient InitClient()
        {
            NetTcpBinding bi = new NetTcpBinding(SecurityMode.None);
            bi.TransferMode = TransferMode.Streamed;
            bi.MaxBufferPoolSize = 2147483647;
            bi.MaxBufferSize = 2147483647;
            bi.MaxReceivedMessageSize = 2147483647;
            bi.ReaderQuotas.MaxDepth = 2147483647;
            bi.ReaderQuotas.MaxStringContentLength = 2147483647;
            bi.ReaderQuotas.MaxArrayLength = 2147483647;
            bi.ReaderQuotas.MaxBytesPerRead = 2147483647;
            bi.ReaderQuotas.MaxNameTableCharCount = 2147483647;
            bi.OpenTimeout = new TimeSpan(0, 10, 0);
            bi.CloseTimeout = new TimeSpan(0, 10, 0);
            bi.SendTimeout = new TimeSpan(0, 10, 0);
            bi.ReceiveTimeout = new TimeSpan(0, 10, 0);
            return new FileTransferServiceClient(bi, new EndpointAddress(RemoteFileServerIp()));
        }

        void ti_Tick(object sender, EventArgs e)
        {
            long l = (bpr - opr) / 1024;
            opr = bpr;

            if (OnProgressChanged != null)
                OnProgressChanged(this, new ProgressChangedEventArgs(Progress, StatusText + "  " + Progress.ToString() + "%  " + l.ToString() + " kb/s", 0));
        }

        public void ReNameFile(string OFileName, string NFileName)
        {
            FileTransferServiceClient client = InitClient();
            client.ReName(OFileName, NFileName);
            client.Close();
        }

        public void DelFile(string remFile)
        {
            FileTransferServiceClient client = InitClient();
            client.Del(remFile);
            client.Close();
        }

        public void SendFile(string remoteDir, string localFile)
        {
            bpr = opr = 0;
            ti.Start();

            Task task = new TaskFactory().StartNew(() =>
            {
                #region Send

                try
                {
                    FileInfo fileInfo = new FileInfo(localFile);

                    if (OnProgressChanged != null)
                        OnProgressChanged(this,
                            new ProgressChangedEventArgs(0,
                                fileInfo.Name + "\t" + Convert.ToString(fileInfo.Length/1024) + "kb", 100));

                    string c32;

                    using (FileStream stream = new FileStream(localFile, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamWithProgress uploadStreamWithProgress = new StreamWithProgress(stream))
                        {
                            uploadStreamWithProgress.ProgressChanged += uploadStreamWithProgress_ProgressChanged;
                            FileTransferServiceClient client = InitClient();

                            c32 = client.Put(fileInfo.Name, fileInfo.Length, remoteDir, uploadStreamWithProgress);
                            client.Close();
                            stream.Close();
                        }
                    }

                    if (CCRC32.GetCRC32File(localFile) == c32)
                    {
                        if (OnProgressChanged != null)
                            OnProgressChanged(this, new ProgressChangedEventArgs(0, "FileSened", 999));
                    }
                    else if (OnProgressChanged != null)
                        OnProgressChanged(this, new ProgressChangedEventArgs(0, "NotFileSened", -1));

                    if (OnProgressChanged != null)
                        OnProgressChanged(this, new ProgressChangedEventArgs(0, "Refresh", 33));

                }
                catch (Exception ex)
                {
                    CLog.Write(ex.ToString());
                    if (OnProgressChanged != null)
                        OnProgressChanged(this, new ProgressChangedEventArgs(0, ex.Message, -1));
                }

                #endregion
            });

            task.Wait();

            if (OnProgressChanged != null)
                OnProgressChanged(this, new ProgressChangedEventArgs(0, "", 0));
            ti.Stop();
        }

        public void DonwloadFile(string remoteFile, string localDir)
        {
            if (remoteFile == null) throw new ArgumentNullException("remoteFile");
            if (localDir == null) throw new ArgumentNullException("localDir");
            ti.Start();

            Task task = new TaskFactory().StartNew(() =>
            {
                #region Download
                try
                {
                    FileTransferServiceClient client = InitClient();

                    var ToDir = localDir;
                    Stream inputStream;
                    long length = client.Get(ref remoteFile, out localDir, out inputStream);

                    
                    if (OnProgressChanged != null)
                        OnProgressChanged(this, new ProgressChangedEventArgs(0, remoteFile + "\t" + Convert.ToString(length / 1024) + "kb", 100));

                    FileInfo fi = new FileInfo(remoteFile);
                    using (FileStream writeStream = new FileStream(ToDir + "\\" + fi.Name, FileMode.Create, FileAccess.Write))
                    {
                        int chunkSize = 2048;
                        byte[] buffer = new byte[chunkSize];

                        do
                        {
                            int bytesRead = inputStream.Read(buffer, 0, chunkSize);
                            if (bytesRead == 0) break;

                            writeStream.Write(buffer, 0, bytesRead);

                            bpr = writeStream.Position;
                            if (length != 0)
                                Progress = (int)(writeStream.Position * 100 / length);
                            StatusText = "DownloadFile";

                        } while (true);

                        writeStream.Close();
                    }

                    inputStream.Dispose();
                    client.Close();

                    if (OnProgressChanged != null)
                        OnProgressChanged(this, new ProgressChangedEventArgs(0, "FileDownloaded", 999));

                    if (OnProgressChanged != null)
                        OnProgressChanged(this, new ProgressChangedEventArgs(0, "Refresh", 22));
                }
                catch (Exception ex)
                {
                    CLog.Write(ex.ToString());
                    if (OnProgressChanged != null)
                        OnProgressChanged(this, new ProgressChangedEventArgs(0, ex.Message, -1));
                }
             #endregion
            });

            task.Wait();

            if (OnProgressChanged != null)
                OnProgressChanged(this, new ProgressChangedEventArgs(0, "", 0));
            ti.Stop();
        }

        public List<FileList> List(string remPath)
        {
            FileTransferServiceClient client = InitClient();
            var ls = client.List(remPath);

            List<FileList> res = new List<FileList>();
            foreach (var item in ls)
            {
                res.Add(new FileList()
                {
                    CRC32 = item.CRC32,
                    FileName = item.FileName,
                    IsDirectory = item.IsDirectory,
                    Level = item.Level,
                    Size = item.Size
                });
            }

            client.Close();
            return res;
        }
 
    }


    class StreamWithProgress : Stream
    {
        private readonly FileStream file;
        private readonly long length;

        public class ProgressChangedEventArgs : EventArgs
        {
            public long BytesRead;
            public long Length;

            public ProgressChangedEventArgs(long BytesRead, long Length)
            {
                this.BytesRead = BytesRead;
                this.Length = Length;
            }
        }

        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        private long bytesRead;

        public StreamWithProgress(FileStream file)
        {
            this.file = file;
            length = file.Length;
            bytesRead = 0;
            if (ProgressChanged != null) ProgressChanged(this, new ProgressChangedEventArgs(bytesRead, length));
        }

        public double GetProgress()
        {
            return ((double)bytesRead) / file.Length;
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush() { }

        public override long Length
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override long Position
        {
            get { return bytesRead; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int result = file.Read(buffer, offset, count);
            bytesRead += result;
            if (ProgressChanged != null) ProgressChanged(this, new ProgressChangedEventArgs(bytesRead, length));
            return result;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void SetLength(long value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}

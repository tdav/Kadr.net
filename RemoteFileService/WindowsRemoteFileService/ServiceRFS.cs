using Kadr.Utils;
using System;
using System.ServiceModel;
using System.ServiceProcess;

namespace WindowsRemoteFileService
{
    public partial class ServiceRFS : ServiceBase
    {
        public ServiceRFS()
        {
            InitializeComponent();
        }

        internal static ServiceHost serviceHost = null;

        protected override void OnStart(string[] args)
        {
            try
            {
                if (serviceHost != null)
                {
                    serviceHost.Close();
                }

                serviceHost = new ServiceHost(typeof(FileTransferService));
                serviceHost.Open();
            }
            catch (Exception err)
            {
                CLog.Write("FileTransferService.OnStart", err.GetAllMessages());
            }
        }

        protected override void OnStop()
        {
            try
            {
                if (serviceHost != null)
                {
                    serviceHost.Close();
                    serviceHost = null;
                }

            }
            catch (Exception err)
            {
                CLog.Write("FileTransferService.OnStop", err.GetAllMessages());
            }
        }

        public void Start()
        {
            OnStart(null);
        }
    }
}

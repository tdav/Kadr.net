using System;
using System.ServiceModel;
using System.ServiceProcess;
using Kadr.Utils;

namespace debugSrv
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                svcHost = new ServiceHost(typeof(Asbt.FileService.FileTransferService));
                svcHost.Open();

                foreach (var item in svcHost.ChannelDispatchers)
                {
                    Console.WriteLine(item.Listener.Uri);
                }
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
            }
            catch (Exception eX)
            {
                svcHost = null;
                Console.WriteLine(eX.GetAllMessages());
            }
            if (svcHost != null)
            {
                svcHost.Close();
                svcHost = null;
            }

            Console.ReadKey();
        }
    }
}

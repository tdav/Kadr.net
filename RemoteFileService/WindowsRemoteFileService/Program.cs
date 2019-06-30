using System.ServiceProcess;

namespace WindowsRemoteFileService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new ServiceRFS() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

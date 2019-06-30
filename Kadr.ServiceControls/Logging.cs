using System;
using System.Data;
using System.Configuration;
using NLog;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Asbt.Services
{
    public static class Logging
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static void Write(string procName, Exception err)
        {
            log.Error(procName, err);
        }

        public static string GetIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpoint.Address;
        }
    }
}
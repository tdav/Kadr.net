using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Apteka.Utils
{
    public class CNet
    {
       
        public static string GetGatewayAddresses()
        {
            const string ip = "";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
                    if (addresses.Count > 0)
                    {
                        foreach (GatewayIPAddressInformation ia in addresses)
                        {
                            if (ia.Address.AddressFamily == AddressFamily.InterNetwork)
                                return ia.Address.ToString();
                        }
                    }
                }
            }
            return ip;
        }


        public static bool PingM1(string ip)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions { DontFragment = true };

            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            PingReply reply = pingSender.Send(ip, 500, buffer, options);
            {
                try
                {
                    return (reply != null && reply.Status == IPStatus.Success);
                }
                catch
                {
                    return false;
                }
            }
        }


        public static string Ping(string name, string ip)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions { DontFragment = true };

            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            string res = "";
            int count = 0; float success = 0; float loop = 0;
            res = name + " ip : " + ip + Environment.NewLine;

            for (int i = 0; i < 6;)
            {
                PingReply reply = pingSender.Send(ip, 500, buffer, options);
                {
                    try
                    {
                        if (reply != null && reply.Status == IPStatus.Success)
                            res += "Ok" + "\t";
                        else
                            res += "Хато" + "\t";
                    }
                    catch
                    {
                        res += "Хато \t";
                    }

                    try
                    {
                        if (reply != null) res += "вакт: " + reply.RoundtripTime.ToString() + " ms" + "\t";
                    }
                    catch
                    {
                        res += "вакт: " + " - " + " ms" + "\t";
                    }

                    try
                    {
                        if (reply != null) res += "TTL: " + reply.Options.Ttl.ToString() + Environment.NewLine;
                    }
                    catch
                    {
                        res += Environment.NewLine;
                    }

                    if (reply != null)
                    {
                        count += Convert.ToInt32(reply.RoundtripTime);
                        if (reply.Status == IPStatus.Success)
                        { success += 1; }
                    }
                }
                i++; loop += 1;
            }

            res += "Уртача вакти : " + (count / loop).ToString() + " ms" + Environment.NewLine;
            float avgSuccess = ((success / loop) * 100);
            res += "Уртача. ок (%)  : " + avgSuccess.ToString() + "%" + Environment.NewLine;

            return "";
        }

        public static string LocalIpAddress()
        {
            string IP = string.Empty;
            string vpnIp = string.Empty;

            IPHostEntry host = Dns.GetHostEntry(System.Environment.MachineName);

            foreach (IPAddress ip in host.AddressList)
            {

                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    if (ip.ToStr().Contains("20.10.") || ip.ToStr().Contains("10.10."))
                        vpnIp = ip.ToStr();
                    else
                        IP = ip.ToStr();
                }
            }

            return vpnIp?.Length != 0 ? vpnIp : IP;
        }

        public static string LocalIpAddress(string mask)
        {
            string res;
            string IP = string.Empty;
            string vpnIp = string.Empty;

            IPHostEntry host = Dns.GetHostEntry(System.Environment.MachineName);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    if (ip.ToStr().Contains(mask))
                    {
                        res = ip.ToStr();
                        break;
                    }
                    else
                        IP = ip.ToStr();
                }
            }

            return vpnIp?.Length != 0 ? vpnIp : IP;
        }

        public static string LocalIpAddressAll(string ia)
        {
            string IP = string.Empty;
            try
            {
                string[] sa = ia.Split('.');
                ia = $"{sa[0]}.{sa[1]}.{sa[2]}.";
                IPHostEntry host = Dns.GetHostEntry(System.Environment.MachineName);
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        string ai = ip.ToStr();
                        if (ia == ai.Substring(0, ia.Length))
                            return ai;
                    }
                }
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CNet.LocalIpAddressAll"
                };
                CLogJson.Write(li);
            }
            return "";
        }

        public static string LocalIpAddressAll()
        {
            string IP = string.Empty;
            string allIp = "";
            try
            {
                IPHostEntry host = Dns.GetHostEntry(System.Environment.MachineName);

                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        allIp += ip.ToStr() + "  ";
                    }
                }
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CNet.LocalIpAddressAll"
                };
                CLogJson.Write(li);
            }
            return allIp;
        }

        public static string GetMAC()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress?.Length == 0)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                    return sMacAddress;
                }
            }
            return sMacAddress;
        }
        
        public static string LocalIpAddress_Texp()
        {
            string IP = string.Empty;
            string vpnIp = string.Empty;


            try
            {
                IPHostEntry host = Dns.GetHostEntry(System.Environment.MachineName);

                foreach (IPAddress ip in host.AddressList)
                {

                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        if (ip.ToStr().Contains("20.10."))
                        {
                            vpnIp = ip.ToStr();
                            return vpnIp;
                        }
                        else
                            vpnIp = ip.ToStr();
                    }
                }
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "CNet.LocalIpAddress_Texp"
                };
                CLogJson.Write(li);
            }
            return vpnIp;
        }

        public static bool CheckServerConnection(string uri)
        {
            try
            {
                Uri u = new Uri(uri);

                Ping pingSender = new Ping();
                PingOptions options = new PingOptions
                {
                    DontFragment = true
                };

                const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                const int timeout = 300;
                string res = "";
                int count = 0; float success = 0; float loop = 0;

                for (int i = 0; i < 6; i++)
                {
                    try
                    {
                        PingReply reply = pingSender.Send(u.Host, timeout, buffer, options);

                        if (reply.Status == IPStatus.Success)
                            return true;
                        else
                            res += "Хато" + "\t";

                        count += Convert.ToInt32(reply.RoundtripTime);
                        if (reply.Status == IPStatus.Success)
                        { success += 1; }
                        loop += 1;
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                return success > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (System.IO.Stream stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Net;

namespace PersonalOperatingSystem
{
    class IP
    {
        public static void Ip(ref string cmd)
        {
            if (cmd.CompareTo("ip") == 0)
            {
                var ips = (Dns.GetHostEntry(Dns.GetHostName()).AddressList);

                foreach (var ip in ips)
                {
                    Console.WriteLine(ip.ToString());
                }
            }
        }
    }
}

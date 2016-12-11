using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace NetHelper.Library
{
    public class NetHost : IConnectionAwaiter, INetHelp
    {
        public string Host { get; set; }
        public IPAddress SubnetMask { get; set; }

        /// <summary>
        /// The frequency <see cref="TimeSpan"/> in milliseconds with which to check if connections are available.
        /// Defaults to 250ms.
        /// </summary>
        public TimeSpan Frequency { get; set; } = TimeSpan.FromMilliseconds(250);

        /// <summary>
        /// The number of attempts to check if connection is available when waiting for connection.
        /// Defaults to infinity.
        /// </summary>
        public int? NumAttempts { get; set; } = null;

        public NetHost()
        {
            Host = "127.0.0.1";
            SubnetMask = IPAddress.Parse("127.0.0.1");
        }

        public NetHost(string host)
        {
            Host = host;
        }

        public NetHost(string host, IPAddress subnetMask)
        {
            Host = host;
            SubnetMask = subnetMask;
        }

        public NetHost(string host, string subnetMask)
        {
            Host = host;
            SubnetMask = IPAddress.Parse(subnetMask);
        }

        public void WaitForConnection()
        {
            if (NumAttempts == null)
            {
                while (true)
                {
                    if (IsConnectionAvailable())
                    {
                        break;
                    }
                }
            }

            int? numAttempts = NumAttempts;
            while (numAttempts > 0)
            {
                if (IsConnectionAvailable())
                {
                    break;
                }
                numAttempts--;
            }
        }

        public Task WaitForConnectionAsync()
        {
            return Task.Run(() => WaitForConnection());
        }

        public bool IsConnectionAvailable()
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(Host);
            return reply?.Status == IPStatus.Success;
        }
    }
}
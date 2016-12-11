using System;
using NetHelper.Library;

namespace NetHelper.Application
{
    using static Console;
    public static class Program
    {
        private static readonly NetHost netHost = new NetHost("192.168.0.16");
        public static void Main()
        {
            Connect();
            WriteLine("Press any button to quit.");
            Read();
        }

        private static void Connect()
        {
            WriteLine($"***Waiting for connection to {netHost.Host}***");
            netHost.WaitForConnection();
            WriteLine("***Connected***");
        }
    }
}
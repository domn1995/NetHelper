using System;
using System.Threading;
using NetHelper.Library;

namespace NetHelper.Application
{
    using static Console;
    public static class Program
    {
        private static readonly NetHost netHost = new NetHost("192.168.0.16");
        private static bool done = false;
        public static void Main()
        {
            Connect();
            while (!done)
            {
                Write("\rConnecting.  ");
                Thread.Sleep(500);
                Write("\rConnecting..");
                Thread.Sleep(500);
                Write("\rConnecting...");
                Thread.Sleep(500);
            }
            WriteLine("Press any button to quit.");
            Read();
        }

        private async static void Connect()
        {
            WriteLine($"***Waiting for connection to {netHost.Host}***");
            await netHost.WaitForConnectionAsync();
            done = true;
            WriteLine("\n***Connection established.***");
        }
    }
}
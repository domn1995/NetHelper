using System;
using System.Runtime.InteropServices;
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
            ConnectAsync();
            PrintStatus();
            WriteLine("Press any button to quit.");
            Read();
        }

        private async static void ConnectAsync()
        {
            WriteLine($"***Waiting for connection to {netHost.Host}***");
            await netHost.WaitForConnectionAsync();
            done = true;
            WriteLine("\n***Connection established.***");
        }

        private static void PrintStatus()
        {
            while (!done)
            {
                Write("\rConnecting");
                for (int i = 0; i < 4; i++)
                {
                    if (done)
                    {
                        return;
                    }

                    Write(".");
                    Thread.Sleep(250);
                    if (i == 3)
                    {
                        Write("\rConnecting    ");
                    }
                }
            }
        }
    }
}
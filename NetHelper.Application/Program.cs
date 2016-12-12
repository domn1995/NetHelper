using System;
using System.Threading;
using NetHelper.Library;

namespace NetHelper.Application
{
    public static class Program
    {
        private static readonly IConnectionAwaiter netHost = new NetHost("192.168.0.16");
        private static bool done = false;
        public static void Main()
        {
            Console.WriteLine($"***Waiting for connection to {((NetHost)netHost).Host}***");
            ConnectAsync();
            PrintStatus();
            Console.WriteLine("Press any button to quit.");
            Console.Read();
        }

        private async static void ConnectAsync()
        {
            await netHost.WaitForConnectionAsync();
            done = true;
            Console.WriteLine("\n***Connection established.***");
        }

        private static void PrintStatus()
        {
            while (!done)
            {
                Console.Write("\rConnecting");
                for (int i = 0; i < 4; i++)
                {
                    if (done)
                    {
                        return;
                    }

                    Console.Write(".");
                    Thread.Sleep(250);
                    if (i == 3)
                    {
                        Console.Write("\rConnecting    ");
                    }
                }
            }
        }
    }
}
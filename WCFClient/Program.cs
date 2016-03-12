using System;
using System.Threading;
using WCFClient.MathServiceClient;

namespace WCFClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** The Async Math Client *****\n");
            using (var proxy = new BasicMathClient())
            {
                proxy.Open();

                // Add numbers in an async manner, using a lambda expression.     
                var result = proxy.BeginAdd(2, 3, ar => { Console.WriteLine("2 + 3 = {0}", proxy.EndAdd(ar)); }, null);
                while (!result.IsCompleted)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("Client working...");
                }
            }
            Console.ReadLine();
        }
    }
}
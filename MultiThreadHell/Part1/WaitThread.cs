using System;
using System.Net;
using System.Threading;

namespace MultiThreadHell
{
    public class WaitThread
    {
        public static void Main(string[] args)
        {
            var thread = new Thread(() =>
            {
                Console.WriteLine("Do Something");
                Thread.Sleep(2000);
                Console.WriteLine("Done.");
            });
            thread.Start();
            thread.Join(); // 이 아래로 블로킹.

            Console.WriteLine("All done.");
        }
    }
}
using System;
using System.Threading;

namespace MultiThreadHell
{
    public class ThreadNew
    {
        public static void Main(string[] args)
        {
            var mainThead = Thread.CurrentThread;
            mainThead.Name = "Main Thread";

            var thread1 = new Thread(CountDown);
            var thread2 = new Thread(CountUp);

            thread1.Start();
            thread2.Start();

            Console.WriteLine(mainThead.Name + "is Complete.");
            Console.ReadKey();
        }

        private static void CountDown()
        {
            for (var i = 10; i >= 0; i--)
            {
                Console.WriteLine("Timer #1 : " + i + " seconds");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Timer #1 is complete.");
        }

        private static void CountUp()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Timer #2 : " + i + " seconds");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Timer #2 is complete.");
        }
    }
}
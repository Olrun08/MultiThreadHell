using System;
using System.Threading;

namespace MultiThreadHell
{
    public class ThreadLambda
    {
        public static void Main(string[] args)
        {
            var mainThread = Thread.CurrentThread;
            mainThread.Name = "Main Thread";

            var thread1 = new Thread(() => CountDown("Timer #69 "));
            var thread2 = new Thread(() => CountUp("Timer #74 "));
            thread1.Start();
            thread2.Start();

            Console.WriteLine(mainThread.Name + " is Complete!");
            Console.ReadKey();
        }

        private static void CountDown(string name)
        {
            for (var i = 10; i >= 0; i--)
            {
                Console.WriteLine(name + i + " seconds");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Timer #1 is complete.");
        }

        private static void CountUp(string name)
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(name + i + " seconds");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Timer #2 is complete.");
        }
    }
}
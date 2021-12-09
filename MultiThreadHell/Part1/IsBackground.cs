using System;
using System.Linq;
using System.Threading;

namespace MultiThreadHell
{
    public class IsBackground
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            Console.WriteLine("Hello World!");

            Case3();
        }

        private static void Case1()
        {
            /*
             * foreground thread이므로 이 스레드의 작업이 끝나기 전까지 어플리케이션은 죽지 않는다.
             */
            new Thread(() => { Thread.Sleep(10000); })
                .Start();
        }

        private static void Case2()
        {
            /*
             * 황족 foreground와 달리 background는 다른 모든 foreground thread가 close되면 같이 죽는다.
             * 물론 작업이 끝날 때 까지 기다려주지도 않음.
             */
            new Thread(() => { Thread.Sleep(10000); })
                {IsBackground = true}.Start();
        }

        private static void Case3()
        {
            Enumerable.Range(0, 10).ToList().ForEach(f =>
            {
                // n개의 스레드가 각자의 스레드에서 일하므로 Case1처럼 10초간 기다릴 필요 없다.
                // 스레드가 반드시 시작한 순서대로 끝날 것이라는 보장은 없음.
                new Thread(() =>
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}" + " ended");
                    })
                    .Start();
            });
        }
    }
}
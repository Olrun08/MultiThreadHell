using System;
using System.Threading;

namespace MultiThreadHell
{
    public class ThreadIssues
    {
        private static event Action EventFinished = () => { };

        public static void Main(string[] args)
        {
            Log("Hello World!");

            #region Blocking Wait

            Log("Before Blocking thread");
            var blockingThread = new Thread(() =>
            {
                Thread.Sleep(500);
                Log("Inside Blocking thread");
            });
            blockingThread.Start();
            blockingThread.Join();
            Log("After First thread");

            #endregion

            #region Polling Wait

            Log("Before Polling thread");
            var isComplete = false;
            var pollingThread = new Thread(() =>
            {
                Log("Inside Polling thread");
                Thread.Sleep(500);
                isComplete = true;
            });
            pollingThread.Start();

            while (!isComplete)
            {
                Log("Polling...");
                Thread.Sleep(10);
            }

            Log("After Polling thread");

            #endregion

            #region Event-based Wait

            Log("Before Event-based thread");
            var eventThread = new Thread(() =>
            {
                Log("Inside Event-based thread");
                Thread.Sleep(500);
                EventFinished();
            });

            // Hook into callback event
            EventFinished += () =>
            {
                // Called back from thread
                Log("Event-based thread callback on complete");
            };
            eventThread.Start();

            Log("After Event-based thread");
            Thread.Sleep(1000);
            Log("-------------------------------------------------");

            #endregion

            #region Event-based Wait Method

            Log("Before Event-based thread method");

            EventThreadCallbackMethod(() =>
            {
                // Called back from thread
                Log("Event-based thread method callback on complete");
            });
            Log("After Event-based thread method");

            #endregion

            Console.ReadLine();
        }

        private static void Log(string message)
        {
            Console.WriteLine($"{message} [{Thread.CurrentThread.ManagedThreadId}]");
        }

        private static void EventThreadCallbackMethod(Action completed)
        {
            new Thread(() =>
            {
                Log("Inside event thread method");
                Thread.Sleep(500);

                completed();
            }).Start();
        }
    }
}
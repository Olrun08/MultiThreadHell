using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadHell
{
    public class TaskMaster2
    {
        public static void Main(string[] args)
        {
            Log("Hello, TaskMaster2!");

            #region Consuming via Task

            Console.WriteLine("----------------------------------------------------------");
            var workResultViaTask = default(string);
            Task.Run(async () =>
            {
                // Get result
                workResultViaTask = await DoWorkAndGetResultAsync("Consume Task");
                Log(workResultViaTask);
            }).Wait();
            Console.WriteLine("----------------------------------------------------------");

            #endregion

            #region Thread during Async Calss

            DoWorkAsync("ContinueWith").ContinueWith(t =>
            {
                // After
                Log("ContinueWith Complete");
            }).Wait();
            Console.WriteLine("----------------------------------------------------------");

            #endregion

            #region Exception

            Log("Before ThrowBefore");
            var crashedTask = ThrowBeforeAwait(true);

            var isFaulted = crashedTask.IsFaulted;
            Log(crashedTask.Exception.Message);

            Log("After ThrowBefore");

            #endregion

            Console.ReadKey();
        }

        #region Helper

        private static void Log(string message)
        {
            Console.WriteLine($"{message} [{Thread.CurrentThread.ManagedThreadId}]");
        }

        #endregion

        #region Consuming Async Methods

        private static async Task DoWorkAsync(string content)
        {
            Log($"Doing work for {content}");

            await Task.Run(async () =>
            {
                Log($"Doing work on inner thread for {content}");

                // Delay
                await Task.Delay(500);

                Log($"Done work on inner thread for {content}");
            });
            Log($"Done work for {content}");
        }


        private static async Task<string> DoWorkAndGetResultAsync(string content)
        {
            Log($"Doing work for {content}");

            await Task.Run(async () =>
            {
                Log($"Doing work on inner thread for {content}");

                // Delay
                await Task.Delay(500);

                Log($"Done work on inner thread for {content}");
            });
            Log($"Done work for {content}");
            return content;
        }

        private static async Task ThrowBeforeAwait(bool before)
        {
            if (before)
                throw new ArgumentException("Shit");

            await Task.Delay(1);
            throw new ArgumentException("Shit");
        }
        
        private static async void ThrowAwaitVoid(bool before)
        {
            if (before)
                throw new ArgumentException("Shit");

            await Task.Delay(1);
            throw new ArgumentException("Shit");
        }


        #endregion
    }
}
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadHell
{
    public class TaskMaster
    {
        public static void Main(string[] args)
        {
            Log("Hello, TaskMaster!");

            #region Sync vs Async Method

            Log("Before sync thread");

            // Website to fetch
            var url = "https://www.google.co.kr";

            // Download the string : synchronously
            WebDownloadString(url);
            Log("After sync thread");
            Console.WriteLine("-------------------------------------------------------");

            Log("Before async thread");
            // Download the string : asynchronously
            var downloadTask = WebDownloadStringAsync(url);

            Log("After async thread");
            // Wait for task to complete
            downloadTask.Wait();
            Console.WriteLine("-------------------------------------------------------");

            #endregion

            Console.ReadLine();
        }

        #region Helper Methods

        /// <summary>
        /// Log current thread ID.
        /// </summary>
        /// <param name="message"></param>
        private static void Log(string message)
        {
            Console.WriteLine($"{message} [{Thread.CurrentThread.ManagedThreadId}]");
        }

        #endregion

        #region Task Example Methods

        /// <summary>
        /// Downloads a string from a website URL synchronously
        /// </summary>
        /// <param name="url">The URL to download</param>
        private static void WebDownloadString(string url)
        {
            // Synchronous pattern
            var webClient = new WebClient();
            var result = webClient.DownloadString(url);

            // Log
            Log($"Downloaded {url}. {result.Substring(0, 10)}");
        }

        /// <summary>
        /// Downloads a string from a website URL asynchronously
        /// </summary>
        /// <param name="url">The URL to download</param>
        private static async Task WebDownloadStringAsync(string url)
        {
            // Asynchronous pattern
            var webClient = new WebClient();
            var result = await webClient.DownloadStringTaskAsync(new Uri(url));

            // Log
            Log($"Downloaded {url}. {result.Substring(0, 10)}");
        }

        #endregion
    }
}
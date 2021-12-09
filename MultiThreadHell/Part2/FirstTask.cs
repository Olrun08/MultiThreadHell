using System;
using System.Threading.Tasks;

namespace MultiThreadHell
{
    public class FirstTask
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            Console.WriteLine("Hello World!");

            Task.Run(async () =>
            {
                // background thread로 간주되어 멈추지 않음.
                await Task.Delay(10000);
                Console.WriteLine("Do Something.");
                Console.WriteLine("Done.");
            });
            Console.WriteLine("All Done");
            // Console.ReadLine();
        }
    }
}
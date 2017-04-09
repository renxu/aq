using System;
using System.Threading.Tasks; // Namespace for Task libary

namespace Asynchronous
{
    public class TaskBasedExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Main thread calling async method...");
            Task workTask = DoSomeWorkAsync();
            Console.WriteLine("Main thread continued while async work is in progress.");
            Console.WriteLine("Main thread paused waiting or async work.");
            workTask.Wait();
            Console.WriteLine("Main thread resumed after async work is done.");
            Console.ReadKey();
        }

        public static async Task DoSomeWorkAsync()
        {
            Console.WriteLine("Work started in async method.");
            await Task.Delay(3000);
            Console.WriteLine("Work end in async method.");
        }
    }
}

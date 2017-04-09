using System;
using System.Collections.Generic;
using System.Threading;

namespace Threading
{
    public class SemaphoreBasic
    {
        private static Semaphore resources = new Semaphore(3, 3);

        public static void Main(string[] args)
        {
            // Create 10 threads to use 3 resources.
            List<Thread> threads = new List<Thread>();
            for (int i = 1; i <= 10; i++)
            {
                Thread thread = new Thread(SemaphoreBasic.WorkerThreadMethod);
                thread.Start(i);
                threads.Add(thread);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("Enter any key to exist.");
            Console.ReadKey();
        }

        public static void WorkerThreadMethod(object index)
        {
            Console.WriteLine(string.Format("Worker #{0} is started. Trying to acquire resource...", index));

            // Block the current thread until acquiring one resource.
            resources.WaitOne();
            Console.WriteLine(string.Format("Worker #{0} acquired a resource.", index));

            Thread.Sleep(3000);

            // Release the locked resource.
            Console.WriteLine(string.Format("Worker #{0} released a resource.", index));
            resources.Release();
        }
    }
}

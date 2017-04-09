using System;
using System.Threading;

namespace Threading
{
    /// <summary>
    /// The ThreadPool class provides your application with a pool of worker threads that are managed by the system, 
    /// allowing you to concentrate on application tasks rather than thread management. If you have short tasks that 
    /// require background processing, the managed thread pool is an easy way to take advantage of multiple threads.
    /// </summary>
    public class ThreadPoolBasic
    {
        public static void Main(string[] args)
        {
            // Add ten short tasks to the thread pool.
            for (int i = 1; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadPoolBasic.WorkerThreadMethod, i);
            }

            Console.ReadKey();
        }

        public static void WorkerThreadMethod(object state)
        {
            Console.WriteLine(string.Format("Thread #{0} is done with its work.", (int)state));
        }
    }
}

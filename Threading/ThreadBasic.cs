using System;
using System.Threading; // Threading namepsace

namespace Threading
{
    public class ThreadBasic
    {
        public void WorkerThreadMethod()
        {
            int i = 0;
            // Sleep 1 second to simulate that the worker has been working for 1 second.
            while (true)
            {
                Thread.Sleep(1000);
                
                i++;
                Console.WriteLine(string.Format("The worker has been working for {0} seconds.", i));

                if (i % 10 == 0)
                {
                    // Yield the worker thread, give up the rest of the threads' current time slice.
                    // The operating system schedules the calling thread for another time slice, 
                    // according to its priority and the status of other threads that are available to run.
                    Thread.Yield();
                    Console.WriteLine("The worker called Thread.Yield().");
                }
            }
        }

        static void Main(string[] args)
        {
            // Start a new thread to do something in the background
            ThreadBasic threadBasic = new ThreadBasic();
            Thread workerThread = new Thread(threadBasic.WorkerThreadMethod);
            workerThread.Start();
            Console.WriteLine("Main thread called workerThread.Start().");

            // Main thread sleep for 5 seconds
            Console.WriteLine("Main thread is going to sleep for 5 seconds while worker thread is doing its work.");
            Thread.Sleep(5000);

            // Note, Thread.Suspend and Thread.Resume has been deprecated.  
            // Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, 
            // to synchronize Threads or protect resources. 
            workerThread.Suspend();
            Console.WriteLine("Main thread called workerThread.Suspend().");

            Console.WriteLine("Main thread is going to sleep for another 5 seconds while worker thread is suspended.");
            Thread.Sleep(5000);

            workerThread.Resume();
            Console.WriteLine("Main thread called workerThread.Resume().");

            Console.WriteLine("Main thread is going to sleep for 5 seconds while worker thread is doing its work.");
            Thread.Sleep(5000);

            // Block the main thread until the worker thread finishes or the specified time lapses.
            Console.WriteLine("Main thread is going to call workerThread.Join(5000).");
            workerThread.Join(5000);

            Console.WriteLine("Main thread resumed execution after workerThread.Join(5000). It is going to sleep for another 5 seconds while worker thread is still doing its work..");
            Thread.Sleep(5000);

            // Call Abort to begin terminating the worker thread
            workerThread.Abort();
            Console.WriteLine("Main thread called workerThread.Abort().");

            Console.WriteLine("Enter any key to exist.");
            Console.ReadKey();
        }
    }
}

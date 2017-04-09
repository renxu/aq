using System;
using System.Collections.Generic;
using System.Threading;

namespace Threading
{
    /// <summary>
    /// Mutex can protect a resource across multiple thread and process. 
    /// One use for a cross-process Mutex is to ensure that only one instance of a program can run at a time. 
    /// To test this program, open Threading.exe twice.
    /// </summary>
    public class MutexBasic
    {
        // Mutex name is required to identify the mutx across processes.
        static Mutex mutex = new Mutex(false, "MutexBasic");

        public static void Main(string[] args)
        {
            if (!mutex.WaitOne(1000, false))
            {
                Console.WriteLine("The app is already runnning. Hit any key to exit.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("The app is now running. Hit any key to exit.");
            Console.ReadKey();
            mutex.ReleaseMutex();
        }
    }
}

using System;
using System.Threading;

namespace Asynchronous
{
    public class CallbackExample
    {
        /// <summary>
        /// Starts some work in another thread with a callback method supplied. 
        /// Main thread should not be blocked. The callback method will be triggered when the work is done.
        /// This asynchronous pattern is not recommended.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CallbackExample callbackExample = new CallbackExample();

            Console.WriteLine("Starting a new thread for echo worker.");
            Thread workerThread = new Thread(callbackExample.RunEchoWorker);
            workerThread.Start();

            Console.WriteLine("Main thread continued to execute without waiting.");
            Console.ReadKey();
        }

        private void RunEchoWorker()
        {
            Console.WriteLine("Calling echo worker with input 123.");
            BackgroundEchoWorker worker = new BackgroundEchoWorker();
            worker.BeginWork(123, this.WorkCompleted);
        }

        private void WorkCompleted(int output)
        {
            Console.WriteLine("Callback method WorkCompleted is triggered.");
            Console.WriteLine(string.Format("Echo worker returned {0}.", output));
        }
    }

    /// <summary>
    /// The echo worker simply returns the input after sleeping 5 seconds.
    /// </summary>
    public class BackgroundEchoWorker
    {
        public delegate void WorkCompleted(int output);

        public void BeginWork(int input, WorkCompleted workCompleted)
        {
            int output = input;
            Thread.Sleep(5000);
            workCompleted(output);
        }
    }
}

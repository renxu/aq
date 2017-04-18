using System;
using System.Threading;

namespace Threading
{
    public class HitCounterProgram
    {
        HitCounter counter = new HitCounter();

        public static void Main(string[] args)
        {
            HitCounterProgram program = new HitCounterProgram();

            // Create three threads for registering hits
            for (int i = 0; i < 3; i++)
            {
                Thread hitThread = new Thread(program.RegisterOneHitPerSecond);
                hitThread.Start();
            }

            // Create another thread to display hits
            Thread getThread = new Thread(program.DisplayHits);
            getThread.Start();

            Console.ReadKey();
        }

        /// <summary>
        /// Register 1 hit per seconds.
        /// </summary>
        public void RegisterOneHitPerSecond()
        {
            while (true)
            {
                this.counter.Hit();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Display hits once per seconds.
        /// </summary>
        public void DisplayHits()
        {
            while (true)
            {
                Console.WriteLine("Hits: " + this.counter.GetHits());
                Thread.Sleep(1000);
            }
        }

        public class HitCounter
        {
            private const int HistoryWindowInSeconds = 60 * 5; // Change the history window to 10 seconds to see the results easily
            private const int BucketNumber = HistoryWindowInSeconds * 2; // Double the needed buckets to provide buffer
            private int[] counters = null;

            /** Initialize your data structure here. */
            public HitCounter()
            {
                counters = new int[BucketNumber];

                // A separate thread to clean older history to avoid locking
                Thread cleanThread = new Thread(this.CleanHistory);
                cleanThread.Start();
            }

            /// <summary>
            /// Register a hit based on the current date time.
            /// </summary>
            public void Hit()
            {
                this.Hit(this.GetCurrentTimeInSeconds());
            }

            private void Hit(long timestampInSeconds)
            {
                int bucketIndex = (int)(timestampInSeconds % BucketNumber);
                Interlocked.Increment(ref counters[bucketIndex]);
            }

            /// <summary>
            /// Returns the number of hits in last 5 minutes.
            /// </summary>
            public int GetHits()
            {
                return GetHits(this.GetCurrentTimeInSeconds());
            }

            private int GetHits(long timestampInSeconds)
            {
                int total = 0;
                int bucketIndex = (int)(timestampInSeconds % BucketNumber);
                for (int i = bucketIndex; i > bucketIndex - HistoryWindowInSeconds; i--)
                {
                    int currentBucketIndex = i;
                    if (currentBucketIndex < 0)
                    {
                        currentBucketIndex = BucketNumber + currentBucketIndex;
                    }

                    total += counters[currentBucketIndex];
                }

                return total;
            }

            private long GetCurrentTimeInSeconds()
            {
                return DateTimeOffset.UtcNow.Ticks / 10000000;
            }

            private void CleanHistory()
            {
                while (true)
                {
                    int nowBucketIndex = (int)(this.GetCurrentTimeInSeconds() % BucketNumber);
                    int bufferInSeconds = HistoryWindowInSeconds / 10;
                    for (int i = nowBucketIndex + bufferInSeconds; i <= nowBucketIndex + HistoryWindowInSeconds - bufferInSeconds; i++)
                    {
                        counters[i % BucketNumber] = 0;
                    }

                    Thread.Sleep(bufferInSeconds * 1000);
                }
            }
        }

        // end of soltion
    }
}

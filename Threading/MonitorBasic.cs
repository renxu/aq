using System;
using System.Threading;

namespace Threading
{
    /// <summary>
    /// A producer adds a message to a single-message board.
    /// A consumer removes a messsage from a single-message board.
    /// </summary>
    public class MonitorBasic
    {
        public static void Main(string[] args)
        {
            // Create a single-message board, a message producer and a message consumer

            var board = new SingleMessageBoard();
            var producer = new MessageProducer(board, 10);
            var consumer = new MessageConsumer(board, 10);

            var producerThread = new Thread(producer.ProduceMessages);
            var consumerThread = new Thread(consumer.ConsumeMessages);
            Console.WriteLine("Producer will write 10 messages. Consumer will read 10 messages.");

            producerThread.Start();
            consumerThread.Start();
            producerThread.Join();
            consumerThread.Join();

            Console.WriteLine("Enter any key to exist.");
            Console.ReadKey();
        }
    }

    public class SingleMessageBoard
    {
        private object boardLock = new object();
        private string message = null;

        public void WriteMessage(string content)
        {
            // lock keyword is equivalent of Monitor.Enter and Monitor.Exit.
            // Monitor.Enter(boxlock);
            lock(this.boardLock)
            {
                while (this.message != null)
                {
                    // The previous message has not been read yet.
                    // Wait for it to be read.
                    // Releases the lock on boardLock and blocks the current thread until it reacquires the lock.
                    Monitor.Wait(this.boardLock);
                }

                this.message = content;
                Console.WriteLine(string.Format("A message is written to the board: \"{0}\"", this.message));

                // Notifies a thread in the waiting queue of a change in the boardLock's state.
                Monitor.Pulse(this.boardLock);
            }
            // Monitor.Exit(boxlock);
        }

        public string ReadMessage()
        {
            lock (this.boardLock)
            {
                while (this.message == null)
                {
                    // No new message has not been written yet.
                    // Wait for it to be written.
                    // Releases the lock on boardLock and blocks the current thread until it reacquires the lock.
                    Monitor.Wait(this.boardLock);
                }

                string content = this.message;
                this.message = null;
                Console.WriteLine(string.Format("A message is read from the board: \"{0}\"", content));

                // Notifies a thread in the waiting queue of a change in the boardLock's state.
                Monitor.Pulse(this.boardLock);
                return content;
            }
        }
    }

    public class MessageProducer
    {
        private SingleMessageBoard board = null;
        private int quantity = 0;
        
        public MessageProducer(SingleMessageBoard board, int quantity)
        {
            this.board = board;
            this.quantity = quantity;
        }

        public void ProduceMessages()
        {
            for (int i = 1; i <= this.quantity; i++)
            {
                board.WriteMessage(string.Format("test message #{0}", i));
            }
        }
    }

    public class MessageConsumer
    {
        private SingleMessageBoard board = null;
        private int quantity = 0;

        public MessageConsumer(SingleMessageBoard board, int quantity)
        {
            this.board = board;
            this.quantity = quantity;
        }

        public void ConsumeMessages()
        {
            for (int i = 1; i <= this.quantity; i++)
            {
                string message = board.ReadMessage();
            }
        }
    }
}

using System;
using System.Threading;

namespace Threading
{
    /// <summary>
    /// Given a content storage, use ReadWriteLockSlim to synchronize a lot of reads and occational writes.
    /// </summary>
    public class ReadWriteLockBasic
    {
        public static void Main(string[] args)
        {
            // Intialize a value storage
            ValueStorage valueStorage = new ValueStorage();

            // Start 5 threads to read, and 1 thread to write
            for (int i = 1; i <= 5; i++)
            {
                var reader = new RepeativeStorageReader("#" + i, valueStorage, 10);
                Thread thread = new Thread(reader.ReadFromStorage);
                thread.Start();
            }

            var writer = new RepeativeStorageWriter("#1", valueStorage, 4);
            Thread writerThread = new Thread(writer.WriteToStorage);
            writerThread.Start();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The reader reads from storage once per second, up to specified times.
    /// </summary>
    public class RepeativeStorageReader
    {
        private string name = null;
        private ValueStorage storage = null;
        private int quantity = 0;

        public RepeativeStorageReader(string name, ValueStorage storage, int quantity)
        {
            this.name = name;
            this.storage = storage;
            this.quantity = quantity;
        }

        public void ReadFromStorage()
        {
            for (int i = 0; i < quantity; i++)
            {
                int value = storage.ReadValue();
                Console.WriteLine(string.Format("Reader {0} reads value from storage: {1}", name, value));
                Thread.Sleep(1000);
            }
        }
    }

    /// <summary>
    /// The writer writes to storage once every 3 seconds, up to specified times.
    /// </summary>
    public class RepeativeStorageWriter
    {
        private string name = null;
        private ValueStorage storage = null;
        private int quantity = 0;

        public RepeativeStorageWriter(string name, ValueStorage storage, int quantity)
        {
            this.name = name;
            this.storage = storage;
            this.quantity = quantity;
        }

        public void WriteToStorage()
        {
            for (int i = 0; i < quantity; i++)
            {
                int newValue = new Random().Next(100);
                storage.WriteValue(newValue);
                Console.WriteLine(string.Format("Writer {0} writes value to storage: {1}", name, newValue));
                Thread.Sleep(3000);
            }
        }
    }

    /// <summary>
    /// The value storage uses ReaderWriterLockSlim to synchronize reads and writes.
    /// </summary>
    public class ValueStorage
    {
        /*
        A thread can enter the lock in three modes: read mode, write mode, and upgradeable read mode. 
        (In the rest of this topic, "upgradeable read mode" is referred to as "upgradeable mode", 
        and the phrase "enter x mode" is used in preference to the longer phrase "enter the lock in x mode".)
        
        Regardless of recursion policy, only one thread can be in write mode at any time. When a thread is in write mode,
        no other thread can enter the lock in any mode. Only one thread can be in upgradeable mode at any time. Any number of
        threads can be in read mode, and there can be one thread in upgradeable mode while other threads are in read mode.

        Upgradeable mode is intended for cases where a thread usually reads from the protected resource, 
        but might need to write to it if some condition is met. 
        */
        private int value = 0;
        private ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();

        public int ReadValue()
        {
            readWriteLock.EnterReadLock();

            try
            {
                return value;
            }
            finally
            {
                readWriteLock.ExitReadLock();
            }
        }

        public void WriteValue(int newValue)
        {
            readWriteLock.EnterWriteLock();

            try
            {
                value = newValue;
            }
            finally
            {
                readWriteLock.ExitWriteLock();
            }
        }
    }
}

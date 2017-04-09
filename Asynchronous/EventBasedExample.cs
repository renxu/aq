﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    public class EventBasedExample
    {
        static void Main(string[] args)
        {
            int threshold = new Random().Next(10);
            Counter c = new Counter(threshold);
            Console.WriteLine(string.Format("The counter threshold is {0}.", threshold));
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total by one.");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached. Event listener is triggered.");
            Console.ReadKey();
        }
    }

    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int threshold)
        {
            this.threshold = threshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                OnThresholdReached(EventArgs.Empty);
            }
        }

        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler ThresholdReached;
    }
}

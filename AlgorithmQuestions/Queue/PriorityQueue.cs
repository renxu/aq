using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class PriorityQueue<T> where T:IComparable
    {
        private Dictionary<int, Queue<T>> queues = null;
        private MinHeap<int> priorityHeap = null;

        public PriorityQueue()
        {
            queues = new Dictionary<int, Queue<T>>();
            priorityHeap = new MinHeap<int>(null);
        }

        /// <summary>
        /// Time complexity: O(1)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="priority"></param>
        public void Enqueue(T item, int priority)
        {
            if (!this.queues.ContainsKey(priority))
            {
                this.queues[priority] = new Queue<T>();
                priorityHeap.Insert(priority);
            }

            this.queues[priority].Enqueue(item);
        }

        /// <summary>
        /// Time complexity: O(logn)
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            int topPriority = priorityHeap.Peak();
            var queue = this.queues[topPriority];
            T value = queue.Dequeue();

            if (queue.Count == 0)
            {
                queues.Remove(topPriority);
                priorityHeap.Extract();
            }

            return value;
        }

        /// <summary>
        /// Time complexity: O(1)
        /// </summary>
        /// <returns></returns>
        public T Peak()
        {
            int topPriority = priorityHeap.Peak();
            var queue = this.queues[topPriority];
            return queue.Peek();
        }
    }
}

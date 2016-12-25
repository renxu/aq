using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void PriorityQueue_EnqueueDequeue_EqualPriority()
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("A", 1);
            queue.Enqueue("B", 1);
            queue.Enqueue("C", 1);
            queue.Enqueue("D", 1);
            queue.Enqueue("E", 1);
            queue.Enqueue("F", 1);
            Assert.AreEqual("A", queue.Dequeue());
            Assert.AreEqual("B", queue.Dequeue());
            Assert.AreEqual("C", queue.Dequeue());
            Assert.AreEqual("D", queue.Dequeue());
            Assert.AreEqual("E", queue.Dequeue());
            Assert.AreEqual("F", queue.Dequeue());
        }

        [TestMethod]
        public void PriorityQueue_EnqueueDequeue_UnequalPriority()
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("A", 1);
            queue.Enqueue("B", 2);
            queue.Enqueue("C", 1);
            queue.Enqueue("D", 2);
            queue.Enqueue("E", 1);
            queue.Enqueue("F", 2);
            Assert.AreEqual("A", queue.Dequeue());
            Assert.AreEqual("C", queue.Dequeue());
            Assert.AreEqual("E", queue.Dequeue());
            Assert.AreEqual("B", queue.Dequeue());
            Assert.AreEqual("D", queue.Dequeue());
            Assert.AreEqual("F", queue.Dequeue());
        }

        [TestMethod]
        public void PriorityQueue_EnqueueDequeue_AddRemoveAddSubqueue()
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("B", 2);
            queue.Enqueue("A", 1);
            Assert.AreEqual("A", queue.Dequeue());
            queue.Enqueue("D", 2);
            queue.Enqueue("C", 1);
            Assert.AreEqual("C", queue.Dequeue());
            Assert.AreEqual("B", queue.Dequeue());
            Assert.AreEqual("D", queue.Dequeue());
        }

        [TestMethod]
        public void PriorityQueue_Peak_Basic()
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("A", 1);
            queue.Enqueue("B", 2);
            queue.Enqueue("C", 1);
            queue.Enqueue("D", 2);
            Assert.AreEqual("A", queue.Peak());
            Assert.AreEqual("A", queue.Dequeue());
            Assert.AreEqual("C", queue.Peak());
        }
    }
}

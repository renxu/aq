using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MinHeapTests
    {
        [TestMethod]
        public void MinHeap_Construct_Basic()
        {
            var data = new int[] { 100, 19, 36, 17, 6, 5, 7, 25, 1 };
            var heap = new MinHeap<int>(data);
            heap.PrintHeap();
        }

        [TestMethod]
        public void MinHeap_Insert_Basic()
        {
            var data = new int[] { 100, 19, 36, 17, 6, 5, 7, 25, 1 };
            var heap = new MinHeap<int>(data);
            heap.Insert(4);
            heap.PrintHeap();
        }

        [TestMethod]
        public void MinHeap_Extract_Basic()
        {
            var data = new int[] { 100, 19, 36, 17, 6, 5, 7, 25, 1 };
            var heap = new MinHeap<int>(data);
            Assert.AreEqual(1, heap.Extract());
            heap.PrintHeap();
        }
    }
}

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
            heap.PrintHeap(); // 1, 5, 6, 17, 19, 36, 7, 100, 25 or 1, 6, 5, 17, 100, 36, 7, 25, 19


        }

        [TestMethod]
        public void MinHeap_Insert_Basic()
        {
            var data = new int[] { 100, 19, 36, 17, 6, 5, 7, 25, 1 };
            var heap = new MinHeap<int>(data);
            heap.Insert(4);
            heap.PrintHeap(); // 1, 4, 6, 17, 5, 36, 7, 100, 25, 19 or 1, 4, 5, 17, 6, 36, 7, 25, 19, 100
        }

        [TestMethod]
        public void MinHeap_Extract_Basic()
        {
            var data = new int[] { 100, 19, 36, 17, 6, 5, 7, 25, 1 };
            var heap = new MinHeap<int>(data);
            Assert.AreEqual(1, heap.Extract());
            heap.PrintHeap(); // 5, 17, 6, 25, 19, 36, 7, 100 or 5, 6, 7, 17, 100, 36, 19, 25
        }
    }
}

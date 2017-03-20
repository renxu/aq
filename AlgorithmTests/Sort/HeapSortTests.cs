using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        public void HeapSort_WithNormalArray()
        {
            int[] inputs = { 56, 3, 249, 518, 7, 26, 94, 651, 23, 9 };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = HeapSort.Sort(inputs);
            TestUtility.AssertSortAscResult(originalInputs, outputs);
        }

        /*
        [TestMethod]
        public void HeapSort_WithDuplicateNumbers()
        {
            int[] inputs = { 56, 3, 249, 518, 3, 26, 94, 94, 23, 9 };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = HeapSort.Sort(inputs);
            TestUtility.AssertSortAscResult(originalInputs, outputs);
        }
        */

        [TestMethod]
        public void HeapSort_SortInPlace_WithNormalArray()
        {
            int[] inputs = { 56, 3, 249, 518, 7, 26, 94, 651, 23, 9 };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = HeapSort.SortInPlace(inputs);
            TestUtility.AssertSortAscResult(originalInputs, outputs);
        }

        [TestMethod]
        public void HeapSort_SortInPlace_SingleNodeArray()
        {
            int[] inputs = { 56 };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = HeapSort.SortInPlace(inputs);
            TestUtility.AssertSortAscResult(originalInputs, outputs);
        }

        [TestMethod]
        public void HeapSort_SortInPlace_EmptyArray()
        {
            int[] inputs = { };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = HeapSort.SortInPlace(inputs);
            Assert.AreEqual(0, outputs.Length);
        }
    }
}

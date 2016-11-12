using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void MergeSort_WithNormalArray()
        {
            int[] inputs = { 56, 3, 249, 518, 7, 26, 94, 651, 23, 9 };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = MergeSort.Sort(inputs);
            TestUtility.AssertSortAscResult(originalInputs, outputs);
        }

        [TestMethod]
        public void MergeSort_WithDuplicateNumbers()
        {
            int[] inputs = { 56, 3, 249, 518, 3, 26, 94, 94, 23, 9 };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = MergeSort.Sort(inputs);
            TestUtility.AssertSortAscResult(originalInputs, outputs);
        }
    }
}

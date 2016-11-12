using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class SelectionSortTests
    {
        [TestMethod]
        public void SelectionSort_WithNormalArray()
        {
            int[] inputs = { 56, 3, 249, 518, 7, 26, 94, 651, 23, 9 };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = SelectionSort.Sort(inputs);
            TestUtility.AssertSortAscResult(originalInputs, outputs);
        }

        [TestMethod]
        public void SelectionSort_WithDuplicateNumbers()
        {
            int[] inputs = { 56, 3, 249, 518, 3, 26, 94, 94, 23, 9 };
            int[] originalInputs = (int[])inputs.Clone();
            int[] outputs = SelectionSort.Sort(inputs);
            TestUtility.AssertSortAscResult(originalInputs, outputs);
        }
    }
}

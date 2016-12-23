using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class AlmostSortedTests
    {
        [TestMethod]
        public void AlmostSorted_Sort_Basic()
        {
            var input = new int[] { 3, 1, 4, 2, 7, 5, 6, 10, 8, 9 };
            var result = AlmostSorted.Sort(input, 2);
            for(int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i+1, result[i]);
            }
        }
    }
}

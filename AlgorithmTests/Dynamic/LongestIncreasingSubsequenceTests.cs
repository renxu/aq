using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class LongestIncreasingSubsequenceTests
    {
        [TestMethod]
        public void LongestIncreasingSubsequence_NoDuplicates()
        {
            var input = new int[]{ 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            var results = LongestIncreasingSubsequence.Find(input);
            Assert.AreEqual(6, results.Length, "Wrong result length.");
        }

        [TestMethod]
        public void LongestIncreasingSubsequence_WithDuplicates()
        {
            var input = new int[] { 10, 22, 9, 22, 33, 21, 50, 41, 60, 80 };
            var results = LongestIncreasingSubsequence.Find(input);
            Assert.AreEqual(6, results.Length, "Wrong result length.");
        }
    }
}

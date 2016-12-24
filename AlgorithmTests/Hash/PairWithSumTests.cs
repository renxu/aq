using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class PairWithSumTests
    {
        [TestMethod]
        public void PairWithSum_Check_Positive()
        {
            var input = new int[] { 3, 1, 4, 2, 7, 5, 6, 10, 8, 9 };
            Assert.IsTrue(PairWithSum.Check(input, 19));
        }

        [TestMethod]
        public void PairWithSum_Check_Negative()
        {
            var input = new int[] { 3, 1, 4, 2, 7, 5, 6, 10, 8, 9 };
            Assert.IsFalse(PairWithSum.Check(input, 20));
        }
    }
}

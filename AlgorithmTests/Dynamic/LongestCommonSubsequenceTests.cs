using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class LongestCommonSubsequenceTests
    {
        [TestMethod]
        public void LongestCommonSubsequence_NoDuplicates()
        {
            var result = LongestCommonSubsequence.FindByBottomUp("AAABCCCB", "CCCBAAAB");
            Assert.AreEqual(4, result, "Wrong result."); //ADH
            result = LongestCommonSubsequence.FindByTopDown("AAABCCCB", "CCCBAAAB");
            Assert.AreEqual(4, result, "Wrong result."); //ADH
        }

        [TestMethod]
        public void LongestCommonSubsequence_WithDuplicates()
        {
            var result = LongestCommonSubsequence.FindByBottomUp("AGGTABAAAAAAAAAAAAAAAA", "GXTXAYBAAAAAAAAAAAAAAAA");
            Assert.AreEqual(20, result, "Wrong result."); //GTABAAAAAAAAAAAAAAAA
            result = LongestCommonSubsequence.FindByTopDown("AGGTABAAAAAAAAAAAAAAAA", "GXTXAYBAAAAAAAAAAAAAAAA");
            Assert.AreEqual(20, result, "Wrong result."); //GTABAAAAAAAAAAAAAAAA
        }

        [TestMethod]
        public void LongestCommonSubsequence_Long()
        {
            var result = LongestCommonSubsequence.FindByBottomUp("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ZYXWUTSRQPONMLKJIHGFEDCBA");
            Assert.AreEqual(1, result, "Wrong result.");
            result = LongestCommonSubsequence.FindByTopDown("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ZYXWUTSRQPONMLKJIHGFEDCBA");
            Assert.AreEqual(1, result, "Wrong result.");
        }
    }
}

using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void LinearSearch_WithNormalArray()
        {
            int[] inputs = { 56, 3, 249, 518, 7, 26, 94, 651, 23, 9 };
            int result = LinearSearch.Search(inputs, 651);
            Assert.AreEqual(7, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void LinearSearch_WithNullArray()
        {
            int[] inputs = null;
            int result = LinearSearch.Search(inputs, 0);
            Assert.AreEqual(-1, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void LinearSearch_WithEmptyArray()
        {
            int[] inputs = { };
            int result = LinearSearch.Search(inputs, 0);
            Assert.AreEqual(-1, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void LinearSearch_WithNoMatch()
        {
            int[] inputs = { 56, 3, 249, 518, 7, 26, 94, 651, 23, 9 };
            int result = LinearSearch.Search(inputs, 652);
            Assert.AreEqual(-1, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void LinearSearch_WithMultipleMatches()
        {
            int[] inputs = { 56, 9, 249, 518, 7, 26, 94, 651, 23, 9 };
            int result = LinearSearch.Search(inputs, 9);
            Assert.AreEqual(1, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void LinearSearch_MatchFirst()
        {
            int[] inputs = { 56, 3, 249, 518, 7, 26, 94, 651, 23, 9 };
            int result = LinearSearch.Search(inputs, 56);
            Assert.AreEqual(0, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void LinearSearch_MatchLast()
        {
            int[] inputs = { 56, 3, 249, 518, 7, 26, 94, 651, 23, 9 };
            int result = LinearSearch.Search(inputs, 9);
            Assert.AreEqual(inputs.Length - 1, result, "The search result index is wrong.");
        }
    }
}

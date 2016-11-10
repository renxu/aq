using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearch_WithoutRecursion_WithNormalArray()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int result = BinarySearch.SearchWithoutRecursion(inputs, 23);
            Assert.AreEqual(5, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithoutRecursion_WithSingleElementArray()
        {
            int[] inputs = { 2 };
            int result = BinarySearch.SearchWithoutRecursion(inputs, 2);
            Assert.AreEqual(0, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithoutRecursion_WithNoMatch()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int result = BinarySearch.SearchWithoutRecursion(inputs, 13);
            Assert.AreEqual(-1, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithoutRecursion_WithMultipleMatches()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 56, 72, 91 };
            int result = BinarySearch.SearchWithoutRecursion(inputs, 56);
            Assert.IsTrue(result == 7 || result == 8, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithoutRecursion_MatchFirst()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int result = BinarySearch.SearchWithoutRecursion(inputs, 2);
            Assert.AreEqual(0, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithoutRecursion_MatchLast()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int result = BinarySearch.SearchWithoutRecursion(inputs, 91);
            Assert.AreEqual(inputs.Length - 1, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithRecursion_WithNormalArray()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int result = BinarySearch.SearchWithRecursion(inputs, 23);
            Assert.AreEqual(5, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithRecursion_WithSingleElementArray()
        {
            int[] inputs = { 2 };
            int result = BinarySearch.SearchWithRecursion(inputs, 2);
            Assert.AreEqual(0, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithRecursion_WithNoMatch()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int result = BinarySearch.SearchWithRecursion(inputs, 13);
            Assert.AreEqual(-1, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithRecursion_WithMultipleMatches()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 56, 72, 91 };
            int result = BinarySearch.SearchWithRecursion(inputs, 56);
            Assert.IsTrue(result == 7 || result == 8, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithRecursion_MatchFirst()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int result = BinarySearch.SearchWithRecursion(inputs, 2);
            Assert.AreEqual(0, result, "The search result index is wrong.");
        }

        [TestMethod]
        public void BinarySearch_WithRecursion_MatchLast()
        {
            int[] inputs = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int result = BinarySearch.SearchWithRecursion(inputs, 91);
            Assert.AreEqual(inputs.Length - 1, result, "The search result index is wrong.");
        }
    }
}

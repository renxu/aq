using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class StringPermutationTests
    { 

        [TestMethod]
        public void StringPermutation_Find()
        {
            var permutations = StringPermutation.FindPermutation("ABC");
            Assert.AreEqual(6, permutations.Count, "Permutation count is wrong.");
        }
    }
}

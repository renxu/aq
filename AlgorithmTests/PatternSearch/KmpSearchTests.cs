using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class KmpSearchTests
    {
        [TestMethod]
        public void KmpSearch_Basic()
        {
            var results = KmpSearch.Search("AABAACAADAABAAABAA", "AABA");
            Assert.AreEqual(3, results.Count, "The search result count is wrong.");
        }

        [TestMethod]
        public void KmpSearch_WorstCase()
        {
            var results = KmpSearch.Search("AAAAAAAAAA", "AAA");
            Assert.AreEqual(8, results.Count, "The search result count is wrong.");
        }
    }
}

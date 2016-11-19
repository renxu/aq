using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class NaiveSearchTests
    {
        [TestMethod]
        public void NaiveSearch_Basic()
        {
            var results = NaiveSearch.Search("AABAACAADAABAAABAA", "AABA");
            Assert.AreEqual(3, results.Count, "The search result count is wrong.");
        }
    }
}

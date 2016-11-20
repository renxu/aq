using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class FindSingleTests
    {
        [TestMethod]
        public void FindSingle_Find_CommonCase()
        {
            int single = FindSingle.Find(new int[] { 12, 1, 12, 3, 12, 1, 1, 2, 3, 3 });
            Assert.AreEqual(2, single, "Wrong result");
        }
    }
}

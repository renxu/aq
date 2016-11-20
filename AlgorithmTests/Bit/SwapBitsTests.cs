using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class SwapBitsTests
    {
        [TestMethod]
        public void SwapBits_SwapPairs1_CommonCase()
        {
            Assert.AreEqual(227, SwapBits.SwapPairs1(47, 1, 5, 3), "Wrong result");
        }

        [TestMethod]
        public void SwapBits_SwapPairs2_CommonCase()
        {
            Assert.AreEqual(227, SwapBits.SwapPairs2(47, 1, 5, 3), "Wrong result");
        }
    }
}

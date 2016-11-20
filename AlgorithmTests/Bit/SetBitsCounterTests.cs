using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class SetBitsCounterTests
    {
        [TestMethod]
        public void SetBitsCounter_Count_CommonCase()
        {
            Assert.AreEqual(9, SetBitsCounter.NaiveCount(6), "Wrong result");
        }
    }
}

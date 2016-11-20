using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class InversionCounterTests
    {
        [TestMethod]
        public void InversionCounter_CommonCase()
        {
            var array = new int[] { 2, 4, 1, 5, 3 };
            var counter = new InversionCounter(array);
            int inversionCount = counter.Count();
            Assert.AreEqual(4, inversionCount, "Wrong result.");
        }
    }
}

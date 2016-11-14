using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class FibonacciNumberTests
    {
        [TestMethod]
        public void FibonacciNumber_ByNormal()
        {
            Assert.AreEqual(0, FibonacciNumber.GetNthByNormal(0), "Wrong result for n=0.");
            Assert.AreEqual(1, FibonacciNumber.GetNthByNormal(1), "Wrong result for n=1.");
            Assert.AreEqual(1, FibonacciNumber.GetNthByNormal(2), "Wrong result for n=2.");
            Assert.AreEqual(2, FibonacciNumber.GetNthByNormal(3), "Wrong result for n=3.");
            Assert.AreEqual(34, FibonacciNumber.GetNthByNormal(9), "Wrong result for n=9.");
        }

        [TestMethod]
        public void FibonacciNumber_ByTopDown()
        {
            Assert.AreEqual(0, FibonacciNumber.GetNthByTopDown(0), "Wrong result for n=0.");
            Assert.AreEqual(1, FibonacciNumber.GetNthByTopDown(1), "Wrong result for n=1.");
            Assert.AreEqual(1, FibonacciNumber.GetNthByTopDown(2), "Wrong result for n=2.");
            Assert.AreEqual(2, FibonacciNumber.GetNthByTopDown(3), "Wrong result for n=3.");
            Assert.AreEqual(34, FibonacciNumber.GetNthByTopDown(9), "Wrong result for n=9.");
        }

        [TestMethod]
        public void FibonacciNumber_ByBottomUp()
        {
            Assert.AreEqual(0, FibonacciNumber.GetNthByBottomUp(0), "Wrong result for n=0.");
            Assert.AreEqual(1, FibonacciNumber.GetNthByBottomUp(1), "Wrong result for n=1.");
            Assert.AreEqual(1, FibonacciNumber.GetNthByBottomUp(2), "Wrong result for n=2.");
            Assert.AreEqual(2, FibonacciNumber.GetNthByBottomUp(3), "Wrong result for n=3.");
            Assert.AreEqual(34, FibonacciNumber.GetNthByBottomUp(9), "Wrong result for n=9.");
        }

    }
}

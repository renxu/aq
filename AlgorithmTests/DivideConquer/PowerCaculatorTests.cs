using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class PowerCaculatorTests
    {
        [TestMethod]
        public void PowerCaculator_PositiveXPositiveY()
        {
            double x = 2;
            double y = 5;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }

        [TestMethod]
        public void PowerCaculator_PositiveXNegativeY()
        {
            double x = 2;
            double y = -5;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }

        [TestMethod]
        public void PowerCaculator_PositiveXZeroY()
        {
            double x = 2;
            double y = 0;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }

        [TestMethod]
        public void PowerCaculator_NegativeXPositiveY()
        {
            double x = -2;
            double y = 5;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }

        [TestMethod]
        public void PowerCaculator_NegativeXNegativeY()
        {
            double x = -2;
            double y = -5;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }

        [TestMethod]
        public void PowerCaculator_NegativeXZeroY()
        {
            double x = -2;
            double y = 0;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }

        [TestMethod]
        public void PowerCaculator_ZeroXPositiveY()
        {
            double x = 0;
            double y = 5;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }

        [TestMethod]
        public void PowerCaculator_ZeroXNegativeY()
        {
            double x = 0;
            double y = -5;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }

        [TestMethod]
        public void PowerCaculator_ZeroXZeroY()
        {
            double x = 0;
            double y = 0;
            Assert.AreEqual(Math.Pow(x, y), PowerCaculator.Pow(x, y), "Wrong calculation result.");
        }
    }
}

using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MajorityElementTests
    {
        [TestMethod]
        public void MajorityElement_Find_OddCountInputPositive()
        {
            var input = new int[] { 2, 3, 2, 3, 2 };
            int majority;
            bool found = MajorityElement.Find(input, out majority);
            Assert.IsTrue(found);
            Assert.AreEqual(2, majority);
        }

        [TestMethod]
        public void MajorityElement_Find_EvenCountInputPositive()
        {
            var input = new int[] { 2, 3, 2, 3 };
            int majority;
            bool found = MajorityElement.Find(input, out majority);
            Assert.IsTrue(found);
            Assert.AreEqual(2, majority);
        }

        [TestMethod]
        public void MajorityElement_Find_OddCountInputNegative()
        {
            var input = new int[] { 2, 3, 2, 3, 1 };
            int majority;
            bool found = MajorityElement.Find(input, out majority);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void MajorityElement_Find_EvenCountInputNegative()
        {
            var input = new int[] { 1, 2, 3, 4 };
            int majority;
            bool found = MajorityElement.Find(input, out majority);
            Assert.IsFalse(found);
        }
    }
}

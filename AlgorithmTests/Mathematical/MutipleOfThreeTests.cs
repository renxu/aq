using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MutipleOfThreeTests
    {
        [TestMethod]
        public void MutipleOfThree_Check1()
        {
            Assert.IsTrue(MutipleOfThree.Check1(0));
            Assert.IsTrue(MutipleOfThree.Check1(3));
            Assert.IsTrue(MutipleOfThree.Check1(6));
            Assert.IsTrue(MutipleOfThree.Check1(9));
            Assert.IsTrue(MutipleOfThree.Check1(12));
            Assert.IsTrue(MutipleOfThree.Check1(369));
            Assert.IsTrue(MutipleOfThree.Check1(-3));
            Assert.IsTrue(MutipleOfThree.Check1(-6));
            Assert.IsTrue(MutipleOfThree.Check1(-9));
            Assert.IsTrue(MutipleOfThree.Check1(-12));
            Assert.IsTrue(MutipleOfThree.Check1(-369));
            Assert.IsFalse(MutipleOfThree.Check1(4));
            Assert.IsFalse(MutipleOfThree.Check1(11));
            Assert.IsFalse(MutipleOfThree.Check1(368));
            Assert.IsFalse(MutipleOfThree.Check1(-4));
            Assert.IsFalse(MutipleOfThree.Check1(-11));
            Assert.IsFalse(MutipleOfThree.Check1(-368));
        }

        [TestMethod]
        public void MutipleOfThree_Check2()
        {
            Assert.IsTrue(MutipleOfThree.Check2(0));
            Assert.IsTrue(MutipleOfThree.Check2(3));
            Assert.IsTrue(MutipleOfThree.Check2(6));
            Assert.IsTrue(MutipleOfThree.Check2(9));
            Assert.IsTrue(MutipleOfThree.Check2(12));
            Assert.IsTrue(MutipleOfThree.Check2(369));
            Assert.IsTrue(MutipleOfThree.Check2(-3));
            Assert.IsTrue(MutipleOfThree.Check2(-6));
            Assert.IsTrue(MutipleOfThree.Check2(-9));
            Assert.IsTrue(MutipleOfThree.Check2(-12));
            Assert.IsTrue(MutipleOfThree.Check2(-369));
            Assert.IsFalse(MutipleOfThree.Check2(4));
            Assert.IsFalse(MutipleOfThree.Check2(11));
            Assert.IsFalse(MutipleOfThree.Check2(368));
            Assert.IsFalse(MutipleOfThree.Check2(-4));
            Assert.IsFalse(MutipleOfThree.Check2(-11));
            Assert.IsFalse(MutipleOfThree.Check2(-368));
        }
    }
}

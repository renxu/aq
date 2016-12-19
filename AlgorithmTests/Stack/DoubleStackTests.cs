using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class DoubleStackTests
    {
        [TestMethod]
        public void DoubleStackTests_PushPop_FirstStack()
        {
            var doubleStack = new DoubleStack<int>(3);
            doubleStack.Push1(1);
            doubleStack.Push1(2);
            doubleStack.Push1(3);
            Assert.AreEqual(3, doubleStack.Pop1());
            Assert.AreEqual(2, doubleStack.Pop1());
            Assert.AreEqual(1, doubleStack.Pop1());
        }

        [TestMethod]
        public void DoubleStackTests_PushPop_SecondStack()
        {
            var doubleStack = new DoubleStack<int>(3);
            doubleStack.Push2(1);
            doubleStack.Push2(2);
            doubleStack.Push2(3);
            Assert.AreEqual(3, doubleStack.Pop2());
            Assert.AreEqual(2, doubleStack.Pop2());
            Assert.AreEqual(1, doubleStack.Pop2());
        }

        [TestMethod]
        public void DoubleStackTests_PushPop_BothStacks()
        {
            var doubleStack = new DoubleStack<int>(3);
            doubleStack.Push1(1);
            doubleStack.Push1(2);
            doubleStack.Push2(3);
            Assert.AreEqual(2, doubleStack.Pop1());
            Assert.AreEqual(1, doubleStack.Pop1());
            Assert.AreEqual(3, doubleStack.Pop2());
        }

        [TestMethod]
        public void DoubleStackTests_OverPush_FirstStack()
        {
            var doubleStack = new DoubleStack<int>(2);
            doubleStack.Push1(1);
            doubleStack.Push1(2);

            try
            {
                doubleStack.Push1(3);
                Assert.Fail("No exception was thrown.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void DoubleStackTests_OverPush_SecondStack()
        {
            var doubleStack = new DoubleStack<int>(2);
            doubleStack.Push2(1);
            doubleStack.Push2(2);

            try
            {
                doubleStack.Push2(3);
                Assert.Fail("No exception was thrown.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void DoubleStackTests_OverPush_BothStacks()
        {
            var doubleStack = new DoubleStack<int>(4);
            doubleStack.Push1(1);
            doubleStack.Push1(2);
            doubleStack.Push2(3);
            doubleStack.Push2(4);

            try
            {
                doubleStack.Push1(5);
                Assert.Fail("No exception was thrown.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void DoubleStackTests_OverPop_FirstStack()
        {
            var doubleStack = new DoubleStack<int>(2);
            doubleStack.Push1(1);
            doubleStack.Push1(2);
            doubleStack.Pop1();
            doubleStack.Pop1();

            try
            {
                doubleStack.Pop1();
                Assert.Fail("No exception was thrown.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void DoubleStackTests_OverPop_SecondStack()
        {
            var doubleStack = new DoubleStack<int>(2);
            doubleStack.Push2(1);
            doubleStack.Push2(2);
            doubleStack.Pop2();
            doubleStack.Pop2();

            try
            {
                doubleStack.Pop2();
                Assert.Fail("No exception was thrown.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void DoubleStackTests_MixUsage()
        {
            var doubleStack = new DoubleStack<int>(4);
            doubleStack.Push1(11);
            doubleStack.Push2(21);
            doubleStack.Push1(12);
            doubleStack.Push2(22);
            Assert.AreEqual(12, doubleStack.Pop1());
            Assert.AreEqual(11, doubleStack.Pop1());
            Assert.AreEqual(22, doubleStack.Pop2());
            Assert.AreEqual(21, doubleStack.Pop2());
        }
    }
}

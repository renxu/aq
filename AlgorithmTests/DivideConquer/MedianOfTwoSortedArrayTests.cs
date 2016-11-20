using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MedianOfTwoSortedArrayTests
    {
        [TestMethod]
        public void MedianOfTwoSortedArray_CommonCase()
        {
            var array1 = new double[] { 1, 12, 15, 16, 38 };
            var array2 = new double[] { 2, 13, 17, 30, 45 };
            double median = MedianOfTwoSortedArray.GetMedian(array1, array2);
            Assert.AreEqual(15.5, median, "Wrong result.");
        }
    }
}

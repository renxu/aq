using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class RegularExpressionMatchingTests
    { 

        [TestMethod]
        public void IsMatch_Basics()
        {
            RegularExpressionMatching re = new RegularExpressionMatching();
            Assert.IsFalse(re.IsMatch("aa", "a"));
            Assert.IsTrue(re.IsMatch("aa", "aa"));
            Assert.IsFalse(re.IsMatch("aaa", "aa"));
            Assert.IsTrue(re.IsMatch("aa", "a*"));
            Assert.IsTrue(re.IsMatch("aa", ".*"));
            Assert.IsTrue(re.IsMatch("ab", ".*"));
            Assert.IsTrue(re.IsMatch("aab", "c*a*b"));
            Assert.IsTrue(re.IsMatch("", ".*"));
        }
    }
}
using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class ParenthesisPairValidatorTests
    {
        [TestMethod]
        public void ParenthesisPairValidator_IsParenthesisBalanced_Balanced()
        {
            Assert.IsTrue(ParenthesisPairValidator.IsParenthesisBalanced("[()]"));
            Assert.IsTrue(ParenthesisPairValidator.IsParenthesisBalanced("[()]{}{[()()]()}"));
            Assert.IsTrue(ParenthesisPairValidator.IsParenthesisBalanced("[(a)]"));
        }

        [TestMethod]
        public void ParenthesisPairValidator_IsParenthesisBalanced_NotBalanced()
        {
            Assert.IsFalse(ParenthesisPairValidator.IsParenthesisBalanced("[(])"));
            Assert.IsFalse(ParenthesisPairValidator.IsParenthesisBalanced("[()]("));
        }

        [TestMethod]
        public void ParenthesisPairValidator_IsParenthesisBalanced_Empty()
        {
            Assert.IsTrue(ParenthesisPairValidator.IsParenthesisBalanced(""));
        }

    }
}

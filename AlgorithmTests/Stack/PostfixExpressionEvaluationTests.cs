using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class PostfixExpressionEvaluationTests
    {
        [TestMethod]
        public void PostfixExpressionEvaluation_Evaluate_BasicCase()
        {
            Assert.AreEqual(-4m, PostfixExpressionEvaluation.Evaluate("2 3 1 * + 9 -", ' '));
        }
    }
}

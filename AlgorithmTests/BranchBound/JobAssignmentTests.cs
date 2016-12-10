using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class JobAssignmentTests
    {
        [TestMethod]
        public void JobAssignment_FindMinCostByBacktrack_Basic()
        {
            var costMatrix = new int[,]
            {
                { 9, 6, 7, 8 },
                { 6, 1, 3, 7 },
                { 5, 8, 1, 8 },
                { 7, 6, 9, 4 }
            };
            var assignment = new JobAssignment(costMatrix);
            Assert.AreEqual(15, assignment.FindMinCostByBacktrack(), "Wrong result.");
        }

        [TestMethod]
        public void JobAssignment_FindMinCostByBacktrack_Basic2()
        {
            var costMatrix = new int[,]
            {
                { 9, 6, 7, 8 },
                { 6, 2, 1, 7 },
                { 6, 8, 1, 8 },
                { 7, 6, 9, 4 }
            };
            var assignment = new JobAssignment(costMatrix);
            Assert.AreEqual(16, assignment.FindMinCostByBacktrack(), "Wrong result.");
        }

        [TestMethod]
        public void JobAssignment_FindMinCostByBacktrack_SingleJob()
        {
            var costMatrix = new int[,]
            {
                { 3 }
            };
            var assignment = new JobAssignment(costMatrix);
            Assert.AreEqual(3, assignment.FindMinCostByBacktrack(), "Wrong result.");
        }
    }
}

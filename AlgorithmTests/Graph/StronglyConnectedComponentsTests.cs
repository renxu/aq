using System;
using System.Collections.Generic;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class StronglyConnectedComponentsTests
    {
        [TestMethod]
        public void StronglyConnectedComponents_Find_Basic()
        {
            // Graph: http://d1hyf4ir1gqw6c.cloudfront.net//wp-content/uploads/SCC.png
            var graph = new MatrixGraph(5, true);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 0);
            graph.AddEdge(2, 1);
            graph.AddEdge(3, 4);
            List<List<int>> components = StronglyConnectedComponents.Find(graph);
            Assert.AreEqual(3, components.Count);
        }
        
    }
}

using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class DetectCircleTests
    {
        [TestMethod]
        public void DetectCircle_Undirected_WithCircle()
        {
            // Graph: http://degottd575b1t.cloudfront.net//wp-content/uploads/graph_representation12.png
            var graph = new MatrixGraph(5, false);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            Assert.IsTrue(DetectCircle.Detect(graph), "The graph should find a circle.");
        }

        [TestMethod]
        public void DetectCircle_Undirected_WithoutCircle()
        {
            var graph = new MatrixGraph(5, false);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            Assert.IsFalse(DetectCircle.Detect(graph), "The graph should not find a circle.");
        }

        [TestMethod]
        public void DetectCircle_Undirected_SelfCircle()
        {
            // Graph: http://degottd575b1t.cloudfront.net//wp-content/uploads/graph_representation12.png
            var graph = new MatrixGraph(5, false);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(4, 4);
            Assert.IsTrue(DetectCircle.Detect(graph), "The graph should find a circle.");
        }

        [TestMethod]
        public void DetectCircle_Undirected_UnconnectedWithCircle()
        {
            var graph = new MatrixGraph(5, false);
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(2, 4);
            Assert.IsTrue(DetectCircle.Detect(graph), "The graph should find a circle.");
        }

        [TestMethod]
        public void DetectCircle_Undirected_UnconnectedWithoutCircle()
        {
            var graph = new MatrixGraph(5, false);
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            Assert.IsFalse(DetectCircle.Detect(graph), "The graph should not find a circle.");
        }

        [TestMethod]
        public void DetectCircle_Directed_WithCircle()
        {
            var graph = new MatrixGraph(5, true);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 1);
            graph.AddEdge(4, 0);
            Assert.IsTrue(DetectCircle.Detect(graph), "The graph should find a circle.");
        }

        [TestMethod]
        public void DetectCircle_Directed_WithoutCircle()
        {
            var graph = new MatrixGraph(5, true);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 1);
            Assert.IsFalse(DetectCircle.Detect(graph), "The graph should not find a circle.");
        }

        [TestMethod]
        public void DetectCircle_Directed_SelfCircle()
        {
            var graph = new MatrixGraph(5, true);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 1);
            graph.AddEdge(1, 1);
            Assert.IsTrue(DetectCircle.Detect(graph), "The graph should find a circle.");
        }
    }
}

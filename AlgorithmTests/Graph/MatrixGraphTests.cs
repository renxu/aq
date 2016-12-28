using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MatrixGraphTests
    {
        [TestMethod]
        public void MatrixGraph_CreateGraph_UndirectedUnweighted()
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
            graph.PrintGraph();
        }

        [TestMethod]
        public void MatrixGraph_CreateGraph_DirectedUnweighted()
        {
            // Graph: http://degottd575b1t.cloudfront.net//wp-content/uploads/BFS.jpg
            var graph = new MatrixGraph(4, true);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 0);
            graph.AddEdge(3, 3);
            graph.PrintGraph();
        }

        [TestMethod]
        public void MatrixGraph_TopologicalSort_Basic()
        {
            // Graph: http://d1hyf4ir1gqw6c.cloudfront.net//wp-content/uploads/graph.png
            var graph = new MatrixGraph(6, true);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(5, 0);
            graph.AddEdge(5, 2);
            int[] result = graph.TopoloicalSort();
            Console.WriteLine(CommonUtility.ToString(result));
            Console.WriteLine("Manually validate results!");
        }

        [TestMethod]
        public void MatrixGraph_DijkstrasShortestPath_Basic()
        {
            // Graph: http://d1hyf4ir1gqw6c.cloudfront.net//wp-content/uploads/Fig-11.jpg
            // Shortest paths: http://d1hyf4ir1gqw6c.cloudfront.net//wp-content/uploads/DIJ5.jpg
            var graph = new MatrixGraph(9, false);
            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 7, 8);
            graph.AddEdge(1, 2, 8);
            graph.AddEdge(1, 7, 11);
            graph.AddEdge(2, 3, 7);
            graph.AddEdge(2, 5, 4);
            graph.AddEdge(2, 8, 2);
            graph.AddEdge(3, 4, 9);
            graph.AddEdge(3, 5, 14);
            graph.AddEdge(4, 5, 10);
            graph.AddEdge(5, 6, 2);
            graph.AddEdge(6, 7, 1);
            graph.AddEdge(6, 8, 6);
            graph.AddEdge(7, 8, 7);
            int[] result = graph.DijkstrasShortestPath(0, 4);
            Console.WriteLine(CommonUtility.ToString(result)); // 0, 7, 6, 5, 4
            Console.WriteLine("Manually validate results!");
        }

        [TestMethod]
        public void MatrixGraph_GetLongestPath_Basic()
        {
            // Graph: http://d1hyf4ir1gqw6c.cloudfront.net//wp-content/uploads/LongestPath.png
            // where r = 0, s = 1, t = 2, x = 3, y = 4, z = 5.
            var graph = new MatrixGraph(6, true);
            graph.AddEdge(0, 1, 5);
            graph.AddEdge(0, 2, 3);
            graph.AddEdge(1, 2, 2);
            graph.AddEdge(1, 3, 6);
            graph.AddEdge(2, 3, 7);
            graph.AddEdge(2, 4, 4);
            graph.AddEdge(2, 5, 2);
            graph.AddEdge(3, 4, -1);
            graph.AddEdge(3, 5, 1);
            graph.AddEdge(4, 5, -2);
            int result = graph.GetLongestPath(1, 2);
            Assert.AreEqual(2, result);
            result = graph.GetLongestPath(1, 3);
            Assert.AreEqual(9, result);
            result = graph.GetLongestPath(1, 4);
            Assert.AreEqual(8, result);
            result = graph.GetLongestPath(1, 5);
            Assert.AreEqual(10, result);
        }
    }
}

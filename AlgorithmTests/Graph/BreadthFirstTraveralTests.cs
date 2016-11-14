using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class BreadthFirstTraveralTests
    {
        [TestMethod]
        public void BreadthFirstTraveral_Traverse_UndirectedUnweighted()
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
            BreadthFirstTraveral.IterativeTraverse(graph, 2);
            Console.Write(System.Environment.NewLine);
            BreadthFirstTraveral.RecursiveTraverse(graph, 2);
        }

        [TestMethod]
        public void BreadthFirstTraveral_Traverse_DirectedUnweighted()
        {
            // Graph: http://degottd575b1t.cloudfront.net//wp-content/uploads/BFS.jpg
            var graph = new MatrixGraph(4, true);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 0);
            graph.AddEdge(3, 3);
            BreadthFirstTraveral.IterativeTraverse(graph, 0);
            Console.Write(System.Environment.NewLine);
            BreadthFirstTraveral.RecursiveTraverse(graph, 0);
            Console.Write(System.Environment.NewLine);
            BreadthFirstTraveral.IterativeTraverse(graph, 3);
            Console.Write(System.Environment.NewLine);
            BreadthFirstTraveral.RecursiveTraverse(graph, 3);
        }
    }
}

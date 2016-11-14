using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class DepthFirstTraveralTests
    {
        [TestMethod]
        public void DepthFirstTraveral_Traverse_UndirectedUnweighted()
        {
            // Graph: http://degottd575b1t.cloudfront.net//wp-content/uploads/graph_representation12.png
            var graph = new LinkedListGraph(5, false);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            DepthFirstTraveral.IterativeTraverse(graph, 2);
            Console.Write(System.Environment.NewLine);
            DepthFirstTraveral.RecursiveTraverse(graph, 2);
        }

        [TestMethod]
        public void DepthFirstTraveral_Traverse_DirectedUnweighted()
        {
            // Graph: http://degottd575b1t.cloudfront.net//wp-content/uploads/BFS.jpg
            var graph = new LinkedListGraph(4, true);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 0);
            graph.AddEdge(3, 3);
            DepthFirstTraveral.IterativeTraverse(graph, 0);
            Console.Write(System.Environment.NewLine);
            DepthFirstTraveral.RecursiveTraverse(graph, 0);
            Console.Write(System.Environment.NewLine);
            DepthFirstTraveral.IterativeTraverse(graph, 3);
            Console.Write(System.Environment.NewLine);
            DepthFirstTraveral.RecursiveTraverse(graph, 3);
        }
    }
}

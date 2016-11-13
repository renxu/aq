using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MatrixGraphTests
    {
        [TestMethod]
        public void MatrixGraph_CreateGraph_UndirectionalUnweighted()
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
        public void MatrixGraph_CreateGraph_DirectionalUnweighted()
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
    }
}

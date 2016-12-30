using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class StronglyConnectedComponents
    {
        /// <summary>
        /// http://www.geeksforgeeks.org/strongly-connected-components/
        /// How it works:
        /// Let's divide the graph into N subgraphs. Each subgraph is a strongly connected component (SCC). Now treat each SCC as one node, 
        /// forming a simplified graph of the original graph. The new SCC graph must be acyclic; otherwise, the SCC nodes in a cycle can form a 
        /// bigger SCC. Ideally, we want to visit a sink SCC node first, exlude the sink node, visit a new sink node, and so on.
        /// However, it is hard to find such a SCC node.
        /// 
        /// What we can find is the last SCC node that we want to visit. When the original graph is travered by DFS, the sink SCC node is always 
        /// first completely-visited. Therefore, if we record the DFS traveral in a stack, the top of the stack must belong the the SCC node that 
        /// we want to visit at last. 
        /// 
        /// Luckily, the transpose graph (the same graph with the direction of every edge reversed) has exactly the same strongly connected 
        /// components as the original graph. The SCC nod ethat we want to visit at last in the original graph becomes the first SCC node
        /// that we want to visit in the transpose graph! Following the nodes from the previous stack, DFS will find all SCC in the transpose
        /// graph.
        /// 
        /// Time: O(n*2)
        /// Space: O(n)
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Vertices of sub graphs.</returns>
        public static List<List<int>> Find(IGraph graph)
        {
            CommonUtility.ThrowIfNull(graph);
            var result = new List<List<int>>();

            if (graph.VertexNumber > 0)
            {
                // Do DFS traversal on the graph
                var visited = new bool[graph.VertexNumber];
                var traversalStack = new Stack<int>();

                for (int vertexIndex = 0; vertexIndex < graph.VertexNumber; vertexIndex++)
                {
                    if (!visited[vertexIndex])
                    {
                        Visit(graph, vertexIndex, visited, traversalStack);
                    }
                }

                // Get the transpose graph
                var transposeGraph = graph.GetTransposeGraph();

                // Do traversal on the transpose graph
                visited = new bool[transposeGraph.VertexNumber];
                while (traversalStack.Count > 0)
                {
                    int vertexIndex = traversalStack.Pop();
                    if (!visited[vertexIndex])
                    {
                        var scc = new List<int>();
                        VisitSCC(transposeGraph, vertexIndex, visited, scc);
                        result.Add(scc);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Depth first traversal.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="vertexIndex"></param>
        /// <param name="visited"></param>
        /// <param name="traversalStack"></param>
        private static void Visit(IGraph graph, int vertexIndex, bool[] visited, Stack<int> traversalStack)
        {
            visited[vertexIndex] = true;

            IList<Tuple<int, int, int>> edges = graph.GetEdges(vertexIndex); // source, target, weight
            foreach(var edge in edges)
            {
                if (!visited[edge.Item2])
                {
                    Visit(graph, edge.Item2, visited, traversalStack);
                }
            }

            traversalStack.Push(vertexIndex);
        }

        private static void VisitSCC(IGraph graph, int vertexIndex, bool[] visited, List<int> scc)
        {
            visited[vertexIndex] = true;
            scc.Add(vertexIndex);

            IList<Tuple<int, int, int>> edges = graph.GetEdges(vertexIndex); // source, target, weight
            foreach (var edge in edges)
            {
                if (!visited[edge.Item2])
                {
                    VisitSCC(graph, edge.Item2, visited, scc);
                }
            }
        }
    }
}

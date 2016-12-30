using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmQuestions
{
    public static class MinimumSpanningTree
    {
        // http://www.geeksforgeeks.org/greedy-algorithms-set-2-kruskals-minimum-spanning-tree-mst/
        // Algorithm
        // 1. Sort all the edges in non-decreasing order of their weight.
        // 2. Pick the smallest edge. Check if it forms a cycle with the spanning tree formed so far.
        //    If cycle is not formed, include this edge.Else, discard it.  
        // 3. Repeat step#2 until there are (V-1) edges in the spanning tree.
        public static IGraph FindTree(IGraph graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            if (graph.VertexNumber == 0 || graph.IsDirected)
            {
                throw new ArgumentException();
            }

            // Sorting can be implemented using varius algorithm, e.g. heap sorting.
            var edges = graph.GetAllEdges();
            var edgeList = new List<Tuple<int, int, int>>();
            edgeList.AddRange(edges);
            edgeList.Sort((x, y) => x.Item3.CompareTo(y.Item3));

            var tree = new MatrixGraph(graph.VertexNumber, false);
            int edgeNumber = 0;
            foreach(var edge in edgeList)
            {
                if (edgeNumber == graph.VertexNumber - 1)
                {
                    break;
                }

                tree.AddEdge(edge.Item1, edge.Item2, edge.Item3);
                
                if (DetectCircle.Detect(tree))
                {
                    tree.RemoveEdge(edge.Item1, edge.Item2);
                }
                else
                {
                    edgeNumber++;
                }
            }

            // Not needed???
            if (edgeNumber != graph.VertexNumber - 1)
            {
                throw new Exception("The result is not a spanning tree.");
            }

            return tree;
        }
    }
}

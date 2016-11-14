using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class DetectCircle
    {
        // Assuming the graph is connected.
        public static bool Detect(IGraph graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            if (graph.VertexNumber == 0)
            {
                throw new ArgumentException();
            }

            if (graph.IsDirected)
            {
                return DetectCircleInDirected(graph);
            }
            else
            {
                return DetectCircleInUndirected(graph);
            }
        }

        // Algrithm:
        // 1. Put all vertices into separate set;
        // 2. Get all edges of the graph;
        // 3. Loop through edges, 
        // 3.1 For each edge, find which sets the two vertices belong to.
        // 3.2 If they belong to the same set already, a circle has been detected.
        // 3.3 If not, and union the sets.
        // 3.4 Continue to the next edge.
        // Time complexity: O(E*V)???
        private static bool DetectCircleInUndirected(IGraph graph)
        {
            var sets = new List<SinglyLinkedList<int>>();
            for (int i = 0; i < graph.VertexNumber; i++)
            {
                var set = new SinglyLinkedList<int>();
                set.First = new SinglyLinkedListNode<int>(i);
                sets.Add(set);
            }

            foreach (var edge in graph.GetAllEdges())
            {
                var set1 = FindSet(sets, edge.Item1);
                var set2 = FindSet(sets, edge.Item2);

                if (set1 == set2)
                {
                    return true;
                }
                else
                {
                    UnionSets(sets, set1, set2);
                }
            }

            return false;
        }

        private static SinglyLinkedList<int> FindSet(List<SinglyLinkedList<int>> sets, int value)
        {
            foreach(var set in sets)
            {
                if (set.ContainsValue(value))
                {
                    return set;
                }
            }

            return null;
        }

        private static void UnionSets(List<SinglyLinkedList<int>> sets, SinglyLinkedList<int> set1, SinglyLinkedList<int> set2)
        {
            set1.Last.Next = set2.First;
            sets.Remove(set2);
        }

        //Solution:
        //Depth First Traversal can be used to detect cycle in a Graph.
        //DFS for a connected graph produces a tree. There is a cycle in a graph only if there is a back edge present in the graph. 
        //A back edge is an edge that is from a node to itself (selfloop) or one of its ancestor in the tree produced by DFS.
        //
        //For a disconnected graph, we get the DFS forrest as output.To detect cycle, we can check for cycle in individual trees 
        //by checking back edges.
        //
        //To detect a back edge, we can keep track of vertices currently in recursion stack of function for DFS traversal. 
        //If we reach a vertex that is already in the recursion stack, then there is a cycle in the tree. 
        //The edge that connects current vertex to the vertex in the recursion stack is back edge. 
        //
        // Time complexity: O(E+V)???
        // Note: This implemention need improvement to support unconnected graph.
        private static bool DetectCircleInDirected(IGraph graph)
        {
            var hits = new bool[graph.VertexNumber];
            var stack = new Stack<int>();

            return FindCycle(graph, stack, hits, 0); ;
        }

        private static bool FindCycle(IGraph graph, Stack<int> stack, bool[] hits, int currentVertexIndex)
        {
            stack.Push(currentVertexIndex);
            hits[currentVertexIndex] = true;

            var edges = graph.GetEdges(currentVertexIndex);

            // Check back edge
            foreach (var edge in edges)
            {
                if (stack.Contains(edge.Item2))
                {
                    return true;
                }
            }

            // Find cycle recursively
            foreach (var edge in edges)
            {
                if (!hits[edge.Item2] && FindCycle(graph, stack, hits, edge.Item2))
                {
                    return true;
                }
            }

            stack.Pop();
            return false;
        }
    }
}

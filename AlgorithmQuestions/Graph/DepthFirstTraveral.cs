using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/depth-first-traversal-for-a-graph/
    /// </summary>
    public static class DepthFirstTraveral
    {
        /// <summary>
        /// Iterative version of implementation.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="startVertex"></param>
        public static void IterativeTraverse(LinkedListGraph graph, int startVertex)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            if (graph.VertexNumber == 0 || startVertex >= graph.VertexNumber)
            {
                throw new ArgumentException();
            }

            // TODO: Use a bit map
            var hits = new bool[graph.VertexNumber];
            var stack = new Stack<int>();
            stack.Push(startVertex);

            while (stack.Count > 0)
            {
                // Note, mark the vertex as hit when pop instead of when push; 
                var currentVertex = stack.Pop();
                if (!hits[currentVertex])
                {
                    Hit(hits, currentVertex);

                    var linkedList = graph.GetLinkedList(currentVertex);
                    var node = linkedList.First;
                    while (node != null)
                    {
                        stack.Push(node.Value);
                        node = node.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Recursive version of implementation.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="startVertex"></param>
        public static void RecursiveTraverse(LinkedListGraph graph, int startVertex)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            if (graph.VertexNumber == 0 || startVertex >= graph.VertexNumber)
            {
                throw new ArgumentException();
            }

            // TODO: Use a bit map
            var hits = new bool[graph.VertexNumber];
            RecurrsiveTraverse(graph, startVertex, hits);
        }

        private static void Hit(bool[] hits, int vertex)
        {
            hits[vertex] = true;
            Console.Write(vertex + " ");
        }

        private static void RecurrsiveTraverse(LinkedListGraph graph, int startVertex, bool[] hits)
        {
            if (hits[startVertex])
            {
                return;
            }

            Hit(hits, startVertex);

            var linkedList = graph.GetLinkedList(startVertex);
            var node = linkedList.First;

            while (node != null)
            {
                RecurrsiveTraverse(graph, node.Value, hits);
                node = node.Next;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace AlgorithmQuestions
{
    public static class BreadthFirstTraveral
    {
        /// <summary>
        /// Iterative version of implementation.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="startVertex"></param>
        public static void IterativeTraverse(IGraph graph, int startVertex)
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
            var queue = new Queue<int>();

            // Note, mark the vertex as hit when enqueue instead of when dequeue; 
            // otherwise, the same vertex may be added to the queue more than once.
            queue.Enqueue(startVertex);
            Hit(hits, startVertex);

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                var edges = graph.GetEdges(currentVertex);
                foreach (var edge in edges)
                {
                    if (!hits[edge.Item2])
                    {
                        queue.Enqueue(edge.Item2);
                        Hit(hits, edge.Item2);
                    }
                }
            }
        }

        /// <summary>
        /// Recursive version of implementation.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="startVertex"></param>
        public static void RecursiveTraverse(IGraph graph, int startVertex)
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
            Hit(hits, startVertex);
            RecurrsiveTraverse(graph, startVertex, hits);
        }

        public static void RecurrsiveTraverse(IGraph graph, int startVertex, bool[] hits)
        {
            var edges = graph.GetEdges(startVertex);
            var unhitChildren = new List<int>();
            foreach(var edge in edges)
            {
                if (!hits[edge.Item2])
                {
                    Hit(hits, edge.Item2);
                    unhitChildren.Add(edge.Item2);
                }
            }

            foreach(var child in unhitChildren)
            {
                RecurrsiveTraverse(graph, child, hits);
            }
        }

        private static void Hit(bool[] hits, int vertex)
        {
            hits[vertex] = true;
            Console.Write(vertex + " ");
        }
    }
}

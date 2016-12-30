using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/graph-and-its-representations/
    /// Graph with linked list representation.
    /// </summary>
    public class LinkedListGraph : IGraph
    {
        private const int NoEdgeValue = 0;
        private SinglyLinkedList<int>[] graph;
        private string[] vertexNames;

        public int VertexNumber { get; private set; }

        public int EdgeNumber { get; private set; }

        public bool IsDirected { get; private set; }

        public LinkedListGraph(int vertexNumber, bool isDirected)
        {
            if (vertexNumber <= 0)
            {
                throw new ArgumentException();
            }

            this.VertexNumber = vertexNumber;
            this.EdgeNumber = 0;
            this.IsDirected = isDirected;

            this.graph = new SinglyLinkedList<int>[VertexNumber];
            for(int i = 0; i < vertexNumber; i++)
            {
                this.graph[i] = new SinglyLinkedList<int>();
            }

            this.vertexNames = new string[vertexNumber];
        }

        public void SetVertexName(int vertexIndex, string name)
        {
            if (vertexIndex < 0 || vertexIndex >= this.VertexNumber)
            {
                throw new ArgumentException();
            }

            this.vertexNames[vertexIndex] = name;
        }

        public string GetVertexName(int vertexIndex, string name)
        {
            if (vertexIndex < 0 || vertexIndex >= this.VertexNumber)
            {
                throw new ArgumentException();
            }

            return this.vertexNames[vertexIndex];
        }

        public void AddEdge(int sourceVertexIndex, int targetVertexIndex)
        {
            this.AddEdge(sourceVertexIndex, targetVertexIndex, 1);
        }

        public void AddEdge(int sourceVertexIndex, int targetVertexIndex, int weight)
        {
            if (weight != 1)
            {
                throw new NotSupportedException();
            }

            if (sourceVertexIndex < 0 
                || sourceVertexIndex >= this.VertexNumber
                || targetVertexIndex < 0
                || targetVertexIndex >= this.VertexNumber)
            {
                throw new ArgumentException();
            }

            var linkedList = graph[sourceVertexIndex];
            if (!linkedList.ContainsValue(targetVertexIndex))
            {
                linkedList.InsertAtFirst(targetVertexIndex);
                this.EdgeNumber++;

                if (!IsDirected)
                {
                    var linkedList2 = graph[targetVertexIndex];
                    linkedList2.InsertAtFirst(sourceVertexIndex);
                }
            }
        }

        public void RemoveEdge(int sourceVertexIndex, int targetVertexIndex)
        {
            throw new NotImplementedException();
        }

        public IList<Tuple<int, int, int>> GetEdges(int vertexIndex)
        {
            throw new NotImplementedException();
        }

        public IList<Tuple<int, int, int>> GetAllEdges()
        {
            throw new NotImplementedException();
        }

        public SinglyLinkedList<int> GetLinkedList(int vertexIndex)
        {
            if (vertexIndex < 0
                || vertexIndex >= this.VertexNumber)
            {
                throw new ArgumentException();
            }

            return this.graph[vertexIndex];
        }

        public IGraph GetTransposeGraph()
        {
            throw new NotImplementedException();
        }

        public void PrintGraph()
        {
            Console.WriteLine(string.Format("The graph has {0} vertices.", this.VertexNumber));
            Console.WriteLine(string.Format("The graph has {0} edges.", this.EdgeNumber));

            for (int i = 0; i < graph.Length; i++)
            {
                var linkedList = graph[i];
                var line = new StringBuilder();
                line.Append(i);

                var node = linkedList.First;
                while(node != null)
                {
                    line.Append(" -> ");
                    line.Append(node.Value);
                    node = node.Next;
                }

                Console.WriteLine(line);
            }
        }
    }
}

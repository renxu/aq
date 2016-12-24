using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmQuestions
{
    /// <summary>
    /// Graph with matrix representation.
    /// </summary>
    public class MatrixGraph: IGraph
    {
        private const int NoEdgeValue = 0;
        private int[][] maxtrix;
        private string[] vertexNames;

        public int VertexNumber { get; private set; }

        public int EdgeNumber { get; private set; }

        public bool IsDirected { get; private set; }

        public MatrixGraph(int vertexNumber, bool isDirected)
        {
            if (vertexNumber <= 0)
            {
                throw new ArgumentException();
            }

            this.VertexNumber = vertexNumber;
            this.EdgeNumber = 0;
            this.IsDirected = isDirected;

            this.maxtrix = new int[vertexNumber][];
            for(int i = 0; i < vertexNumber; i++)
            {
                this.maxtrix[i] = new int[vertexNumber];
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
            if (sourceVertexIndex < 0 
                || sourceVertexIndex >= this.VertexNumber
                || targetVertexIndex < 0
                || targetVertexIndex >= this.VertexNumber
                || weight == 0)
            {
                throw new ArgumentException();
            }

            if (maxtrix[sourceVertexIndex][targetVertexIndex] == NoEdgeValue)
            {
                // Does not handle multi-thread
                this.EdgeNumber++;
            }

            maxtrix[sourceVertexIndex][targetVertexIndex] = weight;
            if (!IsDirected)
            {
                maxtrix[targetVertexIndex][sourceVertexIndex] = weight;
            }
        }

        public void RemoveEdge(int sourceVertexIndex, int targetVertexIndex)
        {
            if (sourceVertexIndex < 0
                || sourceVertexIndex >= this.VertexNumber
                || targetVertexIndex < 0
                || targetVertexIndex >= this.VertexNumber)
            {
                throw new ArgumentException();
            }

            if (maxtrix[sourceVertexIndex][targetVertexIndex] != NoEdgeValue)
            {
                // Does not handle multi-thread
                this.EdgeNumber--;
            }

            maxtrix[sourceVertexIndex][targetVertexIndex] = NoEdgeValue;
            if (!IsDirected)
            {
                maxtrix[targetVertexIndex][sourceVertexIndex] = NoEdgeValue;
            }
        }

        public IList<Tuple<int, int, int>> GetEdges(int vertexIndex)
        {
            if (vertexIndex < 0
                || vertexIndex >= this.VertexNumber)
            {
                throw new ArgumentException();
            }

            var edges = new List<Tuple<int, int, int>>();
            for (int i = 0; i < this.VertexNumber; i++)
            {
                if (this.maxtrix[vertexIndex][i] != NoEdgeValue)
                {
                    edges.Add(new Tuple<int, int, int>(vertexIndex, i, this.maxtrix[vertexIndex][i]));
                }
            }
            return edges;
        }

        public IList<Tuple<int, int, int>> GetAllEdges()
        {
            var edges = new List<Tuple<int, int, int>>();
            for (int i = 0; i < this.VertexNumber; i++)
            {
                for (int j = i; j < this.VertexNumber; j++)
                {
                    if (this.maxtrix[i][j] != NoEdgeValue)
                    {
                        edges.Add(new Tuple<int, int, int>(i, j, this.maxtrix[i][j]));
                    }
                }
            }

            return edges;
        }

        #region Topological sort
        /// <summary>
        /// Algorithm: In DFS, we start from a vertex, we first print it and then recursively call DFS for its adjacent vertices. 
        /// In topological sorting, we use a temporary stack. We don’t print the vertex immediately, we first recursively call 
        /// topological sorting for all its adjacent vertices, then push it to a stack. Finally, print contents of stack. 
        /// Note that a vertex is pushed to stack only when all of its adjacent vertices (and their adjacent vertices and so on) 
        /// are already in stack.
        /// </summary>
        /// <returns></returns>

        public int[] TopoloicalSort()
        {
            if (!this.IsDirected)
            {
                throw new ArgumentException();
            }

            bool[] visited = new bool[this.VertexNumber];
            var stack = new Stack<int>();
            for (int vertexIndex = 0; vertexIndex < this.VertexNumber; vertexIndex++)
            {
                if (!visited[vertexIndex])
                {
                    this.Visit(vertexIndex, visited, stack);
                }
            }

            int[] result = new int[this.VertexNumber];
            for (int i = 0; i < this.VertexNumber; i++)
            {
                result[i] = stack.Pop();
            }

            return result;
        }

        private bool Visit(int vertexIndex, bool[] visited, Stack<int> stack)
        {
            visited[vertexIndex] = true;

            foreach(var edge in this.GetEdges(vertexIndex))
            {
                if (!visited[edge.Item2])
                {
                    this.Visit(edge.Item2, visited, stack);
                }
            }

            stack.Push(vertexIndex);

            return true;
        }

        #endregion

        public void PrintGraph()
        {
            Console.WriteLine(string.Format("The graph has {0} vertices.", this.VertexNumber));
            Console.WriteLine(string.Format("The graph has {0} edges.", this.EdgeNumber));

            // Print header
            var header = new StringBuilder();
            header.Append(" ");
            for (int i = 0; i < this.VertexNumber; i++)
            {
                header.Append('\t');
                header.Append(i);
            }

            Console.WriteLine(header.ToString());

            // Print the rest
            for (int i = 0; i < this.VertexNumber; i++)
            {
                var line = new StringBuilder();
                line.Append(i);
                for (int j = 0; j < this.VertexNumber; j++)
                {
                    line.Append('\t');
                    line.Append(maxtrix[i][j]);
                }

                Console.WriteLine(line.ToString());
            }
        }
    }
}

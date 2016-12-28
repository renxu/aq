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
        /// 
        /// The algorithm is greedy. We start from the source vertice and span out, similarly to spanning tree. Each time, 
        /// among the remaining nodes, we span to a node which has the shortest distance to the source node.
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

        #region Dijkstra's shortest path
        public int[] DijkstrasShortestPath(int sourceVertextIndex, int targetVertextIndex)
        {
            var distances = new List<GraphEdge>(); // Weight is the distance to the source node.
            for (int i = 0; i < this.VertexNumber; i++)
            {
                if (i == sourceVertextIndex)
                {
                    distances.Add(new GraphEdge(-1, i, 0));
                }
                else
                {
                    distances.Add(new GraphEdge(-1, i, int.MaxValue));
                }
            }

            var visited = new bool[this.VertexNumber];
            var edgeStack = new Stack<GraphEdge>(); 
            while(edgeStack.Count < this.VertexNumber)
            {
                // Include the smallest edge
                GraphEdge minDistance = null;
                foreach (var distance in distances)
                {
                    if (!visited[distance.TargetVertexIndex])
                    {
                        if (minDistance == null)
                        {
                            minDistance = distance;
                        }
                        else if (distance.Weight < minDistance.Weight)
                        {
                            minDistance = distance;
                        }
                    }
                }

                edgeStack.Push(minDistance);
                visited[minDistance.TargetVertexIndex] = true;

                if (minDistance.TargetVertexIndex == targetVertextIndex)
                {
                    break;
                }

                // Update distances
                for (int vertexIndex = 0; vertexIndex < this.VertexNumber; vertexIndex++)
                {
                    if (!visited[vertexIndex])
                    {
                        foreach(var edge in this.GetEdges(vertexIndex))
                        {
                            if (visited[edge.Item2] && distances[edge.Item2].Weight + edge.Item3 < distances[vertexIndex].Weight) // hard part
                            {
                                distances[vertexIndex].Weight = distances[edge.Item2].Weight + edge.Item3;
                                distances[vertexIndex].SourceVertexIndex = edge.Item2;
                            }
                        }
                    }
                }
            }

            // Find result path
            var pathStack = new Stack<int>();
            int targetIndex = targetVertextIndex;
            while(edgeStack.Count > 0)
            {
                GraphEdge edge = edgeStack.Pop();
                if (edge.TargetVertexIndex == targetIndex)
                {
                    pathStack.Push(targetIndex);
                    targetIndex = edge.SourceVertexIndex;
                }
            }

            var result = new int[pathStack.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = pathStack.Pop();
            }

            return result;
        }
        #endregion

        #region Longest path in DAG
        public int GetLongestPath(int sourceVertexindex, int targetVertextIndex)
        {
            if(!this.IsDirected)
            {
                throw new ArgumentException();
            }

            if (sourceVertexindex >= this.VertexNumber 
                || targetVertextIndex >= this.VertexNumber 
                || sourceVertexindex < 0
                || targetVertextIndex < 0
                || sourceVertexindex == targetVertextIndex)
            {
                throw new ArgumentException();
            }

            int[] topologicalSort = this.TopoloicalSort();
            int[] longestPaths = new int[this.VertexNumber];
            for (int i = 0; i < longestPaths.Length; i++)
            {
                if (topologicalSort[i] == sourceVertexindex)
                {
                    longestPaths[i] = 0;
                }
                else
                {
                    longestPaths[i] = int.MinValue;
                }
                
            }

            bool meetSource = false;
            for (int i = 0; i < longestPaths.Length; i++)
            {
                // Do no path cost calculation for vertices before the source vertex.
                if (topologicalSort[i] == sourceVertexindex)
                {
                    meetSource = true;
                }

                if (meetSource)
                {
                    if(topologicalSort[i] != targetVertextIndex)
                    {
                        var edges = this.GetEdges(topologicalSort[i]);
                        foreach(var edge in edges)
                        {
                            int edgeTargetSortIndex = FindInArray(topologicalSort, edge.Item2);
                            longestPaths[edgeTargetSortIndex] = Math.Max(longestPaths[edgeTargetSortIndex], longestPaths[i] + edge.Item3);
                        }
                    }
                    else
                    {
                        return longestPaths[i];
                    }
                }
                else if (topologicalSort[i] == targetVertextIndex)
                {
                    // The target vertext comes before the source vertex.
                    // There is no path from source to target.
                    break;
                }
            }

            return int.MinValue;
        }

        private static int FindInArray(int[] values, int value)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    return i;
                }
            }

            throw new ArgumentException("Not found"); 
        }

        #endregion

        /// <summary>
        /// This implementation simply transpose itself instead of creating a new graph.
        /// </summary>
        /// <returns></returns>
        public IGraph GetTransposeGraph()
        {
            for (int i = 0; i < this.VertexNumber; i++)
            {
                for (int j = i + 1; j < this.VertexNumber; j++)
                {
                    int temp = this.maxtrix[i][j];
                    this.maxtrix[i][j] = this.maxtrix[j][i];
                    this.maxtrix[j][i] = temp;
                }
            }

            return this;
        }

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

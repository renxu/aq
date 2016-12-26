using System;
using System.Collections.Generic;

namespace AlgorithmQuestions
{
    public interface IGraph
    {
        int VertexNumber { get; }

        int EdgeNumber { get; }

        bool IsDirected { get; }

        void SetVertexName(int vertexIndex, string name);

        string GetVertexName(int vertexIndex, string name);

        void AddEdge(int sourceVertexIndex, int targetVertexIndex);

        void AddEdge(int sourceVertexIndex, int targetVertexIndex, int weight);

        void RemoveEdge(int sourceVertexIndex, int targetVertexIndex);

        IList<Tuple<int, int, int>> GetEdges(int vertexIndex);

        IList<Tuple<int, int, int>> GetAllEdges();

        IGraph GetTransposeGraph();

        void PrintGraph();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class GraphEdge
    {
        public GraphEdge(int sourceVertexIndex, int targetVertexIndex, int weight)
        {
            this.SourceVertexIndex = sourceVertexIndex;
            this.TargetVertexIndex = targetVertexIndex;
            this.Weight = weight;
        }

        public int SourceVertexIndex { get; set; }

        public int TargetVertexIndex { get; set; }

        public int Weight { get; set; }
    }
}

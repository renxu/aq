using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmQuestions
{
    public class MaxHeap<T> : HeapBasic<T> where T : IComparable
    {
        public MaxHeap(IEnumerable<T> values) : base(values)
        {
        }

        protected override int Compare(int index1, int index2)
        {
            return data[index1].CompareTo(data[index2]);
        }
    }
}

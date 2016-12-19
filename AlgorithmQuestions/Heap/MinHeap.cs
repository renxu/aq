using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmQuestions
{
    public class MinHeap<T>: HeapBasic<T> where T: IComparable
    {
        public MinHeap(IEnumerable<T> values): base(values)
        {
        }

        protected override int Compare(int index1, int index2)
        {
            int comparision = data[index1].CompareTo(data[index2]);
            if (comparision > 0)
            {
                return -1;
            }
            else if (comparision < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

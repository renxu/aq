using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// Problem: Given an array of n elements, where each element is at most k away from its target position, 
    /// devise an algorithm that sorts in O(n log k) time. 
    /// For example, let us consider k is 2, an element at index 7 in the sorted array, can be at indexes 5, 6, 7, 8, 9 in the given array.
    /// 
    /// Algorithm:
    /// 1) Create a Min Heap of size k+1 with first k+1 elements. This will take O(k) time.
    /// 2) One by one remove min element from heap, put it in result array, and add a new element to heap from remaining elements.
    /// </summary>
    public static class AlmostSorted
    {
        public static int[] Sort(int[] input, int k)
        {
            CommonUtility.ThrowIfNull(input);
            if (k <= 0 || k >= input.Length)
            {
                throw new ArgumentException();
            }

            // 1) time complexity = O(k)
            int[] heapInput = new int[k + 1];
            for(int i = 0; i <= k; i++)
            {
                heapInput[i] = input[i];
            }
            MinHeap<int> heap = new MinHeap<int>(heapInput);

            // 2) time complexity = O((n-k)*logk)
            int[] result = new int[input.Length];
            for(int i = 0; i < input.Length; i++)
            {
                result[i] = heap.Extract();

                int insertIndex = k + 1 + i;
                if (insertIndex < input.Length)
                {
                    heap.Insert(input[insertIndex]);
                }
            }

            return result;
        }
    }
}

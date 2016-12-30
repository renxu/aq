using System;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://geeksquiz.com/heap-sort/
    /// </summary>
    public static class HeapSort
    {
        //Since a Binary Heap is a Complete Binary Tree, it can be easily represented as array and array based representation is space efficient.
        //If the parent node is stored at index I, the left child can be calculated by 2 * I + 1 and right child by 2 * I + 2 
        //(assuming the indexing starts at 0).
        //
        //Heap Sort Algorithm for sorting in increasing order:
        //1. Build a max heap from the input data.
        //1.1 Add elements to heap one by one.
        //1.2 Swap with parent if needed.
        //2. At this point, the largest item is stored at the root of the heap. Replace it with the last item of the heap.
        //3. Reduce the size of heap by 1. 
        //4. Heapify the root of tree.
        //5. Repeat above step 2-5 until size of heap is greater than 1.

        // See a more concise solution: http://quiz.geeksforgeeks.org/heap-sort/ -> Java

        /// <summary>
        /// Time complexity: O(nlogn).
        /// Additional space complexity: O(1).
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int[] Sort(int[] inputs)
        {
            if (inputs == null || inputs.Length <= 1)
            {
                return inputs;
            }

            // Build a max heap in place
            // Time complexity = O(nlogn)
            var maxHeap = new MaxHeap<int>(inputs);

            // Extract the root of the max heap, put it to the end of the array, and repeat.
            for(int i = inputs.Length - 1; i >= 0; i--)
            {
                inputs[i] = maxHeap.Extract();
            }

            return inputs;
        }
    }
}

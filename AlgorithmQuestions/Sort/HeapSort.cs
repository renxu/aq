using System;

namespace AlgorithmQuestions
{
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
            BuildMaxHeap(inputs);

            // Loop (i is the number of max number that are found so far)

            // Time complexity = O(nlogn)
            for (int i = 0; i < inputs.Length - 1; i++)
            {
                // Swap first and last
                CommonUtility.Swap(inputs, 0, inputs.Length - 1 - i);

                // Reduce heap by one, heapify the root
                // Time complexity = O(logn)
                SinkNode(inputs, 0, inputs.Length - 2 - i);
            }

            return inputs;
        }

        private static void BuildMaxHeap(int[] inputs)
        {
            
            for (int i = 1; i < inputs.Length; i++)
            {
                RiseNode(inputs, i);
            }
        }

        // Time complexity = O(logn)
        private static void RiseNode(int[] inputs, int index)
        {
            if (index <= 0)
            {
                return;
            }

            int parentIndex = GetParentIndex(index);
            if (inputs[index] > inputs[parentIndex])
            {
                CommonUtility.Swap(inputs, index, parentIndex);
                RiseNode(inputs, parentIndex);
            }
        }

        private static void SinkNode(int[] inputs, int index, int lastIndex)
        {
            if (index >= lastIndex)
            {
                return;
            }

            // Get left child
            int leftChildIndex = GetLeftChildIndex(index, lastIndex);

            // Get right child
            int rightChildIndex = GetRightChildIndex(index, lastIndex);

            // Find the largest of the three
            int largestIndex = index;

            if(leftChildIndex != -1)
            {
                if (inputs[leftChildIndex] > inputs[largestIndex])
                {
                    largestIndex = leftChildIndex;
                }
            }

            if (rightChildIndex != -1)
            {
                if (inputs[rightChildIndex] > inputs[largestIndex])
                {
                    largestIndex = rightChildIndex;
                }
            }

            // Swap if needed and keep sinking
            if (largestIndex != index)
            {
                CommonUtility.Swap(inputs, index, largestIndex);
                SinkNode(inputs, largestIndex, lastIndex);
            }
        }

        private static int GetParentIndex(int childIndex)
        {
            if (childIndex <= 0)
            {
                throw new ArgumentException("childIndex is invalid.");
            }

            return (childIndex - 1) / 2;
        }

        private static int GetLeftChildIndex(int parentIndex, int lastIndex)
        {
            int leftChildIndex = parentIndex * 2 + 1;
            if (leftChildIndex <= lastIndex)
            {
                return leftChildIndex;
            }
            else
            {
                return -1;
            }
        }

        private static int GetRightChildIndex(int parentIndex, int lastIndex)
        {
            int rightChildIndex = parentIndex * 2 + 2;
            if (rightChildIndex <= lastIndex)
            {
                return rightChildIndex;
            }
            else
            {
                return -1;
            }
        }
    }
}

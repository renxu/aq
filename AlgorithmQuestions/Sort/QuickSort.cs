using System;

namespace AlgorithmQuestions
{
    public static class QuickSort
    {
        //Quicksort is a divide and conquer algorithm.Quicksort first divides a large array into two smaller sub-arrays: 
        //the low elements and the high elements.Quicksort can then recursively sort the sub-arrays.
        //
        //The steps are:
        //1. Pick an element, called a pivot, from the array.
        //2. Partitioning: reorder the array so that all elements with values less than the pivot come before the pivot, 
        //   while all elements with values greater than the pivot come after it(equal values can go either way). 
        //   After this partitioning, the pivot is in its final position.This is called the partition operation.
        //3. Recursively apply the above steps to the sub-array of elements with smaller values and separately to the sub-array of elements 
        //   with greater values.
        //
        //The base case of the recursion is arrays of size zero or one, which never need to be sorted.
        //The pivot selection and partitioning steps can be done in several different ways; the choice of specific implementation schemes 
        //greatly affects the algorithm's performance.

        /// <summary>
        /// Time complexity: O(n^2)
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

            Partition(inputs, 0, inputs.Length - 1);
            return inputs;
        }

        private static void Partition(int[] inputs, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivotValue = inputs[endIndex];
            int largerSideStartIndex = -1;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (inputs[i] <= pivotValue)
                {
                    if (largerSideStartIndex != -1)
                    {
                        CommonUtility.Swap(inputs, largerSideStartIndex, i);
                        largerSideStartIndex++;
                    }
                }
                else
                {
                    if (largerSideStartIndex == -1)
                    {
                        largerSideStartIndex = i;
                    }
                }
            }

            if (largerSideStartIndex != -1)
            {
                CommonUtility.Swap(inputs, largerSideStartIndex, endIndex);
            }

            if (largerSideStartIndex == -1)
            {
                Partition(inputs, startIndex, endIndex - 1);
            }
            else if (largerSideStartIndex == startIndex)
            {
                Partition(inputs, startIndex + 1, endIndex);
            }
            else
            {
                Partition(inputs, startIndex, largerSideStartIndex - 1);
                Partition(inputs, largerSideStartIndex + 1, endIndex);
            }
        }
    }
}

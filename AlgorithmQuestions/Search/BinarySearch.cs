using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://quiz.geeksforgeeks.org/binary-search/
    /// </summary>
    public static class BinarySearch
    {
        private const int NotFound = -1;

        //Given a sorted array arr[] of n elements, write a function to search a given element x in arr[].
        //Binary Search: Search a sorted array by repeatedly dividing the search interval in half.Begin with an interval covering the whole array. 
        //If the value of the search key is less than the item in the middle of the interval, narrow the interval to the lower half.
        //Otherwise narrow it to the upper half.Repeatedly check until the value is found or the interval is empty.
        //We basically ignore half of the elements just after one comparison.
        //- Compare x with the middle element.
        //- If x matches with middle element, we return the mid index.
        //- Else If x is greater than the mid element, then x can only lie in right half subarray after the mid element.So we recur for right half.
        //- Else (x is smaller) recur for the left half.

        /// <summary>
        /// Time complexity: O(logn)
        /// Additional space complexity: O(1)
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchWithoutRecursion(int[] inputs, int target)
        {
            if (inputs == null || !inputs.Any())
            {
                return NotFound;
            }

            int lower = 0;
            int upper = inputs.Length - 1;
            while (lower <= upper)
            {
                int middle = GetMiddle(lower, upper);
                if (inputs[middle] == target)
                {
                    return middle;
                }
                else if (inputs[middle] > target)
                {
                    // Note: minus 1 here to avoid infinite loop in the case that no match is in the array.
                    upper = middle - 1;
                }
                else
                {
                    // Note: plus 1 here to avoid infinite loop in the case that no match is in the array.
                    lower = middle + 1;
                }
            }

            return NotFound;
        }

        /// <summary>
        /// Time complexity: O(logn)
        /// Additional space complexity: O(1)
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchWithRecursion(int[] inputs, int target)
        {
            if (inputs == null || !inputs.Any())
            {
                return NotFound;
            }

            return SearchWithRecursion(inputs, 0, inputs.Length - 1, target);
        }

        private static int SearchWithRecursion(int[] inputs, int lower, int upper, int target)
        {
            if (lower > upper)
            {
                return NotFound;
            }

            int middle = GetMiddle(lower, upper);

            if (inputs[middle] == target)
            {
                return middle;
            }
            else if (inputs[middle] > target)
            {
                return SearchWithRecursion(inputs, lower, middle - 1, target);
            }
            else
            {
                return SearchWithRecursion(inputs, middle + 1, upper, target);
            }
        }

        private static int GetMiddle(int lower, int upper)
        {
            return (lower + upper) / 2;
        }
    }
}

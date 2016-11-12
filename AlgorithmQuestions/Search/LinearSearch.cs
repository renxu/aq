using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class LinearSearch
    {
        //Problem: Given an array arr[] of n elements, write a function to search a given element x in arr[].
        //A simple approach is to do linear search, i.e
        //- Start from the leftmost element of arr[] and one by one compare x with each element of arr[]
        //- If x matches with an element, return the index. (return the first match)
        //- If x doesn’t match with any of elements, return -1.
        // Refer to http://quiz.geeksforgeeks.org/linear-search/

        /// <summary>
        /// Looks for target number in the input array.
        /// Time complexity: O(n)
        /// Additional space complexity: O(1)
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] inputs, int target)
        {
            int notFound = -1;
            if (inputs == null || !inputs.Any())
            {
                return notFound;
            }

            for(int i = 0; i < inputs.Length;  i++)
            {
                if (inputs[i] == target)
                {
                    return i;
                }
            }

            return notFound;
        }
    }
}

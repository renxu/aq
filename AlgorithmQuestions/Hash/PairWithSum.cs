using System.Collections.Generic;

namespace AlgorithmQuestions
{
    public static class PairWithSum
    {
        /// <summary>
        /// Problem: Write a C program that, given an array A[] of n numbers and another number x, 
        /// determines whether or not there exist two elements in S whose sum is exactly x. 
        /// 
        /// Algorithm: 1) Initialize Binary Hash Map M[] = {0, 0, ...}
        /// 2) Do following for each element A[i] in A[]
        /// (a)	If M[x - A[i]] is set then print the pair(A[i], x - A[i])
        /// (b)	Set M[A[i]]
        /// 
        /// Time complexity: O(n)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static bool Check(int[] input, int sum)
        {
            CommonUtility.ThrowIfNull(input);

            var set = new HashSet<int>();
            foreach(int value in input)
            {
                if (set.Contains(sum - value))
                {
                    return true;
                }
                else
                {
                    set.Add(value);
                }
            }

            return false;
        }
    }
}

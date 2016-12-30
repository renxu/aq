using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/dynamic-programming-set-3-longest-increasing-subsequence/
    /// Examples: 
    /// LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3.
    /// LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4.
    /// </summary>
    public static class LongestCommonSubsequence
    {
        /// <summary>
        /// Time Complexity O(n*m).
        /// Additinal space complexity O(n*m).
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public static int FindByBottomUp(string input1, string input2)
        {
            if (input1 == null)
            {
                throw new ArgumentNullException("input1");
            }

            if (input2 == null)
            {
                throw new ArgumentNullException("input2");
            }

            if (input1.Length == 0 || input2.Length == 0)
            {
                return 0;
            }

            var lookup = new int[input1.Length + 1, input2.Length + 1];
            for (int i = 0; i <= input1.Length; i++)
            {
                for (int j = 0; j <= input2.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        lookup[i, j] = 0;
                    }
                    else if (input1[i - 1] == input2[j - 1])
                    {
                        lookup[i, j] = lookup[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lookup[i, j] = Math.Max(lookup[i, j - 1], lookup[i - 1, j]); // key of the algorithm
                    }
                }
            }

            return lookup[input1.Length, input2.Length];
        }

        /// <summary>
        /// Time Complexity O(n*m).
        /// Additinal space complexity O(n*m).
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public static int FindByTopDown(string input1, string input2)
        {
            if (input1 == null)
            {
                throw new ArgumentNullException("input1");
            }

            if (input2 == null)
            {
                throw new ArgumentNullException("input2");
            }

            if (input1.Length == 0 || input2.Length == 0)
            {
                return 0;
            }

            var lookup = new int[input1.Length, input2.Length];
            for (int i = 0; i < input1.Length; i++)
            {
                for (int j = 0; j < input2.Length; j++)
                {
                    lookup[i, j] = -1;
                }
            }

            return FindByTopDown(input1, 0, input2, 0, lookup);
        }

        public static int FindByTopDown(string input1, int startIndex1, string input2, int startIndex2, int[,] lookup)
        {
            if (startIndex1 >= input1.Length || startIndex2 >= input2.Length)
            {
                return 0;
            }

            if (lookup[startIndex1, startIndex2] >= 0)
            {
                return lookup[startIndex1, startIndex2];
            }

            int max = 0;
            if (input1[startIndex1] == input2[startIndex2])
            {
                max = 1 + FindByTopDown(input1, startIndex1 + 1, input2, startIndex2 + 1, lookup);
            }
            else
            {
                max = Math.Max(FindByTopDown(input1, startIndex1, input2, startIndex2 + 1, lookup), FindByTopDown(input1, startIndex1 + 1, input2, startIndex2, lookup));
            }

            lookup[startIndex1, startIndex2] = max;
            return max;
        }
    }
}

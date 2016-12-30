using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class LongestIncreasingSubsequence
    {
        /// <summary>
        /// http://www.geeksforgeeks.org/dynamic-programming-set-3-longest-increasing-subsequence/
        /// Algorithm:
        /// 1. Loop through all elements, find the longest increasing subsequence for each element. 
        ///    Use a lookup array to store the subsequences.
        /// 1.1 For each element, add itself to the subsequence first.
        /// 1.2 Find the next increasing element, find the longest subsequence for that element, 
        ///     and append the subsequence to the current element.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] Find(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (input.Length <= 1)
            {
                return input;
            }

            var lookup = new LinkedList<int>[input.Length];
            return Find(input, 0, lookup).ToArray();
        }

        private static LinkedList<int> Find(int[] input, int startIndex, LinkedList<int>[] lookup)
        {
            int maxSequenceLength = -1;
            int maxSequenceIndex = -1;
            for (int i = startIndex; i < input.Length; i++)
            {
                if (lookup[i] == null)
                {
                    lookup[i] = new LinkedList<int>();
                    lookup[i].AddLast(input[i]);

                    int next = FindNextIncreasingNumberIndex(input, i);
                    if (next != -1)
                    {
                        if (lookup[next] == null)
                        {
                            Find(input, next, lookup);
                        }

                        foreach(var value in lookup[next])
                        {
                            lookup[i].AddLast(value);
                        }
                    }
                }

                if (lookup[i].Count > maxSequenceLength)
                {
                    maxSequenceLength = lookup[i].Count;
                    maxSequenceIndex = i;
                }
            }

            return lookup[maxSequenceIndex];
        }

        private static int FindNextIncreasingNumberIndex(int[] input, int startIndex)
        {
            if (startIndex + 1 >= input.Length)
            {
                return -1;
            }

            for (int i = startIndex + 1; i < input.Length; i++)
            {
                if (input[startIndex] < input[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}

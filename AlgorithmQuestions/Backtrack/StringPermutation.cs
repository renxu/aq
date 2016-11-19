using System;
using System.Collections.Generic;

namespace AlgorithmQuestions
{
    public static class StringPermutation
    {
        public static IList<string> FindPermutation(string input)
        {
            CommonUtility.ThrowIfNull(input);

            var permutations = new List<string>();
            if (input.Length == 0)
            {
                return permutations;
            }

            FindPermutation(input, 0, permutations);

            return permutations;
        }

        private static void FindPermutation(string input, int currentIndex, List<string> permutations)
        {
            if (currentIndex >= input.Length)
            {
                permutations.Add(input);
                return;
            }

            for (int i = currentIndex; i < input.Length; i++)
            {
                string variant = Swap(input, currentIndex, i);
                FindPermutation(variant, currentIndex + 1, permutations);
            }
        }

        private static string Swap(string text, int index1, int index2)
        {
            if (index1 == index2)
            {
                return text;
            }
            else
            {
                return text.Substring(0, index1) + text[index2] + text.Substring(index1 + 1, index2 - index1 - 1) + text[index1] + text.Substring(index2 + 1);
            }
        }
    }
}

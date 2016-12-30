using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/searching-for-patterns-set-2-kmp-algorithm/
    /// Time: O(n) n is text length
    /// Space: O(m) m is pattern lenght
    /// </summary>
    public class KmpSearch
    {
        public static IList<int> Search(string text, string pattern)
        {
            CommonUtility.ThrowIfNull(text);
            CommonUtility.ThrowIfNull(pattern);
            if (pattern.Length == 0)
            {
                throw new ArgumentException();
            }

            var matches = new List<int>();
            if (pattern.Length > text.Length)
            {
                return matches;
            }

            int[] lps = FindLps(pattern);

            int j = 0;
            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                while (j < pattern.Length)
                {
                    if (text[i + j] != pattern[j])
                    {
                        break;
                    }

                    j++;
                }

                if (j == pattern.Length)
                {
                    matches.Add(i);
                    j--;
                }

                j = lps[j];
            }

            return matches;
        }


        /// <summary>
        /// Finds the array, array[i] is the longest proper prefix which is also suffix for pattern[0..i].
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static int[] FindLps(string pattern)
        {
            int[] lps = new int[pattern.Length];
            for (int i = 0; i < pattern.Length; i++)
            {
                lps[i] = CalculateLps(pattern.Substring(0, i + 1));
            }

            return lps;
        }

        private static int CalculateLps(string pattern)
        {
            for (int length = pattern.Length - 1; length > 0; length--)
            {
                if (pattern.Substring(0, length) == pattern.Substring(pattern.Length - length))
                {
                    return length;
                }
            }

            return 0;
        }
    }
}

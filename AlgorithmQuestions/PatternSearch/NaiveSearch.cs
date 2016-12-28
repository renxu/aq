using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class NaiveSearch
    {
        /// <summary>
        /// Time: O(m*(n-m+1))
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static IList<int> Search(string text, string pattern)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            if (pattern.Length == 0)
            {
                throw new ArgumentException();
            }

            var matches = new List<int>();
            if (pattern.Length > text.Length)
            {
                return matches;
            }

            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (IsMatch(text, i, pattern))
                {
                    matches.Add(i);
                }
            }

            return matches;
        }

        private static bool IsMatch(string text, int textStartIndex, string pattern)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (text[textStartIndex + i] != pattern[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

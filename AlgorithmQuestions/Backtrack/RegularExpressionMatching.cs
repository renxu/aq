using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class RegularExpressionMatching
    {
        /*
        '.' Matches any single character.
        '*' Matches zero or more of the preceding element.

        The matching should cover the entire input string (not partial).

        The function prototype should be:
        bool isMatch(const char *s, const char *p)

        Some examples:
        isMatch("aa","a") → false
        isMatch("aa","aa") → true
        isMatch("aaa","aa") → false
        isMatch("aa", "a*") → true
        isMatch("aa", ".*") → true
        isMatch("ab", ".*") → true
        isMatch("aab", "c*a*b") → true
        */
        public bool IsMatch(string s, string p)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            if (p == null)
            {
                throw new ArgumentNullException("p");
            }

            if (s.Length == 0 && p.Length == 0)
            {
                return true;
            }
            else if (s.Length != 0 && p.Length == 0)
            {
                return false;
            }

            return IsMatch(s, 0, p, 0);
        }

        private bool IsMatch(string input, int inputIndex, string pattern, int patternIndex)
        {
            if (inputIndex >= input.Length && patternIndex >= pattern.Length)
            {
                return true;
            }
            else if (patternIndex >= pattern.Length)
            {
                return false;
            }
            else if (inputIndex >= input.Length)
            {
                while (patternIndex < pattern.Length)
                {
                    if (pattern[patternIndex] == '*')
                    {
                        throw new ArgumentException("Invalid pattern");
                    }
                    
                    if (patternIndex + 1 < pattern.Length && pattern[patternIndex + 1] == '*')
                    {
                        patternIndex = patternIndex + 2;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }


            if (pattern[patternIndex] == '*')
            {
                throw new ArgumentException("Invalid pattern");
            }

            if (pattern[patternIndex] != '.')
            {
                if (patternIndex + 1 >= pattern.Length || pattern[patternIndex + 1] != '*')
                {
                    // Single char case
                    if (input[inputIndex] == pattern[patternIndex])
                    {
                        return IsMatch(input, inputIndex + 1, pattern, patternIndex + 1);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    // char* case
                    if (input[inputIndex] == pattern[patternIndex])
                    {
                        return IsMatch(input, inputIndex + 1, pattern, patternIndex) || IsMatch(input, inputIndex, pattern, patternIndex + 2);
                    }
                    else
                    {
                        return IsMatch(input, inputIndex, pattern, patternIndex + 2);
                    }
                }
            }
            else
            {
                if (patternIndex + 1 >= pattern.Length || pattern[patternIndex + 1] != '*')
                {
                    // Single . case
                    return IsMatch(input, inputIndex + 1, pattern, patternIndex + 1);
                }
                else
                {
                    // .* case
                    return IsMatch(input, inputIndex + 1, pattern, patternIndex) || IsMatch(input, inputIndex, pattern, patternIndex + 2);
                }
            }
        }
    }
}

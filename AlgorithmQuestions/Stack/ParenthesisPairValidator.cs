using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// Given an expression string exp, write a program to examine whether the pairs and the orders of “{“,”}”,”(“,”)”,”[“,”]” 
    /// are correct in exp. For example, the program should print true for exp = “[()]{}{[()()]()}” and false for exp = “[(])”
    /// </summary>
    public class ParenthesisPairValidator
    {
        private static List<char> parenthesises = new List<char>(new char[] { '(', ')', '[', ']', '{', '}' });

        public static bool IsParenthesisBalanced(string expression)
        {
            CommonUtility.ThrowIfNull(expression);

            var parenthesisStack = new Stack<char>();
            foreach(char c in expression)
            {
                if (parenthesises.Contains(c))
                {
                    int index = parenthesises.IndexOf(c);
                    if (index % 2 == 0)
                    {
                        parenthesisStack.Push(c);
                    }
                    else
                    {
                        char top = parenthesisStack.Pop();
                        if (parenthesises.IndexOf(top) + 1 != index)
                        {
                            return false;
                        }
                    }
                }
            }

            return parenthesisStack.Count == 0;
        }
    }
}

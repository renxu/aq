using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class PostfixExpressionEvaluation
    {
        private const string AddOperator = "+";
        private const string MinusOperator = "-";
        private const string MutiplyOperator = "*";
        private const string DivideOperator = "/";

        private static HashSet<string> supportedOperators;

        static PostfixExpressionEvaluation()
        {
            supportedOperators = new HashSet<string>();
            supportedOperators.Add(AddOperator);
            supportedOperators.Add(MinusOperator);
            supportedOperators.Add(MutiplyOperator);
            supportedOperators.Add(DivideOperator);
        }

        /// <summary>
        /// http://quiz.geeksforgeeks.org/stack-set-4-evaluation-postfix-expression/
        /// Following is algorithm for evaluation postfix expressions.
        /// 1) Create a stack to store operands(or values).
        /// 2) Scan the given expression and do following for every scanned element.
        ///     a) If the element is a number, push it into the stack
        ///     b) If the element is a operator, pop operands for the operator from stack. Evaluate the operator and push the result back to the stack
        /// 3) When the expression is ended, the number in the stack is the final answer
        /// </summary>
        /// <param name="postfixExpression"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static decimal Evaluate(string postfixExpression, char separator)
        {
            CommonUtility.ThrowIfNull(postfixExpression);

            string[] elements = postfixExpression.Split(separator);
            var operandStack = new Stack<decimal>();

            foreach(var element in elements)
            {
                if (supportedOperators.Contains(element)) // an operator
                {
                    decimal number2 = operandStack.Pop(); // notice the top number is the second number in the operation.
                    decimal number1 = operandStack.Pop();
                    decimal result = 0m;

                    if (AddOperator.Equals(element))
                    {
                        result = number1 + number2;
                    }
                    else if (MinusOperator.Equals(element))
                    {
                        result = number1 - number2;
                    }
                    else if (MutiplyOperator.Equals(element))
                    {
                        result = number1 * number2;
                    }
                    else if (DivideOperator.Equals(element))
                    {
                        result = number1 / number2;
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    operandStack.Push(result);
                }
                else
                {
                    decimal number;
                    if (decimal.TryParse(element, out number)) // an operand
                    {
                        operandStack.Push(number);
                    }
                    else // invalid element
                    {
                        throw new ArgumentException(string.Format("Invalid element in the expression: '{0}'.", element));
                    }
                }
            }

            decimal final = operandStack.Pop();

            if (operandStack.Count != 0)
            {
                throw new ArgumentException("Invalid expression.");
            }

            return final;
        }
    }
}

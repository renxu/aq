using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class MutipleOfThree
    {
        /// <summary>
        /// http://www.geeksforgeeks.org/write-an-efficient-method-to-check-if-a-number-is-multiple-of-3/
        /// If sum of digits in a number is multiple of 3 then number is multiple of 3.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool Check1(int number)
        {
            number = Math.Abs(number);

            if (number < 10)
            {
                if (number == 0 || number == 3 || number == 6 || number == 9)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            int digitSum = 0;
            while (number != 0)
            {
                digitSum += number % 10;
                number /= 10;
            }

            return Check1(digitSum);
        }

        /// <summary>
        /// Tag: Bit
        /// There is a pattern in binary representation of the number that can be used to find if number is a multiple of 3. 
        /// If difference between count of odd set bits (Bits set at odd positions) and even set bits is multiple of 3 then is the number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool Check2(int number)
        {
            number = Math.Abs(number);

            if (number == 0)
            {
                return true;
            }
            else if (number == 1 || number == 2)
            {
                return false;
            }

            int oddSetBits = 0;
            int evenSetBits = 0;
            bool isOddPosition = true;
            while (number != 0)
            {
                if ((number & 1) == 1)
                {
                    if (isOddPosition)
                    {
                        oddSetBits++;
                    }
                    else
                    {
                        evenSetBits++;
                    }
                }

                number = number >> 1;
                isOddPosition = !isOddPosition;
            }

            return Check2(oddSetBits - evenSetBits);
        }
    }
}

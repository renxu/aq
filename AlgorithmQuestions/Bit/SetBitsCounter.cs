using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class SetBitsCounter
    {
        /// <summary>
        /// Given a positive integer n, count the total number of set bits in binary representation of all numbers from 1 to n.
        /// For example:
        /// Input: n = 3
        /// Output:  4
        /// 
        /// Input: n = 6
        /// Output: 9
        ///
        /// Input: n = 7
        /// Output: 12
        ///
        /// Input: n = 8
        /// Output: 13
        /// 
        /// Time: O(nlogn)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NaiveCount(int n)
        {
            int setBitsCount = 0;
            for (int i = 1; i <= n; i++)
            {
                setBitsCount += GetSetBitsCount(i);
            }

            return setBitsCount;
        }

        private static int GetSetBitsCount(int i)
        {
            int number = i;
            int count = 0;
            while (number != 0)
            {
                if ((number & 1) == 1)
                {
                    count++;
                }

                number = number >> 1;
            }

            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class SwapBits
    {
        /// <summary>
        /// Time: O(n)
        /// </summary>
        /// <param name="number"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SwapPairs1(int number, int p1, int p2, int n)
        {
            if (p1 < 0 || p2 < 0 || n < 0 || IsOverlaping(p1, p1 + n - 1, p2, p2 + n - 1))
            {
                throw new ArgumentException();
            }

            if (p1 == p2)
            {
                return number;
            }

            for (int i = 0; i < n; i++)
            {
                number = SwapPair(number, p1 + i, p2 + i);
            }

            return number;
        }

        public static int SwapPairs2(int number, int p1, int p2, int n)
        {
            if (p1 < 0 || p2 < 0 || n < 0 || IsOverlaping(p1, p1 + n - 1, p2, p2 + n - 1))
            {
                throw new ArgumentException();
            }

            if (p1 == p2)
            {
                return number;
            }

            int section1 = (number >> p1) & ((1 << n) - 1);
            int section2 = (number >> p2) & ((1 << n) - 1);

            int xor = section1 ^ section2;
            xor = (xor << p1) + (xor << p2);
            number = number ^ xor;
            return number;
        }

        private static int SwapPair(int number, int p1, int p2)
        {
            if (p1 < 0 || p2 < 0)
            {
                throw new ArgumentException();
            }

            if (p1 == p2)
            {
                return number;
            }

            int bit1 = (number >> p1) & 1;
            int bit2 = (number >> p2) & 1;
            if (bit1 == bit2)
            {
                return number;
            }

            int onePosition, zeroPosition;
            if (bit1 == 1)
            {
                onePosition = p1;
                zeroPosition = p2;
            }
            else
            {
                onePosition = p2;
                zeroPosition = p1;
            }

            number = number - (1 << onePosition) + (1 << zeroPosition);
            return number;
        }

        private static bool IsOverlaping(int start1, int end1, int start2, int end2)
        {
            return !(start1 > end2 || start2 > end1);
        }
    }
}

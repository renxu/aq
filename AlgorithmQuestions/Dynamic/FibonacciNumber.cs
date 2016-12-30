using System;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/dynamic-programming-set-1/
    /// 1 1 2 3 5 8 13 21 34...
    /// </summary>
    public static class FibonacciNumber
    {
        public static int GetNthByNormal(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            if (n <= 1)
            {
                return n;
            }

            return GetNthByNormal(n - 2) + GetNthByNormal(n - 1);
        }

        public static int GetNthByTopDown(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            var lookup = new int[n+1];
            for (int i = 0; i <= n; i++)
            {
                lookup[i] = -1;
            }

            return GetNthByTopDown(n, lookup);
        }

        private static int GetNthByTopDown(int n, int[] lookup)
        {
            if (lookup[n] == -1)
            {
                if (n <= 1)
                {
                    lookup[n] = n; // lookup[0] = 0, lookup[1] = 1
                }
                else
                {
                    lookup[n] = GetNthByTopDown(n - 1, lookup) + GetNthByTopDown(n - 2, lookup);
                }
            }

            return lookup[n];
        }

        public static int GetNthByBottomUp(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            if (n <= 1)
            {
                return n;
            }

            int temp1 = 0;
            int temp2 = 1;
            int temp3 = 0;
            for (int i = 2; i <= n; i++)
            {
                temp3 = temp1 + temp2;
                temp1 = temp2;
                temp2 = temp3;
            }

            return temp2;
        }
    }
}

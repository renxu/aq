using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    // 1 1 2 3 5 8 13 21 34...
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

            if (lookup[n] == -1)
            {
                if (n <= 1)
                {
                    lookup[n] = n;
                }
                else
                {
                    lookup[n] = GetNthByTopDown(n - 1) + GetNthByTopDown(n - 2);
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

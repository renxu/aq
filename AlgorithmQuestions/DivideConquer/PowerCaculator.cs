using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class PowerCaculator
    {
        public static double Pow(double x, double y)
        {
            if (y != (double)((int)y))
            {
                throw new ArgumentException();
            }

            int n = (int)y;
            if (n == 0)
            {
                return 1D; 
            }
            else if (n < 0)
            {
                if (x == 0)
                {
                    return double.PositiveInfinity;
                }
                else
                {
                    return 1D / Calculate(x, n * -1);
                }
            }
            else
            {
                if (x == 0)
                {
                    return 0D;
                }
                else
                {
                    return Calculate(x, n);
                }
            }
        }

        private static double Calculate(double x, int y)
        {
            if (y == 1)
            {
                return x;
            }
            else if (y % 2 == 1)
            {
                int halfY = y / 2;
                double halfResult = Calculate(x, halfY);
                return halfResult * halfResult * x;
            }
            else
            {
                int halfY = y / 2;
                double halfResult = Calculate(x, halfY);
                return halfResult * halfResult;
            }
        }
    }
}

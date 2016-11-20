using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class FindSingle
    {
        public static int Find(int[] array)
        {
            CommonUtility.ThrowIfNull(array);

            if (array.Length % 3 != 1)
            {
                throw new ArgumentException();
            }

            int ones = 0;
            int twos = 0;
            int threes = int.MaxValue;
            foreach (var num in array)
            {
                int number = Math.Abs(num);
                int newones = ((ones ^ number) & ones) | ((ones ^ number) & threes);
                int newtwos = ((twos ^ number) & twos) | ((twos ^ number) & ones);
                int newthrees = ((threes ^ number) & threes) | ((threes ^ number) & twos);
                ones = newones;
                twos = newtwos;
                threes = newthrees;
            }

            return ones;
        }
    }
}

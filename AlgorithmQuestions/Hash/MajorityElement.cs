using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class MajorityElement
    {
        public static bool Find(int[] input, out int majority)
        {
            CommonUtility.ThrowIfNull(input);
            if (input.Length == 0)
            {
                throw new ArgumentException();
            }

            
            var countDictionary = new Dictionary<int, int>();
            foreach(int value in input)
            {
                if (countDictionary.ContainsKey(value))
                {
                    countDictionary[value]++;
                }
                else
                {
                    countDictionary[value] = 1;
                }
            }

            majority = 0;
            int majorityCount = (input.Length / 2) + (input.Length % 2);
            foreach (int key in countDictionary.Keys)
            {
                if (countDictionary[key] >= majorityCount)
                {
                    majority = key;
                    return true;
                }
            }

            return false;
        }
    }
}

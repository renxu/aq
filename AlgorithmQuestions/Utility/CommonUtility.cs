using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public static class CommonUtility
    {
        // TODO: Reimplement using bit operatons.
        public static void Swap(int[] array, int index1, int index2)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index1 < 0 
                || index1 > array.Length - 1
                || index2 < 0
                || index2 > array.Length - 1)
            {
                throw new ArgumentException("Out of boundary.");
            }

            if (index1 == index2)
            {
                return;
            }

            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}

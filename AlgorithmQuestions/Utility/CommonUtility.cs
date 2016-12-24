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

            // Option 1
            //int temp = array[index1];
            //array[index1] = array[index2];
            //array[index2] = temp;

            // Option 2
            array[index1] = array[index1] ^ array[index2];
            array[index2] = array[index1] ^ array[index2];
            array[index1] = array[index1] ^ array[index2];
        }

        public static void ThrowIfNull(object paramater)
        {
            if (paramater == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="position">Position from right most to left are 0, 1, 2...</param>
        /// <returns></returns>
        public static bool IsMarked(int bitmap, int position)
        {
            if (position < 0)
            {
                throw new ArgumentException();
            }

            return ((bitmap >> position) & 1) == 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="position">Position from right most to left are 0, 1, 2...</param>
        /// <returns></returns>
        public static int Flip(int bitmap, int position)
        {
            if (position < 0)
            {
                throw new ArgumentException();
            }

            return (1 << position) ^ bitmap;
        }

        public static string ToString(int[] input)
        {
            var sb = new StringBuilder();
            for(int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i]);

                if (i < input.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }
    }
}

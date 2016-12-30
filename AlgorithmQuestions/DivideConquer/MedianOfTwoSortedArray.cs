using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/median-of-two-sorted-arrays/
    /// </summary>
    public static class MedianOfTwoSortedArray
    {
        /*
        Example:
        ar1[] = {1, 12, 15, 26, 38}
        ar2[] = {2, 13, 17, 30, 45}
        For above two arrays m1 = 15 and m2 = 17

        For the above ar1[] and ar2[], m1 is smaller than m2. So median is present in one of the following two subarrays.
        [15, 26, 38] and [2, 13, 17]
        Let us repeat the process for above two subarrays.
         */

        public static double GetMedian(double[] array1, double[] array2)
        {
            CommonUtility.ThrowIfNull(array1);
            CommonUtility.ThrowIfNull(array2);

            if (array1.Length == 0 && array2.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array1.Length != array2.Length)
            {
                throw new ArgumentException();
            }

            // TODO: Check arrays are sorted.

            return GetMedian(array1, 0, array1.Length - 1, array2, 0, array2.Length - 1);
        }

        private static double GetMedian(double[] array1, int startIndex1, int endIndex1, double[] array2, int startIndex2, int endIndex2)
        {
            double medianIndex1, medianValue1, medianIndex2, medianValue2;
            GetMedian(array1, startIndex1, endIndex1, out medianIndex1, out medianValue1);
            GetMedian(array2, startIndex2, endIndex2, out medianIndex2, out medianValue2);

            if (medianValue1 == medianValue2)
            {
                return medianValue1;
            }
            else if (startIndex1 == endIndex1)
            {
                return (medianValue1 + medianValue2) / 2D;
            }
            else if (startIndex1 + 1 == endIndex1) // Hardest part of algorithm
            {
                return (Math.Max(array1[startIndex1], array2[startIndex2]) + Math.Min(array1[endIndex1], array2[endIndex2])) / 2D;
            }
            else if (medianValue1 < medianValue2)
            {
                return GetMedian(array1, (int)Math.Ceiling(medianIndex1), endIndex1, array2, startIndex2, (int)Math.Floor(medianIndex2));
            }
            else
            {
                return GetMedian(array1, startIndex1, (int)Math.Floor(medianIndex1), array2, (int)Math.Ceiling(medianIndex2), endIndex2);
            }

            throw new NotImplementedException();
        }
        
        private static void GetMedian(double[] array, int startIndex, int endIndex, out double medianIndex, out double medianValue)
        {
            if ((startIndex + endIndex) % 2 == 0)
            {
                medianIndex = (startIndex + endIndex) / 2D;
                medianValue = array[(int)medianIndex];
            }
            else
            {
                medianIndex = (startIndex + endIndex) / 2;
                int temp = (int)medianIndex;
                medianValue = (array[temp] + array[temp + 1]) / 2D;
            }
        }
    }
}

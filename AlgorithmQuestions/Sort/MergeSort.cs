namespace AlgorithmQuestions
{
    public static class MergeSort
    {
        //  MergeSort is a Divide and Conquer algorithm.It divides input array in two halves, calls itself for the two halves and then merges the two sorted halves.The merge() function is used for merging two halves.The merge(arr, l, m, r) is key process that assumes that arr[l..m] and arr[m + 1..r] are sorted and merges the two sorted sub-arrays into one.See following C implementation for details.
        // MergeSort(arr[], l,  r)
        // If r > l
        // 1. Find the middle point to divide the array into two halves:  
        //    middle m = (l + r) / 2
        // 2. Call mergeSort for first half:   
        //    Call mergeSort(arr, l, m)
        // 3. Call mergeSort for second half:
        //    Call mergeSort(arr, m+1, r)
        // 4. Merge the two halves sorted in step 2 and 3:
        //    Call merge(arr, l, m, r)

        /// <summary>
        /// Time complexity: O(nlogn).
        /// Additional space complexity: O(n).
        /// Note, space is reusable through recurrsions.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int[] Sort(int[] inputs)
        {
            if (inputs == null || inputs.Length <= 1)
            {
                return inputs;
            }

            Sort(inputs, 0, inputs.Length - 1);
            return inputs;
        }

        private static void Sort(int[] inputs, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                return;
            }

            // Divide into two arrays
            int middleIndex = (startIndex + endIndex) / 2;

            // Sort the two arrays
            Sort(inputs, startIndex, middleIndex);
            Sort(inputs, middleIndex + 1, endIndex);

            // Merge the two sorted arrays
            int[] temp = new int[endIndex - startIndex + 1];
            int firstHead = startIndex;
            int secondHead = middleIndex + 1;
            for (int i = 0; i < temp.Length; i++)
            {
                if (firstHead > middleIndex)
                {
                    temp[i] = inputs[secondHead];
                    secondHead++;
                }
                else if (secondHead > endIndex)
                {
                    temp[i] = inputs[firstHead];
                    firstHead++;
                }
                else if (inputs[firstHead] > inputs[secondHead])
                {
                    temp[i] = inputs[secondHead];
                    secondHead++;
                }
                else
                {
                    temp[i] = inputs[firstHead];
                    firstHead++;
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                inputs[startIndex + i] = temp[i];
            }
        }
    }
}

namespace AlgorithmQuestions
{
    public static class SelectionSort
    {
        //The selection sort algorithm sorts an array by repeatedly finding the minimum element(considering ascending order) from unsorted part and putting it at the beginning.The algorithm maintains two subarrays in a given array.
        //1) The subarray which is already sorted.
        //2) Remaining subarray which is unsorted.
        //In every iteration of selection sort, the minimum element(considering ascending order) from the unsorted subarray is picked and moved to the sorted subarray.

        /// <summary>
        /// Time complexity: O(n^2).
        /// Additional space complexity: O(1).
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int[] Sort(int[] inputs)
        {
            if (inputs == null || inputs.Length <= 1)
            {
                return inputs;
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < inputs.Length; j++)
                {
                    if (inputs[j] < inputs[minIndex])
                    {
                        minIndex = j;
                    }
                }

                CommonUtility.Swap(inputs, i, minIndex);
            }

            return inputs;
        }
    }
}

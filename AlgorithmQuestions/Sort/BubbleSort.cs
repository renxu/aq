namespace AlgorithmQuestions
{
    /// <summary>
    /// http://geeksquiz.com/bubble-sort/
    /// </summary>
    public static class BubbleSort
    {
        //Bubble Sort is the simplest sorting algorithm that works by repeatedly swapping the adjacent elements if they are in wrong order.

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

            for (int i = 0; i < inputs.Length - 1; i++)
            {
                for (int j = inputs.Length - 1; j > i; j--)
                {
                    if (inputs[j-1] > inputs[j])
                    {
                        CommonUtility.Swap(inputs, j - 1, j);
                    }
                }
            }

            return inputs;
        }
    }
}

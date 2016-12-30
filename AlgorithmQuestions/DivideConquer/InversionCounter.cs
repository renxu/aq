namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/counting-inversions/
    /// Two elements a[i] and a[j] form an inversion if a[i] > a[j] and i < j
    /// </summary>
    public class InversionCounter
    {
        private int[] inputs;
        private int count;

        public InversionCounter(int[] inputs)
        {
            if (inputs == null)
            {
                CommonUtility.ThrowIfNull(inputs);
            }

            this.inputs = inputs;
            this.count = 0;
        }
        
        public int Count()
        {
            if (this.inputs.Length <= 1)
            {
                return 0;
            }

            this.count = 0;
            SortAndCount(0, inputs.Length - 1);

            return count;
        }

        private void SortAndCount(int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                return;
            }

            // Divide into two arrays
            int middleIndex = (startIndex + endIndex) / 2;

            // Sort the two arrays
            SortAndCount(startIndex, middleIndex);
            SortAndCount(middleIndex + 1, endIndex);

            // Merge the two sorted arrays
            int[] temp = new int[endIndex - startIndex + 1];
            int firstHead = startIndex;
            int secondHead = middleIndex + 1;
            for (int i = 0; i < temp.Length; i++)
            {
                if (firstHead > middleIndex)
                {
                    temp[i] = this.inputs[secondHead];
                    secondHead++;
                }
                else if (secondHead > endIndex)
                {
                    temp[i] = this.inputs[firstHead];
                    firstHead++;
                }
                else if (this.inputs[firstHead] > this.inputs[secondHead])
                {
                    temp[i] = this.inputs[secondHead];
                    this.count += middleIndex - firstHead + 1;
                    secondHead++;
                }
                else
                {
                    temp[i] = this.inputs[firstHead];
                    firstHead++;
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                this.inputs[startIndex + i] = temp[i];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public abstract class HeapBasic<T> where T: IComparable
    {
        private const int SizeLimit = 1000;
        private const int NotExistIndex = -1;
        private int lastValueIndex = -1;
        protected T[] data;

        public HeapBasic(IEnumerable<T> values)
        {
            data = new T[SizeLimit];

            if (values != null)
            {
                if (values.Count() > SizeLimit)
                {
                    throw new ArgumentException(string.Format("The heap exceeded the size limit: {0}", SizeLimit));
                }

                // Build heap - solution 1: Perform N inserts
                ////foreach (var value in values)
                ////{
                ////    this.Insert(value);
                ////}

                // Build heap - solution 2:
                // a. Randomly populate initial heap with structure property.
                // b. Perform a sift-down from each non-leaf node
                foreach (var value in values)
                {
                    lastValueIndex++;
                    data[lastValueIndex] = value;
                }

                for (int i = (values.Count() / 2) - 1; i >= 0; i--)
                {
                    this.SiftDown(i);
                }
            }
        }

        /// <summary>
        /// Adds a value to the heap.
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value)
        {
            // Add the value to the end of the heap, and run heapify-up on that node.
            lastValueIndex++;
            data[lastValueIndex] = value;
            SiftUp(lastValueIndex);
        }

        /// <summary>
        /// Deletes the root from the heap.
        /// </summary>
        /// <returns></returns>
        public T Extract()
        {
            if (this.lastValueIndex < 0)
            {
                throw new InvalidOperationException("The heap contains no values.");
            }

            T root = data[0];
            if (lastValueIndex > 0)
            {
                // Replace the root of the heap with the last element on the last level.
                // And run heapify-down on the root node.
                data[0] = data[lastValueIndex];
                data[lastValueIndex] = default(T);
                lastValueIndex--;
                this.SiftDown(0);
            }
            else
            {
                lastValueIndex--;
            }

            return root;
        }

        /// <summary>
        /// Gets the value of the root note.
        /// </summary>
        /// <returns></returns>
        public T Peak()
        {
            if (this.lastValueIndex < 0)
            {
                throw new InvalidOperationException("The heap contains no values.");
            }

            return data[0];
        }

        public void PrintHeap()
        {
            var sb = new StringBuilder();
            for (int i = 0; i <= lastValueIndex; i++)
            {
                sb.Append(data[i]);

                if (i != lastValueIndex)
                {
                    sb.Append(", ");
                }
            }

            Console.WriteLine(sb);
        }

        /// <summary>
        /// Compare two values:
        /// For min heap: when index1 value is less than index2 value, return positive number;
        /// For max heap: when index1 value is greater than index2 value, return positive number;
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        protected abstract int Compare(int index1, int index2);

        private int ParentIndex(int currentIndex)
        {
            if (currentIndex <= 0)
            {
                return NotExistIndex;
            }

            return (currentIndex - 1) / 2;
        }

        private int LeftChildIndex(int currentIndex)
        {
            int child = (currentIndex * 2) + 1;
            return child <= lastValueIndex ? child : NotExistIndex;
        }

        private int RightChildIndex(int currentIndex)
        {
            int child = (currentIndex + 1) * 2;
            return child <= lastValueIndex ? child : NotExistIndex;
        }

        /// <summary>
        /// Restores the heap properties by moving the target node up the heap.
        /// For min heap: Ensure that parents are smaller than children.
        /// For max heap: Ensure that parents are larger than children.
        /// </summary>
        /// <param name="index"></param>
        private void SiftUp(int index)
        {
            int current = index;

            // 1. Compare the added element with its parent; if they are in the correct order, stop.
            // 2. If not, swap the element with its parent and return to the previous step.
            while (true)
            {
                int parent = this.ParentIndex(current);
                if (parent == NotExistIndex)
                {
                    break; // heapify is done.
                }

                if (SwapIfNeeded(parent, current))
                {
                    current = parent;
                }
                else
                {
                    break; // heapify is done.
                }
            }
        }

        /// <summary>
        /// Restores the heap properties by moving the target node down the heap.
        /// For min heap: Ensure that parents are smaller than children.
        /// For max heap: Ensure that parents are larger than children.
        /// </summary>
        /// <param name="index"></param>
        private void SiftDown(int index)
        {
            int current = index;

            // 1. Compare the new root with its children; if they are in the correct order, stop.
            // 2. If not, swap the element with one of its children and return to the previous step. 
            //    (Swap with its smaller child in a min heap and its larger child in a max heap.)
            while (true)
            {
                int left = this.LeftChildIndex(current);
                int right = this.RightChildIndex(current);

                if (left == NotExistIndex)
                {
                    break; // No children, so heapify is done.
                }
                else if (right == NotExistIndex)
                {
                    // Left child only (right child only is impossible)
                    SwapIfNeeded(current, left);
                    break; // If the current only has left child, its child won't have children in the heap.
                }
                else
                {
                    // Both children exist.
                    int topIndex = this.TopIndex(current, left, right);
                    if (topIndex == current)
                    {
                        break; // Heapify is done.
                    }
                    else if (topIndex == left)
                    {
                        SwapIfNeeded(current, left);
                        current = left;
                    }
                    else
                    {
                        SwapIfNeeded(current, right);
                        current = right;
                    }
                }
            }
        }

        /// <summary>
        /// Searches and deletes a value from the heap.
        /// </summary>
        /// <param name="value"></param>
        private void Delete(T value)
        {
            throw new NotImplementedException();
        }

        private void DecreaseKey()
        {
            throw new NotImplementedException();
        }

        private void IncreaseKey()
        {
            throw new NotImplementedException();
        }

        private bool SwapIfNeeded(int parent, int child)
        {
            int comparison = this.Compare(parent, child);
            bool swapped = false;
            if (comparison < 0)
            {
                // Exchange position
                T temp = data[parent];
                data[parent] = data[child];
                data[child] = temp;
                swapped = true;
            }
            else if (comparison == 0)
            {
                throw new InvalidOperationException(string.Format("Duplicate values: {0}", data[parent]));
            }

            return swapped;
        }

        /// <summary>
        /// For min heap, top index has the smallest value.
        /// For max heap, top index has the largest value.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int TopIndex(int parent, int left, int right)
        {
            int winner = this.Compare(parent, left) > 0 ? parent : left;
            return this.Compare(winner, right) > 0 ? winner : right;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    // http://www.geeksforgeeks.org/archives/18754
    // Implement two stacks in an array
    // The idea is to start two stacks from two extreme corners of arr[]. stack1 starts from the leftmost element, 
    // the first element in stack1 is pushed at index 0. The stack2 starts from the rightmost corner, the first 
    // element in stack2 is pushed at index(n-1). Both stacks grow(or shrink) in opposite direction.To check for 
    // overflow, all we need to check is for space between top elements of both stacks.
    public class DoubleStack<T>
    {
        private T[] array;
        private int firstStackTop;
        private int secondStackTop;

        public DoubleStack(int totalSize)
        {
            if (totalSize < 0)
            {
                throw new ArgumentException("Size cannot be smaller than zero.");
            }

            array = new T[totalSize];
            firstStackTop = -1;
            secondStackTop = totalSize;
        }

        public void Push1(T value)
        {
            if (IsFull())
            {
                throw new ArgumentOutOfRangeException("The stack is out of space.");
            }

            firstStackTop++;
            array[firstStackTop] = value;
        }

        public T Pop1()
        {
            if (firstStackTop < 0)
            {
                throw new ArgumentOutOfRangeException("The first stack is empty.");
            }

            var value = array[firstStackTop];
            firstStackTop--;
            return value;
        }

        public void Push2(T value)
        {
            if (IsFull())
            {
                throw new ArgumentOutOfRangeException("The stack is out of space.");
            }

            secondStackTop--;
            array[secondStackTop] = value;
        }

        public T Pop2()
        {
            if (secondStackTop >= array.Length)
            {
                throw new ArgumentOutOfRangeException("The second stack is empty.");
            }

            var value = array[secondStackTop];
            secondStackTop++;
            return value;
        }

        private bool IsFull()
        {
            return firstStackTop + 1 >= secondStackTop;
        }
    }
}

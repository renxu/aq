using System;

namespace AlgorithmQuestions
{
    public class SinglyLinkedListNode<T> where T : IComparable
    {
        public SinglyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public SinglyLinkedListNode<T> Next { get; set; }
    }
}

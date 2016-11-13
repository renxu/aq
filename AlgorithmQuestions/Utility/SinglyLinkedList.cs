using System;

namespace AlgorithmQuestions
{
    public class SinglyLinkedList<T> where T : IComparable
    {
        public SinglyLinkedListNode<T> First { get; set; }

        public SinglyLinkedListNode<T> Insert(T value)
        {
            var node = new SinglyLinkedListNode<T>(value);
            if (this.First == null)
            {
                this.First = node;
            }
            else
            {
                node.Next = this.First;
                this.First = node;
            }

            return node;
        }

        public bool ContainsValue(T value)
        {
            var node = this.First;

            while (node != null)
            {
                if (node.Value.CompareTo(value) == 0)
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }
    }
}

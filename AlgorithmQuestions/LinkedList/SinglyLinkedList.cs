using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://quiz.geeksforgeeks.org/linked-list-set-1-introduction/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T> where T : IComparable
    {
        public SinglyLinkedListNode<T> First { get; set; }

        public SinglyLinkedListNode<T> Last
        {
            get
            {
                if (this.First == null)
                {
                    return null;
                }

                var node = this.First;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                return node;
            }
        }

        public SinglyLinkedListNode<T> InsertAtFirst(T value)
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

        public SinglyLinkedListNode<T> InsertAtFirst(SinglyLinkedListNode<T> node)
        {
            if (this.First == null)
            {
                node.Next = null;
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

        public void ReverseList()
        {
            var newList = new SinglyLinkedList<T>();
            var next = this.First;
            while (next != null)
            {
                var nextNext = next.Next;
                newList.InsertAtFirst(next);
                next = nextNext;
            }

            this.First = newList.First;
        }

        public void PrintList()
        {
            var sb = new StringBuilder();
            var next = this.First;
            while (next != null)
            {
                sb.Append(string.Format("-> {0} ", next.Value));
                next = next.Next;
            }

            sb.Append("-> null");
            System.Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// http://www.geeksforgeeks.org/write-a-c-function-to-detect-loop-in-a-linked-list/
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <returns></returns>
        public bool DecectCircleByFloyd()
        {
            var head = new SinglyLinkedListNode<T>(default(T));
            head.Next = this.First;
            SinglyLinkedListNode<T> slow = head;
            SinglyLinkedListNode<T> fast = head;

            while (fast != null)
            {
                slow = slow.Next;
                fast = fast.Next;
                if (fast != null)
                {
                    fast = fast.Next;
                }
                else
                {
                    break;
                }

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// This method is implemented using normal algorithm. 
        /// It can also Floyd circle-detect algorithm, but it is unncessarily complex.
        /// See the link for more details: http://www.geeksforgeeks.org/detect-and-remove-loop-in-a-linked-list/
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <returns></returns>
        public bool DecectAndRemoveCircle()
        {
            var visited = new HashSet<SinglyLinkedListNode<T>>();

            var current = this.First;
            SinglyLinkedListNode<T> previous = null;
            while (current != null)
            {
                if (visited.Contains(current))
                {
                    // Found circle
                    previous.Next = null; // Break circle
                    return true;
                }
                else
                {
                    visited.Add(current);
                    previous = current;
                    current = current.Next;
                }
            }

            return false;
        }
    }
}

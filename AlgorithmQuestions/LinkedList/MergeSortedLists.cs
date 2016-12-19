using System;

namespace AlgorithmQuestions
{
    public class MergeSortedLists
    {
        public static SinglyLinkedList<T> Merge<T>(SinglyLinkedList<T> ascendList1, SinglyLinkedList<T> ascendList2) where T : IComparable
        {
            CommonUtility.ThrowIfNull(ascendList1);
            CommonUtility.ThrowIfNull(ascendList2);

            var result = new SinglyLinkedList<T>();
            Merge(ascendList1.First, ascendList2.First, result, result.First);
            return result;
        }

        private static void Merge<T>(SinglyLinkedListNode<T> head1, SinglyLinkedListNode<T> head2, SinglyLinkedList<T> resultList, SinglyLinkedListNode<T> resultLastNode) where T : IComparable
        {
            if (head1 != null && head2 != null)
            {
                SinglyLinkedListNode<T> smallerNode = null;
                SinglyLinkedListNode<T> biggerNode = null;
                if (head1.Value.CompareTo(head2.Value) <= 0)
                {
                    smallerNode = head1;
                    biggerNode = head2;

                }
                else
                {
                    smallerNode = head2;
                    biggerNode = head1;
                }

                if (resultLastNode == null)
                {
                    resultList.First = smallerNode;
                    
                }
                else
                {
                    resultLastNode.Next = smallerNode;
                }

                resultLastNode = smallerNode;
                var smallerNodeNext = smallerNode.Next;
                smallerNode.Next = null;
                Merge(smallerNodeNext, biggerNode, resultList, resultLastNode);

            }
            else if (head1 != null && head2 == null)
            {
                if (resultLastNode == null)
                {
                    resultList.First = head1;

                }
                else
                {
                    resultLastNode.Next = head1;
                }
            }
            else if (head1 == null && head2 != null)
            {
                if (resultLastNode == null)
                {
                    resultList.First = head2;

                }
                else
                {
                    resultLastNode.Next = head2;
                }
            }
        }
    }
}

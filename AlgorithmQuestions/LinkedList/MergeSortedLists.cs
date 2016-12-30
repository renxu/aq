using System;

namespace AlgorithmQuestions
{
    public class MergeSortedLists
    {
        /// <summary>
        /// http://www.geeksforgeeks.org/merge-two-sorted-linked-lists/
        /// Use recursion.
        /// Time: O(m+n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ascendList1"></param>
        /// <param name="ascendList2"></param>
        /// <returns></returns>
        public static SinglyLinkedList<T> Merge<T>(SinglyLinkedList<T> ascendList1, SinglyLinkedList<T> ascendList2) where T : IComparable
        {
            CommonUtility.ThrowIfNull(ascendList1);
            CommonUtility.ThrowIfNull(ascendList2);

            var result = new SinglyLinkedList<T>();
            AppendNodesToResult(ascendList1.First, ascendList2.First, result, result.First);
            return result;
        }

        private static void AppendNodesToResult<T>(SinglyLinkedListNode<T> currentNodeFromList1, SinglyLinkedListNode<T> currentNodeFromList2, SinglyLinkedList<T> resultList, SinglyLinkedListNode<T> lastNodeFromResult) where T : IComparable
        {
            if (currentNodeFromList1 != null && currentNodeFromList2 != null)
            {
                SinglyLinkedListNode<T> smallerNode = null;
                SinglyLinkedListNode<T> biggerNode = null;
                if (currentNodeFromList1.Value.CompareTo(currentNodeFromList2.Value) <= 0)
                {
                    smallerNode = currentNodeFromList1;
                    biggerNode = currentNodeFromList2;

                }
                else
                {
                    smallerNode = currentNodeFromList2;
                    biggerNode = currentNodeFromList1;
                }

                if (lastNodeFromResult == null)
                {
                    resultList.First = smallerNode;
                    
                }
                else
                {
                    lastNodeFromResult.Next = smallerNode;
                }

                lastNodeFromResult = smallerNode;
                var smallerNodeNext = smallerNode.Next;
                smallerNode.Next = null;
                AppendNodesToResult(smallerNodeNext, biggerNode, resultList, lastNodeFromResult);

            }
            else if (currentNodeFromList1 != null && currentNodeFromList2 == null)
            {
                if (lastNodeFromResult == null)
                {
                    resultList.First = currentNodeFromList1;
                }
                else
                {
                    lastNodeFromResult.Next = currentNodeFromList1;
                }
            }
            else if (currentNodeFromList1 == null && currentNodeFromList2 != null)
            {
                if (lastNodeFromResult == null)
                {
                    resultList.First = currentNodeFromList2;
                }
                else
                {
                    lastNodeFromResult.Next = currentNodeFromList2;
                }
            }
        }
    }
}

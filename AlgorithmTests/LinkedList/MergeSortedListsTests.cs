using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MergeSortedListsTests
    {
        [TestMethod]
        public void MergeSortedLists_Merge_BasicCase()
        {
            var list1 = new SinglyLinkedList<int>();
            list1.InsertAtFirst(6);
            list1.InsertAtFirst(4);
            list1.InsertAtFirst(2);
            list1.InsertAtFirst(0);
            var list2 = new SinglyLinkedList<int>();
            list2.InsertAtFirst(7);
            list2.InsertAtFirst(5);
            list2.InsertAtFirst(3);
            list2.InsertAtFirst(1);

            MergeSortedLists.Merge<int>(list1, list2).PrintList();
        }

        [TestMethod]
        public void MergeSortedLists_Merge_OneEmptyList()
        {
            var list1 = new SinglyLinkedList<int>();
            list1.InsertAtFirst(6);
            list1.InsertAtFirst(4);
            list1.InsertAtFirst(2);
            list1.InsertAtFirst(0);
            var list2 = new SinglyLinkedList<int>();

            MergeSortedLists.Merge<int>(list1, list2).PrintList();
        }

        [TestMethod]
        public void MergeSortedLists_Merge_TwoEmptyLists()
        {
            var list1 = new SinglyLinkedList<int>();
            var list2 = new SinglyLinkedList<int>();

            MergeSortedLists.Merge<int>(list1, list2).PrintList();
        }

    }
}

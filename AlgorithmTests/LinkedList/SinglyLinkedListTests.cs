using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void SinglyLinkedList_ReverseList_BasicCase()
        {
            var list = new SinglyLinkedList<int>();
            list.InsertAtFirst(1);
            list.InsertAtFirst(2);
            list.InsertAtFirst(3);
            list.InsertAtFirst(4);
            list.PrintList();
            list.ReverseList();
            list.PrintList();
        }

        [TestMethod]
        public void SinglyLinkedList_ReverseList_EmptyList()
        {
            var list = new SinglyLinkedList<int>();
            list.PrintList();
            list.ReverseList();
            list.PrintList();
        }

        [TestMethod]
        public void SinglyLinkedList_DetectCycleByFloyd_HasCircleBasic()
        {
            var list = new SinglyLinkedList<int>();
            var node4 = list.InsertAtFirst(4);
            list.InsertAtFirst(3);
            var node2 = list.InsertAtFirst(2);
            list.InsertAtFirst(1);
            node4.Next = node2;
            Assert.IsTrue(list.DecectCircleByFloyd(), "A circle should be found.");
            Assert.IsTrue(list.DecectAndRemoveCircle(), "A circle should be found.");
            Assert.IsFalse(list.DecectCircleByFloyd(), "No circle should be found after removal.");
        }

        [TestMethod]
        public void SinglyLinkedList_DetectCycleByFloyd_NoCircle()
        {
            var list = new SinglyLinkedList<int>();
            list.InsertAtFirst(4);
            list.InsertAtFirst(3);
            list.InsertAtFirst(2);
            list.InsertAtFirst(1);
            Assert.IsFalse(list.DecectCircleByFloyd(), "No circle should be found.");
        }

        [TestMethod]
        public void SinglyLinkedList_DetectCycleByFloyd_SelfCircleBasic()
        {
            var list = new SinglyLinkedList<int>();
            var node4 = list.InsertAtFirst(4);
            list.InsertAtFirst(3);
            list.InsertAtFirst(2);
            list.InsertAtFirst(1);
            node4.Next = node4;
            Assert.IsTrue(list.DecectCircleByFloyd(), "A circle should be found.");
            Assert.IsTrue(list.DecectAndRemoveCircle(), "A circle should be found.");
            Assert.IsFalse(list.DecectCircleByFloyd(), "No circle should be found after removal.");
        }

        [TestMethod]
        public void SinglyLinkedList_DetectCycleByFloyd_HasCircleToFirstNode()
        {
            var list = new SinglyLinkedList<int>();
            var node4 = list.InsertAtFirst(4);
            list.InsertAtFirst(3);
            list.InsertAtFirst(2);
            var node1 = list.InsertAtFirst(1);
            node4.Next = node1;
            Assert.IsTrue(list.DecectCircleByFloyd(), "A circle should be found.");
            Assert.IsTrue(list.DecectAndRemoveCircle(), "A circle should be found.");
            Assert.IsFalse(list.DecectCircleByFloyd(), "No circle should be found after removal.");
        }

        [TestMethod]
        public void SinglyLinkedList_DetectCycleByFloyd_SelfCircleAtFirstNode()
        {
            var list = new SinglyLinkedList<int>();
            var node1 = list.InsertAtFirst(1);
            node1.Next = node1;
            Assert.IsTrue(list.DecectCircleByFloyd(), "A circle should be found.");
            Assert.IsTrue(list.DecectAndRemoveCircle(), "A circle should be found.");
            Assert.IsFalse(list.DecectCircleByFloyd(), "No circle should be found after removal.");
        }

        [TestMethod]
        public void SinglyLinkedList_DetectCycleByFloyd_EmptyList()
        {
            var list = new SinglyLinkedList<int>();
            Assert.IsFalse(list.DecectCircleByFloyd(), "No circle should be found.");
        }
    }
}

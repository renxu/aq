using System;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void BinarySearchTree_Insert_BuildTree()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree();
            tree.ToString();
        }

        [TestMethod]
        public void BinarySearchTree_Search_Found()
        {
            var tree = this.BuildTree();
            var node = tree.Search(9);
            Assert.IsNotNull(node);
            Assert.AreEqual(9, node.Value, "Wrong value.");
        }

        [TestMethod]
        public void BinarySearchTree_Search_NotFound()
        {
            var tree = this.BuildTree();
            var node = tree.Search(22);
            Assert.IsNull(node);
        }

        [TestMethod]
        public void BinarySearchTree_Delete_DeleteLeaf()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /   \
                8     25
            */
            var tree = this.BuildTree();
            tree.Delete(19);
            tree.ToString();
        }

        [TestMethod]
        public void BinarySearchTree_Delete_DeleteNodeWithOneChild()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 8 21
                    /\
                   19 25
            */
            var tree = this.BuildTree();
            tree.Delete(9);
            tree.ToString();
        }

        [TestMethod]
        public void BinarySearchTree_Delete_DeleteNodeWithTwoChildren()
        {
            /* Result tree
                 5
                / \
               2  19
              /\  /\
            -4  3 9 21
                 /   \
                8     25
            */
            var tree = this.BuildTree();
            tree.Delete(12);
            tree.ToString();
        }

        [TestMethod]
        public void BinarySearchTree_FindInOrderNeighbours_Found_Basic()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree();
            int predecessor;
            int successor;
            tree.FindInOrderNeighbours(12, out predecessor, out successor);
            Assert.AreEqual(9, predecessor, "Wrong predecessor.");
            Assert.AreEqual(19, successor, "Wrong successor.");
        }

        [TestMethod]
        public void BinarySearchTree_FindInOrderNeighbours_Found_NoRightSubtree()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree();
            int predecessor;
            int successor;
            tree.FindInOrderNeighbours(9, out predecessor, out successor);
            Assert.AreEqual(8, predecessor, "Wrong predecessor.");
            Assert.AreEqual(12, successor, "Wrong successor.");
        }

        [TestMethod]
        public void BinarySearchTree_FindInOrderNeighbours_Found_LeefNode()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree();
            int predecessor;
            int successor;
            tree.FindInOrderNeighbours(8, out predecessor, out successor);
            Assert.AreEqual(5, predecessor, "Wrong predecessor.");
            Assert.AreEqual(9, successor, "Wrong successor.");
        }

        [TestMethod]
        public void BinarySearchTree_FindInOrderNeighbours_Found_Root()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree();
            int predecessor;
            int successor;
            tree.FindInOrderNeighbours(5, out predecessor, out successor);
            Assert.AreEqual(3, predecessor, "Wrong predecessor.");
            Assert.AreEqual(8, successor, "Wrong successor.");
        }

        [TestMethod]
        public void BinarySearchTree_FindInOrderNeighbours_NotFound()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree();
            int predecessor;
            int successor;
            tree.FindInOrderNeighbours(10, out predecessor, out successor);
            Assert.AreEqual(9, predecessor, "Wrong predecessor.");
            Assert.AreEqual(12, successor, "Wrong successor.");
        }

        [TestMethod]
        public void BinarySearchTree_CorrectSwappedNodes_NotAjacent()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */

            var tree = new BinarySearchTree<int>();
            var node1 = tree.Insert(5);
            tree.Insert(12);
            tree.Insert(9);
            tree.Insert(21);
            tree.Insert(25);
            tree.Insert(2);
            tree.Insert(-4);
            tree.Insert(3);
            var node2 = tree.Insert(19);
            tree.Insert(8);
            node1.Value = 19;
            node2.Value = 5;
            tree.CorrectSwappedNodes();
            Console.WriteLine("Exam results manually.");
        }

        [TestMethod]
        public void BinarySearchTree_CorrectSwappedNodes_Ajacent()
        {
            /* Result tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */

            var tree = new BinarySearchTree<int>();
            tree.Insert(5);
            tree.Insert(12);
            tree.Insert(9);
            var node1 = tree.Insert(21);
            tree.Insert(25);
            tree.Insert(2);
            tree.Insert(-4);
            tree.Insert(3);
            var node2 = tree.Insert(19);
            tree.Insert(8);
            node1.Value = 19;
            node2.Value = 21;
            tree.CorrectSwappedNodes();
            Console.WriteLine("Exam results manually.");
        }

        private BinarySearchTree<int> BuildTree()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(5);
            tree.Insert(12);
            tree.Insert(9);
            tree.Insert(21);
            tree.Insert(25);
            tree.Insert(2);
            tree.Insert(-4);
            tree.Insert(3);
            tree.Insert(19);
            tree.Insert(8);
            return tree;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void BinaryTreeTests_TraverseBreadthFirst_Basic()
        {
            /* Tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree1();
            this.PrintTraversal(tree.TraverseBreadthFirst());
        }

        [TestMethod]
        public void BinaryTreeTests_TraverseDepthFirstPreOrder_Basic()
        {
            /* Tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree1();
            this.PrintTraversal(tree.TraverseDepthFirstPreOrder());
        }

        [TestMethod]
        public void BinaryTreeTests_TraverseDepthFirstInOrder_Basic()
        {
            /* Tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree1();
            this.PrintTraversal(tree.TraverseDepthFirstInOrder());
        }

        [TestMethod]
        public void BinaryTreeTests_TraverseDepthFirstPostOrder_Basic()
        {
            /* Tree
                 5
                / \
               2  12
              /\  /\
            -4  3 9 21
                 /  /\
                8  19 25
            */
            var tree = this.BuildTree1();
            this.PrintTraversal(tree.TraverseDepthFirstPostOrder());
        }

        [TestMethod]
        public void BinaryTreeTests_Reconstruct_Basic()
        {
            /* Tree
                 A
                / \
               B   C
              /\  /
            -D  E F
            */
            var tree = this.BuildTree2();
            var inOrder = tree.TraverseDepthFirstInOrder();
            this.PrintTraversal(inOrder); // D B E A F C
            var preOrder = tree.TraverseDepthFirstPreOrder();
            this.PrintTraversal(preOrder); // A B D E C F
            var reconstruct = BinaryTree<char>.Reconstruct(inOrder, preOrder);
            reconstruct.ToString();
        }

        private BinaryTree<int> BuildTree1()
        {
            var tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(5)
            {
                LeftChild = new BinaryTreeNode<int>(2)
                {
                    LeftChild = new BinaryTreeNode<int>(4),
                    RightChild = new BinaryTreeNode<int>(3)
                },
                RightChild = new BinaryTreeNode<int>(12)
                {
                    LeftChild = new BinaryTreeNode<int>(9)
                    {
                        LeftChild = new BinaryTreeNode<int>(8),
                        RightChild = null
                    },
                    RightChild = new BinaryTreeNode<int>(21)
                    {
                        LeftChild = new BinaryTreeNode<int>(19),
                        RightChild = new BinaryTreeNode<int>(25)
                    }
                }
            };
            return tree;
        }

        private BinaryTree<char> BuildTree2()
        {
            var tree = new BinaryTree<char>();
            tree.Root = new BinaryTreeNode<char>('A')
            {
                LeftChild = new BinaryTreeNode<char>('B')
                {
                    LeftChild = new BinaryTreeNode<char>('D'),
                    RightChild = new BinaryTreeNode<char>('E')
                },
                RightChild = new BinaryTreeNode<char>('C')
                {
                    LeftChild = new BinaryTreeNode<char>('F'),
                    RightChild = null
                }
            };
            return tree;
        }

        private void PrintTraversal<T>(IEnumerable<BinaryTreeNode<T>> traversal) where T: IComparable
        {
            var sb = new StringBuilder();
            foreach(var node in traversal)
            {
                sb.Append(node.Value);
                sb.Append(", ");
            }

            Console.WriteLine(sb);
        }
    }
}

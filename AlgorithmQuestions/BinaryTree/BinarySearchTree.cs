﻿using System;
using System.Collections.Generic;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://quiz.geeksforgeeks.org/binary-search-tree-set-1-search-and-insertion/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; set; }

        public BinarySearchTree(BinaryTreeNode<T> root)
        {
            this.Root = root;
        }

        public BinarySearchTree(): this(null)
        {
        }

        public BinaryTreeNode<T> Search(T value)
        {
            return this.Search(this.Root, value);
        }

        public BinaryTreeNode<T> Insert(T value)
        {
            if (this.Root == null)
            {
                this.Root = new BinaryTreeNode<T>(value);
                return this.Root;
            }

            return this.InsertUnder(this.Root, value);
        }

        public void Delete(T value)
        {
            var foundNode = this.Search(value);

            if (foundNode == null)
            {
                throw new ArgumentException("The value is not found in the tree");
            }

            if (foundNode.LeftChild == null && foundNode.RightChild == null)
            {
                var parentNode = foundNode.Parent;
                if (parentNode.LeftChild == foundNode)
                {
                    parentNode.LeftChild = null;
                }
                else
                {
                    parentNode.RightChild = null;
                }

                foundNode.Parent = null;
            }
            else if(foundNode.LeftChild != null && foundNode.RightChild == null)
            {
                var parentNode = foundNode.Parent;
                if (parentNode.LeftChild == foundNode)
                {
                    parentNode.LeftChild = foundNode.LeftChild;
                }
                else
                {
                    parentNode.RightChild = foundNode.LeftChild;
                }

                foundNode.Parent = null;
                foundNode.LeftChild = null;
            }
            else if (foundNode.LeftChild == null && foundNode.RightChild != null)
            {
                var parentNode = foundNode.Parent;
                if (parentNode.LeftChild == foundNode)
                {
                    parentNode.LeftChild = foundNode.RightChild;
                }
                else
                {
                    parentNode.RightChild = foundNode.RightChild;
                }

                foundNode.Parent = null;
                foundNode.RightChild = null;
            }
            else if (foundNode.LeftChild != null && foundNode.RightChild != null)
            {
                // HARD PART: Find the smallest node in the right branch, move it to the current node.
                var minNode = this.FindMinimumIn(foundNode.RightChild);
                var minValue = minNode.Value;
                this.Delete(minValue);

                foundNode.Value = minValue;
            }
        }
        
        private BinaryTreeNode<T> Search(BinaryTreeNode<T> currentNode, T value)
        {
            if (currentNode == null)
            {
                return null;
            }

            int result = currentNode.Value.CompareTo(value);
            if (result == 0)
            {
                return currentNode;
            }
            else if (result < 0)
            {
                return this.Search(currentNode.RightChild, value);
            }
            else
            {
                return this.Search(currentNode.LeftChild, value);
            }
        }

        private BinaryTreeNode<T> InsertUnder(BinaryTreeNode<T> currentNode, T value)
        {
            if (currentNode == null)
            {
                throw new ArgumentNullException("currentNode");
            }

            int result = currentNode.Value.CompareTo(value);
            if (result == 0)
            {
                throw new ArgumentException("The value already exists in the tree.");
            }
            else if (result < 0)
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = new BinaryTreeNode<T>(value, currentNode);
                    return currentNode.RightChild;
                }
                else
                {
                    return this.InsertUnder(currentNode.RightChild, value);
                }
            }
            else
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = new BinaryTreeNode<T>(value, currentNode);
                    return currentNode.LeftChild;
                }
                else
                {
                    return this.InsertUnder(currentNode.LeftChild, value);
                }
            }
        }

        private BinaryTreeNode<T> FindMinimumIn(BinaryTreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                throw new ArgumentNullException("currentNode");
            }

            BinaryTreeNode<T> minNode = currentNode;
            if (minNode.LeftChild == null)
            {
                return minNode;
            }
            else
            {
                return this.FindMinimumIn(minNode.LeftChild);
            }
        }

        #region Inorder predecessor and successor for a given key in BST
        /// <summary>
        /// http://www.geeksforgeeks.org/inorder-predecessor-successor-given-key-bst/
        /// There is BST given with root node with key part as integer only. 
        /// You need to find the inorder successor and predecessor of a given key. 
        /// In case the given key is not found in BST, then return the two values within which this key will lie.
        /// Note: The tree cannot contain zero because use of default(T).
        /// 
        /// Algorithm: 
        /// 1. Use binary search trying to locate the target. Record lower bound (potential precessor) and upper bound (potential successor)
        ///    along the search path.
        /// 2. If the value is found: 
        /// 2.1. If the found node has left child, the precessor must be the most right leaf of the left substree. Otherwise, the precessor is the lower bound.
        /// 2.2. If the found node has right child, the successor must be the most left leaf of the right substree. Otherwise, the successor is the upper bound.
        /// 3. If the value is not found:
        /// 3.1 Return lower bound as precessor and upper bound as successor.
        /// Time: O(logn)
        /// Space: O(1)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predecessor"></param>
        /// <param name="successor"></param>
        public void FindInOrderNeighbours(T value, out T predecessor, out T successor)
        {
            FindInOrderNeighbours(this.Root, value, default(T), default(T), out predecessor, out successor);
        }

        private void FindInOrderNeighbours(BinaryTreeNode<T> currentNode, T value, T lowerBound, T upperBound, out T predecessor, out T successor)
        {
            predecessor = default(T);
            successor = default(T);

            if (currentNode == null)
            {
                return;
            }

            int comparison = currentNode.Value.CompareTo(value);
            if (comparison == 0)
            {
                predecessor = this.FindPredecessor(currentNode, lowerBound);
                successor = this.FindSuccessor(currentNode, upperBound);
            }
            else if (comparison > 0)
            {
                // Search in left branch
                upperBound = currentNode.Value;
                if (currentNode.LeftChild != null)
                {
                    FindInOrderNeighbours(currentNode.LeftChild, value, lowerBound, upperBound, out predecessor, out successor);
                }
                else
                {
                    // No match
                    predecessor = lowerBound;
                    successor = upperBound;
                }
            }
            else
            {
                // Search in right branch
                lowerBound = currentNode.Value;
                if (currentNode.RightChild != null)
                {
                    FindInOrderNeighbours(currentNode.RightChild, value, lowerBound, upperBound, out predecessor, out successor);
                }
                else
                {
                    // No match
                    predecessor = lowerBound;
                    successor = upperBound;
                }
            }
        }

        private T FindPredecessor(BinaryTreeNode<T> currentNode, T lowerBound)
        {
            if (currentNode.LeftChild != null)
            {
                return FindMaxInSubtree(currentNode.LeftChild);
            }
            else
            {
                return lowerBound;
            }
        }

        private T FindMaxInSubtree(BinaryTreeNode<T> currentNode)
        {
            if (currentNode.RightChild != null)
            {
                return FindMaxInSubtree(currentNode.RightChild);
            }
            else
            {
                return currentNode.Value;
            }
        }

        private T FindSuccessor(BinaryTreeNode<T> currentNode, T upperBound)
        {
            if (currentNode.RightChild != null)
            {
                return FindMinInSubtree(currentNode.RightChild);
            }
            else
            {
                return upperBound;
            }
        }

        /// <summary>
        /// http://www.geeksforgeeks.org/find-the-minimum-element-in-a-binary-search-tree/
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private T FindMinInSubtree(BinaryTreeNode<T> currentNode)
        {
            if (currentNode.LeftChild != null)
            {
                return FindMinInSubtree(currentNode.LeftChild);
            }
            else
            {
                return currentNode.Value;
            }
        }

        #endregion

        #region Two nodes of a BST are swapped, correct the BST
        /// <summary>
        /// http://www.geeksforgeeks.org/fix-two-swapped-nodes-of-bst/
        /// Algorithm:  Since inorder traversal of BST is always a sorted array, the problem can be reduced to a problem 
        /// where two elements of a sorted array are swapped. There are two cases that we need to handle:
        /// 1. The swapped nodes are not adjacent in the inorder traversal of the BST.
        /// 2. The swapped nodes are adjacent in the inorder traversal of BST.
        /// </summary>
        public void CorrectSwappedNodes()
        {
            // Generate in-order list
            var traversal = new List<BinaryTreeNode<T>>();
            this.TraverseInOrder(this.Root, traversal);

            // Find swapped nodes and correct them.
            BinaryTreeNode<T> firstNode = null;
            BinaryTreeNode<T> nodeAfterFirstNode = null;
            BinaryTreeNode<T> secondNode = null;
            BinaryTreeNode<T> previousNode = null;

            foreach(var currentNode in traversal)
            {
                if (previousNode != null)
                {
                    if (currentNode.Value.CompareTo(previousNode.Value) < 0)
                    {
                        if (firstNode == null)
                        {
                            firstNode = previousNode;
                            nodeAfterFirstNode = currentNode;
                        }
                        else
                        {
                            secondNode = currentNode;
                            break;
                        }
                    }
                }

                previousNode = currentNode;
            }

            if (firstNode != null)
            {
                if (secondNode != null)
                {
                    T temp = firstNode.Value;
                    firstNode.Value = secondNode.Value;
                    secondNode.Value = temp;
                }
                else
                {
                    T temp = firstNode.Value;
                    firstNode.Value = nodeAfterFirstNode.Value;
                    nodeAfterFirstNode.Value = temp;
                }
            }
        }

        private void TraverseInOrder(BinaryTreeNode<T> currentNode, List<BinaryTreeNode<T>> traversal)
        {
            if (currentNode != null)
            {
                this.TraverseInOrder(currentNode.LeftChild, traversal);
                traversal.Add(currentNode);
                this.TraverseInOrder(currentNode.RightChild, traversal);
            }
        }

        #endregion
    }
}

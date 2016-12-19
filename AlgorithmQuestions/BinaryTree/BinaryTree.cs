using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class BinaryTree<T> where T: IComparable
    {
        public BinaryTreeNode<T> Root { get; set; }

        public BinaryTree(BinaryTreeNode<T> root)
        {
            this.Root = root;
        }

        public BinaryTree(): this(null)
        {
        }

        /// <summary>
        /// In this implementation: Breadth-first traversal uses a queue, no recursion.
        /// Space complexity: O(n/2)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BinaryTreeNode<T>> TraverseBreadthFirst()
        {
            var queue = new Queue<BinaryTreeNode<T>>();
            var traversal = new List<BinaryTreeNode<T>>();

            if (this.Root != null)
            {
                queue.Enqueue(this.Root);
                while(queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    traversal.Add(current);
                    
                    if (current.LeftChild != null)
                    {
                        queue.Enqueue(current.LeftChild);
                    }

                    if (current.RightChild != null)
                    {
                        queue.Enqueue(current.RightChild);
                    }
                }
            }

            return traversal;
        }

        public IEnumerable<BinaryTreeNode<T>> TraverseDepthFirstPreOrder()
        {
            var traversal = new List<BinaryTreeNode<T>>();
            TraverseDepthFirst(this.Root, traversal, TraversalOrder.PreOrder);
            return traversal;
        }

        public IEnumerable<BinaryTreeNode<T>> TraverseDepthFirstInOrder()
        {
            var traversal = new List<BinaryTreeNode<T>>();
            TraverseDepthFirst(this.Root, traversal, TraversalOrder.InOrder);
            return traversal;
        }

        public IEnumerable<BinaryTreeNode<T>> TraverseDepthFirstPostOrder()
        {
            var traversal = new List<BinaryTreeNode<T>>();
            TraverseDepthFirst(this.Root, traversal, TraversalOrder.PostOrder);
            return traversal;
        }

        private void TraverseDepthFirst(BinaryTreeNode<T> current, List<BinaryTreeNode<T>> history, TraversalOrder order)
        {
            if (current == null)
            {
                return;
            }

            switch(order)
            {
                case TraversalOrder.PreOrder:
                    history.Add(current);
                    this.TraverseDepthFirst(current.LeftChild, history, order);
                    this.TraverseDepthFirst(current.RightChild, history, order);
                    break;

                case TraversalOrder.InOrder:
                    this.TraverseDepthFirst(current.LeftChild, history, order);
                    history.Add(current);
                    this.TraverseDepthFirst(current.RightChild, history, order);
                    break;

                case TraversalOrder.PostOrder:
                    this.TraverseDepthFirst(current.LeftChild, history, order);
                    this.TraverseDepthFirst(current.RightChild, history, order);
                    history.Add(current);
                    break;
            }
        }

        /// <summary>
        /// Assuming no duplicate values.
        /// Inorder sequence: D B E A F C
        /// Preorder sequence: A B D E C F
        /// In a Preorder sequence, leftmost element is the root of the tree. So we know ‘A’ is root for given sequences. 
        /// By searching ‘A’ in Inorder sequence, we can find out all elements on left side of ‘A’ are in left subtree and elements on right are in right subtree.
        /// We recursively follow above steps and get the following tree.
        /// </summary>
        /// <param name="inOrderTraversal"></param>
        /// <param name="preOrderTraversal"></param>
        /// <returns></returns>
        public static BinaryTree<T> Reconstruct(IEnumerable<BinaryTreeNode<T>> inOrderTraversal, IEnumerable<BinaryTreeNode<T>> preOrderTraversal)
        {
            CommonUtility.ThrowIfNull(inOrderTraversal);
            CommonUtility.ThrowIfNull(preOrderTraversal);
            if (inOrderTraversal.Count() != preOrderTraversal.Count())
            {
                throw new ArgumentException("Two traversals must contain the same numbers of nodes.");
            }

            BinaryTree<T> tree = new BinaryTree<T>();
            if (inOrderTraversal.Count() == 0)
            {
                return tree;
            }

            // Convert travesal into value array 
            T[] inOrder = new T[inOrderTraversal.Count()];
            int inOrderIndex = -1;
            foreach(var node in inOrderTraversal)
            {
                inOrderIndex++;
                inOrder[inOrderIndex] = node.Value;
            }

            T[] preOrder = new T[preOrderTraversal.Count()];
            int preOrderIndex = -1;
            foreach (var node in preOrderTraversal)
            {
                preOrderIndex++;
                preOrder[preOrderIndex] = node.Value;
            }

            tree.Root = ReconstructNode(inOrder, 0, inOrder.Length - 1, preOrder, 0, preOrder.Length - 1, null);
            return tree;
        }

        private static BinaryTreeNode<T> ReconstructNode(T[] inOrder, int inOrderStartIndex, int inOrderEndIndex, T[] preOrder, int preOrderStartIndex, int preOrderEndIndex, BinaryTreeNode<T> parent)
        {
            var currentNode = new BinaryTreeNode<T>(preOrder[preOrderStartIndex]);
            if (parent != null)
            {
                currentNode.Parent = parent;
            }

            int parentInOrderIndex = FindNode(inOrder, inOrderStartIndex, inOrderEndIndex, currentNode.Value);

            // Reconstruct left child
            if (parentInOrderIndex > inOrderStartIndex)
            {
                var left = ReconstructNode(inOrder, inOrderStartIndex, parentInOrderIndex - 1, preOrder, preOrderStartIndex + 1, parentInOrderIndex - inOrderStartIndex + preOrderStartIndex, currentNode);
                currentNode.LeftChild = left;
            }

            // Reconstruct right child
            if (parentInOrderIndex < inOrderEndIndex)
            {
                var right = ReconstructNode(inOrder, parentInOrderIndex + 1, inOrderEndIndex, preOrder, preOrderEndIndex - (inOrderEndIndex - parentInOrderIndex) + 1, preOrderEndIndex, currentNode);
                currentNode.RightChild = right;
            }

            return currentNode;
        }

        private static int FindNode(T[] values, int startIndex, int endIndex, T targetValue)
        {
            for(int i = startIndex; i <= endIndex; i++)
            {
                if (values[i].CompareTo(targetValue) == 0)
                {
                    return i;
                }
            }

            throw new InvalidOperationException("Value not found.");
        }
    }
}

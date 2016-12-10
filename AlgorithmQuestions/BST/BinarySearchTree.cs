using System;

namespace AlgorithmQuestions
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTreeNode<T> Root { get; set; }

        public BinarySearchTree(BinarySearchTreeNode<T> root)
        {
            this.Root = root;
        }

        public BinarySearchTree(): this(null)
        {
        }

        public BinarySearchTreeNode<T> Search(T value)
        {
            return this.Search(this.Root, value);
        }

        public BinarySearchTreeNode<T> Insert(T value)
        {
            if (this.Root == null)
            {
                this.Root = new BinarySearchTreeNode<T>(value);
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

        private BinarySearchTreeNode<T> Search(BinarySearchTreeNode<T> currentNode, T value)
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

        private BinarySearchTreeNode<T> InsertUnder(BinarySearchTreeNode<T> currentNode, T value)
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
                    currentNode.RightChild = new BinarySearchTreeNode<T>(value, currentNode);
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
                    currentNode.LeftChild = new BinarySearchTreeNode<T>(value, currentNode);
                    return currentNode.LeftChild;
                }
                else
                {
                    return this.InsertUnder(currentNode.LeftChild, value);
                }
            }
        }

        private BinarySearchTreeNode<T> FindMinimumIn(BinarySearchTreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                throw new ArgumentNullException("currentNode");
            }

            BinarySearchTreeNode<T> minNode = currentNode;
            if (minNode.LeftChild == null)
            {
                return minNode;
            }
            else
            {
                return this.FindMinimumIn(minNode.LeftChild);
            }
        }
    }
}

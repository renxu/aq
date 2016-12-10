using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class BinarySearchTreeNode<T> where T : IComparable
    {
        public T Value { get; set; }

        public BinarySearchTreeNode<T> Parent { get; set; }

        public BinarySearchTreeNode<T> LeftChild { get; set; }

        public BinarySearchTreeNode<T> RightChild { get; set; }

        public BinarySearchTreeNode(T value, BinarySearchTreeNode<T> parent)
        {
            this.Value = value;
            this.Parent = parent;
        }

        public BinarySearchTreeNode(T value): this(value, null)
        {
        }
    }
}

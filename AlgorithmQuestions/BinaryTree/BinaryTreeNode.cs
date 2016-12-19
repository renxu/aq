using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Value { get; set; }

        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public BinaryTreeNode(T value, BinaryTreeNode<T> parent)
        {
            this.Value = value;
            this.Parent = parent;
        }

        public BinaryTreeNode(T value): this(value, null)
        {
        }
    }
}

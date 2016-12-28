using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class HuffmanTreeNode: IComparable
    {
        public HuffmanTreeNode(int frequency, char character)
        {
            this.Character = character;
            this.Frequency = frequency;
            this.IsLeaf = true;
        }

        public HuffmanTreeNode(HuffmanTreeNode leftChild, HuffmanTreeNode rightChild)
        {
            this.Frequency = leftChild.Frequency + rightChild.Frequency;
            this.IsLeaf = false;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public bool IsLeaf { get; set; }

        public char Character { get; set; }

        public int Frequency { get; set; }

        public HuffmanTreeNode LeftChild { get; set; }

        public HuffmanTreeNode RightChild { get; set; }

        public int CompareTo(object obj)
        {
            CommonUtility.ThrowIfNull(obj);
            return this.Frequency.CompareTo(((HuffmanTreeNode)obj).Frequency);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/greedy-algorithms-set-3-huffman-coding/
    /// </summary>
    public class HuffmanTree
    {
        private HuffmanTree()
        {
        }

        public HuffmanTreeNode Root { get; set; }

        /// <summary>
        /// See OneNote for algorithm.
        /// </summary>
        /// <param name="input">Input is array of unique characters along with their frequency of occurrences.</param>
        /// <returns>The root of the result Huffman tree.</returns>
        public static HuffmanTree Create(IEnumerable<HuffmanTreeNode> input)
        {
            CommonUtility.ThrowIfNull(input);
            if (input.Count() == 0)
            {
                throw new ArgumentException();
            }

            var heap = new MinHeap<HuffmanTreeNode>(input);

            while(heap.GetCount() > 1)
            {
                var node1 = heap.Extract();
                var node2 = heap.Extract();
                var newNonLeaf = new HuffmanTreeNode(node1, node2);
                heap.Insert(newNonLeaf);
            }

            var tree = new HuffmanTree();
            tree.Root = heap.Peak();
            return tree;
        }

        public void PrintCodes()
        {
            this.PrintCodes(this.Root, string.Empty);
        }

        private void PrintCodes(HuffmanTreeNode node, string code)
        {
            if(node == null)
            {
                return;
            }

            if (node.IsLeaf)
            {
                Console.WriteLine(string.Format("{0} {1}", node.Character, code));
            }
            else
            {
                this.PrintCodes(node.LeftChild, code + "0");
                this.PrintCodes(node.RightChild, code + "1");
            }
        }
    }
}

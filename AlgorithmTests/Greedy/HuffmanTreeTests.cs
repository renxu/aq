using System;
using System.Collections.Generic;
using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class HuffmanTreeTests
    {
        [TestMethod]
        public void HuffmanTree_CreateAndPrint_Basic()
        {
            var input = new List<HuffmanTreeNode>();
            input.Add(new HuffmanTreeNode(5, 'a'));
            input.Add(new HuffmanTreeNode(9, 'b'));
            input.Add(new HuffmanTreeNode(12, 'c'));
            input.Add(new HuffmanTreeNode(13, 'd'));
            input.Add(new HuffmanTreeNode(16, 'e'));
            input.Add(new HuffmanTreeNode(45, 'f'));
            var tree = HuffmanTree.Create(input);
            tree.PrintCodes();
            Console.WriteLine("Examine the results manually.");
            /*
            f 0
            c 100
            d 101
            a 1100
            b 1101
            e 111
            */
        }
    }
}

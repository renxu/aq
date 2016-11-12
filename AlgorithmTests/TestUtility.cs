using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    public static class TestUtility
    {
        public static void AssertSortAscResult(int[] inputs, int[] outputs)
        {
            if (inputs == null)
            {
                Assert.IsNull(outputs);
                return;
            }

            Assert.AreEqual(inputs.Length, outputs.Length, "Length is wrong.");

            bool[] hits = new bool[inputs.Length];
            for (int i = 0; i < outputs.Length; i++)
            {
                if (i < outputs.Length - 1)
                {
                    Assert.IsTrue(outputs[i] <= outputs[i + 1], "Wrong sorting.");
                }

                bool hit = false;
                for (int j = 0; j < inputs.Length; j++)
                {
                    if (!hits[j] && outputs[i] == inputs[j])
                    {
                        hit = true;
                        hits[j] = true;
                        break;
                    }
                }

                Assert.IsTrue(hit, string.Format("The number is not from the original array or occurs too many times: {0}.", outputs[i]));
            }
        }
    }
}

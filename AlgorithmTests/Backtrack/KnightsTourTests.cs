using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class KnightsTourTests
    { 

        [TestMethod]
        public void KnightsTour_Go()
        {
            var tour = new KnightsTour(8);
            tour.Go(0, 0);
        }
    }
}
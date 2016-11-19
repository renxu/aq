using AlgorithmQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class RatInMazeTests
    { 

        [TestMethod]
        public void RatInMaze_Run()
        {
            int[,] maze =
            {
                { 1, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 1, 1, 1, 0, 0 },
                { 1, 1, 1, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 1, 0, 1 },
                { 1, 1, 1, 1, 0, 0, 1 },
                { 0, 0, 0, 1, 1, 1, 1 },
            };
            var ratInMaze = new RatInMaze(maze);

            // Expected output: (0,0) (1,0) (2,0) (2,1) (2,2) (1,2) (1,3) (1,4) (2,4) (3,4) (3,3) (4,3) (5,3) (5,4) (5,5) (5,6)
            ratInMaze.Run();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/backttracking-set-2-rat-in-a-maze/
    /// </summary>
    public class RatInMaze
    {
        public const int CellBlocked = 0;
        public const int CellOpen = 1;
        public const int CellPassed = 2;

        private IList<Tuple<int, int>> moves;

        public int[,] Maze { get; set; }

        // Start from left top to right bottom.
        public RatInMaze(int[,] maze)
        {
            CommonUtility.ThrowIfNull(maze);

            if (maze.GetLength(0) == 0 || maze.GetLength(1) == 0)
            {
                throw new ArgumentException();
            }

            this.Maze = maze;
            this.moves = new List<Tuple<int, int>>();
        }

        public void Run()
        {
            Move(0, 0);
        }

        private void Move(int positionX, int positionY)
        {
            // Return if blocked.
            if (this.Maze[positionX, positionY] == CellBlocked || this.Maze[positionX, positionY] == CellPassed)
            {
                return;
            }

            // Make the move.
            this.Maze[positionX, positionY] = CellPassed;
            this.moves.Add(new Tuple<int, int>(positionX, positionY));

            if (positionX == this.Maze.GetLength(0) - 1
                && positionY == this.Maze.GetLength(1) - 1)
            {
                PrintPath();
                return;
            }

            IList<Tuple<int, int>> nextMoves = FindNextMoves(positionX, positionY);
            foreach(var nextMove in nextMoves)
            {
                this.Move(nextMove.Item1, nextMove.Item2);
            }

            // Backtrack
            this.Maze[positionX, positionY] = CellOpen;
            this.moves.RemoveAt(this.moves.Count - 1);
        }

        private IList<Tuple<int, int>> FindNextMoves(int positionX, int positionY)
        {
            var nextMoves = new List<Tuple<int, int>>();
            TryAddNextMove(positionX + 1, positionY, nextMoves);
            TryAddNextMove(positionX, positionY + 1, nextMoves);
            TryAddNextMove(positionX - 1, positionY, nextMoves);
            TryAddNextMove(positionX, positionY - 1, nextMoves);
            return nextMoves;
        }

        private void TryAddNextMove(int positionX, int positionY, List<Tuple<int, int>> nextMoves)
        {
            if (positionX >= 0 
                && positionY >= 0
                && positionX < this.Maze.GetLength(0)
                && positionY < this.Maze.GetLength(1))
            {
                nextMoves.Add(new Tuple<int, int>(positionX, positionY));
            }
        }

        private void PrintPath()
        {
            var result = new StringBuilder();
            foreach (var move in this.moves)
            {
                result.Append(string.Format("({0},{1}) ", move.Item1, move.Item2));
            }

            Console.WriteLine(result.ToString());
        }
    }
}

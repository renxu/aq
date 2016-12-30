using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/backtracking-set-1-the-knights-tour-problem/
    /// </summary>
    public class KnightsTour
    {
        public int ChessSize { get; set; }

        private bool[,] map;
        private List<Tuple<int, int>> moves;

        public KnightsTour(int chessSize)
        {
            this.ChessSize = chessSize;
            this.map = new bool[this.ChessSize, this.ChessSize];
            this.moves = new List<Tuple<int, int>>();
        }

        // Knight's moves: https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Chessboard480.svg/208px-Chessboard480.svg.png
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPositionX">From left to right is 0 to 7.</param>
        /// <param name="startPositionY">From top to down is 0 to 7.</param>
        public void Go(int startPositionX, int startPositionY)
        {
            Move(startPositionX, startPositionY);
        }

        private void Move(int positionX, int positionY)
        {
            // Already visited
            if (this.map[positionX, positionY])
            {
                return;
            }

            // Make the move
            this.map[positionX, positionY] = true;
            moves.Add(new Tuple<int, int>(positionX, positionY));

            // Finished!
            if (this.moves.Count == this.ChessSize * this.ChessSize)
            {
                Print(this.moves);
                return;
            }

            // Find the next moves, and try them one by one.
            var nextMoves = FindNextMoves(positionX, positionY);
            foreach (var nextMove in nextMoves)
            {
                Move(nextMove.Item1, nextMove.Item2);
            }

            // Undo the move
            this.map[positionX, positionY] = false;
            moves.RemoveAt(moves.Count - 1);
        }

        private IList<Tuple<int, int>> FindNextMoves(int currentPositionX, int currentPositionY)
        {
            var nextMoves = new List<Tuple<int, int>>();
            TryAddNextMove(nextMoves, currentPositionX + 1, currentPositionY - 2);
            TryAddNextMove(nextMoves, currentPositionX + 2, currentPositionY - 1);
            TryAddNextMove(nextMoves, currentPositionX + 2, currentPositionY + 1);
            TryAddNextMove(nextMoves, currentPositionX + 1, currentPositionY + 2);
            TryAddNextMove(nextMoves, currentPositionX - 1, currentPositionY + 2);
            TryAddNextMove(nextMoves, currentPositionX - 2, currentPositionY + 1);
            TryAddNextMove(nextMoves, currentPositionX - 2, currentPositionY - 1);
            TryAddNextMove(nextMoves, currentPositionX - 1, currentPositionY - 2);

            return nextMoves;
        }

        private void TryAddNextMove(List<Tuple<int, int>> nextMoves, int nextPositionX, int nextPositionY)
        {
            if (nextPositionX >= 0 && nextPositionX < this.ChessSize && nextPositionY >= 0 && nextPositionY < this.ChessSize)
            {
                nextMoves.Add(new Tuple<int, int>(nextPositionX, nextPositionY));
            }
        }

        private static void Print(List<Tuple<int, int>> moves)
        {
            var result = new StringBuilder();
            foreach(var move in moves)
            {
                result.Append(string.Format("({0},{1}) ", move.Item1, move.Item2));
            }

            Console.WriteLine(result.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    public class JobAssignment
    {
        private int[,] costMatrix;
        private int assignedJobBitMap;
        private int minTotalCost;
        private List<int> assignedJobPath;

        public JobAssignment(int[,] costMatrix)
        {
            CommonUtility.ThrowIfNull(costMatrix);

            if (costMatrix.GetLength(0) == 0
                || costMatrix.GetLength(0) != costMatrix.GetLength(1))
            {
                throw new ArgumentException();
            }

            this.costMatrix = costMatrix;
        }

        public int FindMinCostByBacktrack()
        {
            minTotalCost = int.MaxValue;
            assignedJobPath = new List<int>();
            assignedJobBitMap = 0;
            AssignRemainingJobsByByBacktrack(0);

            return minTotalCost;
        }

        private void AssignRemainingJobsByByBacktrack(int currentTotalCost)
        {
            for (int jobIndex = 0; jobIndex < costMatrix.GetLength(1); jobIndex++)
            {
                if (!CommonUtility.IsMarked(assignedJobBitMap, jobIndex))
                {
                    int newTotalCost = currentTotalCost + costMatrix[assignedJobPath.Count, jobIndex];
                    if (assignedJobPath.Count == costMatrix.GetLength(1) - 1)
                    {
                        // All jobs are assigned
                        minTotalCost = Math.Min(minTotalCost, newTotalCost);
                    }
                    else if (newTotalCost < minTotalCost)
                    {
                        // If the total cost is already greater than or equal to min total cost. No need to continue this path.
                        assignedJobPath.Add(jobIndex);
                        assignedJobBitMap = CommonUtility.Flip(assignedJobBitMap, jobIndex);

                        AssignRemainingJobsByByBacktrack(newTotalCost);

                        assignedJobPath.RemoveAt(assignedJobPath.Count - 1);
                        assignedJobBitMap = CommonUtility.Flip(assignedJobBitMap, jobIndex);
                    }
                }
            }
        }

        /// <summary>
        /// 1. Find a good solution (may not best) by greedy algorithm.
        /// 1.1 Among unassigned jobs, pick the best job for worker A.
        /// 1.2 Repeat for woker B, C, D...
        /// 1.3 Calculate the total cost. 
        /// 2. When reaching a node, only continue when its best possible solution (i.e. lower bound) is better the current best.
        /// 3. When reaching a new solution, compare it with the current best, replace it if it's better.
        /// </summary>
        /// <returns></returns>
        public int FindMinCostByBranchBound()
        {
            throw new NotImplementedException();
        }
    }
}

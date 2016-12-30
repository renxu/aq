using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/branch-bound-set-4-job-assignment-problem/
    /// The implementation don't remember the best assignments, only the min cost.
    /// </summary>
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
            // Find a job for the next worker
            for (int jobIndex = 0; jobIndex < costMatrix.GetLength(1); jobIndex++)
            {
                if (!CommonUtility.IsMarked(assignedJobBitMap, jobIndex))
                {
                    int newTotalCost = currentTotalCost + costMatrix[assignedJobPath.Count, jobIndex];
                    assignedJobPath.Add(jobIndex);
                    assignedJobBitMap = CommonUtility.Flip(assignedJobBitMap, jobIndex);

                    if (assignedJobPath.Count == costMatrix.GetLength(1))
                    {
                        // All jobs are assigned
                        minTotalCost = Math.Min(minTotalCost, newTotalCost);
                    }
                    else if (newTotalCost < minTotalCost)
                    {
                        // Continue the path
                        AssignRemainingJobsByByBacktrack(newTotalCost);
                    }
                    else
                    {
                        // do nothing
                        // If the total cost is already greater than or equal to min total cost. No need to continue this path.
                    }

                    assignedJobPath.RemoveAt(assignedJobPath.Count - 1);
                    assignedJobBitMap = CommonUtility.Flip(assignedJobBitMap, jobIndex);
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
            minTotalCost = int.MaxValue;
            assignedJobPath = new List<int>();
            assignedJobBitMap = 0;

            FindGoodSolutionByGreedy();
            AssignRemainingJobsByByBranchBound(0);

            return minTotalCost;
        }

        private void AssignRemainingJobsByByBranchBound(int currentTotalCost)
        {
            int lowerBoundCost = FindLowerBoundCost(currentTotalCost);
            if (minTotalCost <= lowerBoundCost)
            {
                return;
            }

            // Find a job for the next worker
            for (int jobIndex = 0; jobIndex < costMatrix.GetLength(1); jobIndex++)
            {
                if (!CommonUtility.IsMarked(assignedJobBitMap, jobIndex))
                {
                    int newTotalCost = currentTotalCost + costMatrix[assignedJobPath.Count, jobIndex];
                    assignedJobPath.Add(jobIndex);
                    assignedJobBitMap = CommonUtility.Flip(assignedJobBitMap, jobIndex);

                    if (assignedJobPath.Count == costMatrix.GetLength(1))
                    {
                        // All jobs are assigned
                        minTotalCost = Math.Min(minTotalCost, newTotalCost);
                    }
                    else if (newTotalCost < minTotalCost)
                    {
                        // Continue the path
                        AssignRemainingJobsByByBranchBound(newTotalCost);
                    }
                    else
                    {
                        // do nothing
                        // If the total cost is already greater than or equal to min total cost. No need to continue this path.
                    }

                    assignedJobBitMap = CommonUtility.Flip(assignedJobBitMap, jobIndex);
                    assignedJobPath.RemoveAt(assignedJobPath.Count - 1);
                }
            }
        }

        private void FindGoodSolutionByGreedy()
        {
            int totalCost = 0;
            for (int workerIndex = 0; workerIndex < this.costMatrix.GetLength(0); workerIndex++)
            {
                int minJobIndex = -1;
                int minJobCost = this.FindMinJobPerWorker(workerIndex, out minJobIndex);

                totalCost += minJobCost;
                assignedJobBitMap = CommonUtility.Flip(assignedJobBitMap, minJobIndex);
            }

            this.minTotalCost = totalCost;
            this.assignedJobBitMap = 0;
        }

        private int FindLowerBoundCost(int currentTotalCost)
        {
            int totalRemainingCost = 0;
            for (int workerIndex = this.assignedJobPath.Count; workerIndex < this.costMatrix.GetLength(0); workerIndex++)
            {
                int minJobIndex = -1;
                int minJobCost = this.FindMinJobPerWorker(workerIndex, out minJobIndex);
                totalRemainingCost += minJobCost;
            }

            return currentTotalCost + totalRemainingCost;
        }

        private int FindMinJobPerWorker(int workerIndex, out int minJobIndex)
        {
            int minJobCost = int.MaxValue;
            minJobIndex = -1;
            for (int jobIndex = 0; jobIndex < this.costMatrix.GetLength(1); jobIndex++)
            {
                if (!CommonUtility.IsMarked(assignedJobBitMap, jobIndex))
                {
                    if (this.costMatrix[workerIndex, jobIndex] < minJobCost)
                    {
                        minJobCost = this.costMatrix[workerIndex, jobIndex];
                        minJobIndex = jobIndex;
                    }
                }
            }

            return minJobCost;
        }
    }
}

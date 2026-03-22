using System.Collections.Generic;
using MergeGrid.Runtime.Core;

namespace MergeGrid.Runtime.Merge
{
    public class MergeRule
    {
        public int RequiredCount { get; }

        public MergeRule(int requiredCount = 3)
        {
            RequiredCount = requiredCount;
        }

        public List<GridCell> FindMergeCandidates(GridSystem grid, GridCell origin)
        {
            var result = new List<GridCell>();

            if (origin.IsEmpty)
                return result;

            var originItem = origin.Item;

            foreach (var neighbor in grid.GetNeighbors(origin.Position))
            {
                if (!neighbor.IsEmpty && neighbor.Item.Level == originItem.Level)
                {
                    result.Add(neighbor);
                }
            }

            if (result.Count + 1 >= RequiredCount)
                result.Add(origin);

            return result;
        }
    }
}

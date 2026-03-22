using System.Collections.Generic;
using MergeGrid.Runtime.Core;

namespace MergeGrid.Runtime.Merge
{
    public class MergeResult
    {
        public static MergeResult Failed => new MergeResult(false, default, null, null);

        public bool Success { get; }
        public GridPosition Position { get; }
        public GridItem ResultItem { get; }
        public IReadOnlyList<GridCell> ConsumedCells { get; }

        public MergeResult(bool success, GridPosition position, GridItem item, List<GridCell> consumed)
        {
            Success = success;
            Position = position;
            ResultItem = item;
            ConsumedCells = consumed;
        }
    }
}

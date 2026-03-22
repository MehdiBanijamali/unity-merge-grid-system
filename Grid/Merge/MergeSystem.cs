using System.Collections.Generic;
using MergeGrid.Core;

namespace MergeGrid.Merge
{
    public class MergeSystem
    {
        private readonly GridSystem _grid;
        private readonly MergeRule _rule;

        public MergeSystem(GridSystem grid, MergeRule rule)
        {
            _grid = grid;
            _rule = rule;
        }

        public MergeResult TryMerge(GridPosition position)
        {
            var cell = _grid.GetCell(position);
            if (cell == null || cell.IsEmpty)
                return MergeResult.Failed;

            var candidates = _rule.FindMergeCandidates(_grid, cell);

            if (candidates.Count < _rule.RequiredCount)
                return MergeResult.Failed;

            var baseItem = cell.Item;

            foreach (var c in candidates)
                _grid.RemoveItem(c.Position);

            var newItem = new GridItem(baseItem.Id, baseItem.Level + 1);
            _grid.TryPlaceItem(position, newItem);

            return new MergeResult(true, position, newItem, candidates);
        }
    }
}

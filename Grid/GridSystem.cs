
using System.Collections.Generic;

namespace MergeGrid.Runtime.Core
{
    public class GridSystem
    {
        private readonly Dictionary<GridPosition, GridCell> _cells;

        public int Width { get; }
        public int Height { get; }

        public GridSystem(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = new Dictionary<GridPosition, GridCell>();

            Initialize();
        }

        private void Initialize()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var pos = new GridPosition(x, y);
                    _cells[pos] = new GridCell(pos);
                }
            }
        }

        public GridCell GetCell(GridPosition pos)
        {
            return _cells.TryGetValue(pos, out var cell) ? cell : null;
        }

        public bool TryPlaceItem(GridPosition pos, GridItem item)
        {
            var cell = GetCell(pos);
            if (cell == null || !cell.IsEmpty)
                return false;

            cell.SetItem(item);
            return true;
        }

        public GridItem RemoveItem(GridPosition pos)
        {
            var cell = GetCell(pos);
            return cell?.RemoveItem();
        }

        public IEnumerable<GridCell> GetNeighbors(GridPosition pos)
        {
            var directions = new[]
            {
                pos.Up(),
                pos.Down(),
                pos.Left(),
                pos.Right()
            };

            foreach (var p in directions)
            {
                var cell = GetCell(p);
                if (cell != null)
                    yield return cell;
            }
        }

        public IEnumerable<GridCell> AllCells()
        {
            return _cells.Values;
        }
    }
}

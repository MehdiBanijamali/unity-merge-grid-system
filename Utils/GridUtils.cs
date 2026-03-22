using System.Collections.Generic;
using MergeGrid.Runtime.Core;

namespace MergeGrid.Runtime.Utils
{
    public static class GridUtils
    {
        private static readonly GridPosition[] Directions =
        {
            new GridPosition(0, 1),
            new GridPosition(0, -1),
            new GridPosition(1, 0),
            new GridPosition(-1, 0)
        };

        public static IEnumerable<GridPosition> GetCardinalNeighbors(GridPosition position)
        {
            foreach (var dir in Directions)
                yield return position.Offset(dir.X, dir.Y);
        }

        public static bool IsInsideBounds(GridPosition pos, int width, int height)
        {
            return pos.X >= 0 && pos.X < width &&
                   pos.Y >= 0 && pos.Y < height;
        }

        public static int ManhattanDistance(GridPosition a, GridPosition b)
        {
            return System.Math.Abs(a.X - b.X) + System.Math.Abs(a.Y - b.Y);
        }

        public static IEnumerable<GridPosition> GetArea(GridPosition center, int radius)
        {
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    yield return center.Offset(x, y);
                }
            }
        }
    }
}

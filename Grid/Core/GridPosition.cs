using System;

namespace MergeGrid.Runtime.Core
{
    public readonly struct GridPosition : IEquatable<GridPosition>
    {
        public readonly int X;
        public readonly int Y;

        public GridPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static GridPosition Zero => new GridPosition(0, 0);

        public GridPosition Offset(int dx, int dy)
        {
            return new GridPosition(X + dx, Y + dy);
        }

        public GridPosition Up() => Offset(0, 1);
        public GridPosition Down() => Offset(0, -1);
        public GridPosition Left() => Offset(-1, 0);
        public GridPosition Right() => Offset(1, 0);

        public bool Equals(GridPosition other) => X == other.X && Y == other.Y;

        public override bool Equals(object obj) => obj is GridPosition other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(GridPosition a, GridPosition b) => a.Equals(b);
        public static bool operator !=(GridPosition a, GridPosition b) => !a.Equals(b);

        public override string ToString() => $"[{X},{Y}]";
    }
}

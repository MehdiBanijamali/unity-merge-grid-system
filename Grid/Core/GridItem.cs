using MergeGrid.Interfaces;

namespace MergeGrid.Core
{
    public class GridItem : IMergeable
    {
        public int Id { get; }
        public int Level { get; private set; }

        public GridItem(int id, int level)
        {
            Id = id;
            Level = level;
        }

        public bool CanMerge(IMergeable other)
        {
            if (other is not GridItem item)
                return false;

            return item.Level == Level && item.Id == Id;
        }

        public GridItem MergeWith(GridItem other)
        {
            if (!CanMerge(other))
                throw new System.InvalidOperationException("Merge conditions not met");

            return new GridItem(Id, Level + 1);
        }

        IMergeable IMergeable.Merge(IMergeable other)
        {
            return MergeWith((GridItem)other);
        }

        public override string ToString()
        {
            return $"Item(Id:{Id}, Level:{Level})";
        }
    }
}

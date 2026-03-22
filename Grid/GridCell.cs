namespace MergeGrid.Runtime.Core
{
    public class GridCell
    {
        public GridPosition Position { get; }
        public GridItem Item { get; private set; }

        public bool IsEmpty => Item == null;

        public GridCell(GridPosition position)
        {
            Position = position;
        }

        public void SetItem(GridItem item)
        {
            Item = item;
        }

        public GridItem RemoveItem()
        {
            var temp = Item;
            Item = null;
            return temp;
        }

        public override string ToString()
        {
            return IsEmpty
                ? $"Cell {Position} [Empty]"
                : $"Cell {Position} [Level {Item.Level}]";
        }
    }
}

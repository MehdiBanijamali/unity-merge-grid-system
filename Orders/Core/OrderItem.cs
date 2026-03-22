namespace MergeGrid.Orders.Core
{
    public class OrderItem
    {
        public int ItemId { get; }
        public int RequiredAmount { get; }

        private int _currentAmount;

        public int CurrentAmount => _currentAmount;

        public bool IsCompleted => _currentAmount >= RequiredAmount;

        public OrderItem(int itemId, int requiredAmount)
        {
            ItemId = itemId;
            RequiredAmount = requiredAmount;
            _currentAmount = 0;
        }

        public void AddProgress(int amount)
        {
            _currentAmount += amount;
        }

        public override string ToString()
        {
            return $"Item {ItemId}: {_currentAmount}/{RequiredAmount}";
        }
    }
}

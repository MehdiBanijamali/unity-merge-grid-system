using System.Linq;
using MergeGrid.Orders.Data;

namespace MergeGrid.Orders.Core
{
    public class Order
    {
        public OrderDefinition Definition { get; }
        public OrderState State { get; private set; }

        public Order(OrderDefinition definition)
        {
            Definition = definition;
            State = OrderState.Pending;
        }

        public void Start()
        {
            if (State == OrderState.Pending)
                State = OrderState.InProgress;
        }

        public void AddItemProgress(int itemId, int amount)
        {
            if (State != OrderState.InProgress)
                return;

            var item = Definition.RequiredItems.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
                item.AddProgress(amount);
        }

        public bool EvaluateCompletion()
        {
            if (State != OrderState.InProgress)
                return false;

            if (Definition.RequiredItems.All(i => i.IsCompleted))
            {
                State = OrderState.Completed;
                return true;
            }

            return false;
        }

        public void Claim()
        {
            if (State != OrderState.Completed)
                return;

            foreach (var reward in Definition.Rewards)
                reward.Apply();

            State = OrderState.Claimed;
        }
    }
}

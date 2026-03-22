using System.Collections.Generic;
using MergeGrid.Orders.Core;
using MergeGrid.Orders.Interfaces;

namespace MergeGrid.Orders.Data
{
    public class OrderDefinition
    {
        public string Id { get; }
        public string Title { get; }

        public IReadOnlyList<OrderItem> RequiredItems { get; }
        public IReadOnlyList<IOrderReward> Rewards { get; }

        public OrderDefinition(
            string id,
            string title,
            List<OrderItem> requiredItems,
            List<IOrderReward> rewards)
        {
            Id = id;
            Title = title;
            RequiredItems = requiredItems;
            Rewards = rewards;
        }
    }
}

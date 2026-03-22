using System.Collections.Generic;
using MergeGrid.Orders.Core;
using MergeGrid.Orders.Data;

namespace MergeGrid.Orders.Systems
{
    public class OrderSystem
    {
        private readonly Dictionary<string, Order> _orders = new();
        private readonly OrderEvaluator _evaluator = new();

        public void AddOrder(OrderDefinition definition)
        {
            if (_orders.ContainsKey(definition.Id))
                return;

            _orders[definition.Id] = new Order(definition);
        }

        public void StartOrder(string id)
        {
            if (_orders.TryGetValue(id, out var order))
                order.Start();
        }

        public void ReportItemCollected(int itemId, int amount)
        {
            foreach (var order in _orders.Values)
            {
                if (order.State == OrderState.InProgress)
                {
                    order.AddItemProgress(itemId, amount);
                }
            }

            _evaluator.EvaluateAll(new List<Order>(_orders.Values));
        }

        public Order GetOrder(string id)
        {
            return _orders.TryGetValue(id, out var order) ? order : null;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders.Values;
        }
    }
}

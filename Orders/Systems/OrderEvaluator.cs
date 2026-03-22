using System.Collections.Generic;
using MergeGrid.Orders.Core;

namespace MergeGrid.Orders.Systems
{
    public class OrderEvaluator
    {
        public void EvaluateAll(List<Order> orders)
        {
            foreach (var order in orders)
            {
                if (order.State == OrderState.InProgress)
                {
                    order.EvaluateCompletion();
                }
            }
        }
    }
}

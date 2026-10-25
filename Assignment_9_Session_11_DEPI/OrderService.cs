using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_9_Session_11_DEPI
{
    public delegate decimal PriceCalculator(Order order);

    public class OrderService
    {
        public event Action<Order> OrderProcessed;

        public bool ValidateOrder(Order order, Predicate<Order> validationRule)
        {
            return validationRule(order);
        }

        public decimal CalculateOrderPrice(Order order, PriceCalculator calculator)
        {
            return calculator(order);
        }

        public decimal CalculateOrderPrice(Order order, Func<Order, decimal> calculator)
        {
            return calculator(order);
        }

        public void ProcessOrder(Order order, Action<Order> action)
        {
            Console.WriteLine($"[Processing] Order #{order.Id} for {order.CustomerName}...");

            action?.Invoke(order);

            OrderProcessed?.Invoke(order);
        }
    }
}

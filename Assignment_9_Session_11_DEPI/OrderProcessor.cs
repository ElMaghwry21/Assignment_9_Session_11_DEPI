using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_9_Session_11_DEPI
{
    public delegate decimal PriceCalculator(Order order);

    public class OrderProcessor
    {
        public static decimal CalculateTotal(Order order)
        {
            return order.Price * order.Quantity;
        }

        public static decimal CalculateTotalWithDiscount(Order order)
        {
            return (order.Price * order.Quantity) - 10m;
        }

        public static void CalculateOrderPrice(Order order, PriceCalculator calculator)
        {
            decimal total = calculator(order);
            Console.WriteLine($"[Part 1] Order #{order.Id} Total Price: {total:C}");
        }

        public static void CalculateOrderPriceWithFunc(Order order, Func<Order, decimal> calculator)
        {
            decimal total = calculator(order);
            Console.WriteLine($"[Part 2 Func] Total Price: {total:C}");
        }

        public static bool ValidateOrder(Order order, Predicate<Order> validationRule)
        {
            return validationRule(order);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Assignment_9_Session_11_DEPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("       SECTION 01: BOOK LIBRARY SYSTEM     ");
            Console.WriteLine("==========================================");

            List<Book> books = new List<Book>
            {
                new Book("123-456", "C# Advanced", new string[] { "Alice", "Bob" }, new DateTime(2023, 1, 1), 150.0m),
                new Book("789-101", "Design Patterns", new string[] { "Charlie" }, new DateTime(2022, 5, 15), 250.0m)
            };

            Console.WriteLine("\n--- a) User-defined delegate ---");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);

            Console.WriteLine("\n--- b) Built-in delegate (Func) ---");
            Func<Book, string> priceFunc = BookFunctions.GetPrice;
            foreach (var b in books)
            {
                Console.WriteLine(priceFunc(b));
            }

            Console.WriteLine("\n--- c) Anonymous Method (Get ISBN) ---");
            LibraryEngine.ProcessBooks(books, delegate (Book b) {
                return b.ISBN;
            });

            Console.WriteLine("\n--- d) Lambda Expression (Get Publication Date) ---");
            LibraryEngine.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());


            Console.WriteLine("\n==========================================");
            Console.WriteLine("    SECTION 02: ORDER PROCESSING SYSTEM   ");
            Console.WriteLine("==========================================");

            Order order = new Order
            {
                Id = 101,
                CustomerName = "Ahmed Mohamed",
                Price = 200.0m,
                Quantity = 3
            };

            OrderService orderService = new OrderService();

            Console.WriteLine("\n--- Part 3: Predicate Validation ---");
            bool isValidQty = orderService.ValidateOrder(order, o => o.Quantity > 0);
            bool isValidPrice = orderService.ValidateOrder(order, o => o.Price > 0);
            Console.WriteLine($"Is Quantity > 0? {isValidQty}");
            Console.WriteLine($"Is Price > 0? {isValidPrice}");

            Console.WriteLine("\n--- Part 1 & 2: Price Calculation ---");
            decimal total1 = orderService.CalculateOrderPrice(order, o => o.Price * o.Quantity);
            Console.WriteLine($"Total (User Delegate / Lambda): {total1:C}");

            decimal total2 = orderService.CalculateOrderPrice(order, x => (x.Price * x.Quantity) - 25.0m);
            Console.WriteLine($"Total With Discount (Func): {total2:C}");

            Console.WriteLine("\n--- Part 5 & 6: Events & Subscriptions ---");

            Action<Order> Handler1 = o => Console.WriteLine($"[Handler 1] Printing Order #{o.Id} details.");
            Action<Order> Handler2 = o => Console.WriteLine($"[Handler 2] Sending SMS confirmation to {o.CustomerName}.");
            Action<Order> Handler3 = o => Console.WriteLine($"[Handler 3] Writing audit log for Order #{o.Id}.");

            orderService.OrderProcessed += Handler1;
            orderService.OrderProcessed += Handler2;
            orderService.OrderProcessed += Handler3;

            orderService.OrderProcessed -= Handler1;
            Console.WriteLine("(Handler1 unsubscribed)");

            Console.WriteLine("\n--- Part 4 & 7: Process Order Execution Flow ---");
            orderService.ProcessOrder(order, o => Console.WriteLine($"[Action] Order processed successfully. Final Bill: {o.Price * o.Quantity:C}"));
        }
    }

}
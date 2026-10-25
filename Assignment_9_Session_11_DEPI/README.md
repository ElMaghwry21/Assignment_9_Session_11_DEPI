/*
 ==========================================================
            ANSWERS FOR ASSIGNMENT QUESTIONS
 ==========================================================

 Q1: What is the difference between PriceCalculator and Func<Order, decimal>?
 - PriceCalculator is a custom (user-defined) delegate explicitly declared by the developer.
 - Func<Order, decimal> is a built-in generic delegate provided by C#, which saves time and avoids custom declarations.

 Q2: What is the difference between Action<Order> and Func<Order, decimal>?
 - Action<Order> represents a method that takes a parameter and returns void (no return value).
 - Func<Order, decimal> represents a method that takes a parameter and returns a decimal value.

 Q3: Why does Predicate<T> return bool? What kind of problem is it designed to represent?
 - Predicate<T> always returns bool because it is specifically designed for filtering and validation tasks (testing if an object satisfies a specific condition).

 Q4: What is the difference between a delegate and an event?
 - An event is a wrapper around a delegate that provides security by restricting external classes from invoking or clearing the delegate directly, allowing only subscription (+=) and unsubscription (-=).

 Q5: Why can't external code normally invoke an event declared in another class?
 - For security and encapsulation; to prevent external classes from triggering the event arbitrarily. Only the containing class is allowed to invoke it.

 Q6: What happens when multiple handlers subscribe to the same event?
 - It creates a multicast delegate behavior, meaning when the event is raised, all subscribed handlers execute sequentially in order.

 Q7: Explain what this code means: orderService.OrderProcessed += HandleOrderProcessed;
 - It subscribes the method 'HandleOrderProcessed' to the 'OrderProcessed' event using the '+=' operator, so it gets notified when the event fires.

 Q8 (Challenge): Difference between Action<Order> and event Action<Order>?
 - Both use the same underlying type, but using an 'event' keyword restricts access modifiers so external classes can only add/remove handlers, protecting the delegate from being overwritten or invoked from outside.
*/
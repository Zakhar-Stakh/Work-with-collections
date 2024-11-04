using System;
using System.Collections.Generic;

// Клас Order
public class Order
{
    public int OrderId { get; }
    public string CustomerName { get; }
    public string Item { get; }

    public Order(int orderId, string customerName, string item)
    {
        OrderId = orderId;
        CustomerName = customerName;
        Item = item;
    }

    public override string ToString()
    {
        return $"Order ID: {OrderId}, Customer: {CustomerName}, Item: {Item}";
    }
}

// Клас OrderQueue
public class OrderQueue
{
    private Queue<Order> orders = new Queue<Order>();

    // Метод для додавання нового замовлення до черги
    public void AddOrder(Order order)
    {
        orders.Enqueue(order);
        Console.WriteLine($"Order '{order.OrderId}' added to the queue.");
    }

    // Метод для видалення найстаршого замовлення з черги
    public Order RemoveOrder()
    {
        if (orders.Count > 0)
        {
            Order removedOrder = orders.Dequeue();
            Console.WriteLine($"Order '{removedOrder.OrderId}' removed from the queue.");
            return removedOrder;
        }
        Console.WriteLine("No orders in the queue.");
        return null;
    }

    // Метод для отримання найстаршого замовлення з черги без його видалення
    public Order PeekOrder()
    {
        if (orders.Count > 0)
        {
            return orders.Peek();
        }
        Console.WriteLine("No orders in the queue.");
        return null;
    }

    // Метод для виведення на екран інформації про найстарше замовлення у черзі
    public void DisplayFrontOrder()
    {
        Order frontOrder = PeekOrder();
        if (frontOrder != null)
        {
            Console.WriteLine("Front Order:");
            Console.WriteLine(frontOrder);
        }
    }
}

// Клас Main для тестування OrderQueue
class Program
{
    static void Main(string[] args)
    {
        OrderQueue orderQueue = new OrderQueue();

        // Створення замовлень
        Order order1 = new Order(1, "Alice", "Pizza");
        Order order2 = new Order(2, "Bob", "Pasta");
        Order order3 = new Order(3, "Charlie", "Salad");

        // Додавання замовлень до черги
        orderQueue.AddOrder(order1);
        orderQueue.AddOrder(order2);
        orderQueue.AddOrder(order3);

        // Виведення найстаршого замовлення
        orderQueue.DisplayFrontOrder();

        // Видалення замовлення з черги
        orderQueue.RemoveOrder();

        // Виведення найстаршого замовлення після видалення
        orderQueue.DisplayFrontOrder();

        // Видалення ще одного замовлення
        orderQueue.RemoveOrder();

        // Виведення найстаршого замовлення після другого видалення
        orderQueue.DisplayFrontOrder();

        // Видалення останнього замовлення
        orderQueue.RemoveOrder();

        // Спроба виведення найстаршого замовлення, коли черга порожня
        orderQueue.DisplayFrontOrder();
    }
}
using System.Text.Json;

namespace LogisticsApp.Core;

public class OrderRepository :  IOrderRepository
{
    private const string FileName =  "orders.json";
    
    public OrderRepository()
    {
        if (!File.Exists(FileName))
        {
            File.Create(FileName).Close();
            Serialize(new List<Order>());
        }
    }
    
    public Order CreateOrder(Client client, User user, double cost)
    {
        var order = new Order(client, user, cost);
        List<Order> orders = this.GetOrders();
        orders.Add(order);
        Serialize(orders);
        return order;
    }

    public void RemoveOrder(Guid id)
    {
        List<Order> orders = this.GetOrders();
        var order = orders.Find(o => o.Id == id);
        if (order == null)
        { 
            Console.WriteLine($"Order with id {id} was not found");
            return;
        }
        orders.Remove(order);
        Serialize(orders);
    }

    public List<Order> GetOrders()
    {
        string jsonString = File.ReadAllText(FileName);
        var existingOrders = JsonSerializer.Deserialize<List<Order>>(jsonString);
        if (existingOrders == null)
        {
            return  new List<Order>();
        }
        return existingOrders;
    }

    public Order? GetOrder(Guid id)
    {
        return GetOrders().SingleOrDefault(o => o.Id == id);
    }

    public Order UpdateOrder(Order order1)
    {
        var orders = GetOrders();
        var order = orders.SingleOrDefault(o => o.Id == order1.Id);
        if (order == null)
        { 
            Console.WriteLine($"Order with id {order1.Id} was not found");
            return null;
        }
        order.Cost = order1.Cost;
        order.Client = order1.Client;
        order.Manager = order1.Manager;
        order.SetStatus(order1.Status);
        Serialize(orders);
        return order;

    }

    
    
    private static void Serialize(List<Order> orders)
    {
        string json = JsonSerializer.Serialize(orders);
        File.WriteAllText(FileName, json);
    }
    
    
}
using System.Text.Json;

namespace LogisticsApp.Core;

public class OrderService
{
    private IOrderRepository _orderRepository = new OrderRepository();
    public Order CreateOrder(Client client, User user, double cost)
    {
        return _orderRepository.CreateOrder(client, user, cost);
    }

    public List<Order> GetOrders()
    {
        return _orderRepository.GetOrders();
    }
    
    public void RemoveOrder(Guid id)
    {
        _orderRepository.RemoveOrder(id);
    }

    public void ChangeStatus(Guid id, OrderStatus status)
    {
        Order order = _orderRepository.GetOrder(id);
        if (order == null)
        { 
            Console.WriteLine($"Order with id {id} was not found");
            return;
        }
        order.SetStatus(status);
        _orderRepository.UpdateOrder(order);
        
    }

    public void AddDelivery(Guid id, Delivery delivery)
    {
        Order order = _orderRepository.GetOrder(id);
        if (order == null)
        { 
            Console.WriteLine($"Order with id {id} was not found");
            return;
        }
        order.Deliveries.Add(delivery);
    }

   
}
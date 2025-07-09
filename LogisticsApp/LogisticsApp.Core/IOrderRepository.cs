namespace LogisticsApp.Core;

public interface IOrderRepository
{
    Order CreateOrder(Client client, User user, double cost);
    void RemoveOrder(Guid id);
    List<Order> GetOrders();
    Order? GetOrder(Guid id);
    Order UpdateOrder(Order order);
}
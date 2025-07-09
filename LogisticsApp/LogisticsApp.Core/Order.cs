namespace LogisticsApp.Core;

public class Order
{
    public Order(Client client, User manager, double cost)
    {
        Id = Guid.NewGuid();
        Client = client;
        Manager = manager;
        CreatedOn = DateTime.Now;
        Cost = cost;
        Status = OrderStatus.Pending;
    }
    public OrderStatus Status { get; private set; }
    public double Cost { get; set; }

    public Guid Id { get; private set; }
    
    public Client Client { get; set; }
    
    public User Manager { get; set; }
    
    public DateTime CreatedOn { get; private set; }

    public void SetStatus(OrderStatus status)
    {
        Status = status;
    }

    public string GetInfo()
    {
        return
            $"Order {this.Id} from {this.Client.FirstName} {this.Client.LastName} with cost {this.Cost} " +
            $"has been accepted by manager {this.Manager.FirstName} {this.Manager.LastName} on {this.CreatedOn} " +
            $"Status: {this.Status}";
    }
}

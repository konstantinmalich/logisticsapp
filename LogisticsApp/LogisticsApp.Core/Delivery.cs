namespace LogisticsApp.Core;

public class Delivery
{
    public Delivery(DateTime loadingDate, DateTime deliveryDate, string addressOfSender, string addressOfReceiver, TransportCompany transportCompany, Truck truck, double cost, double weight, double lengthInLdm)
    {
        LoadingDate = loadingDate;
        DeliveryDate = deliveryDate;
        AddressOfSender = addressOfSender;
        AddressOfReceiver = addressOfReceiver;
        TransportCompany = transportCompany;
        Truck = truck;
        Cost = cost;
        Weight = weight;
        LengthInLdm = lengthInLdm;
    }

    public DateTime LoadingDate { get; set; }
    
    public DateTime DeliveryDate { get; set; }
    
    public String AddressOfSender { get; set; }
    
    public String AddressOfReceiver { get; set; }
    
    public TransportCompany TransportCompany { get; set; }
    
    public Truck Truck { get; set; }
    
    public double Cost { get; set; }
    
    public double Weight { get; set; }
    
    public double LengthInLdm { get; set; }
}
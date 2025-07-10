namespace LogisticsApp.Core;

public class Truck
{
    public Truck(string brand, TruckType type, double capacity, string plates)
    {
        Brand = brand;
        Type = type;
        Capacity = capacity;
        Plates = plates;
    }

    public string Brand { get; set; }
    
    public TruckType Type { get; set; }
    
    public double Capacity { get; set; }
    
    public string Plates { get; set; }
}
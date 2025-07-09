namespace LogisticsApp.Core;

public class Client
{
    public Client(string firstName, string lastName, string email, string phoneNumber, string address, string accountNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        AccountNumber = accountNumber;
    }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public string AccountNumber { get; set; }
}
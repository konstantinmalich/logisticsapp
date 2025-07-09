using LogisticsApp.Core;
List<User> users = new List<User>();
List<Client> clients = new List<Client>();

var user1 = new User("Hanna", "Praviadzentsava", "h@gmail.com");
users.Add(user1);

var client1 = new Client(
    "Vasiliy",
    "Ivanov", 
    "vasek@mail.ru",
    "88005553535",
    "Minsk",
    "49385030359095");

// Новые пользователи
var user2 = new User("Alex", "Smith", "alex.smith@gmail.com");
users.Add(user2);
var user3 = new User("Maria", "Gomez", "maria.gomez@yahoo.com");
users.Add(user3);
var user4 = new User("Ivan", "Petrov", "ivan.petrov@inbox.ru");
users.Add(user4);
var user5 = new User("Li", "Wang", "li.wang@163.com");
users.Add(user5);

// Новые клиенты
var client2 = new Client("John", "Doe", "john.doe@mail.com", "1234567890", "New York", "12345678901234");
var client3 = new Client("Elena", "Sidorova", "elena@mail.ru", "79876543210", "Moscow", "56789012345678");
var client4 = new Client("Chen", "Lee", "chen.lee@gmail.com", "9876543210", "Beijing", "78901234567890");
var client5 = new Client("Carlos", "Ramirez", "carlos.ramirez@hotmail.com", "5432109876", "Madrid", "89012345678901");

// Сервис заказов
var orderService = new OrderService();

// Создание 10 заказов
// orderService.CreateOrder(client1, user1, 4534);
orderService.CreateOrder(client2, user2, 1001);
orderService.CreateOrder(client3, user3, 2022);
orderService.CreateOrder(client4, user4, 3344);
orderService.CreateOrder(client1, user2, 1234);
orderService.CreateOrder(client2, user3, 5678);
orderService.CreateOrder(client3, user4, 6789);
orderService.CreateOrder(client5, user1, 8901);

var orders = orderService.GetOrders();
int theHihgtestNumberOfOrder = 0;
String name = null;

var usermax = users.MaxBy(user => 
    orders.Count(order => order.Manager.Email == user.Email));

var userWithoutOrders = users.FirstOrDefault(user => orders.Count(order => order.Manager.Email == user.Email) == 0);
Console.WriteLine(usermax.FirstName + " " + usermax.LastName);
Console.WriteLine(userWithoutOrders.FirstName + " " + userWithoutOrders.LastName);

var totalCosts = users.Select(user => orders.Where(order => order.Manager.Email == user.Email).Sum(order => order.Cost));

var latestOrder = orders.MinBy(order => order.CreatedOn);

Console.WriteLine(latestOrder.GetInfo());

var clientOrders = orders.Where(order => order.Client.Email == client1.Email);
void PrintAllOrders(OrderService service)
{
    Console.WriteLine("\r\n");
    var allOrders = service.GetOrders();
    foreach (var order in allOrders)
    {
        Console.WriteLine(order.GetInfo());
    }
}

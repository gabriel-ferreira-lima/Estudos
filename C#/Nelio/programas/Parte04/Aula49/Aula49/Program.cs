using Aula49.Entities;
using Aula49.Entities.Enums;
using System.Globalization;

namespace Aula49 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(nome, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++) {
                Console.WriteLine("Enter #" + i + " item data:");

                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);
                OrderItem item = new OrderItem(quantity, price, product);

                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY");
            Console.WriteLine(order);

            
        }
    }
}

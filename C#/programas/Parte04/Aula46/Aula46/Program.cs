using Aula46.Entities;
using Aula46.Entities.Enums;

namespace Aula46 {
    internal class Program {
        static void Main(string[] args) {

            Order order = new Order() {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };

            Console.WriteLine(order);

            String txt = OrderStatus.PendingPayment.ToString();

            OrderStatus os = Enum.Parse<OrderStatus>("Delivered");

            Console.WriteLine(os);
            Console.WriteLine(txt);
        }
    }
}

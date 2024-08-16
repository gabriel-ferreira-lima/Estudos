using Aula49.Entities.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Aula49.Entities {
    internal class Order {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() {
        }

        public Order(DateTime date, OrderStatus items, Client client) {
            Date = date;
            Status = items;
            Client = client;
        }

        public void AddItem(OrderItem item) {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item) { 
            Items.Remove(item); 
        }

        public double Total() {
            double sum = 0;
            foreach (OrderItem item in Items) {
                sum += item.SubTotal();                
            }
            return sum;
        }

        public override string ToString() { 
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Date.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order Status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Items) {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total Price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}

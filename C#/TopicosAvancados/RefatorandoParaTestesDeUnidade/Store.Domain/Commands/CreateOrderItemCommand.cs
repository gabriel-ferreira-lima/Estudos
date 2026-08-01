using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using System.Diagnostics.Contracts;

namespace Store.Domain.Commands {
    public class CreateOrderItemCommand : Notifiable<Notification>, ICommand {

        public CreateOrderItemCommand() {
        }

        public CreateOrderItemCommand(Guid product, int quantity) {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; }
        public int Quantity { get; }

        public void Validate() {

            AddNotifications(new Contract<Notification>()
                .Requires()
                .AreEquals(Product.ToString(), 32, "Product", "Produto inválido")
                .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade inváliida")
            );
        }
    }
}

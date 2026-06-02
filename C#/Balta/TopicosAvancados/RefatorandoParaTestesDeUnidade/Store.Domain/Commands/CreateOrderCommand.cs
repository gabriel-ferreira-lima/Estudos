using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;


namespace Store.Domain.Commands {
    public class CreateOrderCommand : Notifiable<Notification>, ICommand {

        public CreateOrderCommand() {
            Items = new List<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(string costumer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items) {
            Costumer = costumer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }

        public string Costumer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }

        public void Validate() {

            AddNotifications(new Contract<Notification>()
                .Requires()
                .AreEquals(Costumer, 11, "Costumer", "Cliente inválido")
                .AreEquals(ZipCode, 8, "ZipCode", "CEP inválido")
                .IsGreaterThan(Items.Count, 0, "Items", "Pedido sem itens")
            );
        }
    }
}

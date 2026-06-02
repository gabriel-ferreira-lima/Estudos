using Store.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests.Commands {
    [TestClass]
    public class CreateOrderCommandTests {

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado() {
            var command = new CreateOrderCommand();
            command.Costumer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.IsFalse(command.IsValid);
        }

    }
}

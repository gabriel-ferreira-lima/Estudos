using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities {
    [TestClass]
    public class OrderTests {

        private readonly Costumer _costumer = new Costumer("Gabriel Ferreira Lima", "gabrielfl1997@gmail.com");
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));
        private readonly Product _product = new Product("Camiseta", 10, true);


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres() {
            var order = new Order(_costumer, 10, _discount);

            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento() {
            var order = new Order(_costumer, 10, _discount);
            Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega() {
            var order = new Order(_costumer, 10, _discount);
            order.AddItem(_product, 2);
            var total = 20;
            order.Pay(total);

            Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_status_deve_ser_cancelado() {
            var order = new Order(_costumer, 10, _discount);
            order.Cancel();

            Assert.AreEqual(EOrderStatus.Canceled, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado() {

            var order = new Order(_costumer, 10, _discount);
            order.AddItem(null, 10);

            Assert.IsEmpty(order.Items);

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado() {

            var order = new Order(_costumer, 10, _discount);
            order.AddItem(_product, -2);

            Assert.IsEmpty(order.Items);

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50() {
            var order = new Order(_costumer, 10, _discount);
            order.AddItem(_product, 5);

            Assert.AreEqual(50, order.Total());

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60() {
            var discount = new Discount(50, DateTime.Now.AddDays(-5));
            var order = new Order(_costumer, 10, discount);
            order.AddItem(_product, 5);

            Assert.AreEqual(60, order.Total());

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60() {
            var order = new Order(_costumer, 10, null);
            order.AddItem(_product, 5);

            Assert.AreEqual(60, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50() {
            var order = new Order(_costumer, 0, _discount);
            order.AddItem(_product, 6);

            Assert.AreEqual(50, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60() {
            var order = new Order(_costumer, 10, null);
            order.AddItem(_product, 5);

            Assert.AreEqual(60, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido() {
            var order = new Order(null, 10, _discount);

            Assert.IsFalse(order.IsValid);
        }
    }
}

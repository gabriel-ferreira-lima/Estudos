using Store.Domain.Entities;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests.Repositories {
    public class FakeOrderRepository : IOrderRepository {
        public void Save(Order order) {

        }
    }
}

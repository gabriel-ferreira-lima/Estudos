

using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories {
    public class FakeCostumerRepository : ICostumerRepository {
        public Costumer Get(string document) {
            if (document == "12345678911") {
                return new Costumer("Bruce Wayne", "batman@balta.io");
            }
            return null;
        }
    }
}

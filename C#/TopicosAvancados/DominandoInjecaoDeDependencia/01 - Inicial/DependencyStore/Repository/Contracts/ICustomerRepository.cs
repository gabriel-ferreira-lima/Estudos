using DependencyStore.Models;

namespace DependencyStore.Repository.Contracts {
    public interface ICustomerRepository {
        Task<Customer?> GetByIdAsync(string customerId);
    }
}

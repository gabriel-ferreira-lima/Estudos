using DependencyStore.Repository;
using DependencyStore.Repository.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Extensions {
    public static class DependeciesExtension {

        public static void AddSqlConnection (this IServiceCollection services, string connectionString) {
            services.AddScoped(x => new SqlConnection(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services) {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }

        public static void AddServices(this IServiceCollection services) {
            services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
        }
    }
}

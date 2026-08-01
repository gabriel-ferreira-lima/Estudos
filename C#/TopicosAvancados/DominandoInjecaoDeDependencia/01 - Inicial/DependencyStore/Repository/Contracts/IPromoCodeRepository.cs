using DependencyStore.Models;

namespace DependencyStore.Repository.Contracts {
    public interface IPromoCodeRepository {
        Task<PromoCode?> GetPromoCodeAsync(string promoCode);

    }
}

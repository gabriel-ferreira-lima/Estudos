

using Aula05Exercicios.SharedContext;

namespace Aula05Exercicios.SubscriptionContext {
    internal class Subscription : Base{

        public Plan Plan{ get; set; }
        public DateTime? EndDate{ get; set; }

        public bool IsInactive => EndDate <= DateTime.Now;
    }
}

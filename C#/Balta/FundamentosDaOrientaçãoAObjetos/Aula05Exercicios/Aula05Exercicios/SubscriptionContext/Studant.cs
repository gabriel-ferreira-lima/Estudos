using Aula05Exercicios.NotificationContext;
using Aula05Exercicios.SharedContext;

namespace Aula05Exercicios.SubscriptionContext {
    internal class Studant : Base{

        public Studant()
        {
            Subscriptions = new List<Subscription>();
        }
        public User User{ get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }

        public IList<Subscription> Subscriptions{ get; set; }

        public void CreateSubscription(Subscription subscription) {
            if (IsPremium) {
                AddNotification(new Notification("Premium", "O aluno já tem uma assinatura ativa"));
                return;
            }

            Subscriptions.Add(subscription);
        }
        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);
    }
}

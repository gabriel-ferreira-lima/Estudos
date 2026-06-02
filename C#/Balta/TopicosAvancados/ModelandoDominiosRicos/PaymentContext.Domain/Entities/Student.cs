using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities {
    public class Student : Entity {

        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email) {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; set; }
        public Document Document { get; set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription) {

            var hasSubscriptionsActive = false;
            foreach (var sub in _subscriptions) {
                if(sub.Active)
                    hasSubscriptionsActive = true;
            }

            //AddNotifications(new Contract()
            //    .Requires()
            //    .IsFalse(hasSubscriptionsActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
            //);

            if (hasSubscriptionsActive)
                AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
        }
    }
}
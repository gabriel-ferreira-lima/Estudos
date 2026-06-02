using Flunt.Notifications;

namespace Store.Domain.Entities {
    public class Entity : Notifiable<Notification> {

        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}

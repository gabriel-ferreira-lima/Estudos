using Aula05Exercicios.NotificationContext;

namespace Aula05Exercicios.SharedContext {
    public abstract class Base : Notifiable{

        public Base()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}

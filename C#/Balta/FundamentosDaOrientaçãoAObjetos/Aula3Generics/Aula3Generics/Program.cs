namespace Aula3Generics {
    internal class Program {
        static void Main(string[] args) {
            
            var person = new Person();
            var payment = new Payment();
            var subscription = new Subscription();
            var context = new DataContext<IPerson, Payment, Subscription> ();
            context.Save(person); 
            context.Save(payment);
            context.Save(subscription);
        }
    }
    // DataContext geralmente usado para salvar informações em Banco de dados
    // posso declarar quantos métodos eu quiser normalmente é usado 1 ou 2
    public class DataContext<P, PA, S> 
        // importante colocar esse Wheres para que o compilador saiba qual classe é representada por cada letra
        // é possivel alem de colocar a classe diretamente, uma interface
        where P : IPerson
        where PA : Payment
        where S : Subscription
        {

        // Save para person
        public void Save(P entity) {
            
        }
        // save para payment
        public void Save(PA entity) {

        }
        // save para subscriptiom
        public void Save(S entity) {

        }
    }

    public interface IPerson {

    }

    public class Person : IPerson { }
    public class Payment { }
    public class Subscription { }
}

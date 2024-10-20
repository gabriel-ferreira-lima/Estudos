namespace Aula04Listas {
    internal class Program {
        static void Main(string[] args) {
            /*
            // lista é muito aberta, permite o usuario inserir ou remover itens da lista.
            // o IEnumerable é mais fechado, basicamente só permite ver os itens da lista.
            // ICollection é pouco usado.

            var payments = new List<Payment>();
            var Payments = new IEnumerable<Payment>(); // não consigo instanciar esse pq é uma interface
            var Payments = new ICollection<Payment>(); // não consigo instanciar esse pq é uma interface

            // Consigo instanciar uma lista e jogar em um Ienumerable ou Icollection
            IEnumerable<Payment> payments2 = new List<Payment>();
            */

            // Adicionando itens na lista e apresentando na tela com foreach
            var payments3 = new List<Payment>();
            payments3.Add(new Payment(1));
            payments3.Add(new Payment(2));
            payments3.Add(new Payment(3));
            payments3.Add(new Payment(4));
            payments3.Add(new Payment(5));
            /*
            foreach (var payment in payments3) {
                Console.WriteLine(payment.Id);
            }

            
            // método AddRange adiciona todo o conteudo de uma lista em outra
            var paidPayment = new List<Payment>();
            paidPayment.AddRange(payments3);
            

            // usando Where x (=> usado uma função lambda) x.Id == 3,
            // estou dizendo aqui que Id precisa ser = 3
            // Posso usar essa mesma função porem com o comando First,
            // o comando First diferente do where é usado para retornar apenas 1 item da lista ou seja é apenas uma variave e não uma lista
            // desta forma consigo usar por exemplo um Console.WriteLine() direto
            // já o where ele retorna um IEnumerable, logo para apresentar vou precisar passar o foreach
            var payments4 = payments3.First(x => x.Id == 3);
            Console.WriteLine(payments4.Id);

            // removendo o payment4 (id = 3) da lista Payments3
            payments3.Remove(payments4);

            //Payments3.clear() limpa uma lista 
            
            // retorna se existe o elemento da minha expressão,
            // neste caso eu removi o id 3 então vai retornar false 
            var exists = payments3.Any(x => x.Id == 3);
            Console.WriteLine(exists);
            */

            //payments3.coubt(x => x.Id == 3); conta quantos itens tem na lista dado uma experessão
            //payments3.Skip(1); // pula 1 item da lista
            //payments3.Take(3); // quantos itens eu quero pegar da lista, sempre os 3 primeiros
            //payments3.Skip(2).Take(3) // pulo os 2 primeiros e pego os 3 em diante

            // posso converter uma lista para Enumerable array ou vice versa
            payments3.AsEnumerable();
            payments3.ToList();
            payments3.ToArray();
        }
    }

    public class Payment {
        public int Id { get; set; }

        public Payment(int id) {
            Id = id;
        }
    }

}

namespace Aula01 {

    internal class Program {

        // criei essa função que esta sendo delegada de um método na classe Pagamento5. 
        static void RealizarPagamento(double valor) {
            Console.WriteLine($"Pago o valor de  {valor}");
        }
        private static void Main(string[] args) {
            // objeto é sempre tipo de referencia
            // -> Objeto sempre armazena endereço dos dados

            /*
            // usando o using para chamar automaticamente o método dispose, herdado da interface IDisposable
            using (var pagamento = new Pagamento()) {
                Console.WriteLine("processando o pagamento");
            }

            //instanciando uma classe parcial, a classe esta dividida nos arquivos Payments e CreditCardPayments
            Payments payments = new Payments();

            Console.WriteLine(payments.AtributoA);
            Console.WriteLine(payments.AtributoB);

            //aplicando upcasting
            var pessoa = new Pessoa();
            pessoa = new PessoaFisica();
            pessoa = new PessoaJuridica();
            Console.WriteLine(pessoa.ToString()); // para mostrar que essa pessoa é uma pessoa juridica
            
            //aplicando downcasting
            var pessoa = new Pessoa();
            var pessoaFisica = new PessoaFisica();
            var pessoaJuridica = new PessoaJuridica();

            pessoaFisica = (PessoaFisica) pessoa;
            

            // Comparando Objetos
            // Como objetos são tipos de referencia e não de valor
            // mesmo que duas variaveis de um objeto possuam o mesmo valor, eles não serão iguais, pois sua referencia não é a mesma
            var pessoaA = new Pessoa2(1, "Gabriel Ferreira Lima");
            var pessoaB = new Pessoa2(1, "Gabriel Ferreira Lima");

            Console.WriteLine(pessoaA == pessoaB); // retornará false
            Console.WriteLine(pessoaA.Equals(pessoaB)); // retornará true , por causa da interface IEquatable, se eu não tivesse implementando a interface daria false.
            

            // criando uma variavel que chama o metodo Pagar da classe Pagamento5
            // e esse método esta chamando a fução realizar pagamento
            var pagamento = new Pagamento5.Pagar(RealizarPagamento);
            pagamento(25);
            */
        }

        //o C# possui os seguintes modificadores de acesso :
        //private = acessado só dentro da classe
        //protected = acessado apenas pelas classes filhas e pela própria classe
        //internal = disponivel dentro do mesmo namespace
        //public = visivel como um todo


        //Herdando o IDisposable, uma interface que garante que uma conexão seja fechada, por exemplo com banco de dados
        public class Pagamento : IDisposable {

            // Propriedades, usando o comando prop
            public DateTime Vencimento { get; set; }

            // propg
            public int MyProperty1 { get; private set; }

            // propfull cria uma propriedade privada e outra publica é possivel iterar na publica
            private DateTime _dataPagamento;

            public DateTime DataPagamento {
                get {
                    Console.WriteLine("Lendo o valor");
                    return _dataPagamento;
                }
                set {
                    Console.WriteLine("Atribuindo o valor");
                    // esse "value" é uma palavra reservada usada para atribuir o valor a variavel privada a partir do recebido pela publica
                    _dataPagamento = value;
                }
            }

            // criando contrutor, usando o comando ctor
            public Pagamento() {
                Console.WriteLine("iniciando pagamento");
            }

            // Sobrecarga de contrutor
            public Pagamento(DateTime vencimento) {
                Console.WriteLine("iniciando o pagamento");
                DataPagamento = vencimento;
            }

            // Métodos
            public void Pagar(string numero) { }

            // criando um método com o mesmo nome, porem com parametros diferentes (sobrecarga de métodos)
            public void Pagar(string numero, DateTime vencimento) {
            }

            public void Pagar(string numero, DateTime vencimento, bool pagarAposVencimento = false) {
            }

            // Aplicando Sobreescrita de métodos (virtual)
            public virtual void Pagar2() {
                Console.WriteLine("pagar");
            }

            // Polimorfismo no método ToString
            public override string ToString() {
                return Vencimento.ToString("dd/MM/yyyy");
            }

            // apertando ctrl + . é possivel solicitar ao vs code para gerar automaticamente o método para mim nesse caso método é obrigatório da interface IDisposable

            public void Dispose() {
                Console.WriteLine("Finalizando Pagamento");
            }
        }

        // aplicanndo conceito de herança
        public class PagamentoBoleto : Pagamento {
            public string NumeroBoleto;

            public PagamentoBoleto(DateTime vencimento) : base(vencimento) {
            }

            //sobreescrevendo o método e aplicando conceito de polimorfismo
            public override void Pagar2() {
                base.Pagar2();
                Console.WriteLine("pagar cartão");
            }
        }

        // criando uma classe statica
        // vantagens : classe estatica não precisa ser instanciada
        // desvantagens : Como a informação fica na memória as propriedades da classe sempre vão mudar, exemplo, tenho um sistema em nuvem
        // com 2 usuarios ativos, se eu coloco a classe estatica em um sistema de pagamento quando um usuario fazer um pagamento, o valor
        // do pagamento será igual para todos os usuarios.
        public static class Pagamento2 {
            public static DateTime Vencimento { get; set; }
        }

        //criando classe selada
        //uma classe selada não pode ser herdada, mas pode ser instanciada (ao contrario da abstract).
        //util para o ultimo ramo da herança.
        public sealed class Pagamento3 {
        }

        // criando uma interface

        public interface IPagamento {
            DateTime Vencimento { get; set; }

            void pagar(double valor);
        }
        // criando uma classe que herda a interface
        // como essa classe principal é muito generica, podemos considera-lá como uma classe abstrata,
        // classe abstrata não pode ser instanciada, mas pode ser herdada (ao contrario do sealed) 
        public abstract class Pagamento4 : IPagamento {
            public DateTime Vencimento { get; set; }

            public virtual void pagar(double valor) {
                throw new NotImplementedException();
            }
        }

        // criando mais uma classe que herda a pagamento que herda a interface
        public class Pagamento4ViaBoleto : Pagamento4 {

            public override void pagar(double valor) {
                base.pagar(valor);
            }
        }
        // criando mais uma classe que herda a pagamento que herda a interface
        public class Pagamento4ViaCartao : Pagamento4 {

            public override void pagar(double valor) {
                base.pagar(valor);
            }
        }

        // trabalhando com upcasting
        // conceito de trasformar uma classe fisica em classe pai 
        public class Pessoa {
            public string Name { get; set; }
        }
        public class PessoaFisica : Pessoa {
            public string Cpf { get; set; }
        }
        public class PessoaJuridica : Pessoa {
            public string Cnpj { get; set; }
        }

        //Creie essa classe para poder comparar objetos na main
        //para comparar objetos implementar a interface IEquatable<Nome_da_classe>
        public class Pessoa2 : IEquatable<Pessoa2> {


            public int Id { get; set; }
            public string Name { get; set; }

            public Pessoa2(int id, string name) {
                Id = id;
                Name = name;
            }

            public bool Equals(Pessoa2 pessoa2) {
                return Id == pessoa2.Id;
            }
        }

        // criando uma classe para testar o delegate
        // estou informando no método pagar que ele esta delegando a tarefa para outro método ou função
        // no meu exeplo criei uma função em cima do método main
        public class Pagamento5 {

            public delegate void Pagar(double valor);
        }
    }
}
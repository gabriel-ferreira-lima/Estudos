using System.Globalization;

namespace Aula30TudoDoModulo {
    internal class Program {
        static void Main(string[] args) {

            ContaBancaria conta;

            Console.Write("Entre o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string nomeTitular = (Console.ReadLine());
            Console.Write("Haverá deposito inicial (S/N)? ");
            char temDeposito = char.Parse(Console.ReadLine());
            if (temDeposito == 'S' || temDeposito == 's') {
                Console.Write("Entre o valor de depósito inicial: ");
                double valorDepositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numeroConta, nomeTitular, valorDepositoInicial);
            }
            else {
                conta = new ContaBancaria(numeroConta, nomeTitular);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da Conta:");
            Console.WriteLine(conta);

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Deposito(quantia);
            Console.WriteLine("Dados da Conta atualizados:");
            Console.WriteLine(conta);

            Console.WriteLine();
            Console.Write("Entre um valor para saque: ");
            quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Saque(quantia);
            Console.WriteLine("Dados da Conta atualizados:");
            Console.WriteLine(conta);

        }
    }
}

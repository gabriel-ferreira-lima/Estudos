using System;
using System.Globalization;

namespace Aula18 {
    internal class Program {
        static void Main(string[] args) {

            /* Exercicio01 - Fazer um programa para ler os dados de duas pessoas, depois mostrar o nome da pessoa mais
            velha.
            Pessoa usuario1 = new Pessoa();
            Pessoa usuario2 = new Pessoa();

            Console.WriteLine("Dados da primeira pessoa:");
            Console.Write("Nome: ");
            usuario1.nome = Console.ReadLine();
            Console.Write("Idade: ");
            usuario1.idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados da segunda pessoa:");
            Console.Write("Nome: ");
            usuario2.nome = Console.ReadLine();
            Console.Write("Idade: ");
            usuario2.idade = int.Parse(Console.ReadLine());

            if (usuario1.idade > usuario2.idade) {
                Console.WriteLine("Pessoa mais velha: " + usuario1.nome);
            }
            else {
                Console.WriteLine("Pessoa mais velha: " + usuario2.nome);
            }
            */

            /*Exercicio02 - Fazer um programa para ler nome e salário de dois funcionários. Depois, mostrar o salário
            médio dos funcionários

            Pessoa usuario1 = new Pessoa();
            Pessoa usuario2 = new Pessoa();

            Console.WriteLine("Dados do primeiro funcionário:");
            Console.Write("Nome: ");
            usuario1.nome = Console.ReadLine();
            Console.Write("Salario: ");
            usuario1.salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Dados do segundo funcionário:");
            Console.Write("Nome: ");
            usuario2.nome = Console.ReadLine();
            Console.Write("Salario: ");
            usuario2.salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double mediaSalario = (usuario1.salario + usuario2.salario) / 2;

            Console.WriteLine("Salário médio = " + mediaSalario.ToString("F2", CultureInfo.InvariantCulture));
            */
        }
    }
}

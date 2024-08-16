using System;
using System.Globalization;

namespace Aula03 {

    class Aula03 {
        static void Main(string[] args) {

            char genero = 'F';
            int idade = 32;
            double saldo = 10.35784;
            string nome = "maria";

            Console.Write("Bom dia"); // sem a palavra line no comando ele não faz quebra de linha.
            Console.WriteLine("Boa tarde");
            Console.WriteLine("Boa noite");
            Console.WriteLine(genero);
            Console.WriteLine(idade);
            Console.WriteLine(saldo);
            Console.WriteLine(nome);
            Console.WriteLine(saldo.ToString("f2")); // comando f2 delimita que terá 2 casas após a virgula, caso eu colocasse f3 ficaria 3 casas.
            Console.WriteLine(saldo.ToString("f4"));
            Console.WriteLine(saldo.ToString("f4", CultureInfo.InvariantCulture)); // CultureInfo.InvariantCulture comando para trocar a virgula por ponto no separador das casas decimais

            Console.WriteLine("{0} tem {1} anos e tem saldo igual a {2:F2} reais", nome , idade, saldo); // placeholder
            Console.WriteLine($"{nome} tem {idade} anos e tem saldo igual a {saldo:f2} reais"); //interpolação aqui é possivel utilizar o ToString
            Console.WriteLine(nome + " tem " + idade + " anos e tem saldo igual a " + saldo.ToString("f2", CultureInfo.InvariantCulture) + " reais"); // concatenação (metodo mais antigo) 
        }
    }
}
using System;
using System.Globalization;

namespace Aula08Exercicios {
    class Aula08Exercicios {
        public static void Main(String[] args) {
            
            string nome = Console.ReadLine();
            int quartos = int.Parse(Console.ReadLine());
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);    

            string[] vet = Console.ReadLine().Split(" ");
            string n1 = vet[0];
            int n2 = int.Parse(vet[1]);
            double n3 = double.Parse(vet[2], CultureInfo.InvariantCulture) ;

            Console.WriteLine(nome);
            Console.WriteLine(quartos);
            Console.WriteLine(preco.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3.ToString("F2", CultureInfo.InvariantCulture));


        }
    }
}
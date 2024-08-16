using System;

namespace Aula07 {
    class Aula07 {
        public static void Main(string[] args) {
            
            /*
            string texto = Console.ReadLine();
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            string z = Console.ReadLine();
            */
   

            string[] vet = Console.ReadLine().Split(' ');
            string a = vet[0];
            string b = vet[1];
            string c = vet[2];  

            /*
            Console.WriteLine("você digitou a frase");
            Console.WriteLine(texto);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            */
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}
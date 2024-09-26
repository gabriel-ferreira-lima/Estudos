using System;


namespace Aula12 {
    class Aula12 {
        static void Main(string[] args) {
            /*
            Console.WriteLine("Entre com um número inteiro");
            int x = int.Parse(Console.ReadLine());

            if (x % 2 == 0) { 
                Console.WriteLine("Par !");
            }
            else {
                Console.WriteLine("Impar !");
            }

            */

            Console.WriteLine("Digite as horas");
            int y = int.Parse(Console.ReadLine());

            if (y < 12) {

                Console.WriteLine("Bom dia !");
            }
            else if (y <= 18) {

                Console.WriteLine("Boa tarde !");
            }
            else {
                Console.WriteLine("Boa noite !");
            }
        }
    }
}

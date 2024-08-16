using System;

namespace Aula05 {
    class Aula05 {
        static void Main(string[] args) {

            float a = 4.5f;
            double b = a;

            Console.WriteLine(b); // exemplo de conversão implicita 


            double c;
            float d;

            c = 5.1;
            d = (float)c;

            Console.WriteLine(d); // exemplo de conversão explicita (casting)

            double e;
            int f;

            e = 5.1;
            f = (int)e;

            Console.WriteLine(f); // mais um exemplo de conversão explicita (casting) de double para int

            int g;
            int h;

            g = 5;
            h = 2;

            double resultado = (double) g / h; // colocar um dos valores em double (casting) para evitar do valor vir inteiro

            Console.WriteLine(resultado);

        }
    }
}
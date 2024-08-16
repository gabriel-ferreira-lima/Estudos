using System;

namespace aula02 {

    class program {
        public static void Main(string[] args) {

            bool completo = false;
            char genero = 'F';
            char letra = '\u0041'; // acessar o link para ver todos os códigos https://symbl.cc/en/unicode-table/
            byte n1 = 126;
            int n2 = 1000;
            long n3 = 12818283811L;
            float n4 = 4.5f;
            double n5 = 4.5;
            string nome = "Gabriel Ferreira Lima";
            object obj1 = "Gabriela";
            object obj2 = 4.5f;
            int n6 = int.MinValue; // função para pegar o valor minimo e maximo da variavel
            int n7 = int.MaxValue;
            sbyte n8 = sbyte.MinValue;
            decimal n9 = decimal.MaxValue;

            Console.WriteLine(completo);
            Console.WriteLine(genero);
            Console.WriteLine(letra);
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(n5);
            Console.WriteLine(nome);
            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
            Console.WriteLine(n6);
            Console.WriteLine(n7);
            Console.WriteLine(n8);
            Console.WriteLine(n9);
        }
    }
}

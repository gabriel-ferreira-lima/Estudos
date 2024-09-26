using System;
using System.Runtime.CompilerServices;

namespace Aula04 {
    class Aula04 {
        public static void Main(string[] args) {

            int a = 10;

            Console.WriteLine(a);   

            a += 2;

            Console.WriteLine(a);

            a *= 3; 
            
            Console.WriteLine(a);

            string s = "ABC";

            Console.WriteLine(s);

            s += "DEF";

            Console.WriteLine(s);



            int n1 = 10;
            n1++;

            Console.WriteLine(n1);

            int n2 = 10;
            n2--;

            Console.WriteLine(n2);

            int n3 = 10;
            int n4 = n3++;  // SE COLOCAR O SINA DE MAIS DEPOIS DA VARIAVEL PRIMEIRO ELE ATRIBUI O VALOR ORIGINAL DA VARIAVEL PARA A OUTRA E DEPOIS SOMA

            Console.WriteLine(n3);
            Console.WriteLine(n4);

            int n5 = 10;
            int n6 = ++n5;

        }
    }
}
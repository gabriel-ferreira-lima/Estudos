using System;
using System.Globalization;

namespace Aula16 {
    internal class Program {
        static void Main(string[] args) {

            /*Exercicio 01 - Leia um valor inteiro X (1 <= X <= 1000). Em seguida mostre os ímpares de 1 até X,
            um valor por linha, inclusive o X, se for o caso.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1067/uri1067/Program.cs
            

            int x = int.Parse(Console.ReadLine());

            for (int i = 1; i <= x; i++) {
                if (i % 2 != 0) {
                    Console.WriteLine(i);
                }
            }
            */

            /*Exercicio 02 - Leia um valor inteiro N. Este valor será a quantidade de valores inteiros X que serão
            lidos em seguida. Mostre quantos destes valores X estão dentro do intervalo [10,20] e quantos estão 
            fora do intervalo, mostrando essas informações conforme exemplo (use a palavra "in" para dentro do intervalo,
            e "out" para fora do intervalo).
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1072/uri1072/Program.cs

            Console.Write("Digite um valor : ");
            int n = int.Parse(Console.ReadLine());
            int dentro = 0;
            int fora = 0;

            for (int i = 1; i <= n; i++) {
                int x = int.Parse(Console.ReadLine());
                if (x >= 10 && x <= 20) {
                    dentro += 1;  
                    
                }
                else {
                    fora += 1;
                }
            }

            Console.WriteLine(dentro + " in");
            Console.WriteLine(fora + " out");
            */

            /*Exercicio 03 - Leia 1 valor inteiro N, que representa o número de casos de teste que vem a seguir. 
            Cada caso de teste consiste de 3 valores reais, cada um deles com uma casa decimal. Apresente a média
            ponderada para cada um destes conjuntos de 3 valores, sendo que o primeiro valor tem peso 2, o segundo 
            valor tem peso 3 e o terceiro valor tem peso 5.
            


            Console.Write("Digite um valor : ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                string[] var = Console.ReadLine().Split(" ");
                double a = double.Parse(var[0], CultureInfo.InvariantCulture);
                double b = double.Parse(var[1], CultureInfo.InvariantCulture);
                double c = double.Parse(var[2], CultureInfo.InvariantCulture);

                double media = ((a * 2.0) + (b  * 3.0) + (c * 5.0)) / 10;

                Console.WriteLine(media.ToString("F1", CultureInfo.InvariantCulture));
            }
            */

            /*Exercicio 04 - Fazer um programa para ler um número N. Depois leia N pares de números e mostre a divisão
            do primeiro pelo segundo. Se o denominador for igual a zero, mostrar a mensagem "divisao impossivel".
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1116/uri1116/Program.cs
            

            Console.Write("Digite um valor : ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                string[] var = Console.ReadLine().Split(" ");
                int a = int.Parse(var[0]);
                int b = int.Parse(var[1]);
                if (b == 0) {
                    Console.WriteLine("divisão impossivel");
                }
                else {
                    double resultado = (double)a / b;
                    Console.WriteLine(resultado.ToString("F1", CultureInfo.InvariantCulture));
                }
            }
            */

            /*Exercicio 05 - Ler um valor N. Calcular e escrever seu respectivo fatorial. Fatorial de 
            N = N * (N-1) * (N-2) * (N-3) * ... * 1. Lembrando que, por definição, fatorial de 0 é 1.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1153/uri1153/Program.cs

            Console.Write("Escreva um numero : ");
            int n = int.Parse(Console.ReadLine());
            int fatorial = 1;

            for (int i = 1; i <= n; i++) {
                fatorial *= i;

                
            }
            Console.WriteLine(fatorial);
            */

            /*Exercicio 06 - Ler um número inteiro N e calcular todos os seus divisores.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1157/uri1157/Program.cs
            

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {
                if (n % i == 0 ) {
                    Console.WriteLine(i);
                }
            }
            */

            /*Exercicio 07 - Fazer um programa para ler um número inteiro positivo N. O programa deve então mostrar 
            na tela N linhas, começando de 1 até N. Para cada linha, mostrar o número da linha, depois o quadrado
            e o cubo do valor, conforme exemplo.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1143/uri1143/Program.cs
            

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {

                double raiz = i * i;
                double cubo = Math.Pow(i, 3);

                Console.WriteLine(i + " " + raiz + " " + cubo);
            }
            */
        }
    }
}

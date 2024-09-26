using System;
using System.Globalization;

namespace Aula09TudoSobreEstruturaSequencial {
    class Aula09TudoSobreEstruturaSequencial {
        static void Main(string[] args) {

            /*Exercicio 01 - Faça um programa para ler dois valores inteiros, e depois mostrar na tela a soma desses números com uma 
              mensagem explicativa.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1003/uri1003/Program.cs

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int Soma = a + b;

            Console.WriteLine("SOMA = " + Soma);
            */

            /*Exercicio 02 -Faça um programa para ler o valor do raio de um círculo, e depois mostrar o valor da área deste círculo com quatro 
              casas decimais conforme exemplos.
            Correção : https://github.com/acenelio/nivelamento-csharp/blob/master/uri1002/uri1002/Program.cs

            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double pi = 3.14159;

            double area = pi * (Math.Pow(raio, 2));

            Console.WriteLine(area.ToString("F4", CultureInfo.InvariantCulture));
            */

            /*Exercicio 03 - Fazer um programa para ler quatro valores inteiros A, B, C e D. A seguir, calcule e mostre a diferença do produto 
              de A e B pelo produto de C e D segundo a fórmula: DIFERENCA = (A * B - C * D).
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1007/uri1007/Program.cs

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            int resultado = (a * b) - (c * d);

            Console.WriteLine(resultado);
            */

            /*Exercicio 04 - Fazer um programa que leia o número de um funcionário, seu número de horas trabalhadas, o valor que recebe por 
              hora e calcula o salário desse funcionário. A seguir, mostre o número e o salário do funcionário, com duas casas decimais.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1008/uri1008/Program.cs

            int funcionario = int.Parse(Console.ReadLine());
            int horasTrabalhadas = int.Parse(Console.ReadLine());
            double salarioPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double salarioTotal = horasTrabalhadas * salarioPorHora;

            Console.WriteLine("NUMBER = " + funcionario);
            Console.WriteLine("SALARY = U$ " + salarioTotal.ToString("F2", CultureInfo.InvariantCulture));
            */

            /*Exercicio 05 - Fazer um programa para ler o código de uma peça 1, o número de peças 1, o valor unitário de cada peça 1, o 
              código de uma peça 2, o número de peças 2 e o valor unitário de cada peça 2. Calcule e mostre o valor a ser pago.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1010/uri1010/Program.cs

            int cod1;
            int num1;
            double valor1;

            int cod2;
            int num2;
            double valor2;

            
            string[] vet1 = Console.ReadLine().Split(" ");
            string[] vet2 = Console.ReadLine().Split(" ");

            cod1 = int.Parse(vet1[0]);
            num1 = int.Parse(vet1[1]);
            valor1 = double.Parse(vet1[2], CultureInfo.InvariantCulture);

            cod2 = int.Parse(vet2[0]);
            num2 = int.Parse(vet2[1]);
            valor2 = double.Parse(vet2[2], CultureInfo.InvariantCulture);

            double resultado = (num1 * valor1) + (num2 * valor2);

            Console.WriteLine("VALOR A PAGAR: R$ " + resultado.ToString("F2", CultureInfo.InvariantCulture));
            */

            /*Exercicio 06 - Fazer um programa que leia três valores com ponto flutuante de dupla precisão: A, B e C. Em seguida, calcule e mostre:
              a) a área do triângulo retângulo que tem A por base e C por altura.
              b) a área do círculo de raio C. (pi = 3.14159)
              c) a área do trapézio que tem A e B por bases e C por altura.
              d) a área do quadrado que tem lado B.
              e) a área do retângulo que tem lados A e B. 
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1012/uri1012/Program.cs*/

            double a ;
            double b ;
            double c ;

            string[] vet = Console.ReadLine().Split(" " );

            a = double.Parse(vet[0], CultureInfo.InvariantCulture);
            b = double.Parse(vet[1], CultureInfo.InvariantCulture);
            c = double.Parse(vet[2], CultureInfo.InvariantCulture);

            double resp1 = a * c / 2;
            double resp2 = 3.14159 * Math.Pow(c, 2);
            double resp3 = ((a + b) * c) / 2;
            double resp4 = b * b;
            double resp5 = a * b;

            Console.WriteLine("TRIANGULO: " + resp1.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("CIRCULO: " + resp2.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("TRAPEZIO: " + resp3.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("QUADRADO: " + resp4.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("RETANGULO: " + resp5.ToString("F3", CultureInfo.InvariantCulture));
  
        }
    }
}
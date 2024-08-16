using System;
using System.Globalization;

namespace Aula14 {
    internal class Program {
        static void Main(string[] args) {

            /*Exercicio 01 - Escreva um programa que repita a leitura de uma senha até que ela seja válida. 
            Para cada leitura de senha incorreta informada, escrever a mensagem "Senha Invalida". 
            Quando a senha for informada corretamente deve ser impressa a mensagem "Acesso Permitido" 
            e o algoritmo encerrado. Considere que a senha correta é o valor 2002.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1114/uri1114/Program.cs
            

            int senha = int.Parse(Console.ReadLine());

            while (senha != 2002) { 
                Console.WriteLine("Senha Invalida");
                senha = int.Parse(Console.ReadLine());  
            }

            Console.WriteLine("Acesso Permitido");
            */

            /*Exercicio 02 - Escreva um programa para ler as coordenadas (X,Y) de uma quantidade indeterminada de
            pontos no sistema cartesiano. Para cada ponto escrever o quadrante a que ele pertence. 
            O algoritmo será encerrado quando pelo menos uma de duas coordenadas for NULA 
            (nesta situação sem escrever mensagem alguma).
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1115/uri1115/Program.cs
            

            string[] var = Console.ReadLine().Split(" ");

            int x = int.Parse(var[0]);
            int y = int.Parse(var[1]);

            while (x != 0 || y != 0) {
                if (x > 0 && y > 0) {
                    Console.WriteLine("Primeiro");
                    var = Console.ReadLine().Split(" ");
                    x = int.Parse(var[0]);
                    y = int.Parse(var[1]);
                }
                else if (x < 0 && y > 0) {
                    Console.WriteLine("Segundo");
                    var = Console.ReadLine().Split(" ");
                    x = int.Parse(var[0]);
                    y = int.Parse(var[1]);
                }
                else if (x < 0 && y < 0) {
                    Console.WriteLine("Terceiro");
                    var = Console.ReadLine().Split(" ");
                    x = int.Parse(var[0]);
                    y = int.Parse(var[1]);
                }
                else if (x > 0 && y < 0) {
                    Console.WriteLine("Quarto");
                    var = Console.ReadLine().Split(" ");
                    x = int.Parse(var[0]);
                    y = int.Parse(var[1]);
                }
                else {
                }
            
            }
            */

            /*Exercicio 03 - Um Posto de combustíveis deseja determinar qual de seus produtos tem a preferência de
            seus clientes. Escreva um algoritmo para ler o tipo de combustível abastecido 
            (codificado da seguinte forma: 1.Álcool 2.Gasolina 3.Diesel 4.Fim). Caso o usuário informe 
            um código inválido (fora da faixa de 1 a 4) deve ser solicitado um novo código (atéque seja válido).
            O programa será encerrado quando o código informado for o número 4. Deve ser escrito a 
            mensagem: "MUITO OBRIGADO" e a quantidade de clientes que abasteceram cada tipo de combustível, 
            conforme exemplo.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1134/uri1134/Program.cs
            

            int n = int.Parse(Console.ReadLine());
            int alcool = 0;
            int gasolina = 0;
            int diesel = 0;


            while (n != 4) {
                if (n == 1) {
                    alcool += 1;
                    n = int.Parse(Console.ReadLine());
                }
                else if (n == 2) {
                    gasolina += 1;
                    n = int.Parse(Console.ReadLine());
                }
                else if (n == 3) {
                    diesel += 1;
                    n = int.Parse(Console.ReadLine());
                }
                else if (n < 0 || n >= 5) {
                    n = int.Parse(Console.ReadLine());
                }
                else {
                } 
            }

            Console.WriteLine("MUITO OBRIGADO");
            Console.WriteLine("Alcool: " + alcool);
            Console.WriteLine("Gasolina: " + gasolina);
            Console.WriteLine("Diesel: " + diesel);
            */
        }
    }
}

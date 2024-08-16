using System;
using System.Globalization;

namespace Aula13EstruturaCondicional {
    internal class Aula13 {
        static void Main(string[] args) {
            /*Exercicio01 - Fazer um programa para ler um número inteiro, e depois dizer se este número é negativo ou não
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/cond01/cond01/Program.cs

            Console.WriteLine("Digite um número !");
            int n = int.Parse(Console.ReadLine());

            if (n < 0) {
                Console.WriteLine("NEGATIVO");
                }
            else
                Console.WriteLine("NÃO NEGATIVO");
            */

            /*Exercicio02 - Fazer um programa para ler um número inteiro e dizer se este número é par ou ímpar
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/cond02/cond02/Program.cs

            Console.WriteLine("Digite um número");
            int n = int.Parse(Console.ReadLine());

            if (n % 2 == 0 ) {
                Console.WriteLine("PAR !");
            }
            else {
                Console.WriteLine("IMPAR !");
            }
            */

            /*Exercicio3 - Leia 2 valores inteiros (A e B). Após, o programa deve mostrar uma mensagem 
            "Sao Multiplos" ou "Nao sao Multiplos", indicando se os valores lidos são múltiplos entre si.
            Atenção: os números devem poder ser digitados em ordem crescente ou decrescente. 
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1044/uri1044/Program.cs


            string[] vet = Console.ReadLine().Split(" ");

            int n1 = int.Parse(vet[0]);
            int n2 = int.Parse(vet[1]);

            if (n1 % n2 == 0 || n2 % n1 ==0 ) {
                Console.WriteLine("Sao Multiplos");
            }
            else {
                Console.WriteLine("Nao sao Multiplos");
            }
            */

            /*Exercicio04 - Leia a hora inicial e a hora final de um jogo. A seguir calcule a duração do jogo,
            sabendo que o mesmo pode começar em um dia e terminar em outro, tendo uma duração mínima de 1 hora 
            e máxima de 24 horas.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1046/uri1046/Program.cs

            string[] horas = Console.ReadLine().Split(" ");
            int horaInicio = int.Parse(horas[0]);
            int horaFim = int.Parse(horas[1]);
            int horasTotais;

            if (horaInicio < horaFim) {
                horasTotais = horaInicio - horaFim;
            }
            else {
                horasTotais = 24 - horaInicio + horaFim;
            }

            Console.WriteLine("O jogo durou " + horasTotais);
            */

            /*Exercicio05 - Com base na tabela abaixo, escreva um programa que leia o código de um item e a 
            quantidade deste item. A seguir, calcule e mostre o valor da conta a pagar.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1038/uri1038/Program.cs

            string[] var = Console.ReadLine().Split(" ");

            int codigo = int.Parse(var[0]);
            int quantidade = int.Parse(var[1]);
            double valor;

            if (codigo == 1) {
                valor = quantidade * 4;
                Console.WriteLine("Total: R$ " + valor.ToString("F2", CultureInfo.InvariantCulture));
            }
            else if (codigo == 2) {
                valor = quantidade * 4.5;
                Console.WriteLine("Total: R$ " + valor.ToString("F2", CultureInfo.InvariantCulture));
            }
            else if (codigo == 3) {
                valor = quantidade * 5;
                Console.WriteLine("Total: R$ " + valor.ToString("F2", CultureInfo.InvariantCulture));
            }
            else if (codigo == 4) {
                valor = quantidade * 2;
                Console.WriteLine("Total: R$ " + valor.ToString("F2", CultureInfo.InvariantCulture));
            }
            else if (codigo == 5) {
                valor = quantidade * 1.5;
                Console.WriteLine("Total: R$ " + valor.ToString("F2", CultureInfo.InvariantCulture));
            }
            else {
                Console.WriteLine("Por favor utilize um código valido");
            }
            */

            /*Exercicio06 - Você deve fazer um programa que leia um valor qualquer e apresente uma mensagem dizendo
            em qual dos seguintes intervalos ([0,25], (25,50], (50,75], (75,100]) este valor se encontra.
            Obviamente se o valor não estiver em nenhum destes intervalos, deverá ser impressa a mensagem 
            “Fora de intervalo”.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1037/uri1037/Program.cs

            double n = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (n >= 0 && n <= 25) {
                Console.WriteLine("intervalo [0,25]");
            }
            else if (n > 25 && n <= 50) {
                Console.WriteLine("intervalo [25,50]");
            }
            else if (n > 50 && n <=75) {
                Console.WriteLine("intervalo [50,75]");
            }
            else if (n > 75 &&  n <= 100) {
                Console.WriteLine("intervalo [75, 100]");
            }
            else {
                Console.WriteLine("Fora de intervalo");
            }
            */

            /*Exercicio07 - Leia 2 valores com uma casa decimal (x e y), que devem representar as coordenadas
            de um ponto em um plano. A seguir, determine qual o quadrante ao qual pertence o ponto,
            ou se está sobre um dos eixos cartesianos ou na origem (x = y = 0). Se o ponto estiver na origem,
            escreva a mensagem “Origem”. Se o ponto estiver sobre um dos eixos escreva “Eixo X” ou “Eixo Y”, 
            conforme for a situação.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1041/uri1041/Program.cs

            string[] var = Console.ReadLine().Split(" ");

            double n1 = double.Parse(var[0], CultureInfo.InvariantCulture);
            double n2 = double.Parse(var[1], CultureInfo.InvariantCulture);

            if (n1 == n2 && n2 == 0) {
                Console.WriteLine("Origem");
            }
            else if (n1 == 0.0) {
                Console.WriteLine("Eixo X");
            }
            else if (n2 == 0.0) {
                Console.WriteLine("Eixo Y");
            }
            else if (n1 >= 0.1 && n2 >= 0.1) {
                Console.WriteLine("Q1");
            }
            else if (n1 < 0 && n2 >= 0.1) {
                Console.WriteLine("Q2");
            }
            else if (n1 < 0 && n2 < 0) {
                Console.WriteLine("Q3");
            }
            else {
                Console.WriteLine("Q4");
            }
            */

            /*Exercicio08 - Em um país imaginário denominado Lisarb, todos os habitantes ficam felizes em pagar
            seus impostos, pois sabem que nele não existem políticos corruptos e os recursos arrecadados são 
            utilizados em benefício da população, sem qualquer desvio. A moeda deste país é o Rombus, 
            cujo símbolo é o R$. Leia um valor com duas casas decimais, equivalente ao salário de uma pessoa
            de Lisarb. Em seguida, calcule e mostre o valor que esta pessoa deve pagar de Imposto de Renda,
            segundo a tabela abaixo. Lembre que, se o salário for R$ 3002.00, a taxa que incide é de 8% apenas
            sobre R$ 1000.00, pois a faixa de salário que fica de R$ 0.00 até R$ 2000.00 é isenta de Imposto
            de Renda. No exemplo fornecido (abaixo), a taxa é de 8% sobre R$ 1000.00 + 18% sobre R$ 2.00, 
            o que resulta em R$ 80.36 no total. O valor deve ser impresso com duas casas decimais.
            Correção: https://github.com/acenelio/nivelamento-csharp/blob/master/uri1051/uri1051/Program.cs
            

            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); 

            if (salario >= 0.00 && salario <= 2000.00) {
                Console.WriteLine("Isento");
            }
            else if (salario > 2000 && salario <= 3000.00) {
                salario = (salario - 2000.00) * 0.08;
                Console.WriteLine("R$" + salario.ToString("F2", CultureInfo.InvariantCulture));
            }
            else if(salario > 3000.00 && salario <= 4500.00 ) {
                salario = (salario - 3000.0) * 0.18 + 1000.0 * 0.08;
                Console.WriteLine("R$" + salario.ToString("F2", CultureInfo.InvariantCulture));
            }
            else if (salario > 4500) {
                salario = (salario - 4500.0) * 0.28 + 1500.0 * 0.18 + 1000 * 0.08;
                Console.WriteLine("R$" + salario.ToString("F2", CultureInfo.InvariantCulture));
            }
            else {
                Console.WriteLine("Preencha um valor positivo");
            }
            */
        }
    }
}
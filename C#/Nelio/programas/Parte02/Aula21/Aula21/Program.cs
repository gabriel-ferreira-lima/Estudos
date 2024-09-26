using System.Globalization;
using System;
using System.Xml;

namespace Aula21 {
    internal class Program {
        static void Main(string[] args) {

            /*Exercicio01 - Fazer um programa para ler os valores da largura e altura de um retângulo. 
            Em seguida, mostrar na tela o valor de sua área, perímetro e diagonal. Usar uma classe
            como mostrado no projeto ao lado.
            Retangulo A = new Retangulo();

            Console.WriteLine("Entre com a Largula e altura do retângulo");
            A.Altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            A.Largura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("AREA = " + A.Area().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("PERÍMETRO = " + A.Perimetro().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("DIAGONAL  = " + A.Diagonal().ToString("F2", CultureInfo.InvariantCulture));
            */

            /*Exercicio02 - Fazer um programa para ler os dados de um funcionário (nome, salário bruto e imposto).
            Em seguida, mostrar os dados do funcionário (nome e salário líquido). Em seguida, aumentar o salário 
            do funcionário com base em uma porcentagem dada (somente o salário bruto é afetado pela porcentagem)
            e mostrar novamente os dados do funcionário. Use a classe projetada abaixo.

            Funcionario funcionario = new Funcionario();

            Console.Write("Nome: ");
            funcionario.Nome = Console.ReadLine();
            Console.Write("Salário bruto: ");
            funcionario.SalarioBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Imposto: ");
            funcionario.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.WriteLine("Funcionario: " + funcionario);

            Console.WriteLine();
            Console.Write("Digite a porcentagem para aumentar salário: ");
            double aumento = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            funcionario.AumentarSalario(aumento);

            Console.WriteLine();
            Console.WriteLine("Dados atualizados: " + funcionario);
            */

            /*Exercicio03 - Fazer um programa para ler o nome de um aluno e as três notas que ele obteve nos três trimestres
            do ano (primeiro trimestre vale 30 e o segundo e terceiro valem 35 cada). Ao final, 
            mostrar qual a nota final do aluno no ano. Dizer também se o aluno está APROVADO ou REPROVADO e, 
            em caso negativo, quantos pontos faltam para o aluno obter o mínimo para ser aprovado (que é 60 pontos). 
            Você deve criar uma classe Aluno para resolver este problema..

            Aluno aluno = new Aluno();

            Console.Write("Nome do Aluno: ");
            aluno.Nome = Console.ReadLine(); 
            Console.WriteLine("Digite as três notas do aluno:");
            aluno.N1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            aluno.N2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            aluno.N3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("NOTA FINAL = " + aluno.NotaFinal().ToString("F2", CultureInfo.InvariantCulture)) ;
            
            if (aluno.Aprovado()) {
                Console.WriteLine("APROVADO");
            }
            else {
                Console.WriteLine("REPROVADO\r" 
                                + "FALTARAM " 
                                + aluno.NotaRestante().ToString("F2", CultureInfo.InvariantCulture) 
                                + " PONTOS");
            }
            */

        }
    }
}

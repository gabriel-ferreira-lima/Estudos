using System.Globalization;

namespace Aula24 {
    internal class Program {
        static void Main(string[] args) {

            /*Exercicio 01 - Faça um programa ler a cotação do dólar, e depois um valor em dólares a ser comprado por 
            uma pessoa em reais. Informar quantos reais a pessoa vai pagar pelos dólares, considerando ainda que a 
            pessoa terá que pagar 6% de IOF sobre o valor em dólar. Criar uma classe ConversorDeMoeda para ser 
            responsável pelos calculos*/

            Console.Write("Qual é a cotação do dolár ? ");
            double cotacao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantos dólares você vai comprar? ");
            double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double resultado = ConversorDeMoeda.Conversor(cotacao, quantia);

            Console.WriteLine("Valor a ser pago em reais = "+ resultado.ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}

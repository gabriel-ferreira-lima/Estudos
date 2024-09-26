using System.Globalization;
using System;

namespace Aula23 {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("Entre com valor do raio ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double circ = Calculadora.Circunferencia(raio);
            double volume = Calculadora.Volume(raio);

            Console.WriteLine("Circunferencia: " + circ.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Volume: " + volume.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Valor de PI: " + Calculadora.pi.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}

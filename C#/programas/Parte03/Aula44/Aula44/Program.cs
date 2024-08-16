using System.Globalization;
using System.Net;

namespace Aula44 {
    internal class Program {
        static void Main(string[] args) {
            

            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double desconto = (preco < 20.0) ? preco * 0.1 : preco * 0.05; //forma diferente de fazer if else


            Console.WriteLine(desconto);
        }
    }
}

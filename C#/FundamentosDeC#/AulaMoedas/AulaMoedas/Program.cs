using System.Globalization;

namespace AulaMoedas {
    internal class Program {
        static void Main(string[] args) {

            decimal valor = 10.50m;

            Console.WriteLine(
                valor.ToString(
                    "C", //formatador padrão para colocar o tipo da moeda usada
                        CultureInfo.CreateSpecificCulture("en-US"))); // isso faz a mesma coisa que o InvariantCulture, porem posso colocar qualquer pais


            // Usando o Math para moedas
            Console.WriteLine(Math.Round(valor)); // arredonda o valor para cima ou para baixo
            Console.WriteLine(Math.Ceiling(valor)); // arredonda o valor para cima
            Console.WriteLine(Math.Round(valor)); // arredonda o valor para baixo
        }
    }
}

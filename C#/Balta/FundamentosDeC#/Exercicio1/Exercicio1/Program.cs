namespace Exercicio1 {
    internal class Program {
        static void Main(string[] args) {
            Menu();
        }

        private static void Soma() {
            Console.Clear();
            Console.Write("Primeiro Valor: ");
            double n1 = double.Parse(Console.ReadLine());
            Console.Write("Segundo Valor: ");
            double n2 = double.Parse(Console.ReadLine());

            double sum = n1 + n2;

            Console.WriteLine("O resultado da soma é: " + sum);

            Console.ReadKey();
            Menu();
        }

        private static void Subtracao() {
            Console.Clear();
            Console.Write("Primeiro Valor: ");
            double n1 = double.Parse(Console.ReadLine());
            Console.Write("Segundo Valor: ");
            double n2 = double.Parse(Console.ReadLine());

            double sum = n1 - n2;

            Console.WriteLine("O resultado da subtração é: " + sum);

            Console.ReadKey();
            Menu();
        }

        private static void Multiplicacao() {
            Console.Clear();
            Console.Write("Primeiro Valor: ");
            double n1 = double.Parse(Console.ReadLine());
            Console.Write("Segundo Valor: ");
            double n2 = double.Parse(Console.ReadLine());

            double sum = n1 * n2;

            Console.WriteLine("O resultado da Multiplicação é: " + sum);

            Console.ReadKey();
            Menu();
        }

        private static void Divisao() {
            Console.Clear();
            Console.Write("Primeiro Valor: ");
            double n1 = double.Parse(Console.ReadLine());
            Console.Write("Segundo Valor: ");
            double n2 = double.Parse(Console.ReadLine());

            double sum = n1 / n2;

            Console.WriteLine("O resultado da Divisão é: " + sum);

            Console.ReadKey();
            Menu();
        }

        private static void Menu() {
            Console.Clear();
            Console.WriteLine("digite a opção desejada");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Sair");

            Console.WriteLine("-------------");
            Console.Write("Selecione uma Opção: ");
            int a = int.Parse(Console.ReadLine());

            switch (a) {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Multiplicacao(); break;
                case 4: Divisao(); break;
                case 5: System.Environment.Exit(0); break;
                default: Console.Write("Digite um Valor valido"); Console.ReadKey(); Menu(); break;
            }
        }
    }
}

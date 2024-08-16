using Aula54.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Aula54 {
    internal class Program {
        static void Main(string[] args) {

            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number or tax payer: ");
            int c = int.Parse(Console.ReadLine());
            for (int i = 1; i <= c; i++) { 
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (type == 'i') {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else {
                    Console.Write("Number of employees: ");
                    int numberOfEmployes = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, numberOfEmployes));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");

            double sum = 0;
            foreach (TaxPayer taxPayer in list) {
                Console.WriteLine(taxPayer.Name + ": $ " + taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
                sum += taxPayer.Tax();
            }

            Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}

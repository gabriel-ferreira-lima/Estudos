using Aula51.Entities;
using System.Globalization;

namespace Aula51 {
    internal class Program {
        static void Main(string[] args) {

            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {
                Console.WriteLine("Employee #" + i + " data:");
                Console.Write("Outsorced (y/n)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'y' || ch == 'Y') {
                    Console.Write("Additional charge: ");
                    double additionCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    employees.Add(new OutSourcedEmployee(name, hours, valuePerHour, additionCharge));
                }
                else {
                    employees.Add(new Employee(name, hours, valuePerHour));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PAYMENTS:");

            foreach (Employee emp in employees) {
                Console.WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}

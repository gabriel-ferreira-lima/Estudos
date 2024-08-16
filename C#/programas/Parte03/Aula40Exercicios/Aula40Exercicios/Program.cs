using System.Globalization;
using System.Collections.Generic;

namespace Aula40Exercicios {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("How many Employees will be registered? ");
            int n = int.Parse(Console.ReadLine());

            List<Employee> list = new List<Employee>();

            for (int i = 1; i <= n; i++) {
                Console.WriteLine("Employer #" + i + ":");
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string nome = Console.ReadLine();
                Console.Write("Salary: ");
                double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                list.Add(new Employee(id, nome, salario));
                Console.WriteLine();
            }

            Console.Write("Enter the employee id that will have salary increase : ");
            int buscaID = int.Parse(Console.ReadLine());

            Employee emp = list.Find(x => x.Id == buscaID);
            if (emp != null) {
                Console.Write("Enter the percent: ");
                double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                emp.IncreaseSalary(porcentagem);
            }
            else {
                Console.WriteLine("This id does not exist!");
            }

            Console.WriteLine();
            Console.WriteLine("Updated list of employees:");
            foreach (Employee i in list) {
                Console.WriteLine(i);
            }
        }
    }
}
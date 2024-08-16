using Aula57.Entities;
using Aula57.Entities.Exceptions;
using System.Globalization;

namespace Aula57 {
    internal class Program {
        static void Main(string[] args) {

            try {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("WithdrawLimit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account acc = new Account(number, holder, balance, withdrawLimit);

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double withdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                acc.Withdraw(withdraw);
                Console.WriteLine(acc);
            }
            catch (DomainException e) {
                Console.WriteLine("Withdraw error: " + e.Message);
            }
            catch (FormatException e) {
                Console.WriteLine("Error : " + e.Message);
            }
        }
    }
}

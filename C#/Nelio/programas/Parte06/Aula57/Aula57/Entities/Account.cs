using Aula57.Entities.Exceptions;
using System.Globalization;

namespace Aula57.Entities {
    internal class Account {

        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account() {
        }

        public Account(int number, string holder, double balance, double withdrawLimit) {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount) {
            Balance += amount;
        }

        public void Withdraw(double amount) {
            if (WithdrawLimit < amount) {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            if (Balance < amount) {
                throw new DomainException("Not enought balance");
            }
            Balance -= amount;
        }

        public override string ToString() {
            return "New balance: " + Balance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}

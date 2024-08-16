using System;
using System.Globalization;

namespace Aula30TudoDoModulo {
    internal class ContaBancaria {

        public int NumeroDaConta { get; private set; }
        public string Nome { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numeroDaConta, string nome, double depositoInicial) {
            NumeroDaConta = numeroDaConta;
            Nome = nome;
            Deposito(depositoInicial);
        }

        public ContaBancaria(int numeroDaConta, string nome) {
            NumeroDaConta = numeroDaConta;
            Nome = nome;
        }

        public void Deposito(double deposito) {
            Saldo += deposito;
        }

        public void Saque(double saque) {
            Saldo = Saldo - (saque + 5.00);
        }

        public override string ToString() {
            return "Conta "
                   + NumeroDaConta
                   + ", Titular: "
                   + Nome
                   + ", Saldo: $ "
                   + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }


    }
}

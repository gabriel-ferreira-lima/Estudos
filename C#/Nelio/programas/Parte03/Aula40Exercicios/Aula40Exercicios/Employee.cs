using System.Globalization;

namespace Aula40Exercicios {
    internal class Employee {


        public int Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; private set; }

        public Employee(int id, string nome, double salario) {
            Id = id;
            Nome = nome;
            Salario = salario;
        }
        public void IncreaseSalary(double porcentagem) {
            Salario += Salario * porcentagem / 100;
        }

        public override string ToString() {
            return Id
                + ", "
                + Nome
                + ", "
                + Salario.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}

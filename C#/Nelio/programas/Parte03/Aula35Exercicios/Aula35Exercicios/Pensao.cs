

using System.ComponentModel.DataAnnotations;

namespace Aula35Exercicios {
    internal class Pensao {

        public string Nome { get; set; }
        public string Email { get; set; }

        public Pensao(string nome, string email) {
            Nome = nome;
            Email = email;
        }
        

        public override string ToString() {
            return Nome
                + ", "
                + Email
                ;
        }
    }
}

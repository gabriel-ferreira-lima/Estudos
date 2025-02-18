using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.UserScreen {
    internal class ExcluirUserScreen {

        public static void Load() {
            Console.Clear();
            Console.WriteLine("Atualizar usuario");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            int id = 0;
            try {
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException) {
                Console.WriteLine("Por favor insira apenas numeros");
                Console.ReadKey();
                Load();
            }
            Delete(id);
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Delete(int id) {
            var repository = new Repository<User>(Database.Connection);
            try {
                repository.Delete(id);
                Console.WriteLine($"Usuario Deletado com sucesso");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel Deletar o usuario");
                Console.WriteLine(e.Message);
            }

        }
    }
}

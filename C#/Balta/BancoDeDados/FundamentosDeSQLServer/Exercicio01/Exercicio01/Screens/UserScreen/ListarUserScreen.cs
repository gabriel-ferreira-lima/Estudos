using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.UserScreen {
    internal class ListarUserScreen {
        public static void Load() {
            Console.Clear();
            Console.WriteLine("Lista de Usuarios");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List() {
            var repository = new Repository<User>(Database.Connection);

            var users = repository.Get();
            foreach (var item in users) {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Email} | {item.PasswordHash} | {item.Bio} | {item.Image} | {item.Slug}");
            }
        }
    }
}

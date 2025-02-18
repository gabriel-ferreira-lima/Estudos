using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.RoleScreen {
    internal class AtualizarRoleScreen {

        public static void Load() {

            Console.Clear();
            Console.WriteLine("Atualizar Perfil");
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
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Slug: ");
            string slug = Console.ReadLine();
            Update(new Role {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Update(Role role) {
            var repository = new Repository<Role>(Database.Connection);

            try {
                repository.Update(role);
                Console.WriteLine($"{role.Id} | {role.Name} | {role.Slug}");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel atualizar o Perfil");
                Console.WriteLine(e.Message);
            }
        }

    }
}

using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.RoleScreen {
    internal class AdicionarRoleScreen {
        public static void Load() {

            Console.Clear();
            Console.WriteLine("Cadastrar Perfil");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Slug: ");
            string slug = Console.ReadLine();
            Create(new Role {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Create(Role role) {
            var repository = new Repository<Role>(Database.Connection);

            try { 
                repository.Create(role);
                Console.WriteLine($"Perfil cadastrado com sucesso: {role.Id} | {role.Name} | {role.Slug}");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel cadastrar o Perfil");
                Console.WriteLine(e.Message);
            }
        }
    }
}

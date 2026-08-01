using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.RoleScreen {
    internal class ExcluirRoleScreen {
        public static void Load() {

            Console.Clear();
            Console.WriteLine("Excluir Perfil");
            Console.WriteLine("-------------");
            Console.WriteLine("Digite o ID do perfil que você deseja excluir");
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
            MenuRoleScreen.Load();
        }

        public static void Delete(int id) {
            var repository = new Repository<Role>(Database.Connection);

            try {
                repository.Delete(id);
                Console.WriteLine("Perfil deletada com sucesso");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel deletar a tag");
                Console.WriteLine(e.Message);
            }
        }
    }
}

using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.TagScreen {
    internal class ExcluirTagScreen {

        public static void Load() {

            Console.Clear();
            Console.WriteLine("Excluir tag");
            Console.WriteLine("-------------");
            Console.WriteLine("Digite o ID da tag que você deseja excluir");
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
            MenuTagScreen.Load();
        }

        private static void Delete(int id) {
            var repository = new Repository<Tag>(Database.Connection);

            try {
                repository.Delete(id);
                Console.WriteLine("Tag deletada com sucesso");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel deletar a tag");
                Console.WriteLine(e.Message);
            }

        }

    }
}


using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.CategoryScreen {
    internal class ExcluirCategoryScreen {
        public static void Load() {

            Console.Clear();
            Console.WriteLine("Excluir Categoria");
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
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id) {
            var repository = new Repository<Category>(Database.Connection);

            try {
                repository.Delete(id);
                Console.WriteLine("Categoria deletada com sucesso");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel cadastrar a categoria");
                Console.WriteLine(e.Message);
            }
        }
    }
}

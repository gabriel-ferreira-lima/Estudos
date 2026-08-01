using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.CategoryScreen {
    internal class ListarCategoryScreen {

        public static void Load() {
            Console.Clear();
            Console.WriteLine("Lista de categorias");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void List() {
            var repository = new Repository<Category>(Database.Connection);

            var categories = repository.Get();
            foreach (var category in categories) {
                Console.WriteLine($"{category.Id} | {category.Name} | {category.Slug}");
            }
        }
    }
}

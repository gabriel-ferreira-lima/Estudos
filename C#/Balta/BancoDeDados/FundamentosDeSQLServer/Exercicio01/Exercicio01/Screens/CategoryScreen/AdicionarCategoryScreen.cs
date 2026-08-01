using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.CategoryScreen {
    internal class AdicionarCategoryScreen {
        public static void Load() {

            Console.Clear();
            Console.WriteLine("Cadastrar Categoria");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Slug: ");
            string slug = Console.ReadLine();
            Create(new Category {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Create(Category category) {
            var repository = new Repository<Category>(Database.Connection);

            try {
                repository.Create(category);
                Console.WriteLine($"Categoria cadastrada com sucesso: {category.Id} | {category.Name} | {category.Slug}");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel cadastrar a categoria");
                Console.WriteLine(e.Message);
            }
        }
    }
}

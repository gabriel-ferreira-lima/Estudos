using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.CategoryScreen {
    internal class AtualizarCategoryScreen {
        public static void Load() {

            Console.Clear();
            Console.WriteLine("Atualizar Categoria");
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
            Update(new Category {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Update(Category category) {
            var repository = new Repository<Category>(Database.Connection);

            try {
                repository.Update(category);
                Console.WriteLine($"Categoria atualizada com sucesso: {category.Id} | {category.Name} | {category.Slug}");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel atualizar a categoria");
                Console.WriteLine(e.Message);
            }
        }
    }
}

using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.TagScreen {
    internal class AtualizarTagScreen {

        public static void Load() {

            Console.Clear();
            Console.WriteLine("Atualizar tag");
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
            Update(new Tag {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Update(Tag tag) {
            var repository = new Repository<Tag>(Database.Connection);

            try {
                repository.Update(tag);
                Console.WriteLine($"Tag Atualizada com sucesso: {tag.Id} | {tag.Name} | {tag.Slug}");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel Atualizar a tag");
                Console.WriteLine(e.Message);
            }

        }
    }
}


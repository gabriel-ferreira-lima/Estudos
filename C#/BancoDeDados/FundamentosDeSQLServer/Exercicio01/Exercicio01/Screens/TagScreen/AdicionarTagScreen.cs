using Exercicio01.Models;
using Exercicio01.Repositories;


namespace Exercicio01.Screens.TagScreen {
    internal class AdicionarTagScreen {

        public static void Load() {

            Console.Clear();
            Console.WriteLine("Cadastrar tag");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Slug: ");
            string slug = Console.ReadLine();
            Create(new Tag {
                Name = name, 
                Slug = slug 
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Create(Tag tag) {
            var repository = new Repository<Tag>(Database.Connection);

            try {
                repository.Create(tag);
                Console.WriteLine($"Tag cadastrada com sucesso: {tag.Id} | {tag.Name} | {tag.Slug}");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel salvar a tag");
                Console.WriteLine(e.Message);
            }
            
        }

    }
}


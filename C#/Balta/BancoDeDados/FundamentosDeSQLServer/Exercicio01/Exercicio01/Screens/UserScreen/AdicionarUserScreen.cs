using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.UserScreen {
    internal class AdicionarUserScreen {
        public static void Load() {
            Console.Clear();
            Console.WriteLine("Cadastrar usuario");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("PasswordHash: ");
            var passwordHash = Console.ReadLine();
            Console.Write("Bio: ");
            var bio = Console.ReadLine();
            Console.Write("Imagem: ");
            var image = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new User {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Create(User user) {
            var repository = new Repository<User>(Database.Connection);
            try {
                repository.Create(user);
                Console.WriteLine($"Usuario cadastrado com sucesso: {user.Id} | {user.Name} | {user.Email} | {user.PasswordHash} | {user.Bio} | {user.Image} | {user.Slug}");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel cadastrar o usuario");
                Console.WriteLine(e.Message);
            }
            
        }
    }
}

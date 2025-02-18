using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.UserScreen {
    internal class AtualizarUserScreen {
        public static void Load() {
            Console.Clear();
            Console.WriteLine("Atualizar usuario");
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

            Update(new User {
                Id = id,
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

        private static void Update(User user) {
            var repository = new Repository<User>(Database.Connection);
            try {
                repository.Update(user);
                Console.WriteLine($"Usuario Atualizado com sucesso: {user.Id} | {user.Name} | {user.Email} | {user.PasswordHash} | {user.Bio} | {user.Image} | {user.Slug}");
            }
            catch (Exception e) {
                Console.WriteLine("Não foi possivel Atualizar o usuario");
                Console.WriteLine(e.Message);
            }
        }
    }
}

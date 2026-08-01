using Exercicio01.Models;
using Exercicio01.Repositories;
using Exercicio01.Screens.UserScreen;

namespace Exercicio01.Screens.PostScreen;

public class ListarPostUserScreen {
    public static void Load() {
        Console.Clear();
        Console.WriteLine("Por Favor selecione o ID do seu usuario usuario que você deseja ver os posts");
        Console.WriteLine("-------------");
        List<int> listaDeUsuarios = idsList();
        PrintUserIdsAndNames();
        Console.Write("Insira o ID: ");
        int id = 0;
        try {
            id = int.Parse(Console.ReadLine());
            bool usuarioEncontrado = false;
            foreach (var item in listaDeUsuarios) {
                if (id == item) {
                    usuarioEncontrado = true;
                    break;
                }
            }

            if (usuarioEncontrado) {
                Console.Clear();
                Console.WriteLine("Lista de Posts deste usuario");
                Console.WriteLine("-------------");
                List(id);
                Console.ReadKey();
                MenuPostScreen.Load();
            }
            else {
                Console.WriteLine("Usuario não existe ou não possui nenhum post");
                Console.ReadKey();
                MenuPostScreen.Load();
            }
        }
        catch (FormatException) {
            Console.WriteLine("Por favor insira apenas numeros");
            Console.ReadKey();
            Load();
        }
    }

    internal static List<int> idsList() {
        var repository = new Repository<User>(Database.Connection);
        var listaUsers = new List<int>();
        var users = repository.Get();
        foreach (var user in users) {
            listaUsers.Add(user.Id);
        }

        return listaUsers;
    }

    internal static void PrintUserIdsAndNames() {
        var repository = new Repository<User>(Database.Connection);
        var users = repository.Get();
        foreach (var user in users) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user.Id);
            Console.ResetColor();
            Console.WriteLine($" | {user.Name}");
        }
    }

    private static void List(int id) {
        var repository = new PostRepository(Database.Connection);

        var posts = repository.GetPostFromPeson(id);
        foreach (var post in posts) {
            Console.WriteLine(post.Title);
            Console.WriteLine(post.Summary);
            Console.WriteLine(post.Body);
            Console.WriteLine($"Criado em: {post.CreateDate}");
            Console.WriteLine("-------------------------------------------");
        }
    }
}
using System.Threading.Channels;
using Exercicio01.Models;
using Exercicio01.Repositories;

namespace Exercicio01.Screens.PostScreen;

public class ListarPostScreen {
    public static void Load() {
        Console.Clear();
        Console.WriteLine("Lista de Perfis");
        Console.WriteLine("-------------");
        List();
        Console.ReadKey();
        MenuPostScreen.Load();
    }

    public static void List() {
        var repository = new PostRepository(Database.Connection);

        var posts = repository.GetPosts();
        foreach (var post in posts) {
            Console.WriteLine($"Criado por: {post.User.Name}");
            Console.WriteLine(post.Title);
            Console.WriteLine(post.Summary);
            Console.WriteLine(post.Body);
            Console.WriteLine($"Criado em: {post.CreateDate}");
            Console.WriteLine("-------------------------------------------");
        }
    }
}
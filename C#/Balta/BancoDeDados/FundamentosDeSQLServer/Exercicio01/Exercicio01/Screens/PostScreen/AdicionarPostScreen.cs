using System.Globalization;
using Exercicio01.Models;
using Exercicio01.Repositories;
using Exercicio01.Screens.CategoryScreen;

namespace Exercicio01.Screens.PostScreen;

internal class AdicionarPostScreen {
    public static void Load() {

        Console.Clear();
        Console.WriteLine("Criar Post");
        Console.WriteLine("-------------");
        Console.Write("Titulo: ");
        string title = Console.ReadLine();
        Console.Write("Resumo do Post: ");
        string summary = Console.ReadLine();
        Console.WriteLine("Escreva seu post abaixo");
        Console.WriteLine("-----------------------");
        string body = Console.ReadLine();
        Console.Write("Slug: ");
        string slug = Console.ReadLine();
        Console.Clear();
        ListarPostUserScreen.PrintUserIdsAndNames();
        List<int> userids = ListarPostUserScreen.idsList();
        Console.WriteLine("Coloque o ID do autor do Post");
        int authorId = 0;
        try {
            authorId = int.Parse(Console.ReadLine());
            bool usuarioEncontrado = false;
            foreach (var item in userids) {
                if (authorId == item) {
                    usuarioEncontrado = true;
                    break;
                }
            }

            if (usuarioEncontrado) {
                Console.Clear();
                Console.WriteLine("Digite o ID da categoria");
                ListarCategoryScreen.List();
                int categoryId = 0;
                try {
                    categoryId = int.Parse(Console.ReadLine());
                    bool categoriaEncontrada = false;
                    foreach (var item in userids) {
                        if (categoryId == item) {
                            categoriaEncontrada = true;
                            break;
                        }
                    }

                    if (categoriaEncontrada) {
                        Create(new Post {
                            Title = title,
                            Summary = summary,
                            Body = body,
                            Slug = slug,
                            CreateDate = DateTime.Now,
                            LastUpdateDate = DateTime.Now,
                            AuthorId = authorId,
                            CategoryId = categoryId
                        });
                        Console.ReadKey();
                        MenuPostScreen.Load();
                    }
                    else {
                        Console.WriteLine("Categoria não existe");
                        Console.ReadKey();
                        MenuPostScreen.Load();
                    }
                }
                catch (FormatException) {
                    Console.WriteLine("Por favor insira apenas numeros");
                    Console.ReadKey();
                    Load();
                }

                MenuPostScreen.Load();
            }
            else {
                Console.WriteLine("Usuario não existe");
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

    public static void Create(Post post) {
        var repository = new Repository<Post>(Database.Connection);

        try { 
            repository.Create(post);
            Console.WriteLine($"Post cadastrado com sucesso");
        }
        catch (Exception e) {
            Console.WriteLine("Não foi possivel criar o post");
            Console.WriteLine(e.Message);
        }
    }
}
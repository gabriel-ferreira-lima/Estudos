using Aula01.Data;
using Aula01.Model;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Data;

namespace Aula01 {
    internal class Program {
        static void Main(string[] args) {

            using (var context = new BlogDataContext()) {
                /* Primeira Aula 
                //exemplo de create
                //var tag = new Tag { Name = ".NET", Slug = "dotnet" };
                //context.Tags.Add(tag);
                //context.SaveChanges(); // isso aqui salva o conteudo no banco

                // Exemplo de update
                //var tag = context.Tags.FirstOrDefault(x=> x.Id == 1 );
                //tag.Name = ".NET";
                //tag.Slug = "dotnet";
                //context.Update(tag); 
                //context.SaveChanges();

                //exemplo de delete
                //var tag = context.Tags.FirstOrDefault(x=> x.Id == 1);
                //context.Remove(tag);
                //context.SaveChanges();

                //exemplo de select em lista
                //var tags = context
                //    .Tags
                //    .AsNoTracking() // não vai trazer metadados, o que deixa mais rapido,
                //                    // recomendado para select, porem não para update e delete
                //    .Where(x => x.Name.Contains(".NET"))
                //    .ToList(); //ToList força a execução da query antes do foreach,
                //               //se eu não coloco isso ele só vai fazer a query durante o foreach
                //foreach (var item in tags) {
                //    Console.WriteLine(item.Name);
                //}

                //exemplo de update com id = 4
                //var tag = context
                //    .Tags
                //    .FirstOrDefault(x => x.Id == 4);
                //tag.Name = "Ponto NET";
                //tag.Slug = "dotnet";
                //context.Update(tag);
                //context.SaveChanges();

                // select de um unico item
                //var tag = context
                //    .Tags
                //    .AsNoTracking()
                //    .FirstOrDefault(x => x.Id == 4);
                //Console.WriteLine(tag?.Name);
                */

                /* Segunda Aula

                mostrando que o EF consegue criar um usuario e uma categoria apenas criando o post

                var user = new User {
                    Name = "Gabriel Ferreira",
                    Slug = "gabrielferreira",
                    Email = "gabriel.lima@gmail.com",
                    Bio = "Aprendendo c#",
                    Image = "https://bailtaio",
                    PasswordHash = "123098547"
                };

                var category = new Category {
                    Name = "Backend",
                    Slug = "backend"
                };

                var post = new Post {
                    Author = user,
                    Category = category,
                    Body = "<p> Hello World</p>",
                    Slug = "comecando-com-ef-core",
                    Summary = "neste artigo vamos aprender EF core",
                    Title = "Começando com EF core",
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                };

                context.Posts.Add(post); // o EF é inteligente o suficiente para criar um post e associar ela a um user 
                                        // e category sem nem ao menos cria-las anteriomente. 
                context.SaveChanges();
                */

                /* Terceira Aula 
                var posts = context
                    .Posts
                    .AsNoTracking()
                    .Include(x=> x.Author) // é o que faz os joins das tabelas 
                    .Include(x => x.Category) // fiz uma query com 2 joins
                    .OrderByDescending(x=>x.LastUpdateDate)
                    .ToList();

                foreach (var post in posts) {
                    Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
                }
                */

                /* Quarta Aula

                Exemplo de update, atualizei o nome do usuario usando o objeto post
                var post = context
                    .Posts
                    //.AsNoTracking()
                    .Include(x => x.Author)
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.LastUpdateDate)
                    .FirstOrDefault();

                post.Author.Name = "Teste";

                context.Posts.Update(post);
                context.SaveChanges();
                */
            }
        }
    }
}
using Aula02.Data;
using Aula02.Model;
using Microsoft.EntityFrameworkCore;

namespace Aula02 {
    internal class Program {
        static void Main(string[] args) {

            using var context = new BlogDataContext();

            //context.Users.Add(new User {
            //    Bio = "Aprendendo c#",
            //    Name = "Gabriel Ferreira",
            //    Email = "gabriel.lima@gmail.com",
            //    PasswordHash = "123098547",
            //    Image = "https://bailtaio",
            //    Slug = "gabrielferreira"
            //});
            //context.SaveChanges();

            /*
            var user = context.Users.FirstOrDefault();
            var post = new Post {
                Author = user,
                Body = "Meu artigo",
                Category = new Category {
                    Name = "Backend",
                    Slug = "backend"
                },
                CreateDate = DateTime.Now,
                //LastUpdateDate =
                Slug = "meu-artigo",
                Summary = "Neste artigo vamos conferir...",
                //Tags = null,
                Title = "Meu artigo"
            };

            context.Posts.Add(post);
            context.SaveChanges();
            */
        }
    }
}

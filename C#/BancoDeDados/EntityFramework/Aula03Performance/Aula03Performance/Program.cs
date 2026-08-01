using Aula03Performance.Data;
using Aula03Performance.Model;

namespace Aula03Performance {
    internal class Program {

        /*
        // aplicando conceitos de sistema assincrono : asynk, Task, await
        static async Task Main(string[] args) {

            using (var context = new BlogDataContext()) {

                var posts = await GetPosts(context);

                Console.WriteLine("Teste");
            }
        }
        public static async Task<List<Post>> GetPosts(BlogDataContext context) {
            return await context.Posts.ToListAsync();
        }
        */

        public static void Main(string[] args) {
            using var context = new BlogDataContext();
            /*
            // aplicando conceito de Lazy Loading não recomendado, ao colocar
            // a lista de tags como virtual dentro da classe de post eu consigo
            // rodar o script dessa forma
            // dessa forma ele vai fazer select na tabela posts e na tags deixando o processo mais lento

            var posts = context.Posts ;
            foreach (var post in posts) {
                foreach (var tag in post.Tags) { 
                
                } 
            }
            */

            /*
            // aplicando conceito de Eager Load apliquei o include, desta forma fiz um inner join antes de 
            //e executa a query.
            var posts = context
                .Posts
                .AsNoTracking()
                .Include(x=> x.Tags)
                .ToList();
            foreach (var post in posts) {
                foreach (var tag in post.Tags) {

                }
            }
            */

            /*
            // essa parte tambem é sobre paginação
            var post = GetPosts(context, 0, 25);
            var post2 = GetPosts(context, 25, 25);
            var post3 = GetPosts(context, 50, 25);
            var post4 = GetPosts(context, 75, 25);
            */

            /*
            // aqui mostrando sobre o thenInclude, evitar usar pois ele faz um subselect e isso afeta o servidor
            var posts = context.Posts
                .Include(x => x.Author)
                    .ThenInclude(x => x.Roles);
            */
            
            // criando query pura acessar a classe post PostWithTagsCount e o blogDataContext
            var posts = context.PostWithTagsCounts.ToList();
            foreach (var post in posts) {
                Console.WriteLine(post.Count);
            }
            
        }
        
        /*
        // criando conceito de paginação
        public static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 30) {
            var posts = context
                .Posts
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToList();
            return posts;
        }
        */
    }
}

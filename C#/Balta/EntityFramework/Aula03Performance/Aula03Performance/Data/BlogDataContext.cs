using Aula03Performance.Data.Mappings;
using Aula03Performance.Model;
using Microsoft.EntityFrameworkCore;

namespace Aula03Performance.Data {
    internal class BlogDataContext : DbContext {

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostWithTagsCount> PostWithTagsCounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=localhost,1433;Database=BlogFluentMap;User ID=sa;Password=Gordaojoga10;Trusted_Connection=False; TrustServerCertificate=True;");
            //options.LogTo(Console.WriteLine); // isso aqui gera log no console, é possivel colocar isso em arquivo txt tambem
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());

            modelBuilder.Entity<PostWithTagsCount>(x => {

                x.HasNoKey();
                x.ToSqlQuery(@"
                    SELECT 
                        p.[Title] AS [Name], 
                        (SELECT COUNT(pt.[PostId]) FROM [PostTag] pt WHERE pt.[PostId] = p.[Id]) AS [Count]
                    FROM
                        [Post] p");
            });
        }

    }
}

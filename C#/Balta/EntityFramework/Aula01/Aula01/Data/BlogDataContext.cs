using Aula01.Model;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Data {
    internal class BlogDataContext : DbContext {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<PostTag> PostTags { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=Gordaojoga10;Trusted_Connection=False; TrustServerCertificate=True;");
            //options.LogTo(Console.WriteLine); // isso aqui gera log no console, é possivel colocar isso em arquivo txt tambem
        }
    }
}

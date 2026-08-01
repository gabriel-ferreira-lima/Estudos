using Aula02.Data.Mappings;
using Aula02.Model;
using Microsoft.EntityFrameworkCore;

namespace Aula02.Data {
    internal class BlogDataContext : DbContext{

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User>  Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=localhost,1433;Database=BlogFluentMap;User ID=sa;Password=Gordaojoga10;Trusted_Connection=False; TrustServerCertificate=True;");
            //options.LogTo(Console.WriteLine); // isso aqui gera log no console, é possivel colocar isso em arquivo txt tambem
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}

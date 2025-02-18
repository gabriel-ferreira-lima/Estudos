using Microsoft.EntityFrameworkCore;

namespace Aula02.Data {
    internal class BlogDataContext : DbContext{
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=localhost,1433;Database=FluentBlog;User ID=sa;Password=Gordaojoga10;Trusted_Connection=False; TrustServerCertificate=True;");
            //options.LogTo(Console.WriteLine); // isso aqui gera log no console, é possivel colocar isso em arquivo txt tambem
        }
    }
}

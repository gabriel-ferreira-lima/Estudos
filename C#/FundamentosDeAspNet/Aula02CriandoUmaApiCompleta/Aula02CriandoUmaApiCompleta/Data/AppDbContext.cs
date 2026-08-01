using Aula02CriandoUmaApiCompleta.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula02CriandoUmaApiCompleta.Data {
    public class AppDbContext : DbContext{

        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("DataSource=app.db; Cache=Shared");
        }

    }
}

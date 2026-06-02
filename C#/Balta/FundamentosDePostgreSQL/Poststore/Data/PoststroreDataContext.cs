using Microsoft.EntityFrameworkCore;
using Poststore.Data.Mappings;
using Poststore.Models;

namespace Poststore.Data {

    // forma diferente de criar um construtor, diretamente na classe

    public class PoststroreDataContext(DbContextOptions<PoststroreDataContext> options) : DbContext(options){

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly); // uma forma de pegar todos os mapeamentos de uma vez só

        }


    }
}

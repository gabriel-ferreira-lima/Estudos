using Aula03Performance.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula03Performance.Data.Mappings {
    internal class CategoryMap : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            //Associando a tabela
            builder.ToTable("Category");

            // Associando Chave primaria
            builder.HasKey(x => x.Id);

            // identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd() // isso seria para gerar um valor ao criar uma nova linha
                .UseIdentityColumn(); // isso seria para o autoincremental

            // Propriedades 
            builder.Property(x => x.Name)
                .IsRequired() // NOT NULL
                .HasColumnName("Name") // informa como será o nome do campo na tabela 
                .HasColumnType("NVARCHAR") //Informa o tipo do campo
                .HasMaxLength(80); // tamanho maximo do campo

            builder.Property(x => x.Slug)
                .IsRequired() // NOT NULL
                .HasColumnName("Slug") // informa como será o nome do campo na tabela 
                .HasColumnType("VARCHAR") //Informa o tipo do campo
                .HasMaxLength(80); // tamanho maximo do campo

            // indices 
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();
        }
    }
}

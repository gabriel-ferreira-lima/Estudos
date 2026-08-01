using Aula03Performance.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula03Performance.Data.Mappings {
    internal class UserMap : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            //Associando a tabela
            builder.ToTable("User");

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

            builder.Property(x => x.Bio);
            builder.Property(x => x.Email);
            builder.Property(x => x.Image);
            builder.Property(x => x.PasswordHash);

            builder.Property(x => x.Slug)
                .IsRequired() // NOT NULL
                .HasColumnName("Slug") // informa como será o nome do campo na tabela 
                .HasColumnType("VARCHAR") //Informa o tipo do campo
                .HasMaxLength(80); // tamanho maximo do campo

            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();

            // relacionamento
            // 1:N
            builder
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    role => role
                        .HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRole_RoleId")
                        .OnDelete(DeleteBehavior.Cascade),
                    user => user
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_PostTag_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}

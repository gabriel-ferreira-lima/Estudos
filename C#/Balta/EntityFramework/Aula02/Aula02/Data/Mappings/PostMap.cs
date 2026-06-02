using Aula02.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace Aula02.Data.Mappings {
    internal class PostMap : IEntityTypeConfiguration<Post> {
        public void Configure(EntityTypeBuilder<Post> builder) {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.LastUpdateDate)
                .IsRequired() // NOT NULL
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()"); // esse comando informa que será usada uma função nativa do SQL
                                                  //.HasDefaultValue(DateTime.Now.ToUniversalTime()); // esse comando informa que será usada uma função do .NET
                                                  // Pode usar ambos os valores

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            // indices 
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique();

            //relacionamentos
            // 1:N
            builder.HasOne(x => x.Author) // relacionamento 1:1
                .WithMany(x => x.Posts) // relacionamento 1:N
                .HasConstraintName("FK_Post_Author") // Informa o nome da constratint 
                .OnDelete(DeleteBehavior.Cascade);

            // N:N
            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post => post.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag.HasOne<Post>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .HasConstraintName("FK_PostTag_TagId")
                    .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poststore.Models;

namespace Poststore.Data.Mappings {
    public class CategoryMap : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.ToTable("categories");

            builder
                .HasKey(x => x.Id)
                .HasName("pk_category");

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn()
                .UseSerialColumn();

            builder.OwnsOne(x => x.Heading, heading => {
                heading
                    .Property(x => x.Title)
                    .HasColumnType("varchar")
                    .HasColumnName("title")
                    .IsRequired(true);

                heading
                    .Property(x => x.Slug)
                    .HasColumnType("varchar")
                    .HasColumnName("slug")
                    .IsRequired(true);

                heading
                    .HasIndex(x => x.Slug)
                    .IsUnique()
                    .HasDatabaseName("ix_categiries_slug");
            });

            builder.HasMany(x => x.Products);
        }
    }
}

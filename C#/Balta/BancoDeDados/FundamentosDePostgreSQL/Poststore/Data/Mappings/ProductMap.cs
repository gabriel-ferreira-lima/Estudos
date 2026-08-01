using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poststore.Models;
using System.Text.Json;

namespace Poststore.Data.Mappings {

    public class ProductMap : IEntityTypeConfiguration<Product> {

        // aqui altero a convensão, no C# uso PascalCase, no banco uso snake_case, com isso eu serializo no padrão snake_case
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions() {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        };

        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.ToTable("products");

            builder
                .HasKey(x => x.Id)
                .HasName("pk_product");

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
                    .HasDatabaseName("ix_products_slug");
            });

            builder.Property(x => x.DefautLanguage)
                .HasColumnName("default_language")
                .HasMaxLength(8)
                .HasDefaultValue("en-us")
                .IsRequired(true);

            builder.Property(x => x.Translations)
                .HasColumnName("translations")
                .HasColumnType("jsonb")
                .HasConversion(x => JsonSerializer.Serialize(x, _jsonOptions), 
                               x => string.IsNullOrEmpty(x) 
                                    ? new List<Translation>() 
                                    : JsonSerializer.Deserialize<List<Translation>>(x, _jsonOptions) 
                                        ?? new List<Translation>())
                .IsRequired(false);

            builder
                .Property(x => x.CategoryId)
                .HasColumnName("category_id");

            builder.Property(x => x.CreatedAtUtc)
                .HasColumnName("created_at_utc")
                .HasDefaultValueSql("now()")
                .IsRequired(true);

            builder.Property(x => x.UpdatedAtUtc)
                .HasColumnName("updated_at_utc")
                .HasDefaultValueSql("now()")
                .IsRequired(true);

            builder.Property(x => x.IsActive)
                .HasColumnName("is_active")
                .IsRequired(true);


            builder.HasOne(x => x.Category);

        }
    }
}

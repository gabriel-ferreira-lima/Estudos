using Aula03Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula03Blog.Data.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role> {
    
    public void Configure(EntityTypeBuilder<Role> builder) {
        builder.ToTable("Role");
        
        builder.HasKey(role => role.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(25);
        
        builder.Property(x => x.Slug)
            .IsRequired()
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);

    }
}
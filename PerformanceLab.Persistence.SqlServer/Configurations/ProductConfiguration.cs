using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerformanceLab.Domain.Entities;

namespace PerformanceLab.Persistence.SqlServer.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id)
            .ValueGeneratedOnAdd();

        builder.Property(product => product.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(product => product.Description)
            .HasMaxLength(1000);

        builder.Property(product => product.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(product => product.Stock)
            .IsRequired();

        builder.Property(product => product.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicShopDemo.Api.Models.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Status)
                .HasDefaultValue(true);

            builder.Property(e => e.Price)
                .HasDefaultValue(0.05);

            builder.HasIndex(e => e.Code)
                .HasDatabaseName("UI_ProductCode")
                .IsUnique();

            builder.HasIndex(e => e.Name)
                .HasDatabaseName("UI_ProductName")
                .IsUnique();

            builder.HasIndex(e => e.CategoryId)
             .HasDatabaseName("IX_ProductCategory");

            builder.HasIndex(e => e.Price)
             .HasDatabaseName("IX_ProductPrice");

            builder.HasOne(e => e.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Products_CategoryId");
        }
    }
}
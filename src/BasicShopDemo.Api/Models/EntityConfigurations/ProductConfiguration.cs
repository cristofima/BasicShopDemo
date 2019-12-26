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

            builder.HasIndex(e => e.Code)
                .HasName("UI_ProductCode")
                .IsUnique();

            builder.HasIndex(e => e.Name)
                .HasName("UI_ProductName")
                .IsUnique();

            builder.HasIndex(e => e.CategoryId)
             .HasName("IX_ProductCategory");

            builder.HasOne(e => e.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Products_CategoryId");
        }
    }
}
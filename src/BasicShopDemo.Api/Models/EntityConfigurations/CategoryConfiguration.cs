using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicShopDemo.Api.Models.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Status)
                .HasDefaultValue(true);

            builder.HasIndex(e => e.Code)
                .HasName("UI_CategoryCode")
                .IsUnique();

            builder.HasIndex(e => e.Name)
                .HasName("UI_CategoryName")
                .IsUnique();
        }
    }
}
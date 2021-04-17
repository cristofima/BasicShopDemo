using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicShopDemo.Api.Models.EntityConfigurations
{
    public class ProviderCategoryConfiguration : IEntityTypeConfiguration<ProviderCategory>
    {
        public void Configure(EntityTypeBuilder<ProviderCategory> builder)
        {
            builder.HasOne(e => e.Category)
                    .WithMany(e => e.ProvidersCategory)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Provider)
                   .WithMany(e => e.ProviderCategories)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new { e.ProviderId, e.CategoryId })
                .HasDatabaseName("UI_ProviderCategory")
                .IsUnique();
        }
    }
}

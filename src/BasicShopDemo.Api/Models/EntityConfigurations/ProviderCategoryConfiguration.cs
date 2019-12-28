using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicShopDemo.Api.Models.EntityConfigurations
{
    public class ProviderCategoryConfiguration : IEntityTypeConfiguration<ProviderCategory>
    {
        public void Configure(EntityTypeBuilder<ProviderCategory> builder)
        {
            builder.HasIndex(e => new { e.ProviderId, e.CategoryId })
                .HasName("UI_ProviderCategory")
                .IsUnique();
        }
    }
}

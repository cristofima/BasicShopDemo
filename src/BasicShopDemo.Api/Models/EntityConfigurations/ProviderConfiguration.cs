using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicShopDemo.Api.Models.EntityConfigurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.Property(e => e.Status)
                .HasDefaultValue(true);

            builder.HasIndex(e => e.RUC)
                 .HasDatabaseName("UI_ProviderRUC")
                 .IsUnique();

            builder.HasIndex(e => e.BusinessName)
                 .HasDatabaseName("UI_ProviderBusinessName")
                 .IsUnique();

            builder.HasIndex(e => e.Email)
                .HasDatabaseName("UI_ProviderEmail")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");

            builder.HasIndex(e => e.Phone)
               .HasDatabaseName("UI_ProviderPhone")
               .IsUnique()
               .HasFilter("([Phone] IS NOT NULL)");

            builder.HasIndex(e => e.CellPhone)
               .HasDatabaseName("UI_ProviderCellPhone")
               .IsUnique()
               .HasFilter("([CellPhone] IS NOT NULL)");

            builder.HasIndex(e => e.WebSite)
               .HasDatabaseName("UI_ProviderWebSite")
               .IsUnique()
               .HasFilter("([WebSite] IS NOT NULL)");
        }
    }
}

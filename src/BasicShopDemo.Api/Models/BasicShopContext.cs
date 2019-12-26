using BasicShopDemo.Api.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BasicShopDemo.Api.Models
{
    public class BasicShopContext : DbContext
    {
        public BasicShopContext()
        {
        }

        public BasicShopContext(DbContextOptions<BasicShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=BasicShop;User ID=sa;Password=coronadoserver2018;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
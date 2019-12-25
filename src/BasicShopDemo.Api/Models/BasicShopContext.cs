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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=BasicShop;User ID=sa;Password=coronadoserver2018;Trusted_Connection=True;");
            }
        }
    }
}
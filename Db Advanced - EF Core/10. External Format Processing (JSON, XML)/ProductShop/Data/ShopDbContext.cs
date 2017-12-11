namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.;Database=ProductShopDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            builder.Entity<Product>()
                .HasOne(p => p.Seller)
                .WithMany(p => p.SoldProducts)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(p => p.Buyer)
                .WithMany(p => p.BoughtProducts)
                .HasForeignKey(p => p.BuyerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(c => c.Categories)
                .HasForeignKey(cp => cp.ProductId);

            builder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(cp => cp.CategoryId);

            builder.Entity<Category>()
                .Property(p => p.Name)
                .HasMaxLength(15);

        }
    }
}
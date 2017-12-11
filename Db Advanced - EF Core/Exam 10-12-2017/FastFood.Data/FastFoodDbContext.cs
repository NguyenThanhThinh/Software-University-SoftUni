using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
    using Models;

    public class FastFoodDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }


        public FastFoodDbContext()
        {
        }

        public FastFoodDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Position>()
                .HasAlternateKey(p => p.Name);

            builder.Entity<Item>()
                .HasAlternateKey(p => p.Name);

            builder.Entity<Item>()
                .HasMany(i => i.OrderItems)
                .WithOne(i => i.Item)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasMany(i => i.OrderItems)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderItem>()
                .HasKey(p => new { p.ItemId, p.OrderId });
        }
    }
}
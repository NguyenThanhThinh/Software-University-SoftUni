namespace SalesDatabase
{
    using Models;
    using System.Data.Entity;
    using Microsoft.EntityFrameworkCore;


    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContext)
            : base("name=SalesDbContext")
        {
            Database.SetInitializer(new SalesDbInitializer());
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<StoreLocation> StoreLocations { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(d => d.Description)
                .HasDefaultValue("sd");

        }
    }
}
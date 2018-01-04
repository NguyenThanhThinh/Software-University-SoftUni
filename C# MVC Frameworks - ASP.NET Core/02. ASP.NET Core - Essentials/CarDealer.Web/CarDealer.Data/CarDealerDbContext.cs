
namespace CarDealer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<PartCar> PartCars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartCar>()
                .HasKey(p => new { p.CarId, p.PartId });

            builder.Entity<Car>()
                .HasMany(c => c.Parts)
                .WithOne(pc => pc.Car)
                .HasForeignKey(pc => pc.CarId);

            builder.Entity<Part>()
                .HasMany(p => p.Cars)
                .WithOne(pc => pc.Part)
                .HasForeignKey(pc => pc.PartId);

            builder.Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CarId);

            builder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            builder.Entity<Sale>()
                .HasAlternateKey(p => new { p.CustomerId, p.CarId });

            builder.Entity<PartCar>(entity =>
            {
                entity.ToTable("PartCars");
            });

            base.OnModelCreating(builder);
        }
    }
}

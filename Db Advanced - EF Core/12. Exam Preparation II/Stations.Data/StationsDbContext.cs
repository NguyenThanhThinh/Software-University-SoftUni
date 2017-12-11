using Microsoft.EntityFrameworkCore;

namespace Stations.Data
{
    using Models;

    public class StationsDbContext : DbContext
    {
        public DbSet<CustomerCard> Cards { get; set; }

        public DbSet<SeatingClass> SeatingClasses { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Train> Trains { get; set; }

        public DbSet<TrainSeat> TrainSeats { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public StationsDbContext()
        {
        }

        public StationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Station>()
                .HasAlternateKey(s => s.Name);

            builder.Entity<Train>()
                .HasAlternateKey(t => t.TrainNumber);

            builder.Entity<SeatingClass>()
                .HasAlternateKey(st => new { st.Name, st.Abbreviation });

            builder.Entity<Station>()
                .HasMany(t => t.TripsTo)
                .WithOne(s => s.DestinationStation)
                .HasForeignKey(t => t.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Station>()
                .HasMany(t => t.TripsFrom)
                .WithOne(s => s.OriginStation)
                .HasForeignKey(t => t.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
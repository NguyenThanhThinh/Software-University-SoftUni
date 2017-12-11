namespace MyCoolWebServer.GameStoreApplication.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class GameStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=.;Database=GameStoreDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGame>()
                .HasKey(ug => new { ug.GameId, ug.UserId });

            builder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique(true);

            builder.Entity<Game>()
                .HasMany(u => u.Users)
                .WithOne(ug => ug.Game)
                .HasForeignKey(ug => ug.GameId);

            builder.Entity<User>()
                .HasMany(g => g.Games)
                .WithOne(ug => ug.User)
                .HasForeignKey(ug => ug.UserId);
        }
    }
}
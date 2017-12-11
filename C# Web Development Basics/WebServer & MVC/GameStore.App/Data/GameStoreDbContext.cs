namespace GameStore.App.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class GameStoreDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=.;Database=GameStoreDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGame>(entity =>
            {
                entity
                    .HasKey(ug => new { ug.GameId, ug.UserId });

                entity
                    .ToTable("Orders");

                entity
                    .HasOne(g => g.Game)
                    .WithMany(u => u.Users)
                    .HasForeignKey(ug => ug.GameId);

                entity
                    .HasOne(u => u.User)
                    .WithMany(g => g.Games)
                    .HasForeignKey(ug => ug.UserId);
            });

        }
    }
}
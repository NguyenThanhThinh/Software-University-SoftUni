namespace SimpleMvc.Domain.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SimpleMvcDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=.;Database=SimpleMvcDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Note>()
                .HasOne(u => u.User)
                .WithMany(n => n.Notes)
                .HasForeignKey(u => u.UserId);
        }
    }
}
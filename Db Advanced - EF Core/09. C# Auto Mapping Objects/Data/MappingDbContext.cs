namespace Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MappingDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public MappingDbContext()
        {
        }

        public MappingDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasOne(m => m.Manager)
                .WithMany(e => e.Employees)
                .HasForeignKey(m => m.ManagerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
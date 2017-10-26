namespace _01._CodeFirstStudent
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCource> StudentCources { get; set; }

        public DbSet<License> Licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=StudentDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCource>()
                .HasKey(k => new { k.StudentId, k.CourseId });

            builder.Entity<Student>()
                .HasMany(c => c.Courses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);

            builder.Entity<Course>()
                .HasMany(s => s.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(sc => sc.CourseId);

            builder.Entity<Student>()
                .HasMany(h => h.Homeworks)
                .WithOne(s => s.Student)
                .HasForeignKey(h => h.StudentId);

            builder.Entity<Course>()
                .HasMany(h => h.Homeworks)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            builder.Entity<Resource>()
                .HasOne(c => c.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(r => r.CourseId);

            builder.Entity<License>()
                .HasOne(r => r.Resource)
                .WithMany(l => l.Licenses)
                .HasForeignKey(l => l.ResourceId);
        }
    }
}
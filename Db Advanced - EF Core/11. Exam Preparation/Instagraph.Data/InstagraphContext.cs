namespace Instagraph.Data
{
    using Microsoft.EntityFrameworkCore;
    using ModelConfigurations;
    using Models;

    public class InstagraphContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserFollower> UsersFollowers { get; set; }

        public InstagraphContext() { }

        public InstagraphContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PictureConfig());

            modelBuilder.ApplyConfiguration(new PostConfig());

            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new UsersFollowersConfig());

            modelBuilder.ApplyConfiguration(new CommentConfig());
        }
    }
}
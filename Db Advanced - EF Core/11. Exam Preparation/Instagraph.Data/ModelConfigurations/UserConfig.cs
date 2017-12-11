namespace Instagraph.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Followers)
                .WithOne(uf => uf.User)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.UsersFollowing)
                .WithOne(uf => uf.Follower)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasAlternateKey(p => p.Username);

            builder
                .Property(p => p.Username)
                .HasMaxLength(30);

            builder
                .Property(p => p.Password)
                .HasMaxLength(20);

            builder
                .Property(p => p.Username)
                .IsRequired(true);

            builder
                .Property(p => p.Password)
                .IsRequired(true);

            builder
                .Property(p => p.ProfilePictureId)
                .IsRequired(true);
        }
    }
}
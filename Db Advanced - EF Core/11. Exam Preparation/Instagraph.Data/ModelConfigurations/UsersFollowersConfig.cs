namespace Instagraph.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UsersFollowersConfig : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder
                .HasKey(uf => new { uf.UserId, uf.FollowerId });

            builder
                .ToTable("UsersFollowers");

            builder
                .Property(p => p.UserId)
                .IsRequired(true);

            builder
                .Property(p => p.FollowerId)
                .IsRequired(true);
        }
    }
}
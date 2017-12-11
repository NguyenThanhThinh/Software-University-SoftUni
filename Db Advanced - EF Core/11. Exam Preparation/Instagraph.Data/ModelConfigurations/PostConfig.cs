namespace Instagraph.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(p => p.Caption)
                .IsRequired(true);

            builder
                .Property(p => p.UserId)
                .IsRequired(true);

            builder
                .Property(p => p.PictureId)
                .IsRequired(true);
        }
    }
}
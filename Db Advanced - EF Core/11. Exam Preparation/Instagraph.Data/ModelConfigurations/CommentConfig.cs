namespace Instagraph.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .Property(p => p.Content)
                .IsRequired(true);

            builder
                .Property(p => p.UserId)
                .IsRequired(true);

            builder
                .Property(p => p.PostId)
                .IsRequired(true);

            builder
                .Property(p => p.Content)
                .HasMaxLength(250);
        }
    }
}
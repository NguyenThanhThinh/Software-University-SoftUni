namespace Instagraph.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder
                .HasMany(p => p.Posts)
                .WithOne(p => p.Picture)
                .HasForeignKey(p => p.PictureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Users)
                .WithOne(u => u.ProfilePicture)
                .HasForeignKey(u => u.ProfilePictureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(p => p.Path)
                .IsRequired(true);

            builder
                .Property(p => p.Size)
                .IsRequired(true);
        }
    }
}
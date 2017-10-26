namespace _02.Photo
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PhotoContext : DbContext
    {
        public DbSet<Photographer> Photographers { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<PictureAlbum> PictureAlbums { get; set; }

        public DbSet<TagAlbum> TagAlbum { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=.;Database=PhotoDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PhotographerAlbum>()
                .HasKey(pk => new { pk.PhotographerId, pk.AlbumId });

            builder.Entity<Album>()
                .HasMany(p => p.AlbumsPhotographer)
                .WithOne(a => a.Album)
                .HasForeignKey(pa => pa.PhotographerId);

            builder.Entity<Photographer>()
                .HasMany(a => a.PhotographerAlbums)
                .WithOne(p => p.Photographer)
                .HasForeignKey(a => a.AlbumId);

            builder.Entity<PictureAlbum>()
                .HasKey(pk => new { pk.AlbumId, pk.PictureId });

            builder.Entity<Picture>()
                .HasMany(a => a.PictureAlbums)
                .WithOne(p => p.Picture)
                .HasForeignKey(pa => pa.AlbumId);

            builder.Entity<Album>()
                .HasMany(p => p.AlbumPictures)
                .WithOne(a => a.Album)
                .HasForeignKey(pa => pa.PictureId);

            builder.Entity<TagAlbum>()
                .HasKey(ta => new { ta.TagId, ta.AlbumId });

            builder.Entity<Album>()
                .HasMany(t => t.AlbumTags)
                .WithOne(a => a.Album)
                .HasForeignKey(t => t.TagId);

            builder.Entity<Tag>()
                .HasMany(a => a.TagAlbums)
                .WithOne(t => t.Tag)
                .HasForeignKey(a => a.AlbumId);

            builder.Entity<Tag>()
                .HasIndex(t => t.TagValue)
                .IsUnique();
        }
    }
}
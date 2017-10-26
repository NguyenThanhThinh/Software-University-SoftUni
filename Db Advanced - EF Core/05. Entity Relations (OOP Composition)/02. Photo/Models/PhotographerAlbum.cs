namespace _02.Photo.Models
{
    public class PhotographerAlbum
    {
        public Photographer Photographer { get; set; }

        public int PhotographerId { get; set; }

        public Album Album { get; set; }

        public int AlbumId { get; set; }
    }
}
namespace _02.Photo.Models
{
    public class TagAlbum
    {
        public Tag Tag { get; set; }

        public int TagId { get; set; }

        public Album Album { get; set; }

        public int AlbumId { get; set; }
    }
}
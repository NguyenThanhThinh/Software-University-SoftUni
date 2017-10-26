namespace _02.Photo.Models
{

    public class PictureAlbum
    {
        public Album Album { get; set; }

        public int AlbumId { get; set; }

        public Picture Picture { get; set; }

        public int PictureId { get; set; }
    }
}
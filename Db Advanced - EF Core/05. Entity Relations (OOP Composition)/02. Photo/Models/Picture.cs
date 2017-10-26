namespace _02.Photo.Models
{
    using System.Collections.Generic;

    public class Picture
    {
        public int PictureId { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string Path { get; set; }

        public IList<PictureAlbum> PictureAlbums { get; set; } = new List<PictureAlbum>();
    }
}
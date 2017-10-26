namespace _02.Photo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        public string BackgroundColor { get; set; }

        public Boolean IsPublic { get; set; }

        public int PhotographerId { get; set; }

        public IList<PhotographerAlbum> AlbumsPhotographer { get; set; } = new List<PhotographerAlbum>();

        public IList<PictureAlbum> AlbumPictures { get; set; } = new List<PictureAlbum>();

        public IList<TagAlbum> AlbumTags { get; set; } = new List<TagAlbum>();
    }
}
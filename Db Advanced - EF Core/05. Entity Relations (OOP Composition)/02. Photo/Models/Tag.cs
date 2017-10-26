namespace _02.Photo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;

    public class Tag
    {

        public int TagId { get; set; }

        private string tagValue;

        [Required]
        [TagAttribute]
        public string TagValue
        {
            get { return this.tagValue; }
            set
            {

                if (this.IsTagValid(value))
                {
                    this.tagValue = value;
                }
                else
                {
                    Console.WriteLine(@"Tag must begin with ""#""");
                }
            }
        }

        public IList<TagAlbum> TagAlbums { get; set; } = new List<TagAlbum>();

        private bool IsTagValid(string value)
        {
            if (value.StartsWith("#"))
            {
                return true;
            }
            return false;
        }
    }
}
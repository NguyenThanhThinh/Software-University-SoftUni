namespace News.Services.Models
{
    using System;
    using Common.Mapping;
    using Data.Models;

    public class NewsFullDetailsServiceModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
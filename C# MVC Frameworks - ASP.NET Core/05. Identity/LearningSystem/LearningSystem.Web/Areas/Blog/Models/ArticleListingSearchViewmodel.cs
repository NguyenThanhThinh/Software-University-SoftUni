namespace LearningSystem.Web.Areas.Blog.Models
{
    using System.Collections.Generic;
    using Services.Blog.Models;

    public class ArticleListingSearchViewModel
    {
        public IEnumerable<ArticleListingServiceModel> Articles { get; set; }

        public string SearchText { get; set; }
    }
}
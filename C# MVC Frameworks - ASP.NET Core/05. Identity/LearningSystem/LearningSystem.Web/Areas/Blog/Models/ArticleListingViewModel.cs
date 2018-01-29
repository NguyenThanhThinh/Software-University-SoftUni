namespace LearningSystem.Web.Areas.Blog.Models
{
    using System;
    using System.Collections.Generic;
    using Services;
    using Services.Blog.Models;

    public class ArticleListingViewModel
    {
        public IEnumerable<ArticleListingServiceModel> Articles { get; set; }

        public int TotalArticels { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticels / ServiceConstants.BlogArticlesPageSize);

        public int CurrentPage { get; set; }

        public int NextPage => this.CurrentPage == this.TotalPages ? this.CurrentPage : this.CurrentPage + 1;

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;
    }
}
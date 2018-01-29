namespace LearningSystem.Services.Blog
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        Task CreateAsync(string content, string title, DateTime published, string authorId);

        Task<IEnumerable<ArticleListingServiceModel>> AllAsync(int page);

        Task<int> TotalAsync();

        Task<ArticleDetailsServiceModel> DetailsAsync(int articleId);

        Task<IEnumerable<ArticleListingServiceModel>> FindAsync(string searchText);
    }
}
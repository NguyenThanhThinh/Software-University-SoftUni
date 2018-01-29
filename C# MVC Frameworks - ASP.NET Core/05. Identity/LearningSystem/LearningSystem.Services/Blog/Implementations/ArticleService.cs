namespace LearningSystem.Services.Blog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServiceConstants;

    public class ArticleService : IArticleService
    {
        private readonly LearningSystemDbContext db;

        public ArticleService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string content, string title, DateTime published, string authorId)
        {
            var article = new Article
            {
                AuthorId = authorId,
                Content = content,
                Published = published,
                Title = title
            };

            this.db.Articles.Add(article);

            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> AllAsync(int page = 1)
        {
            return await this.db.Articles
                .OrderByDescending(a => a.Published)
                .Skip((page - 1) * BlogArticlesPageSize)
                .Take(BlogArticlesPageSize)
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();
        }

        public async Task<int> TotalAsync()
        {
            return await this.db.Articles.CountAsync();
        }

        public async Task<ArticleDetailsServiceModel> DetailsAsync(int articleId)
        {
            return await this.db.Articles
                .Where(a => a.Id == articleId)
                .ProjectTo<ArticleDetailsServiceModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            var articles = await this.db.Articles
                .OrderByDescending(a => a.Id)
                .Where(a => a.Title.ToLower().Contains(searchText.ToLower()) ||
                            a.Content.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();

            return articles;
        }
    }
}
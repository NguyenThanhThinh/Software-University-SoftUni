namespace News.Services.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class NewsService : INewsService
    {
        private readonly NewsDbContext db;

        public NewsService(NewsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<NewsFullDetailsServiceModel>> All()
            => await this.db.News
                .OrderBy(n => n.PublishDate)
                .ProjectTo<NewsFullDetailsServiceModel>()
                .ToListAsync();

        public async Task<int> Create(string title, string content, DateTime publishDate)
        {
            var news = new News
            {
                Title = title,
                Content = content,
                PublishDate = publishDate
            };

            await this.db.News.AddAsync(news);
            await this.db.SaveChangesAsync();

            return news.Id;
        }

        public async Task<NewsFullDetailsServiceModel> UpdateById(int id, string title, string content, DateTime publishDate)
        {
            var news = await this.db.News
                .Where(n => n.Id == id)
                .ProjectTo<NewsFullDetailsServiceModel>()
                .FirstOrDefaultAsync();

            news.Title = title;
            news.Content = content;
            news.PublishDate = publishDate;

            await this.db.SaveChangesAsync();

            return news;
        }

        public async Task<int> Delete(int id)
        {
            var news = await this.db.News
                .FirstOrDefaultAsync(n => n.Id == id);

            if (news == null)
            {
                return 0;
            }

            this.db.Remove(news);
            await this.db.SaveChangesAsync();

            return news.Id;
        }
    }
}
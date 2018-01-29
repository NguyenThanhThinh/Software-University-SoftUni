namespace News.Services
{
    using System;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INewsService
    {
        Task<IEnumerable<NewsFullDetailsServiceModel>> All();

        Task<int> Create(string title, string content, DateTime publishDate);

        Task<NewsFullDetailsServiceModel> UpdateById(int id, string title, string content, DateTime publishDate);

        Task<int> Delete(int id);
    }
}
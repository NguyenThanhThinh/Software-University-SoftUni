namespace BookShop.Services
{
    using Models.Author;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<GetAuthorByIdServiceModel> GetByIdAsync(int id);

        Task CreateAsync(string firstName, string lastName);

        Task<IEnumerable<GetBooksDetailsServiceModel>> GetBooksAsync(int authorId);

        Task<bool> Exist(int id);
    }
}
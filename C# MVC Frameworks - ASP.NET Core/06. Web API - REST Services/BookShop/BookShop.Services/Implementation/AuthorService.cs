namespace BookShop.Services.Implementation
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Author;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<GetAuthorByIdServiceModel> GetByIdAsync(int id)
            => await this.db.Authors
                        .Where(a => a.Id == id)
                        .ProjectTo<GetAuthorByIdServiceModel>()
                        .FirstOrDefaultAsync();

        public async Task CreateAsync(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            await this.db.Authors.AddAsync(author);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetBooksDetailsServiceModel>> GetBooksAsync(int authorId)
        {
            var books = await this.db.Books
                .Where(b => b.AuthorId == authorId)
                .ProjectTo<GetBooksDetailsServiceModel>()
                .ToListAsync();

            if (books.Count == 0)
            {
                return null;
            }

            return books;
        }

        public Task<bool> Exist(int id)
            => this.db.Authors.AnyAsync(a => a.Id == id);
    }
}
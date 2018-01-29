namespace BookShop.Services.Models.Author
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class GetAuthorByIdServiceModel : IMapFrom<Author>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> BookTitles { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Author, GetAuthorByIdServiceModel>()
                .ForMember(a => a.BookTitles, cfg => cfg
                    .MapFrom(a => a.Books
                        .Select(b => b.Title)));
        }
    }
}
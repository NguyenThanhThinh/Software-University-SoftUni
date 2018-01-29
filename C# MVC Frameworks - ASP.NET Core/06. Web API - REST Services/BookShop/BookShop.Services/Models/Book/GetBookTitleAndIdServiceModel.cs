namespace BookShop.Services.Models.Book
{
    using Common.Mapping;
    using Data.Models;

    public class GetBookTitleAndIdServiceModel : IMapFrom<Book>
    {
        public string Title { get; set; }

        public int Id { get; set; }
    }
}
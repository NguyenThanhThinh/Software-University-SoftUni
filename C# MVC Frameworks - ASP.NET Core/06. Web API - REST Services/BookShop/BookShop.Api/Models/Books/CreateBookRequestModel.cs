namespace BookShop.Api.Models.Books
{
    public class CreateBookRequestModel : BookDetailsPartialModel
    {
        public string CategoryNames { get; set; }
    }
}
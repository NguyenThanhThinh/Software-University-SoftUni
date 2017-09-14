
namespace _09.BookLibrary
{
    class Book
    {
        private string title = string.Empty;
        private string author = string.Empty;
        private string publisher = string.Empty;
        private string releaseDate = string.Empty;
        private string isbnNumber = string.Empty;
        private double price = 0d;

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string IsbnNumber { get; set; }
        public double Price { get; set; }

    }
}
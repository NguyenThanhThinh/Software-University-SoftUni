using System;

namespace _10.BookLibraryModification
{
    class Book
    {
        private string title = string.Empty;
        private string author = string.Empty;
        private string publisher = string.Empty;
        private DateTime releaseDate = new DateTime();
        private string isbnNumber = string.Empty;
        private double price = 0d;

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbnNumber { get; set; }
        public double Price { get; set; }
    }
}
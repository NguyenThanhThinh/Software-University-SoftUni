using System;

namespace _05.BookLibraryModifed
{
    class Book
    {
        //the title, author, publisher, release date, ISBN-number and price. 
        public string title;
        public string author;
        public string publisher;
        public DateTime releaseDate;
        public string isbnNumber;
        public decimal price;

        //public string Title { get; set; }
        //public string Author { get; set; }
        //public string Publisher { get; set; }
        //public string ReleaseDate { get; set; }
        //public string IsbnNumber { get; set; }
        //public decimal Price { get; set; }

        public Book()
        {

        }

        public Book(string title, string author, string publisher, DateTime releaseDate, string isbnNumber, decimal price)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.releaseDate = releaseDate;
            this.isbnNumber = isbnNumber;
            this.price = price;
        }
    }
}
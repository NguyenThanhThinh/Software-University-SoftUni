using System.Collections.Generic;

namespace _05.BookLibraryModifed
{
    class Library
    {
        //public string name;
        //public List<Book> books = new List<Book>();

        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Library()
        {
            this.Books = new List<Book>();
        }
    }
}
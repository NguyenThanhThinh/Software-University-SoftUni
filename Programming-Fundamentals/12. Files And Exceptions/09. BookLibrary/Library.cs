using System.Collections.Generic;

namespace _09.BookLibrary
{
    class Library
    {
        private string name = string.Empty;
        private List<Book> books = new List<Book>();

        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Library()
        {
            this.Books = new List<Book>();
        }
    }
}
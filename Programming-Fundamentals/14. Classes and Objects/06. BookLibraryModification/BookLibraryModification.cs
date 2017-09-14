using System;
using System.Globalization;
using System.Linq;

namespace _05.BookLibraryModifed
{
    class BookLibraryModification
    {
        static void Main()
        {
            int booksNumber = int.Parse(Console.ReadLine());
            var bookLibrary = new Library();
            DateTime date = new DateTime();
            var book = new Book();

            for (int i = 0; i < booksNumber + 1; i++)
            {
                var bookInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (bookInput.Length > 1)
                {
                    book = new Book(bookInput[0], bookInput[1], bookInput[2], DateTime.ParseExact(bookInput[3], "dd.MM.yyyy", 
                        CultureInfo.InvariantCulture), bookInput[4], decimal.Parse(bookInput[5]));

                    bookLibrary.Books.Add(book);
                }
                else
                {
                    date = DateTime.ParseExact(bookInput[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                }
            }
            bookLibrary.Name = "First Library";
            Console.WriteLine();

            var result = bookLibrary.Books.Where(n => n.releaseDate > date).OrderBy(m => m.releaseDate).ThenBy(c => c.title);

            foreach (var title in result)
            {
                Console.WriteLine("{0} -> {1:dd.MM.yyyy}", title.title, title.releaseDate);
            }
        }
    }
}
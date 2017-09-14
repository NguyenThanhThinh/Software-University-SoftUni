using System;
using System.Linq;

namespace _05.BookLibrary
{
    class BookLibrary
    {
        static void Main()
        {
            int booksNumber = int.Parse(Console.ReadLine());
            var bookLibrary = new Library();

            for (int i = 0; i < booksNumber; i++)
            {
                var bookInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var book = new Book(bookInput[0], bookInput[1], bookInput[2], bookInput[3], bookInput[4], decimal.Parse(bookInput[5]));

                bookLibrary.Books.Add(book);
            }
            bookLibrary.Name = "First Library";
            Console.WriteLine();

            var filteredBooks = bookLibrary.Books.
                            Select(b => new
                            {
                                author = b.author,
                                EarningsTotal = bookLibrary.Books
                                    .Where(b1 => b1.author.Equals(b.author))
                                    .Sum(b1 => b1.price)
                            })
                            .Distinct()
                            .OrderByDescending(b => b.EarningsTotal)
                            .ThenBy(b => b.author)
                            .ToList();
            foreach (var book in filteredBooks)
            {
                Console.WriteLine("{0:f2} -> {1:f2}", book.author, book.EarningsTotal);
            }
        }
    }
}
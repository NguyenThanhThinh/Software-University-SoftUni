using System;
using System.Linq;
using System.IO;
using System.Globalization;

namespace _10.BookLibraryModification
{
    class BookLibraryModification
    {
        static void Main()
        {
            var input = File.ReadAllLines(@"../../input.txt");
            Library library = new Library();
            library.Name = "Sevi";
            DateTime date = new DateTime();

            for (int i = 1; i < input.Length - 1; i++)
            {
                var currentLine = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                library.Books.Add(CreateBook(currentLine[0], currentLine[1], currentLine[2], DateTime.ParseExact(currentLine[3], "dd.MM.yyyy", CultureInfo.InvariantCulture), currentLine[4], double.Parse(currentLine[5])));
            }

            date = DateTime.ParseExact(input[input.Length - 1], "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var book in library.Books.Where(n => n.ReleaseDate > date).OrderBy(m => m.ReleaseDate).ThenBy(z => z.Title))
            {
                File.AppendAllText(@"../../output.txt", book.Title + " -> " + book.ReleaseDate.ToString("dd.MM.yyyy") + Environment.NewLine);
            }

        }

        private static Book CreateBook(string title, string author, string publisher, DateTime releaseDate, string isbnNumber, double price)
        {
            var book = new Book();
            book.Author = author;
            book.Publisher = publisher;
            book.Title = title;
            book.ReleaseDate = releaseDate;
            book.Price = price;
            book.IsbnNumber = isbnNumber;

            return book;
        }
    }
}